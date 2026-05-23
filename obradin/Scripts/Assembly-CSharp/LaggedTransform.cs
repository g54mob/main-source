using UnityEngine;

public class LaggedTransform
{
	public Vector3 pos = Vector3.zero;

	public Quaternion rot = Quaternion.identity;

	private bool hasBeenSet;

	public Matrix4x4 matrix
	{
		get
		{
			return Matrix4x4.TRS(pos, rot, Vector3.one);
		}
		set
		{
			rot = Util.QuaternionFromMatrix(value);
			pos = value.GetT();
			hasBeenSet = true;
		}
	}

	public void Approach(Matrix4x4 target, float t)
	{
		if (!hasBeenSet)
		{
			matrix = target;
			return;
		}
		rot = Quaternion.Lerp(rot, Util.QuaternionFromMatrix(target), t);
		pos = Vector3.Lerp(pos, target.GetT(), t);
	}
}
