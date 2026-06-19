using TMPro;
using UnityEngine;

public class TextScaleInOnLoad : MonoBehaviour
{
	public float textInTime = 1f;

	public float textLetterOffest = 0.05f;

	public float initialDelay;

	public bool dialogueValues;

	private ulong? currentScaleKey;

	private TextMeshPro textRef;

	private TextMeshProUGUI textRefUGUI;

	private void Awake()
	{
		if (textRef == null)
		{
			textRef = GetComponent<TextMeshPro>();
		}
		if (textRefUGUI == null)
		{
			textRefUGUI = GetComponent<TextMeshProUGUI>();
		}
	}

	public void Start()
	{
		RequestScaleIn();
	}

	private void OnDisable()
	{
		EndCurrentScale();
	}

	public void RequestScaleIn()
	{
		EndCurrentScale();
		if (dialogueValues)
		{
			if (textRef != null)
			{
				currentScaleKey = TextScaleInEffect.ScaleInText(textRef, null, OnScaleInDone, 0.25f, 0.015f, null, scaleOut: false, initialDelay);
			}
			else if (textRefUGUI != null)
			{
				currentScaleKey = TextScaleInEffect.ScaleInText(textRefUGUI, null, OnScaleInDone, 0.25f, 0.015f, null, scaleOut: false, initialDelay);
			}
		}
		else if (textRef != null)
		{
			currentScaleKey = TextScaleInEffect.ScaleInText(textRef, null, scaleTime: textInTime, letterOffest: textLetterOffest, GetEaseValue: Inchworm.GetEaseOutElasticValue, callback: OnScaleInDone, scaleOut: false, initialDelay: initialDelay);
		}
		else if (textRefUGUI != null)
		{
			currentScaleKey = TextScaleInEffect.ScaleInText(textRefUGUI, null, scaleTime: textInTime, letterOffest: textLetterOffest, GetEaseValue: Inchworm.GetEaseOutElasticValue, callback: OnScaleInDone, scaleOut: false, initialDelay: initialDelay);
		}
	}

	public void RequestScaleOut()
	{
		EndCurrentScale();
		Inchworm.GetEaseValue getEaseValue = Inchworm.GetEaseInElasticValue;
		if (textRef != null)
		{
			TextMeshPro characterText = textRef;
			float scaleTime = textInTime;
			float letterOffest = textLetterOffest;
			Inchworm.GetEaseValue getEaseValue2 = getEaseValue;
			currentScaleKey = TextScaleInEffect.ScaleInText(characterText, null, OnScaleInDone, scaleTime, letterOffest, getEaseValue2, scaleOut: true, initialDelay);
		}
		else if (textRefUGUI != null)
		{
			TextMeshProUGUI characterText2 = textRefUGUI;
			float letterOffest = textInTime;
			float scaleTime = textLetterOffest;
			Inchworm.GetEaseValue getEaseValue2 = getEaseValue;
			currentScaleKey = TextScaleInEffect.ScaleInText(characterText2, null, OnScaleInDone, letterOffest, scaleTime, getEaseValue2, scaleOut: true, initialDelay);
		}
	}

	public void EndCurrentScale()
	{
		if (currentScaleKey.HasValue)
		{
			if (textRef != null)
			{
				TextScaleInEffect.RequestEffectEnd(currentScaleKey.Value, textRef);
			}
			else if (textRefUGUI != null)
			{
				TextScaleInEffect.RequestEffectEnd(currentScaleKey.Value, textRefUGUI);
			}
		}
	}

	private void OnScaleInDone(ulong key)
	{
		currentScaleKey = null;
	}
}
