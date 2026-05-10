using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StandardModeUI : InGameModeUI
{
	[Serializable]
	private struct FSelectableUI
	{
		[SerializeField]
		public string typeName;

		[SerializeField]
		public SelectableUI uiPrefab;
	}

	[SerializeField]
	private List<FSelectableUI> selectableUIs;

	[SerializeField]
	private AudioClip openSelectableUISound;

	private InGameUI inGameUI;

	private LTHUD ltHud;

	private SelectableUI currentSelectableUI;

	public SelectableUI CurrentSelectableUI
	{
		get
		{
			return currentSelectableUI;
		}
		set
		{
			currentSelectableUI = value;
		}
	}

	protected override void Start()
	{
		base.Start();
		inGameUI = base.gameObject.GetComponentInParent<InGameUI>();
		ltHud = base.Hud as LTHUD;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if ((bool)((base.Hud as LTHUD).LtPlayerController.CurrentInputMode as StandardInputMode))
		{
			((base.Hud as LTHUD).LtPlayerController.CurrentInputMode as StandardInputMode).onSelectedObjectChanged += OnSelectedObjectChanged;
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (ltHud?.LtPlayerController?.CurrentInputMode as StandardInputMode != null)
		{
			(ltHud.LtPlayerController.CurrentInputMode as StandardInputMode).onSelectedObjectChanged -= OnSelectedObjectChanged;
		}
		if ((bool)currentSelectableUI)
		{
			UnityEngine.Object.Destroy(currentSelectableUI.gameObject);
		}
	}

	public override bool BackButtonPressed()
	{
		if ((bool)currentSelectableUI)
		{
			(ltHud.LtPlayerController.CurrentInputMode as StandardInputMode).SelectedObject = null;
		}
		else
		{
			LTFunctionLibrary.GetLTGameManager().PauseGame(pause: true);
		}
		return true;
	}

	private SelectableUI GetSelectableUI(ISelectable selectable)
	{
		foreach (FSelectableUI selectableUI in selectableUIs)
		{
			if (selectable.GetType().Equals(Type.GetType(selectableUI.typeName)) || selectable.GetType().IsSubclassOf(Type.GetType(selectableUI.typeName)))
			{
				return selectableUI.uiPrefab;
			}
		}
		return null;
	}

	private void OnSelectedObjectChanged(ISelectable selectedObject)
	{
		if ((bool)currentSelectableUI)
		{
			UnityEngine.Object.Destroy(currentSelectableUI.gameObject);
			AudioSystem.Instance.PlaySound2D(openSelectableUISound, AudioSystem.EAudioMixerGroup.UI);
		}
		if (!selectedObject.IsUnityNull())
		{
			SelectableUI selectableUI = GetSelectableUI(selectedObject);
			if ((bool)selectableUI)
			{
				currentSelectableUI = UnityEngine.Object.Instantiate(selectableUI.gameObject, base.transform).GetComponent<SelectableUI>();
				currentSelectableUI.SelectedObject = selectedObject;
				AudioSystem.Instance.PlaySound2D(openSelectableUISound, AudioSystem.EAudioMixerGroup.UI);
			}
		}
	}
}
