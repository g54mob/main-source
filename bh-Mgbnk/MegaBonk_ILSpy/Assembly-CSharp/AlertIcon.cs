using Cpp2ILInjected;
using UnityEngine;

public class AlertIcon : MonoBehaviour
{
	private float fps = 7f;

	private float nextUpdateTime;

	private float rotationAmount = 4f;

	private float rotationSpeed = 3f;

	private float scaleAmount = 0.05f;

	private float scaleSpeed = 6f;

	private float defaultZRot;

	private void Awake()
	{
		Transform transform = base.transform;
		defaultZRot = transform.localEulerAngles.z;
	}

	private unsafe void Update()
	{
		//IL_00d5: Expected I, but got O
		//IL_007c: Expected O, but got Ref
		//IL_00c1: Expected O, but got Ref
		float time = Time.time;
		if (!(nextUpdateTime > time))
		{
			float time2 = Time.time;
			float num = 1f / fps;
			float num2 = num + time2;
			nextUpdateTime = num2;
			Transform transform = base.transform;
			nint num3 = (nint)typeof(Vector3);
			float time3 = Time.time;
			float num4 = time3 * scaleSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
			float num5 = num4 * scaleAmount;
			float num6 = num5 + 1f;
			object obj = default(object);
			float num7 = num6 * (float)obj;
			float num8 = num6 * (float)Vector3.oneVector;
			float num9 = default(float);
			transform.localScale = (Vector3)(&num9);
			Transform transform2 = base.transform;
			float time4 = Time.time;
			float num10 = time4 * rotationSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
			transform2.localEulerAngles = (Vector3)(&num9);
		}
	}
}
