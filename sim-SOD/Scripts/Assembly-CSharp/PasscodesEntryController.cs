using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasscodesEntryController : MonoBehaviour
{
	public NewAddress address;

	public NewRoom room;

	public Human human;

	public Interactable interactable;

	public Evidence evidence;

	public GameplayController.Passcode passcode;

	public TextMeshProUGUI text;

	public ButtonController locateOnMapButton;

	public ButtonController enterCodeButton;

	public RawImage evidenceImage;

	public Image icon;

	public string nameString;

	public string passcodeString;

	public void Setup(GameplayController.Passcode newPasscode)
	{
	}

	public void VisualUpdate()
	{
	}

	public void ActiveCodeInputCheck(KeypadController keypad)
	{
	}

	private void OnDestroy()
	{
	}

	public void OpenEvidence()
	{
	}

	public void LocateOnMap()
	{
	}

	public void EnterCode()
	{
	}
}
