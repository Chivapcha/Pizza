using UnityEngine;

public class PizzaController : MonoBehaviour
{
    public void ShowIngredient(string nameBase)
    {
        string ingredientName = "pizza" + nameBase;
        Transform ingredientToShow = transform.Find(ingredientName);
        if (!ingredientToShow)
        {
            Debug.Log(ingredientName + " not found");
            return;
        }
        ingredientToShow.gameObject.SetActive(true);
        Debug.Log(ingredientName + " enabled");
    }
}
