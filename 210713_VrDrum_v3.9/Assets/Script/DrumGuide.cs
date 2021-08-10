using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrumGuide : MonoBehaviour
{

    private Renderer drumRender;          // 드럼 렌더러
    private Color originColor;            // 원래 드럼의 색
    private int flashCount = 2;        // 점멸 횟수
    private float fTime = 0.5f;             // 점멸 주기

    void Start()
    {
        drumRender = GetComponent<MeshRenderer>();
        originColor = drumRender.material.color;
    }
    void Update()
    {
        /*if (Input.anyKeyDown)
            foreach (var dic in keyDictionary)
                if (Input.GetKeyDown(dic.Key))
                    StartCoroutine(Flashing(dic.Value - 1));*/

    }
    public void FlashAct()
    {
        StartCoroutine(Flashing());
    }
    public IEnumerator Flashing()   // 점멸 횟수만큼 색이 바뀐 후 원래의 색으로 돌아옴
    {
        int count = 1;

        while (count < flashCount)      
        {
            drumRender.material.color = Color.red;
            yield return new WaitForSeconds(fTime);
            drumRender.material.color = originColor;
            yield return new WaitForSeconds(fTime);
            drumRender.material.color = Color.red;
            count++;
        }
        yield return new WaitForSeconds(fTime);
        drumRender.material.color = originColor;
    }



}
