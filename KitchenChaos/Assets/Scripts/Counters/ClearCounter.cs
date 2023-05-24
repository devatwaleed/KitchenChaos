using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter{

    

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        //Checks if the counter where we will place things has nothing (=null)
        if (!HasKitchenObject()) {
            //Nope there is nothing
            if (player.HasKitchenObject()) {
                //Player have something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }else {
                //Player has nothing

            }

        }
        else {
            //Yes there is something
            if (player.HasKitchenObject()) {
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {

                    if (plateKitchenObject.TryAddingIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }

                }else { 
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        if (plateKitchenObject.TryAddingIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
                //Player have something

            }else {
                //Player have nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
