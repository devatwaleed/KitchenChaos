using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour{

    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator animator;
    private const string CUT = "Cut";
    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Start(){
        cuttingCounter.Oncut += CuttingCounter_Oncut;
    }

    private void CuttingCounter_Oncut(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }

}
