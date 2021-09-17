using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticDelivery : MonoBehaviour
{
    public BoxCollider2D BoxColl;
    public ItemGenerator ItemGen;
    public UIController UI;

    private bool Tounching = false;
    // Start is called before the first frame update
    void Start()
    {
        Implements();
    }

    // Update is called once per frame
    void Update()
    {
        DeliveryCheck();
    }
    private void Implements ()
    {
        BoxColl = GetComponent<BoxCollider2D>();        
    }
    private void DeliveryCheck()
    {
        if(Tounching == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("CheckPoint01");
            if (ItemGen.HaveItem != false && ItemGen.TypeGenerator >= 0 && ItemGen.TypeGenerator <= 2)
            {
                Debug.Log("CheckPoint02");
                UI.ScoreAdd();
                ItemGen.HaveItem = false;
                return;
            }
            else if (ItemGen.HaveItem != false && ItemGen.TypeGenerator >2)
            {
                Debug.Log("CheckPoint03");
                UI.ScoreLess();
                ItemGen.HaveItem = false;
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tounching = true;
        return;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Tounching = false;
        return;
    }
}
