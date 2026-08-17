using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects;

public class TilingTileset : GameMonoBehaviour
{
	private struct MoongateData
	{
		public Vector2 A;

		public bool HasA;

		public Vector2 B;

		public bool HasB;
	}

	private struct TeleporterData
	{
		public string TeleportKey;

		public Vector2 A;

		public bool HasA;

		public Vector2 B;

		public bool HasB;

		public string DestinationA;

		public string DestinationB;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<CustomProperty> _003C_003E9__92_0;

		public static Predicate<CustomProperty> _003C_003E9__92_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CLinkTeleporters_003Eb__92_0(CustomProperty property)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39BA]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (property != null)
			{
				string name = property.m_Name;
				object obj = "teleportKey";
				if ((object)property.m_Name != "teleportKey")
				{
					if (property.m_Name != null && "teleportKey" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("teleportKey" + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(property.m_Name + 20), ref second, length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal unsafe bool _003CLinkTeleporters_003Eb__92_1(CustomProperty property)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39BB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (property != null)
			{
				string name = property.m_Name;
				object obj = "destinationBiome";
				if ((object)property.m_Name != "destinationBiome")
				{
					if (property.m_Name != null && "destinationBiome" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("destinationBiome" + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(property.m_Name + 20), ref second, length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass62_0
	{
		public Action onComplete;

		internal void _003CFadeAllLayers_003Eb__0()
		{
			Action action = onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public Action onComplete;

		internal void _003CTintAllLayers_003Eb__0()
		{
			Action action = onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass82_0
	{
		public string layerName;

		internal unsafe bool _003CGetObjectLayer_003Eb__0(SuperObjectLayer superObjectLayer)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if ((object)superObjectLayer != null)
			{
				string tiledName = superObjectLayer.m_TiledName;
				if (superObjectLayer.m_TiledName != null)
				{
					string text = layerName;
					if ((object)superObjectLayer.m_TiledName != layerName)
					{
						if (layerName != null && tiledName._stringLength == text._stringLength)
						{
							ref byte second = ref *(byte*)(layerName + 20);
							ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(superObjectLayer.m_TiledName + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private TilesetFactory _tilesetFactory;

	private GameManager _gameManager;

	private PlayerOptions _playerOptions;

	private StageType _stageType;

	private Stage _stage;

	private readonly List<SuperMap> _maps;

	private readonly List<GameObject> _supportMaps;

	private readonly List<PhaserTilemap> _phaserTilemaps;

	private readonly Dictionary<SuperMap, List<SuperTileLayer>> _cachedMapSuperTilesLayers;

	private readonly Dictionary<SuperMap, List<PhaserTilemap>> _cachedCollisionTilemaps;

	private readonly Dictionary<SuperMap, Tilemap> _cachedSpawningTilemap;

	private readonly Dictionary<SuperMap, Tilemap> _cachedFloorLayers;

	private List<Bounds> _bounds;

	private Bounds _currentBounds;

	private Vector3 _previousTilingCenter;

	private bool _hasMoongates;

	private bool _hasTeleporters;

	private readonly Dictionary<string, MoongateData> _moongates;

	private readonly Dictionary<string, TeleporterData> _teleporters;

	private float _sizeX;

	private float _sizeY;

	private AdventureManager _adventureManager;

	private Vector2 _003CStartPosition_003Ek__BackingField;

	public bool _inverted;

	public bool _visuallyInverted;

	public List<SuperObject> SavedScripts;

	private List<PickupTeleporter> _003CListOfTeleporters_003Ek__BackingField;

	private float offset;

	private Bounds _previousFirstMap;

	public Vector2 StartPosition
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		private set
		{
			_003CStartPosition_003Ek__BackingField = value;
		}
	}

	public SuperMap DefaultMap
	{
		get
		{
			List<SuperMap> maps = _maps;
			if (_maps != null)
			{
				if (maps._size > 0)
				{
					SuperMap[] items = maps._items;
					return items[0];
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			return (SuperMap)(object)new NullReferenceException();
		}
	}

	public GameObject DefaultSupportMap
	{
		get
		{
			List<GameObject> supportMaps = _supportMaps;
			if (_supportMaps != null)
			{
				if (supportMaps._size > 0)
				{
					GameObject[] items = supportMaps._items;
					return items[0];
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			return (GameObject)(object)new NullReferenceException();
		}
	}

	public float SizeX => _sizeX;

	public float SizeY => _sizeY;

	public Vector2 DefaultMapPosition
	{
		get
		{
			SuperMap defaultMap = DefaultMap;
			if ((object)defaultMap != null)
			{
				Transform transform = defaultMap.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Vector2 result = default(Vector2);
					return result;
				}
			}
			throw new NullReferenceException();
		}
	}

	public unsafe Bounds CurrentBounds
	{
		get
		{
			//IL_000a: Expected native int or pointer, but got O
			Bounds bounds = default(Bounds);
			((Bounds*)(nint)bounds)->m_Center = (Vector3)_currentBounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Objects.TilingTileset)+A0]");
			_ = 0;
			return bounds;
		}
	}

	public List<SuperMap> Tiles => _maps;

	public List<PickupTeleporter> ListOfTeleporters
	{
		get
		{
			return _003CListOfTeleporters_003Ek__BackingField;
		}
		private set
		{
			_003CListOfTeleporters_003Ek__BackingField = value;
		}
	}

	public unsafe Bounds GetTotalBounds()
	{
		//IL_0139: Expected O, but got I4
		//IL_0134: Expected native int or pointer, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_00a2: Expected O, but got I
		//IL_01a2: Expected O, but got I
		//IL_037c: Invalid comparison between O and F4
		//IL_01e2: Invalid comparison between O and F4
		//IL_0226: Invalid comparison between F4 and O
		//IL_03af: Invalid comparison between F4 and O
		//IL_03e5: Expected native int or pointer, but got O
		//IL_0406: Expected native int or pointer, but got O
		Bounds bounds = default(Bounds);
		((Bounds*)(nint)bounds)->m_Center = (Vector3)0;
		_ = 0;
		List<Bounds>.Enumerator enumerator = default(List<Bounds>.Enumerator);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj5 = default(object);
		Vector3 vector = default(Vector3);
		object obj9 = default(object);
		while (enumerator.MoveNext())
		{
			object obj = 0 - obj2;
			object obj3 = obj4 - obj5;
			object obj6 = bounds.m_Center - bounds.m_Extents;
			object obj7 = vector - vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+8]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+14]");
			object obj8 = num - 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
				obj6 = obj;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
			{
				obj7 = obj9;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
			{
				obj8 = obj3;
			}
			object obj10 = bounds.m_Extents + bounds.m_Center;
			object obj11 = vector + vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+14]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnBuffer @ rcx (UnityEngine.Bounds)+8]");
			object obj12 = num2 + 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				obj10 = obj;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
			{
				obj11 = obj9;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				obj12 = obj3;
			}
			object obj13 = obj10 - obj6;
			object obj14 = obj11 - obj7;
			object obj15 = obj12 - obj8;
			float num3 = (float)obj13 * 0.5f;
			float num4 = (float)obj14 * 0.5f;
			float num5 = (float)obj15 * 0.5f;
			float num6 = (float)obj6 + num3;
			float num7 = (float)obj7 + num4;
			float num8 = (float)obj8 + num5;
			float num9 = (float)obj5 + (float)obj4;
			float num10 = num6 - num3;
			float num11 = num7 - num4;
			float num12 = num8 - num5;
			if ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num11)) && !(num9 > num12))
			{
				num12 = num9;
			}
			float num13 = num6 + num3;
			float num14 = num7 + num4;
			float num15 = num8 + num5;
			if ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num13) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num14) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9)) && !(num15 > num9))
			{
				num15 = num9;
			}
			float num16 = num15 - num12;
			float num17 = num16 * 0.5f;
			((Bounds*)(nint)bounds)->m_Extents = vector;
			float num18 = num12 + num17;
			((Bounds*)(nint)bounds)->m_Center = vector;
		}
		return bounds;
	}

	private void Construct(TilesetFactory tilesetFactory, GameManager gameManager, PlayerOptions playerOptions, AdventureManager adventureManager)
	{
		_tilesetFactory = tilesetFactory;
		_gameManager = gameManager;
		_playerOptions = playerOptions;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	private void OnDrawGizmosSelected()
	{
		Color value = default(Color);
		Gizmos.set_color_Injected(ref value);
		List<Bounds>.Enumerator enumerator = default(List<Bounds>.Enumerator);
		Vector3 center = default(Vector3);
		Vector3 size = default(Vector3);
		while (enumerator.MoveNext())
		{
			Gizmos.DrawWireCube_Injected(ref center, ref size);
		}
		Gizmos.set_color_Injected(ref value);
	}

	protected override void OnDestroy()
	{
		List<PhaserTilemap> phaserTilemaps = _phaserTilemaps;
		if (_phaserTilemaps != null)
		{
			int version = phaserTilemaps._version + 1;
			phaserTilemaps._version = version;
			phaserTilemaps._size = 0;
			if (phaserTilemaps._size > 0)
			{
				Array.Clear(phaserTilemaps._items, 0, phaserTilemaps._size);
			}
		}
		if (_cachedMapSuperTilesLayers != null)
		{
			_cachedMapSuperTilesLayers.Clear();
		}
		if (_cachedCollisionTilemaps != null)
		{
			_cachedCollisionTilemaps.Clear();
		}
		if (_cachedSpawningTilemap != null)
		{
			_cachedSpawningTilemap.Clear();
		}
		if (_cachedFloorLayers != null)
		{
			_cachedFloorLayers.Clear();
		}
	}

	public unsafe void Init(StageType stageType, Stage stage)
	{
		//IL_0213: Expected O, but got I4
		//IL_02ca: Expected O, but got I4
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0365: Expected O, but got I
		//IL_03be: Expected O, but got I
		//IL_03de: Expected O, but got I
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Expected O, but got Unknown
		//IL_03a3: Expected O, but got Ref
		_stageType = stageType;
		_stage = stage;
		List<PickupTeleporter> list = _003CListOfTeleporters_003Ek__BackingField;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = _stageType == StageType.STAGEX;
		_inverted = config._003CSelectedInverse_003Ek__BackingField;
		if (flag || _stageType == StageType.MACHINE)
		{
			_inverted = false;
		}
		bool flag2;
		if (_inverted)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				Stage stage2 = _stage;
				StageData stageData = stage2._stageData;
				flag2 = stageData._003CallowVisualInversion_003Ek__BackingField;
				goto IL_0473;
			}
		}
		flag2 = false;
		goto IL_0473;
		IL_0473:
		bool flag3 = !flag2;
		bool visuallyInverted = !flag3;
		_visuallyInverted = visuallyInverted;
		GenerateMaps();
		List<SuperMap> maps = _maps;
		if (maps._size > 0)
		{
			SuperMap[] items = maps._items;
			SuperMap superMap = items[0];
			List<SuperMap> maps2 = _maps;
			SuperMap[] items2 = maps2._items;
			SuperMap superMap2 = items2[0];
			List<SuperMap> maps3 = _maps;
			object obj = superMap.m_Width * superMap2.m_TileWidth;
			float sizeX = (float)obj * 0.01f;
			_sizeX = sizeX;
			if (maps3._size > 0)
			{
				SuperMap[] items3 = maps3._items;
				SuperMap superMap3 = items3[0];
				List<SuperMap> maps4 = _maps;
				SuperMap[] items4 = maps4._items;
				SuperMap superMap4 = items4[0];
				List<SuperMap> maps5 = _maps;
				object obj2 = superMap3.m_Height * superMap4.m_TileHeight;
				float sizeY = (float)obj2 * 0.01f;
				_sizeY = sizeY;
				bool flag4 = false;
				bool flag5 = false;
				object obj5 = default(object);
				while ((flag4 ? 1 : 0) < maps5._size)
				{
					List<Bounds> bounds = _bounds;
					float num = _sizeX * 0.5f;
					object obj3 = flag5 * _sizeX;
					float num2 = (float)obj3 + num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rdx_v17+18]");
					if (num3 >= 0)
					{
						bounds.AddWithResize((Bounds)(&obj5));
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
						object obj6 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
						object obj7 = (nint)0 * (nint)2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
						object obj8 = 0 + obj7;
					}
					maps5 = _maps;
					flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
					flag4 = flag5;
				}
				ProcessTiling();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public void InitPostLoad()
	{
		List<SuperMap> maps = _maps;
		if (maps._size > 0)
		{
			SuperMap[] items = maps._items;
			HandleCustomScriptProperties(items[0]);
			SpawnMoongates();
			MakeTeleporters();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void InternalUpdate()
	{
		//IL_01cf: Expected I, but got O
		//IL_003b: Expected O, but got I
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_01b6: Expected I, but got O
		ProcessTiling();
		nint num = (nint)typeof(VSDebug);
		if (!VSDebug.s_drawDebug)
		{
			return;
		}
		List<Bounds> bounds = _bounds;
		bool flag = (nint)_bounds < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v2 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
		object obj = -1;
		if (flag)
		{
			return;
		}
		Color colour = default(Color);
		while (true)
		{
			List<Bounds> bounds2 = _bounds;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v10 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)obj2 < 0)
			{
				List<Bounds> bounds3 = _bounds;
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rdx_v9 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
				if ((nint)obj3 < 0)
				{
					List<Bounds> bounds4 = _bounds;
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v11 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
					if ((nint)obj4 < 0)
					{
						List<Bounds> bounds5 = _bounds;
						object obj5 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v13 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
						if ((nint)obj5 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm9,xmm2\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm7,xmm4\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm8,xmm1\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm10,xmm3\"");
							if (obj == null)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r8_v6 (Il2CppClass<VSDebug>)+E4]");
							bool flag2 = (nint)0 < (nint)0;
							VSDebug.DrawDebugRect(0.0, 0.0, 0.0, 0.0, colour);
							obj--;
							if (!flag2)
							{
								num = (nint)typeof(VSDebug);
								continue;
							}
							break;
						}
					}
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}
	}

	public unsafe List<Vector2> GetSpecialLocations(string scriptName)
	{
		//IL_0098: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected Ref, but got Unknown
		//IL_01a9: Expected I8, but got I4
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Ref, but got Unknown
		//IL_01e5: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		SuperMap defaultMap = DefaultMap;
		SuperObjectLayer objectLayer = GetObjectLayer(defaultMap, "Scripts");
		List<Vector2> list;
		if ((object)objectLayer != null && ((UnityEngine.Object)objectLayer).m_CachedPtr != (IntPtr)0)
		{
			SuperObject[] componentsInChildren = objectLayer.GetComponentsInChildren<SuperObject>();
			if (componentsInChildren == null)
			{
				goto IL_02e2;
			}
			if (componentsInChildren.Length != 0)
			{
				list = new List<Vector2>();
				object obj = 0;
				object obj3;
				Vector2 item = default(Vector2);
				for (object obj2 = 0; (nint)obj2 < componentsInChildren.Length; obj2++, obj = obj3)
				{
					SuperObject superObject = componentsInChildren[obj2];
					if ((object)componentsInChildren[obj2] != null)
					{
						string tiledName = superObject.m_TiledName;
						if (superObject.m_TiledName != null)
						{
							if ((object)superObject.m_TiledName != scriptName)
							{
								bool flag = scriptName == null;
								obj3 = obj;
								if (flag)
								{
									continue;
								}
								bool flag2 = tiledName._stringLength != scriptName._stringLength;
								obj3 = obj;
								if (flag2)
								{
									continue;
								}
								ref byte second = ref *(byte*)(scriptName + 20);
								ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
								bool flag3 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref second, length);
								bool flag4 = !flag3;
								obj = 0;
								obj3 = 0;
								if (flag4)
								{
									continue;
								}
							}
							Transform transform = componentsInChildren[obj2].transform;
							if ((object)transform != null)
							{
								Vector3 position = transform.position;
								if (list != null)
								{
									list.Add(item);
									obj3 = obj;
									continue;
								}
							}
						}
					}
					goto IL_02e2;
				}
				goto IL_0311;
			}
		}
		list = null;
		goto IL_0311;
		IL_02e2:
		return (List<Vector2>)(object)new NullReferenceException();
		IL_0311:
		return list;
	}

	public unsafe List<SuperObject> GetScriptsFromName(string scriptName, string layerName = "Scripts")
	{
		//IL_0098: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_0127: Expected I8, but got O
		//IL_0239: Expected O, but got I8
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Ref, but got Unknown
		//IL_01b0: Expected I8, but got I4
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected Ref, but got Unknown
		//IL_01ec: Expected O, but got I4
		//IL_01f4: Expected O, but got I8
		//IL_01fd: Expected O, but got I4
		SuperMap defaultMap = DefaultMap;
		string text = default(string);
		SuperObjectLayer objectLayer = GetObjectLayer(defaultMap, text);
		List<SuperObject> list;
		if ((object)objectLayer != null && ((UnityEngine.Object)objectLayer).m_CachedPtr != (IntPtr)0)
		{
			SuperObject[] componentsInChildren = objectLayer.GetComponentsInChildren<SuperObject>();
			if (componentsInChildren == null)
			{
				goto IL_02b3;
			}
			if (componentsInChildren.Length != 0)
			{
				list = new List<SuperObject>();
				object obj = 0;
				object obj3;
				for (object obj2 = 0; (nint)obj2 < componentsInChildren.Length; obj2++, obj = obj3)
				{
					SuperObject superObject = componentsInChildren[obj2];
					if ((object)componentsInChildren[obj2] != null)
					{
						string tiledName = superObject.m_TiledName;
						if (superObject.m_TiledName != null)
						{
							bool flag = (object)superObject.m_TiledName == scriptName;
							ulong num = (ulong)(long)text;
							if (!flag)
							{
								bool flag2 = scriptName == null;
								obj3 = obj;
								if (flag2)
								{
									continue;
								}
								bool flag3 = tiledName._stringLength != scriptName._stringLength;
								obj3 = obj;
								if (flag3)
								{
									continue;
								}
								ref byte second = ref *(byte*)(scriptName + 20);
								num = (ulong)(tiledName._stringLength + tiledName._stringLength);
								bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref second, num);
								bool flag5 = !flag4;
								obj = 0;
								text = (string)num;
								obj3 = 0;
								if (flag5)
								{
									continue;
								}
							}
							if (list != null)
							{
								list._002Ector();
								text = (string)num;
								obj3 = obj;
								continue;
							}
						}
					}
					goto IL_02b3;
				}
				goto IL_02e2;
			}
		}
		list = null;
		goto IL_02e2;
		IL_02b3:
		return (List<SuperObject>)(object)new NullReferenceException();
		IL_02e2:
		return list;
	}

	public unsafe List<Rectangle> GetScriptRectangularLocations(string objectName, bool autoScaleAndOffset = false)
	{
		//IL_00f3: Expected O, but got I4
		//IL_0158: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_01fe: Expected I8, but got O
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_048a: Expected O, but got I8
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected Ref, but got Unknown
		//IL_0287: Expected I8, but got I4
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected Ref, but got Unknown
		//IL_02c3: Expected O, but got I4
		//IL_02cc: Expected O, but got I4
		//IL_02d4: Expected O, but got I8
		SuperMap defaultMap = DefaultMap;
		SuperObjectLayer objectLayer = GetObjectLayer(defaultMap, "Scripts");
		List<Rectangle> list;
		if ((object)objectLayer != null && ((UnityEngine.Object)objectLayer).m_CachedPtr != (IntPtr)0)
		{
			SuperObject[] componentsInChildren = objectLayer.GetComponentsInChildren<SuperObject>();
			if (componentsInChildren != null)
			{
				if (componentsInChildren.Length == 0)
				{
					list = new List<Rectangle>();
					goto IL_05cf;
				}
				list = new List<Rectangle>();
				SuperMap defaultMap2 = DefaultMap;
				if ((object)defaultMap2 != null)
				{
					SuperMap defaultMap3 = DefaultMap;
					if ((object)defaultMap3 != null)
					{
						object obj = defaultMap2.m_Width * defaultMap3.m_TileWidth;
						SuperMap defaultMap4 = DefaultMap;
						if ((object)defaultMap4 != null)
						{
							SuperMap defaultMap5 = DefaultMap;
							if ((object)defaultMap5 != null)
							{
								object obj2 = defaultMap4.m_Height * defaultMap5.m_TileHeight;
								object obj3 = 0;
								ref byte reference = ref *(byte*)null;
								object obj4 = 0;
								string text = "Scripts";
								object obj5;
								object obj7 = default(object);
								for (; (nint)obj3 < componentsInChildren.Length; obj3++, obj4 = obj5)
								{
									SuperObject superObject = componentsInChildren[obj3];
									if ((object)componentsInChildren[obj3] != null)
									{
										string tiledName = superObject.m_TiledName;
										if (superObject.m_TiledName != null)
										{
											bool flag = (object)superObject.m_TiledName == objectName;
											ulong num = (ulong)(long)text;
											if (!flag)
											{
												bool flag2 = objectName == null;
												obj5 = obj4;
												if (flag2)
												{
													continue;
												}
												bool flag3 = tiledName._stringLength != objectName._stringLength;
												obj5 = obj4;
												if (flag3)
												{
													continue;
												}
												reference = ref *(byte*)(objectName + 20);
												num = (ulong)(tiledName._stringLength + tiledName._stringLength);
												bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref reference, num);
												bool flag5 = !flag4;
												obj4 = 0;
												obj5 = 0;
												text = (string)num;
												if (flag5)
												{
													continue;
												}
											}
											bool flag6 = (byte)(~(_visuallyInverted ? 1u : 0u)) != 0;
											float x = superObject.m_X;
											float y;
											float num3;
											if (!flag6)
											{
												float num2 = (float)obj - superObject.m_X;
												num3 = num2 - superObject.m_Width;
												object obj6 = obj2 - superObject.m_Y;
												y = (float)obj6 - superObject.m_Height;
											}
											else
											{
												y = superObject.m_Y;
												num3 = superObject.m_X;
											}
											float width = superObject.m_Width;
											Rectangle rectangle = new Rectangle();
											bool flag7 = !autoScaleAndOffset;
											rectangle._x = num3;
											rectangle._y = y;
											rectangle._width = superObject.m_Width;
											rectangle._height = superObject.m_Height;
											if (!flag7)
											{
												Vector2 defaultMapPosition = DefaultMapPosition;
												float num4 = num3 * 0.01f;
												num3 = num4 + (float)defaultMapPosition;
												rectangle._x = num3;
												Vector2 defaultMapPosition2 = DefaultMapPosition;
												float num5 = rectangle._y * 0.01f;
												float num6 = num5 + (float)obj7;
												width = num6 ^ -0f;
												rectangle._y = width;
												float width2 = rectangle._width * 0.01f;
												rectangle._width = width2;
												float num7 = (rectangle._height *= 0.01f);
												x = rectangle._y - num7;
												rectangle._y = x;
											}
											if (list != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4C30");
												reference = ref *(byte*)rectangle;
												obj5 = obj4;
												text = (string)num;
												continue;
											}
										}
									}
									goto IL_0516;
								}
								goto IL_05cf;
							}
						}
					}
				}
			}
			goto IL_0516;
		}
		return new List<Rectangle>();
		IL_0516:
		return (List<Rectangle>)(object)new NullReferenceException();
		IL_05cf:
		return list;
	}

	public Tilemap GetTilemapLayer(string layerName)
	{
		SuperMap defaultMap = DefaultMap;
		SuperTileLayer superTileLayer = GetSuperTileLayer(defaultMap, layerName);
		if ((object)superTileLayer != null && ((UnityEngine.Object)superTileLayer).m_CachedPtr != (IntPtr)0)
		{
			return superTileLayer.GetComponent<Tilemap>();
		}
		return null;
	}

	public unsafe SuperTileLayer GetSuperTileLayer(SuperMap map, string layerName)
	{
		//IL_002f: Expected O, but got Ref
		List<SuperTileLayer> list = _cachedMapSuperTilesLayers.get_Item(map);
		List<SuperTileLayer>.Enumerator enumerator = default(List<SuperTileLayer>.Enumerator);
		if (enumerator.MoveNext())
		{
			SuperTileLayer superTileLayer = null;
			List<SuperTileLayer>.Enumerator enumerator2 = (List<SuperTileLayer>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe SuperTile GetSpawningLayerTile(float posX, float posY)
	{
		//IL_009b: Expected O, but got Ref
		//IL_0180->IL00a9: Incompatible stack heights: 2 vs 0
		//IL_0089->IL00a9: Incompatible stack heights: 2 vs 0
		//IL_00a4->IL00a4: Incompatible stack heights: 2 vs 0
		SuperMap defaultMap = DefaultMap;
		Tilemap tilemap = _cachedSpawningTilemap.get_Item(defaultMap);
		if ((object)tilemap != null && ((UnityEngine.Object)tilemap).m_CachedPtr != (IntPtr)0)
		{
			bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			Vector3 worldPosition = default(Vector3);
			GridLayout.WorldToCell_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref worldPosition, out Vector3Int _);
			bool flag2 = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			Vector3Int position = default(Vector3Int);
			IntPtr tileAsset_Injected = Tilemap.GetTileAsset_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref position);
			UnityEngine.Object obj = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<UnityEngine.Object>(tileAsset_Injected);
			if ((object)obj != null && obj.m_CachedPtr != (IntPtr)0)
			{
				return tilemap.GetTile<SuperTile>((Vector3Int)(&position));
			}
		}
		return null;
	}

	public List<Tilemap> GetAllLayers(List<string> excludeLayers = null)
	{
		bool flag = excludeLayers != null;
		List<string> list = excludeLayers;
		if (!flag)
		{
			List<string> list2 = new List<string>();
			list = list2;
		}
		List<Tilemap> result = new List<Tilemap>();
		List<SuperMap>.Enumerator enumerator = default(List<SuperMap>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe void SetAllLayersAlpha(float alpha)
	{
		//IL_0091->IL00b2: Incompatible stack heights: 2 vs 0
		List<Tilemap> allLayers = GetAllLayers();
		List<Tilemap>.Enumerator enumerator = default(List<Tilemap>.Enumerator);
		object value = default(object);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v5 (System.Object)+10]");
			Tilemap.get_color_Injected((IntPtr)0, out Color _);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v5 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v5 (System.Object)+10]");
			Tilemap.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
		}
	}

	public unsafe void FadeAllLayers(float alpha, float durationMillis, Action onComplete = null)
	{
		//IL_0218: Expected I, but got O
		//IL_0062: Expected I, but got O
		//IL_00fa: Expected I, but got O
		//IL_028f: Expected I, but got O
		//IL_02a5: Expected O, but got I
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_01ce: Expected I, but got O
		//IL_02d9: Expected O, but got I4
		//IL_02f0: Expected I, but got I8
		//IL_01aa: Expected I, but got I8
		_003C_003Ec__DisplayClass62_0 obj = new _003C_003Ec__DisplayClass62_0();
		bool flag = obj == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass62_0);
		Sequence sequence;
		TweenCallback tweenCallback;
		if (!flag)
		{
			obj.onComplete = onComplete;
			List<Tilemap> allLayers = GetAllLayers();
			sequence = DOTween.Sequence();
			bool flag2 = allLayers == null;
			num = unchecked((nint)null);
			if (!flag2)
			{
				List<Tilemap>.Enumerator enumerator = default(List<Tilemap>.Enumerator);
				while (enumerator.MoveNext())
				{
					float duration = durationMillis * 0.001f;
					Tweener t = VampireSurvivors.Tools.TweenExtensions.DOFade(null, alpha, duration);
					if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
					{
						Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
				bool flag3 = (nint)0 != 0;
				num = (nint)(&enumerator);
				if (!flag3)
				{
					_ = 1;
					num = unchecked((nint)"DefaultGameTweenId");
				}
				if (sequence != null)
				{
					sequence.stringId = "DefaultGameTweenId";
					if (obj.onComplete == null)
					{
						return;
					}
					tweenCallback = null;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ r10_v2 (Il2CppMethodInfo)+8]");
					((Delegate)tweenCallback).method_ptr = (IntPtr)0;
					((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass62_0._003CFadeAllLayers_003Eb__0);
					((Delegate)tweenCallback).m_target = obj;
					((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ r10_v2 (Il2CppMethodInfo)+4C]");
					object obj2 = (nint)0 >> 4;
					object obj3 = obj2 & 1;
					nint num3;
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ r10_v2 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num3 = unchecked((nint)6447293664L);
							goto IL_02d0;
						}
					}
					num3 = ((Delegate)tweenCallback).method_ptr;
					((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
					goto IL_02d0;
				}
			}
		}
		throw new NullReferenceException();
		IL_02d0:
		object obj4 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = tweenCallback;
		}
	}

	public unsafe void TintAllLayers(Color tint, float durationMillis, Action onComplete = null)
	{
		//IL_0233: Expected O, but got Ref
		//IL_00b7: Expected F4, but got I4
		//IL_02c7: Expected I, but got O
		//IL_02dd: Expected O, but got I
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_01a1: Expected I, but got O
		//IL_0311: Expected O, but got I4
		//IL_0328: Expected I, but got I8
		//IL_017d: Expected I, but got I8
		//IL_0267->IL026c: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL026c: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass63_0 obj = new _003C_003Ec__DisplayClass63_0();
		Sequence sequence;
		TweenCallback tweenCallback;
		if (obj != null)
		{
			Action onComplete2 = default(Action);
			obj.onComplete = onComplete2;
			List<Tilemap> allLayers = GetAllLayers();
			sequence = DOTween.Sequence();
			if (allLayers != null)
			{
				float num = durationMillis;
				List<Tilemap>.Enumerator enumerator = default(List<Tilemap>.Enumerator);
				float num2 = default(float);
				while (enumerator.MoveNext())
				{
					TilingTileset tilingTileset = null;
					bool flag = ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0;
					Tilemap.get_color_Injected(((UnityEngine.Object)tilingTileset).m_CachedPtr, out Color _);
					num = durationMillis * 0.001f;
					Tweener t = VampireSurvivors.Tools.TweenExtensions.DoTint(null, (Color)(&num2), num);
					bool flag2 = TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false);
					bool flag3 = !flag2;
					onComplete2 = null;
					if (!flag3)
					{
						Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
						num = 0f;
						onComplete2 = null;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (sequence != null)
				{
					sequence.stringId = "DefaultGameTweenId";
					if (obj.onComplete == null)
					{
						return;
					}
					tweenCallback = null;
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ r10_v2 (Il2CppMethodInfo)+8]");
					((Delegate)tweenCallback).method_ptr = (IntPtr)0;
					((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass63_0._003CTintAllLayers_003Eb__0);
					((Delegate)tweenCallback).m_target = obj;
					((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ r10_v2 (Il2CppMethodInfo)+4C]");
					object obj2 = (nint)0 >> 4;
					object obj3 = obj2 & 1;
					nint num4;
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ r10_v2 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num4 = unchecked((nint)6447293664L);
							goto IL_0308;
						}
					}
					num4 = ((Delegate)tweenCallback).method_ptr;
					((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
					goto IL_0308;
				}
			}
		}
		throw new NullReferenceException();
		IL_0308:
		object obj4 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = tweenCallback;
		}
	}

	public bool IsPointWithinCollisionLayer(Vector2 spawnPoint)
	{
		//IL_0026: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		SuperMap defaultMap = DefaultMap;
		List<PhaserTilemap> list = _cachedCollisionTilemaps.get_Item(defaultMap);
		object obj = 0;
		object obj2 = 0;
		float2 position = default(float2);
		while (true)
		{
			if ((nint)obj < list._size)
			{
				if ((nint)obj2 >= list._size)
				{
					break;
				}
				PhaserTilemap[] items = list._items;
				if (!items[obj2].IsTileAtPosition(position))
				{
					obj2++;
					obj = obj2;
					continue;
				}
				return true;
			}
			return false;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	public bool IsPointWithinCollisionLayerWrapped(Vector2 spawnPoint)
	{
		//IL_002c: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_01f6: Expected O, but got I
		//IL_0210: Expected I, but got O
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		SuperMap defaultMap = DefaultMap;
		List<PhaserTilemap> list = _cachedCollisionTilemaps.get_Item(defaultMap);
		nint num = 0;
		object obj = 0;
		object obj2 = 0;
		SuperMap key = default(SuperMap);
		object obj6 = default(object);
		while (true)
		{
			if ((nint)obj < list._size)
			{
				if ((nint)obj2 >= list._size)
				{
					break;
				}
				PhaserTilemap[] items = list._items;
				PhaserTilemap phaserTilemap = items[obj2];
				Dictionary<SuperMap, List<PhaserTilemap>> dictionary = (Dictionary<SuperMap, List<PhaserTilemap>>)(items[obj2] + 192);
				List<PhaserTilemap> list2 = dictionary.get_Item(key);
				object obj3 = (object)list2 - (object)phaserTilemap._bounds;
				object obj4 = (object)phaserTilemap._bounds >> 32;
				object obj5 = obj6 - obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rsi_v7 (PhaserTilemap)+74]");
				object obj7 = obj3 % 0;
				bool flag = (nint)obj7 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rsi_v7 (PhaserTilemap)+74]");
				object obj8 = obj7 + 0;
				if (!flag)
				{
					obj8 = obj7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rsi_v7 (PhaserTilemap)+74]");
				object obj9 = (nint)0 >> 32;
				object obj10 = obj5 % obj9;
				num = (nint)phaserTilemap._phaserTiles;
				object obj11 = obj9 + obj10;
				if ((nint)obj10 >= 0)
				{
					obj11 = obj10;
				}
				object obj12 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rsi_v7 (PhaserTilemap)+74]");
				object obj13 = obj12 * 0;
				object obj14 = obj13 + obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r8_v5 (Il2CppMethodInfo)+20+v200 @ rcx_v20*8]");
				if ((nint)0 <= (nint)0)
				{
					obj2++;
					obj = obj2;
					continue;
				}
				return true;
			}
			return false;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	public unsafe bool HasEmptyFloorTile(Vector2 point)
	{
		//IL_013c: Expected O, but got Ref
		//IL_00a0->IL0167: Incompatible stack heights: 1 vs 0
		//IL_008d->IL00d5: Incompatible stack heights: 1 vs 0
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		Tilemap tilemap = default(Tilemap);
		Vector3 worldPosition = default(Vector3);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			if ((object)tilemap != null && ((UnityEngine.Object)tilemap).m_CachedPtr != (IntPtr)0)
			{
				bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
				GridLayout.WorldToCell_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref worldPosition, out Vector3Int _);
				TileBase tile = tilemap.GetTile((Vector3Int)(&obj));
				if ((object)tile == null || ((UnityEngine.Object)tile).m_CachedPtr == (IntPtr)0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public unsafe TileBase GetTileAtPosition(Vector2 point)
	{
		//IL_0127: Expected O, but got Ref
		//IL_014d->IL00c0: Incompatible stack heights: 1 vs 0
		//IL_008a->IL00c0: Incompatible stack heights: 1 vs 0
		//IL_008f->IL0152: Incompatible stack heights: 1 vs 0
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		TileBase tileBase;
		Tilemap tilemap = default(Tilemap);
		Vector3 worldPosition = default(Vector3);
		object obj = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				tileBase = null;
				break;
			}
			if ((object)tilemap != null && ((UnityEngine.Object)tilemap).m_CachedPtr != (IntPtr)0)
			{
				bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
				GridLayout.WorldToCell_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref worldPosition, out Vector3Int _);
				tileBase = tilemap.GetTile((Vector3Int)(&obj));
				if ((object)tileBase != null && ((UnityEngine.Object)tileBase).m_CachedPtr != (IntPtr)0)
				{
					break;
				}
			}
		}
		return tileBase;
	}

	public unsafe PickupMerchant SpawnMerchant()
	{
		//IL_00a1: Expected O, but got I4
		//IL_013e: Expected I8, but got O
		//IL_0258: Expected O, but got I8
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected Ref, but got Unknown
		//IL_01cc: Expected I8, but got I4
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Ref, but got Unknown
		//IL_0208: Expected O, but got I4
		//IL_0219: Expected O, but got I4
		//IL_0221: Expected O, but got I8
		//IL_0329: Expected I, but got O
		//IL_0337: Expected I, but got O
		//IL_0347: Expected O, but got I
		//IL_0383: Expected O, but got I
		SuperMap defaultMap = DefaultMap;
		SuperObjectLayer objectLayer = GetObjectLayer(defaultMap, "Scripts");
		if ((object)objectLayer != null && ((UnityEngine.Object)objectLayer).m_CachedPtr != (IntPtr)0)
		{
			SuperObject[] componentsInChildren = objectLayer.GetComponentsInChildren<SuperObject>();
			if (componentsInChildren == null)
			{
				goto IL_042c;
			}
			if (componentsInChildren.Length != 0)
			{
				object obj = "MRC";
				SuperObject superObject = null;
				Pickup pickup = null;
				nint num = 0;
				object obj2 = 0;
				string text = "Scripts";
				object obj3;
				for (Pickup pickup2 = null; (nint)pickup2 < componentsInChildren.Length; pickup = (Pickup)(pickup + 1), obj2 = obj3, pickup2 = pickup)
				{
					SuperObject superObject2 = componentsInChildren[(object)pickup];
					if ((object)componentsInChildren[(object)pickup] != null)
					{
						string tiledName = superObject2.m_TiledName;
						if (superObject2.m_TiledName != null)
						{
							bool flag = (object)superObject2.m_TiledName == "MRC";
							ref byte reference = ref *(byte*)num;
							ulong num2 = (ulong)(long)text;
							if (!flag)
							{
								bool flag2 = "MRC" == null;
								obj3 = obj2;
								if (flag2)
								{
									continue;
								}
								int stringLength = tiledName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rsi_v5+10]");
								bool flag3 = (nint)stringLength != 0;
								obj3 = obj2;
								if (flag3)
								{
									continue;
								}
								reference = ref *(byte*)("MRC" + 20);
								num2 = (ulong)(tiledName._stringLength + tiledName._stringLength);
								bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject2.m_TiledName + 20), ref reference, num2);
								bool flag5 = !flag4;
								obj2 = 0;
								num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
								obj3 = 0;
								text = (string)num2;
								if (flag5)
								{
									continue;
								}
							}
							superObject = componentsInChildren[(object)pickup];
							num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
							obj3 = obj2;
							text = (string)num2;
							continue;
						}
					}
					goto IL_042c;
				}
				if ((object)superObject != null && ((UnityEngine.Object)superObject).m_CachedPtr != (IntPtr)0)
				{
					SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
					Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
					if ((object)_gameManager != null)
					{
						float value = default(float);
						ItemType relicType = default(ItemType);
						bool validatePickups = default(bool);
						Pickup pickup3 = _gameManager.MakeStagePickup(spawnPosFromSuperObject, ItemType.MERCHANT, WeaponType.VOID, value, relicType, validatePickups);
						bool flag6 = (object)pickup3 == null;
						PickupMerchant result = null;
						if (!flag6)
						{
							nint num3 = (nint)pickup3;
							nint num4 = (nint)typeof(PickupMerchant);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchant>)+130]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchant>)+130]");
							if (num5 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ rax_v29+FFFFFFF8+v631 @ rax_v26*8]");
								if (0 == (nint)typeof(PickupMerchant))
								{
									Pickup pickup4 = null;
									return (PickupMerchant)pickup3;
								}
							}
							result = null;
						}
						return result;
					}
					goto IL_042c;
				}
			}
		}
		return null;
		IL_042c:
		return (PickupMerchant)(object)new NullReferenceException();
	}

	public void pianificami()
	{
	}

	public unsafe void spianami()
	{
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected Ref, but got Unknown
		//IL_01bf: Expected I8, but got I
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected Ref, but got Unknown
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._spawnType = SpawnType.STANDARD;
		List<SuperMap> maps = _maps;
		SpawnType spawnType = SpawnType.STANDARD;
		SpawnType spawnType2 = SpawnType.STANDARD;
		int height = default(int);
		while (true)
		{
			if ((int)spawnType2 >= maps._size)
			{
				return;
			}
			List<SuperMap> maps2 = _maps;
			if ((int)spawnType >= maps2._size)
			{
				break;
			}
			SuperMap[] items = maps2._items;
			List<SuperTileLayer> list = _cachedMapSuperTilesLayers.get_Item(items[(int)spawnType]);
			for (SuperMap superMap = null; (nint)superMap < list._size; superMap = (SuperMap)(superMap + 1))
			{
				List<SuperTileLayer> list2 = ((Dictionary<SuperMap, List<SuperTileLayer>>)(object)list).get_Item(superMap);
				object syncRoot = list2._syncRoot;
				object obj = "Floor";
				if (list2._syncRoot == "Floor")
				{
					continue;
				}
				if (list2._syncRoot != null && "Floor" != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rcx_v14 (System.Object)+10]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rdx_v9+10]");
					if (num == 0)
					{
						ref byte second = ref *(byte*)("Floor" + 20);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rcx_v14 (System.Object)+10]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rcx_v14 (System.Object)+10]");
						ulong length = (ulong)(num2 + 0);
						if (System.SpanHelpers.SequenceEqual(ref *(byte*)(list2._syncRoot + 20), ref second, length))
						{
							continue;
						}
					}
				}
				Tilemap component = ((Component)(object)list2).GetComponent<Tilemap>();
				Tilemap tilemap = TilemapExtensions.RemoveTilesWithin(component, 0, 0, 64, height);
				Tilemap tilemap2 = TilemapExtensions.RemoveTilesWithin(component, 0, 34, 64, height);
				PhaserTilemap component2 = component.GetComponent<PhaserTilemap>();
				if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
				{
					component2.RefreshData();
				}
			}
			maps = _maps;
			spawnType++;
			spawnType2 = spawnType;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public List<PhaserTilemap> GetPhaserTilemaps()
	{
		return _phaserTilemaps;
	}

	public void SetTilemapCollisionsEnabled(bool isEnabled)
	{
		List<PhaserTilemap>.Enumerator enumerator = default(List<PhaserTilemap>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
		}
	}

	private void UpdateInversionBool()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = _stageType == StageType.STAGEX;
		_inverted = config._003CSelectedInverse_003Ek__BackingField;
		if (flag || _stageType == StageType.MACHINE)
		{
			_inverted = false;
		}
		if (_inverted)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				Stage stage = _stage;
				StageData stageData = stage._stageData;
				bool flag2 = !stageData._003CallowVisualInversion_003Ek__BackingField;
				bool visuallyInverted = !flag2;
				_visuallyInverted = visuallyInverted;
				return;
			}
		}
		_visuallyInverted = true;
	}

	private void HandleInversion(SuperMap map, StageType type)
	{
		//IL_0082: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01af->IL0209: Incompatible stack heights: 5 vs 0
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (!stageData._003CisRacingStage_003Ek__BackingField)
		{
			GameObject gameObject = map.gameObject;
			SuperLayer[] componentsInChildren = gameObject.GetComponentsInChildren<SuperLayer>(includeInactive: true);
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			Vector3 value2 = default(Vector3);
			while ((nint)obj2 < componentsInChildren.Length)
			{
				SuperLayer superLayer = componentsInChildren[obj];
				bool flag = ((UnityEngine.Object)superLayer).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)superLayer).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
				obj++;
				obj2 = obj;
			}
		}
	}

	private void HandleNonInversionTint(List<SuperTileLayer> layers, StageData data)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0147: Expected O, but got I
		//IL_01a3->IL01e1: Incompatible stack heights: 1 vs 0
		//IL_01e1->IL0188: Incompatible stack heights: 2 vs 1
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		Color value = default(Color);
		while ((nint)obj2 < layers._size)
		{
			bool flag = (nint)obj >= layers._size;
			SuperTileLayer[] items = layers._items;
			Component component = items[obj];
			while ((object)items[obj] != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				Tilemap component2 = items[obj].GetComponent<Tilemap>();
				object obj3;
				if (data._003Ctileset_003Ek__BackingField != null)
				{
					Tileset tileset = data._003Ctileset_003Ek__BackingField;
					if ((object)tileset._003Ctint_003Ek__BackingField != null)
					{
						if ((object)tileset._003Ctint_003Ek__BackingField != null)
						{
							obj3 = obj4;
							goto IL_01a3;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				obj3 = 0;
				goto IL_01a3;
				IL_01a3:
				bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				Tilemap.set_color_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
				value = (Color)obj3;
				break;
			}
			obj++;
			obj2 = obj;
		}
	}

	private void HandleInversionTint(List<SuperTileLayer> layers, StageData data)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0147: Expected O, but got I
		//IL_01a3->IL01e1: Incompatible stack heights: 1 vs 0
		//IL_01e1->IL0188: Incompatible stack heights: 2 vs 1
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		Color value = default(Color);
		while ((nint)obj2 < layers._size)
		{
			bool flag = (nint)obj >= layers._size;
			SuperTileLayer[] items = layers._items;
			Component component = items[obj];
			while ((object)items[obj] != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				Tilemap component2 = items[obj].GetComponent<Tilemap>();
				object obj3;
				if (data._003Cinverse_003Ek__BackingField != null)
				{
					StageModifiers stageModifiers = data._003Cinverse_003Ek__BackingField;
					if ((object)stageModifiers._003Ctint_003Ek__BackingField != null)
					{
						if ((object)stageModifiers._003Ctint_003Ek__BackingField != null)
						{
							obj3 = obj4;
							goto IL_01a3;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				obj3 = 0;
				goto IL_01a3;
				IL_01a3:
				bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				Tilemap.set_color_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
				value = (Color)obj3;
				break;
			}
			obj++;
			obj2 = obj;
		}
	}

	private unsafe void GenerateMaps()
	{
		//IL_0074: Expected I4, but got O
		//IL_013a: Expected I4, but got O
		//IL_02a2: Expected O, but got I4
		//IL_11f2: Expected O, but got I4
		//IL_02b9: Expected O, but got I4
		//IL_02fe: Expected O, but got I
		//IL_12b7: Expected O, but got I4
		//IL_0356: Expected I, but got O
		//IL_0387: Expected O, but got I
		//IL_0483: Expected I4, but got O
		//IL_0536: Expected O, but got Ref
		//IL_1262: Expected I, but got O
		//IL_128c: Expected O, but got I
		//IL_03cb: Expected I, but got O
		//IL_043b: Expected F4, but got I4
		//IL_0449: Expected I, but got O
		//IL_077e: Expected O, but got Ref
		//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de0: Expected O, but got Unknown
		//IL_0b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b70: Expected O, but got Unknown
		//IL_0ef8: Expected O, but got Ref
		//IL_0c7b: Expected O, but got I
		//IL_0f15: Expected F4, but got I
		//IL_0f1b: Expected O, but got I
		//IL_14e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ed: Expected O, but got Unknown
		//IL_1505: Expected O, but got I4
		//IL_150d: Expected O, but got Ref
		//IL_0cfe: Expected O, but got I
		//IL_0a0b: Expected O, but got I
		//IL_0f2f: Expected O, but got F4
		//IL_0d3d: Expected O, but got I
		//IL_0f5a: Invalid comparison between F4 and I4
		//IL_0d6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d70: Expected Ref, but got Unknown
		//IL_0d8d: Expected I8, but got I
		//IL_0db3: Expected O, but got I8
		//IL_0dc4: Expected O, but got I8
		//IL_0a8e: Expected O, but got I
		//IL_0f7e: Expected O, but got I
		//IL_0acd: Expected O, but got I
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b00: Expected Ref, but got Unknown
		//IL_0b1d: Expected I8, but got I
		//IL_0b43: Expected O, but got I8
		//IL_0b54: Expected O, but got I8
		//IL_100a: Expected O, but got F4
		Dictionary<SuperMap, List<PhaserTilemap>> phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_phaserTilemaps;
		CustomProperty customProperty;
		GameObject tilesetSupportPrefabInternal;
		object obj3;
		Material material;
		Material material2;
		GameManager core;
		nint num4;
		Transform transform;
		if (_phaserTilemaps != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v100 (System.Collections.Generic.Dictionary`2<SuperTiled2Unity.SuperMap, System.Collections.Generic.List`1<PhaserTilemap>>)+1C]");
			_ = (nint)0 + (nint)1;
			phaserTilemaps._entries = null;
			if ((nint)phaserTilemaps._entries > 0)
			{
				Array.Clear(phaserTilemaps._buckets, 0, (int)phaserTilemaps._entries);
			}
			phaserTilemaps = _cachedCollisionTilemaps;
			if (_cachedCollisionTilemaps != null)
			{
				_cachedCollisionTilemaps.Clear();
				Stage stage = _stage;
				if ((object)_stage != null)
				{
					StageData stageData = stage._stageData;
					if (stage._stageData != null)
					{
						System.Int32Enum int32Enum = (((object)stageData._003CtilesetStageType_003Ek__BackingField == null) ? ((System.Int32Enum)_stageType) : ((System.Int32Enum)((object?)stageData._003CtilesetStageType_003Ek__BackingField >> 32)));
						TilesetFactory tilesetFactory = _tilesetFactory;
						if ((object)_tilesetFactory != null)
						{
							bool flag = tilesetFactory._mapInstances == null;
							phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)tilesetFactory._mapInstances;
							if (!flag)
							{
								int num = ((Dictionary<System.Int32Enum, object>)(object)tilesetFactory._mapInstances).FindEntry(int32Enum);
								if (!flag)
								{
									bool flag2 = tilesetFactory._mapInstances == null;
									phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)tilesetFactory._mapInstances;
									if (flag2)
									{
										goto IL_10cb;
									}
									object obj = ((Dictionary<System.Int32Enum, object>)(object)tilesetFactory._mapInstances).get_Item(int32Enum);
									customProperty = (CustomProperty)obj;
								}
								else
								{
									customProperty = null;
								}
								bool flag3 = (object)_tilesetFactory == null;
								phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_tilesetFactory;
								if (!flag3)
								{
									tilesetSupportPrefabInternal = _tilesetFactory.GetTilesetSupportPrefabInternal((StageType)int32Enum, (Action<GameObject>)null);
									Stage stage2 = _stage;
									bool flag4 = (object)_stage == null;
									phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_tilesetFactory;
									if (!flag4)
									{
										StageData stageData2 = stage2._stageData;
										bool flag5 = stage2._stageData == null;
										phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_tilesetFactory;
										if (!flag5)
										{
											phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)stageData2._003Ctileset_003Ek__BackingField;
											if (stageData2._003Ctileset_003Ek__BackingField != null)
											{
												bool flag6 = phaserTilemaps._comparer != null;
												object obj2 = 4;
												if (!flag6)
												{
													obj2 = 1;
												}
												Stage stage3 = _stage;
												StageData stageData3 = stage3._stageData;
												Tileset tileset = stageData3._003Ctileset_003Ek__BackingField;
												Stage stage4 = _stage;
												StageData stageData4 = stage4._stageData;
												bool flag7 = tileset._003CisHorizontalRoad_003Ek__BackingField;
												obj3 = 2;
												if (!flag7)
												{
													obj3 = obj2;
												}
												bool flag8 = !stageData4._003ChasLights_003Ek__BackingField;
												material = null;
												material2 = null;
												if (!flag8)
												{
													Material material3 = Resources.Load<Material>("LitTilemap");
													material = material3;
													material2 = material3;
												}
												phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_stage;
												if ((object)_stage != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v100 (System.Collections.Generic.Dictionary`2<SuperTiled2Unity.SuperMap, System.Collections.Generic.List`1<PhaserTilemap>>)+70]");
													object obj4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v100 (System.Collections.Generic.Dictionary`2<SuperTiled2Unity.SuperMap, System.Collections.Generic.List`1<PhaserTilemap>>)+70]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rdx_v15+10F]");
														if ((nint)0 == 0)
														{
															transform = null;
															Action<GameObject> action = null;
															goto IL_12a9;
														}
														nint num2 = (nint)typeof(GM);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v755 @ rax_v198 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
														nint num3 = 0;
														core = GM.Core;
														bool flag9 = (object)GM.Core == null;
														phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)num3;
														if (!flag9)
														{
															Light2D globalLight = core._GlobalLight;
															bool flag10 = (object)core._GlobalLight == null;
															num4 = (nint)typeof(UnityEngine.Object);
															Action<GameObject> action;
															if (!flag10)
															{
																bool flag11 = ((UnityEngine.Object)globalLight).m_CachedPtr == (IntPtr)0;
																num4 = (nint)typeof(UnityEngine.Object);
																if (!flag11)
																{
																	bool flag12 = (object)core._GlobalLight == null;
																	phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)core._GlobalLight;
																	if (flag12)
																	{
																		goto IL_10cb;
																	}
																	GameObject gameObject = core._GlobalLight.gameObject;
																	UnityEngine.Object.Destroy(gameObject, 0f);
																	float num5 = 0f;
																	action = null;
																	num4 = (nint)gameObject;
																	goto IL_1275;
																}
															}
															action = null;
															goto IL_1275;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_10cb;
		IL_10cb:
		throw new NullReferenceException();
		IL_1275:
		core._GlobalLight = null;
		transform = null;
		phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)num4;
		goto IL_12a9;
		IL_12a9:
		CustomProperty customProperty2 = null;
		List<SuperTileLayer>.Enumerator enumerator = (List<SuperTileLayer>.Enumerator)0;
		Material material4 = material2;
		CustomProperty customProperty3 = customProperty;
		CustomProperty customProperty4 = default(CustomProperty);
		object obj6 = default(object);
		object obj7 = default(object);
		List<SuperTileLayer>.Enumerator enumerator2 = default(List<SuperTileLayer>.Enumerator);
		List<SuperTileLayer>.Enumerator enumerator3 = default(List<SuperTileLayer>.Enumerator);
		object key = default(object);
		object obj9 = default(object);
		object obj10 = default(object);
		Component component3 = default(Component);
		UnityEngine.Object obj13 = default(UnityEngine.Object);
		object obj14 = default(object);
		Component component5 = default(Component);
		SuperMap map = default(SuperMap);
		List<SuperTileLayer>.Enumerator enumerator4 = default(List<SuperTileLayer>.Enumerator);
		object obj17 = default(object);
		List<SuperTileLayer>.Enumerator enumerator5 = default(List<SuperTileLayer>.Enumerator);
		object obj19 = default(object);
		while (true)
		{
			List<object> list;
			System.Collections.Generic.InsertionBehavior insertionBehavior;
			CustomProperty customProperty7;
			if (System.Runtime.CompilerServices.Unsafe.As<CustomProperty, UIntPtr>(ref customProperty2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				CustomProperty customProperty5;
				if (customProperty2 != null)
				{
					Vector2 posByIndex = GetPosByIndex((int)customProperty2, (SuperMap)(object)customProperty3);
					Quaternion identityQuaternion = Quaternion.identityQuaternion;
					Transform transform2 = base.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
					bool flag13 = customProperty4 == null;
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)customProperty3;
					if (flag13)
					{
						break;
					}
					object obj5 = obj6;
					customProperty5 = customProperty4;
					transform = transform2;
				}
				else
				{
					if (customProperty3 == null)
					{
						break;
					}
					Transform transform3 = ((Component)(object)customProperty3).transform;
					Vector2 posByIndex2 = GetPosByIndex(0, (SuperMap)(object)customProperty3);
					transform3.position = (Vector3)(&obj7);
					Transform parent = base.transform;
					transform3.parent = parent;
					obj7 = obj6;
					customProperty5 = customProperty3;
				}
				GameObject gameObject2 = ((Component)(object)customProperty5).gameObject;
				bool flag14 = (object)gameObject2 == null;
				phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)customProperty5;
				if (flag14)
				{
					break;
				}
				SuperTileLayer[] componentsInChildren = gameObject2.GetComponentsInChildren<SuperTileLayer>(includeInactive: true);
				list = Enumerable.ToList((IEnumerable<object>)componentsInChildren);
				bool flag15 = (object)material2 == null;
				phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)typeof(UnityEngine.Object);
				if (!flag15)
				{
					bool flag16 = ((UnityEngine.Object)material4).m_CachedPtr == (IntPtr)0;
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)typeof(UnityEngine.Object);
					if (!flag16)
					{
						bool flag17 = list == null;
						phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)typeof(UnityEngine.Object);
						if (flag17)
						{
							break;
						}
						nint num6 = 0;
						while (enumerator2.MoveNext())
						{
							Component component = null;
						}
						phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(&enumerator2);
					}
				}
				if (!_inverted)
				{
					Stage stage5 = _stage;
					if ((object)_stage == null)
					{
						break;
					}
					HandleNonInversionTint((List<SuperTileLayer>)(object)list, stage5._stageData);
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)this;
				}
				else
				{
					if (_visuallyInverted && customProperty2 == null)
					{
						HandleInversion((SuperMap)(object)customProperty5, _stageType);
						phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)this;
					}
					Stage stage6 = _stage;
					if ((object)_stage == null)
					{
						break;
					}
					HandleInversionTint((List<SuperTileLayer>)(object)list, stage6._stageData);
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)this;
				}
				if (list == null)
				{
					break;
				}
				if (enumerator3.MoveNext())
				{
					Component component2 = null;
					throw new NullReferenceException();
				}
				bool flag18 = _maps == null;
				phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_maps;
				if (flag18)
				{
					break;
				}
				((List<object>)(object)_maps).Add((object)customProperty5);
				bool flag19 = _maps == null;
				phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_maps;
				if (flag19)
				{
					break;
				}
				_maps.Add((SuperMap)(object)customProperty2);
				bool flag20 = _cachedMapSuperTilesLayers == null;
				phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_maps;
				if (flag20)
				{
					break;
				}
				bool flag21 = ((Dictionary<object, object>)(object)_cachedMapSuperTilesLayers).TryInsert(key, (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				CustomProperty customProperty6 = null;
				insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
				object obj8 = list;
				while (true)
				{
					if ((nint)customProperty6 < list._size)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if (obj9 == null)
						{
							goto IL_0b62;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2551 @ rax_v103+10]");
						if ((nint)0 == 0)
						{
							goto IL_0b62;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag22 = obj10 == null;
						phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)list;
						if (flag22)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rax_v110+20]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rax_v110+20]");
						bool flag23 = (nint)0 == 0;
						phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)list;
						if (flag23)
						{
							break;
						}
						object obj12 = "Spawning";
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rax_v110+20]");
						bool flag24 = 0 == unchecked((nint)"Spawning");
						System.Collections.Generic.InsertionBehavior insertionBehavior2 = insertionBehavior;
						if (!flag24)
						{
							bool flag25 = "Spawning" == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rax_v110+20]");
							obj8 = 0;
							if (flag25)
							{
								goto IL_0b62;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ r8_v40 (System.Object)+10]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2861 @ rdx_v63+10]");
							bool flag26 = num7 != 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rax_v110+20]");
							obj8 = 0;
							if (flag26)
							{
								goto IL_0b62;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rax_v110+20]");
							ref byte first = ref *(byte*)((nint)0 + (nint)20);
							ref byte second = ref *(byte*)("Spawning" + 20);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ r8_v40 (System.Object)+10]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ r8_v40 (System.Object)+10]");
							ulong num9 = (ulong)(num8 + 0);
							bool flag27 = System.SpanHelpers.SequenceEqual(ref first, ref second, num9);
							insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
							obj8 = num9;
							insertionBehavior2 = System.Collections.Generic.InsertionBehavior.None;
							obj11 = num9;
							if (!flag27)
							{
								goto IL_0b62;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag28 = (object)component3 == null;
						phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)list;
						if (flag28)
						{
							break;
						}
						Tilemap component4 = component3.GetComponent<Tilemap>();
						bool flag29 = _cachedSpawningTilemap == null;
						phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)component3;
						if (flag29)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4C90");
						insertionBehavior = insertionBehavior2;
						obj8 = component4;
					}
					customProperty7 = null;
					goto IL_148a;
					IL_0b62:
					customProperty6 = (CustomProperty)(customProperty6 + 1);
				}
				break;
			}
			if ((object)tilesetSupportPrefabInternal != null && ((UnityEngine.Object)tilesetSupportPrefabInternal).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(tilesetSupportPrefabInternal);
				if (_supportMaps == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			}
			HandleArcadePhysics(_maps);
			return;
			IL_148a:
			while (true)
			{
				if ((nint)customProperty7 < list._size)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag30 = obj13 != null;
					bool flag31 = !flag30;
					object obj8 = null;
					if (flag31)
					{
						goto IL_0dd2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag32 = obj14 == null;
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)list;
					if (flag32)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v95+20]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v95+20]");
					bool flag33 = (nint)0 == 0;
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)list;
					if (flag33)
					{
						break;
					}
					object obj16 = "Floor";
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v95+20]");
					bool flag34 = 0 == unchecked((nint)"Floor");
					System.Collections.Generic.InsertionBehavior insertionBehavior3 = insertionBehavior;
					if (!flag34)
					{
						bool flag35 = "Floor" == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v95+20]");
						obj8 = 0;
						if (flag35)
						{
							goto IL_0dd2;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r8_v34 (System.Object)+10]");
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2911 @ rdx_v54+10]");
						bool flag36 = num10 != 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v95+20]");
						obj8 = 0;
						if (flag36)
						{
							goto IL_0dd2;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v95+20]");
						ref byte first2 = ref *(byte*)((nint)0 + (nint)20);
						ref byte second2 = ref *(byte*)("Floor" + 20);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r8_v34 (System.Object)+10]");
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r8_v34 (System.Object)+10]");
						ulong num12 = (ulong)(num11 + 0);
						bool flag37 = System.SpanHelpers.SequenceEqual(ref first2, ref second2, num12);
						insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
						obj8 = num12;
						insertionBehavior3 = System.Collections.Generic.InsertionBehavior.None;
						obj15 = num12;
						if (!flag37)
						{
							goto IL_0dd2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag38 = (object)component5 == null;
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)list;
					if (flag38)
					{
						break;
					}
					Tilemap component6 = component5.GetComponent<Tilemap>();
					bool flag39 = _cachedFloorLayers == null;
					phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)component5;
					if (flag39)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4C90");
					insertionBehavior = insertionBehavior3;
					obj8 = component6;
				}
				phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)_maps;
				if (_maps == null)
				{
					break;
				}
				goto IL_0e90;
				IL_0dd2:
				customProperty7 = (CustomProperty)(customProperty7 + 1);
			}
			break;
			IL_0e90:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			HandleSortingOrders(map);
			List<string> list2 = new List<string>();
			bool flag40 = list2 == null;
			phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(object)list2;
			if (flag40)
			{
				break;
			}
			list2.Add("Guides");
			((List<string>)(&enumerator4)).Add((string)(object)list);
			enumerator = (List<SuperTileLayer>.Enumerator)obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2980 @ rax_v80+10]");
			float num5 = 0f;
			Action<GameObject> action = (Action<GameObject>)0;
			while (enumerator5.MoveNext())
			{
				bool flag41 = (UnityEngine.Object)num5 != null;
				bool flag42 = !flag41;
				action = null;
				if (flag42)
				{
					continue;
				}
				if (num5 != 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1377 @ xmm1_v14 (System.Single)+20]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1377 @ xmm1_v14 (System.Single)+20]");
					bool flag43 = (nint)0 == 0;
					action = null;
					if (flag43)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3063 @ rax_v86+10]");
					bool flag44 = (nint)0 <= (nint)0;
					action = null;
					if (flag44)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
					bool flag45 = obj19 == null;
					action = null;
					if (!flag45)
					{
						GameObject gameObject4 = ((Component)num5).gameObject;
						if ((object)gameObject4 == null)
						{
							throw new NullReferenceException();
						}
						gameObject4.SetActive(value: false);
						action = null;
					}
					continue;
				}
				throw new NullReferenceException();
			}
			customProperty2 = (CustomProperty)(customProperty2 + 1);
			material4 = material;
			customProperty3 = customProperty;
			transform = (Transform)insertionBehavior;
			phaserTilemaps = (Dictionary<SuperMap, List<PhaserTilemap>>)(&enumerator5);
		}
		goto IL_10cb;
	}

	private static Vector2 GetPosByIndex(int index, SuperMap map)
	{
		//IL_002b: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		bool flag = index == 0;
		Vector2 result = default(Vector2);
		if (!flag)
		{
			object obj = index - 1;
			if (flag)
			{
				return result;
			}
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 == 1)
				{
					return result;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
		}
		return result;
	}

	public unsafe List<CharacterType> GetCharactersUsed(SuperMap map)
	{
		//IL_0086: Expected O, but got I4
		//IL_0036: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_0068: Expected O, but got I4
		//IL_0c29: Expected I, but got O
		//IL_0148: Expected I, but got O
		//IL_0189: Expected I, but got O
		//IL_02c3: Expected I8, but got I
		//IL_0acd: Expected O, but got I
		//IL_0508: Expected I8, but got I
		//IL_01e1: Expected O, but got I
		//IL_0b2c: Expected O, but got I
		//IL_0c7d: Expected I, but got I8
		//IL_053a: Expected I8, but got I
		//IL_0568: Expected I8, but got I
		//IL_041b: Expected I, but got I8
		//IL_0caf: Expected I, but got I8
		//IL_068c: Expected I, but got I8
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected Ref, but got Unknown
		//IL_037b: Expected I8, but got I4
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected Ref, but got Unknown
		//IL_03b7: Expected O, but got I4
		//IL_03c0: Expected O, but got I4
		//IL_03c8: Expected I, but got I8
		//IL_0981: Unknown result type (might be due to invalid IL or missing references)
		//IL_0986: Expected O, but got Unknown
		//IL_05a4: Expected I8, but got I
		//IL_0458: Expected O, but got I4
		//IL_06b2: Expected I, but got I8
		//IL_07ba: Expected I, but got I8
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected Ref, but got Unknown
		//IL_05d8: Expected I8, but got I4
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected Ref, but got Unknown
		//IL_0609: Expected O, but got I4
		//IL_0612: Expected O, but got I4
		//IL_06e6: Expected I, but got I8
		//IL_049d: Expected O, but got I4
		//IL_0802: Expected I, but got I8
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Expected Ref, but got Unknown
		//IL_071a: Expected I8, but got I4
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_072d: Expected Ref, but got Unknown
		//IL_0756: Expected O, but got I4
		//IL_075f: Expected O, but got I4
		//IL_0767: Expected I, but got I8
		//IL_04c0: Expected O, but got I4
		//IL_04bb: Expected native int or pointer, but got O
		//IL_04c9: Expected O, but got I4
		//IL_082c: Expected I, but got I8
		//IL_0852: Expected I, but got I8
		//IL_0963: Expected O, but got I4
		//IL_095e: Expected native int or pointer, but got O
		//IL_0886: Expected I, but got I8
		//IL_089e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a3: Expected Ref, but got Unknown
		//IL_08ba: Expected I8, but got I4
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Expected Ref, but got Unknown
		//IL_08eb: Expected O, but got I4
		//IL_08f3: Expected I, but got I8
		//IL_08fc: Expected O, but got I4
		//IL_0904: Expected I, but got I8
		List<CharacterType> list = new List<CharacterType>();
		SuperObjectLayer objectLayer = GetObjectLayer(map, "Scripts");
		nint num = default(nint);
		object obj;
		string text2;
		SuperObjectLayer superObjectLayer;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			string text = ((Enum)(&num)).ToString();
			SuperObjectLayer objectLayer2 = GetObjectLayer(map, text);
			num = (nint)typeof(StageType);
			obj = 0;
			text2 = text;
			superObjectLayer = objectLayer2;
		}
		else
		{
			obj = 0;
			text2 = "Scripts";
			superObjectLayer = null;
		}
		if (((object)objectLayer != null && ((UnityEngine.Object)objectLayer).m_CachedPtr != (IntPtr)0) || ((object)superObjectLayer != null && ((UnityEngine.Object)superObjectLayer).m_CachedPtr != (IntPtr)0))
		{
			SuperObject[] componentsInChildren = objectLayer.GetComponentsInChildren<SuperObject>();
			bool flag = (object)superObjectLayer == null;
			SuperObject[] array = componentsInChildren;
			nint num2 = (nint)text2;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)superObjectLayer).m_CachedPtr == (IntPtr)0;
				array = componentsInChildren;
				num2 = (nint)text2;
				if (!flag2)
				{
					SuperObject[] componentsInChildren2 = superObjectLayer.GetComponentsInChildren<SuperObject>();
					bool flag3 = componentsInChildren2.Length == 0;
					array = componentsInChildren;
					num2 = (nint)text2;
					if (!flag3)
					{
						IEnumerable<SuperObject> enumerable = Enumerable.Concat(componentsInChildren, componentsInChildren2);
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v683 @ rbx_v13 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							IEnumerable<SuperObject> enumerable2 = Enumerable.Concat((IEnumerable<SuperObject>)0, componentsInChildren2);
						}
						if (enumerable == null)
						{
							Exception ex = System.Linq.Error.ArgumentNull("source");
							throw ex;
						}
						System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)enumerable);
						SuperObject[] array2 = ((System.Linq.Buffer<SuperObject>*)(&num))->ToArray();
						array = array2;
						num2 = 0;
					}
				}
			}
			SuperObjectLayer superObjectLayer2 = null;
			CustomProperty property = null;
			SuperObjectLayer superObjectLayer3 = null;
			object obj7 = default(object);
			while (true)
			{
				SuperObject superObject;
				ulong num4;
				object obj3;
				if ((nint)superObjectLayer3 < array.Length)
				{
					if ((nint)superObjectLayer2 < array.Length)
					{
						superObject = array[(object)superObjectLayer2];
						string tiledName = superObject.m_TiledName;
						object obj2 = "CFF";
						bool flag4 = (object)superObject.m_TiledName == "CFF";
						num4 = (ulong)num2;
						if (flag4)
						{
							goto IL_03d6;
						}
						bool flag5 = superObject.m_TiledName == null;
						obj3 = obj;
						if (!flag5)
						{
							bool flag6 = "CFF" == null;
							obj3 = obj;
							if (!flag6)
							{
								int stringLength = tiledName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rdx_v16+10]");
								bool flag7 = (nint)stringLength != 0;
								obj3 = obj;
								if (!flag7)
								{
									ref byte second = ref *(byte*)("CFF" + 20);
									num4 = (ulong)(tiledName._stringLength + tiledName._stringLength);
									bool flag8 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref second, num4);
									bool flag9 = !flag8;
									obj = 0;
									obj3 = 0;
									num2 = (nint)num4;
									if (!flag9)
									{
										goto IL_03d6;
									}
								}
							}
						}
						goto IL_04d6;
					}
					goto IL_0c4b;
				}
				PlayerOptions playerOptions = _playerOptions;
				PlayerOptionsData playerOptionsData;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0ce2;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0ce2;
				IL_03d6:
				SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
				bool flag10 = (object)component == null;
				obj3 = obj;
				num2 = (nint)num4;
				if (!flag10)
				{
					bool flag11 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					obj3 = obj;
					num2 = (nint)num4;
					if (!flag11)
					{
						bool flag12 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "cffCharacterType", out property);
						bool flag13 = !flag12;
						obj3 = 0;
						num2 = (nint)(&property);
						if (!flag13)
						{
							CharacterType characterType = Enum.Parse<CharacterType>(property.m_Value);
							bool flag14 = characterType == CharacterType.VOID;
							obj3 = 0;
							num2 = (nint)(&property);
							if (!flag14)
							{
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)list, new System.Linq.Buffer<SuperObject>((IEnumerable<SuperObject>)characterType));
								obj3 = 0;
								num2 = (nint)(&property);
							}
						}
					}
				}
				goto IL_04d6;
				IL_0978:
				superObjectLayer2 = (SuperObjectLayer)(superObjectLayer2 + 1);
				superObjectLayer3 = superObjectLayer2;
				continue;
				IL_0775:
				SuperCustomProperties component2 = superObject.GetComponent<SuperCustomProperties>();
				bool flag15 = (object)component2 == null;
				obj = obj3;
				ulong num5;
				num2 = (nint)num5;
				if (!flag15)
				{
					bool flag16 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
					obj = obj3;
					num2 = (nint)num5;
					if (!flag16)
					{
						string type = superObject.m_Type;
						object obj4 = "";
						bool flag17 = (object)superObject.m_Type == "";
						obj = obj3;
						num2 = (nint)num5;
						if (!flag17)
						{
							bool flag18 = superObject.m_Type == null;
							nint num6 = (nint)num5;
							if (!flag18)
							{
								bool flag19 = "" == null;
								num6 = (nint)num5;
								if (!flag19)
								{
									int stringLength2 = type._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1474 @ rdx_v22+10]");
									bool flag20 = (nint)stringLength2 != 0;
									num6 = (nint)num5;
									if (!flag20)
									{
										ref byte second2 = ref *(byte*)("" + 20);
										ulong num7 = (ulong)(type._stringLength + type._stringLength);
										bool flag21 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second2, num7);
										obj3 = 0;
										num6 = (nint)num7;
										obj = 0;
										num2 = (nint)num7;
										if (flag21)
										{
											goto IL_0978;
										}
									}
								}
							}
							CharacterType characterType2 = Enum.Parse<CharacterType>(superObject.m_Type);
							bool flag22 = characterType2 == CharacterType.VOID;
							obj = obj3;
							num2 = num6;
							if (!flag22)
							{
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)list, new System.Linq.Buffer<SuperObject>((IEnumerable<SuperObject>)characterType2));
								obj = obj3;
								num2 = num6;
							}
						}
					}
				}
				goto IL_0978;
				IL_0c4b:
				return (List<CharacterType>)(object)new IndexOutOfRangeException();
				IL_04d6:
				string tiledName2 = superObject.m_TiledName;
				object obj5 = "AdventureMerchant";
				bool flag23 = (object)superObject.m_TiledName == "AdventureMerchant";
				num5 = (ulong)num2;
				if (!flag23)
				{
					bool flag24 = superObject.m_TiledName == null;
					obj = obj3;
					ulong num8 = (ulong)num2;
					if (!flag24)
					{
						bool flag25 = "AdventureMerchant" == null;
						obj = obj3;
						num8 = (ulong)num2;
						if (!flag25)
						{
							int stringLength3 = tiledName2._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ rdx_v18+10]");
							bool flag26 = (nint)stringLength3 != 0;
							obj = obj3;
							num8 = (ulong)num2;
							if (!flag26)
							{
								ref byte second3 = ref *(byte*)("AdventureMerchant" + 20);
								num8 = (ulong)(tiledName2._stringLength + tiledName2._stringLength);
								bool flag27 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref second3, num8);
								obj = 0;
								obj3 = 0;
								num5 = num8;
								if (flag27)
								{
									goto IL_0775;
								}
							}
						}
					}
					string tiledName3 = superObject.m_TiledName;
					object obj6 = "CustomMerchant";
					bool flag28 = (object)superObject.m_TiledName == "CustomMerchant";
					obj3 = obj;
					num5 = num8;
					if (!flag28)
					{
						bool flag29 = superObject.m_TiledName == null;
						num2 = (nint)num8;
						if (flag29)
						{
							goto IL_0978;
						}
						bool flag30 = "CustomMerchant" == null;
						num2 = (nint)num8;
						if (flag30)
						{
							goto IL_0978;
						}
						int stringLength4 = tiledName3._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1243 @ rdx_v28+10]");
						bool flag31 = (nint)stringLength4 != 0;
						num2 = (nint)num8;
						if (flag31)
						{
							goto IL_0978;
						}
						ref byte second4 = ref *(byte*)("CustomMerchant" + 20);
						num5 = (ulong)(tiledName3._stringLength + tiledName3._stringLength);
						bool flag32 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref second4, num5);
						bool flag33 = !flag32;
						obj3 = 0;
						obj = 0;
						num2 = (nint)num5;
						if (flag33)
						{
							goto IL_0978;
						}
					}
				}
				goto IL_0775;
				IL_0ce2:
				List<CharacterType> list2 = playerOptionsData._003CUnlockedCharacters_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					if ((nint)obj7 != -1)
					{
						break;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ r8_v9+18]");
				if (num9 >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)64);
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				object obj9 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ r8_v9+18]");
				if (num10 < 0)
				{
					_ = 64;
					break;
				}
				goto IL_0c4b;
			}
		}
		return list;
	}

	public unsafe List<Tuple<SuperObject, SuperCustomProperties>> GetAllMerchants()
	{
		//IL_00a0: Expected I, but got O
		//IL_0053: Expected O, but got Ref
		//IL_0084: Expected I, but got O
		//IL_0089: Expected I, but got O
		//IL_07fc: Expected I, but got O
		//IL_017a: Expected I, but got O
		//IL_02ec: Expected I8, but got I
		//IL_01d3: Expected I, but got O
		//IL_031e: Expected I8, but got I
		//IL_034c: Expected I8, but got I
		//IL_022b: Expected O, but got I
		//IL_0861: Expected I, but got I8
		//IL_0468: Expected I, but got I8
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Expected O, but got Unknown
		//IL_0388: Expected I8, but got I
		//IL_048e: Expected I, but got I8
		//IL_0597: Expected I, but got I8
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected Ref, but got Unknown
		//IL_03bc: Expected I8, but got I4
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected Ref, but got Unknown
		//IL_03e9: Expected I, but got O
		//IL_03ee: Expected I, but got O
		//IL_04c2: Expected I, but got I8
		//IL_05df: Expected I, but got I8
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected Ref, but got Unknown
		//IL_04f6: Expected I8, but got I4
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Expected Ref, but got Unknown
		//IL_052e: Expected I, but got O
		//IL_0533: Expected I, but got O
		//IL_053b: Expected I, but got I8
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected Ref, but got Unknown
		//IL_067f: Expected I8, but got I4
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Expected Ref, but got Unknown
		//IL_06ac: Expected I, but got O
		//IL_06b4: Expected I, but got I8
		List<Tuple<SuperObject, SuperCustomProperties>> list = new List<Tuple<SuperObject, SuperCustomProperties>>();
		SuperMap defaultMap = DefaultMap;
		SuperObjectLayer objectLayer = GetObjectLayer(defaultMap, "Scripts");
		nint num = default(nint);
		SuperObjectLayer superObjectLayer;
		nint num2;
		string text2;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			SuperMap defaultMap2 = DefaultMap;
			string text = ((Enum)(&num)).ToString();
			SuperObjectLayer objectLayer2 = GetObjectLayer(defaultMap2, text);
			superObjectLayer = objectLayer2;
			num = (nint)typeof(StageType);
			num2 = unchecked((nint)null);
			text2 = text;
		}
		else
		{
			superObjectLayer = null;
			num2 = unchecked((nint)null);
			text2 = "Scripts";
		}
		if ((object)objectLayer == null || ((UnityEngine.Object)objectLayer).m_CachedPtr == (IntPtr)0)
		{
			if ((object)superObjectLayer == null || ((UnityEngine.Object)superObjectLayer).m_CachedPtr == (IntPtr)0)
			{
				goto IL_0740;
			}
			if ((object)objectLayer == null)
			{
				goto IL_07ca;
			}
		}
		SuperObject[] componentsInChildren = objectLayer.GetComponentsInChildren<SuperObject>();
		bool flag = (object)superObjectLayer == null;
		SuperObject[] array = componentsInChildren;
		nint num3 = (nint)text2;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)superObjectLayer).m_CachedPtr == (IntPtr)0;
			array = componentsInChildren;
			num3 = (nint)text2;
			if (!flag2)
			{
				SuperObject[] componentsInChildren2 = superObjectLayer.GetComponentsInChildren<SuperObject>();
				if (componentsInChildren2 == null)
				{
					goto IL_07ca;
				}
				bool flag3 = componentsInChildren2.Length == 0;
				array = componentsInChildren;
				num3 = (nint)text2;
				if (!flag3)
				{
					IEnumerable<SuperObject> enumerable = Enumerable.Concat(componentsInChildren, componentsInChildren2);
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rbx_v9 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						IEnumerable<SuperObject> enumerable2 = Enumerable.Concat((IEnumerable<SuperObject>)0, componentsInChildren2);
					}
					if (enumerable == null)
					{
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
					System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)enumerable);
					SuperObject[] array2 = ((System.Linq.Buffer<SuperObject>*)(&num))->ToArray();
					array = array2;
					num3 = 0;
				}
			}
		}
		bool flag4 = array == null;
		SuperObjectLayer superObjectLayer2 = null;
		SuperObjectLayer superObjectLayer3 = null;
		if (!flag4)
		{
			nint num6;
			for (; (nint)superObjectLayer3 < array.Length; superObjectLayer2 = (SuperObjectLayer)(superObjectLayer2 + 1), num2 = num6, superObjectLayer3 = superObjectLayer2)
			{
				SuperObject superObject = array[(object)superObjectLayer2];
				ulong num5;
				if ((object)array[(object)superObjectLayer2] != null)
				{
					string tiledName = superObject.m_TiledName;
					object obj = "AdventureMerchant";
					bool flag5 = (object)superObject.m_TiledName == "AdventureMerchant";
					num5 = (ulong)num3;
					if (!flag5)
					{
						bool flag6 = superObject.m_TiledName == null;
						num6 = num2;
						ulong num7 = (ulong)num3;
						if (!flag6)
						{
							bool flag7 = "AdventureMerchant" == null;
							num6 = num2;
							num7 = (ulong)num3;
							if (!flag7)
							{
								int stringLength = tiledName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rdx_v11+10]");
								bool flag8 = (nint)stringLength != 0;
								num6 = num2;
								num7 = (ulong)num3;
								if (!flag8)
								{
									ref byte second = ref *(byte*)("AdventureMerchant" + 20);
									num7 = (ulong)(tiledName._stringLength + tiledName._stringLength);
									bool flag9 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref second, num7);
									num6 = unchecked((nint)null);
									num2 = unchecked((nint)null);
									num5 = num7;
									if (flag9)
									{
										goto IL_0549;
									}
								}
							}
						}
						string tiledName2 = superObject.m_TiledName;
						object obj2 = "CustomMerchant";
						bool flag10 = (object)superObject.m_TiledName == "CustomMerchant";
						num2 = num6;
						num5 = num7;
						if (!flag10)
						{
							bool flag11 = superObject.m_TiledName == null;
							num3 = (nint)num7;
							if (flag11)
							{
								continue;
							}
							bool flag12 = "CustomMerchant" == null;
							num3 = (nint)num7;
							if (flag12)
							{
								continue;
							}
							int stringLength2 = tiledName2._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rdx_v21+10]");
							bool flag13 = (nint)stringLength2 != 0;
							num3 = (nint)num7;
							if (flag13)
							{
								continue;
							}
							ref byte second2 = ref *(byte*)("CustomMerchant" + 20);
							num5 = (ulong)(tiledName2._stringLength + tiledName2._stringLength);
							bool flag14 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_TiledName + 20), ref second2, num5);
							bool flag15 = !flag14;
							num2 = unchecked((nint)null);
							num6 = unchecked((nint)null);
							num3 = (nint)num5;
							if (flag15)
							{
								continue;
							}
						}
					}
					goto IL_0549;
				}
				goto IL_07ca;
				IL_0549:
				SuperCustomProperties component = array[(object)superObjectLayer2].GetComponent<SuperCustomProperties>();
				bool flag16 = (object)component == null;
				num6 = num2;
				num3 = (nint)num5;
				if (flag16)
				{
					continue;
				}
				bool flag17 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				num6 = num2;
				num3 = (nint)num5;
				if (flag17)
				{
					continue;
				}
				string type = superObject.m_Type;
				object obj3 = "";
				bool flag18 = (object)superObject.m_Type == "";
				num6 = num2;
				num3 = (nint)num5;
				if (flag18)
				{
					continue;
				}
				if (superObject.m_Type != null && "" != null)
				{
					int stringLength3 = type._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v999 @ rdx_v15+10]");
					if ((nint)stringLength3 == 0)
					{
						ref byte second3 = ref *(byte*)("" + 20);
						ulong num8 = (ulong)(type._stringLength + type._stringLength);
						bool flag19 = System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second3, num8);
						num6 = unchecked((nint)null);
						num3 = (nint)num8;
						if (flag19)
						{
							continue;
						}
					}
				}
				Tuple<SuperObject, SuperCustomProperties> item = new Tuple<SuperObject, SuperCustomProperties>(array[(object)superObjectLayer2], component);
				if (list != null)
				{
					((List<object>)(object)list).Add((object)item);
					num6 = 0;
					num3 = 0;
					continue;
				}
				goto IL_07ca;
			}
			goto IL_0740;
		}
		goto IL_07ca;
		IL_07ca:
		return (List<Tuple<SuperObject, SuperCustomProperties>>)(object)new NullReferenceException();
		IL_0740:
		return list;
	}

	private unsafe void HandleCustomScriptProperties(SuperMap map)
	{
		//IL_0036: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_01e1: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_025d: Expected O, but got I4
		//IL_026a: Expected O, but got I8
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e90: Expected O, but got Unknown
		//IL_0fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fac: Expected O, but got Unknown
		//IL_0b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected O, but got Unknown
		//IL_10c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c8: Expected O, but got Unknown
		//IL_0c53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c58: Expected O, but got Unknown
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_0d6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d74: Expected O, but got Unknown
		//IL_09fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Expected O, but got Unknown
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected O, but got Unknown
		//IL_0e1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e24: Expected Ref, but got Unknown
		//IL_0e3b: Expected I8, but got I4
		//IL_0e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4a: Expected Ref, but got Unknown
		//IL_0f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f40: Expected Ref, but got Unknown
		//IL_0f57: Expected I8, but got I4
		//IL_0f61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f66: Expected Ref, but got Unknown
		//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad0: Expected Ref, but got Unknown
		//IL_0ae7: Expected I8, but got I4
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af6: Expected Ref, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Expected Ref, but got Unknown
		//IL_076b: Expected I8, but got I4
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Expected Ref, but got Unknown
		//IL_1057: Unknown result type (might be due to invalid IL or missing references)
		//IL_105c: Expected Ref, but got Unknown
		//IL_1073: Expected I8, but got I4
		//IL_107d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1082: Expected Ref, but got Unknown
		//IL_0be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bec: Expected Ref, but got Unknown
		//IL_0c03: Expected I8, but got I4
		//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Expected Ref, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0874: Expected Ref, but got Unknown
		//IL_088b: Expected I8, but got I4
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Expected Ref, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected Ref, but got Unknown
		//IL_03d1: Expected I8, but got I4
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected Ref, but got Unknown
		//IL_0d03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d08: Expected Ref, but got Unknown
		//IL_0d1f: Expected I8, but got I4
		//IL_0d29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2e: Expected Ref, but got Unknown
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Expected Ref, but got Unknown
		//IL_09ab: Expected I8, but got I4
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Expected Ref, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected Ref, but got Unknown
		//IL_04f1: Expected I8, but got I4
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Expected Ref, but got Unknown
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected Ref, but got Unknown
		//IL_0621: Expected I8, but got I4
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Expected Ref, but got Unknown
		SuperObjectLayer objectLayer = GetObjectLayer(map, "Scripts");
		bool flag = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
		Component component = null;
		nint num = default(nint);
		if (!flag)
		{
			string layerName = ((Enum)(&num)).ToString();
			SuperObjectLayer objectLayer2 = GetObjectLayer(map, layerName);
			num = (nint)typeof(StageType);
			component = objectLayer2;
		}
		if (((object)objectLayer == null || ((UnityEngine.Object)objectLayer).m_CachedPtr == (IntPtr)0) && ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0))
		{
			return;
		}
		SuperObject[] componentsInChildren = objectLayer.GetComponentsInChildren<SuperObject>();
		bool flag2 = (object)component == null;
		SuperObject[] array = componentsInChildren;
		if (!flag2)
		{
			bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			array = componentsInChildren;
			if (!flag3)
			{
				SuperObject[] componentsInChildren2 = component.GetComponentsInChildren<SuperObject>();
				bool flag4 = componentsInChildren2.Length == 0;
				array = componentsInChildren;
				if (!flag4)
				{
					IEnumerable<SuperObject> enumerable = Enumerable.Concat(componentsInChildren, componentsInChildren2);
					if (enumerable == null)
					{
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
					System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)enumerable);
					SuperObject[] array2 = ((System.Linq.Buffer<SuperObject>*)(&num))->ToArray();
					array = array2;
				}
			}
		}
		if (array.Length == 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		int num2 = default(int);
		object obj3 = default(object);
		while ((nint)obj < array.Length)
		{
			SuperObject superObject = array[obj2];
			string tiledName = superObject.m_TiledName;
			object obj10;
			int num5;
			if (superObject.m_TiledName != null)
			{
				num2 = tiledName._stringLength;
				obj3 = superObject.m_TiledName + 20;
				object obj4 = 0;
				object obj5 = 2166136261L;
				while ((nint)obj4 < num2)
				{
					if ((nint)obj4 < tiledName._stringLength)
					{
						obj4++;
						object obj6 = obj3 ^ obj5;
						obj5 = obj6 * 16777619;
						obj3 += 2;
						continue;
					}
					System.ThrowHelper.ThrowIndexOutOfRangeException();
					throw new IndexOutOfRangeException();
				}
				if ((nint)obj5 > 1607925127)
				{
					if ((long)obj5 > 3082879841L)
					{
						if ((long)obj5 == 3430077768L)
						{
							object obj7 = "ARCANACHEST";
							if ((object)superObject.m_TiledName == "ARCANACHEST")
							{
								goto IL_040e;
							}
							if ("ARCANACHEST" != null)
							{
								int num3 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1056 @ rdx_v57+10]");
								if ((nint)num3 == 0)
								{
									ref byte first = ref *(byte*)(superObject.m_TiledName + 20);
									ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("ARCANACHEST" + 20), length))
									{
										goto IL_040e;
									}
								}
							}
						}
						else if ((long)obj5 == 3654151273L)
						{
							object obj8 = "Yellow";
							if ((object)superObject.m_TiledName == "Yellow")
							{
								goto IL_052e;
							}
							if ("Yellow" != null)
							{
								int num4 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1058 @ rdx_v53+10]");
								if ((nint)num4 == 0)
								{
									ref byte first2 = ref *(byte*)(superObject.m_TiledName + 20);
									ulong length2 = (ulong)(tiledName._stringLength + tiledName._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Yellow" + 20), length2))
									{
										goto IL_052e;
									}
								}
							}
						}
						else if ((long)obj5 == 4161951547L)
						{
							object obj9 = "tilep";
							bool flag5 = (object)superObject.m_TiledName == "tilep";
							obj10 = obj3;
							num5 = num2;
							if (flag5)
							{
								goto IL_0682;
							}
							if ("tilep" != null)
							{
								int num6 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rdx_v51+10]");
								if ((nint)num6 == 0)
								{
									ref byte first3 = ref *(byte*)(superObject.m_TiledName + 20);
									ulong length3 = (ulong)(tiledName._stringLength + tiledName._stringLength);
									bool flag6 = System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("tilep" + 20), length3);
									obj10 = obj3;
									num5 = num2;
									if (flag6)
									{
										goto IL_0682;
									}
								}
							}
						}
					}
					else if ((long)obj5 == 2699839356L)
					{
						object obj11 = "PlayerStart";
						if ((object)superObject.m_TiledName == "PlayerStart")
						{
							goto IL_07a8;
						}
						if ("PlayerStart" != null)
						{
							int num7 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1062 @ rdx_v47+10]");
							if ((nint)num7 == 0)
							{
								ref byte first4 = ref *(byte*)(superObject.m_TiledName + 20);
								ulong length4 = (ulong)(tiledName._stringLength + tiledName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("PlayerStart" + 20), length4))
								{
									goto IL_07a8;
								}
							}
						}
					}
					else if ((long)obj5 == 2802616108L)
					{
						object obj12 = "RELIC";
						if ((object)superObject.m_TiledName == "RELIC")
						{
							goto IL_08c8;
						}
						if ("RELIC" != null)
						{
							int num8 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ rdx_v43+10]");
							if ((nint)num8 == 0)
							{
								ref byte first5 = ref *(byte*)(superObject.m_TiledName + 20);
								ulong length5 = (ulong)(tiledName._stringLength + tiledName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("RELIC" + 20), length5))
								{
									goto IL_08c8;
								}
							}
						}
					}
					else if ((long)obj5 == 3082879841L)
					{
						object obj13 = "Weapon";
						if ((object)superObject.m_TiledName == "Weapon")
						{
							goto IL_09e8;
						}
						if ("Weapon" != null)
						{
							int num9 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1066 @ rdx_v39+10]");
							if ((nint)num9 == 0)
							{
								ref byte first6 = ref *(byte*)(superObject.m_TiledName + 20);
								ulong length6 = (ulong)(tiledName._stringLength + tiledName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("Weapon" + 20), length6))
								{
									goto IL_09e8;
								}
							}
						}
					}
				}
				else if ((nint)obj5 > 531595006)
				{
					if ((nint)obj5 == 933813866)
					{
						object obj14 = "CustomMerchant";
						if ((object)superObject.m_TiledName == "CustomMerchant")
						{
							goto IL_0b24;
						}
						if ("CustomMerchant" != null)
						{
							int num10 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rdx_v35+10]");
							if ((nint)num10 == 0)
							{
								ref byte first7 = ref *(byte*)(superObject.m_TiledName + 20);
								ulong length7 = (ulong)(tiledName._stringLength + tiledName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("CustomMerchant" + 20), length7))
								{
									goto IL_0b24;
								}
							}
						}
					}
					else if ((nint)obj5 == 1498467054)
					{
						object obj15 = "CFF";
						if ((object)superObject.m_TiledName == "CFF")
						{
							goto IL_0c40;
						}
						if ("CFF" != null)
						{
							int num11 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ rdx_v31+10]");
							if ((nint)num11 == 0)
							{
								ref byte first8 = ref *(byte*)(superObject.m_TiledName + 20);
								ulong length8 = (ulong)(tiledName._stringLength + tiledName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first8, ref *(byte*)("CFF" + 20), length8))
								{
									goto IL_0c40;
								}
							}
						}
					}
					else if ((nint)obj5 == 1607925127)
					{
						object obj16 = "AdventureMerchant";
						if ((object)superObject.m_TiledName == "AdventureMerchant")
						{
							goto IL_0d5c;
						}
						if ("AdventureMerchant" != null)
						{
							int num12 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rdx_v27+10]");
							if ((nint)num12 == 0)
							{
								ref byte first9 = ref *(byte*)(superObject.m_TiledName + 20);
								ulong length9 = (ulong)(tiledName._stringLength + tiledName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first9, ref *(byte*)("AdventureMerchant" + 20), length9))
								{
									goto IL_0d5c;
								}
							}
						}
					}
				}
				else if ((nint)obj5 == 52117953)
				{
					object obj17 = "PARTO";
					if ((object)superObject.m_TiledName == "PARTO")
					{
						goto IL_0e78;
					}
					if ("PARTO" != null)
					{
						int num13 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rdx_v23+10]");
						if ((nint)num13 == 0)
						{
							ref byte first10 = ref *(byte*)(superObject.m_TiledName + 20);
							ulong length10 = (ulong)(tiledName._stringLength + tiledName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first10, ref *(byte*)("PARTO" + 20), length10))
							{
								goto IL_0e78;
							}
						}
					}
				}
				else if ((nint)obj5 == 526680070)
				{
					object obj18 = "Item";
					if ((object)superObject.m_TiledName == "Item")
					{
						goto IL_0f94;
					}
					if ("Item" != null)
					{
						int num14 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rdx_v19+10]");
						if ((nint)num14 == 0)
						{
							ref byte first11 = ref *(byte*)(superObject.m_TiledName + 20);
							ulong length11 = (ulong)(tiledName._stringLength + tiledName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first11, ref *(byte*)("Item" + 20), length11))
							{
								goto IL_0f94;
							}
						}
					}
				}
				else if ((nint)obj5 == 531595006)
				{
					object obj19 = "TELEPORT";
					if ((object)superObject.m_TiledName == "TELEPORT")
					{
						goto IL_10b0;
					}
					if ("TELEPORT" != null)
					{
						int num15 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rdx_v15+10]");
						if ((nint)num15 == 0)
						{
							ref byte first12 = ref *(byte*)(superObject.m_TiledName + 20);
							ulong length12 = (ulong)(tiledName._stringLength + tiledName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first12, ref *(byte*)("TELEPORT" + 20), length12))
							{
								goto IL_10b0;
							}
						}
					}
				}
			}
			StoreScript(superObject);
			obj10 = obj3;
			num5 = num2;
			goto IL_0682;
			IL_09e8:
			SpawnWeaponAt(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_0e78:
			GetMoongateData(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_0f94:
			SpawnItemAt(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_052e:
			SpawnYellowAt(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_07a8:
			SetPlayerStartFromSuperObject(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_0682:
			obj2++;
			obj3 = obj10;
			num2 = num5;
			obj = obj2;
			continue;
			IL_0d5c:
			SpawnAdventureMerchant(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_10b0:
			LinkTeleporters(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_0c40:
			SpawnCoffin(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_0b24:
			SpawnCustomMerchant(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_040e:
			SpawnArcanaChestAt(superObject);
			obj2++;
			obj = obj2;
			continue;
			IL_08c8:
			SpawnRelicAt(superObject);
			obj2++;
			obj = obj2;
		}
	}

	private unsafe SuperObjectLayer GetObjectLayer(SuperMap map, string layerName)
	{
		_003C_003Ec__DisplayClass82_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass82_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.layerName = layerName;
			if ((object)map != null)
			{
				GameObject gameObject = map.gameObject;
				if ((object)gameObject != null)
				{
					SuperObjectLayer[] componentsInChildren = gameObject.GetComponentsInChildren<SuperObjectLayer>(includeInactive: true);
					Func<SuperObjectLayer, bool> predicate = delegate(SuperObjectLayer superObjectLayer)
					{
						//IL_012f: Expected I4, but got O
						//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d1: Expected Ref, but got Unknown
						//IL_00e8: Expected I8, but got I4
						//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
						//IL_00fb: Expected Ref, but got Unknown
						if ((object)superObjectLayer != null)
						{
							string tiledName = superObjectLayer.m_TiledName;
							if (superObjectLayer.m_TiledName != null)
							{
								string layerName2 = CS_0024_003C_003E8__locals6.layerName;
								if ((object)superObjectLayer.m_TiledName != CS_0024_003C_003E8__locals6.layerName)
								{
									if (CS_0024_003C_003E8__locals6.layerName != null && tiledName._stringLength == layerName2._stringLength)
									{
										ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.layerName + 20);
										ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
										return System.SpanHelpers.SequenceEqual(ref *(byte*)(superObjectLayer.m_TiledName + 20), ref second, length);
									}
									return false;
								}
								return true;
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					};
					return (SuperObjectLayer)Enumerable.FirstOrDefault(componentsInChildren, (Func<object, bool>)predicate);
				}
			}
		}
		return (SuperObjectLayer)(object)new NullReferenceException();
	}

	private unsafe void SetPlayerStartFromSuperObject(SuperObject superObject)
	{
		if ((object)superObject != null)
		{
			Transform transform = superObject.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				_003CStartPosition_003Ek__BackingField = ret;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SpawnWeaponAt(SuperObject superObject)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Ref, but got Unknown
		//IL_0112: Expected I8, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		//IL_0333: Expected I, but got O
		//IL_0341: Expected I, but got O
		//IL_0351: Expected O, but got I
		//IL_03d1: Expected O, but got I4
		//IL_038d: Expected O, but got I
		//IL_03c3: Expected O, but got I4
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string type = superObject.m_Type;
		object obj = "";
		if ((object)superObject.m_Type == "")
		{
			return;
		}
		if (superObject.m_Type != null && "" != null)
		{
			int stringLength = type._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("" + 20);
				ulong length = (ulong)(type._stringLength + type._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second, length))
				{
					return;
				}
			}
		}
		WeaponType weaponType = Enum.Parse<WeaponType>(superObject.m_Type);
		if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "chance", out var property))
		{
			float num = StringExtensions.ToFloat(property.m_Value);
			float value = UnityEngine.Random.value;
			Stage stage = _stage;
			GameSessionData gameSessionData = stage._gameSessionData;
			float num2 = gameSessionData._activeCharacter.PLuck();
			float num3 = value * num;
			if (value > num3)
			{
				return;
			}
		}
		if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "requiresItem", out var property2) && Enum.Parse<ItemType>(property2.m_Value) != ItemType.VOID)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				return;
			}
		}
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		float value2 = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = _gameManager.MakeStagePickup(spawnPosFromSuperObject, ItemType.WEAPON, weaponType, value2, relicType, validatePickups);
		bool flag = (object)pickup == null;
		PickupGuarded pickupGuarded = null;
		object obj5;
		if (!flag)
		{
			nint num4 = (nint)pickup;
			nint num5 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rax_v36+FFFFFFF8+v687 @ rax_v32*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj5 = 1;
					goto IL_044e;
				}
			}
			obj5 = 0;
			goto IL_044e;
		}
		goto IL_0475;
		IL_044e:
		bool flag2 = obj5 == null;
		pickupGuarded = null;
		if (!flag2)
		{
			pickupGuarded = (PickupGuarded)pickup;
		}
		goto IL_0475;
		IL_0475:
		if ((object)pickupGuarded != null && ((UnityEngine.Object)pickupGuarded).m_CachedPtr != (IntPtr)0)
		{
			SetGuardedDataForItem(component, pickupGuarded);
		}
	}

	private unsafe void SpawnItemAt(SuperObject superObject)
	{
		//IL_051b: Expected F4, but got I4
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Ref, but got Unknown
		//IL_0112: Expected I8, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		//IL_04a6: Expected F4, but got I4
		//IL_0431: Expected F4, but got I4
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string type = superObject.m_Type;
		object obj = "";
		if ((object)superObject.m_Type == "")
		{
			return;
		}
		if (superObject.m_Type != null && "" != null)
		{
			int stringLength = type._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("" + 20);
				ulong length = (ulong)(type._stringLength + type._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second, length))
				{
					return;
				}
			}
		}
		if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "requiresItem", out var property) && Enum.Parse<ItemType>(property.m_Value) != ItemType.VOID)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				return;
			}
		}
		ItemType itemType = Enum.Parse<ItemType>(superObject.m_Type);
		if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "chance", out var property2))
		{
			float num = StringExtensions.ToFloat(property2.m_Value);
			float value = UnityEngine.Random.value;
			Stage stage = _stage;
			GameSessionData gameSessionData = stage._gameSessionData;
			float num2 = gameSessionData._activeCharacter.PLuck();
			float num3 = value * num;
			if (value > num3)
			{
				return;
			}
		}
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		float value3 = default(float);
		ItemType relicType = default(ItemType);
		bool shouldCallValidatePickups = default(bool);
		bool isRemote = default(bool);
		switch (itemType)
		{
		default:
		{
			Pickup pickup = _gameManager.MakePickup(spawnPosFromSuperObject, itemType, WeaponType.VOID, value3, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			break;
		}
		case ItemType.GOLDFINGER:
		{
			Pickup pickup2 = _gameManager.MakePickup(spawnPosFromSuperObject, ItemType.GOLDFINGER, WeaponType.VOID, value3, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
			{
				pickup2._003CIgnoreMadGroove_003Ek__BackingField = true;
			}
			break;
		}
		case ItemType.COINBAG1:
		{
			bool flag3 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "value", out var property4);
			bool flag4 = !flag3;
			float value2 = 0f;
			if (!flag4)
			{
				float num5 = StringExtensions.ToFloat(property4.m_Value);
				value2 = num5;
			}
			_gameManager.MakeRedCoinBag(spawnPosFromSuperObject, value2);
			break;
		}
		case ItemType.COIN:
		{
			bool flag5 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "value", out var property5);
			bool flag6 = !flag5;
			float value4 = 0f;
			if (!flag6)
			{
				float num6 = StringExtensions.ToFloat(property5.m_Value);
				value4 = num6;
			}
			_gameManager.MakeCoin(spawnPosFromSuperObject, value4);
			break;
		}
		case ItemType.GEM:
		{
			bool flag = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "value", out var property3);
			bool flag2 = !flag;
			float xp = 0f;
			if (!flag2)
			{
				float num4 = StringExtensions.ToFloat(property3.m_Value);
				xp = num4;
			}
			_gameManager.MakeGem(spawnPosFromSuperObject, xp);
			break;
		}
		}
	}

	private unsafe void SpawnRelicAt(SuperObject superObject)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Ref, but got Unknown
		//IL_0112: Expected I8, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		//IL_0201: Expected I, but got O
		//IL_020f: Expected I, but got O
		//IL_021f: Expected O, but got I
		//IL_029f: Expected O, but got I4
		//IL_025b: Expected O, but got I
		//IL_0291: Expected O, but got I4
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string type = superObject.m_Type;
		object obj = "";
		if ((object)superObject.m_Type == "")
		{
			return;
		}
		if (superObject.m_Type != null && "" != null)
		{
			int stringLength = type._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("" + 20);
				ulong length = (ulong)(type._stringLength + type._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second, length))
				{
					return;
				}
			}
		}
		ItemType item = Enum.Parse<ItemType>(superObject.m_Type);
		PlayerOptionsData config = _playerOptions.Config;
		if (config.HasCollectedItem(item))
		{
			return;
		}
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = _gameManager.MakeStagePickup(spawnPosFromSuperObject, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
		bool flag = (object)pickup == null;
		PickupGuarded pickupGuarded = null;
		object obj4;
		if (!flag)
		{
			nint num = (nint)pickup;
			nint num2 = (nint)typeof(PickupRelic);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ rax_v34+FFFFFFF8+v447 @ rax_v30*8]");
				if (0 == (nint)typeof(PickupRelic))
				{
					obj4 = 1;
					goto IL_031c;
				}
			}
			obj4 = 0;
			goto IL_031c;
		}
		goto IL_0343;
		IL_031c:
		bool flag2 = obj4 == null;
		pickupGuarded = null;
		if (!flag2)
		{
			pickupGuarded = (PickupGuarded)pickup;
		}
		goto IL_0343;
		IL_0343:
		if ((object)pickupGuarded != null && ((UnityEngine.Object)pickupGuarded).m_CachedPtr != (IntPtr)0)
		{
			SetGuardedDataForItem(component, pickupGuarded);
		}
	}

	private unsafe void SpawnYellowAt(SuperObject superObject)
	{
		//IL_022d: Expected I, but got O
		//IL_023b: Expected I, but got O
		//IL_024b: Expected O, but got I
		//IL_02cb: Expected O, but got I4
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected Ref, but got Unknown
		//IL_0177: Expected I8, but got I4
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected Ref, but got Unknown
		//IL_0287: Expected O, but got I
		//IL_02bd: Expected O, but got I4
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj == -1)
		{
			return;
		}
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string type = superObject.m_Type;
		object obj2 = "";
		if ((object)superObject.m_Type == "")
		{
			return;
		}
		if (superObject.m_Type != null && "" != null)
		{
			int stringLength = type._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v9+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("" + 20);
				ulong length = (ulong)(type._stringLength + type._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second, length))
				{
					return;
				}
			}
		}
		WeaponType weaponType = Enum.Parse<WeaponType>(superObject.m_Type);
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = _gameManager.MakeStagePickup(spawnPosFromSuperObject, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
		bool flag = (object)pickup == null;
		PickupGuarded pickupGuarded = null;
		object obj5;
		if (!flag)
		{
			nint num = (nint)pickup;
			nint num2 = (nint)typeof(PickupGuarded);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rax_v39+FFFFFFF8+v496 @ rax_v35*8]");
				if (0 == (nint)typeof(PickupGuarded))
				{
					obj5 = 1;
					goto IL_035a;
				}
			}
			obj5 = 0;
			goto IL_035a;
		}
		goto IL_0381;
		IL_0381:
		if ((object)pickupGuarded != null && ((UnityEngine.Object)pickupGuarded).m_CachedPtr != (IntPtr)0)
		{
			SetGuardedDataForItem(component, pickupGuarded);
		}
		return;
		IL_035a:
		bool flag2 = obj5 == null;
		pickupGuarded = null;
		if (!flag2)
		{
			pickupGuarded = (PickupGuarded)pickup;
		}
		goto IL_0381;
	}

	private void SpawnArcanaChestAt(SuperObject superObject)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0500: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0528: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_01e8: Expected O, but got I
		//IL_01cd: Expected O, but got I4
		//IL_055f: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_0237: Expected O, but got I4
		//IL_0587: Expected O, but got I
		//IL_02bc: Expected O, but got I
		//IL_02a1: Expected O, but got I4
		//IL_05af: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_030b: Expected O, but got I4
		//IL_05d7: Expected O, but got I
		//IL_0390: Expected O, but got I
		//IL_0375: Expected O, but got I4
		List<float> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(100f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1120403456;
		}
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v8+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v10+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v12+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v14+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v16+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1;
		}
		Treasure treasure = new Treasure();
		treasure._003Cchances_003Ek__BackingField = list;
		treasure._003CprizeTypes_003Ek__BackingField = list2;
		List<WeaponType> list3 = new List<WeaponType>();
		treasure._003CfixedPrizes_003Ek__BackingField = list3;
		treasure._003ChasArcana_003Ek__BackingField = true;
		GameManager core = GM.Core;
		int num9 = core._stage.SetTreasureLevelFromChance(treasure);
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
			TreasureChest treasureChest = GM.Core.MakeTreasure(spawnPosFromSuperObject, treasure);
			if ((object)treasureChest != null && ((UnityEngine.Object)treasureChest).m_CachedPtr != (IntPtr)0)
			{
				treasureChest.RemoveCursor();
			}
		}
	}

	private unsafe void SpawnCoffin(SuperObject superObject)
	{
		//IL_0077: Expected I4, but got O
		//IL_0472: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_0300: Expected I, but got O
		//IL_030e: Expected I, but got O
		//IL_031e: Expected O, but got I
		//IL_039e: Expected O, but got I4
		//IL_035a: Expected O, but got I
		//IL_0390: Expected O, but got I4
		Stage stage = _stage;
		StageData stageData = stage._stageData;
		bool flag = (object)stageData._003Ccff_003Ek__BackingField == null;
		CharacterType characterType = CharacterType.VOID;
		if (!flag)
		{
			if ((object)stageData._003Ccff_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			characterType = (CharacterType)((object?)stageData._003Ccff_003Ek__BackingField >> 32);
		}
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "cffCharacterType", out var property))
			{
				CharacterType characterType2 = Enum.Parse<CharacterType>(property.m_Value);
				if (characterType2 != CharacterType.VOID)
				{
					characterType = characterType2;
				}
			}
			bool flag2 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "requiresItem", out var property2);
			bool flag3 = !flag2;
			object obj = 0;
			nint num = (nint)(&property2);
			if (!flag3)
			{
				ItemType itemType = Enum.Parse<ItemType>(property2.m_Value);
				bool flag4 = itemType == ItemType.VOID;
				obj = 0;
				num = (nint)(&property2);
				if (!flag4)
				{
					GameManager core = GM.Core;
					PlayerOptionsData config = core._playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
					object obj2 = default(object);
					bool flag5 = obj2 == null;
					obj = 0;
					num = (nint)(&property2);
					if (flag5)
					{
						return;
					}
				}
			}
		}
		if (characterType == CharacterType.VOID)
		{
			return;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj3 = default(object);
		SuperCustomProperties component2;
		Pickup pickup;
		PickupCoffin pickupCoffin;
		object obj6;
		if (obj3 == null)
		{
			component2 = superObject.GetComponent<SuperCustomProperties>();
			if ((object)component2 == null || ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0 || component2.m_Properties == null)
			{
				return;
			}
			Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			pickup = _gameManager.MakeStagePickup(spawnPosFromSuperObject, ItemType.COFFIN, WeaponType.VOID, value, relicType, validatePickups);
			bool flag6 = (object)pickup == null;
			pickupCoffin = null;
			if (!flag6)
			{
				nint num2 = (nint)pickup;
				nint num3 = (nint)typeof(PickupCoffin);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ rax_v42+FFFFFFF8+v824 @ rax_v38*8]");
					if (0 == (nint)typeof(PickupCoffin))
					{
						obj6 = 1;
						goto IL_04af;
					}
				}
				obj6 = 0;
				goto IL_04af;
			}
			goto IL_04d6;
		}
		TrySpawnSpecialCoffin(superObject);
		return;
		IL_04d6:
		if ((object)pickupCoffin != null && ((UnityEngine.Object)pickupCoffin).m_CachedPtr != (IntPtr)0)
		{
			pickupCoffin.SetChar(characterType);
			SetGuardedDataForItem(component2, pickupCoffin);
		}
		return;
		IL_04af:
		bool flag7 = obj6 == null;
		pickupCoffin = null;
		if (!flag7)
		{
			pickupCoffin = (PickupCoffin)pickup;
		}
		goto IL_04d6;
	}

	private void TrySpawnSpecialCoffin(SuperObject superObject)
	{
		//IL_004b: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0233: Expected I, but got O
		//IL_0241: Expected I, but got O
		//IL_0251: Expected O, but got I
		//IL_02d1: Expected O, but got I4
		//IL_028d: Expected O, but got I
		//IL_02c3: Expected O, but got I4
		PlayerOptionsData config = _playerOptions.Config;
		List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		bool flag = (nint)0 == 0;
		object obj = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			bool flag2 = (nint)obj2 != -1;
			obj = 64;
			if (flag2)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj3 = default(object);
		if (obj3 != null)
		{
			return;
		}
		CharacterType[] array = new CharacterType[5]
		{
			CharacterType.PUGNALA,
			CharacterType.GIOVANNA,
			CharacterType.POPPEA,
			CharacterType.CONCETTA,
			CharacterType.ASSUNTA
		};
		PickupCoffinX pickupCoffinX = null;
		PickupCoffinX pickupCoffinX2 = null;
		PickupCoffinX pickupCoffinX3 = null;
		object obj4 = default(object);
		while ((nint)pickupCoffinX3 < array.Length)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config2 = core._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			if (obj4 == null)
			{
				break;
			}
			pickupCoffinX2 = (PickupCoffinX)(pickupCoffinX2 + 1);
			pickupCoffinX = (PickupCoffinX)(pickupCoffinX + 1);
			pickupCoffinX3 = pickupCoffinX;
		}
		if ((nint)pickupCoffinX2 != array.Length)
		{
			return;
		}
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = _gameManager.MakeStagePickup(spawnPosFromSuperObject, ItemType.COFFINX, WeaponType.VOID, value, relicType, validatePickups);
		bool flag3 = (object)pickup == null;
		PickupCoffinX pickupCoffinX4 = null;
		object obj7;
		if (!flag3)
		{
			nint num = (nint)pickup;
			nint num2 = (nint)typeof(PickupCoffinX);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffinX>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffinX>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v41+FFFFFFF8+v625 @ rax_v37*8]");
				if (0 == (nint)typeof(PickupCoffinX))
				{
					obj7 = 1;
					goto IL_037d;
				}
			}
			obj7 = 0;
			goto IL_037d;
		}
		goto IL_03a4;
		IL_037d:
		bool flag4 = obj7 == null;
		pickupCoffinX4 = null;
		if (!flag4)
		{
			pickupCoffinX4 = (PickupCoffinX)pickup;
		}
		goto IL_03a4;
		IL_03a4:
		if ((object)pickupCoffinX4 != null && ((UnityEngine.Object)pickupCoffinX4).m_CachedPtr != (IntPtr)0)
		{
			pickupCoffinX4.SetChar(CharacterType.ARENGIJUS);
			SetGuardedDataForItem(component, pickupCoffinX4);
		}
	}

	private unsafe void GetMoongateData(SuperObject superObject)
	{
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_01fc: Expected O, but got I
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02f7: Expected O, but got I
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Ref, but got Unknown
		//IL_0112: Expected I8, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0381: Expected O, but got I
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string type = superObject.m_Type;
		object obj = "";
		if ((object)superObject.m_Type == "")
		{
			return;
		}
		if (superObject.m_Type != null && "" != null)
		{
			int stringLength = type._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("" + 20);
				ulong length = (ulong)(type._stringLength + type._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second, length))
				{
					return;
				}
			}
		}
		int num = _moongates.FindEntry(superObject.m_Type);
		object obj2 = default(object);
		if (num < 0)
		{
			_ = 0;
			_ = 0;
			_ = 0;
			MoongateData value = (MoongateData)(obj2 - 64);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-2F]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-2D]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-2B]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
			object obj3 = (nint)0 >> 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-37]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
			_ = 0;
			bool flag = ((Dictionary<object, MoongateData>)(object)_moongates).TryInsert((object)superObject.m_Type, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		object obj4 = obj2 - 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4CC0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17+10]");
		_ = 0;
		object obj5 = default(object);
		if (obj5 != null)
		{
			object obj6 = obj2 - 64;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4CC0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v27+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
			object obj7 = (nint)0 >> 32;
			if (obj7 == null)
			{
				object obj8 = obj2 - 64;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4CC0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v30+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+2C]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
				object obj9 = (nint)0 >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-B]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-9]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+2C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
				_ = 0;
				MoongateData value2 = (MoongateData)(obj2 - 32);
				bool flag2 = ((Dictionary<object, MoongateData>)(object)_moongates).TryInsert((object)superObject.m_Type, value2, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
				_hasMoongates = true;
			}
		}
		else
		{
			object obj10 = obj2 - 64;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4CC0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v19+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+2C]");
			_ = 0;
			MoongateData value3 = (MoongateData)(obj2 - 32);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-F]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-B]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-9]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-17]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
			_ = 0;
			bool flag3 = ((Dictionary<object, MoongateData>)(object)_moongates).TryInsert((object)superObject.m_Type, value3, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
	}

	private unsafe void LinkTeleporters(SuperObject superObject)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0114: Expected O, but got I4
		//IL_0506: Expected O, but got I4
		//IL_0130: Expected O, but got Ref
		//IL_016c: Expected O, but got I4
		//IL_01bb: Expected O, but got Ref
		//IL_034c: Expected O, but got Ref
		//IL_053b: Expected O, but got I4
		//IL_020a: Expected O, but got Ref
		//IL_022f: Expected O, but got I
		//IL_0398: Expected O, but got I
		//IL_03a8: Expected O, but got I
		//IL_026a: Expected O, but got Ref
		//IL_0407: Expected O, but got Ref
		//IL_030d: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Predicate<CustomProperty> match = _003C_003Ec._003C_003E9__92_0;
		if (_003C_003Ec._003C_003E9__92_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__92_0 = delegate(CustomProperty property)
			{
				//IL_0144: Expected I4, but got O
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Expected Ref, but got Unknown
				//IL_00fd: Expected I8, but got I4
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0110: Expected Ref, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39BA]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (property == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				string text = property.m_Name;
				object obj12 = "teleportKey";
				if ((object)property.m_Name != "teleportKey")
				{
					if (property.m_Name != null && "teleportKey" != null)
					{
						int stringLength = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("teleportKey" + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(property.m_Name + 20), ref second, length);
						}
					}
					return false;
				}
				return true;
			});
		}
		CustomProperty customProperty = component.m_Properties.Find(match);
		if (customProperty == null)
		{
			return;
		}
		string value = customProperty.m_Value;
		if (customProperty.m_Value != null && value._stringLength > 0)
		{
			int num = _teleporters.FindEntry(customProperty.m_Value);
			bool flag = num >= 0;
			object obj3 = 0;
			if (!flag)
			{
				TeleporterData value2 = (TeleporterData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				_ = 0;
				_ = 0;
				_ = 0;
				bool flag2 = ((Dictionary<object, TeleporterData>)(object)_teleporters).TryInsert((object)customProperty.m_Value, value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				obj3 = 0;
			}
			Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
			Predicate<CustomProperty> match2 = _003C_003Ec._003C_003E9__92_1;
			bool flag3 = _003C_003Ec._003C_003E9__92_1 != null;
			object obj4 = 0;
			if (!flag3)
			{
				Predicate<CustomProperty> predicate = (_003C_003Ec._003C_003E9__92_1 = delegate(CustomProperty property)
				{
					//IL_0144: Expected I4, but got O
					//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
					//IL_00e6: Expected Ref, but got Unknown
					//IL_00fd: Expected I8, but got I4
					//IL_010b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0110: Expected Ref, but got Unknown
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39BB]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (property == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					string text = property.m_Name;
					object obj12 = "destinationBiome";
					if ((object)property.m_Name != "destinationBiome")
					{
						if (property.m_Name != null && "destinationBiome" != null)
						{
							int stringLength = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("destinationBiome" + 20);
								ulong length = (ulong)(text._stringLength + text._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(property.m_Name + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				});
				obj4 = 0;
				match2 = predicate;
			}
			CustomProperty customProperty2 = component.m_Properties.Find(match2);
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4D60");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rax_v28+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rax_v28+10]");
			if ((nint)0 != 0)
			{
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4D60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rax_v51+18]");
				object obj7 = (nint)0 >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rax_v51+20]");
				_ = 0;
				if (obj7 == null)
				{
					object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4D60");
					if (customProperty2 != null)
					{
						string message = "creating teleporter B - " + customProperty.m_Value + " - " + customProperty2.m_Value;
						Debug.Log(message);
					}
					_ = customProperty.m_Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rax_v54+10]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rax_v54+20]");
					_ = 0;
					TeleporterData value3 = (TeleporterData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
					bool flag4 = ((Dictionary<object, TeleporterData>)(object)_teleporters).TryInsert((object)customProperty.m_Value, value3, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
					_hasTeleporters = true;
				}
			}
			else
			{
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4D60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v848 @ rax_v30+20]");
				_ = 0;
				if (customProperty2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v42+B8]");
					object obj11 = 0;
				}
				else
				{
					_ = customProperty2.m_Value;
					string message2 = "creating teleporter A - " + customProperty.m_Value + " - " + customProperty2.m_Value;
					Debug.Log(message2);
				}
				TeleporterData value4 = (TeleporterData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				_ = customProperty.m_Value;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
				_ = 0;
				bool flag5 = ((Dictionary<object, TeleporterData>)(object)_teleporters).TryInsert((object)customProperty.m_Value, value4, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			}
		}
		else
		{
			Debug.LogError("TeleportKey is invalid");
		}
	}

	private unsafe void SpawnMoongates()
	{
		//IL_004c: Expected O, but got Ref
		//IL_00d8: Expected I, but got O
		//IL_00e6: Expected I, but got O
		//IL_00f6: Expected O, but got I
		//IL_0178: Expected O, but got I4
		//IL_0133: Expected O, but got I
		//IL_016a: Expected O, but got I4
		//IL_020f: Expected I, but got O
		//IL_021d: Expected I, but got O
		//IL_022d: Expected O, but got I
		//IL_02ad: Expected O, but got I4
		//IL_0269: Expected O, but got I
		//IL_029f: Expected O, but got I4
		if (!_hasMoongates)
		{
			return;
		}
		Dictionary<string, MoongateData>.ValueCollection values = _moongates.Values;
		Dictionary<string, MoongateData>.ValueCollection.Enumerator enumerator = default(Dictionary<string, MoongateData>.ValueCollection.Enumerator);
		Vector2 pos = default(Vector2);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			bool flag = (object)_gameManager == null;
			Dictionary<string, MoongateData>.ValueCollection.Enumerator enumerator2 = (Dictionary<string, MoongateData>.ValueCollection.Enumerator)(&enumerator);
			if (flag)
			{
				break;
			}
			Pickup pickup;
			nint num;
			object obj2;
			bool flag3;
			if (_gameManager.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.MOONGATE))
			{
				pickup = PickupManager.CreatePickup(pos, ItemType.MOONGATE);
				bool flag2 = (object)pickup != null;
				flag3 = true;
				if (flag2)
				{
					num = (nint)pickup;
					nint num2 = (nint)typeof(PickupMoongate);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMoongate>)+130]");
					Vector2 vector = (Vector2)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMoongate>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rax_v82+FFFFFFF8+v675 @ rax_v78 (UnityEngine.Vector2)*8]");
						if (0 == (nint)typeof(PickupMoongate))
						{
							obj2 = 1;
							goto IL_03bc;
						}
					}
					obj2 = 0;
					goto IL_03bc;
				}
			}
			Pickup pickup2 = null;
			goto IL_03e6;
			IL_03e6:
			Pickup pickup3;
			nint num4;
			object obj5;
			if (_gameManager.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.MOONGATE))
			{
				pickup3 = PickupManager.CreatePickup(pos, ItemType.MOONGATE);
				bool flag4 = (object)pickup3 != null;
				flag3 = true;
				if (flag4)
				{
					num4 = (nint)pickup3;
					nint num5 = (nint)typeof(PickupMoongate);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMoongate>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMoongate>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v56+FFFFFFF8+v924 @ rax_v52*8]");
						if (0 == (nint)typeof(PickupMoongate))
						{
							obj5 = 1;
							goto IL_0408;
						}
					}
					obj5 = 0;
					goto IL_0408;
				}
			}
			Pickup pickup4 = null;
			goto IL_0437;
			IL_03bc:
			bool flag5 = obj2 == null;
			pickup2 = null;
			flag3 = (byte)num != 0;
			if (!flag5)
			{
				pickup2 = pickup;
				flag3 = (byte)num != 0;
			}
			goto IL_03e6;
			IL_0437:
			if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0 && (object)pickup4 != null && ((UnityEngine.Object)pickup4).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BC7010");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BC7010");
				continue;
			}
			return;
			IL_0408:
			bool flag6 = obj5 == null;
			pickup4 = null;
			flag3 = (byte)num4 != 0;
			if (!flag6)
			{
				pickup4 = pickup3;
				flag3 = (byte)num4 != 0;
			}
			goto IL_0437;
		}
		throw new NullReferenceException();
	}

	private unsafe void MakeTeleporters()
	{
		//IL_0060: Expected O, but got Ref
		//IL_0097: Expected O, but got Ref
		//IL_014b: Expected I, but got O
		//IL_0185: Expected I, but got O
		//IL_0195: Expected O, but got I
		//IL_0215: Expected O, but got I4
		//IL_01d1: Expected O, but got I
		//IL_0207: Expected O, but got I4
		//IL_0237: Expected I, but got O
		//IL_0247: Expected O, but got I
		//IL_02c7: Expected O, but got I4
		//IL_0283: Expected O, but got I
		//IL_02b9: Expected O, but got I4
		if (!_hasTeleporters)
		{
			return;
		}
		Dictionary<string, TeleporterData>.ValueCollection values = _teleporters.Values;
		Dictionary<string, TeleporterData>.ValueCollection.Enumerator enumerator = default(Dictionary<string, TeleporterData>.ValueCollection.Enumerator);
		Vector2 gatePosition = default(Vector2);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			GameManager gameManager = _gameManager;
			bool flag = (object)_gameManager == null;
			Dictionary<string, TeleporterData>.ValueCollection.Enumerator enumerator2 = (Dictionary<string, TeleporterData>.ValueCollection.Enumerator)(&enumerator);
			PickupTeleporter pickupTeleporter;
			PickupTeleporter pickupTeleporter2;
			Pickup_EME_Teleporter pickup_EME_Teleporter;
			nint num2;
			object obj3;
			ItemType itemType2;
			if (!flag)
			{
				Stage stage = gameManager._stage;
				bool flag2 = (object)gameManager._stage == null;
				enumerator2 = (Dictionary<string, TeleporterData>.ValueCollection.Enumerator)(&enumerator);
				if (!flag2)
				{
					bool flag3 = stage._stageType == StageType.EMERALD;
					ItemType itemType = ItemType.EME_TELEPORTER;
					if (!flag3)
					{
						itemType = ItemType.TELEPORTER;
					}
					pickupTeleporter = MakeTeleporter(gatePosition, itemType);
					pickupTeleporter2 = MakeTeleporter(gatePosition, itemType);
					GameManager gameManager2 = _gameManager;
					bool flag4 = (object)_gameManager == null;
					enumerator2 = (Dictionary<string, TeleporterData>.ValueCollection.Enumerator)this;
					if (!flag4)
					{
						enumerator2 = (Dictionary<string, TeleporterData>.ValueCollection.Enumerator)gameManager2._stage;
						if ((object)gameManager2._stage != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rcx_v9 (System.Collections.Generic.Dictionary`2<System.String, VampireSurvivors.Objects.TilingTileset+TeleporterData>+ValueCollection<System.String, VampireSurvivors.Objects.TilingTileset+TeleporterData>+Enumerator<Syst…");
							bool flag5 = (nint)0 != 38;
							itemType2 = itemType;
							if (flag5)
							{
								goto IL_0330;
							}
							nint num = (nint)typeof(Pickup_EME_Teleporter);
							if ((object)pickupTeleporter2 == null)
							{
								pickup_EME_Teleporter = null;
								itemType2 = itemType;
								goto IL_0512;
							}
							num2 = (nint)pickupTeleporter2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_EME_Teleporter>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_EME_Teleporter>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rax_v75+FFFFFFF8+v790 @ rax_v71*8]");
								if (0 == (nint)typeof(Pickup_EME_Teleporter))
								{
									obj3 = 1;
									goto IL_052f;
								}
							}
							obj3 = 0;
							goto IL_052f;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_02f1:
			if ((object)pickup_EME_Teleporter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm8,8\"");
				pickup_EME_Teleporter.DestinationName = null;
				itemType2 = ItemType.VOID;
			}
			goto IL_0330;
			IL_052f:
			bool flag6 = obj3 == null;
			pickup_EME_Teleporter = null;
			itemType2 = (ItemType)num2;
			if (!flag6)
			{
				pickup_EME_Teleporter = (Pickup_EME_Teleporter)pickupTeleporter2;
				itemType2 = (ItemType)num2;
			}
			goto IL_0512;
			IL_0330:
			if ((object)pickupTeleporter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BBAE00");
				string text = null;
			}
			else
			{
				string text = null;
			}
			if ((object)pickupTeleporter2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BBAE00");
			}
			if ((object)pickupTeleporter != null && ((UnityEngine.Object)pickupTeleporter).m_CachedPtr != (IntPtr)0 && (object)pickupTeleporter2 != null && ((UnityEngine.Object)pickupTeleporter2).m_CachedPtr != (IntPtr)0)
			{
				pickupTeleporter.LinkTo(pickupTeleporter2);
				pickupTeleporter2.LinkTo(pickupTeleporter);
				enumerator2 = (Dictionary<string, TeleporterData>.ValueCollection.Enumerator)_003CListOfTeleporters_003Ek__BackingField;
				if (_003CListOfTeleporters_003Ek__BackingField == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4E00");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4E00");
				continue;
			}
			return;
			IL_0512:
			if ((object)pickupTeleporter == null)
			{
				goto IL_02f1;
			}
			nint num4 = (nint)pickupTeleporter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_EME_Teleporter>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_EME_Teleporter>)+130]");
			object obj6;
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v69+FFFFFFF8+v888 @ rax_v64*8]");
				if (0 == (nint)typeof(Pickup_EME_Teleporter))
				{
					obj6 = 1;
					goto IL_0559;
				}
			}
			obj6 = 0;
			goto IL_0559;
			IL_0559:
			bool flag7 = obj6 == null;
			Pickup_EME_Teleporter pickup_EME_Teleporter2 = null;
			if (!flag7)
			{
				pickup_EME_Teleporter2 = (Pickup_EME_Teleporter)pickupTeleporter;
			}
			bool flag8 = (object)pickup_EME_Teleporter2 == null;
			itemType2 = (ItemType)num4;
			if (!flag8)
			{
				pickup_EME_Teleporter2.DestinationName = null;
				itemType2 = ItemType.VOID;
			}
			goto IL_02f1;
		}
		throw new NullReferenceException();
	}

	private unsafe PickupTeleporter MakeTeleporter(Vector2 gatePosition, ItemType teleporterType)
	{
		//IL_01b3: Expected I4, but got O
		//IL_01d8: Expected O, but got Ref
		//IL_0084: Expected I, but got O
		//IL_0198: Expected I, but got O
		//IL_023f: Expected I, but got O
		//IL_024f: Expected O, but got I
		//IL_00a6: Expected O, but got I
		Pickup pickup;
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool shouldCallValidatePickups = default(bool);
		bool isRemote = default(bool);
		PickupTeleporter result;
		nint num;
		Pickup result2;
		Pickup pickup2;
		if (teleporterType == ItemType.TELEPORTER)
		{
			if ((object)GM.Core == null)
			{
				goto IL_01ff;
			}
			pickup = GM.Core.MakePickup(gatePosition, ItemType.TELEPORTER, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			bool flag = (object)pickup == null;
			result = null;
			if (flag)
			{
				goto IL_022d;
			}
			num = (nint)typeof(PickupTeleporter);
			result2 = pickup;
			pickup2 = null;
		}
		else
		{
			if (teleporterType != ItemType.EME_TELEPORTER)
			{
				object obj = default(object);
				object arg = (ItemType)obj;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "ItemType {0} isn't a teleporter", (System.ParamsArray)(&obj2));
				Exception exception = new Exception(message);
				Debug.LogException(exception);
				return null;
			}
			if ((object)GM.Core == null)
			{
				goto IL_01ff;
			}
			pickup = GM.Core.MakePickup(gatePosition, ItemType.EME_TELEPORTER, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
			bool flag2 = (object)pickup == null;
			result = null;
			if (flag2)
			{
				goto IL_022d;
			}
			num = (nint)typeof(Pickup_EME_Teleporter);
			result2 = pickup;
			pickup2 = null;
		}
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Items.PickupTeleporter>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v6+FFFFFFF8+v329 @ rax_v3*8]");
			if (0 == num)
			{
				return (PickupTeleporter)result2;
			}
		}
		result = (PickupTeleporter)pickup2;
		goto IL_022d;
		IL_022d:
		return result;
		IL_01ff:
		return (PickupTeleporter)(object)new NullReferenceException();
	}

	private void Pianificami(SuperObject superObject)
	{
	}

	public unsafe Vector2 GetSpawnPosFromSuperObject(SuperObject superObject, SuperCustomProperties scp)
	{
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected Ref, but got Unknown
		//IL_014e: Expected I8, but got I4
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected Ref, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected Ref, but got Unknown
		//IL_02b6: Expected I8, but got I4
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39A9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)scp == null)
		{
			goto IL_0353;
		}
		if (CustomPropertyListExtensions.TryGetProperty(scp.m_Properties, "xMultiplier", out var property))
		{
			if (property == null)
			{
				goto IL_0353;
			}
			string type = property.m_Type;
			object obj = "float";
			if ((object)property.m_Type == "float")
			{
				goto IL_019b;
			}
			if (property.m_Type != null && "float" != null)
			{
				int stringLength = type._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v19+10]");
				if ((nint)stringLength == 0)
				{
					ref byte second = ref *(byte*)("float" + 20);
					ulong length = (ulong)(type._stringLength + type._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref *(byte*)(property.m_Type + 20), ref second, length))
					{
						goto IL_019b;
					}
				}
			}
			int num = StringExtensions.ToInt(property.m_Value);
		}
		goto IL_0377;
		IL_0308:
		CustomProperty property2;
		float num2 = StringExtensions.ToFloat(property2.m_Value);
		goto IL_03ad;
		IL_0377:
		if (CustomPropertyListExtensions.TryGetProperty(scp.m_Properties, "yMultiplier", out property2))
		{
			if (property2 == null)
			{
				goto IL_0353;
			}
			string type2 = property2.m_Type;
			object obj2 = "float";
			if ((object)property2.m_Type == "float")
			{
				goto IL_0308;
			}
			bool flag = property2.m_Type == null;
			ulong num3 = (ulong)(nint)(&property2);
			if (!flag)
			{
				bool flag2 = "float" == null;
				num3 = (ulong)(nint)(&property2);
				if (!flag2)
				{
					int stringLength2 = type2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rdx_v12+10]");
					bool flag3 = (nint)stringLength2 != 0;
					num3 = (ulong)(nint)(&property2);
					if (!flag3)
					{
						ref byte second2 = ref *(byte*)("float" + 20);
						num3 = (ulong)(type2._stringLength + type2._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref *(byte*)(property2.m_Type + 20), ref second2, num3))
						{
							goto IL_0308;
						}
					}
				}
			}
			int num4 = StringExtensions.ToInt(property2.m_Value);
		}
		goto IL_03ad;
		IL_03ad:
		if ((object)superObject != null)
		{
			Transform transform = superObject.transform;
			if ((object)transform != null)
			{
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 result = default(Vector2);
				return result;
			}
		}
		goto IL_0353;
		IL_0353:
		throw new NullReferenceException();
		IL_019b:
		num2 = StringExtensions.ToFloat(property.m_Value);
		goto IL_0377;
	}

	private static void SetGuardedDataForItem(SuperCustomProperties scp, PickupGuarded item)
	{
		if (CustomPropertyListExtensions.TryGetProperty(scp.m_Properties, "guards", out var property))
		{
			bool flag = CustomPropertyListExtensions.TryGetProperty(scp.m_Properties, "spawnQuantity", out var property2);
			bool flag2 = !flag;
			int num = 0;
			if (!flag2)
			{
				int num2 = StringExtensions.ToInt(property2.m_Value);
				num = num2;
			}
			bool flag3 = CustomPropertyListExtensions.TryGetProperty(scp.m_Properties, "spawnAngle", out var property3);
			bool flag4 = !flag3;
			float num3 = 360f;
			if (!flag4)
			{
				float num4 = StringExtensions.ToFloat(property3.m_Value);
				num3 = num4;
			}
			EnemyType enemyType = Enum.Parse<EnemyType>(property.m_Value);
			float num5 = num3 * ((float)Math.PI / 180f);
			int num6 = num ^ num;
			int num7 = num & num6;
			bool flag5 = num7 < 0;
			bool flag6 = num < 0;
			bool flag7 = num == 0;
			item._enemyType = enemyType;
			bool flag8 = flag6 == flag5;
			bool flag9 = !flag7;
			bool flag10 = flag9 & flag8;
			item._spawnQuantity = num;
			item._003CIsAnyGuardAlive_003Ek__BackingField = flag10;
			item._003CSpawnAngle_003Ek__BackingField = num5;
			item._hasAssignedSpawnData = true;
		}
	}

	private void StoreScript(SuperObject superObject)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4BD0");
	}

	private unsafe void SpawnAdventureMerchant(SuperObject superObject)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Ref, but got Unknown
		//IL_0112: Expected I8, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string type = superObject.m_Type;
		object obj = "";
		if ((object)superObject.m_Type == "")
		{
			return;
		}
		if (superObject.m_Type != null && "" != null)
		{
			int stringLength = type._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("" + 20);
				ulong length = (ulong)(type._stringLength + type._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second, length))
				{
					return;
				}
			}
		}
		CharacterType merchantType = Enum.Parse<CharacterType>(superObject.m_Type);
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		float2 spawnPos = default(float2);
		_stage.SpawnStaticAdventureMerchant(merchantType, spawnPos);
	}

	private unsafe void SpawnCustomMerchant(SuperObject superObject)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Ref, but got Unknown
		//IL_0112: Expected I8, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		SuperCustomProperties component = superObject.GetComponent<SuperCustomProperties>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string type = superObject.m_Type;
		object obj = "";
		if ((object)superObject.m_Type == "")
		{
			return;
		}
		if (superObject.m_Type != null && "" != null)
		{
			int stringLength = type._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("" + 20);
				ulong length = (ulong)(type._stringLength + type._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(superObject.m_Type + 20), ref second, length))
				{
					return;
				}
			}
		}
		CharacterType merchantType = Enum.Parse<CharacterType>(superObject.m_Type);
		Vector2 spawnPosFromSuperObject = GetSpawnPosFromSuperObject(superObject, component);
		PickupCustomMerchant pickupCustomMerchant = _stage.SpawnStaticCustomMerchant(merchantType, spawnPosFromSuperObject);
	}

	private void HandleSortingOrders(SuperMap map)
	{
		//IL_02dc: Expected I4, but got I8
		//IL_02f8: Expected I4, but got I8
		//IL_0314: Expected I4, but got I8
		//IL_0021: Expected I4, but got I8
		//IL_003d: Expected I4, but got I8
		//IL_005e: Expected I4, but got I8
		//IL_007a: Expected I4, but got I8
		//IL_009b: Expected I4, but got I8
		//IL_00b7: Expected I4, but got I8
		//IL_0121: Expected I4, but got I8
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		bool visible = default(bool);
		SetTilemapLayerSortingOrder(map, "Floor", -2000, visible);
		SetTilemapLayerSortingOrder(map, "FloorOverlay", -1999, visible);
		SetTilemapLayerSortingOrder(map, "FakeWalls", -1998, visible);
		SetTilemapLayerSortingOrder(map, "FakeWalls2", -1997, visible);
		SetTilemapLayerSortingOrder(map, "FakeWalls3", -1996, visible);
		SetTilemapLayerSortingOrder(map, "Walls", -1997, visible);
		SetTilemapLayerSortingOrder(map, "PlayerWall", -1996, visible);
		SetTilemapLayerSortingOrder(map, "Obstacle", -1995, visible);
		SetTilemapLayerSortingOrder(map, "Decals", -1994, visible);
		int sortingOrder;
		if (_stageType != StageType.CARLOCART)
		{
			bool flag = _stageType != StageType.ADV_FOSCARI_002;
			sortingOrder = 1;
			if (flag)
			{
				goto IL_0319;
			}
		}
		sortingOrder = 1993;
		goto IL_0319;
		IL_0319:
		if (_visuallyInverted)
		{
			sortingOrder = -1993;
		}
		SetTilemapLayerSortingOrder(map, "Overlay1", sortingOrder, visible);
		SetTilemapLayerSortingOrder(map, "Shadows", 1994, visible);
		SetTilemapLayerSortingOrder(map, "ShadowDecals", 1995, visible);
		SetTilemapLayerSortingOrder(map, "Spawning", 10000, visible);
		SuperTileLayer[] componentsInChildren = map.GetComponentsInChildren<SuperTileLayer>();
		CustomProperty customProperty = null;
		CustomProperty property = null;
		while ((nint)customProperty < componentsInChildren.Length)
		{
			SuperCustomProperties component = componentsInChildren[(object)customProperty].GetComponent<SuperCustomProperties>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "DepthOverride", out property))
			{
				string text = property.m_Name;
				if (property.m_Name != null && text._stringLength > 0)
				{
					int sortingOrder2 = StringExtensions.ToInt(property.m_Value);
					TilemapRenderer component2 = componentsInChildren[(object)customProperty].GetComponent<TilemapRenderer>();
					if ((object)component2 != null)
					{
						component2.sortingOrder = sortingOrder2;
					}
				}
			}
			customProperty = (CustomProperty)(customProperty + 1);
		}
	}

	private void SetTilemapLayerSortingOrder(SuperMap map, string layerName, int sortingOrder, bool visible = true)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected I4, but got Unknown
		SuperTileLayer superTileLayer = GetSuperTileLayer(map, layerName);
		if ((object)superTileLayer != null && ((UnityEngine.Object)superTileLayer).m_CachedPtr != (IntPtr)0)
		{
			TilemapRenderer component = superTileLayer.GetComponent<TilemapRenderer>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				component.sortingOrder = sortingOrder;
				object obj = default(object);
				bool forceRenderingOff = (byte)(obj ^ 1) != 0;
				component.forceRenderingOff = forceRenderingOff;
			}
		}
	}

	private PhaserTilemap AddPhaserTilemap(SuperMap map, string layerName, int setID)
	{
		PhaserTilemap phaserTilemapFromLayer = GetPhaserTilemapFromLayer(map, layerName);
		if ((object)phaserTilemapFromLayer != null && ((UnityEngine.Object)phaserTilemapFromLayer).m_CachedPtr != (IntPtr)0)
		{
			phaserTilemapFromLayer._parentSetID = setID;
			if (_phaserTilemaps == null)
			{
				return (PhaserTilemap)(object)new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B44C0");
		}
		return phaserTilemapFromLayer;
	}

	private void HandleArcadePhysics(List<SuperMap> maps)
	{
		//IL_00d9: Expected I4, but got O
		PhysicsManager sInstance = PhysicsManager._sInstance;
		ArcadeColliderType @object = default(ArcadeColliderType);
		ArcadePhysicsCallback collideCallback = default(ArcadePhysicsCallback);
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		TilemapSetCollider tilemapSetCollider = new TilemapSetCollider(ArcadePhysics.s_world, overlapOnly: false, sInstance._playersWithWallCollisionGroup, @object, collideCallback, processCallback, callbackContext);
		Collider collider = tilemapSetCollider.setName("Player>AllWalls");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if ((object)s_scene.physics != null)
		{
			PhysicsManager sInstance2 = PhysicsManager._sInstance;
			TilemapSetCollider tilemapSetCollider2 = new TilemapSetCollider(ArcadePhysics.s_world, overlapOnly: false, sInstance2._enemyGroup, @object, collideCallback, processCallback, callbackContext);
			Collider collider2 = tilemapSetCollider2.setName("Enemies>AllWalls");
			int num = 0;
			object obj = null;
			System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)sInstance2._enemyGroup;
			int num2 = 0;
			TilingTileset tilingTileset = this;
			while (num2 < maps._size)
			{
				if (num < maps._size)
				{
					SuperMap[] items = maps._items;
					PhaserTilemap phaserTilemap = tilingTileset.AddPhaserTilemap(items[num], "Walls", num);
					PhaserTilemap phaserTilemap2 = tilingTileset.AddPhaserTilemap(items[num], "PlayerWall", num);
					PhaserTilemap phaserTilemap3 = tilingTileset.AddPhaserTilemap(items[num], "Obstacle", num);
					bool flag = (object)phaserTilemap == null;
					PhaserTilemap phaserTilemap4 = (PhaserTilemap)(object)"Obstacle";
					int num3 = num;
					if (!flag)
					{
						bool flag2 = ((UnityEngine.Object)phaserTilemap).m_CachedPtr == (IntPtr)0;
						phaserTilemap4 = (PhaserTilemap)(object)"Obstacle";
						num3 = num;
						if (!flag2)
						{
							tilemapSetCollider.AddTilemap(num, phaserTilemap);
							phaserTilemap4 = phaserTilemap;
							num3 = 0;
						}
					}
					if ((bool)phaserTilemap3)
					{
						tilemapSetCollider.AddTilemap(num, phaserTilemap3);
						phaserTilemap4 = phaserTilemap3;
						num3 = 0;
					}
					if ((bool)phaserTilemap2)
					{
						tilemapSetCollider.AddTilemap(num, phaserTilemap2);
						phaserTilemap4 = phaserTilemap2;
						num3 = 0;
					}
					if ((bool)phaserTilemap)
					{
						tilemapSetCollider2.AddTilemap(num, phaserTilemap);
						phaserTilemap4 = phaserTilemap;
						num3 = 0;
					}
					if ((bool)phaserTilemap3)
					{
						tilemapSetCollider2.AddTilemap(num, phaserTilemap3);
						phaserTilemap4 = phaserTilemap3;
						num3 = 0;
					}
					List<PhaserTilemap> list = new List<PhaserTilemap>();
					if ((bool)phaserTilemap)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B44C0");
					}
					if ((bool)phaserTilemap3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B44C0");
					}
					if ((bool)phaserTilemap2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B44C0");
					}
					bool flag3 = ((Dictionary<object, object>)(object)_cachedCollisionTilemaps).TryInsert((object)items[num], (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					num++;
					obj = list;
					insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
					num2 = num;
					tilingTileset = this;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			World s_world = ArcadePhysics.s_world;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
			World s_world2 = ArcadePhysics.s_world;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
			return;
		}
		throw new NullReferenceException();
	}

	private PhaserTilemap GetPhaserTilemapFromLayer(SuperMap map, string layerName)
	{
		SuperTileLayer superTileLayer = GetSuperTileLayer(map, layerName);
		if ((object)superTileLayer != null && ((UnityEngine.Object)superTileLayer).m_CachedPtr != (IntPtr)0)
		{
			PhaserTilemap component = superTileLayer.GetComponent<PhaserTilemap>();
			if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
			{
				string message = "PhaserTilemap for layer " + layerName + " not found!";
				Debug.LogWarning(message);
			}
			return component;
		}
		string message2 = "Layer " + layerName + " not found!";
		Debug.LogWarning(message2);
		return null;
	}

	private unsafe void ProcessTiling()
	{
		//IL_0ee5: Expected O, but got I
		//IL_0f18: Expected O, but got I
		//IL_1038: Expected O, but got I4
		//IL_0537: Expected O, but got Ref
		//IL_058c: Expected O, but got I4
		//IL_05d9: Expected O, but got I4
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Expected O, but got Unknown
		//IL_04a2: Expected O, but got F4
		//IL_0828: Expected O, but got I
		//IL_0870: Expected O, but got I4
		//IL_0a52: Expected O, but got Ref
		//IL_0c00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c05: Expected O, but got Unknown
		//IL_0cfa: Invalid comparison between F4 and O
		//IL_0e08: Expected I, but got O
		//IL_0d3b: Expected O, but got I
		//IL_0d92: Invalid comparison between F4 and O
		//IL_0db1: Invalid comparison between F4 and I4
		//IL_0dda: Expected O, but got I4
		//IL_1137: Unknown result type (might be due to invalid IL or missing references)
		//IL_113c: Expected O, but got Unknown
		//IL_0f36->IL0f36: Incompatible stack heights: 2 vs 0
		//IL_0f30->IL0f5b: Incompatible stack heights: 3 vs 1
		//IL_00e1->IL0f30: Incompatible stack heights: 3 vs 2
		//IL_0230->IL0f30: Incompatible stack heights: 8 vs 2
		//IL_0293->IL0293: Incompatible stack heights: 10 vs 6
		//IL_03c8->IL04ac: Incompatible stack heights: 13 vs 10
		//IL_03cd->IL03cd: Incompatible stack heights: 13 vs 11
		//IL_0621->IL0f30: Incompatible stack heights: 13 vs 2
		//IL_1027->IL11dc: Incompatible stack heights: 13 vs 10
		//IL_068f->IL0f30: Incompatible stack heights: 15 vs 2
		//IL_04a7->IL0fdd: Incompatible stack heights: 14 vs 13
		//IL_071a->IL0f30: Incompatible stack heights: 17 vs 2
		//IL_0788->IL0f30: Incompatible stack heights: 19 vs 2
		//IL_0813->IL0f30: Incompatible stack heights: 21 vs 2
		//IL_09e0->IL0f30: Incompatible stack heights: 23 vs 2
		//IL_0acb->IL0f30: Incompatible stack heights: 27 vs 2
		//IL_11a3->IL0f5b: Incompatible stack heights: 26 vs 1
		//IL_0e70->IL1185: Incompatible stack heights: 27 vs 26
		//IL_0b42->IL0f30: Incompatible stack heights: 29 vs 2
		//IL_0e88->IL1185: Incompatible stack heights: 27 vs 26
		//IL_0bd0->IL1161: Incompatible stack heights: 34 vs 26
		object obj = default(object);
		Vector2 vector3 = default(Vector2);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj4 = default(object);
		List<Bounds>.Enumerator enumerator2 = default(List<Bounds>.Enumerator);
		Bounds _unity_self = default(Bounds);
		Bounds bounds2 = default(Bounds);
		Vector3 value = default(Vector3);
		object obj27 = default(object);
		while (true)
		{
			List<SuperMap> maps = _maps;
			bool flag = _maps == null;
			Vector2 ret;
			object obj2;
			Vector2 vector5;
			Transform transform4;
			if (maps._size != 1)
			{
				if (maps._size == 2)
				{
					break;
				}
				GameManager core = GM.Core;
				bool flag2 = (object)GM.Core == null;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
				bool flag3 = core._mainCharacters == null;
				if (mainCharacters._size <= 0)
				{
					goto IL_0f30;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				bool flag4 = mainCharacters._items == null;
				Component component = items[0];
				bool flag5 = (object)items[0] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ r13_v14 (UnityEngine.Component)+2C0]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FF0100");
				Component component2;
				if (obj == null)
				{
					component2 = items[0];
				}
				else
				{
					GameManager core2 = GM.Core;
					bool flag7 = (object)GM.Core == null;
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core2._mainCharacters;
					GameManager core3 = GM.Core;
					int num = core3._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
					bool flag8 = core2._mainCharacters == null;
					if (core3._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField >= mainCharacters2._size)
					{
						goto IL_0f30;
					}
					VampireSurvivors.Objects.Characters.CharacterController[] items2 = mainCharacters2._items;
					bool flag9 = mainCharacters2._items == null;
					component2 = items2[num];
					bool flag10 = (object)items2[num] == null;
				}
				Transform transform = component2.transform;
				bool flag11 = (object)transform == null;
				bool flag12 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				GameManager core4 = GM.Core;
				bool flag13 = (object)GM.Core == null;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters3 = core4._mainCharacters;
				bool flag14 = core4._mainCharacters == null;
				if (mainCharacters3._size <= 1)
				{
					goto IL_04ac;
				}
				GameManager core5 = GM.Core;
				bool flag15 = core5._multiplayer == null;
				if (core5._multiplayer.IsOnlineMultiplayer)
				{
					bool flag16 = _playerOptions == null;
					PlayerOptionsData config = _playerOptions.Config;
					bool flag17 = config == null;
					if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
					{
						goto IL_04ac;
					}
				}
				Vector3 vector = Vector3.zeroVector;
				GameManager core6 = GM.Core;
				bool flag18 = (object)GM.Core == null;
				bool flag19 = core6._characters == null;
				Vector2 vector2 = vector3;
				Transform transform2 = null;
				while (enumerator.MoveNext())
				{
					Component component3 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1960 @ rcx_v82 (UnityEngine.Component)+34E]");
					if ((nint)0 != 0)
					{
						Transform transform3 = ((Component)null).transform;
						bool flag20 = (object)transform3 == null;
						float num2 = transform3.position.x + (float)vector;
						Vector2 vector4 = vector3 + vector2;
						transform2 = (Transform)(transform2 + 1);
						vector2 = vector4;
						vector = (Vector3)num2;
					}
				}
				obj2 = (object)vector2 / (object)transform2;
				vector5 = (Vector2)((object)vector / (object)transform2);
				transform4 = null;
				goto IL_11dc;
			}
			List<Bounds> bounds = _bounds;
			bool flag21 = _bounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
				bool flag22 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v34+20]");
				_currentBounds = (Bounds)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v34+30]");
				_ = 0;
				UpdatePhaserTilemapBounds();
				break;
			}
			goto IL_0f30;
			IL_04ac:
			obj2 = obj4;
			vector5 = ret;
			transform4 = null;
			goto IL_11dc;
			IL_11dc:
			bool flag23 = _bounds == null;
			while (true)
			{
				if (!enumerator2.MoveNext())
				{
					UpdateHorizontalTilesetOnTeleport(vector3, processTiling: false);
					UpdateVerticalTilesetOnTeleport(vector3, processTiling: false);
					break;
				}
				object obj5 = Bounds.Contains_Injected(ref _unity_self, ref *(Vector3*)(&ret));
				if (obj5 != null)
				{
					_currentBounds = _unity_self;
					_ = 0;
					break;
				}
			}
			bool flag24 = _bounds == null;
			bool flag25 = _bounds.Remove((Bounds)(&bounds2));
			Bounds currentBounds = _currentBounds;
			bool flag26 = System.Runtime.CompilerServices.Unsafe.As<Bounds, UIntPtr>(ref currentBounds) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector5);
			object obj6 = (object)_currentBounds - (object)vector5;
			bool flag27 = obj6 == null;
			bool flag28 = !flag26;
			bool flag29 = !flag27;
			object obj7 = flag29 & flag28;
			bool flag30 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector3);
			object obj8 = obj2 - (object)vector3;
			bool flag31 = obj8 == null;
			bool flag32 = !flag30;
			bool flag33 = !flag31;
			object obj9 = flag33 & flag32;
			List<Bounds> bounds3 = _bounds;
			bool flag34 = _bounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rax_v61 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0f30;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rax_v61 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			bool flag35 = (nint)0 == 0;
			if (obj7 == null)
			{
			}
			List<Bounds> bounds4 = _bounds;
			bool flag36 = _bounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v37 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0f30;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v37 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			bool flag37 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v37 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
			_ = (nint)0 + (nint)1;
			List<Bounds> bounds5 = _bounds;
			bool flag38 = _bounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v958 @ rax_v67 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)0 <= (nint)1)
			{
				goto IL_0f30;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v958 @ rax_v67 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			bool flag39 = (nint)0 == 0;
			if (obj9 == null)
			{
			}
			List<Bounds> bounds6 = _bounds;
			bool flag40 = _bounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v38 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)0 <= (nint)1)
			{
				goto IL_0f30;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v38 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			bool flag41 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v38 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
			_ = (nint)0 + (nint)1;
			List<Bounds> bounds7 = _bounds;
			bool flag42 = _bounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rax_v73 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)0 <= (nint)2)
			{
				goto IL_0f30;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rax_v73 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rax_v73 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			bool flag43 = (nint)0 == 0;
			object obj11 = obj7 & obj9;
			bool flag44 = obj11 == null;
			object obj12 = !flag44;
			float num4;
			float num6;
			float num10;
			if (obj12 == null)
			{
				if (obj9 == null)
				{
					if (obj7 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3305 @ rcx_v47 (VampireSurvivors.Objects.TilingTileset)+9C]");
						float num3 = 0f * 2f;
						num4 = (float)_currentBounds + num3;
						float num5 = (float)vector3 * 2f;
						num6 = (float)vector3 - num5;
						goto IL_109f;
					}
					float num7 = (float)vector3 * 2f;
					float num8 = (float)_currentBounds - num7;
					float num9 = (float)vector3 * 2f;
					num10 = (float)vector3 - num9;
					num4 = num8;
					goto IL_10c4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3305 @ rcx_v47 (VampireSurvivors.Objects.TilingTileset)+9C]");
				float num11 = 0f * 2f;
				float num12 = (float)_currentBounds + num11;
				num4 = num12;
			}
			else
			{
				float num13 = (float)vector3 * 2f;
				float num14 = (float)_currentBounds - num13;
				num4 = num14;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v962 @ rax_v74+60]");
			float num15 = 0f * 2f;
			num10 = (float)vector3 + num15;
			goto IL_10c4;
			IL_109f:
			List<Bounds> bounds8 = _bounds;
			bool flag45 = _bounds == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v40 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			if ((nint)0 > (nint)2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v40 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
				bool flag46 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v40 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
				_ = (nint)0 + (nint)1;
				bool flag47 = _bounds == null;
				_bounds.Insert(0, (Bounds)(&bounds2));
				List<SuperMap> maps2 = _maps;
				bool flag48 = _maps == null;
				Transform transform5 = transform4;
				Transform transform6 = transform4;
				while (true)
				{
					if ((nint)transform6 < maps2._size)
					{
						List<SuperMap> maps3 = _maps;
						bool flag49 = _maps == null;
						if ((nint)transform5 >= maps3._size)
						{
							break;
						}
						SuperMap[] items3 = maps3._items;
						bool flag50 = maps3._items == null;
						List<Bounds> bounds9 = _bounds;
						bool flag51 = _bounds == null;
						Transform obj13 = transform5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ rax_v96 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
						if ((nint)obj13 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ rax_v96 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
						bool flag52 = (nint)0 == 0;
						bool flag53 = (object)items3[(object)transform5] == null;
						Transform transform7 = items3[(object)transform5].transform;
						bool flag54 = (object)transform7 == null;
						bool flag55 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref value);
						transform5 = (Transform)(transform5 + 1);
						maps2 = _maps;
						bool flag56 = _maps == null;
						transform6 = transform5;
						continue;
					}
					float num16 = (float)_previousTilingCenter - num4;
					float num17 = (float)vector3 - num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3305 @ rcx_v47 (VampireSurvivors.Objects.TilingTileset)+B0]");
					object obj14 = 0 - vector3;
					float num18 = num17 * num17;
					float num19 = num16 * num16;
					float num20 = num18 + num19;
					object obj15 = obj14 * obj14;
					float num21 = num20 + (float)obj15;
					if (!(9.9999994E-11f > num21))
					{
						UpdatePhaserTilemapBounds();
					}
					_previousTilingCenter = vector3;
					object obj16 = (object)_currentBounds - (object)_previousFirstMap;
					object obj17 = vector3 - vector3;
					object obj18 = vector3 - vector3;
					object obj19 = obj17 * obj17;
					object obj20 = obj16 * obj16;
					object obj21 = obj19 + obj20;
					object obj22 = obj18 * obj18;
					object obj23 = obj21 + obj22;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj23))
					{
						object obj24 = vector3 - vector3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3305 @ rcx_v47 (VampireSurvivors.Objects.TilingTileset)+A0]");
						nint num22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3305 @ rcx_v47 (VampireSurvivors.Objects.TilingTileset)+10C]");
						object obj25 = num22 - 0;
						object obj26 = obj27 - obj27;
						object obj28 = obj24 * obj24;
						object obj29 = obj25 * obj25;
						object obj30 = obj28 + obj29;
						object obj31 = obj26 * obj26;
						object obj32 = obj30 + obj31;
						bool flag57 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj32);
						float num23 = 9.9999994E-11f - (float)obj32;
						bool flag58 = num23 == 0f;
						bool flag59 = !flag57;
						bool flag60 = !flag58;
						object obj33 = flag60 & flag59;
						if (obj33 != null)
						{
							goto IL_1185;
						}
					}
					nint num24 = (nint)typeof(Debug);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3271 @ rcx_v46 (Il2CppClass<UnityEngine.Debug>)+E4]");
					if ((nint)0 == 0)
					{
						Debug.Log("Tilemaps moved");
					}
					else
					{
						Debug.Log("Tilemaps moved");
					}
					Vector2 defaultMapPosition = DefaultMapPosition;
					Stage stage = _stage;
					bool flag61 = (object)_stage == null;
					if ((object)stage._fancyBg != null)
					{
						stage._fancyBg.OnPlayerEnteringDifferentTilemap();
					}
					goto IL_1185;
					IL_1185:
					_previousFirstMap = _currentBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3305 @ rcx_v47 (VampireSurvivors.Objects.TilingTileset)+A0]");
					_ = 0;
					return;
				}
			}
			goto IL_0f30;
			IL_10c4:
			num6 = num10;
			goto IL_109f;
			IL_0f30:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void UpdateHorizontalTilesetOnTeleport(Vector2 playerPos, bool processTiling = true)
	{
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d7: Expected O, but got I4
		//IL_006e: Invalid comparison between I and F4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_0135: Expected O, but got I
		//IL_01a6: Expected O, but got I
		//IL_0254: Expected O, but got I
		//IL_026b: Expected O, but got I
		//IL_028c->IL02ac: Incompatible stack heights: 3 vs 0
		//IL_029c->IL02ac: Incompatible stack heights: 3 vs 0
		_ = 0;
		object obj2 = default(object);
		object obj = obj2 - 96;
		object obj3 = this + 144;
		object obj4 = Bounds.Contains_Injected(ref *(Bounds*)obj3, ref *(Vector3*)obj);
		if (obj4 != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingTileset)+9C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingTileset)+9C]");
		float num = 0f * 2f;
		float num2 = num * 0.5f;
		_ = _currentBounds;
		_ = _currentBounds;
		float num3 = (float)_currentBounds + num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+20]");
		if (0f == num3)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+20]");
		object obj5 = 0 - _currentBounds;
		_ = _currentBounds;
		float num4 = (float)obj5 / num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj6 = num4 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		object obj7 = default(object);
		if ((nint)obj7 != 1)
		{
			_ = _currentBounds;
			List<Bounds> bounds = _bounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			bool flag = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v13+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v13+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingTileset)+98]");
			_ = 0;
			_ = _currentBounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			bool flag2 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-34]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-2C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-24]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
			_ = (nint)0 + (nint)1;
			List<Bounds> bounds2 = _bounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v20 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			bool flag3 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v20 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v21+20]");
			_currentBounds = (Bounds)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v21+30]");
			_ = 0;
			if (processTiling)
			{
				ProcessTiling();
			}
		}
	}

	public unsafe void UpdateVerticalTilesetOnTeleport(Vector2 playerPos, bool processTiling = true)
	{
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02cb: Expected O, but got I4
		//IL_0064: Invalid comparison between I and F4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_0129: Expected O, but got I
		//IL_019a: Expected O, but got I
		//IL_0248: Expected O, but got I
		//IL_025f: Expected O, but got I
		//IL_0280->IL02a0: Incompatible stack heights: 3 vs 0
		//IL_0290->IL02a0: Incompatible stack heights: 3 vs 0
		_ = 0;
		object obj2 = default(object);
		object obj = obj2 - 96;
		object obj3 = this + 144;
		object obj4 = Bounds.Contains_Injected(ref *(Bounds*)obj3, ref *(Vector3*)obj);
		if (obj4 != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingTileset)+9C]");
		_ = 0;
		object obj5 = default(object);
		float num = (float)obj5 * 2f;
		float num2 = num * 0.5f;
		_ = _currentBounds;
		_ = _currentBounds;
		float num3 = (float)obj5 + num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
		if (0f == num3)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+24]");
		object obj6 = 0 - obj5;
		_ = _currentBounds;
		float num4 = (float)obj6 / num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj7 = num4 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		object obj8 = default(object);
		if ((nint)obj8 != 1)
		{
			_ = _currentBounds;
			List<Bounds> bounds = _bounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			bool flag = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v13+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v13+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingTileset)+98]");
			_ = 0;
			_ = _currentBounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			bool flag2 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-34]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-2C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-24]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
			_ = (nint)0 + (nint)1;
			List<Bounds> bounds2 = _bounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v20 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
			bool flag3 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v20 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v21+20]");
			_currentBounds = (Bounds)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v21+30]");
			_ = 0;
			if (processTiling)
			{
				ProcessTiling();
			}
		}
	}

	public unsafe void MoveTilesetForHorizontalRoad(float speedMultiplier)
	{
		//IL_0766: Expected O, but got I
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Expected O, but got Unknown
		//IL_09d0: Expected O, but got I
		//IL_1b11: Invalid comparison between O and F4
		//IL_1c6e: Invalid comparison between F4 and O
		//IL_1374: Expected O, but got Ref
		//IL_1d49: Expected O, but got I4
		//IL_1437: Expected O, but got I4
		//IL_1548: Expected O, but got Ref
		//IL_16ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f3: Expected O, but got Unknown
		//IL_1c13: Expected F4, but got I4
		//IL_1320: Expected O, but got Ref
		//IL_1ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de4: Expected O, but got Unknown
		//IL_1778->IL1778: Incompatible stack heights: 2 vs 0
		//IL_012c->IL1772: Incompatible stack heights: 7 vs 2
		//IL_01db->IL1772: Incompatible stack heights: 10 vs 2
		//IL_0288->IL1772: Incompatible stack heights: 15 vs 2
		//IL_0335->IL1772: Incompatible stack heights: 20 vs 2
		//IL_057c->IL1772: Incompatible stack heights: 39 vs 2
		//IL_0629->IL1772: Incompatible stack heights: 44 vs 2
		//IL_06e3->IL1772: Incompatible stack heights: 51 vs 2
		//IL_0751->IL1772: Incompatible stack heights: 53 vs 2
		//IL_07cf->IL1772: Incompatible stack heights: 55 vs 2
		//IL_083d->IL1772: Incompatible stack heights: 57 vs 2
		//IL_08c2->IL1772: Incompatible stack heights: 59 vs 2
		//IL_094d->IL1772: Incompatible stack heights: 61 vs 2
		//IL_09bb->IL1772: Incompatible stack heights: 63 vs 2
		//IL_0a39->IL1772: Incompatible stack heights: 65 vs 2
		//IL_0aa7->IL1772: Incompatible stack heights: 67 vs 2
		//IL_0b2e->IL1772: Incompatible stack heights: 69 vs 2
		//IL_0bc8->IL1772: Incompatible stack heights: 71 vs 2
		//IL_0f82->IL1772: Incompatible stack heights: 76 vs 2
		//IL_0c9a->IL1772: Incompatible stack heights: 76 vs 2
		//IL_0d49->IL1772: Incompatible stack heights: 79 vs 2
		//IL_1054->IL1772: Incompatible stack heights: 81 vs 2
		//IL_0e1e->IL1772: Incompatible stack heights: 83 vs 2
		//IL_13c0->IL1772: Incompatible stack heights: 83 vs 2
		//IL_1103->IL1772: Incompatible stack heights: 84 vs 2
		//IL_14d6->IL1772: Incompatible stack heights: 85 vs 2
		//IL_0ecb->IL1772: Incompatible stack heights: 88 vs 2
		//IL_11b0->IL1772: Incompatible stack heights: 89 vs 2
		//IL_15bb->IL1772: Incompatible stack heights: 89 vs 2
		//IL_1632->IL1772: Incompatible stack heights: 91 vs 2
		//IL_1c21->IL1e2d: Incompatible stack heights: 94 vs 75
		//IL_125d->IL1772: Incompatible stack heights: 94 vs 2
		//IL_1326->IL1326: Incompatible stack heights: 98 vs 80
		//IL_16c0->IL1e09: Incompatible stack heights: 96 vs 88
		Vector3 value = default(Vector3);
		float num5 = default(float);
		List<Bounds>.Enumerator enumerator = default(List<Bounds>.Enumerator);
		Bounds _unity_self = default(Bounds);
		Bounds bounds11 = default(Bounds);
		Vector3 vector = default(Vector3);
		Bounds bounds14 = default(Bounds);
		while (true)
		{
			GameManager core = GM.Core;
			bool flag = (object)GM.Core == null;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			bool flag2 = core._mainCharacters == null;
			if (mainCharacters._size > 0)
			{
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				bool flag3 = mainCharacters._items == null;
				bool flag4 = (object)items[0] == null;
				Transform transform = items[0].transform;
				bool flag5 = (object)transform == null;
				bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float num = speedMultiplier * -0.064f;
				offset = num;
				List<SuperMap> maps = _maps;
				bool flag7 = _maps == null;
				if (maps._size > 0)
				{
					SuperMap[] items2 = maps._items;
					bool flag8 = maps._items == null;
					bool flag9 = (object)items2[0] == null;
					Transform transform2 = items2[0].transform;
					List<SuperMap> maps2 = _maps;
					bool flag10 = _maps == null;
					if (maps2._size > 0)
					{
						SuperMap[] items3 = maps2._items;
						bool flag11 = maps2._items == null;
						bool flag12 = (object)items3[0] == null;
						Transform transform3 = items3[0].transform;
						bool flag13 = (object)transform3 == null;
						bool flag14 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret2);
						List<SuperMap> maps3 = _maps;
						bool flag15 = _maps == null;
						if (maps3._size > 0)
						{
							SuperMap[] items4 = maps3._items;
							bool flag16 = maps3._items == null;
							bool flag17 = (object)items4[0] == null;
							Transform transform4 = items4[0].transform;
							bool flag18 = (object)transform4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1658 @ rax_v134 (UnityEngine.Transform)+10]");
							bool flag19 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1658 @ rax_v134 (UnityEngine.Transform)+10]");
							float ret3;
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
							List<SuperMap> maps4 = _maps;
							bool flag20 = _maps == null;
							if (maps4._size > 0)
							{
								SuperMap[] items5 = maps4._items;
								bool flag21 = maps4._items == null;
								bool flag22 = (object)items5[0] == null;
								Transform transform5 = items5[0].transform;
								bool flag23 = (object)transform5 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1660 @ rax_v142 (UnityEngine.Transform)+10]");
								bool flag24 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1660 @ rax_v142 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 ret4);
								bool flag25 = (object)transform2 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ rax_v125 (UnityEngine.Transform)+10]");
								bool flag26 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1655 @ rax_v125 (UnityEngine.Transform)+10]");
								Transform.set_position_Injected((IntPtr)0, ref value);
								List<SuperMap> maps5 = _maps;
								bool flag27 = _maps == null;
								bool flag28 = maps5._size <= 1;
								SuperMap[] items6 = maps5._items;
								bool flag29 = maps5._items == null;
								bool flag30 = items6.Length <= 1;
								bool flag31 = (object)items6[1] == null;
								Transform transform6 = items6[1].transform;
								List<SuperMap> maps6 = _maps;
								bool flag32 = _maps == null;
								bool flag33 = maps6._size <= 1;
								SuperMap[] items7 = maps6._items;
								bool flag34 = maps6._items == null;
								bool flag35 = items7.Length <= 1;
								bool flag36 = (object)items7[1] == null;
								Transform transform7 = items7[1].transform;
								bool flag37 = (object)transform7 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4993 @ rax_v155 (UnityEngine.Transform)+10]");
								bool flag38 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4993 @ rax_v155 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out ret4);
								List<SuperMap> maps7 = _maps;
								bool flag39 = _maps == null;
								if (maps7._size > 1)
								{
									SuperMap[] items8 = maps7._items;
									bool flag40 = maps7._items == null;
									bool flag41 = (object)items8[1] == null;
									Transform transform8 = items8[1].transform;
									bool flag42 = (object)transform8 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1662 @ rax_v163 (UnityEngine.Transform)+10]");
									bool flag43 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1662 @ rax_v163 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
									List<SuperMap> maps8 = _maps;
									bool flag44 = _maps == null;
									if (maps8._size > 1)
									{
										SuperMap[] items9 = maps8._items;
										bool flag45 = maps8._items == null;
										bool flag46 = (object)items9[1] == null;
										Transform transform9 = items9[1].transform;
										bool flag47 = (object)transform9 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1664 @ rax_v171 (UnityEngine.Transform)+10]");
										bool flag48 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1664 @ rax_v171 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out ret2);
										bool flag49 = (object)transform6 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4382 @ rax_v154 (UnityEngine.Transform)+10]");
										bool flag50 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4382 @ rax_v154 (UnityEngine.Transform)+10]");
										Transform.set_position_Injected((IntPtr)0, ref ret4);
										List<Bounds> bounds = _bounds;
										bool flag51 = _bounds == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2106 @ rax_v181 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
										if ((nint)0 > (nint)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2106 @ rax_v181 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
											bool flag52 = (nint)0 == 0;
											List<Bounds> bounds2 = _bounds;
											bool flag53 = _bounds == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1666 @ rax_v183 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
											if ((nint)0 > (nint)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1666 @ rax_v183 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
												object obj = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1666 @ rax_v183 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
												bool flag54 = (nint)0 == 0;
												List<Bounds> bounds3 = _bounds;
												bool flag55 = _bounds == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1668 @ rax_v185 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
												if ((nint)0 > (nint)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1668 @ rax_v185 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
													bool flag56 = (nint)0 == 0;
													List<Bounds> bounds4 = _bounds;
													bool flag57 = _bounds == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1670 @ rax_v187 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
													if ((nint)0 > (nint)0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1670 @ rax_v187 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
														bool flag58 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1667 @ rax_v184+20]");
														object obj2 = 0 + offset;
														List<Bounds> bounds5 = _bounds;
														bool flag59 = _bounds == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rcx_v143 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
														if ((nint)0 > (nint)0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rcx_v143 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
															bool flag60 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rcx_v143 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
															_ = (nint)0 + (nint)1;
															List<Bounds> bounds6 = _bounds;
															bool flag61 = _bounds == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v190 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
															if ((nint)0 > (nint)1)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v190 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																bool flag62 = (nint)0 == 0;
																List<Bounds> bounds7 = _bounds;
																bool flag63 = _bounds == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1675 @ rax_v192 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
																if ((nint)0 > (nint)1)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1675 @ rax_v192 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																	object obj3 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1675 @ rax_v192 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																	bool flag64 = (nint)0 == 0;
																	List<Bounds> bounds8 = _bounds;
																	bool flag65 = _bounds == null;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1677 @ rax_v194 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
																	if ((nint)0 > (nint)1)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1677 @ rax_v194 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																		bool flag66 = (nint)0 == 0;
																		List<Bounds> bounds9 = _bounds;
																		bool flag67 = _bounds == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1679 @ rax_v196 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
																		if ((nint)0 > (nint)1)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1679 @ rax_v196 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																			bool flag68 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1676 @ rax_v193+38]");
																			float num2 = 0f + offset;
																			List<Bounds> bounds10 = _bounds;
																			bool flag69 = _bounds == null;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v144 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
																			if ((nint)0 > (nint)1)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v144 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																				bool flag70 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v144 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
																				_ = (nint)0 + (nint)1;
																				float num3 = _sizeX * 0.5f;
																				List<SuperMap> maps9 = _maps;
																				bool flag71 = _maps == null;
																				if (maps9._size > 0)
																				{
																					SuperMap[] items10 = maps9._items;
																					bool flag72 = maps9._items == null;
																					bool flag73 = (object)items10[0] == null;
																					Transform transform10 = items10[0].transform;
																					bool flag74 = (object)transform10 == null;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1684 @ rax_v201 (UnityEngine.Transform)+10]");
																					bool flag75 = (nint)0 == 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1684 @ rax_v201 (UnityEngine.Transform)+10]");
																					Transform.get_position_Injected((IntPtr)0, out ret4);
																					float num4 = (float)ret4 + num3;
																					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
																					{
																						List<SuperMap> maps10 = _maps;
																						bool flag76 = _maps == null;
																						if (maps10._size <= 1)
																						{
																							goto IL_1772;
																						}
																						SuperMap[] items11 = maps10._items;
																						bool flag77 = maps10._items == null;
																						bool flag78 = (object)items11[1] == null;
																						Transform transform11 = items11[1].transform;
																						List<SuperMap> maps11 = _maps;
																						bool flag79 = _maps == null;
																						if (maps11._size <= 1)
																						{
																							goto IL_1772;
																						}
																						SuperMap[] items12 = maps11._items;
																						bool flag80 = maps11._items == null;
																						bool flag81 = (object)items12[1] == null;
																						Transform transform12 = items12[1].transform;
																						bool flag82 = (object)transform12 == null;
																						Vector3 position = transform12.position;
																						List<SuperMap> maps12 = _maps;
																						bool flag83 = _maps == null;
																						if (maps12._size <= 1)
																						{
																							goto IL_1772;
																						}
																						SuperMap[] items13 = maps12._items;
																						bool flag84 = maps12._items == null;
																						bool flag85 = (object)items13[1] == null;
																						Transform transform13 = items13[1].transform;
																						bool flag86 = (object)transform13 == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ rax_v293 (UnityEngine.Transform)+10]");
																						bool flag87 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ rax_v293 (UnityEngine.Transform)+10]");
																						Transform.get_position_Injected((IntPtr)0, out ret4);
																						List<SuperMap> maps13 = _maps;
																						bool flag88 = _maps == null;
																						if (maps13._size <= 1)
																						{
																							goto IL_1772;
																						}
																						SuperMap[] items14 = maps13._items;
																						bool flag89 = maps13._items == null;
																						bool flag90 = (object)items14[1] == null;
																						Transform transform14 = items14[1].transform;
																						bool flag91 = (object)transform14 == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1692 @ rax_v301 (UnityEngine.Transform)+10]");
																						bool flag92 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1692 @ rax_v301 (UnityEngine.Transform)+10]");
																						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
																						bool flag93 = (object)transform11 == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1686 @ rax_v288 (UnityEngine.Transform)+10]");
																						bool flag94 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1686 @ rax_v288 (UnityEngine.Transform)+10]");
																						Transform.set_position_Injected((IntPtr)0, ref value);
																						num2 = 0f;
																						num4 = num5;
																					}
																					List<SuperMap> maps14 = _maps;
																					bool flag95 = _maps == null;
																					if (maps14._size > 0)
																					{
																						SuperMap[] items15 = maps14._items;
																						bool flag96 = maps14._items == null;
																						bool flag97 = (object)items15[0] == null;
																						Transform transform15 = items15[0].transform;
																						bool flag98 = (object)transform15 == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1694 @ rax_v209 (UnityEngine.Transform)+10]");
																						bool flag99 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1694 @ rax_v209 (UnityEngine.Transform)+10]");
																						Transform.get_position_Injected((IntPtr)0, out ret4);
																						float num6 = (float)ret4 + num3;
																						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) >= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
																						{
																							List<SuperMap> maps15 = _maps;
																							bool flag100 = _maps == null;
																							if (maps15._size <= 1)
																							{
																								goto IL_1772;
																							}
																							SuperMap[] items16 = maps15._items;
																							bool flag101 = maps15._items == null;
																							bool flag102 = (object)items16[1] == null;
																							Transform transform16 = items16[1].transform;
																							List<SuperMap> maps16 = _maps;
																							bool flag103 = _maps == null;
																							if (maps16._size <= 0)
																							{
																								goto IL_1772;
																							}
																							SuperMap[] items17 = maps16._items;
																							bool flag104 = maps16._items == null;
																							bool flag105 = (object)items17[0] == null;
																							Transform transform17 = items17[0].transform;
																							bool flag106 = (object)transform17 == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1697 @ rax_v262 (UnityEngine.Transform)+10]");
																							bool flag107 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1697 @ rax_v262 (UnityEngine.Transform)+10]");
																							Transform.get_position_Injected((IntPtr)0, out ret4);
																							List<SuperMap> maps17 = _maps;
																							bool flag108 = _maps == null;
																							if (maps17._size <= 0)
																							{
																								goto IL_1772;
																							}
																							SuperMap[] items18 = maps17._items;
																							bool flag109 = maps17._items == null;
																							bool flag110 = (object)items18[0] == null;
																							Transform transform18 = items18[0].transform;
																							bool flag111 = (object)transform18 == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ rax_v270 (UnityEngine.Transform)+10]");
																							bool flag112 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ rax_v270 (UnityEngine.Transform)+10]");
																							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
																							List<SuperMap> maps18 = _maps;
																							bool flag113 = _maps == null;
																							if (maps18._size <= 0)
																							{
																								goto IL_1772;
																							}
																							SuperMap[] items19 = maps18._items;
																							bool flag114 = maps18._items == null;
																							bool flag115 = (object)items19[0] == null;
																							Transform transform19 = items19[0].transform;
																							bool flag116 = (object)transform19 == null;
																							num2 = transform19.position.z;
																							bool flag117 = (object)transform16 == null;
																							transform16.position = (Vector3)(&value);
																						}
																						bool flag118 = _bounds == null;
																						while (enumerator.MoveNext())
																						{
																							object obj4 = Bounds.Contains_Injected(ref _unity_self, ref value);
																							if (obj4 != null)
																							{
																								_currentBounds = _unity_self;
																								_ = 0;
																								break;
																							}
																						}
																						bool flag119 = _bounds == null;
																						bool flag120 = _bounds.Remove((Bounds)(&bounds11));
																						List<Bounds> bounds12 = _bounds;
																						bool flag121 = _bounds == null;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1703 @ rax_v225 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
																						if ((nint)0 > (nint)0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1703 @ rax_v225 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																							bool flag122 = (nint)0 == 0;
																							Bounds currentBounds = _currentBounds;
																							bool flag123 = System.Runtime.CompilerServices.Unsafe.As<Bounds, UIntPtr>(ref currentBounds) < System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret);
																							object obj5 = (object)_currentBounds - (object)ret;
																							bool flag124 = obj5 == null;
																							bool flag125 = !flag123;
																							bool flag126 = !flag124;
																							object obj6 = flag126 & flag125;
																							float num8;
																							if (obj6 == null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingTileset)+9C]");
																								float num7 = 0f * 2f;
																								num8 = (float)_currentBounds + num7;
																							}
																							else
																							{
																								float num9 = (float)vector * 2f;
																								float num10 = (float)_currentBounds - num9;
																								num8 = num10;
																							}
																							List<Bounds> bounds13 = _bounds;
																							bool flag127 = _bounds == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rcx_v161 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
																							if ((nint)0 > (nint)0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rcx_v161 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																								bool flag128 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rcx_v161 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
																								_ = (nint)0 + (nint)1;
																								bool flag129 = _bounds == null;
																								_bounds.Insert(0, (Bounds)(&bounds14));
																								List<SuperMap> maps19 = _maps;
																								bool flag130 = _maps == null;
																								object obj7 = null;
																								object obj8 = null;
																								while (true)
																								{
																									if ((nint)obj8 < maps19._size)
																									{
																										List<SuperMap> maps20 = _maps;
																										bool flag131 = _maps == null;
																										if ((nint)obj7 >= maps20._size)
																										{
																											break;
																										}
																										SuperMap[] items20 = maps20._items;
																										bool flag132 = maps20._items == null;
																										List<Bounds> bounds15 = _bounds;
																										bool flag133 = _bounds == null;
																										object obj9 = obj7;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1708 @ rax_v241 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
																										if ((nint)obj9 >= 0)
																										{
																											break;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1708 @ rax_v241 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
																										bool flag134 = (nint)0 == 0;
																										bool flag135 = (object)items20[obj7] == null;
																										Transform transform20 = items20[obj7].transform;
																										bool flag136 = (object)transform20 == null;
																										bool flag137 = ((UnityEngine.Object)transform20).m_CachedPtr == (IntPtr)0;
																										Transform.set_position_Injected(((UnityEngine.Object)transform20).m_CachedPtr, ref value);
																										obj7++;
																										maps19 = _maps;
																										bool flag138 = _maps == null;
																										obj8 = obj7;
																										continue;
																									}
																									float num11 = (float)_previousTilingCenter - num8;
																									object obj10 = vector - vector;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.TilingTileset)+B0]");
																									object obj11 = 0 - vector;
																									object obj12 = obj10 * obj10;
																									float num12 = num11 * num11;
																									float num13 = (float)obj12 + num12;
																									object obj13 = obj11 * obj11;
																									float num14 = num13 + (float)obj13;
																									if (!(9.9999994E-11f > num14))
																									{
																										UpdatePhaserTilemapBounds();
																									}
																									_previousTilingCenter = vector;
																									return;
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_1772;
			IL_1772:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe void UpdatePhaserTilemapBounds()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_0119: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_015b: Expected O, but got Ref
		//IL_016b: Expected O, but got I
		if (_phaserTilemaps == null)
		{
			return;
		}
		List<PhaserTilemap> phaserTilemaps = _phaserTilemaps;
		object obj = 0;
		PhaserTilemap phaserTilemap2 = default(PhaserTilemap);
		object obj6 = default(object);
		for (object obj2 = 0; (nint)obj2 < phaserTilemaps._size; phaserTilemaps = _phaserTilemaps, obj++, obj2 = obj)
		{
			List<PhaserTilemap> phaserTilemaps2 = _phaserTilemaps;
			if ((nint)obj < phaserTilemaps2._size)
			{
				PhaserTilemap[] items = phaserTilemaps2._items;
				PhaserTilemap phaserTilemap = items[obj];
				if ((object)items[obj] == null || ((UnityEngine.Object)phaserTilemap).m_CachedPtr == (IntPtr)0)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				List<Bounds> bounds = _bounds;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v21+A0]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rsi_v9 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
				if (num < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rsi_v9 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v21+A0]");
					object obj4 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v21+A0]");
					object obj5 = 0 + obj4;
					phaserTilemap2.UpdateTilemapBounds((Bounds)(&obj6));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdx_v9+20+v247 @ rcx_v20*8]");
					obj6 = 0;
					continue;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
		}
	}

	public TilingTileset()
	{
		List<SuperMap> maps = new List<SuperMap>();
		_maps = maps;
		List<GameObject> supportMaps = new List<GameObject>();
		_supportMaps = supportMaps;
		List<PhaserTilemap> phaserTilemaps = new List<PhaserTilemap>();
		_phaserTilemaps = phaserTilemaps;
		Dictionary<SuperMap, List<SuperTileLayer>> cachedMapSuperTilesLayers = new Dictionary<SuperMap, List<SuperTileLayer>>();
		_cachedMapSuperTilesLayers = cachedMapSuperTilesLayers;
		Dictionary<SuperMap, List<PhaserTilemap>> cachedCollisionTilemaps = new Dictionary<SuperMap, List<PhaserTilemap>>();
		_cachedCollisionTilemaps = cachedCollisionTilemaps;
		Dictionary<SuperMap, Tilemap> cachedSpawningTilemap = new Dictionary<SuperMap, Tilemap>();
		_cachedSpawningTilemap = cachedSpawningTilemap;
		Dictionary<SuperMap, Tilemap> cachedFloorLayers = new Dictionary<SuperMap, Tilemap>();
		_cachedFloorLayers = cachedFloorLayers;
		List<Bounds> bounds = new List<Bounds>();
		_bounds = bounds;
		Dictionary<string, MoongateData> moongates = null;
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		_moongates = moongates;
		Dictionary<string, TeleporterData> teleporters = null;
		EqualityComparer<object> equalityComparer2 = EqualityComparer<object>.Default;
		if (equalityComparer2 != null)
		{
			_ = 0;
		}
		_teleporters = teleporters;
		_sizeX = 20.48f;
		_sizeY = 20.48f;
		_inverted = true;
		List<SuperObject> savedScripts = new List<SuperObject>();
		SavedScripts = savedScripts;
		List<PickupTeleporter> list = new List<PickupTeleporter>();
		_003CListOfTeleporters_003Ek__BackingField = list;
		base._onResumeSent = true;
	}
}
