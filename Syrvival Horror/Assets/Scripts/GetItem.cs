using UnityEngine;
using UnityEngine.UI;


public class GetItem : MonoBehaviour
{

    public float Distance;
    public float InteractableDistance = 3f;
    public GameObject ActionText;
    public GameObject PlayerFlashlight;
    public GameObject Flashlight;
    public GameObject ActionKey;
    public GameObject PlayerTalking;

    void Update()
    {
        Distance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (Distance < InteractableDistance)
        {
            ActionText.SetActive(true);
            ActionKey.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                this.enabled = false;
                Flashlight.SetActive(false);
                PlayerFlashlight.SetActive(true);

            }

        }
        else
        {
            ActionText.SetActive(false);
            ActionKey.SetActive(false);
            PlayerTalking.GetComponent<Text>().text = "";
        }

    }


    private void OnMouseExit()
    {
        ActionText.SetActive(false);
        ActionKey.SetActive(false);
        PlayerTalking.GetComponent<Text>().text = "";
    }
}
