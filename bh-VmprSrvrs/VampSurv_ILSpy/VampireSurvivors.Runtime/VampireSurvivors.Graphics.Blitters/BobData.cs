using System;

namespace VampireSurvivors.Graphics.Blitters;

[Serializable]
public class BobData
{
	private float _003CVx_003Ek__BackingField;

	private float _003CVy_003Ek__BackingField;

	private float _003CBounce_003Ek__BackingField;

	private float _003CRight_003Ek__BackingField;

	private float _003CLeft_003Ek__BackingField;

	private float _003CTop_003Ek__BackingField;

	private float _003CBottom_003Ek__BackingField;

	private int _003CID_003Ek__BackingField;

	public float Vx
	{
		get
		{
			return _003CVx_003Ek__BackingField;
		}
		set
		{
			_003CVx_003Ek__BackingField = value;
		}
	}

	public float Vy
	{
		get
		{
			return _003CVy_003Ek__BackingField;
		}
		set
		{
			_003CVy_003Ek__BackingField = value;
		}
	}

	public float Bounce
	{
		get
		{
			return _003CBounce_003Ek__BackingField;
		}
		set
		{
			_003CBounce_003Ek__BackingField = value;
		}
	}

	public float Right
	{
		get
		{
			return _003CRight_003Ek__BackingField;
		}
		set
		{
			_003CRight_003Ek__BackingField = value;
		}
	}

	public float Left
	{
		get
		{
			return _003CLeft_003Ek__BackingField;
		}
		set
		{
			_003CLeft_003Ek__BackingField = value;
		}
	}

	public float Top
	{
		get
		{
			return _003CTop_003Ek__BackingField;
		}
		set
		{
			_003CTop_003Ek__BackingField = value;
		}
	}

	public float Bottom
	{
		get
		{
			return _003CBottom_003Ek__BackingField;
		}
		set
		{
			_003CBottom_003Ek__BackingField = value;
		}
	}

	public int ID
	{
		get
		{
			return _003CID_003Ek__BackingField;
		}
		set
		{
			_003CID_003Ek__BackingField = value;
		}
	}

	public void Reset()
	{
		_003CTop_003Ek__BackingField = 0f;
		_003CRight_003Ek__BackingField = 0f;
		_003CVy_003Ek__BackingField = 0f;
		_003CVx_003Ek__BackingField = 0f;
		_003CID_003Ek__BackingField = 0;
	}
}
