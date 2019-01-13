using UnityEngine;
using UnityEngine.UI;


public class AquireItem : MonoBehaviour
{

    public float Distance;
    public float InteractableDistance = 3f;
    public GameObject ActionText;
    public GameObject Item;
    public GameObject ActionKey;
    public GameObject PlayerTalking;
    //public GameObject Inventory;

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
                Item.SetActive(false);
                Inventory.Items.Add(Item); 

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
