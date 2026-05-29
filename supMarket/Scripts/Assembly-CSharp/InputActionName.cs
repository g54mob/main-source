using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionName : NoktaSingleton<InputActionName>
{
	[SerializeField]
	private InputActionAsset m_InputActionAsset;

	private bool isGamepadConnected;

	private PlayerInput playerInput;

	private void Awake()
	{
	}

	public string GetActionInput(string actionName)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGamePadConnected(bool isConnected)
	{
	}
}
