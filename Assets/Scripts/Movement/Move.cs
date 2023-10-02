using UnityEngine;
using UserInterface;
using UserInterface.GameUIs;
using Movement.Basic;

namespace Movement
{
    public class Move : MonoBehaviour, IMovable
    {
        [SerializeField]
        int speedMove = 10;

        public void MoveAsDirection()
        {
            this.GetComponent<Rigidbody2D>().velocity = Direction;
            if (Direction.x < 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0,180,0);
            }
            else
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        public Vector2 Direction
        {
            get
            {
                if (Joystick.Instance.MayIMove == true)
                {
                    return new Vector2(Joystick.Instance.CountX / 150, Joystick.Instance.CountY / 150);
                }
                else
                {
                    return Vector2.zero;
                }
            }
        }
        void Update ()
        {
            MoveAsDirection();
        }
    }
}