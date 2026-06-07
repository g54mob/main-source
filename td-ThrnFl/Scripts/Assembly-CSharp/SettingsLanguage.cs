using I2.Loc;
using UnityEngine;

public class SettingsLanguage : MonoBehaviour
{
	public EnumSelector selector;

	private void Start()
	{
		selector.onChange.AddListener(OnChange);
	}

	private void OnEnable()
	{
		selector.options.Clear();
		selector.options.AddRange(LocalizationManager.GetAllLanguages());
		string currentLanguage = LocalizationManager.CurrentLanguage;
		for (int i = 0; i < selector.options.Count; i++)
		{
			if (selector.options[i] == currentLanguage)
			{
				selector.SetIndex(i);
				break;
			}
		}
	}

	private void OnChange()
	{
		LocalizationManager.CurrentLanguage = selector.options[selector.Index];
	}
}
