using Cpp2ILInjected;
using UnityEngine;

public class AnimateUi : MonoBehaviour
{
	private float fps = 7f;

	private float nextUpdateTime;

	public float rotationAmount = 4f;

	public float rotationSpeed = 3f;

	public float scaleAmount = 0.05f;

	public float scaleSpeed = 6f;

	public bool animateScale = true;

	private float defaultZRot;

	private void Awake()
	{
		Transform transform = base.transform;
		defaultZRot = transform.localEulerAngles.z;
	}

	private unsafe void Update()
	{
		//IL_00e8: Expected O, but got Ref
		//IL_00fc: Expected I, but got O
		//IL_0096: Expected O, but got Ref
		float time = Time.time;
		if (!(nextUpdateTime > time))
		{
			float time2 = Time.time;
			bool flag = !animateScale;
			float num = 1f / fps;
			float num2 = num + time2;
			nextUpdateTime = num2;
			float num8 = default(float);
			if (!flag)
			{
				Transform transform = base.transform;
				nint num3 = (nint)typeof(Vector3);
				float time3 = Time.time;
				float num4 = time3 * scaleSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
				float num5 = num4 * scaleAmount;
				float num6 = num5 + 1f;
				object obj = default(object);
				float num7 = num6 * (float)obj;
				num2 = num6 * (float)Vector3.oneVector;
				transform.localScale = (Vector3)(&num8);
				num8 = num2;
			}
			Transform transform2 = base.transform;
			float time4 = Time.time;
			float num9 = time4 * rotationSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
			transform2.localEulerAngles = (Vector3)(&num8);
		}
	}
}
