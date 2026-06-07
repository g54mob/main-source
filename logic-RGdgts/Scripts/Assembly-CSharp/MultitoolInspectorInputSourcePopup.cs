using TMPro;
using UnityEngine;

public class MultitoolInspectorInputSourcePopup : MonoBehaviour
{
	public TextMeshProUGUI title;

	public Transform linesRoot;

	private LayoutHelper<MultitoolInspectorInputSourcePopupLine> layout;

	private MultitoolInspectorLine line;

	private IInputChip inputChip;

	private InputBinding.Type inputType;

	private bool buttonsAxis;

	private string negativeButton;

	private InputSource inputSource;

	private string buttonsAxisKey;

	private void Awake()
	{
	}

	public void Show(MultitoolInspectorLine line)
	{
	}

	private void ShowInputChipSelection()
	{
	}

	private void ShowInputSourceSelection(IInputChip inputChip, string label, InputBinding.Type[] inputTypes, string[] hideNames = null)
	{
	}

	private void ShowDirectionSelection(string label)
	{
	}

	public void Hide()
	{
	}

	public void OnSelectionInputChip(ModuleId moduleId)
	{
	}

	public void OnSelectionInputSource(InputSource inputSource)
	{
	}

	public void OnSelectionDirection(InputBinding.Direction direction)
	{
	}

	private void Reset()
	{
	}
}
