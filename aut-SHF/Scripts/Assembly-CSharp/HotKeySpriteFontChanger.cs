using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(HotKeyRaycaster))]
public class HotKeySpriteFontChanger : MonoBehaviour
{
	[SerializeField]
	private HotKeyRaycaster raycaster;

	[SerializeField]
	private TMP_Text text;

	[SerializeField]
	private bool onlyGamePadDisplay;

	private InputAction action;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void ChangeInputMode(PadInputManager.InputType inputType)
	{
	}

	private void UpdateSpriteFont()
	{
	}

	public void ChangeInput(InputAction action)
	{
	}

	private void OnDestroy()
	{
	}
}
