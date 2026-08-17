using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class ScoreUiPrefab : MonoBehaviour
{
	public TextMeshProUGUI t_score;

	public TextMeshProUGUI t_desc;

	private float desiredScale;

	private float startFadeTime = 1.5f;

	private float fadeTime = 1f;

	public float bounceSpeed = 3.5f;

	public float scaleSpeed = 16f;

	private float scaleMultiplier = 1f;

	private bool moveDesc;

	private bool isActive;

	private unsafe void Update()
	{
		//IL_019e: Invalid comparison between I4 and F4
		//IL_00d7: Expected F4, but got I4
		//IL_00e9: Expected O, but got Ref
		//IL_01de: Invalid comparison between I4 and F4
		if (desiredScale > 1f)
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime * bounceSpeed;
			float num2 = desiredScale - num;
			desiredScale = num2;
		}
		Transform transform = t_score.transform;
		Transform transform2 = t_score.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime2 = Time.deltaTime;
		float num3 = deltaTime2 * scaleSpeed;
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
		transform.localScale = (Vector3)(&num4);
		if (moveDesc)
		{
			RectTransform rectTransform = t_desc.rectTransform;
			RectTransform rectTransform2 = t_desc.rectTransform;
			Vector2 anchoredPosition = rectTransform2.anchoredPosition;
			float deltaTime3 = Time.deltaTime;
			float num5 = deltaTime3 * scaleSpeed;
			if (0f > num5 || num5 > 1f)
			{
			}
			Vector2 anchoredPosition2 = default(Vector2);
			rectTransform.anchoredPosition = anchoredPosition2;
		}
	}

	public unsafe void SetScore(string description, string header, float sizeMultiplier)
	{
		//IL_0062: Expected O, but got Ref
		//IL_00ca: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F69]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = base.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
		bool flag = header == null;
		string text = "";
		if (!flag)
		{
			text = header;
		}
		t_score.text = text;
		Transform transform2 = t_score.transform;
		transform2.localScale = (Vector3)(&num);
		t_desc.text = description;
		RectTransform rectTransform = t_desc.rectTransform;
		RectTransform rectTransform2 = t_desc.rectTransform;
		Vector2 sizeDelta = rectTransform2.sizeDelta;
		Vector2 anchoredPosition = default(Vector2);
		rectTransform.anchoredPosition = anchoredPosition;
		moveDesc = false;
		desiredScale = 2f;
		t_score.CrossFadeAlpha(1f, 0f, ignoreTimeScale: true);
		CancelInvoke();
		Invoke("ShowDesc", 0.25f);
		Invoke("StartFade", startFadeTime);
	}

	private void StartFade()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F6A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		t_score.CrossFadeAlpha(0f, fadeTime, ignoreTimeScale: true);
		t_desc.CrossFadeAlpha(0f, fadeTime, ignoreTimeScale: true);
		Invoke("DisableObject", fadeTime);
	}

	private void ShowDesc()
	{
		moveDesc = true;
		t_desc.CrossFadeAlpha(1f, 0f, ignoreTimeScale: true);
	}

	private void DisableObject()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		isActive = false;
	}
}
