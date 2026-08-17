using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom;

public class Ellipse : BaseGeom
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

	public bool IsEmpty
	{
		get
		{
			//IL_000b: Invalid comparison between I4 and F4
			//IL_0030: Invalid comparison between I4 and F4
			if (!(0f < _width))
			{
				return true;
			}
			bool flag = 0f < _height;
			return !flag;
		}
	}

	public float Left
	{
		get
		{
			float num = _width * 0.5f;
			return _x - num;
		}
	}

	public float Right
	{
		get
		{
			float num = _width * 0.5f;
			return num + _x;
		}
	}

	public float Top
	{
		get
		{
			float num = _height * 0.5f;
			return num + _y;
		}
	}

	public float Bottom
	{
		get
		{
			float num = _height * 0.5f;
			return _y - num;
		}
	}

	public Ellipse()
	{
	}

	public Ellipse(float x, float y, float width, float height)
	{
		float height2 = default(float);
		_height = height2;
		_x = x;
		_y = y;
		_width = width;
	}

	public void SetPosition(float x, float y)
	{
		_x = x;
		_y = y;
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
			int num11 = default(int);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,edi\"");
				float num = 0f * (float)Math.PI;
				float num2 = num + num;
				float num3 = num2 / (float)quantity;
				list2._002Ector(capacity);
				float num4 = _width * 0.5f;
				float num5 = num3 * num4;
				float num6 = num5 + _x;
				list2._002Ector(capacity);
				float num7 = _height * 0.5f;
				float num8 = num3 * num7;
				float num9 = num8 + _y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				list2 = (List<Vector2>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				capacity = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if (num10 >= 0)
				{
					list.AddWithResize((Vector2)num11);
					capacity = num11;
					list2 = list;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj2 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if (num12 >= 0)
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
		float num = _width * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}
}
