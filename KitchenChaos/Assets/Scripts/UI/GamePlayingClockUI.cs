using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour{

    [SerializeField] private Image timerImg;

    private void Update()
    {
        timerImg.fillAmount = KitchenGameManager.Instance.GetGamePlayingTimerNormalized();
    }

}
