using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class ArcadeBodyBounds : RBush.IRectangular
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

	public float minX => x;

	public float minY => y;

	public float maxX => width + x;

	public float maxY => height + y;

	public ArcadeBodyBounds()
	{
		x = 0f;
		width = 0f;
	}

	public ArcadeBodyBounds(float x, float y, float width, float height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		float num = default(float);
		this.height = num;
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

	public float2 randomPoint()
	{
		//IL_0010: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0076: Expected O, but got I8
		//IL_00b4: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		ArcadeBodyBounds arcadeBodyBounds = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			arcadeBodyBounds = (ArcadeBodyBounds)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v52 @ rax_v5 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			arcadeBodyBounds = (ArcadeBodyBounds)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v98 @ rax_v8 (should have been resolved before IL gen)");
		float2 result = default(float2);
		return result;
	}
}
