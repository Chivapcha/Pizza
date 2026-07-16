using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] food;
    public float borderLR = 2.3f;
    public int borderTop = 30; // ending point (may make that the finish line position later)
    public int borderBottom = 2; // starting point
    public int distanceBetween = 3;
    public GameObject ingredient;
    private GameObject clone;

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

                clone = Instantiate(foodItem, position, foodItem.transform.rotation);
                clone.name = foodItem.name; // to get the pizza ingredient shown correctly in the Spinner_Collector script
                // there is probably a better way to do so though
            }
            posZ++;
        }
    }
}
