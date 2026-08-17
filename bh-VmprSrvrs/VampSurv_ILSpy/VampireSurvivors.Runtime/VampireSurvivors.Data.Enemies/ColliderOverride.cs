using System;

namespace VampireSurvivors.Data.Enemies;

[Serializable]
public class ColliderOverride
{
	private float _003Cradius_003Ek__BackingField;

	private float _003CoffsetX_003Ek__BackingField;

	private float _003CoffsetY_003Ek__BackingField;

	private bool _003CupdateBasedOnFlipX_003Ek__BackingField;

	private float _003CoffsetXWhenFlipped_003Ek__BackingField;

	public float radius
	{
		get
		{
			return _003Cradius_003Ek__BackingField;
		}
		set
		{
			_003Cradius_003Ek__BackingField = value;
		}
	}

	public float offsetX
	{
		get
		{
			return _003CoffsetX_003Ek__BackingField;
		}
		set
		{
			_003CoffsetX_003Ek__BackingField = value;
		}
	}

	public float offsetY
	{
		get
		{
			return _003CoffsetY_003Ek__BackingField;
		}
		set
		{
			_003CoffsetY_003Ek__BackingField = value;
		}
	}

	public bool updateBasedOnFlipX
	{
		get
		{
			return _003CupdateBasedOnFlipX_003Ek__BackingField;
		}
		set
		{
			_003CupdateBasedOnFlipX_003Ek__BackingField = value;
		}
	}

	public float offsetXWhenFlipped
	{
		get
		{
			return _003CoffsetXWhenFlipped_003Ek__BackingField;
		}
		set
		{
			_003CoffsetXWhenFlipped_003Ek__BackingField = value;
		}
	}
}
