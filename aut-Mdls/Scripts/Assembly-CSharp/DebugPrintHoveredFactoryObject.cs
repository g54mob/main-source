using Data.FactoryFloor;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugPrintHoveredFactoryObject : MonoBehaviour
{
	[SerializeField]
	private MouseToGridInput _mouseToGridInput;

	[SerializeField]
	private FactoryLayer _factoryLayer;

	[SerializeField]
	private InputActionReference _inputActionReference;

	[SerializeField]
	private InputActionAsset _inputActionAsset;

	private InputActionMap _debugInputActionMap;
}
