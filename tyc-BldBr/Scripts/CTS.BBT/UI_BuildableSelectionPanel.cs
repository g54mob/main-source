using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine;

public class UI_BuildableSelectionPanel : MonoSingleton<UI_BuildableSelectionPanel>
{
	[SerializeField]
	private GameObject _mainContainer;

	[SerializeField]
	private Transform _content;

	[SerializeField]
	private UI_BuyableButton _prefab;

	private readonly List<UI_BuyableButton> _uIBuyableButtons = new List<UI_BuyableButton>();

	protected override void SingletonAwake()
	{
		UI_BuyableButton.BuyableButtonClicked += UI_BuyableButton_BuyableButtonClicked;
		ConstructionSystem.OnConstructionModeChanged += ConstructionChanged;
		ThemeManager.OnStyleChanged += OnStyleChanged;
		UI_PaintPanel.OnSelectedSurfaceChanged += UI_PaintPanel_OnSelectedSurfaceChanged;
	}

	private void UI_PaintPanel_OnSelectedSurfaceChanged(SurfaceData obj)
	{
		if (!(obj == null))
		{
			MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable = null;
			UpdateCatalogue();
		}
	}

	protected override void OnSingletonDestroy()
	{
		ConstructionSystem.OnConstructionModeChanged -= ConstructionChanged;
		UI_BuyableButton.BuyableButtonClicked -= UI_BuyableButton_BuyableButtonClicked;
		ThemeManager.OnStyleChanged -= OnStyleChanged;
		UI_PaintPanel.OnSelectedSurfaceChanged -= UI_PaintPanel_OnSelectedSurfaceChanged;
	}

	private void Start()
	{
		Populate();
		OnStyleChanged(MonoSingleton<ThemeManager>.Instance.CurrentSelectedBarStyle);
	}

	private void OnStyleChanged(EBarStyle style)
	{
		ConstructionChanged();
	}

	public void LockAllElement(bool toLock)
	{
		for (int i = 0; i < _uIBuyableButtons.Count; i++)
		{
			_uIBuyableButtons[i].Interactable = !toLock;
		}
	}

	private void UpdateCatalogue()
	{
		for (int i = 0; i < _uIBuyableButtons.Count; i++)
		{
			if (_uIBuyableButtons[i].AssignedBuyable is BuildableElementSO buildableElementSO)
			{
				_uIBuyableButtons[i].gameObject.SetActive(MonoSingleton<ConstructionSystem>.Instance.CurrentMode != EConstructionMode.Assingation && (buildableElementSO.Style == MonoSingleton<ThemeManager>.Instance.CurrentSelectedBarStyle || buildableElementSO.BuildableType == BuildableElementSO.EBuildableType.Room) && BuildableActiveOnCurrentMode(buildableElementSO));
				_uIBuyableButtons[i].RefreshData(null);
			}
		}
		LockAllElement(MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.Destruction);
	}

	private bool BuildableActiveOnCurrentMode(BuildableElementSO buildable)
	{
		if (MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.Construction)
		{
			return true;
		}
		return false;
	}

	private void ConstructionChanged()
	{
		_mainContainer.gameObject.SetActive(MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.Construction);
		MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable = null;
		UpdateCatalogue();
		for (int i = 0; i < _uIBuyableButtons.Count; i++)
		{
			if (_uIBuyableButtons[i].AssignedBuyable is BuildableElementSO { BuildableType: BuildableElementSO.EBuildableType.Room })
			{
				_uIBuyableButtons[i].OnButtonClicked();
				break;
			}
		}
	}

	private void UI_BuyableButton_BuyableButtonClicked(AbsBuyableItemSO obj)
	{
		if (obj == null)
		{
			MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable = null;
		}
		else if (obj is BuildableElementSO)
		{
			MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable = (BuildableElementSO)obj;
		}
	}

	public void HideContent()
	{
		for (int i = 0; i < _content.childCount; i++)
		{
			_content.GetChild(i).gameObject.SetActive(value: false);
		}
	}

	private void Populate()
	{
		List<BuildableElementSO> list = MonoSingleton<BuildablePlacementSystem>.Instance.Buildables[BuildableElementSO.EBuildableType.Room];
		list.AddRange(MonoSingleton<BuildablePlacementSystem>.Instance.Buildables[BuildableElementSO.EBuildableType.Door]);
		list.AddRange(MonoSingleton<BuildablePlacementSystem>.Instance.Buildables[BuildableElementSO.EBuildableType.Window]);
		list.AddRange(MonoSingleton<BuildablePlacementSystem>.Instance.Buildables[BuildableElementSO.EBuildableType.Arch]);
		foreach (BuildableElementSO item in list)
		{
			if (item.GetValidationState != AbsLockableItemSO.ELockState.Removed)
			{
				UI_BuyableButton uI_BuyableButton = Object.Instantiate(_prefab, _content);
				uI_BuyableButton.AssignBuyable(item);
				_uIBuyableButtons.Add(uI_BuyableButton);
			}
		}
	}
}
