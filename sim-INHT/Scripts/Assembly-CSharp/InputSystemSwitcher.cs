using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class InputSystemSwitcher : MonoBehaviour
{
	[SerializeField]
	private PlayerInput _playerInput;

	[SerializeField]
	private InputSystemUIInputModule _inputSystemUIInputModule;

	private void Start()
	{
	}

	private void OnDeviceChanged(PlayerInput input)
	{
	}

	private void OnDestroy()
	{
	}
}
