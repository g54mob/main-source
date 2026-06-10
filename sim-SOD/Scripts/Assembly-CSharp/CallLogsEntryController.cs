using TMPro;
using UnityEngine;

public class CallLogsEntryController : MonoBehaviour
{
	public RectTransform rect;

	public NewBuilding building;

	public TelephoneController.PhoneCall logged;

	public TextMeshProUGUI timeText;

	public TextMeshProUGUI durationText;

	public ButtonController fromButton;

	public ButtonController toButton;

	public void Setup(TelephoneController.PhoneCall newLogged, NewBuilding newBuilding)
	{
	}

	public void FromButton()
	{
	}

	public void ToButton()
	{
	}
}
