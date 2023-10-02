using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement.Basic
{
    public interface IMovable
    {
        void MoveAsDirection();
    }
    public interface ICountDirection
    {
        void CountDirection();
    }
}
