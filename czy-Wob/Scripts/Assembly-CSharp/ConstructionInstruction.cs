using TMPro;
using UnityEngine;

public class ConstructionInstruction : MonoBehaviour
{
	public ElementBouncer bouncerRef;

	public TextMeshProUGUI instructionText;

	private float easeTime = 0.15f;

	private string textToUpdate;

	public void Show(ElementBouncer.ElementBouncerCallback callback = null, bool immediate = false)
	{
		if (immediate)
		{
			bouncerRef.transform.localScale = Vector3.one;
			callback?.Invoke();
			return;
		}
		if (bouncerRef.transform.localScale != Vector3.zero)
		{
			bouncerRef.RequestBounce(bouncerRef.transform.localScale, Vector3.zero, easeTime, overwriteExistingBounces: true, Inchworm.EaseStyle.QuadraticIn);
		}
		bouncerRef.RequestBounce(Vector3.zero, Vector3.one, easeTime, overwriteExistingBounces: false, Inchworm.EaseStyle.QuadraticOut, callback);
	}

	public void Hide(ElementBouncer.ElementBouncerCallback callback = null, bool immediate = false)
	{
		if (immediate)
		{
			bouncerRef.transform.localScale = Vector3.zero;
			callback?.Invoke();
		}
		else if (bouncerRef.transform.localScale != Vector3.zero)
		{
			bouncerRef.RequestBounce(bouncerRef.transform.localScale, Vector3.zero, easeTime, overwriteExistingBounces: true, Inchworm.EaseStyle.QuadraticIn, callback);
		}
		else
		{
			callback?.Invoke();
		}
	}

	public void UpdateText(string newText, bool immediate = false)
	{
		if (immediate)
		{
			instructionText.text = newText;
			Show(null, immediate: true);
		}
		else
		{
			textToUpdate = newText;
			Hide(UpdateTextCallback);
		}
	}

	private void UpdateTextCallback()
	{
		instructionText.text = textToUpdate;
		textToUpdate = "";
		Show();
	}
}
