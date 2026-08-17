using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PhaserTilemapBoundingBoxesAsset : ScriptableObject
{
	[Serializable]
	public struct BoundCombine
	{
		public int bound1;

		public int bound2;

		public bool IsValid(int count)
		{
			//IL_0091: Expected O, but got I4
			if (bound1 < count && bound2 < count && bound1 >= 0 && bound2 >= 0)
			{
				object obj = bound1 - bound2;
				bool flag = obj == null;
				return !flag;
			}
			return false;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<BoundsInt, bool> _003C_003E9__7_0;

		public static Func<BoundsInt, int> _003C_003E9__7_1;

		public static Func<IGrouping<(int, int, int), BoundsInt>, bool> _003C_003E9__7_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CSetup_003Eb__7_0(BoundsInt x)
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			if ((nint)x.m_Size > 0)
			{
				object obj = (object)x.m_Size >> 32;
				if ((nint)obj > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
					object obj3 = default(object);
					object obj2 = obj3 - 9999;
					bool flag = obj2 == null;
					return !flag;
				}
			}
			return false;
		}

		internal int _003CSetup_003Eb__7_1(BoundsInt x)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850039F0");
			int result = default(int);
			return result;
		}

		internal bool _003CSetup_003Eb__7_3(IGrouping<(int, int, int), BoundsInt> x)
		{
			//IL_0020: Expected O, but got I4
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected I4, but got Unknown
			int num = Enumerable.Count(x);
			object obj = num - 1;
			int num2 = num ^ 1;
			int num3 = num ^ obj;
			int num4 = num2 & num3;
			bool flag = num4 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public BoundsInt bounds;

		public int i;
	}

	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public int j;

		public _003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals1;

		internal (int, int, int) _003CSetup_003Eb__2(BoundsInt x)
		{
			//IL_00ee: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_001f: Expected O, but got I
			//IL_002f: Expected O, but got I
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Expected O, but got Unknown
			//IL_0171: Expected O, but got I
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_019c: Expected O, but got I
			//IL_01aa: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (UnityEngine.BoundsInt)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (UnityEngine.BoundsInt)+18]");
			if ((nint)0 != 0)
			{
				nint num = default(nint);
				object obj2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+C]");
				object obj3 = 0 + num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (UnityEngine.BoundsInt)+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (UnityEngine.BoundsInt)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v1+10]");
					object obj6 = default(object);
					object obj5 = obj6 - 0;
					object obj7 = obj5 >> 31;
					object obj8 = obj5 - obj7;
					object obj9 = obj8 >> 1;
					_003C_003Ec__DisplayClass7_1 obj10 = (_003C_003Ec__DisplayClass7_1)obj9;
					if (num < (nint)obj3)
					{
						obj2 = obj3;
					}
					object obj11 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v6+10]");
					object obj12 = obj11 - 0;
					object obj13 = obj12 >> 31;
					object obj14 = obj12 - obj13;
					object obj15 = obj14 >> 1;
					object obj16 = num >> 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v6+28]");
					object obj17 = obj16 + 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (UnityEngine.BoundsInt)+10]");
					object obj18 = (nint)0 & (nint)0x1F;
					object obj19 = 1 << (int)obj18;
					object obj20 = obj17 / obj19;
					return ((int, int, int))this;
				}
			}
			return ((int, int, int))new NullReferenceException();
		}
	}

	private const int NotSet = 9999;

	public Hash128 hash;

	public BoundCombine combine;

	public List<BoundsInt> allBounds;

	public unsafe static Hash128 CalculateHash(Tilemap tilemap)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0307: Expected I8, but got I4
		//IL_0302: Expected native int or pointer, but got O
		//IL_031a: Expected O, but got Ref
		//IL_033b: Expected I, but got O
		//IL_0366: Expected O, but got I
		//IL_0381: Expected O, but got I4
		//IL_039f: Expected O, but got I
		//IL_005d: Expected O, but got I
		//IL_048c: Expected O, but got I
		//IL_00ae: Expected O, but got I
		//IL_04a1: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_03c1: Expected O, but got Ref
		//IL_040c: Expected O, but got I
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02c0: Expected O, but got I
		//IL_0159: Expected O, but got Ref
		//IL_0176: Expected O, but got Ref
		//IL_01ed: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_026c: Expected O, but got Ref
		//IL_0297->IL045f: Incompatible stack heights: 1 vs 0
		//IL_029c->IL029c: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Hash128 hash = default(Hash128);
		((Hash128*)(nint)hash)->u64_0 = 0uL;
		BoundsInt cellBounds = tilemap.cellBounds;
		_ = cellBounds.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v10 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Hash128.ComputeFromPtr((IntPtr)obj3, 0, 1, 24, ref *(Hash128*)cellBounds.m_Position);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1D]");
		TileBase[] array = new TileBase[0];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1D]");
		object obj4 = (nint)0 >> 32;
		bool flag = (nint)obj4 <= 0;
		object obj5 = 0;
		if (!flag)
		{
			object arg = default(object);
			object arg2 = default(object);
			object obj16;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1D]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
				object obj7 = num + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
				if (0 > (nint)obj7)
				{
					obj6 = obj7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-25]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-25]");
				object obj9 = num2 + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-25]");
				if (0 > (nint)obj9)
				{
					obj8 = obj9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-15]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
				object obj11 = num3 + 0;
				object obj12 = obj8 + obj5;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
				if (0 > (nint)obj11)
				{
					obj10 = obj11;
				}
				BoundsInt bounds = (BoundsInt)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1D]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
				int tilesBlockNonAlloc = ((Tilemap)0).GetTilesBlockNonAlloc(bounds, array);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1D]");
				if ((nint)tilesBlockNonAlloc != 0)
				{
					object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1D]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					string message = $"Missing tile bounds {arg} vs {arg2}";
					Debug.LogWarning(message);
					bounds = (BoundsInt)0;
				}
				if (tilesBlockNonAlloc > 0)
				{
					object obj15 = 0;
					do
					{
						bool flag2 = (nint)obj15 >= array.Length;
						TileBase tileBase = array[obj15];
						if ((object)array[obj15] != null && ((UnityEngine.Object)tileBase).m_CachedPtr != (IntPtr)0)
						{
							ref Vector3 reference = ref System.Runtime.CompilerServices.Unsafe.As<object, Vector3>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							_ = 0;
							((Hash128*)hash)->Append(ref reference);
							bounds = (BoundsInt)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
						}
						obj15++;
					}
					while ((nint)obj15 < tilesBlockNonAlloc);
				}
				obj5++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1D]");
				obj16 = (nint)0 >> 32;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16));
		}
		return hash;
	}

	public unsafe void MakeWholeBound(PhaserTilemap from)
	{
		//IL_00c2: Expected O, but got I
		//IL_011b: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0100: Expected O, but got Ref
		//IL_01af: Expected O, but got I8
		Tilemap tilemap = from._layer;
		if ((object)from._layer == null || ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0)
		{
			Tilemap component = from.GetComponent<Tilemap>();
			tilemap = component;
		}
		BoundsInt cellBounds = tilemap.cellBounds;
		List<BoundsInt> list = new List<BoundsInt>();
		allBounds = list;
		List<BoundsInt> list2 = allBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v5+18]");
		if (num >= 0)
		{
			object obj2 = default(object);
			list2.AddWithResize((BoundsInt)(&obj2));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
			object obj4 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
			object obj5 = 0 + obj4;
			_ = cellBounds.m_Position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v11 (UnityEngine.BoundsInt)+10]");
			_ = 0;
		}
		hash = (Hash128)CalculateHash(tilemap).u64_0;
	}

	public unsafe void Setup(PhaserTilemap from)
	{
		//IL_00bb: Expected O, but got I
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0134: Expected O, but got I4
		//IL_0152: Expected O, but got I
		//IL_0163: Expected O, but got I
		//IL_0178: Expected I, but got O
		//IL_116d: Expected O, but got I
		//IL_1184: Expected O, but got I
		//IL_01c6: Expected O, but got Ref
		//IL_01ee: Expected O, but got Ref
		//IL_0efe: Expected I, but got O
		//IL_0f14: Expected O, but got I
		//IL_0270: Expected O, but got I4
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_071e: Expected O, but got Unknown
		//IL_0739: Expected O, but got I8
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected O, but got Unknown
		//IL_02a3: Expected O, but got I4
		//IL_0783: Expected O, but got I
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Expected O, but got Unknown
		//IL_11dc: Expected O, but got I4
		//IL_11ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f1: Expected O, but got Unknown
		//IL_0c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c49: Expected O, but got Unknown
		//IL_0c61: Expected I, but got O
		//IL_0249: Expected O, but got I
		//IL_0253: Expected O, but got I4
		//IL_1014: Expected O, but got I8
		//IL_0816: Expected O, but got I
		//IL_0fe0: Expected O, but got I4
		//IL_07e3: Expected O, but got I8
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_037b: Expected O, but got I
		//IL_08fb: Expected I, but got O
		//IL_0900: Expected I, but got O
		//IL_03b6: Expected O, but got I
		//IL_03cf: Expected O, but got I
		//IL_03d8: Expected O, but got I4
		//IL_03e1: Expected O, but got I4
		//IL_03ea: Expected O, but got I4
		//IL_03fa: Expected O, but got I
		//IL_040a: Expected O, but got I
		//IL_0413: Expected O, but got Ref
		//IL_0423: Expected O, but got I
		//IL_0433: Expected O, but got I
		//IL_06da: Expected O, but got Ref
		//IL_06f3: Expected O, but got Ref
		//IL_0bc4: Expected O, but got I8
		//IL_112a: Expected O, but got I4
		//IL_1106: Expected O, but got I4
		//IL_0e98: Expected I4, but got O
		//IL_0db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db6: Expected O, but got Unknown
		//IL_0dcc: Expected O, but got I4
		//IL_0b56: Expected I4, but got O
		//IL_09ad: Expected O, but got I
		//IL_109f: Expected I, but got O
		//IL_06b3: Expected I4, but got O
		//IL_0d14: Expected O, but got Ref
		//IL_0d48: Expected O, but got I
		//IL_0d51: Expected O, but got I4
		//IL_0d5a: Expected O, but got I4
		//IL_0d6a: Expected O, but got I
		//IL_0d7a: Expected O, but got I
		//IL_0d83: Expected O, but got Ref
		//IL_0d93: Expected O, but got I
		//IL_0da3: Expected O, but got I
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected O, but got Unknown
		//IL_09e6: Expected O, but got Ref
		//IL_04c7: Expected O, but got Ref
		//IL_04d9: Expected O, but got I4
		//IL_04f4: Expected O, but got I4
		//IL_0545: Expected I4, but got O
		//IL_0538: Expected I4, but got O
		//IL_0e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e07: Expected O, but got Unknown
		//IL_0e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e25: Expected O, but got Unknown
		//IL_0a6a: Expected O, but got I4
		//IL_0a6e: Expected O, but got I4
		//IL_0ac3: Expected O, but got I
		//IL_0ad0: Expected O, but got Ref
		//IL_0ad5: Expected I, but got O
		//IL_0e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4f: Expected O, but got Unknown
		//IL_0e57: Expected I4, but got O
		_003C_003Ec__DisplayClass7_0 obj = new _003C_003Ec__DisplayClass7_0();
		Tilemap tilemap;
		Tilemap tilemap2;
		if ((object)from != null)
		{
			tilemap = from._layer;
			if ((object)from._layer != null)
			{
				bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr != (IntPtr)0;
				tilemap2 = from._layer;
				if (flag)
				{
					goto IL_009e;
				}
			}
			Tilemap component = from.GetComponent<Tilemap>();
			bool flag2 = (object)component == null;
			tilemap2 = component;
			tilemap = component;
			if (!flag2)
			{
				goto IL_009e;
			}
		}
		goto IL_0bc5;
		IL_009e:
		BoundsInt cellBounds = tilemap.cellBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v32 (UnityEngine.BoundsInt)+10]");
		Vector3Int vector3Int = (Vector3Int)0;
		if (obj != null)
		{
			obj.bounds = (BoundsInt)cellBounds.m_Position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v32 (UnityEngine.BoundsInt)+10]");
			_ = 0;
			List<BoundsInt> list = new List<BoundsInt>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (PhaserTilemapBoundingBoxesAsset+<>c__DisplayClass7_0)+1C]");
			TileBase[] array = new TileBase[0];
			_003C_003Ec obj2 = (_003C_003Ec)(obj + 16);
			Vector3 val = (Vector3)0;
			_003C_003Ec__DisplayClass7_0 obj3 = obj;
			List<BoundsInt> list2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
			Vector3Int vector3Int2 = (Vector3Int)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (PhaserTilemapBoundingBoxesAsset+<>c__DisplayClass7_0)+1C]");
			BoundsInt x = (BoundsInt)0;
			List<BoundsInt> list3 = list;
			TileBase[] array2 = array;
			nint num = unchecked((nint)null);
			int num5 = default(int);
			object arg = default(object);
			object arg2 = default(object);
			int num16 = default(int);
			Vector3Int vector3Int6 = default(Vector3Int);
			Vector3Int vector3Int14 = default(Vector3Int);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ rdi_v11 (PhaserTilemapBoundingBoxesAsset+<>c__DisplayClass7_0)+1C]");
				Vector3Int vector3Int3 = (Vector3Int)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ rdi_v11 (PhaserTilemapBoundingBoxesAsset+<>c__DisplayClass7_0)+1C]");
				object obj4 = (nint)0 >> 32;
				int num2;
				int tilesBlockNonAlloc;
				Vector3 vector;
				if (num < (nint)obj4)
				{
					num2 = obj2._003CSetup_003Eb__7_1(x);
					int num3 = obj2._003CSetup_003Eb__7_1(x);
					int num4 = obj2._003CSetup_003Eb__7_1(x);
					tilesBlockNonAlloc = tilemap2.GetTilesBlockNonAlloc((BoundsInt)(&num5), array2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (PhaserTilemapBoundingBoxesAsset+<>c__DisplayClass7_0)+1C]");
					bool flag3 = (nint)tilesBlockNonAlloc == 0;
					x = (BoundsInt)(&num5);
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						string message = $"Missing tile bounds {arg} vs {arg2}";
						Debug.LogWarning(message);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (PhaserTilemapBoundingBoxesAsset+<>c__DisplayClass7_0)+1C]");
						Vector3Int vector3Int4 = (Vector3Int)0;
						x = (BoundsInt)0;
					}
					bool flag4 = array2 == null;
					vector = (Vector3)0;
					if (flag4)
					{
						break;
					}
					while (true)
					{
						bool flag5 = (nint)vector >= array2.Length;
						num5 = num2;
						vector3Int = (Vector3Int)1;
						if (flag5)
						{
							break;
						}
						if ((nint)vector < array2.Length)
						{
							TileBase tileBase = array2[(object)vector];
							if ((object)array2[(object)vector] == null || ((UnityEngine.Object)tileBase).m_CachedPtr == (IntPtr)0)
							{
								vector++;
								continue;
							}
							goto IL_032f;
						}
						goto IL_0c66;
					}
					goto IL_0c3b;
				}
				Func<BoundsInt, bool> predicate = _003C_003Ec._003C_003E9__7_0;
				if (_003C_003Ec._003C_003E9__7_0 == null)
				{
					Func<BoundsInt, bool> func = null;
					bool flag6 = ((_003C_003Ec)(object)func)._003CSetup_003Eb__7_0((BoundsInt)_003C_003Ec._003C_003E9);
					_003C_003Ec._003C_003E9__7_0 = func;
					nint num6 = (nint)typeof(_003C_003Ec);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1311 @ rax_v151 (Il2CppClass<PhaserTilemapBoundingBoxesAsset+<>c>)+B8]");
					object obj5 = (nint)0 + (nint)8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag7 = (nint)0 == 0;
					predicate = func;
					if (!flag7)
					{
						object obj6 = obj5 >> 12;
						object obj7 = obj6 & 0x1FFFFF;
						object obj8 = obj7 >> 6;
						object obj9 = 6603577472L;
						object obj10 = obj7 & 0x3F;
						nint num8;
						do
						{
							object obj11 = 1 << (int)obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ r12_v14+462E0+v1342 @ rdx_v60*8]");
							object obj12 = 0 | obj11;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ r12_v14+462E0+v1342 @ rdx_v60*8]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ r12_v14+462E0+v1342 @ rdx_v60*8]");
							if (num7 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ r12_v14+462E0+v1342 @ rdx_v60*8]");
							num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ r12_v14+462E0+v1342 @ rdx_v60*8]");
						}
						while (num8 != 0);
						predicate = func;
					}
				}
				IEnumerable<BoundsInt> enumerable = Enumerable.Where(list3, predicate);
				Func<BoundsInt, int> func2 = _003C_003Ec._003C_003E9__7_1;
				if (_003C_003Ec._003C_003E9__7_1 != null)
				{
					goto IL_0832;
				}
				Func<BoundsInt, int> func3 = null;
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ r9_v24 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				_ = _003C_003Ec._003C_003E9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ r9_v24 (Il2CppMethodInfo)+4C]");
				object obj13 = (nint)0 >> 4;
				object obj14 = obj13 & 1;
				object obj15;
				if (obj14 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ r9_v24 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 1)
					{
						obj15 = 6447980672L;
						goto IL_0fd7;
					}
				}
				else if (_003C_003Ec._003C_003E9 == null)
				{
					int num10 = ((_003C_003Ec)null)._003CSetup_003Eb__7_1((BoundsInt)6570564832L);
					throw num10;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1703 @ rax_v122 (System.Func`2<UnityEngine.BoundsInt, System.Int32>)+10]");
				obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1703 @ rax_v122 (System.Func`2<UnityEngine.BoundsInt, System.Int32>)+20]");
				_ = 0;
				goto IL_0fd7;
				IL_06b8:
				list3 = list;
				array2 = array;
				goto IL_0c9d;
				IL_0c66:
				throw new IndexOutOfRangeException();
				IL_0832:
				IEnumerable<BoundsInt> enumerable2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A8DE30");
				if (enumerable2 != null)
				{
					List<BoundsInt> list4 = new List<BoundsInt>(enumerable2);
					if ((object)this == null)
					{
						break;
					}
					allBounds = list4;
					if (allBounds != null)
					{
						List<BoundsInt> list5 = new List<BoundsInt>(allBounds);
						obj.i = 0;
						nint num11 = unchecked((nint)null);
						nint num12 = unchecked((nint)null);
						List<BoundsInt> list6 = list5;
						Tilemap tilemap3 = tilemap2;
						_003C_003Ec__DisplayClass7_0 obj16 = obj;
						while (true)
						{
							if (obj16.i < 3)
							{
								_003C_003Ec__DisplayClass7_1 obj17 = new _003C_003Ec__DisplayClass7_1();
								if (obj17 == null)
								{
									break;
								}
								obj17.CS_0024_003C_003E8__locals1 = obj16;
								obj17.j = 1;
								while (true)
								{
									bool flag8 = obj17.j >= 3;
									Vector3Int vector3Int5 = (Vector3Int)num5;
									if (flag8)
									{
										break;
									}
									while (true)
									{
										Func<BoundsInt, (int, int, int)> func4 = null;
										int num13 = ((_003C_003Ec)(object)func4)._003CSetup_003Eb__7_1((BoundsInt)obj17);
										IEnumerable<BoundsInt> enumerable3 = (IEnumerable<BoundsInt>)((_003C_003Ec)(object)list6)._003CSetup_003Eb__7_1((BoundsInt)func4);
										Func<IGrouping<(int, int, int), BoundsInt>, bool> predicate2 = _003C_003Ec._003C_003E9__7_3;
										if (_003C_003Ec._003C_003E9__7_3 == null)
										{
											Func<IGrouping<(int, int, int), BoundsInt>, bool> func5 = (_003C_003Ec._003C_003E9__7_3 = delegate(IGrouping<(int, int, int), BoundsInt> source)
											{
												//IL_0020: Expected O, but got I4
												//IL_0036: Unknown result type (might be due to invalid IL or missing references)
												//IL_003b: Expected I4, but got Unknown
												int num22 = Enumerable.Count(source);
												object obj25 = num22 - 1;
												int num23 = num22 ^ 1;
												int num24 = num22 ^ obj25;
												int num25 = num23 & num24;
												bool flag17 = num25 < 0;
												bool flag18 = (nint)obj25 < 0;
												bool flag19 = obj25 == null;
												bool flag20 = flag18 == flag17;
												bool flag21 = !flag19;
												return flag21 & flag20;
											});
											num12 = unchecked((nint)null);
											predicate2 = func5;
										}
										if (!Enumerable.Any((IEnumerable<IGrouping<(int, int, int), BoundsInt>>)enumerable3, predicate2))
										{
											break;
										}
										List<BoundsInt> list7 = null;
										bool flag9 = Enumerable.Any((IEnumerable<IGrouping<(int, int, int), BoundsInt>>)list7, (Func<IGrouping<(int, int, int), BoundsInt>, bool>)0);
										if (enumerable3 == null)
										{
											goto end_IL_1138;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
										object obj18 = (object)(&num11);
										while (true)
										{
											if (num11 != 0)
											{
												if (((_003C_003Ec)null)._003CSetup_003Eb__7_1((BoundsInt)typeof(IEnumerator)) == 0)
												{
													break;
												}
												bool flag10 = num11 == 0;
												int num14 = 0;
												if (!flag10)
												{
													int num15 = ((_003C_003Ec)null)._003CSetup_003Eb__7_1((BoundsInt)typeof(IEnumerator<IGrouping<(int, int, int), BoundsInt>>));
													List<BoundsInt> nextGroup = (List<BoundsInt>)((_003C_003Ec)num15)._003CSetup_003Eb__7_1((BoundsInt)typeof(IEnumerator<IGrouping<(int, int, int), BoundsInt>>));
													BoundsInt boundsInt = CombineBounds(nextGroup);
													bool flag11 = list7 == null;
													num14 = (int)(&num16);
													if (!flag11)
													{
														vector3Int3 = boundsInt.m_Position;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rax_v93 (UnityEngine.BoundsInt)+10]");
														vector3Int = (Vector3Int)0;
														list7.Add((BoundsInt)(&vector3Int6));
														num12 = unchecked((nint)null);
														vector3Int5 = boundsInt.m_Position;
														continue;
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										if (obj18 != null)
										{
											int num17 = ((_003C_003Ec)null)._003CSetup_003Eb__7_1((BoundsInt)typeof(IDisposable));
										}
										list6 = list7;
									}
									int j = obj17.j + 1;
									obj17.j = j;
									num5 = (int)vector3Int5;
									tilemap3 = tilemap2;
								}
								int i = obj.i + 1;
								obj.i = i;
								tilemap2 = tilemap3;
								obj16 = obj;
								continue;
							}
							allBounds = list6;
							this.hash = (Hash128)CalculateHash(tilemap3).u64_0;
							return;
							continue;
							end_IL_1138:
							break;
						}
						break;
					}
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				}
				Exception ex2 = System.Linq.Error.ArgumentNull("source");
				throw ex2;
				IL_0c3b:
				list2 = (List<BoundsInt>)(list2 + 1);
				num16 = num2;
				obj3 = obj;
				num = (nint)list2;
				continue;
				IL_032f:
				Hash128 hash = (Hash128)(this + 24);
				((Hash128*)hash)->Append(ref val);
				bool flag12 = tilesBlockNonAlloc <= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
				int num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
				vector3Int2 = (Vector3Int)0;
				vector3Int = (Vector3Int)list2;
				if (!flag12)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,0Ch\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
					Vector3Int vector3Int7 = (Vector3Int)0;
					num5 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
					Vector3Int vector3Int8 = (Vector3Int)0;
					Vector3Int vector3Int9 = (Vector3Int)0;
					object obj19 = 0;
					Vector3Int vector3Int10 = (Vector3Int)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
					vector3Int2 = (Vector3Int)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
					vector3Int = (Vector3Int)0;
					BoundsInt x2 = (BoundsInt)(&val);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
					Vector3Int vector3Int11 = (Vector3Int)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
					Vector3Int vector3Int12 = (Vector3Int)0;
					while ((nint)obj19 < array2.Length)
					{
						TileBase tileBase2 = array2[obj19];
						if ((object)array2[obj19] != null && ((UnityEngine.Object)tileBase2).m_CachedPtr != (IntPtr)0)
						{
							Vector3Int vector3Int13 = vector3Int11 + vector3Int12;
							if (System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int11) <= System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int13))
							{
								vector3Int13 = vector3Int11;
							}
							if ((nint)vector3Int13 != 9999)
							{
								int num19 = ((_003C_003Ec)(&vector3Int2))._003CSetup_003Eb__7_1(x2);
								object obj20 = num19 + 1;
								vector3Int12 = (Vector3Int)(obj20 - (object)vector3Int2);
								object obj21 = tilesBlockNonAlloc - 1;
								if (obj19 == obj21)
								{
									if (list == null)
									{
										goto end_IL_115d;
									}
									num5 = (int)vector3Int2;
									goto IL_0d07;
								}
								num18 = (int)vector3Int2;
								vector3Int8 = vector3Int14;
								vector3Int9 = vector3Int10;
								vector3Int11 = vector3Int2;
							}
							else
							{
								int num20 = obj2._003CSetup_003Eb__7_1(x2);
								Vector3Int vector3Int15 = (Vector3Int)(obj19 + num20);
								Vector3Int vector3Int16 = vector3Int11 + vector3Int12;
								bool flag13 = System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int11) < System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int16);
								Vector3Int vector3Int17 = vector3Int16;
								if (!flag13)
								{
									vector3Int17 = vector3Int11;
								}
								if (System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int15) <= System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int17))
								{
									vector3Int17 = vector3Int15;
								}
								object obj22 = vector3Int17 - vector3Int15;
								vector3Int12 = (Vector3Int)(obj22 + 1);
								int num21 = obj2._003CSetup_003Eb__7_1(x2);
								vector3Int14 = (Vector3Int)(num21 + list2);
								Vector3Int vector3Int18 = vector3Int9 + vector3Int8;
								bool flag14 = System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int8) < System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int18);
								Vector3Int vector3Int19 = vector3Int18;
								if (!flag14)
								{
									vector3Int19 = vector3Int8;
								}
								if (System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int14) <= System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int19))
								{
									vector3Int19 = vector3Int14;
								}
								object obj23 = vector3Int19 - vector3Int14;
								vector3Int9 = (Vector3Int)(obj23 + 1);
								num18 = (int)vector3Int15;
								vector3Int8 = vector3Int14;
								vector3Int10 = vector3Int9;
								vector3Int2 = vector3Int15;
								vector3Int11 = vector3Int15;
							}
						}
						else
						{
							Vector3Int vector3Int20 = vector3Int11 + vector3Int12;
							if (System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int11) <= System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int20))
							{
								vector3Int20 = vector3Int11;
							}
							bool flag15 = (nint)vector3Int20 == 9999;
							num18 = (int)vector3Int7;
							if (!flag15)
							{
								if (list == null)
								{
									goto end_IL_115d;
								}
								num5 = (int)vector3Int7;
								goto IL_0d07;
							}
						}
						goto IL_0da8;
						IL_0da8:
						obj19++;
						bool flag16 = (nint)obj19 < tilesBlockNonAlloc;
						vector3Int7 = (Vector3Int)num18;
						array2 = array;
						if (flag16)
						{
							continue;
						}
						goto IL_06b8;
						IL_0d07:
						list.Add((BoundsInt)(&num5));
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,4\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,0Ch\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
						num18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
						vector3Int8 = (Vector3Int)0;
						vector3Int9 = (Vector3Int)0;
						vector3Int10 = (Vector3Int)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
						vector3Int2 = (Vector3Int)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
						vector3Int = (Vector3Int)0;
						x2 = (BoundsInt)(&num5);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
						vector3Int11 = (Vector3Int)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11920]");
						vector3Int12 = (Vector3Int)0;
						goto IL_0da8;
					}
					goto IL_0c66;
				}
				goto IL_0c9d;
				IL_0c9d:
				if (list3 == null)
				{
					break;
				}
				list3.Add((BoundsInt)(&num5));
				val = vector;
				num5 = num18;
				x = (BoundsInt)(&num5);
				goto IL_0c3b;
				IL_0fd7:
				object obj24 = 24;
				_ = 6447983488L;
				_003C_003Ec._003C_003E9__7_1 = func3;
				func2 = func3;
				goto IL_0832;
				continue;
				end_IL_115d:
				break;
			}
		}
		goto IL_0bc5;
		IL_0bc5:
		throw new NullReferenceException();
	}

	public unsafe void CombineTiles(BoundCombine combineInstance)
	{
		//IL_010f: Expected O, but got Ref
		//IL_010f: Expected O, but got Ref
		//IL_0159: Expected O, but got I
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_01ef: Expected O, but got I
		//IL_024a: Expected O, but got I
		//IL_024a: Expected O, but got I
		List<BoundsInt> list = allBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
		if ((nint)combineInstance < 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
			int num = default(int);
			if ((nint)num < (nint)0 && (nint)combineInstance >= 0 && num >= 0 && (nint)combineInstance != num)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
				if ((nint)combineInstance < 0)
				{
					List<BoundsInt> list2 = allBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v7 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
					if ((nint)num < (nint)0)
					{
						object obj = default(object);
						object obj2 = default(object);
						BoundsInt boundsInt = Combine((BoundsInt)(&obj), (BoundsInt)(&obj2));
						List<BoundsInt> list3 = allBounds;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
						if ((nint)combineInstance < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
							object obj3 = 0;
							object obj4 = combineInstance * 2;
							object obj5 = (object)combineInstance + obj4;
							_ = boundsInt.m_Position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v14 (UnityEngine.BoundsInt)+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+1C]");
							_ = (nint)0 + (nint)1;
							List<BoundsInt> list4 = allBounds;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v7 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
							if ((nint)num < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v7 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
								object obj6 = -1;
								if (num < (nint)obj6)
								{
									int sourceIndex = num + 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v7 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v7 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
									int length = default(int);
									Array.Copy((Array)num2, sourceIndex, (Array)0, num, length);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v7 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+1C]");
								_ = (nint)0 + (nint)1;
								return;
							}
						}
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		Debug.LogError("Combine indices not valid");
	}

	private unsafe int NumCombinable(List<BoundsInt> nextGroup)
	{
		//IL_003d: Expected O, but got I
		//IL_005f: Expected O, but got I4
		//IL_03a7: Expected O, but got I
		//IL_009b: Expected O, but got I
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_0148: Expected O, but got I
		//IL_0171: Expected O, but got I
		//IL_0261: Expected O, but got Ref
		//IL_0261: Expected O, but got Ref
		//IL_029c: Expected O, but got I
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		//IL_032b: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_01d7: Expected O, but got I
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_020f: Expected O, but got I
		//IL_0238: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,4\"");
			int num = 0;
			object obj2 = 1;
			object obj16 = default(object);
			object obj17 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
				object obj3 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
					object obj5 = 0;
					object obj6 = obj2 * 2;
					object obj7 = obj2 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+20+v441 @ rcx_v8*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+30+v441 @ rcx_v8*8]");
					object obj8 = num2 + 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+20+v441 @ rcx_v8*8]");
					bool flag = 0 <= (nint)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+20+v441 @ rcx_v8*8]");
					object obj9 = 0;
					if (!flag)
					{
						obj9 = obj8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+30]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+20]");
					object obj10 = num3 + 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+20]");
					bool flag2 = 0 >= (nint)obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+20]");
					object obj11 = 0;
					if (!flag2)
					{
						obj11 = obj10;
					}
					if (obj9 != obj11)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+20+v441 @ rcx_v8*8]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+30+v441 @ rcx_v8*8]");
						object obj12 = num4 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+20+v441 @ rcx_v8*8]");
						bool flag3 = 0 >= (nint)obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5+20+v441 @ rcx_v8*8]");
						object obj13 = 0;
						if (!flag3)
						{
							obj13 = obj12;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+30]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+20]");
						object obj14 = num5 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+20]");
						bool flag4 = 0 <= (nint)obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+20]");
						object obj15 = 0;
						if (!flag4)
						{
							obj15 = obj14;
						}
						if (obj13 != obj15)
						{
							goto IL_03d0;
						}
					}
					BoundsInt boundsInt = Combine((BoundsInt)(&obj16), (BoundsInt)(&obj17));
					object obj18 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
					if ((nint)obj18 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
					object obj19 = 0;
					object obj20 = obj2 * 2;
					object obj21 = obj2 + obj20;
					_ = boundsInt.m_Position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v23 (UnityEngine.BoundsInt)+10]");
					_ = 0;
					object obj22 = obj2 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ rdx (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047F780");
					num++;
					obj2--;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8+20]");
					obj17 = 0;
					goto IL_03d0;
				}
				return num;
				IL_03d0:
				obj2++;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	private unsafe BoundsInt CombineBoundsY(List<BoundsInt> nextGroup)
	{
		//IL_02c7: Expected O, but got I4
		//IL_02c2: Expected native int or pointer, but got O
		//IL_003d: Expected O, but got I
		//IL_0052: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_0062: Expected native int or pointer, but got O
		//IL_0085: Expected O, but got I4
		//IL_0365: Expected O, but got I
		//IL_00c1: Expected O, but got I
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_010d: Expected O, but got I
		//IL_0136: Expected O, but got I
		//IL_0394: Expected O, but got I
		//IL_0303: Expected O, but got I
		//IL_01dd: Expected O, but got Ref
		//IL_01dd: Expected O, but got Ref
		//IL_0218: Expected O, but got I
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0252: Expected O, but got I
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_0180: Expected O, but got I
		//IL_01b3: Expected O, but got I
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		BoundsInt boundsInt = default(BoundsInt);
		((BoundsInt*)(nint)boundsInt)->m_Position = (Vector3Int)0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v9+20]");
			Vector3Int vector3Int = (Vector3Int)0;
			BoundsInt boundsInt2 = boundsInt;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v9+20]");
			((BoundsInt*)(nint)boundsInt2)->m_Position = (Vector3Int)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v9+30]");
			_ = 0;
			List<BoundsInt> list = nextGroup;
			object obj2 = 1;
			object obj14 = default(object);
			object obj15 = default(object);
			Vector3Int position = default(Vector3Int);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
				object obj3 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
					object obj5 = 0;
					object obj6 = obj2 * 2;
					object obj7 = obj2 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+30+v423 @ rcx_v8*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+20+v423 @ rcx_v8*8]");
					object obj8 = num + 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+20+v423 @ rcx_v8*8]");
					bool flag = 0 <= (nint)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+20+v423 @ rcx_v8*8]");
					object obj9 = 0;
					if (!flag)
					{
						obj9 = obj8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.BoundsInt)+4]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.BoundsInt)+4]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.BoundsInt)+10]");
					object obj11 = num2 + 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.BoundsInt)+4]");
					if (0 < (nint)obj11)
					{
						obj10 = obj11;
					}
					if (obj9 != obj10)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+30+v423 @ rcx_v8*8]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+20+v423 @ rcx_v8*8]");
						object obj12 = num3 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850039F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+20+v423 @ rcx_v8*8]");
						bool flag2 = 0 >= (nint)obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5+20+v423 @ rcx_v8*8]");
						object obj13 = 0;
						if (!flag2)
						{
							obj13 = obj12;
						}
						if (obj13 != obj14)
						{
							goto IL_03b5;
						}
					}
					BoundsInt boundsInt3 = Combine((BoundsInt)(&obj15), (BoundsInt)(&position));
					object obj16 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
					if ((nint)obj16 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
					object obj17 = 0;
					object obj18 = obj2 * 2;
					object obj19 = obj2 + obj18;
					_ = boundsInt3.m_Position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v25 (UnityEngine.BoundsInt)+10]");
					vector3Int = (Vector3Int)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v25 (UnityEngine.BoundsInt)+10]");
					_ = 0;
					object obj20 = obj2 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047F780");
					obj2--;
					position = boundsInt.m_Position;
					list = (List<BoundsInt>)boundsInt3;
					goto IL_03b5;
				}
				return boundsInt;
				IL_03b5:
				obj2++;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		BoundsInt result = default(BoundsInt);
		return result;
	}

	private unsafe BoundsInt CombineBounds(List<BoundsInt> nextGroup)
	{
		//IL_00f6: Expected O, but got I4
		//IL_00f1: Expected native int or pointer, but got O
		//IL_003d: Expected O, but got I
		//IL_0052: Expected O, but got I
		//IL_0062: Expected O, but got I
		//IL_006b: Expected O, but got I4
		//IL_0113: Expected native int or pointer, but got O
		//IL_00af: Expected O, but got Ref
		//IL_00af: Expected O, but got Ref
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00de: Expected O, but got I
		BoundsInt boundsInt = default(BoundsInt);
		((BoundsInt*)(nint)boundsInt)->m_Position = (Vector3Int)0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v9+20]");
			Vector3Int position = (Vector3Int)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v9+30]");
			object obj2 = 0;
			object obj3 = 1;
			Vector3Int vector3Int = default(Vector3Int);
			object obj6 = default(object);
			while (true)
			{
				((BoundsInt*)(nint)boundsInt)->m_Position = position;
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
				if ((nint)obj4 < 0)
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [nextGroup @ r8 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
					if ((nint)obj5 >= 0)
					{
						break;
					}
					BoundsInt boundsInt2 = Combine((BoundsInt)(&vector3Int), (BoundsInt)(&obj6));
					obj3++;
					position = boundsInt2.m_Position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v14 (UnityEngine.BoundsInt)+10]");
					obj2 = 0;
					continue;
				}
				return boundsInt;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		BoundsInt result = default(BoundsInt);
		return result;
	}

	private unsafe BoundsInt Combine(BoundsInt i1, BoundsInt i2)
	{
		//IL_021f: Expected O, but got I
		//IL_013a: Expected O, but got I
		//IL_0171: Expected O, but got I
		//IL_0060: Expected O, but got I
		//IL_0271: Expected O, but got I
		//IL_01af: Expected O, but got I
		//IL_01e6: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_01f3: Expected native int or pointer, but got O
		//IL_0296: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
		Vector3Int vector3Int = default(Vector3Int);
		Vector3Int vector3Int2 = default(Vector3Int);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int) > System.Runtime.CompilerServices.Unsafe.As<Vector3Int, UIntPtr>(ref vector3Int2);
		Vector3Int vector3Int3 = vector3Int2;
		if (!flag)
		{
			vector3Int3 = vector3Int;
		}
		object obj5 = default(object);
		object obj6 = default(object);
		object obj7 = default(object);
		object obj8;
		object obj10;
		BoundsInt boundsInt = default(BoundsInt);
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+4]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+4]");
			object obj2 = num + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+4]");
			if (0 > (nint)obj2)
			{
				obj = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+4]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+10]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+4]");
			object obj4 = num2 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+4]");
			if (0 > (nint)obj4)
			{
				obj3 = obj4;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004030");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004030");
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
				obj7 = obj6;
				if (!flag2)
				{
					obj7 = obj5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+4]");
			obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+10]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+4]");
			object obj9 = num3 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i1 @ r8 (UnityEngine.BoundsInt)+4]");
			if (0 < (nint)obj9)
			{
				obj8 = obj9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+4]");
			obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+10]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+4]");
			object obj11 = num4 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [i2 @ r9 (UnityEngine.BoundsInt)+4]");
			if (0 < (nint)obj11)
			{
				obj10 = obj11;
			}
			((BoundsInt*)(nint)boundsInt)->m_Position = vector3Int3;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10));
		_ = 0;
		Vector3Int size = (Vector3Int)(obj7 - (object)vector3Int3);
		((BoundsInt*)(nint)boundsInt)->m_Size = size;
		_ = 1;
		return boundsInt;
	}

	public PhaserTilemapBoundingBoxesAsset()
	{
		List<BoundsInt> list = new List<BoundsInt>();
		allBounds = list;
		base._002Ector();
	}
}
