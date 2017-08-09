using UnityEngine;

public class ScaleTransformation : Transformation {
    public Vector3 Scale;

    public override Matrix4x4 Matrix {
        get {
            var matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(Scale.x, 0f, 0f, 1f));
            matrix.SetRow(1, new Vector4(0f, Scale.y, 0f, 1f));
            matrix.SetRow(2, new Vector4(0f, 0f, Scale.z, 1f));
            matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
            return matrix;
        }
    }
}
