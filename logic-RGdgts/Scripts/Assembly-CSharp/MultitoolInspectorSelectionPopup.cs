using TMPro;
using UnityEngine;

public class MultitoolInspectorSelectionPopup : MonoBehaviour
{
	public TextMeshProUGUI title;

	public Transform linesRoot;

	private LayoutHelper<MultitoolInspectorSelectionPopupLine> layout;

	private MultitoolInspectorLine line;

	private void Awake()
	{
	}

	public void Show(MultitoolInspectorLine line)
	{
	}

	public void Hide()
	{
	}

	public void OnSelectionModuleId(ModuleId moduleId)
	{
	}

	public void OnSelectionSelection(int value)
	{
	}

	public void OnSelectionAsset(AssetReference assetRef)
	{
	}
}
