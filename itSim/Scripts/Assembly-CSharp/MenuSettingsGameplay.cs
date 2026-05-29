using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingsGameplay : MonoBehaviour
{
	[Header("Language")]
	public LanguageBase languageBase;

	public List<string> Language;

	public TMP_Text viewLanguage;

	private int nowindexLanguage;

	private string selectedLanguage;

	[Header("Field Of View")]
	public TMP_Text viewMouseFieldOfView;

	public Scrollbar viewScrollbarFieldOfView;

	private bool load;

	public TextMeshProUGUI languageInBlueScreen;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetNextLanguageButton(int value)
	{
	}

	private void SetLanguageAction(int value, bool increment = true)
	{
	}

	public void SetTextInStartBlueScreen()
	{
	}

	public void SetNextFieldOfView(float value)
	{
	}

	public void SetNextFieldOfViewAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarMouseSensitivity(float value)
	{
	}

	public void SetDeflaut()
	{
	}

	public void LoadSettings()
	{
	}

	public static int AddValue(int now, int value, bool increment)
	{
		return 0;
	}

	public static float AddValue(float now, float value, bool increment)
	{
		return 0f;
	}
}
