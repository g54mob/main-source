using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using UnityEngine;

public class LookTowardsPlayer : MonoBehaviour
{
	public bool onlyXZ;

	public bool lerp;

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_023a: Expected O, but got Ref
		//IL_012f: Expected O, but got Ref
		//IL_02c0: Expected O, but got Ref
		//IL_02ce: Expected O, but got Ref
		//IL_02f6: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((bool)MyPlayer.Instance)
		{
			if (!onlyXZ)
			{
				Transform transform = base.transform;
				Transform target = MyPlayer.Instance.transform;
				transform.LookAt(target);
				return;
			}
			if (!lerp)
			{
				Transform transform2 = base.transform;
				Transform transform3 = MyPlayer.Instance.transform;
				Vector3 position = transform3.position;
				Transform transform4 = base.transform;
				Vector3 position2 = transform4.position;
				Transform transform5 = MyPlayer.Instance.transform;
				Vector3 position3 = transform5.position;
				Vector3 worldPosition = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				_ = position3.z;
				_ = position.x;
				_ = position2.y;
				transform2.LookAt(worldPosition);
				return;
			}
			Transform transform6 = MyPlayer.Instance.transform;
			Vector3 position4 = transform6.position;
			Transform transform7 = base.transform;
			Vector3 position5 = transform7.position;
			Transform transform8 = MyPlayer.Instance.transform;
			Vector3 position6 = transform8.position;
			Transform transform9 = base.transform;
			Vector3 position7 = transform9.position;
			float num = position4.x - position7.x;
			float num2 = position5.y - position7.y;
			float num3 = position6.z - position7.z;
			Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			Quaternion quaternion = Quaternion.LookRotation(forward);
			Transform transform10 = base.transform;
			Transform transform11 = base.transform;
			Quaternion rotation = transform11.rotation;
			_ = quaternion.x;
			_ = rotation.x;
			float deltaTime = Time.deltaTime;
			float t = deltaTime + deltaTime;
			Quaternion b = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			Quaternion a = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			Quaternion quaternion2 = Quaternion.Lerp(a, b, t);
			Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			_ = quaternion2.x;
			transform10.rotation = rotation2;
		}
	}
}
