using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.InputSystem;

public class TestMoph : MonoBehaviour
{
    [SerializeField] VisualEffect _visualEffect;
    //[SerializeField] SkinnedMeshRenderer[] _skinnedMeshRenderers;
    [SerializeField] string changesourceName;
    [SerializeField] string noiseName = "Noise";
    [SerializeField, Range(0, 300)] float noiseField;
    [SerializeField] bool change; 
    //���f���̍��W������Ă��邽�߂��̕������������邽�߂̕ϐ�
    Vector3 origin;
    Vector3 norigin;
    float Count;
    // Start is called before the first frame update
    void Start()
    {
        //���f���̂���𖳗���蒼��
        origin = transform.position;
        Count = 0;
        noiseField = 0;
        norigin = origin - new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            ChangeForm();
        }
    }
    /// <summary>
    /// �t�H�[���̕ύX
    /// </summary>
    public void ChangeForm()
    {
        StartCoroutine(Transforming());
    }

    IEnumerator Transforming()
    {
        change = false;
        yield return StartCoroutine(StartNoise());
        if (Count == 1)
        {
            Count = 0;
        }
        else
        {
            Count = 1;
        }
        //�Ƃ肠����y������𖳗����C��
        if (Count == 0)
        {
            transform.position = new Vector3(transform.position.x, norigin.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, origin.y, transform.position.z);
        }
        Debug.Log("s");
        _visualEffect.SetFloat(changesourceName, Count);
        yield return StartCoroutine(EndNoise());
    }

    IEnumerator StartNoise()
    {
        while(noiseField <= 300)
        {
            yield return null;
            noiseField++;
            _visualEffect.SetFloat(noiseName, noiseField);
        }
        yield return null;
    }

    IEnumerator EndNoise()
    {
        while(noiseField > 0)
        {
            yield return null;
            noiseField--;
            _visualEffect.SetFloat(noiseName, noiseField);
        }
        yield return null;
    }
    
    
}
