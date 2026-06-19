using System;
using Rewired;
using UnityEngine;

public class ControlMapping_SingleActionMapping : RadicalMenuOption
{
	[SerializeField]
	private PugText _mappingText;

	[SerializeField]
	private bool _useControllerButtonIconChars;

	[SerializeField]
	private GameObject _selectedIndicator;

	[SerializeField]
	private ControllerType _controllerType;

	[SerializeField]
	private Transform _rootInList;

	public ActionElementMap ActionElementMap { get; private set; }

	public ControllerType ControllerType => _controllerType;

	public override float localScrollPosition => _rootInList.localPosition.y;

	public event Action<ControlMapping_SingleActionMapping> ActionMappingActivated;

	public event Action<ControlMapping_SingleActionMapping> ActionMappingSelected;

	public void Setup(ActionElementMap actionElementMap, string localizationOverride = null)
	{
		if (_mappingText == null)
		{
			Debug.LogWarning("ControlMapping_SingleActionMapping.Setup: missing PugText for action mapping name or controller icon. Aborting.");
			return;
		}
		ActionElementMap = actionElementMap;
		_mappingText.localize = localizationOverride != null;
		if (actionElementMap.elementIdentifierName == null)
		{
			_mappingText.Render("NULL");
		}
		else if (_useControllerButtonIconChars)
		{
			string controllerButtonCharacter = Manager.ui.controllerButtonToCharTable.GetControllerButtonCharacter(actionElementMap.controllerMap.controllerType, actionElementMap.controllerMap.controller.name, actionElementMap.elementIdentifierName);
			_mappingText.Render(controllerButtonCharacter, rewindEffectAnims: false, force: true);
		}
		else
		{
			_mappingText.Render(localizationOverride ?? actionElementMap.elementIdentifierName);
		}
	}

	public override void OnSelected()
	{
		base.OnSelected();
		_selectedIndicator.SetActive(value: true);
		this.ActionMappingSelected?.Invoke(this);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		_selectedIndicator.SetActive(value: false);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		this.ActionMappingActivated?.Invoke(this);
	}

	protected override void OnDisable()
	{
		Cleanup();
		base.OnDisable();
	}

	public void Cleanup()
	{
		this.ActionMappingActivated = null;
		this.ActionMappingSelected = null;
		ActionElementMap = null;
		_mappingText.Render("", rewindEffectAnims: false, force: true);
		_selectedIndicator.SetActive(value: false);
		topUIElements.Clear();
		bottomUIElements.Clear();
	}
}
