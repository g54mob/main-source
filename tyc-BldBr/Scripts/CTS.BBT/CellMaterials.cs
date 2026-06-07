using System;
using CTS;
using CTS.Core;

public struct CellMaterials
{
	public ConstructionCell LinkedCell;

	private int _nordWallMaterialIndex;

	private int _eastWallMaterialIndex;

	private int _southWallMaterialIndex;

	private int _westWallMaterialIndex;

	private int _floorMaterialIndex;

	private int? _paintingNordWallMaterialIndex;

	private int? _paintingEastWallMaterialIndex;

	private int? _paintingSouthWallMaterialIndex;

	private int? _paintingWestWallMaterialIndex;

	private int? _paintingFloorMaterialIndex;

	public static event Action<int, int, bool> OnRepaint;

	public static event Action<SurfaceData, SurfaceData> Painted;

	public int[] ToSaveArray()
	{
		if (_nordWallMaterialIndex != 0 || _eastWallMaterialIndex != 0 || _southWallMaterialIndex != 0 || _westWallMaterialIndex != 0 || _floorMaterialIndex != 0)
		{
			return new int[5] { _nordWallMaterialIndex, _eastWallMaterialIndex, _southWallMaterialIndex, _westWallMaterialIndex, _floorMaterialIndex };
		}
		return null;
	}

	public void FromSaveArray(int[] array)
	{
		if (array != null && array.Length == 5)
		{
			_nordWallMaterialIndex = array[0];
			CellMaterials.Painted?.Invoke(null, MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallSurfaceData(_nordWallMaterialIndex));
			_eastWallMaterialIndex = array[1];
			CellMaterials.Painted?.Invoke(null, MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallSurfaceData(_eastWallMaterialIndex));
			_southWallMaterialIndex = array[2];
			CellMaterials.Painted?.Invoke(null, MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallSurfaceData(_southWallMaterialIndex));
			_westWallMaterialIndex = array[3];
			CellMaterials.Painted?.Invoke(null, MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetWallSurfaceData(_westWallMaterialIndex));
			_floorMaterialIndex = array[4];
			CellMaterials.Painted?.Invoke(null, MonoSingleton<SurfaceObjectPaintingSystem>.Instance.GetFloorSurfaceData(_floorMaterialIndex));
		}
	}

	public void ClearBuyPaint()
	{
		if (_paintingNordWallMaterialIndex.HasValue)
		{
			_paintingNordWallMaterialIndex = null;
		}
		if (_paintingEastWallMaterialIndex.HasValue)
		{
			_paintingEastWallMaterialIndex = null;
		}
		if (_paintingSouthWallMaterialIndex.HasValue)
		{
			_paintingSouthWallMaterialIndex = null;
		}
		if (_paintingWestWallMaterialIndex.HasValue)
		{
			_paintingWestWallMaterialIndex = null;
		}
		if (_paintingFloorMaterialIndex.HasValue)
		{
			_paintingFloorMaterialIndex = null;
		}
	}

	public void BuyPaint()
	{
		if (_paintingNordWallMaterialIndex.HasValue)
		{
			CellMaterials.OnRepaint?.Invoke(_nordWallMaterialIndex, _paintingNordWallMaterialIndex.Value, arg3: false);
			_nordWallMaterialIndex = _paintingNordWallMaterialIndex.Value;
			_paintingNordWallMaterialIndex = null;
		}
		if (_paintingEastWallMaterialIndex.HasValue)
		{
			CellMaterials.OnRepaint?.Invoke(_eastWallMaterialIndex, _paintingEastWallMaterialIndex.Value, arg3: false);
			_eastWallMaterialIndex = _paintingEastWallMaterialIndex.Value;
			_paintingEastWallMaterialIndex = null;
		}
		if (_paintingSouthWallMaterialIndex.HasValue)
		{
			CellMaterials.OnRepaint?.Invoke(_southWallMaterialIndex, _paintingSouthWallMaterialIndex.Value, arg3: false);
			_southWallMaterialIndex = _paintingSouthWallMaterialIndex.Value;
			_paintingSouthWallMaterialIndex = null;
		}
		if (_paintingWestWallMaterialIndex.HasValue)
		{
			CellMaterials.OnRepaint?.Invoke(_westWallMaterialIndex, _paintingWestWallMaterialIndex.Value, arg3: false);
			_westWallMaterialIndex = _paintingWestWallMaterialIndex.Value;
			_paintingWestWallMaterialIndex = null;
		}
		if (_paintingFloorMaterialIndex.HasValue)
		{
			CellMaterials.OnRepaint?.Invoke(_floorMaterialIndex, _paintingFloorMaterialIndex.Value, arg3: true);
			_floorMaterialIndex = _paintingFloorMaterialIndex.Value;
			_paintingFloorMaterialIndex = null;
		}
	}

