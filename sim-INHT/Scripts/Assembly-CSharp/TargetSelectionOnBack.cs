using UnityEngine;
using UnityEngine.InputSystem;

public class TargetSelectionOnBack : MonoBehaviour
{
	[SerializeField]
	private InputActionReference backAction;

	[SerializeField]
	private GameObject objectToSelect;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void BackPerformed(InputAction.CallbackContext callbackContext)
	{
	}
}
