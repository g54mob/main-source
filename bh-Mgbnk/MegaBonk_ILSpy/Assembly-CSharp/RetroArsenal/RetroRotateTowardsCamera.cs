using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

public class RetroRotateTowardsCamera : MonoBehaviour
{
	private Camera mainCamera;

	private void Start()
	{
		Camera main = Camera.main;
		mainCamera = main;
		if (mainCamera == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	private unsafe void Update()
	{
		//IL_00f3: Expected I, but got O
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_01a9: Invalid comparison between F4 and I4
		//IL_01d2: Expected O, but got I4
		//IL_00c4: Expected O, but got Ref
		//IL_00da: Expected O, but got Ref
		if (mainCamera != null)
		{
			Transform transform = mainCamera.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float num = position.x - position2.x;
			float num2 = position.z - position2.z;
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			object obj2 = default(object);
			object obj = 0 - obj2;
			float num5 = num - (float)Vector3.zeroVector;
			float num6 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float num7 = num6 - 0f;
			object obj3 = obj * obj;
			float num8 = num5 * num5;
			float num9 = num7 * num7;
			float num10 = (float)obj3 + num8;
			float num11 = num10 + num9;
			bool flag = 9.9999994E-11f < num11;
			float num12 = 9.9999994E-11f - num11;
			bool flag2 = num12 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj4 = flag4 & flag3;
			if (obj4 == null)
			{
				Transform transform3 = base.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301660");
				object obj5 = default(object);
				Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj5));
				transform3.rotation = (Quaternion)(&obj5);
			}
		}
	}
}
