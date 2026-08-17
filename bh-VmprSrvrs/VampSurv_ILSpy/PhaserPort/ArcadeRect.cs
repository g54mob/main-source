using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct ArcadeRect
{
	public float x;

	public float y;

	public float width;

	public float height;

	public float left
	{
		get
		{
			return x;
		}
		set
		{
			x = value;
		}
	}

	public float top
	{
		get
		{
			return y;
		}
		set
		{
			y = value;
		}
	}

	public float right => width + x;

	public float bottom => height + y;

	public ArcadeRect(float2 pos, float2 size)
	{
		//IL_000a: Expected F4, but got O
		//IL_001e: Expected F4, but got O
		x = (float)pos;
		float num = default(float);
		y = num;
		width = (float)size;
		float num2 = default(float);
		height = num2;
	}

	public ArcadeRect(float x, float y, float2 size)
	{
		//IL_0014: Expected F4, but got O
		this.x = x;
		width = (float)size;
		float num = default(float);
		height = num;
		this.y = y;
	}

	public ArcadeRect(float x, float y, float width, float height)
	{
		float num = default(float);
		this.height = num;
		this.x = x;
		this.y = y;
		this.width = width;
	}

	public unsafe static ArcadeRect FromBounds(float x, float y, float right, float bottom)
	{
		//IL_000d: Invalid comparison between O and F4
		//IL_0061: Expected native int or pointer, but got O
		//IL_007d: Expected native int or pointer, but got O
		//IL_008a: Expected native int or pointer, but got O
		//IL_0097: Expected native int or pointer, but got O
		object obj = default(object);
		if (right > x || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y))
		{
			Debug.DebugBreak();
		}
		float num = right - x;
		ArcadeRect arcadeRect = default(ArcadeRect);
		((ArcadeRect*)(nint)arcadeRect)->x = x;
		float num2 = (float)obj - y;
		((ArcadeRect*)(nint)arcadeRect)->y = y;
		((ArcadeRect*)(nint)arcadeRect)->width = num;
		((ArcadeRect*)(nint)arcadeRect)->height = num2;
		return arcadeRect;
	}

	public void setTo(float x, float y, float width, float height)
	{
		float num = default(float);
		this.height = num;
		this.x = x;
		this.y = y;
		this.width = width;
	}

	public bool contains(float2 position)
	{
		//IL_000a: Invalid comparison between O and F4
		//IL_0039: Invalid comparison between F4 and O
		//IL_0057: Invalid comparison between O and F4
		//IL_0086: Invalid comparison between F4 and O
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x))
		{
			float num = width + x;
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y))
			{
				float num2 = height + y;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				return !flag;
			}
		}
		return false;
	}
}
