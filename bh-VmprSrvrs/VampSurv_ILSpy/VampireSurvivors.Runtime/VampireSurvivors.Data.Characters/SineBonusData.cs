using System;

namespace VampireSurvivors.Data.Characters;

[Serializable]
public class SineBonusData
{
	private float _003Cmin_003Ek__BackingField = 1f;

	private float _003Cmax_003Ek__BackingField = 1f;

	private float _003Cduration_003Ek__BackingField = 1f;

	public float min
	{
		get
		{
			return _003Cmin_003Ek__BackingField;
		}
		set
		{
			_003Cmin_003Ek__BackingField = value;
		}
	}

	public float max
	{
		get
		{
			return _003Cmax_003Ek__BackingField;
		}
		set
		{
			_003Cmax_003Ek__BackingField = value;
		}
	}

	public float duration
	{
		get
		{
			return _003Cduration_003Ek__BackingField;
		}
		set
		{
			_003Cduration_003Ek__BackingField = value;
		}
	}
}
