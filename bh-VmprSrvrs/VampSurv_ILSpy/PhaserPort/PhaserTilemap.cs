using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Tilemaps;

public class PhaserTilemap : PhaserGameObject
{
	public Tilemap _layer;

	public PhaserTilemapBoundingBoxes _boundingBoxes;

	private SuperMap _map;

	[NonSerialized]
	public PhaserTile[] _phaserTiles;

	[NonSerialized]
	public BoundsInt _bounds;

	[NonSerialized]
	public float4 _worldBounds;

	[NonSerialized]
	public float4 _parentBounds;

	[NonSerialized]
	public int _parentSetID;

	private BoundsInt[] _loadedBounds;

	private bool _isInverse;

	[NonSerialized]
	public float4[] precachedBounds;

	public TilemapDataCache data;

	public override bool isParent => false;

	public override bool isTilemap => true;

	private void Awake()
	{
		//IL_01a2: Expected I, but got O
		//IL_01c5: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_01d2: Expected O, but got I
		Tilemap layer = _layer;
		if ((object)_layer == null || ((UnityEngine.Object)layer).m_CachedPtr == (IntPtr)0)
		{
			Tilemap component = GetComponent<Tilemap>();
			_layer = component;
		}
		PhaserTilemapBoundingBoxes boundingBoxes = _boundingBoxes;
		if ((object)_boundingBoxes == null || ((UnityEngine.Object)boundingBoxes).m_CachedPtr == (IntPtr)0)
		{
			PhaserTilemapBoundingBoxes component2 = GetComponent<PhaserTilemapBoundingBoxes>();
			_boundingBoxes = component2;
		}
		PhaserTilemapBoundingBoxes boundingBoxes2 = _boundingBoxes;
		if ((object)_boundingBoxes != null && ((UnityEngine.Object)boundingBoxes2).m_CachedPtr != (IntPtr)0)
		{
			PhaserTilemapBoundingBoxes boundingBoxes3 = _boundingBoxes;
			PhaserTilemapBoundingBoxesAsset asset = boundingBoxes3._asset;
			if ((object)boundingBoxes3._asset != null && ((UnityEngine.Object)asset).m_CachedPtr != (IntPtr)0)
			{
				PhaserTilemapBoundingBoxes boundingBoxes4 = _boundingBoxes;
				PhaserTilemapBoundingBoxesAsset asset2 = boundingBoxes4._asset;
				List<BoundsInt> allBounds = asset2.allBounds;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rdi_v11 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+18]");
				Array loadedBounds;
				if ((nint)0 != 0)
				{
					nint num = unchecked((nint)null);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rdi_v11 (System.Collections.Generic.List`1<UnityEngine.BoundsInt>)+10]");
					int length = default(int);
					Array.Copy((Array)0, 0, (Array)num, 0, length);
					loadedBounds = (Array)num;
				}
				else
				{
					loadedBounds = List<BoundsInt>.s_emptyArray;
				}
				_loadedBounds = (BoundsInt[])loadedBounds;
				goto IL_0246;
			}
		}
		_loadedBounds = null;
		GameObject gameObject = base.gameObject;
		string text = ((UnityEngine.Object)gameObject).GetName();
		string message = "No custom bounds found for layer " + text;
		Debug.LogWarning(message);
		goto IL_0246;
		IL_0246:
		Tilemap component3 = GetComponent<Tilemap>();
		_layer = component3;
		SuperMap componentInParent = GetComponentInParent<SuperMap>();
		_map = componentInParent;
	}

	public unsafe void RefreshData()
	{
		//IL_008c: Expected O, but got I
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0144: Expected O, but got I
		//IL_0153: Expected O, but got Ref
		//IL_0a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Expected O, but got Unknown
		//IL_0aa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aad: Expected O, but got Unknown
		//IL_01b4: Expected O, but got I4
		//IL_01df: Expected O, but got I4
		//IL_07c6: Expected O, but got I4
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Expected O, but got Unknown
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Expected O, but got Unknown
		//IL_026e: Expected I, but got O
		//IL_027c: Expected I, but got O
		//IL_028c: Expected O, but got I
		//IL_0b4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4f: Expected O, but got Unknown
		//IL_0b58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5d: Expected O, but got Unknown
		//IL_030c: Expected O, but got I4
		//IL_02c8: Expected O, but got I
		//IL_08a2: Expected O, but got I
		//IL_08c7: Expected O, but got Ref
		//IL_08c7: Expected O, but got Ref
		//IL_08dc: Expected O, but got I4
		//IL_02fe: Expected O, but got I4
		//IL_03ac: Expected I8, but got I4
		//IL_03c4: Expected I8, but got I
		//IL_04f4: Expected I8, but got I
		//IL_06f9: Expected I, but got O
		//IL_0548: Expected I8, but got I
		//IL_0586: Expected I8, but got I
		//IL_05d5: Expected I8, but got I
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected Ref, but got Unknown
		//IL_04a4: Expected I8, but got I
		//IL_04c9: Expected I, but got O
		//IL_04d6: Expected I, but got O
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Expected Ref, but got Unknown
		//IL_0625: Expected I8, but got I
		//IL_064a: Expected I, but got O
		//IL_064f: Expected I, but got O
		//IL_09de->IL09de: Incompatible stack heights: 5 vs 0
		//IL_0922->IL0ba1: Incompatible stack heights: 9 vs 6
		//IL_0b63->IL0b63: Incompatible stack heights: 8 vs 5
		//IL_08e2->IL08e2: Incompatible stack heights: 11 vs 8
		//IL_06ec->IL0b37: Incompatible stack heights: 10 vs 8
		//IL_0748->IL0b37: Incompatible stack heights: 11 vs 8
		object obj;
		TileBase[] tilesBlock;
		BoundsInt bounds = default(BoundsInt);
		Transform transform2;
		while (true)
		{
			bool flag = (object)_layer == null;
			_bounds = (BoundsInt)_layer.cellBounds.m_Position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v23 (UnityEngine.BoundsInt)+10]");
			_ = 0;
			SuperMap map = _map;
			bool flag2 = (object)_map == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
			obj = (nint)0 >> 32;
			object obj2 = this + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004030");
			object obj3 = this + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850040A0");
			object obj4 = this + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004670");
			object obj5 = this + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
			object obj6 = this + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850039F0");
			object obj7 = this + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003FC0");
			bool flag3 = (object)_layer == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+78]");
			Transform transform = (Transform)0;
			tilesBlock = _layer.GetTilesBlock((BoundsInt)(&bounds));
			bool flag4 = (object)_layer == null;
			transform2 = _layer.transform;
			bool flag5 = (object)transform2 == null;
			if (((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform2);
		}
		Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
		bool flag6 = 0 < (nint)ret;
		object obj8 = 0 - ret;
		bool flag7 = obj8 == null;
		bool flag8 = !flag6;
		bool flag9 = !flag7;
		bool isInverse = flag9 & flag8;
		_isInverse = isInverse;
		object obj9 = "collides";
		object obj10 = "true";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
		PhaserTile[] array = (PhaserTile[])(obj * 0);
		PhaserTile[] phaserTiles = new PhaserTile[(object)array];
		_phaserTiles = phaserTiles;
		PhaserTile[] array2 = null;
		List<CustomProperty>.Enumerator enumerator = (List<CustomProperty>.Enumerator)0;
		Transform transform3 = transform2;
		bounds = _bounds;
		object obj12 = default(object);
		object obj11 = obj12;
		PhaserTile phaserTile = (PhaserTile)(object)array;
		List<CustomProperty>.Enumerator enumerator2 = (List<CustomProperty>.Enumerator)0;
		object obj13 = obj12;
		object obj14 = default(object);
		int2 int6 = default(int2);
		object obj15 = default(object);
		PhaserTile ret2;
		object obj19 = default(object);
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
		{
			PhaserTile[] array3;
			for (int2 int5 = int6; System.Runtime.CompilerServices.Unsafe.As<int2, UIntPtr>(ref int5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15); Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0"), int5++, array2 = (PhaserTile[])(array3 + 1))
			{
				bool flag10 = tilesBlock == null;
				bool flag11 = (nint)array2 >= tilesBlock.Length;
				TileBase tileBase = tilesBlock[(object)array2];
				if ((object)tilesBlock[(object)array2] == null)
				{
					goto IL_0748;
				}
				nint num = (nint)tileBase;
				nint num2 = (nint)typeof(SuperTile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdx_v41 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1748 @ r9_v17 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdx_v41 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
				bool flag12 = num3 < 0;
				object obj18;
				if (!flag12)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1748 @ r9_v17 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+C8]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1902 @ rax_v115+FFFFFFF8+v1842 @ rax_v92*8]");
					flag12 = 0 != (nint)typeof(SuperTile);
					if (!flag12)
					{
						obj18 = 1;
						goto IL_0aca;
					}
				}
				obj18 = 0;
				goto IL_0aca;
				IL_0aca:
				bool flag13 = obj18 == null;
				TileBase tileBase2 = null;
				if (!flag13)
				{
					tileBase2 = tilesBlock[(object)array2];
				}
				if ((object)tileBase2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v25 (UnityEngine.Tilemaps.TileBase)+58]");
					if ((nint)0 != 0)
					{
						bool flag14 = _phaserTiles == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v25 (UnityEngine.Tilemaps.TileBase)+58]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v25 (UnityEngine.Tilemaps.TileBase)+58]");
						bool flag15 = (nint)0 == 0;
						ulong num4 = 0uL;
						while (true)
						{
							if (enumerator.MoveNext())
							{
								Transform transform4 = null;
								num4 = (ulong)(nint)((UnityEngine.Object)transform4).m_CachedPtr;
								bool flag16 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)unchecked((nint)"collides");
								nint num5 = num;
								bool flag17 = flag12;
								if (!flag16)
								{
									if (((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0 || "collides" == null)
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ r8_v28 (System.UInt64)+10]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rsi_v12+10]");
									flag12 = num6 != 0;
									if (flag12)
									{
										continue;
									}
									ref byte first = ref *(byte*)((nint)((UnityEngine.Object)transform4).m_CachedPtr + 20);
									ref byte second = ref *(byte*)("collides" + 20);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ r8_v28 (System.UInt64)+10]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ r8_v28 (System.UInt64)+10]");
									num4 = (ulong)(num7 + 0);
									bool flag18 = System.SpanHelpers.SequenceEqual(ref first, ref second, num4);
									bool flag19 = !flag18;
									num5 = unchecked((nint)null);
									flag17 = flag12;
									num = unchecked((nint)null);
									if (flag19)
									{
										continue;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rbx_v29 (UnityEngine.Transform)+20]");
								ulong num8 = 0uL;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rbx_v29 (UnityEngine.Transform)+20]");
								if (0 != unchecked((nint)"true"))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rbx_v29 (UnityEngine.Transform)+20]");
									bool flag20 = (nint)0 == 0;
									num = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rbx_v29 (UnityEngine.Transform)+20]");
									num4 = 0uL;
									flag12 = flag17;
									if (flag20)
									{
										continue;
									}
									bool flag21 = "true" == null;
									num = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rbx_v29 (UnityEngine.Transform)+20]");
									num4 = 0uL;
									flag12 = flag17;
									if (flag21)
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2249 @ r8_v32 (System.UInt64)+10]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v12+10]");
									flag12 = num9 != 0;
									num = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rbx_v29 (UnityEngine.Transform)+20]");
									num4 = 0uL;
									if (flag12)
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rbx_v29 (UnityEngine.Transform)+20]");
									ref byte first2 = ref *(byte*)((nint)0 + (nint)20);
									ref byte second2 = ref *(byte*)("true" + 20);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2249 @ r8_v32 (System.UInt64)+10]");
									nint num10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2249 @ r8_v32 (System.UInt64)+10]");
									num8 = (ulong)(num10 + 0);
									bool flag22 = System.SpanHelpers.SequenceEqual(ref first2, ref second2, num8);
									bool flag23 = !flag22;
									num5 = unchecked((nint)null);
									num = unchecked((nint)null);
									num4 = num8;
									if (flag23)
									{
										continue;
									}
								}
								PhaserTile phaserTile2 = null;
								phaserTile2.position = int5;
								phaserTile2._data = 15;
								num = num5;
								phaserTile = phaserTile2;
								num4 = num8;
							}
							else
							{
								phaserTile = null;
							}
							break;
						}
						transform3 = (Transform)(object)_phaserTiles;
						bool flag24 = _phaserTiles == null;
						bool flag25 = phaserTile == null;
						array3 = array2;
						ret2 = null;
						enumerator = (List<CustomProperty>.Enumerator)bounds;
						enumerator2 = (List<CustomProperty>.Enumerator)bounds;
						Transform transform = null;
						if (!flag25)
						{
							nint num11 = (nint)transform3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							bool flag26 = obj19 == null;
							array3 = array2;
							ret2 = null;
							enumerator = (List<CustomProperty>.Enumerator)bounds;
							enumerator2 = (List<CustomProperty>.Enumerator)bounds;
							transform = null;
						}
						continue;
					}
				}
				goto IL_0748;
				IL_0748:
				transform3 = (Transform)(object)_phaserTiles;
				bool flag27 = _phaserTiles == null;
				array3 = array2;
				phaserTile = null;
			}
			obj13 = obj11 + 1;
		}
		PhaserTile[] phaserTiles2 = _phaserTiles;
		bool flag28 = _phaserTiles == null;
		Transform transform5 = null;
		object obj20 = 0;
		Transform transform6 = null;
		bool isInverse2 = default(bool);
		while ((nint)transform6 < phaserTiles2.Length)
		{
			PhaserTile[] phaserTiles3 = _phaserTiles;
			bool flag29 = _phaserTiles == null;
			bool flag30 = (nint)transform5 >= phaserTiles3.Length;
			if (phaserTiles3[(object)transform5] != null)
			{
				bool flag31 = _phaserTiles == null;
				bool flag32 = (nint)transform5 >= phaserTiles3.Length;
				bool flag33 = phaserTiles3[(object)transform5] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+78]");
				Transform transform = (Transform)0;
				phaserTiles3[(object)transform5].updateTileFaces(_phaserTiles, (BoundsInt)(&bounds), (BoundsInt)(&obj20), isInverse2);
				bounds = _bounds;
				obj20 = 0;
			}
			transform5 = (Transform)(transform5 + 1);
			phaserTiles2 = _phaserTiles;
			bool flag34 = _phaserTiles == null;
			transform6 = transform5;
		}
		object layer = _layer;
		bool flag35 = (object)_layer == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rbx_v15 (System.Object)+10]");
		bool flag36 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rbx_v15 (System.Object)+10]");
		Tilemap.get_localBounds_Injected((IntPtr)0, out *(Bounds*)(&ret2));
		bool flag37 = (object)_layer == null;
		Transform transform7 = _layer.transform;
		if (_isInverse)
		{
		}
		bool flag38 = (object)transform7 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rax_v62 (UnityEngine.Transform)+10]");
		bool flag39 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rax_v62 (UnityEngine.Transform)+10]");
		float4 position = default(float4);
		Transform.TransformPoint_Injected((IntPtr)0, ref *(Vector3*)(&position), out ret);
		bool flag40 = (object)_layer == null;
		Transform transform8 = _layer.transform;
		if (_isInverse)
		{
		}
		bool flag41 = (object)transform8 == null;
		bool flag42 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
		float4 position2 = default(float4);
		Transform.TransformPoint_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Vector3*)(&position2), out *(Vector3*)(&position));
		float4 worldBounds = default(float4);
		_worldBounds = worldBounds;
	}

	public void RemoveTileAt(int tileX, int tileY)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		object obj = this + 104;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
		object obj2 = this + 104;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850039F0");
		object obj3 = this + 104;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003FC0");
		object obj4 = this + 104;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003980");
		object obj5 = this + 104;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850039F0");
		object obj6 = this + 104;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003FC0");
		object obj8 = default(object);
		object obj7 = obj8 >> 32;
		object obj9 = tileY - obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
		object obj10 = obj9 * 0;
		object obj12 = default(object);
		object obj11 = obj10 - obj12;
		object obj13 = obj11 + tileX;
		object obj14 = default(object);
		if (obj14 == null)
		{
			PhaserTile[] phaserTiles = _phaserTiles;
			if ((nint)obj13 < phaserTiles.Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
	}

	public unsafe void UpdatePrecachedData()
	{
		//IL_0008: Expected O, but got Ref
		//IL_001b: Expected O, but got Ref
		//IL_0025: Expected native int or pointer, but got O
		//IL_004e: Expected O, but got I
		//IL_0130: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_032f: Expected O, but got I
		//IL_0358: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_0234: Expected O, but got I
		//IL_039a: Expected O, but got I
		//IL_03e3: Expected O, but got I
		//IL_040c: Expected O, but got I
		//IL_041c: Expected O, but got I
		//IL_042c: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_044c: Expected O, but got I
		//IL_0276: Expected O, but got I
		//IL_08fe: Expected O, but got I
		//IL_02bf: Expected O, but got I
		//IL_02e8: Expected O, but got I
		//IL_046a: Expected O, but got I
		//IL_047a: Expected O, but got I
		//IL_048a: Expected O, but got I
		//IL_049a: Expected O, but got I
		//IL_0771: Expected O, but got I
		//IL_0781: Expected O, but got I
		//IL_0791: Expected O, but got I
		//IL_07a1: Expected O, but got I
		//IL_07f0: Expected O, but got Ref
		//IL_07fe: Expected O, but got Ref
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Expected O, but got Unknown
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Expected O, but got Unknown
		//IL_089e: Expected O, but got Ref
		//IL_08ac: Expected O, but got Ref
		//IL_06a7: Expected O, but got I
		//IL_06bd: Expected O, but got I
		//IL_095b->IL071f: Incompatible stack heights: 1 vs 0
		//IL_08df->IL071f: Incompatible stack heights: 2 vs 0
		//IL_0700->IL071f: Incompatible stack heights: 2 vs 0
		//IL_0712->IL0147: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		if ((object)this != null)
		{
			TilemapDataCache tilemapDataCache = (TilemapDataCache)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			*(TilemapDataCache*)(nint)tilemapDataCache = new TilemapDataCache(_layer);
			bool flag = _loadedBounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
			data = (TilemapDataCache)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
			_ = 0;
			if (!flag)
			{
				BoundsInt[] loadedBounds = _loadedBounds;
				if (loadedBounds.Length != 0)
				{
					if (precachedBounds != null)
					{
						float4[] array = precachedBounds;
						if (array.Length == loadedBounds.Length)
						{
							goto IL_0106;
						}
					}
					float4[] array2 = new float4[loadedBounds.Length];
					precachedBounds = array2;
					goto IL_0106;
				}
			}
			precachedBounds = null;
			return;
		}
		goto IL_071f;
		IL_0106:
		BoundsInt[] loadedBounds2 = _loadedBounds;
		_ = 0;
		bool flag2 = _loadedBounds == null;
		object obj3 = 0;
		object obj4 = 0;
		if (!flag2)
		{
			while (true)
			{
				if ((nint)obj4 >= loadedBounds2.Length)
				{
					return;
				}
				BoundsInt[] loadedBounds3 = _loadedBounds;
				if (_loadedBounds == null)
				{
					break;
				}
				bool flag3 = !_isInverse;
				object obj5 = obj3 * 2;
				object obj6 = obj3 + obj5;
				_ = _layer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+30+v679 @ rcx_v22*8]");
				_ = 0;
				BoundsInt boundsInt8;
				BoundsInt boundsInt9;
				BoundsInt boundsInt7;
				BoundsInt boundsInt6;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,0Ch\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt = (BoundsInt)(num + 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					bool flag4 = 0 >= (nint)boundsInt;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt2 = (BoundsInt)0;
					if (!flag4)
					{
						boundsInt2 = boundsInt;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt3 = (BoundsInt)(num2 + 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					if (0 < (nint)boundsInt3)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt4 = (BoundsInt)(num3 + 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					bool flag5 = 0 >= (nint)boundsInt4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt5 = (BoundsInt)0;
					if (!flag5)
					{
						boundsInt5 = boundsInt4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt6 = (BoundsInt)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt7 = (BoundsInt)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt8 = (BoundsInt)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt9 = (BoundsInt)0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,0Ch\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt10 = (BoundsInt)(num4 + 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					bool flag6 = 0 <= (nint)boundsInt10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt2 = (BoundsInt)0;
					if (!flag6)
					{
						boundsInt2 = boundsInt10;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt11 = (BoundsInt)(num5 + 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					if (0 > (nint)boundsInt11)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt12 = (BoundsInt)(num6 + 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					bool flag7 = 0 <= (nint)boundsInt12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt6 = (BoundsInt)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt7 = (BoundsInt)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt8 = (BoundsInt)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					boundsInt9 = (BoundsInt)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
					BoundsInt boundsInt5 = (BoundsInt)0;
					if (!flag7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
						boundsInt6 = (BoundsInt)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
						boundsInt7 = (BoundsInt)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
						boundsInt8 = (BoundsInt)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v16 (UnityEngine.BoundsInt[])+20+v679 @ rcx_v22*8]");
						boundsInt9 = (BoundsInt)0;
						boundsInt5 = boundsInt12;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				if ((nint)0 == 0)
				{
					break;
				}
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r12_v11 (System.Object)+10]");
				bool flag8 = (nint)0 == 0;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r12_v11 (System.Object)+10]");
				GridLayout.CellToWorld_Injected((IntPtr)0, ref *(Vector3Int*)obj9, out *(Vector3*)obj8);
				bool flag9 = !_isInverse;
				object layer = _layer;
				if (!flag9)
				{
					BoundsInt boundsInt13 = (BoundsInt)((object)boundsInt9 + (object)boundsInt8);
					if (System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt9) > System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt13))
					{
						boundsInt9 = boundsInt13;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
					BoundsInt boundsInt14 = (BoundsInt)(0 + boundsInt7);
					if (System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt7) > System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt14))
					{
						boundsInt7 = boundsInt14;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
					BoundsInt boundsInt15 = (BoundsInt)(0 + boundsInt6);
					if (System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt6) > System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt15))
					{
						boundsInt6 = boundsInt15;
					}
				}
				else
				{
					BoundsInt boundsInt16 = (BoundsInt)((object)boundsInt9 + (object)boundsInt8);
					if (System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt9) < System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt16))
					{
						boundsInt9 = boundsInt16;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
					BoundsInt boundsInt17 = (BoundsInt)(0 + boundsInt7);
					if (System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt7) < System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt17))
					{
						boundsInt7 = boundsInt17;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
					BoundsInt boundsInt18 = (BoundsInt)(0 + boundsInt6);
					if (System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt6) < System.Runtime.CompilerServices.Unsafe.As<BoundsInt, UIntPtr>(ref boundsInt18))
					{
						boundsInt6 = boundsInt18;
					}
				}
				if ((object)_layer == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
				_ = 0;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r15_v12 (System.Object)+10]");
				bool flag10 = (nint)0 == 0;
				object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r15_v12 (System.Object)+10]");
				GridLayout.CellToWorld_Injected((IntPtr)0, ref *(Vector3Int*)obj11, out *(Vector3*)obj10);
				if (precachedBounds == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
				obj3 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
				object obj12 = (nint)0 + (nint)2;
				object obj13 = obj12 + obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
				_ = 0;
				loadedBounds2 = _loadedBounds;
				if (_loadedBounds == null)
				{
					break;
				}
				obj4 = obj3;
			}
		}
		goto IL_071f;
		IL_071f:
		throw new NullReferenceException();
	}

	public unsafe void UpdateTilemapBounds(Bounds parentBounds)
	{
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_030c: Expected O, but got I
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_0299: Expected O, but got I
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Expected O, but got Unknown
		//IL_046d: Expected O, but got I
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_03fa: Expected O, but got I
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_04f7->IL0224: Incompatible stack heights: 1 vs 0
		//IL_0387->IL0224: Incompatible stack heights: 2 vs 0
		//IL_0201->IL0224: Incompatible stack heights: 2 vs 0
		//IL_01d8->IL0224: Incompatible stack heights: 2 vs 0
		//IL_0514->IL0224: Incompatible stack heights: 3 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+14]");
		_ = 0;
		_ = parentBounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+8]");
		_ = 0;
		_ = parentBounds.m_Extents;
		_ = parentBounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+14]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+8]");
		_ = 0;
		_ = parentBounds.m_Extents;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+14]");
		_ = 0;
		_ = parentBounds.m_Extents;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+8]");
		_ = 0;
		_ = parentBounds.m_Center;
		_ = parentBounds.m_Extents;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+14]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [parentBounds @ rdx (UnityEngine.Bounds)+8]");
		_ = 0;
		_ = parentBounds.m_Center;
		float4 float5 = default(float4);
		_parentBounds = float5;
		if ((object)_layer != null)
		{
			Transform transform = _layer.transform;
			bool flag = !_isInverse;
			object layer = _layer;
			bool num;
			object obj2 = default(object);
			if (!flag)
			{
				if ((object)_layer == null)
				{
					goto IL_0224;
				}
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rbx_v14 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				num = flag2;
				object obj = obj2 - 64;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rbx_v14 (System.Object)+10]");
				Tilemap.get_localBounds_Injected((IntPtr)0, out *(Bounds*)obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-38]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-2C]");
				object obj3 = num2 + 0;
			}
			else
			{
				if ((object)_layer == null)
				{
					goto IL_0224;
				}
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rbx_v14 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				num = flag3;
				object obj4 = obj2 - 64;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rbx_v14 (System.Object)+10]");
				Tilemap.get_localBounds_Injected((IntPtr)0, out *(Bounds*)obj4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-38]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-2C]");
				object obj3 = num3 - 0;
			}
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj5 = obj2 - 96;
				object obj6 = obj2 - 80;
				Transform.TransformPoint_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj6, out *(Vector3*)obj5);
				if ((object)_layer != null)
				{
					Transform transform2 = _layer.transform;
					bool flag5 = !_isInverse;
					object layer2 = _layer;
					bool num4;
					if (!flag5)
					{
						if ((object)_layer == null)
						{
							goto IL_0224;
						}
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v16 (System.Object)+10]");
						bool flag6 = (nint)0 == 0;
						num4 = flag6;
						object obj7 = obj2 - 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v16 (System.Object)+10]");
						Tilemap.get_localBounds_Injected((IntPtr)0, out *(Bounds*)obj7);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-18]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-C]");
						object obj8 = num5 - 0;
					}
					else
					{
						if ((object)_layer == null)
						{
							goto IL_0224;
						}
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v16 (System.Object)+10]");
						bool flag7 = (nint)0 == 0;
						num4 = flag7;
						object obj9 = obj2 - 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rbx_v16 (System.Object)+10]");
						Tilemap.get_localBounds_Injected((IntPtr)0, out *(Bounds*)obj9);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-18]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-C]");
						object obj8 = num6 + 0;
					}
					if ((object)transform2 != null)
					{
						_ = 0;
						_ = 0;
						bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj10 = obj2 - 80;
						object obj11 = obj2 - 64;
						Transform.TransformPoint_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj11, out *(Vector3*)obj10);
						_worldBounds = float5;
						UpdatePrecachedData();
						return;
					}
				}
			}
		}
		goto IL_0224;
		IL_0224:
		throw new NullReferenceException();
	}

	public int GetTilesInBounds(BoundsInt targetBounds, PhaserTile[] tileCache)
	{
		//IL_001e: Expected I4, but got O
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e6: Expected O, but got I
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_028e: Expected I4, but got O
		//IL_021f: Expected O, but got I
		//IL_016a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003A60");
		int num = (object)targetBounds.m_Position - (object)_bounds;
		object obj = (object)targetBounds.m_Position >> 32;
		object obj2 = (object)_bounds >> 32;
		object obj3 = obj - obj2;
		object obj4 = targetBounds.m_Size + num;
		object obj5 = (object)targetBounds.m_Size >> 32;
		PhaserTile phaserTile = (PhaserTile)(object)(obj5 + obj3);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<PhaserTile, UIntPtr>(ref phaserTile);
		int result = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
			object obj6 = 0 * obj3;
			int num2 = 0;
			PhaserTile phaserTile2 = phaserTile;
			object obj7 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
			object obj8 = 0;
			int num3 = num;
			object obj10 = default(object);
			bool flag6;
			do
			{
				bool flag2 = num3 >= (nint)obj4;
				int num4 = num2;
				PhaserTile phaserTile3 = phaserTile2;
				int num5 = num3;
				if (!flag2)
				{
					while (true)
					{
						PhaserTile[] phaserTiles = _phaserTiles;
						object obj9 = obj6 + num5;
						if ((nint)obj9 < phaserTiles.Length)
						{
							bool flag3 = phaserTiles[obj9] == null;
							num2 = num4;
							if (!flag3)
							{
								num2 = num4 + 1;
								nint num6 = (nint)tileCache;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								if (obj10 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								bool flag4 = num2 >= tileCache.Length;
								phaserTile3 = phaserTiles[obj9];
								result = num2;
								if (flag4)
								{
									break;
								}
							}
							num5++;
							bool flag5 = num5 < (nint)obj4;
							num4 = num2;
							if (flag5)
							{
								continue;
							}
							goto IL_0207;
						}
						IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
						return (int)ex2;
					}
					break;
				}
				goto IL_0239;
				IL_0239:
				obj3++;
				obj6 += obj8;
				flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<PhaserTile, UIntPtr>(ref phaserTile2);
				result = num2;
				obj7 = obj3;
				continue;
				IL_0207:
				phaserTile2 = phaserTile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
				obj8 = 0;
				obj3 = obj7;
				num3 = num;
				goto IL_0239;
			}
			while (flag6);
		}
		return result;
	}

	public bool IsTileAtPosition(float2 position)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0187: Expected I4, but got O
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		float4 worldBounds = _worldBounds;
		if (System.Runtime.CompilerServices.Unsafe.As<float4, UIntPtr>(ref worldBounds) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+88]");
			if ((nint)position <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+84]");
				object obj = default(object);
				if (0 <= (nint)obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+8C]");
					if ((nint)obj <= 0)
					{
						object obj2 = this + 192;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D10");
						object obj4 = default(object);
						object obj3 = obj4 - (object)_bounds;
						object obj5 = (object)_bounds >> 32;
						object obj6 = obj - obj5;
						PhaserTile[] phaserTiles = _phaserTiles;
						if (_phaserTiles != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
							object obj7 = obj6 * 0;
							object obj8 = obj7 + obj3;
							bool flag = (nint)phaserTiles[obj8] < 0;
							bool flag2 = phaserTiles[obj8] == null;
							bool flag3 = !flag;
							bool flag4 = !flag2;
							return flag4 & flag3;
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
				}
			}
		}
		return false;
	}

	public bool IsTileAtPositionWrapped(float2 position)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_013a: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01a7: Expected I4, but got O
		object obj = this + 192;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D10");
		object obj3 = default(object);
		object obj2 = obj3 - (object)_bounds;
		object obj4 = (object)_bounds >> 32;
		object obj6 = default(object);
		object obj5 = obj6 - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
		object obj7 = obj2 % 0;
		bool flag = (nint)obj7 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
		object obj8 = obj7 + 0;
		if (!flag)
		{
			obj8 = obj7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
		object obj9 = (nint)0 >> 32;
		object obj10 = obj5 % obj9;
		PhaserTile[] phaserTiles = _phaserTiles;
		object obj11 = obj9 + obj10;
		if ((nint)obj10 >= 0)
		{
			obj11 = obj10;
		}
		object obj12 = obj11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
		object obj13 = obj12 * 0;
		object obj14 = obj13 + obj8;
		if ((nint)obj14 < phaserTiles.Length)
		{
			bool flag2 = (nint)phaserTiles[obj14] < 0;
			bool flag3 = phaserTiles[obj14] == null;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public PhaserTile GetTileAtCellPosition(int2 cellPos)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		object obj = (object)cellPos - (object)_bounds;
		object obj2 = (object)_bounds >> 32;
		object obj4 = default(object);
		object obj3 = obj4 - obj2;
		PhaserTile[] phaserTiles = _phaserTiles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PhaserTilemap)+74]");
		object obj5 = obj3 * 0;
		object obj6 = obj5 + obj;
		if ((nint)obj6 < phaserTiles.Length)
		{
			return phaserTiles[obj6];
		}
		return (PhaserTile)(object)new IndexOutOfRangeException();
	}

	public PhaserTilemap()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
