using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.InputSystem;

public class TestMoph : MonoBehaviour
{
    [SerializeField] VisualEffect _visualEffect;
    [SerializeField] SkinnedMeshRenderer[] _skinnedMeshRenderers;
    [SerializeField] string sourceName;
    [SerializeField, Range(0, 1)] int change; 
    Vector3 orgin;
    int Count;
    // Start is called before the first frame update
    void Start()
    {
        orgin = transform.position;
        Count = 0;
        if (_skinnedMeshRenderers[0] != null)
        _visualEffect.SetSkinnedMeshRenderer(sourceName, _skinnedMeshRenderers[Count]);
        if (Count == 0)
        {
            transform.position -= new Vector3(0, 1, 0);
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Count = change;
        InputsChange();
    }

    public void InputsChange()
    {
        //Count++;
        //Count = Count % _skinnedMeshRenderers.Length;
        if (Count == 0)
        {
            Vector3 a = transform.position;
            a.y = 0;
            transform.position = a;
        }
        else
        {
            Vector3 a = transform.position;
            a.y = 1;
            transform.position = a;
        }
        if (_skinnedMeshRenderers[0] != null)
            _visualEffect.SetSkinnedMeshRenderer(sourceName, _skinnedMeshRenderers[Count]);
    }
}
