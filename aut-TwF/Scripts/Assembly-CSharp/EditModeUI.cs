using System;
using System.Collections.Generic;
using UnityEngine;

public class EditModeUI : InGameModeUI
{
	[SerializeField]
	private List<GameObject> hiddenObjectWhileEditing;

	private InGameUI inGameUI;

	private LTHUD ltHud;

	protected override void Start()
	{
		base.Start();
		inGameUI = GetComponentInParent<InGameUI>();
		ltHud = base.Hud as LTHUD;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		EditModeInputMode editModeInputMode = LTFunctionLibrary.GetLTPlayerController().LTHUD.LtPlayerController.CurrentInputMode as EditModeInputMode;
		if ((bool)editModeInputMode)
		{
			editModeInputMode.LockClicks = false;
			EditModeInputMode obj = (base.Hud as LTHUD).LtPlayerController.CurrentInputMode as EditModeInputMode;
			obj.onEditingObjectChanged = (Action<PlacementComponent>)Delegate.Combine(obj.onEditingObjectChanged, new Action<PlacementComponent>(OnEditingObjectChanged));
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		EditModeInputMode editModeInputMode = LTFunctionLibrary.GetLTPlayerController().LTHUD.LtPlayerController.CurrentInputMode as EditModeInputMode;
		if ((bool)editModeInputMode)
		{
			EditModeInputMode obj = (base.Hud as LTHUD).LtPlayerController.CurrentInputMode as EditModeInputMode;
			obj.onEditingObjectChanged = (Action<PlacementComponent>)Delegate.Remove(obj.onEditingObjectChanged, new Action<PlacementComponent>(OnEditingObjectChanged));
			editModeInputMode.OnCancel(null);
			editModeInputMode.LockClicks = true;
		}
	}

	public override bool BackButtonPressed()
	{
		if (base.BackButtonPressed())
		{
			ltHud.ShowStandardModeUI();
			return true;
		}
		return false;
	}

	private void OnEditingObjectChanged(PlacementComponent editingObject)
	{
		hiddenObjectWhileEditing?.ForEach(delegate(GameObject x)
		{
			x.SetActive(!editingObject);
		});
	}
}
