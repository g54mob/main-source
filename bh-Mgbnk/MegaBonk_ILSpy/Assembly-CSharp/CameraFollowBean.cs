using Cpp2ILInjected;
using UnityEngine;

public class CameraFollowBean : MonoBehaviour
{
	public Transform target;

	public Rigidbody[] rbs;

	public float speed = 2f;

	public float rotationSpeed = 2f;

	public Camera camera;

	private bool falling;

	private float upOffset = 2f;

	private float rightOffset = 14f;

	public Animator animator;

	public float force = 200f;

	public float rotationForce = 200f;

	public GameObject animation;

	public GameObject ragdoll;

	private void Update()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_04f4: Expected I, but got O
		//IL_055c: Expected I, but got O
		//IL_007c: Invalid comparison between I4 and F4
		//IL_00c7: Expected F4, but got I4
		//IL_044f: Invalid comparison between I4 and F4
		//IL_0103: Expected F4, but got I4
		//IL_0218: Invalid comparison between I4 and F4
		//IL_0263: Expected F4, but got I4
		//IL_013e: Invalid comparison between I4 and F4
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_0189: Expected F4, but got I4
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		if (falling)
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime * 0.35f;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			float num2 = 10f - upOffset;
			float num3 = num2 * num;
			float num4 = num3 + upOffset;
			upOffset = num4;
			float deltaTime2 = Time.deltaTime;
			float num5 = deltaTime2 * 0.2f;
			if (!(0f > num5))
			{
				if (num5 > 1f)
				{
					num5 = 1f;
				}
			}
			else
			{
				num5 = 0f;
			}
			float num6 = 0f - rightOffset;
			float num7 = num6 * num5;
			float num8 = num7 + rightOffset;
			rightOffset = num8;
			float fieldOfView = camera.fieldOfView;
			float deltaTime3 = Time.deltaTime;
			float num9 = deltaTime3 * 0.5f;
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
			float num10 = 90f - fieldOfView;
			float num11 = num10 * num9;
			float fieldOfView2 = num11 + fieldOfView;
			camera.fieldOfView = fieldOfView2;
		}
		nint num12 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num13 = 0;
		_ = Vector3.rightVector;
		float num14 = rightOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-55]");
		float num15 = num14 * 0f;
		float num16 = rightOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
		float num17 = num16 * 0f;
		float num18 = rightOffset * (float)Vector3.rightVector;
		nint num19 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num20 = 0;
		_ = Vector3.upVector;
		float num21 = (float)Vector3.upVector * upOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-55]");
		float num22 = 0f * upOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num23 = 0f * upOffset;
		float num24 = num21 + num18;
		float num25 = num22 + num15;
		float num26 = num23 + num17;
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Vector3 position2 = target.position;
		float num27 = num24 + position2.x;
		float num28 = num25 + position2.y;
		float num29 = num26 + position2.z;
		float time = Time.time;
		float num30 = time * speed;
		if (!(0f > num30))
		{
			if (num30 > 1f)
			{
				num30 = 1f;
			}
		}
		else
		{
			num30 = 0f;
		}
		float num31 = num27 - position.x;
		float num32 = num28 - position.y;
		float num33 = num29 - position.z;
		float num34 = num31 * num30;
		float num35 = num32 * num30;
		float num36 = num33 * num30;
		float num37 = num34 + position.x;
		float num38 = num35 + position.y;
		float num39 = num36 + position.z;
		Vector3 position3 = (Vector3)(obj - 89);
		transform.position = position3;
		Transform transform3 = base.transform;
		Transform transform4 = base.transform;
		Quaternion rotation = transform4.rotation;
		Vector3 position4 = target.position;
		Transform transform5 = base.transform;
		Vector3 position5 = transform5.position;
		float num40 = position4.x - position5.x;
		float num41 = position4.y - position5.y;
		float num42 = position4.z - position5.z;
		Vector3 forward = (Vector3)(obj - 89);
		Quaternion quaternion = Quaternion.LookRotation(forward);
		float deltaTime4 = Time.deltaTime;
		float t = deltaTime4 * rotationSpeed;
		Quaternion b = (Quaternion)(obj - 73);
		Quaternion a = (Quaternion)(obj - 89);
		_ = quaternion.x;
		_ = rotation.x;
		Quaternion quaternion2 = Quaternion.Lerp(a, b, t);
		Quaternion rotation2 = (Quaternion)(obj - 73);
		_ = quaternion2.x;
		transform3.rotation = rotation2;
	}
}
