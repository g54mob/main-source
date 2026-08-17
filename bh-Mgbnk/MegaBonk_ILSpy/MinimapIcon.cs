using Assets.Scripts.Actors.Player;
using UnityEngine;

public class MinimapIcon : MonoBehaviour
{
	public bool isStatic;

	public bool alignToCamera;

	private unsafe void Start()
	{
		//IL_0055: Expected O, but got Ref
		//IL_0012: Expected O, but got Ref
		Transform transform = base.transform;
		object obj = default(object);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj));
		transform.rotation = (Quaternion)(&obj);
		if (isStatic)
		{
			Object.Destroy(this);
		}
	}

	private unsafe void Update()
	{
		//IL_00c3: Expected O, but got Ref
		//IL_00d9: Expected O, but got Ref
		//IL_0073: Expected O, but got Ref
		//IL_0089: Expected O, but got Ref
		object obj = default(object);
		if (alignToCamera && MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			Transform transform = instance.minimapCamera.transform;
			Vector3 eulerAngles = transform.eulerAngles;
			Transform transform2 = base.transform;
			Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj));
			transform2.rotation = (Quaternion)(&obj);
		}
		if (!isStatic)
		{
			Transform transform3 = base.transform;
			Quaternion quaternion2 = Quaternion.Internal_FromEulerRad((Vector3)(&obj));
			transform3.rotation = (Quaternion)(&obj);
		}
	}
}
