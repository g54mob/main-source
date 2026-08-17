using System;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class TilemapPos
{
	private float _003Cx_003Ek__BackingField;

	private float _003Cy_003Ek__BackingField;

	public float x
	{
		get
		{
			return _003Cx_003Ek__BackingField;
		}
		set
		{
			_003Cx_003Ek__BackingField = value;
		}
	}

	public float y
	{
		get
		{
			return _003Cy_003Ek__BackingField;
		}
		set
		{
			_003Cy_003Ek__BackingField = value;
		}
	}
}
