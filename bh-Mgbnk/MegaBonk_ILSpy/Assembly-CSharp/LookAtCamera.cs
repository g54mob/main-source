using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	public bool invert;

	public bool xzOnly;

	private Transform target;

	private unsafe void Update()
	{
		//IL_0117: Expected O, but got Ref
		//IL_009b: Expected O, but got Ref
		//IL_00b1: Expected O, but got Ref
		bool flag = target == null;
		if (!flag)
		{
			object obj = default(object);
			if (xzOnly == flag)
			{
				if (invert != flag)
				{
				}
				Transform transform = base.transform;
				Vector3 position = target.position;
				Transform transform2 = base.transform;
				Vector3 position2 = transform2.position;
				Quaternion quaternion = Quaternion.LookRotation((Vector3)(&obj));
				object obj2 = default(object);
				transform.rotation = (Quaternion)(&obj2);
			}
			else
			{
				Transform transform3 = base.transform;
				Vector3 position3 = target.position;
				Transform transform4 = base.transform;
				Vector3 position4 = transform4.position;
				Vector3 position5 = target.position;
				transform3.LookAt((Vector3)(&obj));
			}
		}
		else if (PlayerCamera.Instance != null)
		{
			Transform transform5 = PlayerCamera.Instance.transform;
			target = transform5;
		}
	}
}
