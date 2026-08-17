using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Campfire : MonoBehaviour
{
	public ParticleSystem createFx;

	public AudioSource audioSource;

	public RandomSfx randomSfx;

	private float animationTimer;

	private bool isActive;

	private float animateTime = 0.2f;

	private Vector3 fromScale;

	public unsafe void StartFire(Vector3 pos)
	{
		//IL_00ae: Expected O, but got Ref
		//IL_00d4: Expected O, but got Ref
		//IL_015f: Expected I, but got O
		Transform transform = createFx.transform;
		Transform parent = transform.parent;
		if (parent != null)
		{
			Transform transform2 = createFx.transform;
			transform2.parentInternal = null;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		Transform transform3 = base.transform;
		float num = default(float);
		transform3.position = (Vector3)(&num);
		Transform transform4 = createFx.transform;
		transform4.position = (Vector3)(&num);
		GameObject gameObject2 = createFx.gameObject;
		gameObject2.SetActive(value: true);
		createFx.Play();
		audioSource.enabled = true;
		randomSfx.Play();
		isActive = true;
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		fromScale = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
	}

	public void EndFire()
	{
		isActive = false;
	}

	private unsafe void Update()
	{
		//IL_0152: Invalid comparison between I4 and F4
		//IL_00a1: Expected F4, but got I4
		//IL_01a7: Invalid comparison between I4 and F4
		//IL_00e0: Expected O, but got Ref
		//IL_00eb: Invalid comparison between I4 and F4
		float num;
		if (!isActive)
		{
			float deltaTime = Time.deltaTime;
			num = animationTimer - deltaTime;
		}
		else
		{
			float deltaTime2 = Time.deltaTime;
			float num2 = deltaTime2 + animationTimer;
			num = num2;
		}
		if (!(0f > num))
		{
			if (num > animateTime)
			{
				num = animateTime;
			}
		}
		else
		{
			num = 0f;
		}
		animationTimer = num;
		float t = num / animateTime;
		float num3 = Easing.InOutCirc(t);
		Transform transform = base.transform;
		if (0f > num3 || num3 > 1f)
		{
		}
		float num4 = default(float);
		transform.localScale = (Vector3)(&num4);
		if (!(0f < animationTimer))
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			GameObject gameObject2 = createFx.gameObject;
			gameObject2.SetActive(value: false);
		}
	}
}
