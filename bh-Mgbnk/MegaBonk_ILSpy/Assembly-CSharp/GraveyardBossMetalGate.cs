using Cpp2ILInjected;
using MilkShake;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GraveyardBossMetalGate : MonoBehaviour
{
	public Transform uiArrowTarget;

	public AudioSource sfxOpen;

	public ShakePreset shakePreset;

	private bool isOpen;

	private float timer;

	private float moveOverTime = 2f;

	private Vector3 startPos;

	private Vector3 endPos;

	public unsafe void Open()
	{
		//IL_0048: Expected O, but got Ref
		//IL_0073: Expected O, but got F4
		//IL_00ed: Expected I, but got O
		//IL_00b4: Expected O, but got I4
		if (!isOpen)
		{
			isOpen = true;
			UiManager instance = UiManager.Instance;
			object obj = default(object);
			float timeout = default(float);
			float scaleMultiplier = default(float);
			instance.objectiveArrow.SetTarget(uiArrowTarget, (Vector3)(&obj), 6f, timeout, scaleMultiplier);
			Transform transform = base.transform;
			Vector3 position = transform.position;
			startPos = (Vector3)position.x;
			_ = position.z;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v13 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num3 = 0f * 12f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (GraveyardBossMetalGate)+4C]");
			float num5 = num4 + 0f;
			Vector3 vector = default(Vector3);
			endPos = vector;
			sfxOpen.Play();
			PlayerCamera instance2 = PlayerCamera.Instance;
			ShakeInstance shakeInstance = instance2.shaker.Shake(shakePreset, (int?)(object)0);
		}
	}

	private unsafe void Update()
	{
		//IL_0080: Invalid comparison between I4 and F4
		//IL_00cb: Expected F4, but got I4
		//IL_0130: Invalid comparison between I4 and F4
		//IL_010a: Expected O, but got Ref
		if (!isOpen || !(timer < moveOverTime))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = (timer = deltaTime + timer) / moveOverTime;
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
		float num2 = Easing.InOutQuad(num);
		Transform transform = base.transform;
		if (0f > num2 || num2 > 1f)
		{
		}
		float num3 = default(float);
		transform.position = (Vector3)(&num3);
	}
}
