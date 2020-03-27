using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownPanel : MonoBehaviour
{
    public GameObject[] dropdownObjects;
    public Dropdown myDropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdownObjects = GameObject.FindGameObjectsWithTag("RealItem"); // For example
        PopulateDropdown(myDropdown, dropdownObjects);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateDropdown(Dropdown dropdown, GameObject[] optionsArray)
    {
        List<string> options = new List<string>();
        foreach (var option in optionsArray)
        {
            options.Add(option.name); // Or whatever you want for a label
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }
}
