using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_Reroll : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image_Icon_Normal;

	[SerializeField]
	private Image image_Icon_Disabled;

	[SerializeField]
	private TMP_Text text_RerollCount;

	private bool canReroll;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRerollCountChanged(int value, int delta)
	{
	}

	private void UpdateText(int value)
	{
	}

	private void OnClickButton()
	{
	}
}
