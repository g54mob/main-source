using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultitoolInspectorLine : MonoBehaviour
{
	public TextMeshProUGUI nameLabel;

	public GameObject persistentButton;

	public TMP_InputField inputField;

	public Toggle toggle;

	public GameObject button;

	public TextMeshProUGUI buttonLabel;

	public Image buttonImage;

	private MultitoolInspectorService inspector;

	[NonSerialized]
	[HideInInspector]
	public MultitoolInspectorProperty property;

	private Color32 colorValue;

	private ModuleId moduleIdValue;

	private Data.Selection selectionValue;

	private AssetReference assetValue;

	private InputSource inputSourceValue;

	public void Setup(MultitoolInspectorService inspector, MultitoolInspectorProperty property)
	{
	}

	public void Refresh()
	{
	}

	public void OnResetPersistent()
	{
	}

	public void OnEndEdit()
	{
	}

	public void OnValueChange()
	{
	}

	private void _OnValueChange(bool force)
	{
	}

	public void OnButtonClick()
	{
	}

	public void OnPopupColor(Color32 color)
	{
	}

	public void OnPopupModuleId(ModuleId moduleId)
	{
	}

	public void OnPopupSelection(int value)
	{
	}

	public void OnPopupAsset(AssetReference assetRef)
	{
	}

	public void OnPopupInputSource(InputSource inputSource)
	{
	}
}
