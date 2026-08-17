using Cpp2ILInjected;
using MilkShake;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class DungeonPressurePlate : MonoBehaviour
{
	private bool opened;

	public GameObject blocker;

	public AudioSource sfxPlate;

	public AudioSource sfxBlocker;

	public ShakePreset shakePreset;

	private Vector3 startPos;

	private Vector3 endPos;

	private float progressTimer;

	private float progressDuration = 0.55f;

	private void OnTriggerEnter(Collider other)
	{
		//IL_00ba: Expected O, but got F4
		//IL_010a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C1C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!opened)
		{
			GameObject gameObject = other.gameObject;
			int layer = gameObject.layer;
			int num = LayerMask.NameToLayer("Player");
			if (layer == num)
			{
				opened = true;
				Transform transform = base.transform;
				Vector3 position = transform.position;
				startPos = (Vector3)position.x;
				_ = position.z;
				nint num2 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
				float num4 = 0f * 0.25f;
				float num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DungeonPressurePlate)+50]");
				float num6 = num5 + 0f;
				Vector3 vector = default(Vector3);
				endPos = vector;
				sfxPlate.Play();
			}
		}
	}

	private void Move()
	{
		//IL_0036: Expected O, but got F4
		//IL_005f: Expected I, but got O
		opened = true;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		startPos = (Vector3)position.x;
		_ = position.z;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
		float num3 = 0f * 0.25f;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DungeonPressurePlate)+50]");
		float num5 = num4 + 0f;
		Vector3 vector = default(Vector3);
		endPos = vector;
		sfxPlate.Play();
	}

	private unsafe void FinishMove()
	{
		//IL_0037: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		sfxBlocker.Play();
		PlayerCamera instance = PlayerCamera.Instance;
		ShakeInstance shakeInstance = instance.shaker.Shake(shakePreset, (int?)(object)0);
		GameObject gameObject = blocker.gameObject;
		Transform transform = gameObject.transform;
		Vector3 position = transform.position;
		Transform transform2 = blocker.transform;
		Vector3 up = transform2.up;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
	}

	private unsafe void Update()
	{
		//IL_009d: Invalid comparison between I4 and F4
		//IL_00e8: Expected F4, but got I4
		//IL_022d: Invalid comparison between I4 and F4
		//IL_0124: Expected F4, but got I4
		//IL_0136: Expected O, but got Ref
		//IL_018c: Expected O, but got I4
		//IL_01fb: Expected O, but got Ref
		if (!opened || !(progressTimer < 1f))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = deltaTime / progressDuration;
		float num2 = num + progressTimer;
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
		progressTimer = num2;
		Transform transform = base.transform;
		float num3 = Easing.InOutQuad(progressTimer);
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = default(float);
		transform.position = (Vector3)(&num4);
		if (!(progressTimer < 1f))
		{
			sfxBlocker.Play();
			PlayerCamera instance = PlayerCamera.Instance;
			ShakeInstance shakeInstance = instance.shaker.Shake(shakePreset, (int?)(object)0);
			GameObject gameObject = blocker.gameObject;
			Transform transform2 = gameObject.transform;
			Vector3 position = transform2.position;
			Transform transform3 = blocker.transform;
			Vector3 up = transform3.up;
			transform2.position = (Vector3)(&num4);
		}
	}
}
