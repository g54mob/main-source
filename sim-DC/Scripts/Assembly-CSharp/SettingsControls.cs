using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControls : MonoBehaviour
{
	[SerializeField]
	private Slider sliderLookSensitivity;

	[SerializeField]
	private TextMeshProUGUI textLookSensitivityValue;

	[SerializeField]
	private Toggle toggleInvertY;

	[SerializeField]
	private bool isMainMenu;

	private void Start()
	{
	}

	public void LookSensitivity(float fl)
	{
	}

	public void InvertY()
	{
	}

	private void LoadSettings()
	{
	}
}