	public bool SetNordWall(int value)
	{
		if (_nordWallMaterialIndex != value)
		{
			_paintingNordWallMaterialIndex = value;
		}
		else
		{
			_paintingNordWallMaterialIndex = null;
		}
		return _nordWallMaterialIndex != value;
	}

	public bool SetEastWall(int value)
	{
		if (_eastWallMaterialIndex != value)
		{
			_paintingEastWallMaterialIndex = value;
		}
		else
		{
			_paintingEastWallMaterialIndex = null;
		}
		return _eastWallMaterialIndex != value;
	}

	public bool SetSouthWall(int value)
	{
		if (_southWallMaterialIndex != value)
		{
			_paintingSouthWallMaterialIndex = value;
		}
		else
		{
			_paintingSouthWallMaterialIndex = null;
		}
		return _southWallMaterialIndex != value;
	}

	public bool SetWestWall(int value)
	{
		if (_westWallMaterialIndex != value)
		{
			_paintingWestWallMaterialIndex = value;
		}
		else
		{
			_paintingWestWallMaterialIndex = null;
		}
		return _westWallMaterialIndex != value;
	}

	public bool SetFloor(int value)
	{
		if (_floorMaterialIndex != value)
		{
			_paintingFloorMaterialIndex = value;
		}
		else
		{
			_paintingFloorMaterialIndex = null;
		}
		return _floorMaterialIndex != value;
	}

	public int GetNordWallIndex()
	{
		if (!_paintingNordWallMaterialIndex.HasValue)
		{
			return _nordWallMaterialIndex;
		}
		return _paintingNordWallMaterialIndex.Value;
	}

	public int GetEastWallIndex()
	{
		if (!_paintingEastWallMaterialIndex.HasValue)
		{
			return _eastWallMaterialIndex;
		}
		return _paintingEastWallMaterialIndex.Value;
	}

	public int GetSouthWallIndex()
	{
		if (!_paintingSouthWallMaterialIndex.HasValue)
		{
			return _southWallMaterialIndex;
		}
		return _paintingSouthWallMaterialIndex.Value;
	}

	public int GetWestWallIndex()
	{
		if (!_paintingWestWallMaterialIndex.HasValue)
		{
			return _westWallMaterialIndex;
		}
		return _paintingWestWallMaterialIndex.Value;
	}

	public int GetFloorIndex()
	{
		if (!_paintingFloorMaterialIndex.HasValue)
		{
			return _floorMaterialIndex;
		}
		return _paintingFloorMaterialIndex.Value;
	}

	public void ClearNord()
	{
		_paintingNordWallMaterialIndex = null;
		_nordWallMaterialIndex = 0;
	}

	public void ClearEast()
	{
		_paintingEastWallMaterialIndex = null;
		_eastWallMaterialIndex = 0;
	}

	public void ClearSouth()
	{
		_paintingSouthWallMaterialIndex = null;
		_southWallMaterialIndex = 0;
	}

	public void ClearWest()
	{
		_paintingWestWallMaterialIndex = null;
		_westWallMaterialIndex = 0;
	}

	public void ClearFloor()
	{
		_paintingFloorMaterialIndex = null;
		_floorMaterialIndex = 0;
	}

	public int GetPaintingCost()
	{
		int num = 0;
		if (_paintingNordWallMaterialIndex.HasValue)
		{
			num += MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[_paintingNordWallMaterialIndex.Value].PurchasePrice;
		}
		if (_paintingEastWallMaterialIndex.HasValue)
		{
			num += MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[_paintingEastWallMaterialIndex.Value].PurchasePrice;
		}
		if (_paintingSouthWallMaterialIndex.HasValue)
		{
			num += MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[_paintingSouthWallMaterialIndex.Value].PurchasePrice;
		}
		if (_paintingWestWallMaterialIndex.HasValue)
		{
			num += MonoSingleton<SurfaceObjectPaintingSystem>.Instance.WallMaterialsSOs[_paintingWestWallMaterialIndex.Value].PurchasePrice;
		}
		if (_paintingFloorMaterialIndex.HasValue)
		{
			num += MonoSingleton<SurfaceObjectPaintingSystem>.Instance.FloorMaterialsSOs[_paintingFloorMaterialIndex.Value].PurchasePrice;
		}
		return num;
	}
}
