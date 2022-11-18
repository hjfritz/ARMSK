using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject step1Menu;
    [SerializeField] private GameObject step2Menu;
    [SerializeField] private GameObject step3Menu;
    [SerializeField] private GameObject step4Menu;

    public int step = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStep()
    {
        if (step >= 1 && step <= 3)
        {
            step++;
            _animator.SetInteger("Step", step);
            if (step == 1)
            {
                DeactivateMenus();
                step1Menu.SetActive(true);
            }else if (step == 2)
            {
                DeactivateMenus();
                step2Menu.SetActive(true);
            }else if (step == 3)
            {
                DeactivateMenus();
                step3Menu.SetActive(true);
            }else if (step == 4)
            {
                DeactivateMenus();
                step4Menu.SetActive(true);
            }
        }
    }

    public void BackStep()
    {
        if (step >= 2 && step <= 4)
        {
            step--;
            _animator.SetInteger("Step", step);
            if (step == 1)
            {
                DeactivateMenus();
                step1Menu.SetActive(true);
            }else if (step == 2)
            {
                DeactivateMenus();
                step2Menu.SetActive(true);
            }else if (step == 3)
            {
                DeactivateMenus();
                step3Menu.SetActive(true);
            }else if (step == 4)
            {
                DeactivateMenus();
                step4Menu.SetActive(true);
            }
        }
    }

    private void DeactivateMenus()
    {
        step1Menu.SetActive(false);
        step2Menu.SetActive(false);
        step3Menu.SetActive(false);
        step4Menu.SetActive(false);
    }
}
