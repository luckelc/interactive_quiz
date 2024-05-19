using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{

    public List<Image> houses = new List<Image>();

    [SerializeField]
    Sprite regHouse;

    [SerializeField]
    Sprite newHouse;

    [SerializeField]
    private int comparisonValue; // The int value to compare against the child's position in the hierarchy

    public int ComparisonValue
    {
        get { return comparisonValue; }
        set
        {
            comparisonValue = value;
            UpdateChildrenColors(); // Update colors whenever the value changes
        }
    }
    public Color newColor; // The color to change to if the condition is met
    public Color defaultColor; // The default color if the condition is not met

    // Start is called before the first frame update
    void Start()
    {
        UpdateChildrenColors();
    }

    private void OnValidate()
    {
        UpdateChildrenColors();
    }

    public void AddPoints(int pointSet)
    {
        ComparisonValue += pointSet;
    }

    private void UpdateChildrenColors()
    {
        if(comparisonValue >= 8)
        {
            houses[2].sprite = newHouse;
        }else if (comparisonValue >= 6)
        {
            houses[1].sprite = newHouse;
        }
        else if (comparisonValue >= 4)
        {
            houses[0].sprite = newHouse;
        }

        // Loop through all child transforms
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Image childImage = child.GetComponent<Image>();

            // If the child has an Image component, change its color based on the condition
            if (childImage != null)
            {
                // Get the sibling index of the child in the hierarchy
                int siblingIndex = child.GetSiblingIndex();

                // Compare the sibling index with the comparison value
                if (comparisonValue > siblingIndex)
                {
                    // Change the color if the condition is met
                    childImage.color = newColor;
                }
                else
                {
                    // Otherwise, set to the default color
                    childImage.color = defaultColor;
                }
            }
            else
            {
                Debug.LogWarning($"No Image component found on child {child.name}");
            }
        }
    }
}
