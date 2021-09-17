using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDelivery : MonoBehaviour
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
    private void Implements()
    {
        BoxColl = GetComponent<BoxCollider2D>();
    }
    private void DeliveryCheck()
    {
        if (Tounching == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("CheckPoint11");
            if (ItemGen.HaveItem != false && ItemGen.TypeGenerator >= 3 && ItemGen.TypeGenerator <= 5)
            {
                Debug.Log("CheckPoint12");                
                ItemGen.HaveItem = false;
                UI.ScoreAdd();                
                return;
            }
            else if (ItemGen.HaveItem != false && ItemGen.TypeGenerator < 3 || ItemGen.TypeGenerator > 5)
            {
                Debug.Log("CheckPoint13");
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
