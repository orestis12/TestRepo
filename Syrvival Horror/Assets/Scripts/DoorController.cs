using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

    public float Distance;
    public float InteractableDistance = 3f;
    public GameObject ActionText;
    public GameObject ActionKey;
    public GameObject PlayerTalking;
    public GameObject Door;
    public GameObject Key;
    public AudioSource UnlockDoor;
    public AudioSource LockedDoor;
    public AudioSource DoorOpen;
    public AudioSource DoorClose;
    public bool isOpen = false;
    public bool isLocked = false;
   
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

            if (Input.GetButtonDown("Interact")){

                if (!isLocked)
                {
                    if (isOpen == false)
                    {
                        DoorOpen.Play();
                        Door.GetComponent<Animator>().Play("DoorOpen");
                        Door.GetComponentInChildren<BoxCollider>().enabled = false;
                        isOpen = true;
                    }
                    else
                    {
                        DoorClose.Play();
                        Door.GetComponent<Animator>().Play("DoorClose");
                        Door.GetComponentInChildren<BoxCollider>().enabled = true;
                        isOpen = false;
                    }
                }
                else
                {
                    if (Inventory.Items.Contains(Key))
                    {
                        isLocked = false;
                        UnlockDoor.Play();
                    }
                    else
                    {
                        LockedDoor.Play();
                        PlayerTalking.GetComponent<Text>().text = "It's locked!";
                    }
                   
                    
                }
                
                
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
