using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public struct TilemapDataCache
{
	public float2 worldpos;

	public float2 size;

	public BoundsInt worldBounds;

	public TilemapDataCache(Tilemap layer)
	{
		//IL_0092->IL0043: Incompatible stack heights: 1 vs 0
		if ((object)layer != null)
		{
			Transform transform = layer.transform;
			bool flag = ((UnityEngine.Object)layer).m_CachedPtr == (IntPtr)0;
			GridLayout.get_cellSize_Injected(((UnityEngine.Object)layer).m_CachedPtr, out Vector3 ret);
			if ((object)transform != null)
			{
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret2);
				float2 float5 = (object)ret2 * (object)ret;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 * obj3;
				size = float5;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				float2 float6 = default(float2);
				worldpos = float6;
				worldBounds = (BoundsInt)layer.cellBounds.m_Position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v34 (UnityEngine.BoundsInt)+10]");
				_ = 0;
				return;
			}
		}
		throw new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public float2 CellToWorld(float2 pos)
	{
		float2 result = default(float2);
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public float2 CellToWorld(int2 pos)
	{
		float2 result = default(float2);
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public int2 WorldToCell(float2 pos)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		object obj = pos - worldpos;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		object obj5 = obj / (object)size;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (TilemapDataCache)+C]");
		object obj6 = obj2 / 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		int2 result = default(int2);
		return result;
	}

	public TilemapDataCache(PhaserTilemap tilemap)
		: this(tilemap._layer)
	{
	}
}
