using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class FadeWorldUi : MonoBehaviour
{
	public MaskableGraphic damageText;

	public MaskableGraphic otherText;

	private Vector3 randomDir;

	public CanvasGroup cGroup;

	private Vector3 defaultScale;

	private float fadeTime = 0.6f;

	public float startFadeoutTime = 0.5f;

	private bool started;

	private IEnumerator shakeRoutine;

	private float moveMultiplier = 1f;

	private float speed = 8f;

	private Vector3 moveDir;

	private float desiredScale = 4f;

	private void StartFadeOut()
	{
		damageText.CrossFadeAlpha(0f, fadeTime, ignoreTimeScale: true);
		otherText.CrossFadeAlpha(0f, fadeTime, ignoreTimeScale: true);
	}

	public unsafe void Start()
	{
		//IL_01dc: Expected I, but got O
		//IL_0219: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_0280: Invalid comparison between F4 and O
		//IL_00bd: Expected O, but got Ref
		//IL_00a1: Expected O, but got F4
		//IL_011b: Expected O, but got F4
		//IL_02a5: Expected I, but got O
		damageText.CrossFadeAlpha(1f, 0f, ignoreTimeScale: true);
		otherText.CrossFadeAlpha(1f, 0f, ignoreTimeScale: true);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		speed = 8f;
		desiredScale = 4f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj = defaultScale - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FadeWorldUi)+4C]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj2 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FadeWorldUi)+50]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num4 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj3 * obj3;
		object obj6 = obj * obj;
		object obj7 = obj4 + obj6;
		object obj8 = obj7 + obj5;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			Transform transform = base.transform;
			Vector3 localScale = transform.localScale;
			defaultScale = (Vector3)localScale.x;
			_ = localScale.z;
		}
		Transform transform2 = base.transform;
		float num5 = default(float);
		transform2.localScale = (Vector3)(&num5);
		Transform transform3 = PlayerCamera.Instance.transform;
		Vector3 position = transform3.position;
		Transform transform4 = base.transform;
		Vector3 position2 = transform4.position;
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		randomDir = (Vector3)insideUnitSphere.x;
		_ = insideUnitSphere.z;
		nint num6 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num7 = 0;
		Transform transform5 = base.transform;
		float num8 = transform5.forward.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FadeWorldUi)+38]");
		float num9 = num8 + 0f;
		float num10 = num9 * moveMultiplier;
		float num11 = num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num12 = num11 + 0f;
		Vector3 vector = default(Vector3);
		moveDir = vector;
		Invoke("StartFadeOut", startFadeoutTime);
		float time = startFadeoutTime + fadeTime;
		Invoke("DestroySelf", time);
		started = true;
	}

	private unsafe void Update()
	{
		//IL_0079: Expected O, but got Ref
		//IL_00a0: Invalid comparison between I4 and F4
		//IL_00eb: Expected F4, but got I4
		//IL_0125: Invalid comparison between I4 and F4
		//IL_0170: Expected F4, but got I4
		//IL_0182: Expected O, but got Ref
		//IL_01a9: Invalid comparison between I4 and F4
		//IL_01f4: Expected F4, but got I4
		if (!started)
		{
			return;
		}
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float deltaTime = Time.deltaTime;
		float num = default(float);
		transform.position = (Vector3)(&num);
		float deltaTime2 = Time.deltaTime;
		float num2 = deltaTime2 * 6f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = 0.02f - speed;
		float num4 = num3 * num2;
		float num5 = num4 + speed;
		speed = num5;
		Transform transform2 = base.transform;
		Transform transform3 = base.transform;
		Vector3 localScale = transform3.localScale;
		float deltaTime3 = Time.deltaTime;
		float num6 = deltaTime3 * 10f;
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		transform2.localScale = (Vector3)(&num);
		float deltaTime4 = Time.deltaTime;
		float num7 = deltaTime4 * 3f;
		if (!(0f > num7))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		float num8 = 3f - desiredScale;
		float num9 = num8 * num7;
		float num10 = num9 + desiredScale;
		desiredScale = num10;
	}

	private void DestroySelf()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}
}
