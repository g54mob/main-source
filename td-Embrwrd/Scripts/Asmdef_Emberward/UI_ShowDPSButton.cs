using UnityEngine;
using UnityEngine.UI;

public class UI_ShowDPSButton : MonoBehaviour
{
	[SerializeField]
	private Button button_ShowDPS;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Color color_On;

	[SerializeField]
	private Color color_Off;

	private bool isDpsMeterOn;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnClickButton_ShowDPS()
	{
	}

	private void ShowDpsMeter(bool isOn, bool playSound)
	{
	}
}
