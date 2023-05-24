using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryManagerSingleUI : MonoBehaviour{

    [SerializeField] private TextMeshProUGUI recipeNameText;

    public void SetRecipeSO(RecipeSO recipeSO) {

        Debug.Log("Data 2 : " + recipeSO);
        Debug.Log("Data 3 : " + recipeSO.recipeName);
        recipeNameText.text = recipeSO.recipeName;

    }

}
