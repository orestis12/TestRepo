using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using System.Collections;

public class OpeningScene : MonoBehaviour
{

    public GameObject Player;
    public GameObject PlayerTalking;
    public GameObject FadingIn;

    void Start()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine("StartingScene");
        
    }

    IEnumerator StartingScene()
    {
        yield return new WaitForSeconds(1f);
        FadingIn.SetActive(false);
        PlayerTalking.GetComponent<Text>().text = "Where am i?";
        PlayerTalking.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        PlayerTalking.GetComponent<Text>().text = "";
        Player.GetComponent<FirstPersonController>().enabled = true;
    }
}
