using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PhaserTile : ArcadeColliderType
{
	public int2 position;

	public int _data;

	private const int cFaceTop = 1;

	private const int cFaceBottom = 2;

	private const int cFaceLeft = 4;

	private const int cFaceRight = 8;

	public const int All = 15;

	public const int None = 0;

	public bool faceLeft
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 4;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 4;
			int num = _data & -5;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public bool faceRight
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 8;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 8;
			int num = _data & -9;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public bool faceTop
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 1;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 1;
			int num = _data & -2;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public bool faceBottom
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			int num = _data & 2;
			bool flag = num == 0;
			return !flag;
		}
		set
		{
			int data = _data | 2;
			int num = _data & -3;
			if (!value)
			{
				data = num;
			}
			_data = data;
		}
	}

	public bool collideLeft
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			return true;
		}
	}

	public bool collideRight
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			return true;
		}
	}

	public bool collideUp
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			return true;
		}
	}

	public bool collideDown
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			return true;
		}
	}

	public bool isParent => false;

	public BaseBody body => null;

	public bool isTilemap => false;

	public GameObject gameObject => null;

	[MethodImpl((MethodImplOptions)256)]
	public PhaserTile(int x, int y)
	{
		//IL_000a: Expected O, but got I4
		position = (int2)x;
		_data = 15;
	}

	private unsafe bool isTileEmpty(Tilemap tiles, int x, int y, BoundsInt bounds)
	{
		//IL_0012: Expected O, but got Ref
		//IL_0041: Expected I, but got O
		//IL_0049: Expected I, but got O
		//IL_0059: Expected O, but got I
		//IL_00d9: Expected O, but got I4
		//IL_0095: Expected O, but got I
		//IL_00cb: Expected O, but got I4
		//IL_01a3: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850039F0");
		object obj = default(object);
		TileBase tile = tiles.GetTile((Vector3Int)(&obj));
		if ((object)tile == null)
		{
			goto IL_0148;
		}
		nint num = (nint)typeof(SuperTile);
		nint num2 = (nint)tile;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v6 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r9_v4 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v6 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r9_v4 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v17+FFFFFFF8+v105 @ rcx_v8*8]");
			if (0 == (nint)typeof(SuperTile))
			{
				obj4 = 1;
				goto IL_0173;
			}
		}
		obj4 = 0;
		goto IL_0173;
		IL_0148:
		return true;
		IL_0173:
		bool flag = obj4 == null;
		SuperTile superTile = null;
		if (!flag)
		{
			superTile = (SuperTile)tile;
		}
		if ((object)superTile != null)
		{
			bool flag2 = SuperTileExtensions.TryGetProperty(superTile, "collides", out var _);
			if (flag2)
			{
				SuperTile superTile2 = null;
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		}
		goto IL_0148;
	}

	[MethodImpl((MethodImplOptions)256)]
	private bool isPhaserTileEmpty(PhaserTile[] tiles, int x, int y, BoundsInt layerBounds, BoundsInt mapBounds)
	{
		//IL_0016: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_0042: Expected O, but got I
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_011f: Expected O, but got I
		//IL_0287: Expected I4, but got O
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_30+C]");
		object obj = (nint)0 >> 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_30+4]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_30+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_30+4]");
		object obj3 = num + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_30+4]");
		if (0 > (nint)obj3)
		{
			obj2 = obj3;
		}
		object obj4 = obj - obj2;
		object obj5 = obj4 + y;
		object obj6 = obj5 % obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_30+C]");
		object obj8 = default(object);
		object obj7 = 0 - obj8;
		object obj9 = obj7 + x;
		object obj10 = obj2 + obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ stack_30+C]");
		object obj11 = obj9 % 0;
		object obj12 = obj8 + obj11;
		object obj14 = default(object);
		object obj13 = obj14;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ stack_28+C]");
		object obj15 = 0 + obj14;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
		{
			obj13 = obj15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850039F0");
		object obj17 = default(object);
		object obj16 = obj10 - obj17;
		object obj18 = obj12 - obj13;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ stack_28+C]");
			if ((nint)obj18 < 0 && (nint)obj16 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ stack_28+C]");
				object obj19 = (nint)0 >> 32;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19))
				{
					if (tiles != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ stack_28+C]");
						object obj20 = 0 * obj16;
						object obj21 = obj20 + obj18;
						return tiles[obj21] == null;
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
		}
		return true;
	}

	public void updateTileFaces(PhaserTile[] tiles, BoundsInt layerBounds, BoundsInt mapBounds, bool isInverse)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected I4, but got Unknown
		//IL_0074: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_016d: Expected I4, but got O
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected I4, but got Unknown
		//IL_01cd: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_020c: Expected I4, but got O
		//IL_0258: Expected I4, but got O
		//IL_026c: Expected O, but got I4
		//IL_027c: Expected O, but got I4
		//IL_02ab: Expected I4, but got O
		//IL_02f7: Expected I4, but got O
		//IL_0114: Expected O, but got I4
		//IL_039c: Expected O, but got I4
		//IL_0441: Expected O, but got I4
		//IL_03ee: Expected O, but got I4
		_ = mapBounds.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mapBounds @ r9 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		int x = (int)(position - 1);
		_ = layerBounds.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [layerBounds @ r8 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTile)+14]");
		BoundsInt layerBounds2 = default(BoundsInt);
		BoundsInt mapBounds2 = default(BoundsInt);
		bool flag = isPhaserTileEmpty(tiles, x, 0, layerBounds2, mapBounds2);
		PhaserTile phaserTile = (PhaserTile)(_data | 4);
		PhaserTile phaserTile2 = (PhaserTile)(_data & -5);
		_ = mapBounds.m_Position;
		if (!flag)
		{
			phaserTile = phaserTile2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mapBounds @ r9 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		_data = (int)phaserTile;
		int x2 = (int)(position + 1);
		_ = layerBounds.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [layerBounds @ r8 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTile)+14]");
		bool flag2 = phaserTile2.isPhaserTileEmpty(tiles, x2, 0, layerBounds2, mapBounds2);
		PhaserTile phaserTile3 = (PhaserTile)(_data | 8);
		PhaserTile phaserTile4 = (PhaserTile)(_data & -9);
		_ = mapBounds.m_Position;
		if (!flag2)
		{
			phaserTile3 = phaserTile4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mapBounds @ r9 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		_data = (int)phaserTile3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTile)+14]");
		int y = (int)(-1);
		_ = layerBounds.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [layerBounds @ r8 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		bool flag3 = phaserTile4.isPhaserTileEmpty(tiles, (int)position, y, layerBounds2, mapBounds2);
		PhaserTile phaserTile5 = (PhaserTile)(_data | 1);
		PhaserTile phaserTile6 = (PhaserTile)(_data & -2);
		_ = mapBounds.m_Position;
		if (!flag3)
		{
			phaserTile5 = phaserTile6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mapBounds @ r9 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		_data = (int)phaserTile5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTile)+14]");
		int y2 = (int)((nint)0 + (nint)1);
		_ = layerBounds.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [layerBounds @ r8 (UnityEngine.BoundsInt)+10]");
		_ = 0;
		bool flag4 = phaserTile6.isPhaserTileEmpty(tiles, (int)position, y2, layerBounds2, mapBounds2);
		int num = _data | 2;
		int num2 = _data & -3;
		if (!flag4)
		{
			num = num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+30]");
		bool flag5 = (nint)0 == 0;
		_data = num;
		if (!flag5)
		{
			int num3 = num & -5;
			int num4 = num | 4;
			int num5 = num & 8;
			bool flag6 = num5 == 0;
			object obj = !flag6;
			if (obj == null)
			{
				num4 = num3;
			}
			int num6 = num4 | 8;
			int num7 = num4 & -9;
			int num8 = num & 4;
			bool flag7 = num8 == 0;
			object obj2 = !flag7;
			if (obj2 == null)
			{
				num6 = num7;
			}
			int num9 = num6 & -2;
			int num10 = num6 | 1;
			int num11 = num6 & 2;
			bool flag8 = num11 == 0;
			object obj3 = !flag8;
			if (obj3 == null)
			{
				num10 = num9;
			}
			int data = num10 | 2;
			int num12 = num10 & -3;
			int num13 = num6 & 1;
			bool flag9 = num13 == 0;
			object obj4 = !flag9;
			if (obj4 == null)
			{
				data = num12;
			}
			_data = data;
		}
	}

	public unsafe void drawDebug(PhaserTilemap layer)
	{
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_039b: Expected O, but got I4
		//IL_045c: Expected O, but got I4
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_01b0: Expected O, but got I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_023c: Expected O, but got I4
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_030a->IL0295: Incompatible stack heights: 1 vs 0
		//IL_0068->IL0295: Incompatible stack heights: 1 vs 0
		//IL_03b8->IL0295: Incompatible stack heights: 2 vs 0
		if ((object)layer != null)
		{
			Tilemap layer2 = layer._layer;
			if ((object)layer._layer != null)
			{
				bool flag = ((UnityEngine.Object)layer2).m_CachedPtr == (IntPtr)0;
				int2 cellPosition = default(int2);
				double ret;
				GridLayout.CellToWorld_Injected(((UnityEngine.Object)layer2).m_CachedPtr, ref *(Vector3Int*)(&cellPosition), out *(Vector3*)(&ret));
				if ((object)layer._layer != null)
				{
					Transform transform = layer._layer.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&cellPosition));
						Tilemap layer3 = layer._layer;
						bool flag3 = 0 < (nint)cellPosition;
						object obj = 0 - cellPosition;
						bool flag4 = obj == null;
						bool flag5 = !flag3;
						bool flag6 = !flag4;
						object obj2 = flag6 & flag5;
						if ((object)layer._layer != null)
						{
							bool flag7 = ((UnityEngine.Object)layer3).m_CachedPtr == (IntPtr)0;
							GridLayout.get_cellSize_Injected(((UnityEngine.Object)layer3).m_CachedPtr, out Vector3 _);
							if (obj2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,xmm9\"");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,xmm0\"");
							}
							int num = _data & 4;
							bool flag8 = num == 0;
							bool flag9 = num < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm7,xmm0\"");
							bool flag10 = !flag9;
							object obj3 = !flag10;
							object obj4 = obj3 | flag8;
							double num2 = default(double);
							if (obj4 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm3,xmm8\"");
								VSDebug.DrawDebugLine(ret, num2, ret, num2);
							}
							int num3 = _data & 8;
							bool flag11 = num3 == 0;
							bool flag12 = num3 < 0;
							bool flag13 = !flag12;
							object obj5 = !flag13;
							object obj6 = obj5 | flag11;
							if (obj6 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm3,xmm8\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,xmm9\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm9\"");
								VSDebug.DrawDebugLine(ret, num2, ret, num2);
							}
							int num4 = _data & 1;
							bool flag14 = num4 == 0;
							bool flag15 = num4 < 0;
							bool flag16 = !flag15;
							object obj7 = !flag16;
							object obj8 = obj7 | flag14;
							if (obj8 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,xmm9\"");
								VSDebug.DrawDebugLine(ret, num2, ret, num2);
							}
							int num5 = _data & 2;
							bool flag17 = num5 == 0;
							bool flag18 = num5 < 0;
							bool flag19 = !flag18;
							object obj9 = !flag19;
							object obj10 = obj9 | flag17;
							if (obj10 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,xmm8\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm3,xmm8\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,xmm9\"");
								VSDebug.DrawDebugLine(ret, num2, ret, num2);
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
