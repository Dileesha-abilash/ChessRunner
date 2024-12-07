using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private GameObject followObj;

public float jumpDuration = 1f;
public float jumpHeight = 2f;
    private Vector3 followposition;
    // Start is called before the first frame update
    void Start()
    {
           followposition = followObj.GetComponent<Transform>().position;
        }

        // Update is called once per frame
        void Update()
        {
            
           followposition = followObj.GetComponent<Transform>().position;
            transform.DOJump(followposition, jumpHeight, 1, jumpDuration);
            
        }
    }
