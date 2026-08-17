using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom;

public class Circle : BaseGeom
{
	private float _x;

	private float _y;

	private float _radius;

	private float _diameter;

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

	public float Radius
	{
		get
		{
			return _radius;
		}
		set
		{
			_radius = value;
			float diameter = value + value;
			_diameter = diameter;
		}
	}

	public float Diameter
	{
		get
		{
			return _diameter;
		}
		set
		{
			_diameter = value;
			float radius = value * 0.5f;
			_radius = radius;
		}
	}

	public Vector2 Position
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			//IL_000a: Expected F4, but got O
			_x = (float)value;
			float y = default(float);
			_y = y;
		}
	}

	public bool IsEmpty
	{
		get
		{
			//IL_000b: Invalid comparison between I4 and F4
			bool flag = 0f < _radius;
			return !flag;
		}
	}

	public float Left => _x - _radius;

	public float Right => _radius + _x;

	public float Top => _radius + _y;

	public float Bottom => _y - _radius;

	public Circle()
	{
	}

	public Circle(float x, float y, float radius)
	{
		_x = x;
		_y = y;
		_radius = radius;
	}

	public List<Vector2> GetPoints(int quantity)
	{
		//IL_000e: Expected O, but got I4
		//IL_0047: Expected O, but got I
		//IL_00c1: Expected O, but got I
		//IL_0095: Expected O, but got I4
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		List<Vector2> list = new List<Vector2>(quantity);
		if (quantity > 0)
		{
			object obj = 0;
			int capacity = quantity;
			List<Vector2> list2 = list;
			int num9 = default(int);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,edi\"");
				float num = 0f * (float)Math.PI;
				float num2 = num + num;
				float num3 = num2 / (float)quantity;
				list2._002Ector(capacity);
				float num4 = num3 * _radius;
				float num5 = num4 + _x;
				list2._002Ector(capacity);
				float num6 = num3 * _radius;
				float num7 = num6 + _y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				list2 = (List<Vector2>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				capacity = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if (num8 >= 0)
				{
					list.AddWithResize((Vector2)num9);
					capacity = num9;
					list2 = list;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj2 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if (num10 >= 0)
					{
						return (List<Vector2>)(object)new IndexOutOfRangeException();
					}
				}
				obj++;
			}
			while ((nint)obj < quantity);
		}
		return list;
	}

	public Vector2 CircumferencePoint(float angle)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}

	public void SetPosition(float x, float y)
	{
		_x = x;
		_y = y;
	}

	public Vector2 GetRandomPoint()
	{
		//IL_0013: Expected O, but got F4
		//IL_0080: Expected O, but got F4
		//IL_0031: Expected O, but got F4
		//IL_0047: Invalid comparison between O and F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * ((float)Math.PI * 2f);
		object obj3 = UnityEngine.Random.value;
		object obj4 = UnityEngine.Random.value;
		object obj5 = obj2 + obj2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}

	public bool Contains(Vector2 point)
	{
		//IL_000b: Invalid comparison between F4 and I4
		//IL_003d: Invalid comparison between O and F4
		//IL_006c: Invalid comparison between F4 and O
		//IL_009b: Invalid comparison between F4 and O
		//IL_00ca: Invalid comparison between O and F4
		if (_radius > 0f)
		{
			float num = _x - _radius;
			if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref point) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
			{
				float num2 = _radius + _x;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) >= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref point))
				{
					float num3 = _radius + _y;
					object obj = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						float num4 = _y - _radius;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
						{
							float num5 = _x - (float)point;
							float num6 = _y - (float)obj;
							float num7 = _radius * _radius;
							float num8 = num5 * num5;
							float num9 = num6 * num6;
							float num10 = num8 + num9;
							bool flag = num7 < num10;
							return !flag;
						}
					}
				}
			}
		}
		return false;
	}
}
