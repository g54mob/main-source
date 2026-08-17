using System;

namespace Doozy.Engine.Attributes;

public class MinMaxRangeAttribute(float min, float max) : Attribute
{
	private float _003CMin_003Ek__BackingField = min;

	private float _003CMax_003Ek__BackingField = max;

	public float Min
	{
		get
		{
			return _003CMin_003Ek__BackingField;
		}
		private set
		{
			_003CMin_003Ek__BackingField = value;
		}
	}

	public float Max
	{
		get
		{
			return _003CMax_003Ek__BackingField;
		}
		private set
		{
			_003CMax_003Ek__BackingField = value;
		}
	}
}
