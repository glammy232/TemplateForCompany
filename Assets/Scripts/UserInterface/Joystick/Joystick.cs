using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserInterface.GameUIs
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public static Joystick Instance;

        public GameObject Handle;
        public GameObject JoystickBackground;

        public Vector2 MousePos;

        public float CountY
        {
            get
            {
                if (Input.mousePosition.y - 225f < 150f && Input.mousePosition.y - 225f > -150f)
                {
                    return Input.mousePosition.y - 225f;
                }
                else
                {
                    if (Input.mousePosition.y - 225f > 150f)
                        return 150f;
                    else
                        return -150f;
                }
            }
        }
        public float CountX
        {
           get 
           {
                if (Input.mousePosition.x - 225f < 150f && Input.mousePosition.x - 225f > -150f)
                {
                    return Input.mousePosition.x - 225f;
                }
                else
                {
                    if (Input.mousePosition.x - 225f > 150f)
                        return 150f;
                    else
                        return -150f;
                }
           }
        }

        public bool MayIMove
        {
            get
            {
                if (Handle != null && Handle.transform.localPosition != Vector3.zero)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        void Awake()
        {
            Instance = this;
        }
        public void OnPointerDown(PointerEventData ped)
        {
            Handle.transform.localPosition = new Vector2(CountX, CountY);
        }
        public void OnPointerUp(PointerEventData ped)
        {
            ResetToHandleOriginalPos();
        }
        public virtual void OnDrag(PointerEventData ped)
        {
            Handle.transform.localPosition = Vector3.MoveTowards(Handle.transform.localPosition, new Vector2(CountX, CountY), 5f);
        }
        public void ResetToHandleOriginalPos()
        {
            Handle.transform.localPosition = Vector3.zero;
        }
    }
}

