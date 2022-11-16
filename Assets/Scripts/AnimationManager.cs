using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public int step = 1;

    // Start is called before the first frame update
    void Start()
    {
        _animator.Play(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStep()
    {
        step++;
        _animator.SetInteger("Step", step);
    }

    public void BackStep()
    {
        step--;
        _animator.SetInteger("Step", step);
    }
}
