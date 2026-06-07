using GameCreator.Runtime.Variables;
using TMPro;
using UnityEngine;

public class SyncSign : MonoBehaviour
{
	[Header("Data Source")]
	[SerializeField]
	private GlobalNameVariables savedVariables;

	[Header("UI References")]
	[SerializeField]
	private SpriteRenderer iconRenderer;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private MeshRenderer backgroundRenderer;

	[Header("Settings")]
	[SerializeField]
	private bool syncColor = true;

	private void OnEnable()
	{
		if (!(savedVariables == null))
		{
			savedVariables.Register(OnVariableChanged);
			RefreshAll();
		}
	}

	private void OnDisable()
	{
		if (!(savedVariables == null))
		{
			savedVariables.Unregister(OnVariableChanged);
		}
	}

	private void OnVariableChanged(string variableName)
	{
		switch (variableName)
		{
		case "Company-Icon":
			RefreshIcon();
			break;
		case "Company-Name":
			RefreshName();
			break;
		case "Company-Front-Color":
			RefreshFrontColor();
			break;
		case "Company-Background-Color":
			RefreshBackgroundColor();
			break;
		}
	}

	private void RefreshAll()
	{
		RefreshIcon();
		RefreshName();
		RefreshFrontColor();
		RefreshBackgroundColor();
	}

	private void RefreshIcon()
	{
		if (iconRenderer == null)
		{
			return;
		}
		try
		{
			if (savedVariables.Get("Company-Icon") is Sprite sprite && sprite != null)
			{
				iconRenderer.sprite = sprite;
				iconRenderer.size = sprite.bounds.size;
			}
		}
		catch (MissingReferenceException)
		{
		}
	}

	private void RefreshName()
	{
		if (savedVariables.Get("Company-Name") is string text && nameText != null)
		{
			nameText.text = text;
		}
	}

	private void RefreshFrontColor()
	{
		if (syncColor && savedVariables.Get("Company-Front-Color") is Color color)
		{
			if (nameText != null)
			{
				nameText.color = color;
			}
			if (iconRenderer != null)
			{
				iconRenderer.material.color = color;
			}
		}
	}

	private void RefreshBackgroundColor()
	{
		if (syncColor && savedVariables.Get("Company-Background-Color") is Color color && backgroundRenderer != null)
		{
			backgroundRenderer.material.color = color;
		}
	}
}
