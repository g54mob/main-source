using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace VampireSurvivors;

public class WorldToCellTest : MonoBehaviour
{
	protected PhaserTilemap tilemap;

	protected SpriteRenderer targetSprite;

	protected bool drawOrig;

	protected bool drawCalc;

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02b3: Expected O, but got Ref
		//IL_02d5: Expected F4, but got I
		//IL_0339: Expected O, but got Ref
		//IL_035d: Expected O, but got Ref
		//IL_036f: Expected O, but got Ref
		//IL_04bb: Expected O, but got I4
		//IL_041a: Expected O, but got Ref
		//IL_00e4: Expected O, but got I4
		//IL_00ae: Expected I, but got O
		//IL_0148: Expected O, but got I4
		//IL_0507: Expected F4, but got Ref
		//IL_0112: Expected I, but got O
		//IL_0589: Expected F4, but got Ref
		//IL_01ac: Expected O, but got I4
		//IL_0451: Expected O, but got Ref
		//IL_0176: Expected I, but got O
		//IL_0215: Expected O, but got Ref
		//IL_0229: Expected native int or pointer, but got O
		//IL_0242: Expected O, but got Ref
		//IL_01da: Expected I, but got O
		//IL_0537: Expected F4, but got Ref
		//IL_0558: Expected O, but got Ref
		//IL_05c6: Expected F4, but got Ref
		//IL_05e4: Expected O, but got Ref
		//IL_02ed->IL0255: Incompatible stack heights: 1 vs 0
		//IL_04d7->IL0255: Incompatible stack heights: 3 vs 0
		//IL_00d1->IL00d1: Incompatible stack heights: 4 vs 3
		//IL_0135->IL0135: Incompatible stack heights: 4 vs 3
		//IL_0199->IL0199: Incompatible stack heights: 4 vs 3
		//IL_01fd->IL01fd: Incompatible stack heights: 4 vs 3
		//IL_055e->IL039b: Incompatible stack heights: 5 vs 3
		//IL_05e9->IL04a4: Incompatible stack heights: 5 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)this.tilemap != null)
		{
			Tilemap component = this.tilemap.GetComponent<Tilemap>();
			SpriteRenderer spriteRenderer = targetSprite;
			if ((object)targetSprite != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				Renderer.get_bounds_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Bounds*)obj3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-6C]");
				float num = 0f;
				if ((object)component != null)
				{
					bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					Vector3 worldPosition = default(Vector3);
					GridLayout.WorldToCell_Injected(((UnityEngine.Object)component).m_CachedPtr, ref worldPosition, out Vector3Int _);
					_ = 0;
					_ = 0;
					bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Vector3 worldPosition2 = default(Vector3);
					GridLayout.WorldToCell_Injected(((UnityEngine.Object)component).m_CachedPtr, ref worldPosition2, out *(Vector3Int*)obj4);
					Vector3Int vector3Int = WorldToCell(component, (Vector3)(&worldPosition2));
					Vector3Int vector3Int2 = WorldToCell(component, (Vector3)(&worldPosition2));
					bool flag4 = !drawOrig;
					Tilemap tilemap = component;
					int value = default(int);
					if (!flag4)
					{
						Gizmos.set_color_Injected(ref *(Color*)(&value));
						bool flag5 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						GridLayout.CellToWorld_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3Int*)(&worldPosition2), out worldPosition);
						Gizmos.DrawSphere_Injected(ref *(Vector3*)(&value), (float)(nint)(&worldPosition2));
						Gizmos.set_color_Injected(ref *(Color*)(&worldPosition2));
						bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						GridLayout.CellToWorld_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3Int*)(&value), out worldPosition);
						Gizmos.DrawSphere_Injected(ref worldPosition2, (float)(nint)(&value));
						num = 0.1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
						value = 0;
						tilemap = (Tilemap)(&worldPosition);
					}
					if (drawCalc)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124D0]");
						_ = 0;
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						Gizmos.set_color_Injected(ref *(Color*)obj5);
						bool flag7 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						GridLayout.CellToWorld_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3Int*)(&value), out worldPosition);
						Gizmos.DrawSphere_Injected(ref worldPosition2, (float)(nint)(&value));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12420]");
						_ = 0;
						object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						Gizmos.set_color_Injected(ref *(Color*)obj6);
						bool flag8 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						GridLayout.CellToWorld_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3Int*)(&value), out worldPosition);
						Gizmos.DrawSphere_Injected(ref worldPosition2, (float)(nint)(&value));
						num = 0.1f;
						value = vector3Int2.m_X;
						tilemap = (Tilemap)(&worldPosition);
					}
					object[] array = new object[4];
					Tilemap tilemap2 = (Tilemap)(object)(Vector3Int)value;
					if (array != null)
					{
						if ((object)tilemap2 != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj7 = default(object);
							bool flag9 = obj7 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Tilemap tilemap3 = (Tilemap)(object)(Vector3Int)value;
						if ((object)tilemap3 != null)
						{
							nint num3 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj8 = default(object);
							bool flag10 = obj8 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Tilemap tilemap4 = (Tilemap)(object)(Vector3Int)value;
						if ((object)tilemap4 != null)
						{
							nint num4 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj9 = default(object);
							bool flag11 = obj9 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Tilemap tilemap5 = (Tilemap)(object)(Vector3Int)value;
						if ((object)tilemap5 != null)
						{
							nint num5 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj10 = default(object);
							bool flag12 = obj10 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(array));
						string message = string.FormatHelper((IFormatProvider)null, "min {0} vs {1} max {2} {3}", (System.ParamsArray)(&value));
						Debug.Log(message);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe Vector3Int WorldToCell(Tilemap tilemap, Vector3 point)
	{
		//IL_012a: Expected native int or pointer, but got O
		//IL_013c: Expected native int or pointer, but got O
		//IL_015d: Expected native int or pointer, but got O
		//IL_017e: Expected native int or pointer, but got O
		//IL_019f: Expected native int or pointer, but got O
		//IL_01ac: Expected native int or pointer, but got O
		//IL_01ba: Expected native int or pointer, but got O
		//IL_00bc->IL0060: Incompatible stack heights: 1 vs 0
		if ((object)tilemap != null)
		{
			Transform transform = tilemap.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Transform transform2 = tilemap.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
					bool flag3 = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
					GridLayout.get_cellSize_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, out Vector3 ret3);
					object obj = (object)ret3 * (object)ret2;
					object obj3 = default(object);
					object obj4 = default(object);
					object obj2 = obj3 * obj4;
					float x = default(float);
					((Vector3*)(nint)point)->x = x;
					((Vector3*)(nint)point)->z = point.z;
					float x2 = point.x / (float)obj;
					((Vector3*)(nint)point)->x = x2;
					float y = point.y / (float)obj2;
					((Vector3*)(nint)point)->y = y;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
					Vector3Int vector3Int = default(Vector3Int);
					int y2 = default(int);
					((Vector3Int*)(nint)vector3Int)->m_Y = y2;
					int x3 = default(int);
					((Vector3Int*)(nint)vector3Int)->m_X = x3;
					((Vector3Int*)(nint)vector3Int)->m_Z = 0;
					return vector3Int;
				}
			}
		}
		throw new NullReferenceException();
	}

	public WorldToCellTest()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
