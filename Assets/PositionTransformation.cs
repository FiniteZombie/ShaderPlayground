using System;
using UnityEngine;

public class PositionTransformation : Transformation {
    public Vector3 Position;

    public override Matrix4x4 Matrix {
        get {
            var matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(1f, 0f, 0f, Position.x));
            matrix.SetRow(1, new Vector4(0f, 1f, 0f, Position.y));
            matrix.SetRow(2, new Vector4(0f, 0f, 1f, Position.z));
            matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
            return matrix;
        }
    }
}
