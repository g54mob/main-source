using RuralGasStation;
using UnityEngine;

public class GarageDoorHandler : MonoBehaviour
{
	[SerializeField]
	private KeyCode _interactableKey = KeyCode.E;

	private IDoorCollider _doorColider;

	private void Update()
	{
		if (Input.GetKeyUp(_interactableKey))
		{
			_doorColider?.Handle();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<GarageDoorCollider>(out var component))
		{
			_doorColider = component;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (_doorColider != null && other.gameObject == _doorColider.gameObject)
		{
			_doorColider = null;
		}
	}
}
