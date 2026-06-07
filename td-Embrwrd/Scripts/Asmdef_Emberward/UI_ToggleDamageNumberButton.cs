using UnityEngine;
using UnityEngine.UI;

public class UI_ToggleDamageNumberButton : MonoBehaviour
{
	[SerializeField]
	private Button button_ToggleDamageNumber;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Sprite sprite_Full;

	[SerializeField]
	private Sprite sprite_Dynamic;

	[SerializeField]
	private Sprite sprite_Off;

	private eDamageNumberType curDamageNumberType;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnClickButton_ToggleDamageNumber()
	{
	}

	private void UpdateDamageNumber(eDamageNumberType type, bool playSound)
	{
	}
}
