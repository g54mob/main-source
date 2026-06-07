using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultitoolInspectorInputSourcePopupLine : MonoBehaviour
{
	public Button button;

	public TextMeshProUGUI label;

	private MultitoolInspectorInputSourcePopup multitoolInspectorPopup;

	private IInputChip inputChip;

	private string inputBindingName;

	private InputBinding.Direction direction;

	public void SetupInputChip(MultitoolInspectorInputSourcePopup multitoolInspectorPopup, IInputChip inputChip)
	{
	}

	public void SetupInputSource(MultitoolInspectorInputSourcePopup multitoolInspectorPopup, IInputChip inputChip, string inputBindingName)
	{
	}

	public void SetupDirection(MultitoolInspectorInputSourcePopup multitoolInspectorPopup, InputBinding.Direction direction)
	{
	}

	private void OnButtonClick_InputChip()
	{
	}

	private void OnButtonClick_InputSource()
	{
	}

	private void OnButtonClick_Direction()
	{
	}
}
