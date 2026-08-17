using System;
using UnityEngine;

public class DebugGUIGraphAttribute : Attribute
{
	private float _003Cmin_003Ek__BackingField;

	private float _003Cmax_003Ek__BackingField;

	private Color _003Ccolor_003Ek__BackingField;

	private int _003Cgroup_003Ek__BackingField;

	private bool _003CautoScale_003Ek__BackingField;

	public float min
	{
		get
		{
			return _003Cmin_003Ek__BackingField;
		}
		private set
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
		private set
		{
			_003Cmax_003Ek__BackingField = value;
		}
	}

	public unsafe Color color
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)_003Ccolor_003Ek__BackingField;
			return color;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003Ccolor_003Ek__BackingField = (Color)value.r;
		}
	}

	public int group
	{
		get
		{
			return _003Cgroup_003Ek__BackingField;
		}
		private set
		{
			_003Cgroup_003Ek__BackingField = value;
		}
	}

	public bool autoScale
	{
		get
		{
			return _003CautoScale_003Ek__BackingField;
		}
		private set
		{
			_003CautoScale_003Ek__BackingField = value;
		}
	}

	public DebugGUIGraphAttribute(float r = 1f, float g = 1f, float b = 1f, float min = 0f, float max = 1f, int group = 0, bool autoScale = true)
	{
		int num = default(int);
		_003Cgroup_003Ek__BackingField = num;
		float num2 = default(float);
		_003Cmin_003Ek__BackingField = num2;
		float num3 = default(float);
		_003Cmax_003Ek__BackingField = num3;
		bool flag = default(bool);
		_003CautoScale_003Ek__BackingField = flag;
		Color color = default(Color);
		_003Ccolor_003Ek__BackingField = color;
	}
}
