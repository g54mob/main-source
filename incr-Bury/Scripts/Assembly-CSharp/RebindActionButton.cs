using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RebindActionButton : MonoBehaviour
{
	public enum ActionMapType
	{
		player = 0
	}

	public ActionMapType actionMapType;

	[SerializeField]
	private string actionName;

	[SerializeField]
	private int additionalIndex = -1;

	public Button ourButton;

	[SerializeField]
	private bool isControllerRebindButton;

	[SerializeField]
	private TMP_Text inputDisplay_Keyboard;

	[SerializeField]
	private TMP_Text inputDisplay_Controller;

	[SerializeField]
	private bool isMovementAxis;

	private void Start()
	{
		ourButton = GetComponent<Button>();
	}

	private void Update()
	{
	}

	public void UpdateActionBindingButtonText()
	{
		InputActionMap inputActionMap = null;
		InputAction inputAction = null;
		if (actionMapType == ActionMapType.player)
		{
			inputActionMap = InputManager.Singleton.inputActions.PlayerActionMap;
			inputAction = inputActionMap.FindAction(actionName);
		}
		if (inputActionMap == null || inputAction == null)
		{
			Debug.Log("Couldn't find this action binding to display");
			return;
		}
		if (!ourButton)
		{
			ourButton = GetComponent<Button>();
		}
		if (isMovementAxis)
		{
			inputDisplay_Keyboard.text = inputAction.GetBindingDisplayString(additionalIndex + 1);
			inputDisplay_Controller.text = inputAction.GetBindingDisplayString(additionalIndex + 6);
		}
		else
		{
			inputDisplay_Keyboard.text = inputAction.GetBindingDisplayString(0);
			inputDisplay_Controller.text = inputAction.GetBindingDisplayString(1);
		}
	}

	public int GetAdditionalIndex()
	{
		return additionalIndex;
	}

	public bool GetIsControllerRebindButton()
	{
		return isControllerRebindButton;
	}

	public bool GetIsMovementAxis()
	{
		return isMovementAxis;
	}
}
