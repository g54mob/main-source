using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

public static class VectorUtils
{
	[MethodImpl((MethodImplOptions)256)]
	public unsafe static float3 ToFloat3(float2 v)
	{
		//IL_000d: Expected F4, but got O
		//IL_0008: Expected native int or pointer, but got O
		//IL_0015: Expected native int or pointer, but got O
		//IL_0023: Expected native int or pointer, but got O
		float3 float5 = default(float3);
		((float3*)(nint)float5)->x = (float)v;
		float y = default(float);
		((float3*)(nint)float5)->y = y;
		((float3*)(nint)float5)->z = 0f;
		return float5;
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe static float3 ToFloat3(float2 v, float vz)
	{
		//IL_000d: Expected F4, but got O
		//IL_0008: Expected native int or pointer, but got O
		//IL_0015: Expected native int or pointer, but got O
		//IL_0022: Expected native int or pointer, but got O
		float3 float5 = default(float3);
		((float3*)(nint)float5)->x = (float)v;
		float y = default(float);
		((float3*)(nint)float5)->y = y;
		((float3*)(nint)float5)->z = vz;
		return float5;
	}

	public static float2 setToPolar(float2 v, float azimuth, float radius = 1f)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float2 result = default(float2);
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float2 RotatePoint(float2 target, float angle, float2 origin)
	{
		float num = angle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float num2 = angle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float2 result = default(float2);
		return result;
	}

	public static float2 ToFloat2(Vector2 v)
	{
		float2 result = default(float2);
		return result;
	}

	public static float2 ToFloat2(Vector3 v)
	{
		float2 result = default(float2);
		return result;
	}

	public static Vector2 ToVector2(Vector3 v)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public static Vector2 ToVector2(float2 v)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe static Vector3 ToVector3(Vector2 v)
	{
		//IL_000d: Expected F4, but got O
		//IL_0008: Expected native int or pointer, but got O
		//IL_0015: Expected native int or pointer, but got O
		//IL_0023: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)v;
		float y = default(float);
		((Vector3*)(nint)vector)->y = y;
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public unsafe static Vector3 ToVector3(float2 v)
	{
		//IL_000d: Expected F4, but got O
		//IL_0008: Expected native int or pointer, but got O
		//IL_0015: Expected native int or pointer, but got O
		//IL_0023: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)v;
		float y = default(float);
		((Vector3*)(nint)vector)->y = y;
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public static void Set(Vector2 v, double x, double y)
	{
	}
}
