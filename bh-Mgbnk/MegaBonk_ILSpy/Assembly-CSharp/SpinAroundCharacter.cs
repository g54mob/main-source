using Cpp2ILInjected;
using UnityEngine;

public class SpinAroundCharacter : MonoBehaviour
{
	public Transform camera;

	public Transform target;

	public float distanceFromTarget = 10f;

	public float cameraHeight = 5f;

	public Vector3 targetOffset;

	public float rotationSpeed = 0.5f;

	private float currentAngle;

	private unsafe void Update()
	{
		//IL_0054: Expected O, but got Ref
		//IL_00b5: Invalid comparison between I4 and F4
		//IL_0100: Expected F4, but got I4
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01fd: Invalid comparison between I4 and F4
		//IL_013c: Expected F4, but got I4
		//IL_025f: Expected O, but got Ref
		//IL_014e: Expected O, but got Ref
		//IL_0162: Expected O, but got Ref
		//IL_018b: Expected O, but got Ref
		if (!(target != null))
		{
			return;
		}
		Transform transform = base.transform;
		Vector3 position = target.position;
		float num = default(float);
		transform.position = (Vector3)(&num);
		float time = Time.time;
		float num2 = time * rotationSpeed;
		float num3 = num2 / 240f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num4 = num3 * 240f;
		float num5 = num2 - num4;
		if (!(0f > num5))
		{
			if (num5 > 240f)
			{
				num5 = 240f;
			}
		}
		else
		{
			num5 = 0f;
		}
		float num6 = num5 - 120f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num6 & 0;
		float num7 = 120f - (float)obj;
		float num8 = num7 - 60f;
		float deltaTime = Time.deltaTime;
		float num9 = deltaTime * 0.5f;
		if (!(0f > num9))
		{
			if (num9 > 1f)
			{
				num9 = 1f;
			}
		}
		else
		{
			num9 = 0f;
		}
		float num10 = num8 - currentAngle;
		float num11 = num10 * num9;
		float num12 = num11 + currentAngle;
		currentAngle = num12;
		Transform transform2 = base.transform;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		object obj2 = default(object);
		transform2.rotation = (Quaternion)(&obj2);
		camera.localPosition = (Vector3)(&num);
		Vector3 position2 = target.position;
		camera.LookAt((Vector3)(&num));
	}
}
