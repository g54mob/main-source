using System;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

public class UI_PaintPanel : MonoSingleton<UI_PaintPanel>
{
	[SerializeField]
	private GameObject _mainContainer;

	[SerializeField]
	private Transform _content;

	[SerializeField]
	private UI_BuyableButton _prefab;

	[SerializeField]
	private Toggle _paintModeToggle;

	private readonly List<UI_BuyableButton> _uIBuyableButtons = new List<UI_BuyableButton>();

	private SurfaceData _currentSelectedSurface;

	private ESurfacePaintingMode _currentSurfacePaintingMode;

	[SerializeField]
	private UI_ShellPanel _shellPanel;

	[SerializeField]
	private Color _validBuyingColor;

	[SerializeField]
	private Color _invalidBuyingColor;

	public ESurfacePaintingMode CurrentSurfacePaintingMode
	{
		get
		{
			return _currentSurfacePaintingMode;
		}
		set
		{
			_currentSurfacePaintingMode = value;
			UI_PaintPanel.OnPaintingModeChanged?.Invoke(_currentSurfacePaintingMode);
		}
	}

	public SurfaceData CurrentSelectedSurface
	{
		get
		{
			return _currentSelectedSurface;
		}
		set
		{
			_currentSelectedSurface = value;
			_paintModeToggle.interactable = _currentSelectedSurface != null;
			UI_PaintPanel.OnSelectedSurfaceChanged?.Invoke(_currentSelectedSurface);
		}
	}

	public ESurfaceType CurrentSurfaceType
	{
		get
		{
			if (!(_currentSelectedSurface == null))
			{
				return _currentSelectedSurface.SurfaceType;
			}
			return ESurfaceType.None;
		}
	}

	public static event Action<SurfaceData> OnSelectedSurfaceChanged;

	public static event Action<ESurfacePaintingMode> OnPaintingModeChanged;

	public static event Action<int> OnPaintingCostChanged;

	public static event Action OnBuyAction;

	protected override void SingletonAwake()
	{
		_paintModeToggle.onValueChanged.AddListener(OnPaintModeToggleChanged);
		ConstructionSystem.OnConstructionModeChanged += ConstructionChanged;
		UI_BuyableButton.BuyableButtonClicked += UI_BuyableButton_BuyableButtonClicked;
		ThemeManager.OnStyleChanged += OnStyleChanged;
		BuildablePlacementSystem.OnSelectedValueChanged += UI_BuildableSelectionPanel_OnSelectedValueChanged;
	}

	protected override void OnSingletonDestroy()
	{
		_paintModeToggle.onValueChanged.RemoveListener(OnPaintModeToggleChanged);
		ConstructionSystem.OnConstructionModeChanged -= ConstructionChanged;
		UI_BuyableButton.BuyableButtonClicked -= UI_BuyableButton_BuyableButtonClicked;
		ThemeManager.OnStyleChanged -= OnStyleChanged;
		BuildablePlacementSystem.OnSelectedValueChanged -= UI_BuildableSelectionPanel_OnSelectedValueChanged;
	}

	private void Start()
	{
		CurrentSurfacePaintingMode = ESurfacePaintingMode.Room;
		Populate();
		HideContent();
		_paintModeToggle.interactable = false;
	}

	private void OnPaintModeToggleChanged(bool toggle)
	{
		if (toggle)
		{
			CurrentSurfacePaintingMode = ESurfacePaintingMode.OneSurface;
		}
		else
		{
			CurrentSurfacePaintingMode = ESurfacePaintingMode.Room;
		}
	}

	private void UI_BuildableSelectionPanel_OnSelectedValueChanged(BuildableElementSO obj)
	{
		if (!(obj == null))
		{
			CurrentSelectedSurface = null;
			UpdateCatalogue();
		}
	}

	private void OnStyleChanged(EBarStyle style)
	{
		ConstructionChanged();
	}

	private void UI_ConstructionSystem_OnConstructionModeChanged(EConstructionMode mode)
	{
		ConstructionChanged();
	}

	private void ConstructionChanged()
	{
		_mainContainer.gameObject.SetActive(MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.Construction);
		CurrentSelectedSurface = null;
		UpdateCatalogue();
	}

	private void UI_BuyableButton_BuyableButtonClicked(AbsBuyableItemSO obj)
	{
		if (!(obj == null) && obj is SurfaceData)
		{
			CurrentSelectedSurface = (SurfaceData)obj;
		}
	}

	private void UpdateCatalogue()
	{
		for (int i = 0; i < _uIBuyableButtons.Count; i++)
		{
			if (_uIBuyableButtons[i].AssignedBuyable is SurfaceData surfaceData)
			{
				_uIBuyableButtons[i].gameObject.SetActive(MonoSingleton<ConstructionSystem>.Instance.CurrentMode != EConstructionMode.None && MonoSingleton<ConstructionSystem>.Instance.CurrentMode != EConstructionMode.Assingation && surfaceData.Style == MonoSingleton<ThemeManager>.Instance.CurrentSelectedBarStyle);
			}
		}
		LockAllElement(MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.Destruction);
	}

	private void OnBuyClicked()
	{
		UI_PaintPanel.OnBuyAction?.Invoke();
		MonoSingleton<SurfaceObjectPaintingSystem>.Instance.ConfirmBuyPaint();
	}

	public void SetPaintingCostText(int currentCost, int currentMoney)
	{
		UI_PaintPanel.OnPaintingCostChanged?.Invoke(currentCost);
	}

	public void HideContent()
	{
		for (int i = 0; i < _content.childCount; i++)
		{
			_content.GetChild(i).gameObject.SetActive(value: false);
		}
	}

	public void LockAllElement(bool toLock)
	{
		for (int i = 0; i < _uIBuyableButtons.Count; i++)
		{
			_uIBuyableButtons[i].Interactable = !toLock;
		}
	}

	private void Populate()
	{
		List<SurfaceData> list = new List<SurfaceData>(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs);
		list.AddRange(MonoSingleton<SurfaceObjectPaintingSystem>.Instance.FloorMaterialsSOs);
		foreach (SurfaceData item in list)
		{
			if (item.GetValidationState != AbsLockableItemSO.ELockState.Removed)
			{
				UI_BuyableButton uI_BuyableButton = UnityEngine.Object.Instantiate(_prefab, _content);
				uI_BuyableButton.AssignBuyable(item);
				_uIBuyableButtons.Add(uI_BuyableButton);
			}
		}
	}
}
