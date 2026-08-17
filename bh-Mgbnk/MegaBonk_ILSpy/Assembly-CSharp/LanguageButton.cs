using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
	private void Awake()
	{
		Button component = GetComponent<Button>();
		UnityAction call = OpenLanguages;
		component.m_OnClick.AddListener(call);
	}

	public void OpenLanguages()
	{
		AlwaysUi.Instance.OpenLanguageWindow();
	}
}
