using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    public GameObject lightObject; // assign the Spot Light GameObject

    public void ToggleLight()
    {
        if (lightObject) lightObject.SetActive(!lightObject.activeSelf);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
