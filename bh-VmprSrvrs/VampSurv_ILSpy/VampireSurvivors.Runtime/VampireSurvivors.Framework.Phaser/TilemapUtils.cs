using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Phaser;

public static class TilemapUtils
{
	public unsafe static void RemoveTileAt(SuperMap map, int x, int y, string layerName)
	{
		//IL_014c->IL0100: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		Stage stage = core._stage;
		SuperTileLayer superTileLayer = stage._tilingTileset.GetSuperTileLayer(map, layerName);
		Tilemap component = superTileLayer.GetComponent<Tilemap>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			int position = default(int);
			Tilemap.SetTileAsset_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3Int*)(&position), (IntPtr)0);
		}
		PhaserTilemap component2 = superTileLayer.GetComponent<PhaserTilemap>();
		if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
		{
			component2.RemoveTileAt(x, y);
		}
	}

	public unsafe static bool BatchRemoveTileAt(SuperMap map, List<int2> posList, string layerName)
	{
		//IL_0105: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_0128: Expected O, but got I
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_02d1: Expected I4, but got O
		//IL_02ea: Expected O, but got I4
		//IL_02f3: Expected O, but got I4
		//IL_01b3: Expected O, but got Ref
		//IL_040c: Expected O, but got I
		//IL_041a->IL03c0: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		bool result;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._tilingTileset != null)
			{
				string layerName2 = default(string);
				SuperTileLayer superTileLayer = stage._tilingTileset.GetSuperTileLayer(map, layerName2);
				if ((object)superTileLayer == null || ((UnityEngine.Object)superTileLayer).m_CachedPtr == (IntPtr)0)
				{
					return false;
				}
				Tilemap component = superTileLayer.GetComponent<Tilemap>();
				PhaserTilemap component2 = superTileLayer.GetComponent<PhaserTilemap>();
				if (posList != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
					bool flag = (nint)0 <= (nint)0;
					object obj = 0;
					bool flag2 = false;
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
					object obj3 = 0;
					result = false;
					if (flag)
					{
						goto IL_032a;
					}
					float2 float5 = default(float2);
					float2 float6 = default(float2);
					float2 position = default(float2);
					object obj5 = default(object);
					float2 float8 = default(float2);
					object obj6 = default(object);
					int tileX = default(int);
					while (true)
					{
						bool flag3 = (object)component == null;
						bool flag4 = true;
						if (!flag3)
						{
							bool flag5 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
							flag4 = true;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								if (!flag2)
								{
									TileBase tile = component.GetTile((Vector3Int)(&float5));
									if ((bool)tile)
									{
										flag2 = true;
									}
									float5 = float6;
								}
								bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
								Tilemap.SetTileAsset_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3Int*)(&position), (IntPtr)0);
								float2 float7 = float6;
								layerName2 = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
								obj3 = 0;
								flag4 = true;
							}
						}
						if ((bool)component2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							object obj4 = obj5 >> 32;
							if (!flag2)
							{
								if ((object)component2 == null)
								{
									break;
								}
								bool flag7 = component2.IsTileAtPosition(float8);
								bool flag8 = !flag7;
								float2 float7 = float8;
								layerName2 = null;
								if (!flag8)
								{
									float7 = float8;
									flag2 = flag4;
									layerName2 = null;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if ((object)component2 == null)
							{
								break;
							}
							int num = obj6 >> 32;
							component2.RemoveTileAt(tileX, num);
							layerName2 = (string)num;
							obj2 = 0;
						}
						obj++;
						bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
						result = flag2;
						if (flag9)
						{
							continue;
						}
						goto IL_032a;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_032a:
		return result;
	}
}
