using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class UiTextPopup : MonoBehaviour
{
	public TextMeshProUGUI t_text;

	public GameObject parent;

	public CanvasGroup canvasGroup;

	private float startFadeTime = 1f;

	private float fadeTime = 0.5f;

	private float upSpeed = 100f;

	private float scaleSpeed = 30f;

	private Vector3 desiredScale;

	public RandomSfx sfx;

	public RectTransform overlayCanvas;

	private bool fading;

	private float fadeTimer;

	public Vector2 TransformCameraToOverlaySpace(Vector3 position)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public void SetTextCameraSpace(string text, Vector3 position, Color color, float desiredScale = 1f)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		object obj = default(object);
		Color color2 = (Color)(obj - 24);
		Vector3 position2 = (Vector3)(obj - 40);
		float num = default(float);
		SetText(text, position2, color2, num);
	}

	public unsafe void SetText(string text, Vector3 position, Color color, float desiredScale = 1f)
	{
		//IL_008f: Expected O, but got Ref
		//IL_00a4: Expected O, but got Ref
		//IL_011f: Expected I, but got O
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_00f4: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172128]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parent.SetActive(value: true);
		sfx.Play();
		upSpeed = 70f;
		Transform transform = parent.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
		t_text.color = (Color)(&num);
		t_text.text = text;
		fadeTimer = 0f;
		fading = false;
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v13 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		object obj2 = default(object);
		object obj = obj2 * 0;
		Vector3 vector = default(Vector3);
		this.desiredScale = vector;
		Transform transform2 = parent.transform;
		transform2.localScale = (Vector3)(&num);
		CancelInvoke();
		Invoke("StartFade", startFadeTime);
	}

	private void StartFade()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172129]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		fading = true;
		fadeTimer = 0f;
		Invoke("HideObject", fadeTime);
	}

	private unsafe void Update()
	{
		//IL_0240: Invalid comparison between I4 and F4
		//IL_028b: Expected F4, but got I4
		//IL_0192: Invalid comparison between I4 and F4
		//IL_01dd: Expected F4, but got I4
		//IL_009d: Invalid comparison between I4 and F4
		//IL_03d1: Invalid comparison between I4 and F4
		//IL_00e8: Expected F4, but got I4
		//IL_043d: Expected O, but got Ref
		//IL_0219: Expected F4, but got I4
		//IL_038e: Invalid comparison between I4 and F4
		//IL_0124: Expected F4, but got I4
		//IL_0313: Invalid comparison between I4 and F4
		//IL_035e: Expected F4, but got I4
		//IL_0370: Expected O, but got Ref
		if (1f > fadeTimer)
		{
			CanvasGroup canvasGroup;
			float num4;
			if (fading)
			{
				float deltaTime = Time.deltaTime;
				float num = deltaTime / fadeTime;
				float num2 = num + fadeTimer;
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
				canvasGroup = this.canvasGroup;
				fadeTimer = num2;
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
				float num3 = num2 * -1f;
				num4 = num3 + 1f;
			}
			else
			{
				float deltaTime2 = Time.deltaTime;
				float num5 = fadeTime * 0.5f;
				float num6 = deltaTime2 / num5;
				num4 = num6 + fadeTimer;
				if (!(0f > num4))
				{
					if (num4 > 1f)
					{
						num4 = 1f;
					}
				}
				else
				{
					num4 = 0f;
				}
				canvasGroup = this.canvasGroup;
				fadeTimer = num4;
				if (!(0f > num4))
				{
					if (num4 > 1f)
					{
						num4 = 1f;
					}
				}
				else
				{
					num4 = 0f;
				}
			}
			canvasGroup.alpha = num4;
		}
		float deltaTime3 = Time.deltaTime;
		float num7 = deltaTime3 * 2.5f;
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
		float num8 = 0f - upSpeed;
		float num9 = num8 * num7;
		float num10 = num9 + upSpeed;
		upSpeed = num10;
		Transform transform = parent.transform;
		Vector3 position = transform.position;
		float deltaTime4 = Time.deltaTime;
		Vector3 vector = default(Vector3);
		transform.position = (Vector3)(&vector);
		Transform transform2 = parent.transform;
		Transform transform3 = parent.transform;
		Vector3 localScale = transform3.localScale;
		float deltaTime5 = Time.deltaTime;
		float num11 = deltaTime5 * scaleSpeed;
		if (!(0f > num11))
		{
			if (num11 > 1f)
			{
				num11 = 1f;
			}
		}
		else
		{
			num11 = 0f;
		}
		float num12 = default(float);
		transform2.localScale = (Vector3)(&num12);
	}

	private void HideObject()
	{
		parent.SetActive(value: false);
	}
}
