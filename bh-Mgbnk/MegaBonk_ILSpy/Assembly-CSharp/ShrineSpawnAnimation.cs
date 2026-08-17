using Assets.Scripts.Utility;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ShrineSpawnAnimation : MonoBehaviour
{
	public float offset;

	private float moveOverTime = 3f;

	public ShakePreset shakePreset;

	private Vector3 fromPos;

	private Vector3 toPos;

	private bool started;

	private float timer;

	public unsafe void Activate()
	{
		//IL_00c0: Expected O, but got Ref
		//IL_0050: Expected O, but got F4
		//IL_00dd: Expected I, but got O
		//IL_0094: Expected O, but got I4
		started = true;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		fromPos = (Vector3)position2.x;
		_ = position2.z;
		Transform transform3 = base.transform;
		Vector3 position3 = transform3.position;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = offset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num4 = num3 * 0f;
		float num5 = num4 + position3.z;
		Vector3 vector = default(Vector3);
		toPos = vector;
		PlayerCamera instance = PlayerCamera.Instance;
		ShakeInstance shakeInstance = instance.shaker.Shake(shakePreset, (int?)(object)0);
	}

	private unsafe void FixedUpdate()
	{
		//IL_0124: Invalid comparison between I4 and F4
		//IL_0075: Expected F4, but got I4
		//IL_0087: Expected O, but got Ref
		if (!started || !(timer < moveOverTime))
		{
			return;
		}
		if ((timer += MyTime.fixedDeltaTime) > moveOverTime)
		{
			timer = moveOverTime;
		}
		float t = timer / moveOverTime;
		Transform transform = base.transform;
		float num = Easing.OutCirc(t);
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
		float num2 = default(float);
		transform.position = (Vector3)(&num2);
	}
}
