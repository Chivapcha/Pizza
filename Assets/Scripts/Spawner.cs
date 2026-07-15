using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] food;
    public float borderLR = 2.3f;
    public int borderTop = 30; // ending point (may make that the finish line position later)
    public int borderBottom = 2; // starting point
    public int distanceBetween = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initializing all the food
        int posZ = borderBottom; // starting point

        while (posZ <= borderTop) // while not at the end
        {
            if (posZ % distanceBetween == 0) // if we are at the needed distance between foods
            {
                float posX = Random.Range(-borderLR, borderLR);
                Vector3 position = new Vector3(posX, 0.5f, posZ); // pos is random x, defined y and actual z
                GameObject foodItem = food[Random.Range(0, food.Length)]; // we choose a random food

                Instantiate(foodItem, position, foodItem.transform.rotation);
            }
            posZ++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
