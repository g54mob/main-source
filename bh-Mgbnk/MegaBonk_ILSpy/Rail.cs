using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class Rail : MonoBehaviour
{
	private bool isRailingPlayer;

	private float stopRailTime;

	public SplineContainer splineContainer;

	private float restoreCollisionAtTime;

	private bool isIgnoringCollision;

	public Collider renderCollider;

	private Collider playerCollider;

	public bool IsOnCooldown()
	{
		//IL_0036: Invalid comparison between F4 and I4
		bool flag = restoreCollisionAtTime < MyTime.time;
		float num = restoreCollisionAtTime - MyTime.time;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public void Cooldown(Collider playerCollider)
	{
		isIgnoringCollision = true;
		this.playerCollider = playerCollider;
		Physics.IgnoreCollision(renderCollider, playerCollider, ignore: true);
		float num = MyTime.time + 0.5f;
		restoreCollisionAtTime = num;
	}

	private void FixedUpdate()
	{
		if (isIgnoringCollision && MyTime.time > restoreCollisionAtTime)
		{
			Physics.IgnoreCollision(renderCollider, playerCollider, ignore: false);
			isIgnoringCollision = false;
		}
	}

	public unsafe bool IsValidPosition()
	{
		//IL_0008: Expected O, but got Ref
		//IL_003e: Expected O, but got I4
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_0387: Expected I, but got O
		//IL_006d: Expected O, but got Ref
		//IL_00b2: Expected O, but got Ref
		//IL_013b: Expected O, but got Ref
		//IL_0153: Expected O, but got Ref
		//IL_017f: Expected O, but got I4
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0277: Expected O, but got I
		//IL_03c2: Expected I4, but got O
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01db: Expected O, but got Ref
		//IL_029a: Expected O, but got Ref
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_02d9: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		Transform transform = splineContainer.transform;
		Spline spline = splineContainer.Spline;
		object obj3 = 0;
		Spline spline2 = spline;
		Vector3 vector = default(Vector3);
		float num7 = default(float);
		int layerMask = default(int);
		object obj8 = default(object);
		while (true)
		{
			float t = (float)obj3 / 20f;
			float3 float5 = SplineUtility.EvaluatePosition<object>((object)spline2, t);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			object obj4 = obj3 + 1;
			float t2 = (float)obj4 / 20f;
			float3 float6 = SplineUtility.EvaluatePosition<object>((object)spline2, t2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v12 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num3 = 0f * 0.5f;
			Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v11+8]");
			_ = 0;
			float num4 = num3 + transform.TransformPoint(position).z;
			Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rax_v15+8]");
			_ = 0;
			float num5 = num3 + transform.TransformPoint(position2).z;
			float num6 = num5 - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			vector.Normalize();
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
			RaycastHit[] array = Physics.RaycastAll(origin, direction, num7, layerMask);
			object obj5 = 0;
			while ((nint)obj5 < array.Length)
			{
				if ((nint)obj5 < array.Length)
				{
					object obj6 = obj5 * 44;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rcx_v24+20+v200 @ rax_v25 (UnityEngine.RaycastHit[])]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rcx_v24+30+v200 @ rax_v25 (UnityEngine.RaycastHit[])]");
					_ = 0;
					RaycastHit raycastHit = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rcx_v24+3C+v200 @ rax_v25 (UnityEngine.RaycastHit[])]");
					_ = 0;
					Collider collider = ((RaycastHit*)raycastHit)->collider;
					if (collider == renderCollider)
					{
						obj5++;
						continue;
					}
					RaycastHit raycastHit2 = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
					Collider collider2 = ((RaycastHit*)raycastHit2)->collider;
					GameObject gameObject = collider2.gameObject;
					string text = gameObject.name;
					RaycastHit raycastHit3 = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
					Collider collider3 = ((RaycastHit*)raycastHit3)->collider;
					GameObject gameObject2 = collider3.gameObject;
					int layer = gameObject2.layer;
					string text2 = LayerMask.LayerToName(layer);
					string text3 = "Obstacle detected " + text + " on layer " + text2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					return false;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				return (byte)(int)ex != 0;
			}
			obj3++;
			if ((nint)obj3 >= 20)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
			spline2 = (Spline)0;
			float num8 = num7;
			object obj7 = obj8;
		}
		return true;
	}

	private void OnValidate()
	{
		Transform transform = base.transform;
		Transform parent = transform.parent;
		SplineContainer componentInChildren = parent.GetComponentInChildren<SplineContainer>();
		splineContainer = componentInChildren;
	}
}
