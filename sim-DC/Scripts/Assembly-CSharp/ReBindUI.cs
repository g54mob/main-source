using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ReBindUI : MonoBehaviour
{
	[SerializeField]
	private InputActionReference inputActionReference;

	[SerializeField]
	private bool excludeMouse;

	[Range(0f, 20f)]
	[SerializeField]
	private int selectedBinding;

	[SerializeField]
	private InputBinding.DisplayStringOptions displayStringOptions;

	[Header("Binding Info - DO NOT EDIT")]
	[SerializeField]
	private InputBinding inputBinding;

	private int bindingIndex;

	private string actionName;

	[Header("UI Fields")]
	[SerializeField]
	private TextMeshProUGUI actionText;

	private ButtonExtended rebindButton;

	private TextMeshProUGUI rebindText;

	[SerializeField]
	private ButtonExtended resetButton;

	[SerializeField]
	private bool translateKeyTextToImage;

	private Image imageGamePadKey;

	private GamepadIcons iconsXbox;

	private GamepadIcons iconsPS4;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnValidate()
	{
	}

	private void GetBindingInfo()
	{
	}

	private void UpdateUI()
	{
	}

	private void DoRebind()
	{
	}

	private void ResetBinding()
	{
	}
}
