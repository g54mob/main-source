using UnityEngine;

public class DefaultTransformCalculator : DisplayProductTransformCalculator
{
	public override Vector3 GetPosition(int index)
	{
		return default(Vector3);
	}

	public override Quaternion GetRotation(int index)
	{
		return default(Quaternion);
	}
}
