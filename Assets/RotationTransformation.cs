using UnityEngine;

public class RotationTransformation : Transformation {
    public Vector3 Rotation;

    public override Vector3 Apply(Vector3 point) {
        var radZ = Rotation.z * Mathf.Deg2Rad;
        var sinZ = Mathf.Sin(radZ);
        var cosZ = Mathf.Cos(radZ);

        return new Vector3(
            point.x * cosZ - point.y * sinZ,
            point.x * sinZ + point.y * cosZ,
            point.z
            );
    }
}
