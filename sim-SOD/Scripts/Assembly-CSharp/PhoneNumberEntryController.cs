using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneNumberEntryController : MonoBehaviour
{
	public RectTransform rect;

	public Telephone telephone;

	public GameplayController.PhoneNumber number;

	public TextMeshProUGUI text;

	public ButtonController openLocationButton;

	public ButtonController openEvidenceButton;

	public ButtonController enterCodeButton;

	public Image icon;

	public string nameString;

	public string passcodeString;

	private List<Human> citizenSubscriptions;

	public void Setup(GameplayController.PhoneNumber newNumber)
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

	public void OpenLocation()
	{
	}

	public void OpenEvidence()
	{
	}

	public void EnterCode()
	{
	}
}
