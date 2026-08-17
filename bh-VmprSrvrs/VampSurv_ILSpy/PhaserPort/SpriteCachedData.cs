using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;

public struct SpriteCachedData
{
	public const float PPU = 100f;

	public const float OneDivPPU = 0.01f;

	public float2 sizeInUnits;

	public float2 pivotInUnits;

	private float2 originalSize;

	public void Set(Sprite t)
	{
		//IL_00ea: Expected O, but got F4
		//IL_006c: Expected O, but got I4
		//IL_0197: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000185012D7Fh\"");
		float2 float5 = default(float2);
		if ((object)originalSize == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000185012D7Fh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SpriteCachedData)+14]");
			if ((nint)0 == 0)
			{
				if ((object)t == null)
				{
					sizeInUnits = float5;
					pivotInUnits = (float2)1056964608;
					_ = 1056964608;
					return;
				}
				bool flag = ((UnityEngine.Object)t).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)t).m_CachedPtr, out Rect _);
				sizeInUnits = float5;
				Vector2 pivot = t.pivot;
				float num = (float)pivot * 0.01f;
				object obj = default(object);
				float num2 = (float)obj * 0.01f;
				pivotInUnits = (float2)num;
				return;
			}
		}
		originalSize = originalSize;
		float num3 = (float)originalSize * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SpriteCachedData)+14]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SpriteCachedData)+14]");
		float num4 = 0f * 0.5f;
		float num5 = num3 * 0.01f;
		float num6 = num4 * 0.01f;
		pivotInUnits = (float2)num5;
		sizeInUnits = float5;
	}

	public void Set(Sprite t, float2 originalSize)
	{
		//IL_0054: Expected O, but got F4
		float num = (float)originalSize * 0.5f;
		this.originalSize = originalSize;
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		float num3 = num * 0.01f;
		float num4 = num2 * 0.01f;
		pivotInUnits = (float2)num3;
		float2 float5 = default(float2);
		sizeInUnits = float5;
	}

	public void SetUsingSpritePPU(Sprite t)
	{
		//IL_001a: Expected O, but got I4
		//IL_00e5: Expected O, but got F4
		float2 float5 = default(float2);
		float num;
		while (true)
		{
			if ((object)t == null)
			{
				sizeInUnits = float5;
				pivotInUnits = (float2)1056964608;
				_ = 1056964608;
				return;
			}
			float pixelsPerUnit = t.pixelsPerUnit;
			num = 1f / pixelsPerUnit;
			if (((UnityEngine.Object)t).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(t);
		}
		Sprite.get_rect_Injected(((UnityEngine.Object)t).m_CachedPtr, out Rect _);
		sizeInUnits = float5;
		Vector2 pivot = t.pivot;
		float num2 = (float)pivot * num;
		object obj = default(object);
		float num3 = (float)obj * num;
		pivotInUnits = (float2)num2;
	}
}
