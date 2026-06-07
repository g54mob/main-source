using Febucci.TextAnimatorForUnity.TextMeshPro;
using UnityEngine;

public class NotificationBounceHandler : MonoBehaviour
{
	[SerializeField]
	private LocalizeAffixStringHandler textHandler;

	[SerializeField]
	private TextAnimator_TMP textAnimator;

	[SerializeField]
	private string effectName = "bounce";

	private void OnEnable()
	{
		textHandler.Prefix = "<" + effectName + ">";
		textAnimator.SetText(textHandler.AffixValue);
	}

	private void OnDisable()
	{
		textHandler.Prefix = string.Empty;
		textAnimator.SetText(textHandler.AffixValue);
	}

	private void ApplyEffect()
	{
		if (!string.IsNullOrEmpty(effectName))
		{
			string text = textAnimator.TMProComponent.text;
			if (!text.Contains("<" + effectName + ">"))
			{
				textAnimator.SetText("<" + effectName + ">" + text + "</" + effectName + ">");
			}
		}
	}

	private void RemoveEffect()
	{
		if (!string.IsNullOrEmpty(effectName))
		{
			string text = textAnimator.TMProComponent.text;
			string oldValue = "<" + effectName + ">";
			string oldValue2 = "</" + effectName + ">";
			string text2 = text.Replace(oldValue, string.Empty).Replace(oldValue2, string.Empty);
			textAnimator.SetText(text2);
		}
	}
}
