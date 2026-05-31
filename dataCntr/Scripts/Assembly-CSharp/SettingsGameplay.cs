using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGameplay : MonoBehaviour
{
	[SerializeField]
	private TMP_Dropdown dropDownLanguages;

	[SerializeField]
	private Toggle toggleAutoSave;

	[SerializeField]
	private TMP_Dropdown dropDownAutoSaveInterval;

	[SerializeField]
	private bool isMainMenu;

	public void Start()
	{
	}

	public void OnLanguageDropDownChange(int i)
	{
	}

	public void SetAutoSaveInterval(int i)
	{
	}

	public void SetAutoSaveOnOff(bool isActive)
	{
	}
}
