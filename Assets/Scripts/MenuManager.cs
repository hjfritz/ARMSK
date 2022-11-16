using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject shoulderMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartShoulderExam()
    {
        menu.SetActive(false);
        shoulderMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
