using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

public class ResourceManagementPanel : Panel
{
	[Header("Prefabs")]
	[Tooltip("The prefab for initializing the input field.")]
	public ResourceManagementInputField ResourceFieldPrefab;

	[Header("Settings")]
	[Tooltip("Transform used as the parent for each instantiated input field.")]
	public Transform Content;

	[Tooltip("The text to display when the players open the panel without any producers.")]
	public LocalizedString NoProducerText = null;

	[Tooltip("The text component to display the text if the panel is open without producers build.")]
	public TextMeshProUGUI NoProducerTextComponent;

	[Header("Input")]
	[SerializeField]
	private SelectableGroup _selectableGroup;

	[SerializeField]
	private RewiredAction _increaseAction;

	[SerializeField]
	private RewiredAction _decreaseAction;

	[SerializeField]
	private RewiredAction _infiniteAction;

	private List<ResourceManagementInputField> _instancedLimitFields = new List<ResourceManagementInputField>();

	private bool _updatePanel;

	private void Awake()
	{
		ItemProperties[] itemProperties = GameManager.Settings.ItemSettings.ItemProperties;
		foreach (ItemProperties resource in itemProperties)
		{
			GenerateLimitField(resource);
		}
		NoProducerTextComponent.text = NoProducerText;
		_selectableGroup.Initialize();
	}

	private void OnEnable()
	{
		UpdatePanel();
		_increaseAction.ActivateWait();
		_decreaseAction.ActivateWait();
		_infiniteAction.ActivateWait();
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
	}

	private void LateUpdate()
	{
		if (_updatePanel)
		{
			UpdatePanel();
		}
		if (_increaseAction.GetButtonDown())
		{
			IncreaseSelected();
		}
		if (_decreaseAction.GetButtonDown())
		{
			DecreaseSelected();
		}
		if (_infiniteAction.GetButtonDown())
		{
			SetSelectedInfinite();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (base.Open(id, context))
		{
			RewiredAction.AddToActionInfoBar(_increaseAction, _decreaseAction, _infiniteAction);
			return true;
		}
		return false;
	}

	public override void Close()
	{
		RewiredAction.RemoveFromActionInfoBar(_increaseAction, _decreaseAction, _infiniteAction);
		base.Close();
	}

	private void GenerateLimitField(ItemProperties resource)
	{
		ResourceManagementInputField resourceManagementInputField = UnityEngine.Object.Instantiate(ResourceFieldPrefab, Content);
		resourceManagementInputField.Initialize(resource, GameManager.ResourceManager.ReturnResourceLimit(resource));
		resourceManagementInputField.gameObject.SetActive(value: false);
		_instancedLimitFields.Add(resourceManagementInputField);
	}

	private void UpdatePanel()
	{
		foreach (ItemProperties key in GameManager.ResourceManager.ReturnResourceLimits().Keys)
		{
			EnableLimitField(key);
		}
		_updatePanel = false;
	}

	private void OnBuildableBuilt(GameEvent gameEvent)
	{
		_updatePanel = true;
	}

	private void EnableLimitField(ItemProperties itemProperties)
	{
		if (TryGetLimitField(out var limitField, itemProperties))
		{
			limitField.gameObject.SetActive(value: true);
			if (NoProducerTextComponent.gameObject.activeSelf)
			{
				NoProducerTextComponent.gameObject.SetActive(value: false);
			}
		}
		else
		{
			Debug.LogException(new Exception($"No limit field found for item '{itemProperties}'"));
		}
	}

	private bool TryGetLimitField(out ResourceManagementInputField limitField, ItemProperties itemProperties)
	{
		int count = _instancedLimitFields.Count;
		while (0 < count--)
		{
			limitField = _instancedLimitFields[count];
			if (limitField.ItemProperties == itemProperties)
			{
				return true;
			}
		}
		limitField = null;
		return false;
	}

	public void IncreaseSelected()
	{
		if ((bool)_selectableGroup && _selectableGroup.Selected is ResourceManagementInputField resourceManagementInputField)
		{
			resourceManagementInputField.Increase();
		}
	}

	public void DecreaseSelected()
	{
		if ((bool)_selectableGroup && _selectableGroup.Selected is ResourceManagementInputField resourceManagementInputField)
		{
			resourceManagementInputField.Decrease();
		}
	}

	public void SetSelectedInfinite()
	{
		if ((bool)_selectableGroup && _selectableGroup.Selected is ResourceManagementInputField resourceManagementInputField)
		{
			resourceManagementInputField.SetInfinite();
		}
	}
}
