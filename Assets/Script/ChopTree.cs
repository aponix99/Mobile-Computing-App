using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerInRange;
    public GameObject tree;
    public bool isHitted;
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    void Start()
    {

    }

    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && playerInRange)
        {
            if (tree.activeInHierarchy)
            {
                tree.SetActive(false);
                hit();
                spawnObject();
            }
            else
            {
                tree.SetActive(true);
                
            }
        }
      
        } 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) { 
            playerInRange = false;
        }
    }

    public void isHit()
    {
        if (!gameObject)
            isHitted = true;
        isHitted = false;
    }
        public void hit()
    {
        Destroy(gameObject);
    }
    public void spawnObject()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;

        }
    }


}