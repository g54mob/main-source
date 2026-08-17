using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Plugins.PhaserPort.optimize;

public class PhaserTilemapRevealTiles : MonoBehaviour
{
	protected int randomSeed;

	protected PhaserTilemap tilemap;

	protected unsafe void OnDrawGizmosSelected()
	{
		//IL_0008: Expected O, but got Ref
		//IL_065b: Expected O, but got Ref
		//IL_0450: Expected O, but got I4
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_049a: Expected O, but got Ref
		//IL_0643: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_019c: Expected O, but got I
		//IL_02e0: Expected O, but got I
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		//IL_02fe: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_0204: Expected O, but got I
		//IL_0502: Expected O, but got Ref
		//IL_0238: Expected O, but got I
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Expected O, but got Unknown
		//IL_0292: Expected O, but got I
		//IL_02c6: Expected O, but got I
		//IL_05d5: Expected O, but got Ref
		//IL_069a: Expected O, but got Ref
		//IL_06ba: Expected O, but got F4
		//IL_061c: Expected O, but got Ref
		//IL_03fe->IL0315: Incompatible stack heights: 1 vs 0
		//IL_0630->IL0585: Incompatible stack heights: 3 vs 2
		Vector3 center = default(Vector3);
		object obj = (object)(&center);
		PhaserTilemap phaserTilemap = this.tilemap;
		if ((object)this.tilemap == null || ((UnityEngine.Object)phaserTilemap).m_CachedPtr == (IntPtr)0)
		{
			PhaserTilemap component = GetComponent<PhaserTilemap>();
			this.tilemap = component;
		}
		PhaserTilemap phaserTilemap2 = this.tilemap;
		if ((object)this.tilemap != null)
		{
			Tilemap tilemap = phaserTilemap2._layer;
			if ((object)phaserTilemap2._layer == null || ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0)
			{
				if ((object)this.tilemap == null)
				{
					goto IL_0315;
				}
				Tilemap component2 = this.tilemap.GetComponent<Tilemap>();
				tilemap = component2;
			}
			_ = 0;
			object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref center, 96));
			Gizmos.get_color_Injected(out *(Color*)obj2);
			UnityEngine.Random.InitState(randomSeed);
			if ((object)tilemap != null)
			{
				BoundsInt cellBounds = tilemap.cellBounds;
				_ = cellBounds.m_Position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v611 @ rax_v51 (UnityEngine.BoundsInt)+10]");
				_ = 0;
				bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
				GridLayout.get_cellSize_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, out Vector3 ret);
				Transform transform = tilemap.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret2);
					object obj3 = (object)ret * (object)ret2;
					object obj4 = 0 * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
					PhaserTilemapRevealTiles phaserTilemapRevealTiles = (PhaserTilemapRevealTiles)(0 + cellBounds.m_Position);
					_ = cellBounds.m_Position;
					Vector3Int vector3Int = cellBounds.m_Position;
					Vector3Int vector3Int2 = (Vector3Int)(&ret2);
					PhaserTilemapRevealTiles phaserTilemapRevealTiles2 = (PhaserTilemapRevealTiles)cellBounds.m_Position;
					float saturationMax = default(float);
					float valueMin = default(float);
					float valueMax = default(float);
					float alphaMin = default(float);
					float num5 = default(float);
					while (true)
					{
						bool flag3 = System.Runtime.CompilerServices.Unsafe.As<PhaserTilemapRevealTiles, UIntPtr>(ref phaserTilemapRevealTiles2) < System.Runtime.CompilerServices.Unsafe.As<PhaserTilemapRevealTiles, UIntPtr>(ref phaserTilemapRevealTiles);
						PhaserTilemapRevealTiles phaserTilemapRevealTiles3 = phaserTilemapRevealTiles;
						if (!flag3)
						{
							phaserTilemapRevealTiles3 = phaserTilemapRevealTiles2;
						}
						if (System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int) >= System.Runtime.CompilerServices.Unsafe.As<PhaserTilemapRevealTiles, UIntPtr>(ref phaserTilemapRevealTiles3))
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-74]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
						object obj5 = num + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
						object obj6 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
							bool flag4 = 0 < (nint)obj5;
							object obj7 = obj5;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
								obj7 = 0;
							}
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-6C]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
							object obj8 = num2 + 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
							if (0 <= (nint)obj8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
								obj8 = 0;
							}
							vector3Int2 = (Vector3Int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref center, 64));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
							_ = 0;
							TileBase tile = tilemap.GetTile<TileBase>(vector3Int2);
							Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.75f, saturationMax, valueMin, valueMax, alphaMin, 1f);
							if ((object)tile != null && ((UnityEngine.Object)tile).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-6C]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
								object obj9 = num3 + 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
								if (0 <= (nint)obj9)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
									obj9 = 0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
								_ = 0;
								bool flag5 = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
								object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref center, 32));
								GridLayout.CellToWorld_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref *(Vector3Int*)obj10, out ret);
								float num4 = (float)obj4 * 0.5f;
								_ = color.r;
								object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref center, 16));
								Gizmos.set_color_Injected(ref *(Color*)obj11);
								obj = num5;
								vector3Int2 = (Vector3Int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref center, 16));
								Gizmos.DrawCube_Injected(ref center, ref *(Vector3*)vector3Int2);
							}
							obj6++;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
						phaserTilemapRevealTiles2 = (PhaserTilemapRevealTiles)0;
						vector3Int++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
						phaserTilemapRevealTiles = (PhaserTilemapRevealTiles)0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
					_ = 0;
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref center, 96));
					Gizmos.set_color_Injected(ref *(Color*)obj12);
					return;
				}
			}
		}
		goto IL_0315;
		IL_0315:
		throw new NullReferenceException();
	}

	public PhaserTilemapRevealTiles()
	{
		//IL_0020: Expected I, but got O
		randomSeed = 111;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
