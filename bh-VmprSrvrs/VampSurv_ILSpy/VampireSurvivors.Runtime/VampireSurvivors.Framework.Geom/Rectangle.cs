using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom;

public class Rectangle : BaseGeom
{
	private float _x;

	private float _y;

	private float _width;

	private float _height;

	public float X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public float Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public float Width
	{
		get
		{
			return _width;
		}
		set
		{
			_width = value;
		}
	}

	public float Height
	{
		get
		{
			return _height;
		}
		set
		{
			_height = value;
		}
	}

	public Vector2 Position
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public Rectangle()
	{
	}

	public Rectangle(float x, float y, float width, float height)
	{
		float height2 = default(float);
		_height = height2;
		_x = x;
		_y = y;
		_width = width;
	}

	public bool Contains(float x, float y)
	{
		//IL_001b: Invalid comparison between I4 and F4
		//IL_003d: Invalid comparison between I4 and F4
		float num = y * -1f;
		if (0f < _width && 0f < _height && !(x < _x))
		{
			float num2 = _width + _x;
			if (!(num2 < x) && !(num < _y))
			{
				float num3 = _height + _y;
				bool flag = num3 < num;
				return !flag;
			}
		}
		return false;
	}

	public bool UnitySpaceContains(float2 position)
	{
		//IL_000a: Invalid comparison between O and F4
		//IL_0039: Invalid comparison between F4 and O
		//IL_0057: Invalid comparison between O and F4
		//IL_0086: Invalid comparison between F4 and O
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_x))
		{
			float num = _width + _x;
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_y))
			{
				float num2 = _height + _y;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				return !flag;
			}
		}
		return false;
	}
}
