using System;
using System.Collections.Generic;
using System.Linq;
using CTS;
using CTS.Core;
using UnityEngine;

public class SurfaceObjectPaintingSystem : MonoSingleton<SurfaceObjectPaintingSystem>
{
	private List<ConstructionCell> _cellToRepaint = new List<ConstructionCell>();

	private List<SurfaceData> _wallMaterialsSOs;

	private List<SurfaceData> _floorMaterialsSOs;

	public List<SurfaceData> WallMaterialsSOs
	{
		get
		{
			if (_wallMaterialsSOs == null)
			{
				_wallMaterialsSOs = new List<SurfaceData>(Resources.LoadAll<SurfaceData>("Scriptables/SurfaceData/WallSurfaces")).OrderBy((SurfaceData x) => x.name).ToList();
			}
			return _wallMaterialsSOs;
		}
	}

	public List<SurfaceData> FloorMaterialsSOs
	{
		get
		{
			if (_floorMaterialsSOs == null)
			{
				_floorMaterialsSOs = new List<SurfaceData>(Resources.LoadAll<SurfaceData>("Scriptables/SurfaceData/Flooring")).OrderBy((SurfaceData x) => x.name).ToList();
			}
			return _floorMaterialsSOs;
		}
	}

	public SurfaceData SelectedMaterialData { get; private set; }

	public int SelectedMaterialdataIndex { get; private set; }

	public ESurfaceType CurrentPaintingSurfaceType { get; private set; }

	public int CurrentCost { get; private set; }

	public static event Action<SurfaceData, SurfaceData> OnPaintingChanged;

	public static event Action<int> OnPaintingUpdated;

	public static event Action OnBuyPaint;

	protected override void SingletonAwake()
	{
		UI_PaintPanel.OnSelectedSurfaceChanged += OnSelectedValueChanged;
		CellMaterials.OnRepaint += CellMaterials_OnRepaint;
	}

	private void CellMaterials_OnRepaint(int oldIndex, int newIndex, bool hasFloor)
	{
		if (hasFloor)
		{
			SurfaceObjectPaintingSystem.OnPaintingChanged?.Invoke(FloorMaterialsSOs[oldIndex], FloorMaterialsSOs[newIndex]);
		}
		else
		{
			SurfaceObjectPaintingSystem.OnPaintingChanged?.Invoke(WallMaterialsSOs[oldIndex], WallMaterialsSOs[newIndex]);
		}
	}

	protected override void OnSingletonDestroy()
	{
		UI_PaintPanel.OnSelectedSurfaceChanged -= OnSelectedValueChanged;
		CellMaterials.OnRepaint -= CellMaterials_OnRepaint;
	}

	private void OnEnable()
	{
		AbsMoneyHandlerBridge.MoneyAmountChanged += OnMoneyChanged;
	}

	private void OnDisable()
	{
		AbsMoneyHandlerBridge.MoneyAmountChanged -= OnMoneyChanged;
	}

	public void AddRepaintToList(ConstructionCell cell)
	{
		if (!_cellToRepaint.Contains(cell))
		{
			_cellToRepaint.Add(cell);
		}
	}

	public void RemoveRepaintToList(ConstructionCell cell)
	{
		if (_cellToRepaint.Contains(cell))
		{
			_cellToRepaint.Remove(cell);
		}
		UpdatePaintingCost();
	}

	private void OnMoneyChanged(int currentMoney)
	{
		if (MonoSingleton<UI_PaintPanel>.TryGetInstance(out var outInstance) && MonoSingleton<AbsMoneyHandlerBridge>.TryGetInstance(out var outInstance2))
		{
			outInstance.SetPaintingCostText(CurrentCost, outInstance2.GetCurrentMoney());
		}
	}

	public void UpdatePaintingCost()
	{
		CurrentCost = 0;
		for (int i = 0; i < _cellToRepaint.Count; i++)
		{
			CurrentCost += _cellToRepaint[i].GetPaintingCost();
		}
		MonoSingleton<UI_PaintPanel>.Instance.SetPaintingCostText(CurrentCost, MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetCurrentMoney());
	}

	public void ConfirmBuyPaint()
	{
		UpdatePaintingCost();
		int obj = -1;
		for (int i = 0; i < _cellToRepaint.Count; i++)
		{
			_cellToRepaint[i].ConfirmBuyPaint();
			obj = _cellToRepaint[i].CurrentSectorID;
		}
		_cellToRepaint.Clear();
		SurfaceObjectPaintingSystem.OnBuyPaint?.Invoke();
		SurfaceObjectPaintingSystem.OnPaintingUpdated?.Invoke(obj);
		CurrentCost = 0;
		RefreshCostVisual();
	}

	public void ClearBuyPaint()
	{
		for (int i = 0; i < _cellToRepaint.Count; i++)
		{
			_cellToRepaint[i].ClearBuyPaint();
		}
		_cellToRepaint.Clear();
		CurrentCost = 0;
	}

	private void OnSelectedValueChanged(SurfaceData surfaceData)
	{
		if (MonoSingleton<UI_PaintPanel>.Instance.CurrentSurfaceType == ESurfaceType.Wall)
		{
			SelectedMaterialdataIndex = WallMaterialsSOs.IndexOf(surfaceData);
			SelectedMaterialData = surfaceData;
			CurrentPaintingSurfaceType = ESurfaceType.Wall;
		}
		else
		{
			SelectedMaterialdataIndex = FloorMaterialsSOs.IndexOf(surfaceData);
			SelectedMaterialData = surfaceData;
			CurrentPaintingSurfaceType = ESurfaceType.Floor;
		}
	}

	public void RefreshCostVisual()
	{
		MonoSingleton<UI_PaintPanel>.Instance.SetPaintingCostText(CurrentCost, MonoSingleton<AbsMoneyHandlerBridge>.Instance.GetCurrentMoney());
	}

	public Material GetWallMaterialFromIndex(int index)
	{
		return WallMaterialsSOs[index].MaterialData;
	}

	public Material GetFloorMaterialFromIndex(int index)
	{
		return FloorMaterialsSOs[index].MaterialData;
	}

	public SurfaceData GetWallSurfaceData(int index)
	{
		return WallMaterialsSOs.ElementAtOrDefault(index);
	}

	public SurfaceData GetFloorSurfaceData(int index)
	{
		return WallMaterialsSOs.ElementAtOrDefault(index);
	}
}
