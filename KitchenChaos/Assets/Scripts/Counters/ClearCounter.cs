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
                Debug.Log("This is that something" + this);
            }else {
                //Player has nothing

            }

        }
        else {
            //Yes there is something
            if (player.HasKitchenObject()) {
                //Player have something

            }
            else {
                //Player have nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
