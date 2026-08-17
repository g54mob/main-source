using Assets.Scripts.Utility;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public bool useMeTime;

	public float speed;

	public Vector3 axis;

	private unsafe void Update()
	{
		//IL_007c: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		object obj = default(object);
		if (!useMeTime)
		{
			Transform transform = base.transform;
			float deltaTime = Time.deltaTime;
			float angle = speed * deltaTime;
			transform.Rotate((Vector3)(&obj), angle, Space.World);
		}
		else
		{
			Transform transform2 = base.transform;
			float angle2 = speed * MyTime.deltaTime;
			transform2.Rotate((Vector3)(&obj), angle2);
		}
	}

	public RotateObject()
	{
		//IL_0016: Expected O, but got I4
		useMeTime = true;
		axis = (Vector3)0;
		_ = 1065353216;
		base._002Ector();
	}
}
