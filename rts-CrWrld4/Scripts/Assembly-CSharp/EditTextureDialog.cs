using System;
using UnityEngine;
using UnityEngine.UI;

public class EditTextureDialog : MonoBehaviour
{
	public InputField nameField;

	public Dropdown filterMode;

	public GameObject errorPane;

	public Text errorMessage;

	[NonSerialized]
	public CPack.CPackTexture texture;

	public void OnEnable()
	{
	}

	public void Show(CPack.CPackTexture texture)
	{
	}

	public void OnNameChanged()
	{
	}

	public void OnFilterModeChanged()
	{
	}

	public void OnExport()
	{
	}
}
