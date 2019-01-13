using System.Collections;
using UnityEngine;

public class LampTurnOff : MonoBehaviour
{
    public GameObject WallLampLight;
    public AudioSource DyingLampSound;
    public GameObject Trigger;
    private void OnTriggerEnter() 
    {
        StartCoroutine("DyingLamp");
        
    }

    IEnumerator DyingLamp()
    {
        DyingLampSound.Play();
        yield return new WaitForSeconds(1f);
        WallLampLight.SetActive(false);
        Trigger.SetActive(false);
    }
}
