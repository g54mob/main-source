using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultitoolInspectorSelectionPopupLine : MonoBehaviour
{
	public Button button;

	public TextMeshProUGUI label;

	private MultitoolInspectorSelectionPopup multitoolInspectorPopup;

	private Module module;

	private KeyValuePair<int, string> selectionValue;

	private Asset asset;

	public void SetupModuleId(MultitoolInspectorSelectionPopup multitoolInspectorPopup, Module module)
	{
	}

	private void OnButtonClick_ModuleId()
	{
	}

	public void SetupSelection(MultitoolInspectorSelectionPopup multitoolInspectorPopup, KeyValuePair<int, string> value)
	{
	}

	private void OnButtonClick_Selection()
	{
	}

	public void SetupAsset(MultitoolInspectorSelectionPopup multitoolInspectorPopup, Asset asset)
	{
	}

	private void OnButtonClick_Asset()
	{
	}
}
