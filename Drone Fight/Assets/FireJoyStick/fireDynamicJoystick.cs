using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fireDynamicJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public Image fireBackGround;
    public Image fireHandle;
    public GameObject clickPosition;
    public Vector2 koordinat2;
    public Vector3 koordinat3;
    public float mag;
    public float minWidth, minHeight, maxWidth, maxHeight;



    // Start is called before the first frame update
    void Start()
    {
        fireHandle.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData joystick)
    {
        infoFire = true;
        fireHandle.enabled = true;
        koordinat2 = Vector2.zero;
        maxWidth = fireBackGround.rectTransform.position.x + (fireBackGround.rectTransform.sizeDelta.x / 2) - (fireHandle.rectTransform.sizeDelta.x /2);
        maxHeight = fireBackGround.rectTransform.position.y + (fireBackGround.rectTransform.sizeDelta.y / 2) - (fireHandle.rectTransform.sizeDelta.y);
        minWidth = fireBackGround.rectTransform.position.x - (fireBackGround.rectTransform.sizeDelta.x / 2) + fireHandle.rectTransform.sizeDelta.x;
        minHeight = fireBackGround.rectTransform.position.y - (fireBackGround.rectTransform.sizeDelta.y / 2) + (fireHandle.rectTransform.sizeDelta.y/3);


        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(fireBackGround.rectTransform, joystick.position, joystick.pressEventCamera, out koordinat2))
        {
            koordinat2 = joystick.position;
            if(koordinat2.x > maxWidth)
            {
                koordinat2.x = maxWidth;
            }
            if (koordinat2.x < minWidth)
            {
                koordinat2.x = minWidth;
            }
            if (koordinat2.y > maxHeight)
            {
                koordinat2.y = maxHeight;
            }
            if (koordinat2.y < minHeight)
            {
                koordinat2.y = minHeight;
            }
            clickPosition.transform.position = koordinat2;
        }
        
        
    }
    public void OnPointerDown(PointerEventData joystick)
    {
        OnDrag(joystick);
        infoDown = true;
    }
    public void OnPointerUp(PointerEventData joystick)
    {
        fireHandle.enabled = false;
        infoFire = false;
        infoDown = false;
        koordinat2 = Vector3.zero;
    }
    public bool infoFire = false, infoDown = false;

}
