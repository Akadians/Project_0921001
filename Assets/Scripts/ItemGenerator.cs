using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] Item;    
    public LayerMask Player;
    public bool HaveItem = false;
    public int TypeGenerator;

    private bool Tounching = false;
    private BoxCollider2D boxColl;

    // Start is called before the first frame update
    void Start()
    {
        Implements();
    }
    private void Update()
    {
        ItemGen();
        CheckRoutine();
    }
    private void Implements()
    {
        boxColl = GetComponent<BoxCollider2D>();        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touch");
        Tounching = true;
        return;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("TouchOut " + TypeGenerator);
        Tounching = false;
        return;
    }
    private void ItemGen()
    {
        if (Tounching != false && Input.GetKeyDown(KeyCode.Space) && HaveItem == false)
        {
            TypeGenerator = Random.Range(0, 14);
            Item[TypeGenerator].SetActive(true);
            HaveItem = true;
            return;
        }
        else if (Tounching != true && Input.GetKeyDown(KeyCode.Space) && HaveItem == true)
        {
            Debug.Log("Can't");
            return;
        }
    }
    private void CheckRoutine ()
    {
        if(HaveItem == false)
        {
            Item[TypeGenerator].SetActive(false);
        }
    }
}