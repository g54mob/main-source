using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyGridOverview : Panel
{
	[SerializeField]
	private EnergyGridOverviewSlot _gridSlot;

	[SerializeField]
	private Transform _contentTransform;

	[SerializeField]
	private Button _previousButton;

	[SerializeField]
	private Button _nextButton;

	[SerializeField]
	private TMP_Text _gridName;

	[SerializeField]
	private LocalizedString _gridLocalizedName = "";

	private readonly List<EnergyGridOverviewSlot> _slots = new List<EnergyGridOverviewSlot>();

	private readonly List<EnergyGrid> _validGrids = new List<EnergyGrid>();

	private int _currentGridIndex;

	private void UpdateElements(GameEvent gameEvent = null)
	{
		AcquireValidGrids();
		int num = _validGrids.Count - 1;
		if (_currentGridIndex >= num)
		{
			_currentGridIndex = num;
		}
		_previousButton.interactable = _currentGridIndex > 0;
		_nextButton.interactable = _currentGridIndex < num;
		SetCurrentGrid();
	}

	private void OnEnable()
	{
		UpdateElements();
		Overlays.OverlayType = Overlays.Type.Energy;
		GameEventDispatcher.AddListener(GameEventType.EnergyGridsUpdated, UpdateElements);
		GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
	}

	private void OnDisable()
	{
		if (Overlays.OverlayType == Overlays.Type.Energy)
		{
			Overlays.OverlayType = Overlays.Type.None;
		}
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridsUpdated, UpdateElements);
		GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
	}

	private void AcquireValidGrids()
	{
		_validGrids.Clear();
		_validGrids.AddRangeWhere(EnergyGridManager.Grids, (EnergyGrid grid) => grid.Components != null && grid.Components.FindCount((IEnergyGridComponent component) => !(component is EnergyGridPole)) > 1);
	}

	private void AddGridSlot(EnergyGrid grid, int index)
	{
		EnergyGridOverviewSlot energyGridOverviewSlot = Object.Instantiate(_gridSlot, _contentTransform);
		energyGridOverviewSlot.Initialize(grid, index);
		_slots.Add(energyGridOverviewSlot);
	}

	private void OnOverlayUpdate(GameEvent gameEvent)
	{
		base.gameObject.SetActive(gameEvent is OverlayEvent overlayEvent && overlayEvent.OverlayType == Overlays.Type.Energy);
	}

	public void PreviousGrid()
	{
		if (_currentGridIndex != 0)
		{
			_currentGridIndex--;
			_nextButton.interactable = true;
			_previousButton.interactable = _currentGridIndex > 0;
			SetCurrentGrid();
		}
	}

	public void NextGrid()
	{
		int num = _currentGridIndex + 1;
		if (_validGrids.Count > num)
		{
			_currentGridIndex = num;
			_previousButton.interactable = true;
			_nextButton.interactable = _currentGridIndex < _validGrids.Count - 1;
			SetCurrentGrid();
		}
	}

	public void SetCurrentGrid()
	{
		_gridName.text = ReplaceGridNumber();
		foreach (EnergyGridOverviewSlot slot in _slots)
		{
			slot.gameObject.SetActive(value: false);
		}
		if (_currentGridIndex >= 0)
		{
			EnergyGrid grid = _validGrids[_currentGridIndex];
			if (_currentGridIndex >= _slots.Count)
			{
				AddGridSlot(grid, _currentGridIndex + 1);
			}
			else
			{
				_slots[_currentGridIndex].Initialize(grid, _currentGridIndex + 1);
			}
		}
	}

	private string ReplaceGridNumber()
	{
		string input = _gridLocalizedName;
		string replacement = (_currentGridIndex + 1).ToString().PadLeft(2, '0');
		return Regex.Replace(input, "%GRIDNUMBER%", replacement, RegexOptions.IgnoreCase);
	}
}
