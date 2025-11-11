using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Camera Camera;
    private float cameraPointX;
    private float camerPointY;
    public LayerMask layerMask;
    private GameObject curInteractGameObject;
    public IInteractable curInteractable;
    public TextMeshProUGUI promptText;
    private float checkRate;
    private float LastCheckTime;
    void Start()
    {
        Camera = Camera.main;
    }


    void Update()
    {
        if (Time.time - LastCheckTime > checkRate)
        {
            LastCheckTime = Time.time;
            Ray ray = Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3f, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPrompt();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }

    }

    public void SetPrompt()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteratPrompty();
    }


}
//하나의 기준점을 바탕으로 마우스 이동
//카메라를 기준으로 ray를 쏨
//ray를 쏜 대상이 오브젝트인 경우에는 정보를 가져온다
//아이템데이터에 있는걸 가져와서 현제오브젝트와 대상 오브젝트가 같은지 확인
//Ui호출