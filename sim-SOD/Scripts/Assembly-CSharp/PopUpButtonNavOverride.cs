using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpButtonNavOverride : MonoBehaviour
{
	public TMP_InputField desiredUpTarget;

	public ButtonController desiredLeftTarget;

	public ButtonController desiredRightTarget;

	private Navigation _nav;

	private Navigation _previousNav;

	private ButtonController _buttonController;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
