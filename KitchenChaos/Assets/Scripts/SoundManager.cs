using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private AudioClipsRefSO audioClipsRefSO;

    private void Start(){

        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;

    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioClipsRefSO.trash, trashCounter.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipsRefSO.objectDrop, baseCounter.transform.position);
    }

    private void Player_OnPickedSomething(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsRefSO.objectPick, Player.Instance.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipsRefSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e){
        PlaySound(audioClipsRefSO.deliveryFail, Camera.main.transform.position,0.3f);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e){
        PlaySound(audioClipsRefSO.deliverySuccess, Camera.main.transform.position, 0.3f);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position,float volume =1f) {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume); 
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    public void PlayFootStepSound (Vector3 position, float volume) {

        PlaySound(audioClipsRefSO.footstep, position, volume);

    }


}
