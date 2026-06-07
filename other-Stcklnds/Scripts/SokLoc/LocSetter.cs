using TMPro;
using UnityEngine;

public class LocSetter : MonoBehaviour
{
	[Term]
	public string Term;

	public string Prefix = "";

	public string Postfix = "";

	private void Awake()
	{
		SokLoc.instance.LanguageChanged += SetText;
		SetText();
	}

	private void OnDestroy()
	{
		if (SokLoc.instance != null)
		{
			SokLoc.instance.LanguageChanged -= SetText;
		}
	}

	private void SetText()
	{
		string text = SokLoc.Translate(Term);
		if (!string.IsNullOrEmpty(Prefix))
		{
			text = Prefix + text;
		}
		if (!string.IsNullOrEmpty(Postfix))
		{
			text += Postfix;
		}
		TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
		if ((Object)(object)component != null)
		{
			component.text = text;
		}
		TextMeshPro component2 = GetComponent<TextMeshPro>();
		if ((Object)(object)component2 != null)
		{
			component2.text = text;
		}
	}
}
