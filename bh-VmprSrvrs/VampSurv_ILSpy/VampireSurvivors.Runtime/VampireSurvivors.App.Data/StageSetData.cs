using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;

namespace VampireSurvivors.App.Data;

[Serializable]
public class StageSetData
{
	private StageSetType _003CType_003Ek__BackingField;

	private Dictionary<StageType, List<StageData>> _003CData_003Ek__BackingField;

	public StageSetType Type
	{
		get
		{
			return _003CType_003Ek__BackingField;
		}
		set
		{
			_003CType_003Ek__BackingField = value;
		}
	}

	public Dictionary<StageType, List<StageData>> Data
	{
		get
		{
			return _003CData_003Ek__BackingField;
		}
		set
		{
			_003CData_003Ek__BackingField = value;
		}
	}
}
