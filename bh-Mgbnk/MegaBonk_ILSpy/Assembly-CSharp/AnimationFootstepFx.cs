using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

public class AnimationFootstepFx : MonoBehaviour
{
	public Transform leftFoot;

	public Transform rightFoot;

	public unsafe void RightFoot()
	{
		//IL_0019: Expected O, but got Ref
		Vector3 position = rightFoot.position;
		object obj = default(object);
		Spawn((Vector3)(&obj));
	}

	public unsafe void LeftFoot()
	{
		//IL_0019: Expected O, but got Ref
		Vector3 position = leftFoot.position;
		object obj = default(object);
		Spawn((Vector3)(&obj));
	}

	private unsafe void Spawn(Vector3 position)
	{
		//IL_0050: Expected O, but got Ref
		//IL_0087: Expected O, but got Ref
		//IL_009d: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
		Object obj = default(Object);
		if (obj != null)
		{
			Transform transform = ((GameObject)obj).transform;
			float num = default(float);
			transform.position = (Vector3)(&num);
			Transform transform2 = ((GameObject)obj).transform;
			Transform transform3 = base.transform;
			Vector3 forward = transform3.forward;
			Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
			object obj2 = default(object);
			transform2.rotation = (Quaternion)(&obj2);
		}
	}
}
