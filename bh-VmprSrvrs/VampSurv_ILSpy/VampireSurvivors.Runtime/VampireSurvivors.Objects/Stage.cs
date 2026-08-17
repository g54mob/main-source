using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence.Log;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Lexone.UnityTwitchChat;
using Newtonsoft.Json.Linq;
using QFSW.MOP2;
using Rewired;
using SuperTiled2Unity;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects;

public class Stage : GameMonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<StageType, bool> _003C_003E9__240_0;

		public static Func<StageType, bool> _003C_003E9__241_0;

		public static Func<StageData, int> _003C_003E9__242_0;

		public static Func<Pickup, bool> _003C_003E9__255_0;

		public static Func<EnemyController, float> _003C_003E9__280_0;

		public static Predicate<PlayerInfo> _003C_003E9__344_0;

		public static Func<Pickup, bool> _003C_003E9__413_0;

		public static Func<Pickup, bool> _003C_003E9__414_0;

		public static Func<Tuple<SuperObject, SuperCustomProperties>, bool> _003C_003E9__414_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGetValidUnlockedHypers_003Eb__240_0(StageType type)
		{
			//IL_005b: Expected O, but got I4
			if (type <= StageType.TOWER)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,edx\"");
				if (type < StageType.TOWER)
				{
					return true;
				}
			}
			object obj = type - 13;
			return obj == null;
		}

		internal bool _003CGetValidUnlockedStages_003Eb__241_0(StageType type)
		{
			//IL_005b: Expected O, but got I4
			if (type <= StageType.TOWER)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,edx\"");
				if (type < StageType.TOWER)
				{
					return true;
				}
			}
			object obj = type - 13;
			return obj == null;
		}

		internal int _003CInitStage_003Eb__242_0(StageData s)
		{
			//IL_0035: Expected I4, but got O
			if (s != null)
			{
				return s._003Cminute_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal bool _003COnCycleComplete_003Eb__255_0(Pickup x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._003CPickupType_003Ek__BackingField - 29;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal float _003CGetClosestEnemiesSorted_003Eb__280_0(EnemyController x)
		{
			return x.Distance;
		}

		internal bool _003CGetRandomCharacter_003Eb__344_0(PlayerInfo player)
		{
			if ((object)player != null)
			{
				return ((UnityEngine.Object)player).m_CachedPtr == (IntPtr)0;
			}
			return true;
		}

		internal bool _003CForceRepositionMerchants_003Eb__413_0(Pickup pickup)
		{
			//IL_0049: Expected O, but got I4
			if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
			{
				object obj = pickup._003CPickupType_003Ek__BackingField - 80;
				return obj == null;
			}
			return false;
		}

		internal bool _003CPositionAllCustomMerchants_003Eb__414_0(Pickup pickup)
		{
			//IL_0049: Expected O, but got I4
			if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
			{
				object obj = pickup._003CPickupType_003Ek__BackingField - 29;
				return obj == null;
			}
			return false;
		}

		internal unsafe bool _003CPositionAllCustomMerchants_003Eb__414_1(Tuple<SuperObject, SuperCustomProperties> m)
		{
			//IL_0145: Expected I4, but got O
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected Ref, but got Unknown
			//IL_00fe: Expected I8, but got I4
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected Ref, but got Unknown
			if (m != null)
			{
				SuperObject item = m.m_Item1;
				if ((object)m.m_Item1 != null)
				{
					string type = item.m_Type;
					object obj = "TP_LIBRARIAN";
					if ((object)item.m_Type != "TP_LIBRARIAN")
					{
						if (item.m_Type != null && "TP_LIBRARIAN" != null)
						{
							int stringLength = type._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("TP_LIBRARIAN" + 20);
								ulong length = (ulong)(type._stringLength + type._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(item.m_Type + 20), ref second, length);
							}
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

	private sealed class _003C_003Ec__DisplayClass244_0
	{
		public Stage _003C_003E4__this;

		public Action onYoyo;

		internal void _003CDoTeleportVfx_003Eb__0()
		{
			//IL_0027: Expected O, but got I4
			Stage stage = _003C_003E4__this;
			PhaserSprite phaserSprite = stage._beam.setScale(0f, (float?)(object)0);
			Action action = onYoyo;
			if (onYoyo != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v49.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass248_0<TBiome> where TBiome : struct, Enum
	{
		public JToken jToken;

		public Func<JToken, bool> _003C_003E9__1;

		public Func<JToken, bool> _003C_003E9__2;

		internal bool _003CSetupStageDataByBiomeInternal_003Eb__0(JToken s)
		{
			//IL_00bb: Expected I4, but got O
			if (s != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
				bool flag = default(bool);
				if (!flag)
				{
					return flag;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
				if (jToken != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
					object obj2 = default(object);
					object obj = obj2 >> 32;
					object obj4 = default(object);
					object obj3 = obj4 - obj;
					bool flag2 = obj3 == null;
					object obj6 = default(object);
					object obj5 = obj6 - obj2;
					bool flag3 = obj5 == null;
					return flag3 & flag2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSetupStageDataByBiomeInternal_003Eb__1(JToken s)
		{
			//IL_00bb: Expected I4, but got O
			if (s != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
				bool flag = default(bool);
				if (!flag)
				{
					return flag;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
				if (jToken != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
					object obj2 = default(object);
					object obj = obj2 >> 32;
					object obj4 = default(object);
					object obj3 = obj4 - obj;
					bool flag2 = obj3 == null;
					object obj6 = default(object);
					object obj5 = obj6 - obj2;
					bool flag3 = obj5 == null;
					return flag3 & flag2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSetupStageDataByBiomeInternal_003Eb__2(JToken s)
		{
			//IL_00bb: Expected I4, but got O
			if (s != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
				bool flag = default(bool);
				if (!flag)
				{
					return flag;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
				if (jToken != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
					object obj2 = default(object);
					object obj = obj2 >> 32;
					object obj4 = default(object);
					object obj3 = obj4 - obj;
					bool flag2 = obj3 == null;
					object obj6 = default(object);
					object obj5 = obj6 - obj2;
					bool flag3 = obj5 == null;
					return flag3 & flag2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass305_0
	{
		public CharacterType merchantType;

		internal bool _003CSpawnCustomMerchants_003Eb__0(Pickup x)
		{
			//IL_0013: Expected I, but got O
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			//IL_0067: Expected O, but got I
			//IL_009d: Expected O, but got I4
			//IL_00cd: Expected O, but got I
			//IL_0131: Expected I4, but got O
			//IL_0109: Expected O, but got I
			if ((object)x == null)
			{
				goto IL_011d;
			}
			nint num = (nint)typeof(PickupCustomMerchant);
			nint num2 = (nint)x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11+FFFFFFF8+v45 @ rax_v4*8]");
				if (0 == (nint)typeof(PickupCustomMerchant))
				{
					obj3 = 1;
					goto IL_014e;
				}
			}
			obj3 = 0;
			goto IL_014e;
			IL_011d:
			return false;
			IL_014e:
			bool flag = obj3 == null;
			Pickup pickup = null;
			if (!flag)
			{
				pickup = x;
			}
			if ((object)pickup != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5 (VampireSurvivors.Objects.Pickups.Pickup)+190]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5 (VampireSurvivors.Objects.Pickups.Pickup)+190]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v6+10]");
					object obj5 = (nint)0 - (nint)merchantType;
					return obj5 == null;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_011d;
		}
	}

	private sealed class _003C_003Ec__DisplayClass308_0
	{
		public List<Tilemap> shadowLayers;

		public Stage _003C_003E4__this;

		internal void _003CToggleShadows_003Eb__0()
		{
			//IL_01cc: Expected O, but got I4
			//IL_01d5: Expected O, but got I4
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Expected O, but got Unknown
			//IL_0078->IL01a1: Incompatible stack heights: 1 vs 0
			//IL_00af->IL01a1: Incompatible stack heights: 1 vs 0
			//IL_02c8->IL01a1: Incompatible stack heights: 9 vs 0
			//IL_01a0->IL02cd: Incompatible stack heights: 9 vs 0
			List<Tilemap> list = shadowLayers;
			bool flag = shadowLayers == null;
			object obj = 0;
			object obj2 = 0;
			if (!flag)
			{
				Color value = default(Color);
				while (true)
				{
					if ((nint)obj2 < list._size)
					{
						List<Tilemap> list2 = shadowLayers;
						if (shadowLayers == null)
						{
							break;
						}
						bool flag2 = (nint)obj >= list2._size;
						Tilemap[] items = list2._items;
						if (list2._items == null)
						{
							break;
						}
						object obj3 = items[obj];
						if ((object)items[obj] == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v5 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v5 (System.Object)+10]");
						Tilemap.get_color_Injected((IntPtr)0, out Color _);
						List<Tilemap> list3 = shadowLayers;
						bool flag4 = shadowLayers == null;
						bool flag5 = (nint)obj >= list3._size;
						Tilemap[] items2 = list3._items;
						bool flag6 = list3._items == null;
						bool flag7 = (nint)obj >= items2.Length;
						object obj4 = items2[obj];
						Stage stage = _003C_003E4__this;
						bool flag8 = (object)_003C_003E4__this == null;
						if (!(stage._ShadowAlpha > stage._SoleShadowAlpha))
						{
						}
						bool flag9 = (object)items2[obj] == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6 (System.Object)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6 (System.Object)+10]");
						Tilemap.set_color_Injected((IntPtr)0, ref value);
						list = shadowLayers;
						obj++;
						if (shadowLayers == null)
						{
							break;
						}
						obj2 = obj;
						continue;
					}
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass336_0
	{
		public Vector2 position;

		internal int _003CSpawnChosenDestructiblesInClosestLocations_003Eb__0(Vector2 v1, Vector2 v2)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_01b3: Expected I4, but got I8
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Expected O, but got Unknown
			//IL_0190: Expected O, but got I4
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Expected I4, but got Unknown
			object obj = v1 - position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage+<>c__DisplayClass336_0)+14]");
			object obj3 = default(object);
			object obj2 = obj3 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage+<>c__DisplayClass336_0)+14]");
			object obj5 = default(object);
			object obj4 = obj5 - 0;
			object obj6 = obj * obj;
			object obj7 = obj2 * obj2;
			object obj8 = obj7 + obj6;
			object obj9 = v2 - position;
			object obj10 = obj4 * obj4;
			object obj11 = obj9 * obj9;
			object obj12 = obj10 + obj11;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E6BDF8h\"");
					if (obj8 == obj12)
					{
						return 0;
					}
					object obj13 = obj8 & -2147483649L;
					if ((nint)obj13 > 2139095040)
					{
						object obj14 = obj12 & -2147483649L;
						bool flag = (nint)obj14 < 2139095040;
						object obj15 = obj14 - 2139095040;
						bool flag2 = obj15 == null;
						bool flag3 = !flag;
						bool flag4 = !flag2;
						object obj16 = flag4 & flag3;
						return obj16 - 1;
					}
				}
				return 1;
			}
			return -1;
		}
	}

	private TilingBackground _TilingBackgroundPrefab;

	private TilingTileset _TilingTilesetPrefab;

	private Transform _LevelTransform;

	private static List<CharacterType> _validStageCharacters;

	private StageType _stageType;

	private int _currentMinute;

	private int _maxStageDataMinute;

	private int _maximum;

	private int _lastMinimum;

	private int _lastMaximum;

	private int _defaultMaximum;

	private float _minMultiplier;

	private float _onlineEnemyMultiplier;

	private float _effectiveSpawnFrequency;

	private JObject _stageJsonData;

	private StageData _stageData;

	private StageData _baseStageData;

	private Dictionary<int, JArray> _stageDataByBiome;

	private bool _hasTileSet;

	private SpawnType _spawnType;

	private bool _hasAttachedTreasure;

	private bool _compressTime;

	private float _pizzaDelay;

	private const float PizzaIntervalMillis = 20000f;

	private const int BulletAllowance = 50;

	private Timer _pauseTimer;

	private Timer _spawnTimer;

	private Timer _destructibleTimer;

	private Timer _checkPizzasTimer;

	private readonly List<Vector2> _enemySpawnLocations;

	private readonly List<Vector2> _destructibleLocations;

	private List<Vector2> _cartLocations;

	private List<Vector2> _windowLocations;

	private List<Vector2> _pizzaLocations;

	private readonly List<PizzaCircle> _pizzaCircles;

	private List<Vector2> _tiledPositions;

	private List<Rectangle> _noShadowLocations;

	private Timer _noShadowsTimer;

	private bool _shadowsVisible;

	private MultiTargetTween _shadowsTween;

	private Rect _spawnOuterRect;

	private Rect _spawnInnerRect;

	private Rect _containmentScreenRect;

	private Rect _containmentExactRect;

	private Rect _tiledOuterRect;

	private Rect _tiledInnerRect;

	private float _widthRect;

	private float _heightRect;

	private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> _spawnOuterRects;

	private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> _spawnInnerRects;

	private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> _playerRects;

	private readonly List<EnemyController> _spawnedEnemies;

	private readonly HashSet<EnemyController> _authoritativePermanentEnemies;

	private static Coherence.Log.Logger _logger;

	private bool _hasWallsCheckDestructibleLogic;

	private bool _isCharmApplied;

	private bool _disableMinueteSpawning;

	private Transform _cachedTransform;

	private Camera _mainCamera;

	private SignalBus _signalBus;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private StageEventManager _stageEventManager;

	private StageEventTrisectionManager _trisection;

	private GlimmerManager _glimmerManager;

	private StageEventTwitchManager _stageEventTwitchManager;

	private GameSessionData _gameSessionData;

	private DiContainer _diContainer;

	private TilingBackground _tilingBackground;

	private TilingTileset _tilingTileset;

	private EnemyFactory _enemyFactory;

	private DestructibleFactory _destructibleFactory;

	private ArcanaManager _arcanaManager;

	private BackgroundManager _fancyBg;

	private GameManager _gameManager;

	private LobbiesManager _lobbiesManager;

	private PhaserSprite _beam;

	private PhaserSprite _whiteFader;

	private List<EnemyType?> _enemyTypes;

	private List<EnemyType?> _bossTypes;

	private readonly Dictionary<EnemyType, bool> _enemyPoolStates;

	private readonly Dictionary<EnemyType, bool> _bossPoolStates;

	private List<Weapon> _003CStageHazardWeapons_003Ek__BackingField;

	public float _ShadowAlpha;

	public float _SoleShadowAlpha;

	private bool _003CHasInitialized_003Ek__BackingField;

	private float _003CEnemyHealthMultiplier_003Ek__BackingField;

	private float _003CEnemySpeedMultiplier_003Ek__BackingField;

	private int _003CMaxDestructibles_003Ek__BackingField;

	private float _003CPause_003Ek__BackingField;

	private bool _003CStopCheckingMinutes_003Ek__BackingField;

	private StageModifiers _003CStageMods_003Ek__BackingField;

	private float? _003CMinTreasureY_003Ek__BackingField;

	private float? _003CMaxTreasureY_003Ek__BackingField;

	private float? _003CMinTreasureX_003Ek__BackingField;

	private float? _003CMaxTreasureX_003Ek__BackingField;

	private bool _003CPoolsInitialized_003Ek__BackingField;

	private StageData _tmpStageData;

	private MultiTargetTween _teleportVfxTween;

	private static readonly ProfilerMarker MarkerSpawnEnemy;

	private static readonly ProfilerMarker MarkerFindClosestEnemy;

	private SortedList<uint, EnemyController> _queryEnemiesCache;

	private List<EnemyController> _unsortedEnemiesCache;

	private List<Pickup> _onScreenPickupsCache;

	private static readonly ProfilerMarker MarkerHandleSpawning;

	private static readonly ProfilerMarker MarkerSpawnEnemyUnit;

	private static readonly ProfilerMarker MarkerSpawnEnemyResolve;

	private static readonly ProfilerMarker MarkerUpdateCulling;

	private int _cullIterator;

	private List<EnemyController> _enemiesToCull;

	private static readonly ProfilerMarker MarkerDespawnEnemyIfOutsideRect;

	public PickupMerchant TrouserMerchant;

	public static List<CharacterType> ValidStageCharacters => _validStageCharacters;

	public float OnlineEnemyMultiplier
	{
		get
		{
			return _onlineEnemyMultiplier;
		}
		set
		{
			_onlineEnemyMultiplier = value;
		}
	}

	public bool DisableMinueteSpawning
	{
		get
		{
			return _disableMinueteSpawning;
		}
		set
		{
			_disableMinueteSpawning = value;
		}
	}

	public List<Weapon> StageHazardWeapons
	{
		get
		{
			return _003CStageHazardWeapons_003Ek__BackingField;
		}
		set
		{
			_003CStageHazardWeapons_003Ek__BackingField = value;
		}
	}

	public DestructibleFactory DestructibleFactory => _destructibleFactory;

	public StageEventTrisectionManager Trisection => _trisection;

	public GlimmerManager GlimmerManager => _glimmerManager;

	public unsafe Rect ContainmentExactRect
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = (float)_containmentExactRect;
			return rect;
		}
	}

	public bool HasInitialized
	{
		get
		{
			return _003CHasInitialized_003Ek__BackingField;
		}
		private set
		{
			_003CHasInitialized_003Ek__BackingField = value;
		}
	}

	public List<EnemyController> SpawnedEnemies => _spawnedEnemies;

	public int EnemiesCount
	{
		get
		{
			//IL_001d: Expected I4, but got O
			List<EnemyController> spawnedEnemies = _spawnedEnemies;
			if (_spawnedEnemies != null)
			{
				return spawnedEnemies._size;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public SpawnType SpawnType
	{
		get
		{
			return _spawnType;
		}
		set
		{
			_spawnType = value;
		}
	}

	public int PermanentEnemiesNumber
	{
		get
		{
			//IL_00f1: Expected I4, but got O
			if ((object)GM.Core != null)
			{
				bool isStageHost = GM.Core.IsStageHost;
				List<EnemyController> spawnedEnemies = _spawnedEnemies;
				if (isStageHost)
				{
					if (_spawnedEnemies != null)
					{
						StageEventManager stageEventManager = _stageEventManager;
						if (_stageEventManager != null)
						{
							return spawnedEnemies._size - stageEventManager._003CSpawned_003Ek__BackingField;
						}
					}
				}
				else if (_spawnedEnemies != null && (object)OnlineStageManager._instance != null)
				{
					int stageEventSpawned = OnlineStageManager._instance.StageEventSpawned;
					return spawnedEnemies._size - stageEventSpawned;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public StageData ActiveStageData => _stageData;

	public unsafe Rect SpawnOuterRect
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = (float)_spawnOuterRect;
			return rect;
		}
	}

	public unsafe Rect SpawnInnerRect
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = (float)_spawnInnerRect;
			return rect;
		}
	}

	public unsafe Rect ContainmentScreenRect
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = (float)_containmentScreenRect;
			return rect;
		}
	}

	public List<Vector2> EnemySpawnLocations => _enemySpawnLocations;

	public bool HasTileSet => _hasTileSet;

	public StageEventManager StageEventManager => _stageEventManager;

	public StageEventTwitchManager StageEventTwitchManager => _stageEventTwitchManager;

	public GameSessionData GameSessionData => _gameSessionData;

	public TilingTileset TilingTileset => _tilingTileset;

	public TilingBackground TilingBackground => _tilingBackground;

	public float EnemyHealthMultiplier
	{
		get
		{
			return _003CEnemyHealthMultiplier_003Ek__BackingField;
		}
		set
		{
			_003CEnemyHealthMultiplier_003Ek__BackingField = value;
		}
	}

	public float EnemySpeedMultiplier
	{
		get
		{
			return _003CEnemySpeedMultiplier_003Ek__BackingField;
		}
		set
		{
			_003CEnemySpeedMultiplier_003Ek__BackingField = value;
		}
	}

	public List<ItemType> LootTable
	{
		get
		{
			StageData stageData = _stageData;
			if (_stageData != null)
			{
				return stageData._003CLootTable_003Ek__BackingField;
			}
			return (List<ItemType>)(object)new NullReferenceException();
		}
	}

	public BackgroundManager FancyBg => _fancyBg;

	public LobbiesManager LobbiesManager => _lobbiesManager;

	public List<Vector2> DestructibleLocations => _destructibleLocations;

	public int MaxDestructibles
	{
		get
		{
			return _003CMaxDestructibles_003Ek__BackingField;
		}
		set
		{
			_003CMaxDestructibles_003Ek__BackingField = value;
		}
	}

	public float Pause
	{
		get
		{
			return _003CPause_003Ek__BackingField;
		}
		set
		{
			_003CPause_003Ek__BackingField = value;
		}
	}

	public bool HasLights
	{
		get
		{
			//IL_0041: Expected I4, but got O
			StageData stageData = _stageData;
			if (_stageData != null)
			{
				return stageData._003ChasLights_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasCharacterSpotlight
	{
		get
		{
			//IL_0041: Expected I4, but got O
			StageData baseStageData = _baseStageData;
			if (_baseStageData != null)
			{
				return baseStageData._003ChasCharacterSpotlight_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool StopCheckingMinutes
	{
		get
		{
			return _003CStopCheckingMinutes_003Ek__BackingField;
		}
		set
		{
			_003CStopCheckingMinutes_003Ek__BackingField = value;
		}
	}

	public List<PizzaCircle> PizzaCircles => _pizzaCircles;

	public StageType StageType => _stageType;

	public PropType DestructibleType
	{
		get
		{
			StageData stageData = _stageData;
			if (_stageData != null)
			{
				string text = stageData._003CdestructibleType_003Ek__BackingField;
				if (stageData._003CdestructibleType_003Ek__BackingField != null && text._stringLength > 0)
				{
					StageData stageData2 = _stageData;
					return Enum.Parse<PropType>(stageData2._003CdestructibleType_003Ek__BackingField);
				}
			}
			return PropType.BRAZIER;
		}
	}

	public StageModifiers StageMods
	{
		get
		{
			return _003CStageMods_003Ek__BackingField;
		}
		set
		{
			_003CStageMods_003Ek__BackingField = value;
		}
	}

	public List<EnemyType?> BossTypes => _bossTypes;

	public List<EnemyType?> EnemyTypes
	{
		get
		{
			return _enemyTypes;
		}
		set
		{
			_enemyTypes = value;
		}
	}

	public int Maximum
	{
		get
		{
			return _maximum;
		}
		set
		{
			_maximum = value;
		}
	}

	public int LastMinimum
	{
		get
		{
			return _lastMinimum;
		}
		set
		{
			_lastMinimum = value;
		}
	}

	public int LastMaximum
	{
		get
		{
			return _lastMaximum;
		}
		set
		{
			_lastMaximum = value;
		}
	}

	public float? MinTreasureY
	{
		get
		{
			return _003CMinTreasureY_003Ek__BackingField;
		}
		set
		{
			_003CMinTreasureY_003Ek__BackingField = value;
		}
	}

	public float? MaxTreasureY
	{
		get
		{
			return _003CMaxTreasureY_003Ek__BackingField;
		}
		set
		{
			_003CMaxTreasureY_003Ek__BackingField = value;
		}
	}

	public float? MinTreasureX
	{
		get
		{
			return _003CMinTreasureX_003Ek__BackingField;
		}
		set
		{
			_003CMinTreasureX_003Ek__BackingField = value;
		}
	}

	public float? MaxTreasureX
	{
		get
		{
			return _003CMaxTreasureX_003Ek__BackingField;
		}
		set
		{
			_003CMaxTreasureX_003Ek__BackingField = value;
		}
	}

	public unsafe Rect EnemiesDespawnRect
	{
		get
		{
			//IL_01a9: Expected F4, but got I4
			//IL_0013: Expected O, but got I4
			//IL_001b: Expected O, but got Ref
			//IL_01dc: Expected native int or pointer, but got O
			Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> playerRects = _playerRects;
			Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>.Enumerator enumerator = default(Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>.Enumerator enumerator2 = (Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			float xMin = 0f;
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = xMin;
			return rect;
		}
	}

	public EnemyFactory EnemyFactory => _enemyFactory;

	public bool PoolsInitialized
	{
		get
		{
			return _003CPoolsInitialized_003Ek__BackingField;
		}
		private set
		{
			_003CPoolsInitialized_003Ek__BackingField = value;
		}
	}

	private float Frequency
	{
		get
		{
			StageData stageData = _stageData;
			return stageData._003Cfrequency_003Ek__BackingField;
		}
	}

	private float DestructibleFrequency
	{
		get
		{
			StageData stageData = _stageData;
			return stageData._003CdestructibleFreq_003Ek__BackingField;
		}
	}

	private bool IsMerchantBanned
	{
		get
		{
			//IL_0041: Expected I4, but got O
			StageData stageData = _stageData;
			if (_stageData != null)
			{
				return stageData._003CisMerchantBanned_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public int CurrentMinute => _currentMinute;

	private int StartingSpawns
	{
		get
		{
			//IL_0041: Expected I4, but got O
			StageData stageData = _stageData;
			if (_stageData != null)
			{
				return stageData._003CstartingSpawns_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private void Construct(DataManager dataManager, PlayerOptions playerOptions, SignalBus signalBus, GameSessionData gameSessionData, DiContainer diContainer, EnemyFactory enemyFactory, DestructibleFactory destructibleFactory, ArcanaManager arcanaManager, GameManager gameManager, LobbiesManager lobbiesManager)
	{
		//IL_009c: Expected O, but got I
		_dataManager = dataManager;
		_playerOptions = playerOptions;
		_signalBus = signalBus;
		_gameSessionData = (GameSessionData)(object)gameManager;
		_diContainer = (DiContainer)(object)lobbiesManager;
		IntPtr intPtr = default(IntPtr);
		_enemyFactory = (EnemyFactory)(nint)intPtr;
		DestructibleFactory destructibleFactory2 = default(DestructibleFactory);
		_destructibleFactory = destructibleFactory2;
		ArcanaManager arcanaManager2 = default(ArcanaManager);
		_arcanaManager = arcanaManager2;
		GameManager gameManager2 = default(GameManager);
		_gameManager = gameManager2;
		LobbiesManager lobbiesManager2 = default(LobbiesManager);
		_lobbiesManager = lobbiesManager2;
		Action<GameplaySignals.RemoveEnemyFromStageSignal> action = null;
		((Stage)(object)action).OnEnemyKilled((GameplaySignals.RemoveEnemyFromStageSignal)this);
		((Stage)(object)_signalBus).OnEnemyKilled((GameplaySignals.RemoveEnemyFromStageSignal)action);
	}

	private void Awake()
	{
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		Camera main = Camera.main;
		_mainCamera = main;
	}

	private void Start()
	{
		SpeedupManager instance = SpeedupManager.Instance;
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(0);
			instance.m_Player = player;
			if (instance.m_Player != null)
			{
				instance.SetSpeedup(1f);
				if (instance.m_Player != null)
				{
					Action<InputActionEventData> action = null;
					((SpeedupManager)(object)action).ToggleSpeedup((InputActionEventData)instance);
					int actionId = default(int);
					object[] arguments = default(object[]);
					instance.m_Player.AddInputEventDelegate(action, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, actionId, arguments);
				}
			}
		}
		InitRects();
	}

	protected override void OnUpdate()
	{
		UpdateRectPositions();
		UpdateCulling();
		TilingTileset tilingTileset = _tilingTileset;
		if ((object)_tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
		{
			_tilingTileset.InternalUpdate();
		}
		float deltaTime = PauseSystem.DeltaTime;
		float pizzaDelay = _pizzaDelay - deltaTime;
		_pizzaDelay = pizzaDelay;
		if (_stageEventManager != null)
		{
			_stageEventManager.InternalUpdate();
		}
		if (_trisection != null)
		{
			_trisection.TrisectionUpdate();
		}
	}

	protected override void OnDestroy()
	{
		Action<GameplaySignals.RemoveEnemyFromStageSignal> action = null;
		((Stage)(object)action).OnEnemyKilled((GameplaySignals.RemoveEnemyFromStageSignal)this);
		((Stage)(object)_signalBus).OnEnemyKilled((GameplaySignals.RemoveEnemyFromStageSignal)action);
		SpeedupManager.ClearSpeedupManager();
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_05eb: Expected O, but got I4
		//IL_0093: Expected O, but got I
		//IL_09ca: Expected I, but got O
		//IL_01a5: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_02bd: Expected O, but got I
		//IL_0227: Expected O, but got I
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_03cf: Expected O, but got I
		//IL_0339: Expected O, but got I
		//IL_071f: Expected F4, but got I
		//IL_0557: Expected O, but got I
		//IL_04e1: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_07a9: Expected F4, but got I
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Expected O, but got Unknown
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_0833: Expected F4, but got I
		//IL_093c: Expected F4, but got I
		//IL_08bd: Expected F4, but got I
		//IL_09d0->IL0685: Incompatible stack heights: 3 vs 2
		//IL_08fe->IL05dc: Incompatible stack heights: 2 vs 0
		//IL_01b9->IL0746: Incompatible stack heights: 6 vs 2
		//IL_02cb->IL07d0: Incompatible stack heights: 6 vs 2
		//IL_03dd->IL085a: Incompatible stack heights: 6 vs 2
		//IL_072d->IL09e8: Incompatible stack heights: 6 vs 3
		//IL_05dc->IL05dc: Incompatible stack heights: 6 vs 0
		//IL_04ef->IL08e4: Incompatible stack heights: 6 vs 2
		//IL_07b7->IL0a01: Incompatible stack heights: 6 vs 3
		//IL_0841->IL0a1a: Incompatible stack heights: 6 vs 3
		//IL_0949->IL0a4c: Incompatible stack heights: 6 vs 3
		//IL_08cb->IL0a33: Incompatible stack heights: 6 vs 3
		object obj = Application.isPlaying;
		if (obj == null)
		{
			return;
		}
		GameSessionData gameSessionData = _gameSessionData;
		Transform transform = gameSessionData._activeCharacter.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		float value = default(float);
		Gizmos.set_color_Injected(ref *(Color*)(&value));
		Vector3 center = default(Vector3);
		Gizmos.DrawWireCube_Injected(ref center, ref ret);
		Gizmos.set_color_Injected(ref *(Color*)(&value));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+11C]");
		float num = 0f * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+114]");
		float num2 = 0f + num;
		Gizmos.DrawWireCube_Injected(ref ret, ref center);
		bool flag2 = _playerRects == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3AD0");
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>.Enumerator enumerator = default(Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>.Enumerator);
		float num3 = default(float);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rax_v93+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rax_v93+10]");
			Color coopColour = ((VampireSurvivors.Objects.Characters.CharacterController)0).GetCoopColour();
			Gizmos.set_color_Injected(ref *(Color*)(&value));
			Gizmos.DrawWireCube_Injected(ref ret, ref center);
			num2 = num3;
			nint num4 = unchecked((nint)null);
		}
		Color value2 = default(Color);
		Gizmos.set_color_Injected(ref value2);
		Gizmos.DrawWireCube_Injected(ref ret, ref center);
		object obj3 = default(object);
		object obj5 = default(object);
		if (_enemySpawnLocations != null)
		{
			Color value3 = default(Color);
			Gizmos.set_color_Injected(ref value3);
			List<Vector2> enemySpawnLocations = _enemySpawnLocations;
			bool flag4 = _enemySpawnLocations == null;
			object obj2 = default(object);
			Vector3 center2 = default(Vector3);
			while (true)
			{
				bool flag5 = obj2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1777 @ stack_-1B8_v33+1C]");
				if (obj3 == null)
				{
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1777 @ stack_-1B8_v33+18]");
					if ((nint)obj4 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1777 @ stack_-1B8_v33+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1777 @ stack_-1B8_v33+10]");
						bool flag6 = (nint)0 == 0;
						object obj7 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2373 @ rdx_v91+18]");
						bool flag7 = (nint)obj7 >= 0;
						object obj8 = obj5 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1777 @ stack_-1B8_v33+10]");
						Gizmos.DrawWireSphere_Injected(ref center2, 0f);
						obj5 = obj8;
						continue;
					}
					break;
				}
				break;
			}
			bool flag8 = obj2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1777 @ stack_-1B8_v33+1C]");
			bool flag9 = obj3 != null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1777 @ stack_-1B8_v33+18]");
			object obj9 = (nint)0 + (nint)1;
			obj5 = obj9;
			nint num4 = 0;
		}
		if (_windowLocations != null)
		{
			Color value4 = default(Color);
			Gizmos.set_color_Injected(ref value4);
			List<Vector2> enemySpawnLocations = _windowLocations;
			bool flag10 = _windowLocations == null;
			object obj10 = default(object);
			Vector3 center3 = default(Vector3);
			while (true)
			{
				bool flag11 = obj10 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ stack_-1B8_v31+1C]");
				if (obj3 == null)
				{
					object obj11 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ stack_-1B8_v31+18]");
					if ((nint)obj11 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ stack_-1B8_v31+10]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ stack_-1B8_v31+10]");
						bool flag12 = (nint)0 == 0;
						object obj13 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2184 @ rdx_v83+18]");
						bool flag13 = (nint)obj13 >= 0;
						object obj14 = obj5 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ stack_-1B8_v31+10]");
						Gizmos.DrawWireSphere_Injected(ref center3, 0f);
						obj5 = obj14;
						continue;
					}
					break;
				}
				break;
			}
			bool flag14 = obj10 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ stack_-1B8_v31+1C]");
			bool flag15 = obj3 != null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ stack_-1B8_v31+18]");
			object obj15 = (nint)0 + (nint)1;
			obj5 = obj15;
		}
		if (_cartLocations != null)
		{
			Color value5 = default(Color);
			Gizmos.set_color_Injected(ref value5);
			List<Vector2> enemySpawnLocations = _cartLocations;
			bool flag16 = _cartLocations == null;
			object obj16 = default(object);
			while (true)
			{
				bool flag17 = obj16 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ stack_-1B8_v29+1C]");
				if (obj3 == null)
				{
					object obj17 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ stack_-1B8_v29+18]");
					if ((nint)obj17 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ stack_-1B8_v29+10]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ stack_-1B8_v29+10]");
						bool flag18 = (nint)0 == 0;
						object obj19 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3004 @ rdx_v75+18]");
						bool flag19 = (nint)obj19 >= 0;
						object obj20 = obj5 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ stack_-1B8_v29+10]");
						Gizmos.DrawWireSphere_Injected(ref *(Vector3*)(&value2), 0f);
						obj5 = obj20;
						continue;
					}
					break;
				}
				break;
			}
			bool flag20 = obj16 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ stack_-1B8_v29+1C]");
			bool flag21 = obj3 != null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2280 @ stack_-1B8_v29+18]");
			object obj21 = (nint)0 + (nint)1;
			obj5 = obj21;
		}
		if (_pizzaLocations != null)
		{
			Color value6 = default(Color);
			Gizmos.set_color_Injected(ref value6);
			List<Vector2> enemySpawnLocations = _pizzaLocations;
			bool flag22 = _pizzaLocations == null;
			object obj22 = default(object);
			Vector3 center4 = default(Vector3);
			while (true)
			{
				bool flag23 = obj22 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2682 @ stack_-1B8_v27+1C]");
				if (obj3 == null)
				{
					object obj23 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2682 @ stack_-1B8_v27+18]");
					if ((nint)obj23 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2682 @ stack_-1B8_v27+10]");
						object obj24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2682 @ stack_-1B8_v27+10]");
						bool flag24 = (nint)0 == 0;
						object obj25 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3684 @ rdx_v67+18]");
						bool flag25 = (nint)obj25 >= 0;
						object obj26 = obj5 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2682 @ stack_-1B8_v27+10]");
						Gizmos.DrawWireSphere_Injected(ref center4, 0f);
						obj5 = obj26;
						continue;
					}
					break;
				}
				break;
			}
			bool flag26 = obj22 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2682 @ stack_-1B8_v27+1C]");
			bool flag27 = obj3 != null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2682 @ stack_-1B8_v27+18]");
			object obj27 = (nint)0 + (nint)1;
			obj5 = obj27;
		}
		if (_tiledPositions == null)
		{
			return;
		}
		Color value7 = default(Color);
		Gizmos.set_color_Injected(ref value7);
		bool flag28 = _tiledPositions == null;
		object obj28 = default(object);
		while (true)
		{
			bool flag29 = obj28 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-1B8_v25+1C]");
			if (obj3 == null)
			{
				object obj29 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-1B8_v25+18]");
				if ((nint)obj29 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-1B8_v25+10]");
					object obj30 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-1B8_v25+10]");
					bool flag30 = (nint)0 == 0;
					object obj31 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4351 @ rdx_v59+18]");
					bool flag31 = (nint)obj31 >= 0;
					object obj32 = obj5 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-1B8_v25+10]");
					Gizmos.DrawWireSphere_Injected(ref *(Vector3*)(&value2), 0f);
					obj5 = obj32;
					continue;
				}
				break;
			}
			break;
		}
		bool flag32 = obj28 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-1B8_v25+1C]");
		bool flag33 = obj3 != null;
	}

	public static List<CharacterType> GetValidStageXCharacters()
	{
		return _validStageCharacters;
	}

	public static bool HasValidStageXCharacters()
	{
		//IL_0070: Expected I, but got O
		//IL_00d3: Expected O, but got I
		//IL_015c: Expected I, but got O
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			List<CharacterType> characterSelections = OnlineStageManager._instance.GetCharacterSelections();
		}
		else
		{
			List<CharacterType> characterSelections = MultiplayerManager.s_instance.GetCharacterSelections();
		}
		nint num = unchecked((nint)null);
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-28_v8+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-28_v8+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-28_v8+10]");
						object obj5 = 0;
						obj4++;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						if (obj6 == null)
						{
							return false;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		num = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ stack_-28_v8+1C]");
			if (obj2 == null)
			{
				return true;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	public static bool HasAllNonVoidCharacters()
	{
		//IL_0088: Expected O, but got I
		//IL_010e: Expected O, but got I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		List<CharacterType> characterSelections = MultiplayerManager.s_instance.GetCharacterSelections();
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v7+1C]");
				if (obj4 == null)
				{
					object obj5 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v7+18]");
					if ((nint)obj5 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v7+10]");
						object obj6 = 0;
						obj++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v30+20+v126 @ rdx_v10*4]");
						if ((nint)0 == 0)
						{
							return false;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v7+1C]");
			if (obj4 == null)
			{
				return true;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			object obj7 = 0;
		}
		throw new NullReferenceException();
	}

	public static List<CharacterType> GetValidAnyStageCharacters()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_02af: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_02e5: Expected O, but got I
		//IL_01aa: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_023e: Expected O, but got I
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v4+18]");
			if (num2 >= 0)
			{
				goto IL_02b4;
			}
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v6+18]");
			if (num4 >= 0)
			{
				goto IL_02b4;
			}
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v8+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v8+18]");
			if (num6 >= 0)
			{
				goto IL_02b4;
			}
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v10+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
			return list;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		object obj8 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v10+18]");
		if (num8 < 0)
		{
			_ = 4;
			return list;
		}
		goto IL_02b4;
		IL_02b4:
		return (List<CharacterType>)(object)new IndexOutOfRangeException();
	}

	public static List<StageType> GetValidUnlockedHypers()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Func<StageType, bool> predicate = _003C_003Ec._003C_003E9__240_0;
		if (_003C_003Ec._003C_003E9__240_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__240_0 = delegate(StageType type)
			{
				//IL_005b: Expected O, but got I4
				if (type <= StageType.TOWER)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,edx\"");
					if (type < StageType.TOWER)
					{
						return true;
					}
				}
				object obj = type - 13;
				return obj == null;
			});
		}
		IEnumerable<StageType> enumerable = Enumerable.Where(config._003CUnlockedHypers_003Ek__BackingField, predicate);
		if (enumerable != null)
		{
			return (List<StageType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public static List<StageType> GetValidUnlockedStages()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Func<StageType, bool> predicate = _003C_003Ec._003C_003E9__241_0;
		if (_003C_003Ec._003C_003E9__241_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__241_0 = delegate(StageType type)
			{
				//IL_005b: Expected O, but got I4
				if (type <= StageType.TOWER)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,edx\"");
					if (type < StageType.TOWER)
					{
						return true;
					}
				}
				object obj = type - 13;
				return obj == null;
			});
		}
		IEnumerable<StageType> enumerable = Enumerable.Where(config._003CUnlockedStages_003Ek__BackingField, predicate);
		if (enumerable != null)
		{
			return (List<StageType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public unsafe void InitStage(StageType stageType)
	{
		//IL_0cb5: Expected O, but got I4
		//IL_0cc3: Expected O, but got I4
		//IL_0cd1: Expected O, but got I4
		//IL_0cdf: Expected O, but got I4
		//IL_0ced: Expected O, but got I4
		//IL_0cfb: Expected O, but got I4
		//IL_0d09: Expected O, but got I4
		//IL_0d17: Expected O, but got I4
		//IL_0d25: Expected O, but got I4
		//IL_0d33: Expected O, but got I4
		//IL_0d41: Expected O, but got I4
		//IL_0d5d: Expected O, but got I4
		//IL_0d6b: Expected O, but got I4
		//IL_0d79: Expected O, but got I4
		//IL_006f: Expected I, but got O
		//IL_0e01: Expected O, but got I4
		//IL_0e41: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		//IL_02ec: Expected O, but got I
		//IL_01e6: Expected O, but got I4
		//IL_03af: Expected O, but got I4
		//IL_03a0: Expected I4, but got O
		//IL_0447: Expected O, but got I
		//IL_0484: Expected O, but got I
		//IL_050b: Expected O, but got I4
		//IL_0530: Expected O, but got I
		//IL_0539: Expected O, but got I4
		//IL_066f: Expected F4, but got I4
		//IL_05b0: Expected O, but got I
		//IL_05b9: Expected O, but got I4
		//IL_0630: Expected O, but got I
		//IL_0639: Expected O, but got I4
		//IL_06ce: Expected F4, but got I4
		//IL_0ee2: Expected O, but got I4
		//IL_0f03: Expected O, but got I4
		//IL_0f7a: Expected O, but got I4
		//IL_093c: Expected O, but got I4
		//IL_0944: Expected O, but got Ref
		StageModifiers stageModifiers = new StageModifiers();
		stageModifiers._003CBGM_rate_003Ek__BackingField = 1f;
		stageModifiers._003CBGM_new_rate_003Ek__BackingField = 1f;
		_003CStageMods_003Ek__BackingField = stageModifiers;
		StageModifiers stageModifiers2 = _003CStageMods_003Ek__BackingField;
		stageModifiers2._003CTimeLimit_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CClockSpeed_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CPlayerPxSpeed_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CEnemySpeed_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CProjectileSpeed_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CGoldMultiplier_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CEnemyHealthMultiplier_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CXpBonus_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CStartingSpawns_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CLuckBonus_003Ek__BackingField = (float?)(object)1;
		stageModifiers2._003CEndCycles_003Ek__BackingField = (float?)(object)1;
		TimeMods timeMods = new TimeMods();
		timeMods.Start = (float?)(object)1;
		timeMods.HpPerMinute = (float?)(object)1;
		timeMods.SpeedPerMinute = (float?)(object)1;
		stageModifiers2._003CTimeMods_003Ek__BackingField = timeMods;
		StageEventManager stageEventManager = _diContainer.Instantiate<StageEventManager>();
		_stageEventManager = stageEventManager;
		_stageEventManager.Initialize();
		StageEventManager stageEventManager2 = _stageEventManager;
		nint num = (nint)stageEventManager2;
		stageEventManager2.Init(this);
		StageEventTrisectionManager stageEventTrisectionManager;
		Stage stage;
		if (!TwitchIntegration._sInstance.IsTwitchOn())
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (!config._003CSelectedRandomEvents_003Ek__BackingField)
			{
				goto IL_0d8b;
			}
			GameManager core2 = GM.Core;
			StageEventTrisectionManager trisection = core2._diContainer.Instantiate<StageEventTrisectionManager>();
			_trisection = trisection;
			_trisection.Initialize();
			stageEventTrisectionManager = _trisection;
			GameManager core3 = GM.Core;
			stage = core3._stage;
		}
		else
		{
			TwitchIntegration sInstance = TwitchIntegration._sInstance;
			IRC twitchClient = TwitchIntegration._sInstance.TwitchClient;
			bool flag = (object)twitchClient == null;
			object obj = 0;
			IRC typeFromHandle = (IRC)(object)typeof(UnityEngine.Object);
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)twitchClient).m_CachedPtr == (IntPtr)0;
				obj = 0;
				typeFromHandle = (IRC)(object)typeof(UnityEngine.Object);
				if (!flag2)
				{
					IRC twitchClient2 = TwitchIntegration._sInstance.TwitchClient;
					twitchClient2.channel = sInstance._username;
					IRC twitchClient3 = TwitchIntegration._sInstance.TwitchClient;
					twitchClient3.Connect();
					obj = 0;
					typeFromHandle = twitchClient3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C02590");
			TwitchIntegration twitchIntegration = default(TwitchIntegration);
			if (!twitchIntegration.IsTwitchWorking())
			{
				Debug.LogWarning("Could not init Twitch, show a warning popup? JS doesnt...");
				goto IL_0d8b;
			}
			GameManager core4 = GM.Core;
			StageEventTwitchManager stageEventTwitchManager = core4._diContainer.Instantiate<StageEventTwitchManager>();
			_stageEventTwitchManager = stageEventTwitchManager;
			_stageEventTwitchManager.Initialize();
			stageEventTrisectionManager = (StageEventTrisectionManager)(object)_stageEventTwitchManager;
			stage = this;
		}
		stageEventTrisectionManager.Init(stage);
		goto IL_0d8b;
		IL_0d8b:
		UpdateRectPositions();
		InitTiledPositions();
		StageType stageType2 = default(StageType);
		_stageType = stageType2;
		_currentMinute = 0;
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		object source = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)stageType2);
		Func<StageData, int> selector = _003C_003Ec._003C_003E9__242_0;
		bool flag3 = _003C_003Ec._003C_003E9__242_0 != null;
		object s = stageType2;
		if (!flag3)
		{
			selector = (_003C_003Ec._003C_003E9__242_0 = delegate(StageData stageData3)
			{
				//IL_0035: Expected I4, but got O
				if (stageData3 == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				return stageData3._003Cminute_003Ek__BackingField;
			});
			s = _003C_003Ec._003C_003E9;
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2140 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			int num3 = ((_003C_003Ec)0)._003CInitStage_003Eb__242_0((StageData)s);
		}
		IEnumerable<int> source2 = Enumerable.Select((IEnumerable<StageData>)source, selector);
		int maxStageDataMinute = Enumerable.Max(source2);
		_maxStageDataMinute = maxStageDataMinute;
		if (stageType2 == StageType.TP_CASTLE || stageType2 == StageType.EMERALD)
		{
			SetupStageDataByBiomeInternal<TBiome>(StageType.TP_CASTLE);
		}
		int num4 = 0;
		if (GetStageDataForMinute(_currentMinute, _stageType, out var stageJsonObject))
		{
			object obj2 = stageJsonObject.ToObject<object>();
			num4 = (int)obj2;
		}
		_baseStageData = (StageData)num4;
		_enemyFactory.InitPools(this, _dataManager);
		_003CPoolsInitialized_003Ek__BackingField = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+B0]");
		bool flag4 = (nint)0 < (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+B0]");
		bool flag5 = (nint)0 == 0;
		bool flag6 = !flag4;
		bool flag7 = !flag5;
		bool hasTileSet = flag7 & flag6;
		_hasTileSet = hasTileSet;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+C8]");
		SpawnType spawnType = Enum.Parse<SpawnType>((string)0);
		_spawnType = spawnType;
		if (_hasTileSet)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+B0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1134 @ rax_v216+32]");
			_hasWallsCheckDestructibleLogic = false;
		}
		UpdateAllData(stageJsonObject);
		StageData stageData = _stageData;
		_003CMaxDestructibles_003Ek__BackingField = stageData._003CmaxDestructibles_003Ek__BackingField;
		StageData stageData2 = _stageData;
		if (stageData2._003CrandomMinutes_003Ek__BackingField)
		{
			UpdateMinuteData();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+98]");
		bool flag8 = (nint)0 == 0;
		object obj4 = 0;
		if (!flag8)
		{
			StageModifiers stageModifiers3 = _003CStageMods_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+98]");
			stageModifiers3.Set((StageModifiers)0);
			obj4 = 0;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		if (config2._003CSelectedHyper_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+A0]");
			if ((nint)0 != 0)
			{
				StageModifiers stageModifiers4 = _003CStageMods_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+A0]");
				stageModifiers4.Add((StageModifiers)0);
				obj4 = 0;
			}
		}
		PlayerOptionsData config3 = _playerOptions.Config;
		if (config3._003CSelectedInverse_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+A8]");
			if ((nint)0 != 0)
			{
				StageModifiers stageModifiers5 = _003CStageMods_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+A8]");
				stageModifiers5.Add((StageModifiers)0);
				obj4 = 0;
			}
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		bool flag9 = !config4._003CSelectedHurry_003Ek__BackingField;
		float num5 = 0f;
		if (!flag9)
		{
			StageModifiers stageModifiers6 = _003CStageMods_003Ek__BackingField;
			int num6;
			if ((object)stageModifiers6._003CXpBonus_003Ek__BackingField != null)
			{
				num5 = 0.25f;
				num6 = 1;
			}
			else
			{
				num5 = 0f;
				num6 = 0;
			}
			stageModifiers6._003CXpBonus_003Ek__BackingField = (float?)(object)num6;
		}
		int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
		if (playerCount > 1 || MultiplayerManager.s_instance.IsOnlineMultiplayer)
		{
			PlayerOptionsData config5 = _playerOptions.Config;
			if (!config5._003CSelectedSharePassives_003Ek__BackingField)
			{
				StageModifiers stageModifiers7 = _003CStageMods_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
				int num7 = (((object)stageModifiers7._003CGoldMultiplier_003Ek__BackingField != null) ? 1 : 0);
				stageModifiers7._003CGoldMultiplier_003Ek__BackingField = (float?)(object)num7;
			}
		}
		StageModifiers stageModifiers8 = _003CStageMods_003Ek__BackingField;
		if ((object)stageModifiers8._003CPlayerPxSpeed_003Ek__BackingField != null)
		{
			float playerPxSpeed = 0f * 0.82500005f;
			GameManager.PlayerPxSpeed = playerPxSpeed;
			StageModifiers stageModifiers9 = _003CStageMods_003Ek__BackingField;
			if ((object)stageModifiers9._003CEnemySpeed_003Ek__BackingField != null)
			{
				float enemySpeed = 0f * 0.231f;
				GameManager.EnemySpeed = enemySpeed;
				StageModifiers stageModifiers10 = _003CStageMods_003Ek__BackingField;
				if ((object)stageModifiers10._003CProjectileSpeed_003Ek__BackingField != null)
				{
					float projectileSpeed = 0f * 1.6500001f;
					GameManager.ProjectileSpeed = projectileSpeed;
					StageModifiers stageModifiers11 = _003CStageMods_003Ek__BackingField;
					if ((object)stageModifiers11._003CGoldMultiplier_003Ek__BackingField != null)
					{
						GameManager.GoldMultiplier = 0f;
						StageModifiers stageModifiers12 = _003CStageMods_003Ek__BackingField;
						if ((object)stageModifiers12._003CEnemyHealthMultiplier_003Ek__BackingField != null)
						{
							GameManager.EnemyHealthMultiplier = 0f;
							StageModifiers stageModifiers13 = _003CStageMods_003Ek__BackingField;
							if ((object)stageModifiers13._003CXpBonus_003Ek__BackingField != null)
							{
								GameManager.ExperienceMultiplier = 0f;
								List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
								if (enumerator.MoveNext())
								{
									object obj5 = 0;
									List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
									throw new NullReferenceException();
								}
								CalculateEnemySpeed();
								_tmpStageData = (StageData)num4;
								StageData tmpStageData = _tmpStageData;
								if (tmpStageData._003Ctileset_003Ek__BackingField == null)
								{
									SpawnYellowItems();
								}
								else
								{
									GenerateTilingTileset();
								}
								VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-D8_v9 (System.Int32)+1C0]");
								bool flag10 = (nint)0 == 0;
								int num8 = 0;
								if (!flag10)
								{
									bool isStageHost = GM.Core.IsStageHost;
									bool flag11 = !isStageHost;
									num8 = 0;
									if (!flag11)
									{
										num8 = 0;
										List<FollowerData>.Enumerator enumerator3 = default(List<FollowerData>.Enumerator);
										while (enumerator3.MoveNext())
										{
											int num9 = AddFollower(null, playerOne, num8);
											num8 = num9;
										}
									}
								}
								List<FollowerData> aICharacters = MultiplayerManager.s_instance.AICharacters;
								List<FollowerData>.Enumerator enumerator4 = default(List<FollowerData>.Enumerator);
								while (enumerator4.MoveNext())
								{
									FollowerData followerData = null;
								}
								GlimmerManager glimmerManager = new GlimmerManager();
								_glimmerManager = glimmerManager;
								SetupFancyBackground();
								MakeDoorVfx();
								GameManager gameManager = _gameManager;
								if (gameManager._multiplayer.IsOnlineMultiplayer)
								{
									GameplayLoader.LoadCoffinCharactersOnline();
								}
								return;
							}
						}
					}
				}
			}
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new NullReferenceException();
	}

	public void DoTeleportVfx(float2 position, TweenCallback onComplete, Action onYoyo)
	{
		//IL_0070: Expected I, but got O
		//IL_00c6: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_01a8: Expected I, but got O
		//IL_028e: Expected O, but got I4
		_003C_003Ec__DisplayClass244_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass244_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.onYoyo = onYoyo;
		PhaserSprite phaserSprite = _beam.setPosition(position);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_beam != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		if (_teleportVfxTween != null && _teleportVfxTween.IsAlive())
		{
			_teleportVfxTween.Kill();
		}
		PhaserSprite phaserSprite2 = _whiteFader.setAlpha(0f);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_whiteFader != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 300f;
		tweenConfig2.yoyo = true;
		tweenConfig2.onComplete = onComplete;
		TweenCallback onYoyo2 = delegate
		{
			//IL_0027: Expected O, but got I4
			Stage stage = CS_0024_003C_003E8__locals5._003C_003E4__this;
			PhaserSprite phaserSprite3 = stage._beam.setScale(0f, (float?)(object)0);
			Action onYoyo3 = CS_0024_003C_003E8__locals5.onYoyo;
			if (CS_0024_003C_003E8__locals5.onYoyo != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v49.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		tweenConfig2.onYoyo = onYoyo2;
		MultiTargetTween teleportVfxTween = Tweens.Add(tweenConfig2);
		_teleportVfxTween = teleportVfxTween;
	}

	private void MakeDoorVfx()
	{
		//IL_0047: Expected O, but got I4
		//IL_017d: Expected O, but got I4
		//IL_01c7: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "Beam");
		PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)1);
		PhaserSprite phaserSprite3 = phaserSprite2.setTint(16448250u);
		PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
		PhaserSprite phaserSprite5 = phaserSprite4.setDepth(1996);
		GameObject gameObject = phaserSprite5.gameObject;
		((UnityEngine.Object)gameObject).SetName("PickupTeleporter - Beam");
		_beam = phaserSprite5;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserSprite phaserSprite6 = RenderingExtensions.sprite(s_scene2.add, pos, "vfx", "WhiteDot");
			PhaserSprite phaserSprite7 = phaserSprite6.setTint(16448250u);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene3._renderer;
				if ((object)GM.Core != null)
				{
					float xScale = renderer.width * 100f;
					PhaserSprite component = phaserSprite7.setScale(xScale, (float?)(object)1);
					PhaserSprite phaserSprite8 = RenderingExtensions.SetScrollFactor(component, 0f);
					PhaserSprite phaserSprite9 = phaserSprite8.setAlpha(0f);
					PhaserSprite phaserSprite10 = phaserSprite9.setOrigin(0f, (float?)(object)0);
					PhaserSprite phaserSprite11 = phaserSprite10.setDepth(1996);
					GameObject gameObject2 = phaserSprite11.gameObject;
					((UnityEngine.Object)gameObject2).SetName("PickupTeleporter - WhiteFader");
					_whiteFader = phaserSprite11;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe static int AddFollower(FollowerData followerData, VampireSurvivors.Objects.Characters.CharacterController playerOne, int lastPlayerindex)
	{
		//IL_0522: Expected I, but got O
		//IL_0035: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_004b: Expected O, but got Ref
		//IL_0252: Expected I, but got O
		//IL_027b: Expected I, but got O
		//IL_016c: Expected I, but got O
		//IL_019a: Expected O, but got I
		//IL_02cf: Expected O, but got I
		//IL_032d: Expected I, but got O
		//IL_0209: Expected I, but got O
		//IL_0373: Expected O, but got I
		//IL_0392: Expected I, but got O
		//IL_023b: Expected O, but got I
		//IL_0244: Expected I, but got O
		//IL_0420: Expected O, but got I
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		int num3;
		VampireSurvivors.Objects.Characters.CharacterController followedCharacter;
		if ((object)GM.Core != null && core._characters != null)
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj2 = 0;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				bool flag = followerData == null;
				num2 = (nint)(&enumerator);
				if (flag)
				{
					goto IL_0503;
				}
				bool flag2 = !followerData._003CAllowDuplicates_003Ek__BackingField;
				num3 = lastPlayerindex;
				if (flag2)
				{
					goto IL_05b7;
				}
			}
			bool flag3 = followerData == null;
			num2 = (nint)(&enumerator);
			if (!flag3)
			{
				if (!followerData._003CShouldFollowMainPlayer_003Ek__BackingField)
				{
					int num4 = lastPlayerindex + 1;
					num2 = (nint)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+298]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+298]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v50+18]");
							bool flag4 = (nint)num4 >= (nint)0;
							num3 = 0;
							if (!flag4)
							{
								num3 = num4;
							}
							GameManager core2 = GM.Core;
							List<VampireSurvivors.Objects.Characters.CharacterController> characters = core2._characters;
							if (num3 >= characters._size)
							{
								goto IL_0602;
							}
							num2 = (nint)characters._items;
							if (characters._items != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+20+v728 @ rsi_v7 (System.Int32)*8]");
								followedCharacter = (VampireSurvivors.Objects.Characters.CharacterController)0;
								nint num5 = (nint)GM.Core;
								goto IL_0289;
							}
						}
					}
				}
				else
				{
					nint num5 = (nint)GM.Core;
					bool flag5 = (object)GM.Core == null;
					followedCharacter = playerOne;
					num3 = lastPlayerindex;
					num2 = (nint)GM.Core;
					if (!flag5)
					{
						goto IL_0289;
					}
				}
			}
		}
		goto IL_0503;
		IL_0289:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rcx_v13 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+108]");
		bool flag6 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rcx_v13 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+108]");
		num2 = 0;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rcx_v13 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+108]");
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = ((DataManager)0).GetConvertedCharacterData();
			bool flag7 = convertedCharacterData == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rcx_v13 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+108]");
			num2 = 0;
			if (!flag7)
			{
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)followerData._003CFollowerCharacter_003Ek__BackingField);
				bool flag8 = obj4 == null;
				num2 = (nint)convertedCharacterData;
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v25 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0602;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v25 (System.Object)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v25 (System.Object)+10]");
					bool flag9 = (nint)0 == 0;
					num2 = (nint)convertedCharacterData;
					if (!flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v26+20]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v26+20]");
						if ((nint)0 != 0)
						{
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+40]");
								CharacterLoader.LoadCharacterTexture((string)0, followerData._003CFollowerCharacter_003Ek__BackingField, core3._dataManager);
								if ((object)GM.Core != null)
								{
									bool manualLevelups = default(bool);
									int everyXLevels = default(int);
									bool spawnWithoutAuthority = default(bool);
									VampireSurvivors.Objects.Characters.CharacterController characterController = GM.Core.AddFollower(followerData._003CFollowerCharacter_003Ek__BackingField, followedCharacter, followerData._003CFollowerAI_003Ek__BackingField, manualLevelups, everyXLevels, spawnWithoutAuthority);
									if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
									{
										characterController._003CTrackedByCamera_003Ek__BackingField = followerData._003CTrackedByCamera_003Ek__BackingField;
										characterController.IsFollowerSharingPassives = followerData._003CShouldSharePassives_003Ek__BackingField;
										characterController.IsFollowerReactingToArcanas = followerData._003CShouldFollowerReactToArcanas_003Ek__BackingField;
										characterController.SetPermanentInvulnerability(followerData._003CIsFollowerInvinceable_003Ek__BackingField);
										characterController._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = followerData._003CCountsAsMainCharacterForRevivals_003Ek__BackingField;
									}
									goto IL_05b7;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0503;
		IL_05b7:
		return num3;
		IL_0503:
		throw new NullReferenceException();
		IL_0602:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	private void SetupStageDataByBiome(StageType stageType)
	{
		switch (stageType)
		{
		case StageType.EMERALD:
			SetupStageDataByBiomeInternal<BackgroundEmerald.EmeraldsBiomes>(stageType);
			break;
		case StageType.TP_CASTLE:
			SetupStageDataByBiomeInternal<TPBiomeType>(StageType.TP_CASTLE);
			break;
		}
	}

	private unsafe void SetupStageDataByBiomeInternal<TBiome>(StageType stageType) where TBiome : struct, Enum
	{
		//IL_006d: Expected O, but got I
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_00cf: Expected I, but got O
		//IL_031d: Expected O, but got Ref
		//IL_0339: Expected O, but got Ref
		//IL_0341: Expected O, but got I
		//IL_0384: Expected O, but got Ref
		//IL_038d: Expected O, but got Ref
		//IL_039f: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_0f63: Expected I, but got O
		//IL_01d8: Expected O, but got I4
		//IL_0181: Expected O, but got I
		//IL_02e7: Expected O, but got I
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_03e9: Expected I, but got O
		//IL_01e5: Expected I, but got O
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_0412: Expected O, but got I
		//IL_0226: Expected I, but got O
		//IL_0433: Expected O, but got I
		//IL_0458: Expected O, but got I
		//IL_046e: Expected O, but got I
		//IL_0f82: Expected O, but got I
		//IL_024e: Expected O, but got I
		//IL_049b: Expected O, but got I
		//IL_025b: Expected I, but got O
		//IL_0c03: Expected I, but got O
		//IL_0c1c: Expected O, but got I
		//IL_087c: Expected O, but got I
		//IL_051f: Expected O, but got I4
		//IL_0539: Expected O, but got Ref
		//IL_0ca7: Expected I, but got O
		//IL_0587: Expected O, but got Ref
		//IL_0fd8: Expected O, but got I4
		//IL_085a: Expected I, but got O
		//IL_0d24: Expected I4, but got O
		//IL_0bdf: Expected O, but got Ref
		//IL_0be8: Expected O, but got Ref
		//IL_0933: Expected O, but got I4
		//IL_05f4: Expected I, but got O
		//IL_0611: Expected O, but got Ref
		//IL_062f: Expected O, but got I
		//IL_0646: Expected O, but got Ref
		//IL_0940: Expected I, but got O
		//IL_065c: Expected I, but got O
		//IL_0685: Expected O, but got Ref
		//IL_0979: Expected I, but got O
		//IL_06be: Expected O, but got I
		//IL_0727: Expected I, but got O
		//IL_0749: Expected O, but got Ref
		//IL_077e: Expected O, but got Ref
		//IL_0a2e: Expected O, but got I
		//IL_0aab: Expected O, but got I
		//IL_0794: Expected I, but got O
		//IL_07bd: Expected O, but got Ref
		//IL_0ac3: Expected I, but got O
		//IL_07fd: Expected O, but got Ref
		//IL_0820: Expected O, but got I
		//IL_0b97: Expected O, but got I
		//IL_0ba7: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		DataManager dataManager = _dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllStages_003Ek__BackingField).get_Item((System.Int32Enum)stageType);
		JArray jArray = ((Dictionary<StageType, JArray>)0).get_Item(StageType.SINKING);
		object obj2 = jArray + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Array array2 = default(Array);
		Array array = array2;
		if (array != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v638 @ rdx_v7 (Il2CppClass<System.Array>)+8F8] (should have been resolved before IL gen)");
			Array array3 = default(Array);
			IEnumerator enumerator = array3.GetEnumerator();
			Array array4 = default(Array);
			object obj3 = default(object);
			IntPtr intPtr = default(IntPtr);
			object obj11;
			Dictionary<int, JArray> dictionary7 = default(Dictionary<int, JArray>);
			TBiome result;
			nint num4;
			Dictionary<int, JArray> dictionary8;
			Dictionary<int, JArray> dictionary9;
			object obj12 = default(object);
			Array array6 = default(Array);
			Dictionary<int, JArray> dictionary10 = default(Dictionary<int, JArray>);
			while (true)
			{
				object obj10;
				object obj4;
				if (array4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj3 != null)
					{
						bool flag = array4 == null;
						Array array5 = null;
						array = array4;
						if (!flag)
						{
							nint num2 = (nint)array4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ r10_v30 (Il2CppClass<System.Array>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_01bd;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ r10_v30 (Il2CppClass<System.Array>)+B0]");
							obj4 = 0;
							Dictionary<int, JArray> dictionary = null;
							while (true)
							{
								object obj5 = (object)dictionary + (object)dictionary;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ r8_v80+v1004 @ rax_v222*8]");
								if (0 == (nint)typeof(IEnumerator))
								{
									break;
								}
								dictionary = (Dictionary<int, JArray>)(dictionary + 1);
								Dictionary<int, JArray> dictionary2 = dictionary;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ r10_v30 (Il2CppClass<System.Array>)+12E]");
								if ((nint)dictionary2 < 0)
								{
									continue;
								}
								goto IL_01bd;
							}
							object obj6 = (object)dictionary + (object)dictionary;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ r8_v80+8+v1167 @ rcx_v157*8]");
							object obj7 = (nint)0 + (nint)1;
							object obj8 = obj7 << 4;
							object obj9 = obj8 + 312;
							obj10 = obj9 + num2;
							goto IL_0f46;
						}
						throw new NullReferenceException();
					}
					Dictionary<int, JArray> dictionary3 = (Dictionary<int, JArray>)(&array4);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Dictionary<int, JArray> dictionary4 = (Dictionary<int, JArray>)(&array4);
					dictionary4 = (Dictionary<int, JArray>)(nint)intPtr;
					if (intPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					obj11 = obj;
					Dictionary<int, JArray> dictionary5 = (Dictionary<int, JArray>)(&array4);
					Dictionary<int, JArray> dictionary6 = (Dictionary<int, JArray>)(&dictionary7);
					nint num3 = intPtr;
					result = (TBiome)null;
					num4 = unchecked((nint)null);
					dictionary8 = null;
					dictionary9 = null;
					break;
				}
				throw new NullReferenceException();
				IL_01bd:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj10 = obj12;
				obj4 = 1;
				goto IL_0f46;
				IL_0f46:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1174 @ rdx_v112] (should have been resolved before IL gen)");
				nint num5 = 0;
				bool flag2 = array6 == null;
				array = array6;
				if (!flag2)
				{
					nint num6 = (nint)array6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1392 @ rcx_v141 (Il2CppClass<System.Array>)+40]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1267 @ rdx_v115 (Il2CppClass<TBiome>)+40]");
					bool flag3 = num7 != 0;
					array = array6;
					if (!flag3)
					{
						Array array7 = (Array)(object)(IntPtr)dictionary10;
						JArray value = new JArray();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
						object obj13 = 0;
						nint num8 = (nint)array7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1797 @ rdx_v122 (Il2CppClass<System.Array>)+40]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1713 @ rcx_v148+40]");
						if (num9 == 0)
						{
							Dictionary<int, JArray> stageDataByBiome = _stageDataByBiome;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1486 @ rax_v205 (System.Array)+10]");
							bool flag4 = ((Dictionary<int, object>)(object)stageDataByBiome).TryInsert(0, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
							array = array7;
							continue;
						}
						throw new InvalidCastException();
					}
					throw new InvalidCastException();
				}
				throw new NullReferenceException();
			}
			object obj14 = default(object);
			string value2 = default(string);
			object obj23 = default(object);
			IEnumerable<JToken> value4 = default(IEnumerable<JToken>);
			TBiome val = default(TBiome);
			IntPtr intPtr2 = default(IntPtr);
			object obj25 = default(object);
			Dictionary<int, JArray> dictionary11 = default(Dictionary<int, JArray>);
			Dictionary<int, JArray> dictionary12 = default(Dictionary<int, JArray>);
			while (true)
			{
				nint num10 = (nint)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1429 @ rdx_v48 (Il2CppClass<System.Object>)+5E8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (System.Runtime.CompilerServices.Unsafe.As<Dictionary<int, JArray>, UIntPtr>(ref dictionary9) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
				{
					return;
				}
				object CS_0024_003C_003E8__locals3 = null;
				nint num11 = (nint)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1740 @ r8_v36 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+10]");
				object obj15 = 0;
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1971 @ r8_v39 (Il2CppMethodInfo)+50]");
				object obj16 = (nint)0 + (nint)20;
				object obj17 = obj16 + obj16;
				object obj18 = obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1975 @ rax_v98+v1974 @ rcx_v65*8]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2050 @ rdx_v54+53]");
				object obj20 = (nint)0 & (nint)2;
				if (obj20 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2050 @ rdx_v54+40]");
					object obj21 = 0;
					obj19 = obj21;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1971 @ r8_v39 (Il2CppMethodInfo)+40]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AFEED0");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2057 @ rax_v101+8] (should have been resolved before IL gen)");
				if (!Enum.TryParse<TBiome>(value2, ignoreCase: true, out var result2))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+10]");
					if (Enum.TryParse<TBiome>(value2, ignoreCase: false, out result2))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+10]");
						JArray jArray2 = (JArray)Enum.TryParse<TBiome>(value2, ignoreCase: false, out result2);
						IEnumerator<JToken> enumerator2 = jArray2.GetEnumerator();
						Array array8 = (Array)(&num4);
						System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
						while (true)
						{
							if (num4 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								if (obj23 == null)
								{
									break;
								}
								bool flag5 = num4 == 0;
								Array array5 = null;
								array = (Array)(&num4);
								if (!flag5)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804860B0");
									object value3 = Newtonsoft.Json.Linq.Extensions.Value<object>(value4);
									bool flag6 = Enum.TryParse<TBiome>((string)value3, ignoreCase: true, out result);
									bool flag7 = !flag6;
									insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
									if (flag7)
									{
										continue;
									}
									Array array9 = (Array)(object)(IntPtr)val;
									bool flag8 = _stageDataByBiome == null;
									array = (Array)(&num4);
									if (!flag8)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
										object obj24 = 0;
										bool flag9 = array9 == null;
										array = (Array)(&num4);
										if (!flag9)
										{
											nint num13 = (nint)array9;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rdx_v98 (Il2CppClass<System.Array>)+40]");
											nint num14 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ r9_v44+40]");
											bool flag10 = num14 != 0;
											array = (Array)(&num4);
											if (!flag10)
											{
												Dictionary<int, JArray> stageDataByBiome2 = _stageDataByBiome;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1366 @ rax_v165 (System.Array)+10]");
												JArray collection = stageDataByBiome2.get_Item(0);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+18]");
												Func<JToken, bool> condition = (Func<JToken, bool>)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+18]");
												if ((nint)0 == 0)
												{
													Func<JToken, bool> func = delegate(JToken s)
													{
														//IL_00bb: Expected I4, but got O
														if (s != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
															bool flag18 = default(bool);
															if (!flag18)
															{
																return flag18;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
															if (((_003C_003Ec__DisplayClass248_0<TBiome>)CS_0024_003C_003E8__locals3).jToken != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
																object obj36 = default(object);
																object obj35 = obj36 >> 32;
																object obj38 = default(object);
																object obj37 = obj38 - obj35;
																bool flag19 = obj37 == null;
																object obj40 = default(object);
																object obj39 = obj40 - obj36;
																bool flag20 = obj39 == null;
																return flag20 & flag19;
															}
														}
														NullReferenceException ex4 = new NullReferenceException();
														return (byte)(int)ex4 != 0;
													};
													condition = func;
												}
												VampireSurvivors.App.Tools.Extensions.RemoveWhere((ICollection<object>)collection, (Func<object, bool>)condition);
												Array array10 = (Array)(object)(IntPtr)val;
												bool flag11 = _stageDataByBiome == null;
												array = (Array)(&num4);
												if (!flag11)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
													insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
													bool flag12 = array10 == null;
													array = (Array)(&num4);
													if (!flag12)
													{
														nint num15 = (nint)array10;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v965 @ rdx_v103 (Il2CppClass<System.Array>)+40]");
														nint num16 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r9_v29 (System.Collections.Generic.InsertionBehavior)+40]");
														bool flag13 = num16 != 0;
														array = (Array)(&num4);
														if (!flag13)
														{
															Dictionary<int, JArray> stageDataByBiome3 = _stageDataByBiome;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rax_v171 (System.Array)+10]");
															JArray jArray3 = stageDataByBiome3.get_Item(0);
															bool flag14 = jArray3 == null;
															array = (Array)(&num4);
															if (!flag14)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+10]");
																jArray3.Add((object)0);
																val = result2;
																continue;
															}
															throw new NullReferenceException();
														}
														throw new InvalidCastException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new InvalidCastException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						bool flag15 = array8 == null;
						nint num3 = num4;
						if (!flag15)
						{
							num3 = (nint)array8;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						dictionary8 = null;
					}
					else
					{
						Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
						if ((object)typeFromHandle == null)
						{
							ArgumentNullException ex = new ArgumentNullException("enumType");
							ex._002Ector("enumType");
							throw ex;
						}
						Array enumValues = typeFromHandle.GetEnumValues();
						IEnumerator enumerator3 = enumValues.GetEnumerator();
						System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
						while (true)
						{
							if (intPtr2 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								if (obj25 == null)
								{
									break;
								}
								bool flag16 = intPtr2 == (IntPtr)0;
								dictionary11 = null;
								if (!flag16)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									nint num17 = 0;
									dictionary11 = (Dictionary<int, JArray>)1;
									if (dictionary12 != null)
									{
										nint num18 = (nint)dictionary12;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2214 @ rcx_v94 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32, Newtonsoft.Json.Linq.JArray>>)+40]");
										nint num19 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2204 @ rdx_v77 (Il2CppClass<TBiome>)+40]");
										if (num19 == 0)
										{
											object obj26 = (IntPtr)val;
											if (_stageDataByBiome != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
												insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
												if (obj26 != null)
												{
													object obj27 = obj26;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2007 @ rdx_v79+40]");
													nint num20 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r9_v29 (System.Collections.Generic.InsertionBehavior)+40]");
													if (num20 == 0)
													{
														Dictionary<int, JArray> stageDataByBiome4 = _stageDataByBiome;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2085 @ rax_v134+10]");
														JArray source = stageDataByBiome4.get_Item(0);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+20]");
														Func<JToken, bool> predicate = (Func<JToken, bool>)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+20]");
														if ((nint)0 == 0)
														{
															Func<JToken, bool> func2 = delegate(JToken s)
															{
																//IL_00bb: Expected I4, but got O
																if (s != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
																	bool flag18 = default(bool);
																	if (!flag18)
																	{
																		return flag18;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
																	if (((_003C_003Ec__DisplayClass248_0<TBiome>)CS_0024_003C_003E8__locals3).jToken != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
																		object obj36 = default(object);
																		object obj35 = obj36 >> 32;
																		object obj38 = default(object);
																		object obj37 = obj38 - obj35;
																		bool flag19 = obj37 == null;
																		object obj40 = default(object);
																		object obj39 = obj40 - obj36;
																		bool flag20 = obj39 == null;
																		return flag20 & flag19;
																	}
																}
																NullReferenceException ex4 = new NullReferenceException();
																return (byte)(int)ex4 != 0;
															};
															insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
															predicate = func2;
														}
														bool flag17 = Enumerable.Any(source, predicate);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2808 @ rax_v129 (System.Collections.Generic.Dictionary`2<System.Int32, Newtonsoft.Json.Linq.JArray>)+10]");
														val = (TBiome)0;
														if (!flag17)
														{
															object obj28 = (IntPtr)val;
															if (_stageDataByBiome == null)
															{
																throw new NullReferenceException();
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
															insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
															if (obj28 == null)
															{
																throw new NullReferenceException();
															}
															object obj29 = obj28;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1761 @ rdx_v84+40]");
															nint num21 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r9_v29 (System.Collections.Generic.InsertionBehavior)+40]");
															if (num21 != 0)
															{
																throw new InvalidCastException();
															}
															Dictionary<int, JArray> stageDataByBiome5 = _stageDataByBiome;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1840 @ rax_v140+10]");
															JArray jArray4 = stageDataByBiome5.get_Item(0);
															if (jArray4 == null)
															{
																throw new NullReferenceException();
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1646 @ rax_v94 (System.Object)+10]");
															jArray4.Add((object)0);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2808 @ rax_v129 (System.Collections.Generic.Dictionary`2<System.Int32, Newtonsoft.Json.Linq.JArray>)+10]");
															val = (TBiome)0;
														}
														continue;
													}
													throw new InvalidCastException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new InvalidCastException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B97280");
						if (dictionary8 != null)
						{
							throw dictionary11;
						}
						Dictionary<int, JArray> dictionary5 = (Dictionary<int, JArray>)(&intPtr2);
						Dictionary<int, JArray> dictionary6 = (Dictionary<int, JArray>)(&intPtr2);
						nint num3 = intPtr2;
						dictionary8 = null;
					}
				}
				else
				{
					object obj30 = (IntPtr)val;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
					object obj31 = 0;
					object obj32 = obj30;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2490 @ r9_v33+40]");
					nint num22 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r10_v31+40]");
					if (num22 != 0)
					{
						break;
					}
					Dictionary<int, JArray> stageDataByBiome6 = _stageDataByBiome;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v107+10]");
					JArray collection2 = stageDataByBiome6.get_Item(0);
					Func<JToken, bool> condition2 = delegate(JToken s)
					{
						//IL_00bb: Expected I4, but got O
						if (s != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
							bool flag18 = default(bool);
							if (!flag18)
							{
								return flag18;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
							if (((_003C_003Ec__DisplayClass248_0<TBiome>)CS_0024_003C_003E8__locals3).jToken != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
								object obj36 = default(object);
								object obj35 = obj36 >> 32;
								object obj38 = default(object);
								object obj37 = obj38 - obj35;
								bool flag19 = obj37 == null;
								object obj40 = default(object);
								object obj39 = obj40 - obj36;
								bool flag20 = obj39 == null;
								return flag20 & flag19;
							}
						}
						NullReferenceException ex4 = new NullReferenceException();
						return (byte)(int)ex4 != 0;
					};
					VampireSurvivors.App.Tools.Extensions.RemoveWhere((ICollection<object>)collection2, (Func<object, bool>)condition2);
					object obj33 = (IntPtr)val;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
					nint num2 = 0;
					object obj34 = obj33;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v35+40]");
					nint num23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ r10_v30 (Il2CppClass<System.Array>)+40]");
					if (num23 != 0)
					{
						InvalidCastException ex2 = new InvalidCastException();
						break;
					}
					Dictionary<int, JArray> stageDataByBiome7 = _stageDataByBiome;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v113+10]");
					JArray jArray5 = stageDataByBiome7.get_Item(0);
					System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)jArray5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r9_v29 (System.Collections.Generic.InsertionBehavior)+6F0]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v163 @ r9_v29 (System.Collections.Generic.InsertionBehavior)+6E8] (should have been resolved before IL gen)");
					val = result2;
					dictionary8 = null;
				}
				dictionary9 = (Dictionary<int, JArray>)(0 + 1);
				obj11 = obj;
			}
			throw new InvalidCastException();
		}
		ArgumentNullException ex3 = new ArgumentNullException("enumType");
		ex3._002Ector("enumType");
		throw ex3;
	}

	public unsafe void InitStagePostLoad()
	{
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_01df: Expected O, but got Ref
		//IL_023d: Expected I, but got O
		//IL_0419: Expected O, but got I4
		//IL_0278: Expected I, but got O
		StageData tmpStageData = _tmpStageData;
		bool flag = _tmpStageData == null;
		GameManager gameManager = (GameManager)(object)this;
		if (!flag)
		{
			if (tmpStageData._003Ctileset_003Ek__BackingField != null)
			{
				InitTilingTileset();
			}
			_tmpStageData = null;
			GenerateTilingBackground();
			StageData stageData = _stageData;
			if (_stageData != null)
			{
				Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
				if (stageData._003Ctileset_003Ek__BackingField != null && tileset._003ChardBounds_003Ek__BackingField != null)
				{
					HardBounds hardBounds = tileset._003ChardBounds_003Ek__BackingField;
					gameManager = _gameManager;
					if ((object)_gameManager == null)
					{
						goto IL_0585;
					}
					float yMax = default(float);
					bool skipInverseCalculation = default(bool);
					_gameManager.SetHardBoundsMinMax(hardBounds._003Cx_003Ek__BackingField, hardBounds._003Cy_003Ek__BackingField, hardBounds._003Cwidth_003Ek__BackingField, yMax, skipInverseCalculation);
					Debug.Log("[Stage] Set hard bounds dynamically from StageData");
				}
			}
			SetHardBoundsFromTMX();
			StageData stageData2 = _stageData;
			bool flag2 = _stageData == null;
			gameManager = (GameManager)(object)this;
			if (!flag2)
			{
				if (stageData2._003Cbackground_003Ek__BackingField != null)
				{
					BackgroundManager fancyBg = _fancyBg;
					if ((object)_fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
					{
						BackgroundManager fancyBg2 = _fancyBg;
						Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
						bool flag3 = (object)_fancyBg == null;
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						gameManager = (GameManager)(&enumerator);
						if (!flag3)
						{
							fancyBg2._camBounds = (Bounds)bounds.m_Center;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v80 (UnityEngine.Bounds)+10]");
							_ = 0;
							gameManager = (GameManager)(object)_fancyBg;
							if ((object)_fancyBg != null)
							{
								nint num = (nint)gameManager;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1053 @ rdx_v31 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+1F8] (should have been resolved before IL gen)");
								gameManager = (GameManager)(object)_fancyBg;
								if ((object)_fancyBg != null)
								{
									nint num2 = (nint)gameManager;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1055 @ rdx_v33 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+1D8] (should have been resolved before IL gen)");
									object obj = default(object);
									if (obj != null)
									{
										goto IL_029f;
									}
									goto IL_034a;
								}
							}
						}
						goto IL_0585;
					}
				}
				goto IL_029f;
			}
		}
		goto IL_0585;
		IL_0585:
		throw new NullReferenceException();
		IL_029f:
		StageData stageData3 = _stageData;
		bool flag4 = _stageData == null;
		GameManager gameManager2 = null;
		GameManager gameManager3 = null;
		gameManager = null;
		if (!flag4)
		{
			while ((nint)gameManager3 < stageData3._003CstartingSpawns_003Ek__BackingField)
			{
				HandleSpawning(checkMaxEnemyCount: false);
				gameManager2 = (GameManager)(gameManager2 + 1);
				stageData3 = _stageData;
				if (_stageData != null)
				{
					gameManager3 = gameManager2;
					continue;
				}
				goto IL_0585;
			}
			goto IL_034a;
		}
		goto IL_0585;
		IL_034a:
		SpawnBoss();
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			SpawnAdventureMerchants();
		}
		if (_playerOptions != null)
		{
			List<CharacterType> customMerchantCharacters = _playerOptions.GetCustomMerchantCharacters();
			SpawnCustomMerchants(customMerchantCharacters);
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator2.MoveNext())
				{
					object obj2 = 0;
					nint num3 = (nint)(&enumerator2);
					throw new NullReferenceException();
				}
				_003CHasInitialized_003Ek__BackingField = true;
				return;
			}
		}
		goto IL_0585;
	}

	public unsafe SuperObject GetHardBoundsObjFromTMX()
	{
		//IL_0193: Expected I, but got O
		//IL_0302: Expected O, but got Ref
		//IL_031e: Expected O, but got Ref
		//IL_01f9: Expected I, but got O
		//IL_0206: Expected I, but got O
		//IL_0216: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_02e7: Expected O, but got Ref
		//IL_02f0: Expected I, but got O
		TilingTileset tilingTileset = _tilingTileset;
		if ((object)_tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_tilingTileset != null)
			{
				SuperMap defaultMap = _tilingTileset.DefaultMap;
				if ((object)defaultMap == null || ((UnityEngine.Object)defaultMap).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0357;
				}
				Transform transform = defaultMap.transform;
				if ((object)transform != null)
				{
					if ("Grid" == null)
					{
						ArgumentNullException ex = new ArgumentNullException("Name cannot be null");
						ex._002Ector("Name cannot be null");
						throw ex;
					}
					Transform transform2 = transform.FindRelativeTransformWithPath("Grid", false);
					if ((object)transform2 != null)
					{
						if ("HardBounds" != null)
						{
							Transform transform3 = transform2.FindRelativeTransformWithPath("HardBounds", false);
							if ((object)transform3 != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
							{
								IEnumerator enumerator = transform3.GetEnumerator();
								nint num = unchecked((nint)null);
								object obj = default(object);
								object obj2 = default(object);
								Transform transform5 = default(Transform);
								object obj5 = default(object);
								while (true)
								{
									if (obj != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
										if (obj2 == null)
										{
											break;
										}
										bool flag = obj == null;
										Transform transform4 = null;
										if (!flag)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
											nint num2 = (nint)typeof(Transform);
											num = (nint)transform5;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rcx_v46 (Il2CppClass<UnityEngine.Transform>)+130]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v7 (Il2CppClass<UnityEngine.Transform>)+130]");
											nint num3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rcx_v46 (Il2CppClass<UnityEngine.Transform>)+130]");
											if (num3 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v7 (Il2CppClass<UnityEngine.Transform>)+C8]");
												object obj4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ rax_v61+FFFFFFF8+v778 @ rax_v60*8]");
												if (0 == (nint)typeof(Transform))
												{
													SuperObject component = transform5.GetComponent<SuperObject>();
													transform4 = (Transform)(object)typeof(UnityEngine.Object);
													if ((object)component != null)
													{
														bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
														transform4 = (Transform)(object)typeof(UnityEngine.Object);
														if (!flag2)
														{
															SuperObject component2 = ((Component)(&obj5)).GetComponent<SuperObject>();
															nint num4 = unchecked((nint)null);
															return component;
														}
													}
													continue;
												}
											}
											throw new InvalidCastException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								object obj6 = (object)(&obj);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
								object obj7 = (object)(&obj);
								object obj8 = default(object);
								obj7 = obj8;
								if (obj8 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
							}
							goto IL_0357;
						}
						ArgumentNullException ex2 = new ArgumentNullException("Name cannot be null");
						ex2._002Ector("Name cannot be null");
						throw ex2;
					}
				}
			}
			return (SuperObject)(object)new NullReferenceException();
		}
		goto IL_0357;
		IL_0357:
		return null;
	}

	private unsafe void SetHardBoundsFromTMX()
	{
		//IL_0144: Expected I, but got O
		//IL_031f: Expected O, but got Ref
		//IL_033b: Expected O, but got Ref
		//IL_01aa: Expected I, but got O
		//IL_01b7: Expected I, but got O
		//IL_01c7: Expected O, but got I
		//IL_0203: Expected O, but got I
		//IL_030d: Expected I, but got O
		TilingTileset tilingTileset = _tilingTileset;
		if ((object)_tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		SuperMap defaultMap = _tilingTileset.DefaultMap;
		if ((object)defaultMap == null || ((UnityEngine.Object)defaultMap).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform transform = defaultMap.transform;
		if ("Grid" != null)
		{
			Transform transform2 = transform.FindRelativeTransformWithPath("Grid", false);
			if ("HardBounds" != null)
			{
				Transform transform3 = transform2.FindRelativeTransformWithPath("HardBounds", false);
				if ((object)transform3 == null || ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				IEnumerator enumerator = transform3.GetEnumerator();
				nint num = unchecked((nint)null);
				object obj = default(object);
				object obj2 = default(object);
				Transform transform5 = default(Transform);
				float yMax = default(float);
				bool skipInverseCalculation = default(bool);
				object obj7 = default(object);
				while (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj2 != null)
					{
						bool flag = obj == null;
						Transform transform4 = null;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							nint num2 = (nint)typeof(Transform);
							num = (nint)transform5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rcx_v46 (Il2CppClass<UnityEngine.Transform>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r9_v7 (Il2CppClass<UnityEngine.Transform>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rcx_v46 (Il2CppClass<UnityEngine.Transform>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r9_v7 (Il2CppClass<UnityEngine.Transform>)+C8]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ rax_v62+FFFFFFF8+v844 @ rax_v61*8]");
								if (0 == (nint)typeof(Transform))
								{
									SuperObject component = transform5.GetComponent<SuperObject>();
									transform4 = (Transform)(object)typeof(UnityEngine.Object);
									if ((object)component != null)
									{
										bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
										transform4 = (Transform)(object)typeof(UnityEngine.Object);
										if (!flag2)
										{
											float num4 = component.m_Height + component.m_Y;
											float xMax = component.m_Width + component.m_X;
											_gameManager.SetHardBoundsMinMax(component.m_X, component.m_Y, xMax, yMax, skipInverseCalculation);
											Debug.Log("[Stage] Set hard bounds dynamically from TMX");
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B97280");
											nint num5 = unchecked((nint)null);
											return;
										}
									}
									continue;
								}
							}
							throw new InvalidCastException();
						}
						throw new NullReferenceException();
					}
					object obj5 = (object)(&obj);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					object obj6 = (object)(&obj);
					obj6 = obj7;
					if (obj7 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					return;
				}
				throw new NullReferenceException();
			}
			ArgumentNullException ex = new ArgumentNullException("Name cannot be null");
			ex._002Ector("Name cannot be null");
			throw ex;
		}
		ArgumentNullException ex2 = new ArgumentNullException("Name cannot be null");
		ex2._002Ector("Name cannot be null");
		throw ex2;
	}

	private void SetHardBoundsFromStageData()
	{
		StageData stageData = _stageData;
		if (_stageData != null)
		{
			Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
			if (stageData._003Ctileset_003Ek__BackingField != null && tileset._003ChardBounds_003Ek__BackingField != null)
			{
				HardBounds hardBounds = tileset._003ChardBounds_003Ek__BackingField;
				float yMax = default(float);
				bool skipInverseCalculation = default(bool);
				_gameManager.SetHardBoundsMinMax(hardBounds._003Cx_003Ek__BackingField, hardBounds._003Cy_003Ek__BackingField, hardBounds._003Cwidth_003Ek__BackingField, yMax, skipInverseCalculation);
				Debug.Log("[Stage] Set hard bounds dynamically from StageData");
			}
		}
	}

	public void CheckHalfMinute()
	{
		//IL_01a6: Expected I, but got O
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		float num3 = core._003CSurvivedSeconds_003Ek__BackingField / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		int minute = default(int);
		if (GetStageDataForMinute(minute, _stageType, out var _) && _stageEventTwitchManager != null)
		{
			_stageEventTwitchManager.ShowTwitchUI();
		}
		BackgroundManager fancyBg = _fancyBg;
		if ((object)_fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			_fancyBg.CheckHalfMinute();
		}
		if (_003CStopCheckingMinutes_003Ek__BackingField)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		if (config._003CSelectedRandomEvents_003Ek__BackingField && _trisection != null)
		{
			_trisection.ShowCircles();
			Action onComplete = delegate
			{
				_trisection.Spinnn();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public void CheckMinute()
	{
		//IL_0013: Expected I, but got O
		//IL_0068: Invalid comparison between F4 and I4
		//IL_0077: Invalid comparison between F4 and I4
		//IL_00a0: Expected O, but got I4
		//IL_02d8: Invalid comparison between F4 and I4
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		//IL_0168: Expected O, but got I4
		//IL_015a: Expected O, but got I4
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected I4, but got Unknown
		//IL_0351: Invalid comparison between I4 and F4
		//IL_036f: Invalid comparison between F4 and I4
		//IL_0398: Expected O, but got I4
		if (_003CStopCheckingMinutes_003Ek__BackingField)
		{
			return;
		}
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v3 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		float num3 = core._003CSurvivedSeconds_003Ek__BackingField / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		StageModifiers stageModifiers = _003CStageMods_003Ek__BackingField;
		float num4 = default(float);
		bool flag = num4 < 0f;
		bool flag2 = num4 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj = flag4 & flag3;
		object obj2 = (object?)stageModifiers._003CEndCycles_003Ek__BackingField & obj;
		bool flag5 = obj2 == null;
		int num5 = default(int);
		int minute = num5;
		if (!flag5)
		{
			StageModifiers stageModifiers2 = _003CStageMods_003Ek__BackingField;
			bool flag6 = (object)stageModifiers2._003CTimeLimit_003Ek__BackingField == null;
			minute = num5;
			if (!flag6)
			{
				if (_003CStageMods_003Ek__BackingField == null)
				{
					goto IL_05c4;
				}
				object obj3 = (((object)stageModifiers2._003CTimeLimit_003Ek__BackingField == null) ? ((object)0) : ((object)1));
				if (obj3 == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rsp+74h]\"");
				int num6 = num5 % (_003F?)stageModifiers._003CEndCycles_003Ek__BackingField;
				bool flag7 = num6 != 0;
				minute = num6;
				if (!flag7)
				{
					OnCycleComplete();
					return;
				}
			}
		}
		StageData stageData = _stageData;
		StageType stageType = _stageType;
		if (stageData._003CrandomMinutes_003Ek__BackingField)
		{
			List<StageType> validUnlockedStages = GetValidUnlockedStages();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
			if ((nint)0 >= (nint)2)
			{
				StageType stageType2 = VampireSurvivors.App.Tools.Extensions.PickRnd(validUnlockedStages);
				stageType = stageType2;
			}
		}
		if (num5 > _currentMinute && GetStageDataForMinute(minute, stageType, out var stageJsonObject))
		{
			_currentMinute = num5;
			UpdateAllData(stageJsonObject);
		}
		StageModifiers stageModifiers3 = _003CStageMods_003Ek__BackingField;
		TimeMods timeMods = stageModifiers3._003CTimeMods_003Ek__BackingField;
		if (stageModifiers3._003CTimeMods_003Ek__BackingField != null)
		{
			bool flag8 = num4 < 0f;
			bool flag9 = !flag8;
			object obj4 = (_003F?)timeMods.Start & flag9;
			if (obj4 != null)
			{
				StageModifiers stageModifiers4 = _003CStageMods_003Ek__BackingField;
				if (stageModifiers4._003CTimeMods_003Ek__BackingField == null)
				{
					goto IL_05c4;
				}
				bool flag10 = (float)num5 < num4;
				float num7 = (float)num5 - num4;
				bool flag11 = num7 == 0f;
				bool flag12 = !flag10;
				bool flag13 = !flag11;
				object obj5 = flag13 & flag12;
				object obj6 = (object?)timeMods.Start & obj5;
				if (obj6 != null)
				{
					TimeMods timeMods2 = stageModifiers4._003CTimeMods_003Ek__BackingField;
					if ((object)timeMods2.HpPerMinute != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v33 (VampireSurvivors.App.Objects.TimeMods)+1C]");
						float num8 = 0f + _003CEnemyHealthMultiplier_003Ek__BackingField;
						_003CEnemyHealthMultiplier_003Ek__BackingField = num8;
					}
					TimeMods timeMods3 = stageModifiers4._003CTimeMods_003Ek__BackingField;
					if ((object)timeMods3.SpeedPerMinute != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v34 (VampireSurvivors.App.Objects.TimeMods)+24]");
						float num9 = 0f + _003CEnemySpeedMultiplier_003Ek__BackingField;
						_003CEnemySpeedMultiplier_003Ek__BackingField = num9;
					}
				}
			}
		}
		_hasAttachedTreasure = false;
		SpawnBoss();
		if (_arcanaManager.HasRandomazzoEnabled())
		{
			SpawnArcanaHolder();
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		if (config._003CSelectedRandomEvents_003Ek__BackingField && _trisection != null)
		{
			_trisection.TriggerTrisectionEvent();
		}
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager = core3._arcanaManager;
		if (arcanaManager._hasMoonlightBolero)
		{
			SpawnBatGoblin();
		}
		BackgroundManager fancyBg = _fancyBg;
		if ((object)_fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			_fancyBg.CheckMinute(minute);
		}
		return;
		IL_05c4:
		throw new NullReferenceException();
	}

	public void OnCycleComplete()
	{
		//IL_01e4: Expected O, but got I4
		StageModifiers stageModifiers = _003CStageMods_003Ek__BackingField;
		int num = (((object)stageModifiers._003CEndCycles_003Ek__BackingField != null) ? 1 : 0);
		stageModifiers._003CEndCycles_003Ek__BackingField = (float?)(object)num;
		float num2 = _003CEnemyHealthMultiplier_003Ek__BackingField + 1f;
		_currentMinute = 0;
		_003CEnemyHealthMultiplier_003Ek__BackingField = num2;
		bool stageDataForMinute = GetStageDataForMinute(0, _stageType, out var stageJsonObject);
		UpdateAllData(stageJsonObject);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				if (!config2._003CSelectedReapers_003Ek__BackingField)
				{
					return;
				}
				GameManager core3 = GM.Core;
				Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__255_0;
				if (_003C_003Ec._003C_003E9__255_0 == null)
				{
					predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__255_0 = delegate(Pickup x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj2 = x._003CPickupType_003Ek__BackingField - 29;
						return obj2 == null;
					});
				}
				int num3 = Enumerable.Count(core3._stagePickups, predicate);
				if (num3 <= 0)
				{
					SpawnMerchant();
					PickupMerchant trouserMerchant = TrouserMerchant;
					if ((object)TrouserMerchant == null || ((UnityEngine.Object)trouserMerchant).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					goto IL_01a9;
				}
				return;
			}
		}
		if (_stageType != StageType.TP_CASTLE)
		{
			return;
		}
		goto IL_01a9;
		IL_01a9:
		List<CharacterType> customMerchantCharacters = _playerOptions.GetCustomMerchantCharacters();
		SpawnCustomMerchants(customMerchantCharacters);
	}

	public void DebugNextMinute()
	{
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float num = 59f - core._003CSurvivedSeconds_003Ek__BackingField;
		if (!(1f > num))
		{
			GameManager core2 = GM.Core;
			float num2 = num + core2._003CSurvivedSeconds_003Ek__BackingField;
			core2._003CSurvivedSeconds_003Ek__BackingField = num2;
		}
	}

	public void DebugNextHalfMinute()
	{
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float num = 29f - core._003CSurvivedSeconds_003Ek__BackingField;
		if (!(1f > num))
		{
			GameManager core2 = GM.Core;
			float num2 = num + core2._003CSurvivedSeconds_003Ek__BackingField;
			core2._003CSurvivedSeconds_003Ek__BackingField = num2;
		}
	}

	public void DebugLastMinute()
	{
		StageData stageData = _stageData;
		StageModifiers stageModifiers = stageData._003Cmods_003Ek__BackingField;
		if ((object)stageModifiers._003CTimeLimit_003Ek__BackingField != null)
		{
			StageData stageData2 = _stageData;
			GameManager core = GM.Core;
			StageModifiers stageModifiers2 = stageData2._003Cmods_003Ek__BackingField;
			if ((object)stageModifiers2._003CTimeLimit_003Ek__BackingField != null)
			{
				object obj = default(object);
				float num = (float)obj - 1f;
				core._003CSurvivedSeconds_003Ek__BackingField = num;
			}
			else
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
		}
	}

	public void Cleanup()
	{
		//IL_0018: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_0374: Expected O, but got I4
		//IL_01f2: Expected I, but got O
		//IL_0464: Expected O, but got I4
		//IL_0472: Expected O, but got I4
		//IL_0499: Expected O, but got I4
		//IL_04a7: Expected O, but got I4
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0235: Expected O, but got I4
		//IL_078e: Expected I, but got O
		//IL_0099->IL068a: Incompatible stack heights: 1 vs 0
		//IL_00ed->IL068a: Incompatible stack heights: 2 vs 0
		//IL_01ab->IL068a: Incompatible stack heights: 2 vs 0
		//IL_01d2->IL068a: Incompatible stack heights: 2 vs 0
		//IL_0152->IL068a: Incompatible stack heights: 2 vs 0
		//IL_023e->IL0026: Incompatible stack heights: 2 vs 0
		//IL_0243->IL0243: Incompatible stack heights: 2 vs 0
		//IL_0419->IL0419: Incompatible stack heights: 1 vs 0
		UnloadAssets();
		List<EnemyController> spawnedEnemies = _spawnedEnemies;
		_003CHasInitialized_003Ek__BackingField = false;
		bool flag = (nint)_spawnedEnemies < 0;
		if (_spawnedEnemies != null)
		{
			List<EnemyController> list = (List<EnemyController>)(spawnedEnemies._size - 1);
			if (flag)
			{
				goto IL_0243;
			}
			Component component = default(Component);
			while (true)
			{
				List<EnemyController> spawnedEnemies2 = _spawnedEnemies;
				if (_spawnedEnemies == null)
				{
					break;
				}
				bool flag2 = (nint)list >= spawnedEnemies2._size;
				EnemyController[] items = spawnedEnemies2._items;
				if (spawnedEnemies2._items == null)
				{
					break;
				}
				bool flag3 = (nint)list >= items.Length;
				EnemyController enemyController = items[(object)list];
				if ((object)items[(object)list] == null)
				{
					break;
				}
				CoherenceSync coherenceSync = enemyController._coherenceSync;
				bool flag4;
				if ((object)enemyController._coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
				{
					if ((object)enemyController._coherenceSync == null)
					{
						break;
					}
					bool hasStateAuthority = enemyController._coherenceSync.HasStateAuthority;
					flag4 = (hasStateAuthority ? 1 : 0) < (false ? 1 : 0);
					if (!hasStateAuthority)
					{
						goto IL_021c;
					}
				}
				if (_spawnedEnemies == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if ((object)component == null)
				{
					break;
				}
				GameObject obj = component.gameObject;
				nint num = (nint)typeof(UnityEngine.Object);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v990 @ rcx_v114 (Il2CppClass<UnityEngine.Object>)+E4]");
				flag4 = (nint)0 < (nint)0;
				UnityEngine.Object.Destroy(obj);
				goto IL_021c;
				IL_021c:
				list = (List<EnemyController>)(list - 1);
				object obj2 = !flag4;
				if (obj2 != null)
				{
					continue;
				}
				goto IL_0243;
			}
		}
		goto IL_068a;
		IL_0243:
		List<EnemyController> spawnedEnemies3 = _spawnedEnemies;
		if (_spawnedEnemies != null)
		{
			int version = spawnedEnemies3._version + 1;
			spawnedEnemies3._version = version;
			spawnedEnemies3._size = 0;
			if (spawnedEnemies3._size > 0)
			{
				Array.Clear(spawnedEnemies3._items, 0, spawnedEnemies3._size);
				object obj3 = 0;
			}
			if ((object)_enemyFactory != null)
			{
				_enemyFactory.PurgePools();
				StageData stageData = new StageData();
				_stageData = stageData;
				object stageEventManager = _stageEventManager;
				if (_stageEventManager != null)
				{
					Action action = _stageEventManager.Cleanup;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v11 (System.Object)+20]");
					if ((nint)0 == 0)
					{
						goto IL_068a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA45A0");
					object obj3 = 0;
				}
				_stageEventManager = null;
				TilingTileset tilingTileset = _tilingTileset;
				if ((object)_tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
				{
					List<EnemyController> tilingTileset2 = (List<EnemyController>)(object)_tilingTileset;
					if ((object)_tilingTileset == null)
					{
						goto IL_068a;
					}
					bool flag5 = tilingTileset2._items == null;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)tilingTileset2._items);
					GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj4, 0f);
					_tilingTileset = null;
				}
				Timer spawnTimer = _spawnTimer;
				if (_spawnTimer != null && !_spawnTimer.IsDone)
				{
					float timeElapsed = _spawnTimer.GetTimeElapsed();
					spawnTimer._timeElapsedBeforeCancel = (float?)(object)1;
					spawnTimer._timeElapsedBeforePause = (float?)(object)0;
				}
				Timer checkPizzasTimer = _checkPizzasTimer;
				if (_checkPizzasTimer != null && !_checkPizzasTimer.IsDone)
				{
					float timeElapsed2 = _checkPizzasTimer.GetTimeElapsed();
					checkPizzasTimer._timeElapsedBeforeCancel = (float?)(object)1;
					checkPizzasTimer._timeElapsedBeforePause = (float?)(object)0;
				}
				SpeedupManager.ClearSpeedupManager();
				List<EnemyController> fancyBg = (List<EnemyController>)(object)_fancyBg;
				if ((object)_fancyBg != null && fancyBg._items != null)
				{
					if ((object)_fancyBg == null)
					{
						goto IL_068a;
					}
					_fancyBg.Cleanup();
				}
				TwitchIntegration sInstance = TwitchIntegration._sInstance;
				if (TwitchIntegration._sInstance != null)
				{
					string username = sInstance._username;
					if (sInstance._username == null || username._stringLength <= 0)
					{
						return;
					}
					if (MultiplayerManager.s_instance != null)
					{
						int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
						if (playerCount > 1 || MultiplayerManager.s_instance.IsOnlineMultiplayer)
						{
							return;
						}
						if (TwitchIntegration._sInstance != null)
						{
							IRC twitchClient = TwitchIntegration._sInstance.TwitchClient;
							if ((object)twitchClient == null || ((UnityEngine.Object)twitchClient).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							IRC twitchClient2 = TwitchIntegration._sInstance.TwitchClient;
							if ((object)twitchClient2 != null)
							{
								if (twitchClient2.connection != null)
								{
									Lexone.UnityTwitchChat.TwitchConnection connection = twitchClient2.connection;
									if (!connection.disconnectCalled)
									{
										IEnumerator routine = twitchClient2.NonBlockingDisconnect();
										Coroutine coroutine = twitchClient2.StartCoroutine(routine);
									}
								}
								return;
							}
						}
					}
				}
			}
		}
		goto IL_068a;
		IL_068a:
		throw new NullReferenceException();
	}

	public void CancelSpawnTimer()
	{
		if (_spawnTimer != null)
		{
			_spawnTimer.Cancel();
		}
	}

	public Weapon AddStageHazardWeapon(WeaponType weaponType)
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData = core2._gameSessionData;
			if (core2._gameSessionData != null && core._weaponsFacade != null)
			{
				bool allowDuplicates = default(bool);
				Weapon weapon = core._weaponsFacade.AddHiddenWeapon(weaponType, gameSessionData._activeCharacter, removeFromStore: false, allowDuplicates);
				if ((object)weapon != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
				{
					((Equipment)weapon)._003CShowInRecap_003Ek__BackingField = false;
					if (_003CStageHazardWeapons_003Ek__BackingField == null)
					{
						goto IL_00fe;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BCD0");
				}
				return weapon;
			}
		}
		goto IL_00fe;
		IL_00fe:
		return (Weapon)(object)new NullReferenceException();
	}

	public GameObject SpawnEnemy(EnemyType enemyType, Vector2 spawnPos, bool asRemote = false, bool forceSpawn = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		Component component = default(Component);
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			return component.gameObject;
		}
		return null;
	}

	public GameObject SpawnEnemyInOuterRect(EnemyType enemyType, bool checkWalls = false, bool forceSpawn = false)
	{
		GameObject gameObject = SpawnOneUnitInOuterRect(enemyType, checkWalls);
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			GameObject result = null;
			if (!flag)
			{
				result = gameObject;
			}
			return result;
		}
		return null;
	}

	public unsafe T SpawnEnemy<T>(EnemyType enemyType, Vector2 spawnPos, bool asRemote = false, bool forceSpawn = false) where T : EnemyController
	{
		//IL_0222: Expected O, but got Ref
		//IL_0222: Expected O, but got Ref
		//IL_0261: Expected I, but got O
		//IL_0292: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ stack_30+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		if (_dataManager == null)
		{
			goto IL_0488;
		}
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
		EnemyController result;
		if (convertedEnemyData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).FindEntry((System.Int32Enum)enemyType);
			if (num < 0)
			{
				goto IL_0488;
			}
			if ((object)_enemyFactory != null)
			{
				ObjectPool enemyPool = _enemyFactory.GetEnemyPool(enemyType);
				if ((object)GM.Core != null)
				{
					object obj = default(object);
					if (!GM.Core.IsStageHost)
					{
						if ((object)enemyPool == null || (object)enemyPool._template == null)
						{
							goto IL_0492;
						}
						CoherenceSync component = enemyPool._template.GetComponent<CoherenceSync>();
						if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && !asRemote && (nint)obj == (asRemote ? 1 : 0))
						{
							return null;
						}
					}
					if ((object)enemyPool != null)
					{
						object obj3 = default(object);
						object obj4 = default(object);
						GameObject obj2 = enemyPool.GetObject((Vector3)(&obj3), (Quaternion)(&obj4));
						EnemyController objectComponent = enemyPool.GetObjectComponent<EnemyController>(obj2);
						if ((object)objectComponent != null)
						{
							nint num2 = (nint)objectComponent;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r10_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+330]");
							bool flag = false;
							objectComponent.InitEnemy(enemyType, asRemote);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ stack_30+38]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							GameManager gameManager = _gameManager;
							if ((object)_gameManager != null)
							{
								bool flag2 = !gameManager._003CIsTimeStopped_003Ek__BackingField;
								bool flag3 = asRemote;
								EnemyController enemyController = default(EnemyController);
								if (!flag2)
								{
									if ((object)enemyController == null)
									{
										goto IL_0492;
									}
									enemyController.TimeStop(gameManager._003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField);
									flag3 = false;
								}
								GameManager gameManager2 = _gameManager;
								if ((object)_gameManager != null)
								{
									bool flag4 = !gameManager2._003CIsAllDefanged_003Ek__BackingField;
									float num4 = default(float);
									float num3 = num4;
									uint num5 = (flag3 ? 1u : 0u);
									if (!flag4)
									{
										if ((object)enemyController == null)
										{
											goto IL_0492;
										}
										bool flag5 = enemyController.DoDefang();
										flag = false;
										num3 = -1f;
										num5 = 4521864u;
									}
									if (_spawnedEnemies != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
										bool flag6 = obj == null;
										result = enemyController;
										if (!flag6)
										{
											result = enemyController;
											if (!asRemote)
											{
												if (_authoritativePermanentEnemies == null)
												{
													goto IL_0492;
												}
												bool flag7 = ((HashSet<object>)(object)_authoritativePermanentEnemies).AddIfNotPresent((object)enemyController);
												result = enemyController;
											}
										}
										goto IL_04cc;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0492;
		IL_04cc:
		return (T)result;
		IL_0488:
		result = null;
		goto IL_04cc;
		IL_0492:
		return (T)(object)new NullReferenceException();
	}

	public void DebugSpawnMaxEnemies()
	{
		StageData stageData = _stageData;
		_maximum = 500;
		stageData._003Cminimum_003Ek__BackingField = 500;
		SwarmCheck();
	}

	public void DebugSpawnAllEnemies()
	{
		List<EnemyType?> list = new List<EnemyType?>();
		List<EnemyType?> list2 = new List<EnemyType?>();
		list2._002Ector();
		bool flag = _maxStageDataMinute <= 0;
		List<EnemyType?> bosses = list2;
		List<EnemyType?> enemies = list;
		int num = 0;
		List<EnemyType?> list3 = list2;
		List<EnemyType?> list4 = list;
		if (!flag)
		{
			List<EnemyType?> list5 = default(List<EnemyType?>);
			List<EnemyType?> list6 = default(List<EnemyType?>);
			bool flag2;
			do
			{
				bool stageDataForMinute = GetStageDataForMinute(num, _stageType, out var stageJsonObject);
				object obj = stageJsonObject.ToObject<object>();
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3DC0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3F40");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3DC0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3F40");
					list3 = list5;
					list4 = list6;
				}
				num++;
				flag2 = num < _maxStageDataMinute;
				bosses = list3;
				enemies = list4;
			}
			while (flag2);
		}
		UpdateEnemyPools(enemies, bosses);
		StageData stageData = _stageData;
		_maximum = 500;
		stageData._003Cminimum_003Ek__BackingField = 500;
		SpawnBoss();
		SwarmCheck();
	}

	public void CalculateEnemySpeed()
	{
		StageModifiers stageModifiers = _003CStageMods_003Ek__BackingField;
		bool flag = (object)stageModifiers._003CEnemySpeed_003Ek__BackingField == null;
		float num = 1f;
		if (!flag)
		{
			if ((object)stageModifiers._003CEnemySpeed_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			float num2 = default(float);
			num = num2;
		}
		float num3 = GM.Core.AveragePlayerCurse();
		float num4 = num * 0.231f;
		float num5 = num4 * num3;
		float enemySpeed = num5 * _003CEnemySpeedMultiplier_003Ek__BackingField;
		GameManager.EnemySpeed = enemySpeed;
	}

	public void RecalculateCurseAndCharm()
	{
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected I4, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected I4, but got Unknown
		BackgroundManager fancyBg = _fancyBg;
		bool flag = (object)_fancyBg == null;
		float num = 1f;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
			num = 1f;
			if (!flag2)
			{
				BackgroundManager fancyBg2 = _fancyBg;
				num = fancyBg2.CurseMod;
			}
		}
		float num2 = GM.Core.AveragePlayerCurse();
		StageModifiers stageModifiers = _003CStageMods_003Ek__BackingField;
		if ((object)stageModifiers._003CEndCycles_003Ek__BackingField != null)
		{
			object obj = default(object);
			float num3 = (float)obj * 0.5f;
			float num4 = num3 + num2;
			float num5 = GM.Core.AveragePlayerCurse();
			StageModifiers stageModifiers2 = _003CStageMods_003Ek__BackingField;
			if ((object)stageModifiers2._003CEndCycles_003Ek__BackingField != null)
			{
				float num6 = (float)obj + num5;
				float minMultiplier = num6 * num;
				_minMultiplier = minMultiplier;
				CalculateEnemySpeed();
				StageData stageData = _stageData;
				float num7 = num4 * num;
				bool flag3 = !(0.1f < num7);
				float num8 = 0.1f;
				if (!flag3)
				{
					num8 = num7;
				}
				float effectiveSpawnFrequency = stageData._003Cfrequency_003Ek__BackingField / num8;
				_effectiveSpawnFrequency = effectiveSpawnFrequency;
				BackgroundManager fancyBg3 = _fancyBg;
				bool flag4 = (object)_fancyBg == null;
				float num9 = 1f;
				if (!flag4)
				{
					bool flag5 = ((UnityEngine.Object)fancyBg3).m_CachedPtr == (IntPtr)0;
					num9 = 1f;
					if (!flag5)
					{
						BackgroundManager fancyBg4 = _fancyBg;
						num9 = fancyBg4.CharmMod;
					}
				}
				GameManager core = GM.Core;
				GameSessionData gameSessionData = core._gameSessionData;
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				PlayerModifierStats playerStats = activeCharacter._playerStats;
				float num10 = (float)playerStats._003CCharm_003Ek__BackingField * num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				StageData stageData2 = _stageData;
				object obj2 = default(object);
				int num11 = stageData2._003Cminimum_003Ek__BackingField + obj2;
				stageData2._003Cminimum_003Ek__BackingField = num11;
				int maximum = obj2 + _defaultMaximum;
				_maximum = maximum;
				return;
			}
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	public void ResetStageMinimumSpawnToDefault()
	{
		if (GetStageDataForMinute(0, _stageType, out var stageJsonObject))
		{
			object obj = stageJsonObject.ToObject<object>();
			StageData stageData = _stageData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v10 (System.Object)+140]");
			stageData._003Cminimum_003Ek__BackingField = 0;
		}
	}

	public void ResetStageMaximumSpawnToDefault()
	{
		_maximum = _defaultMaximum;
	}

	public void SetSpawnType(SpawnType type)
	{
		_spawnType = type;
	}

	public void SetWallsCheckDestructibleAndEnemiesLogic(bool value)
	{
		_hasWallsCheckDestructibleLogic = value;
		_hasTileSet = value;
	}

	public void StartTimers()
	{
		if (_spawnTimer != null)
		{
			_spawnTimer.Cancel();
		}
		Action onComplete = delegate
		{
			HandleSpawning();
		};
		float duration = _effectiveSpawnFrequency * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer spawnTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_spawnTimer = spawnTimer;
		if (_destructibleTimer != null)
		{
			_destructibleTimer.Cancel();
		}
		StageData stageData = _stageData;
		Action onComplete2 = HandleDestructibleSpawning;
		float duration2 = stageData._003CdestructibleFreq_003Ek__BackingField * 0.001f;
		Timer destructibleTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_destructibleTimer = destructibleTimer;
	}

	public void CancelTimers()
	{
		if (_spawnTimer != null)
		{
			_spawnTimer.Cancel();
		}
		if (_destructibleTimer != null)
		{
			_destructibleTimer.Cancel();
		}
	}

	public unsafe EnemyController ClosestAlive(Vector3 queryPos, float maxRange = 3.4028235E+38f)
	{
		//IL_0013: Expected O, but got Ref
		object obj = default(object);
		return FindClosestEnemy((Vector3)(&obj), excludeDead: true, maxRange);
	}

	public EnemyController FindClosestEnemy(Vector3 queryPos, bool excludeDead = false, float maxRange = 3.4028235E+38f)
	{
		if (_spawnedEnemies != null)
		{
			List<EnemyController> spawnedEnemies = _spawnedEnemies;
			if (spawnedEnemies._size != 0)
			{
				float num = maxRange * maxRange;
				if (!(3.4028235E+38f > num))
				{
					num = 3.4028235E+38f;
				}
				EnemyController result;
				if (excludeDead)
				{
					result = null;
					List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
					while (enumerator.MoveNext())
					{
						EnemyController enemyController = null;
					}
				}
				else
				{
					if (_spawnedEnemies == null)
					{
						return (EnemyController)(object)new NullReferenceException();
					}
					result = null;
					List<EnemyController>.Enumerator enumerator2 = default(List<EnemyController>.Enumerator);
					while (enumerator2.MoveNext())
					{
						EnemyController enemyController2 = null;
					}
				}
				return result;
			}
		}
		return null;
	}

	public EnemyController FindClosestLateralEnemy(Vector3 queryPos, bool excludeDead = false, float maxRange = 3.4028235E+38f, bool checkLeft = true)
	{
		if (_spawnedEnemies != null)
		{
			List<EnemyController> spawnedEnemies = _spawnedEnemies;
			if (spawnedEnemies._size != 0)
			{
				float num = maxRange * maxRange;
				if (!(3.4028235E+38f > num))
				{
					num = 3.4028235E+38f;
				}
				EnemyController result;
				if (excludeDead)
				{
					result = null;
					List<EnemyController>.Enumerator enumerator = (List<EnemyController>.Enumerator)spawnedEnemies;
					List<EnemyController>.Enumerator enumerator2 = default(List<EnemyController>.Enumerator);
					while (enumerator2.MoveNext())
					{
						EnemyController enemyController = null;
					}
				}
				else
				{
					if (_spawnedEnemies == null)
					{
						return (EnemyController)(object)new NullReferenceException();
					}
					result = null;
					List<EnemyController>.Enumerator spawnedEnemies2 = (List<EnemyController>.Enumerator)_spawnedEnemies;
					List<EnemyController>.Enumerator enumerator3 = default(List<EnemyController>.Enumerator);
					while (enumerator3.MoveNext())
					{
						EnemyController enemyController2 = null;
					}
				}
				return result;
			}
		}
		return null;
	}

	public List<EnemyController> GetClosestEnemiesSorted(Vector3 queryPos, bool excludeDead = false, float maxRange = 3.4028235E+38f)
	{
		//IL_0214: Expected F4, but got I4
		//IL_00b8: Expected F4, but got I4
		if (_spawnedEnemies != null)
		{
			List<EnemyController> spawnedEnemies = _spawnedEnemies;
			if (spawnedEnemies._size != 0)
			{
				List<EnemyController> source = new List<EnemyController>();
				float num = maxRange * maxRange;
				if (!(3.4028235E+38f > num))
				{
					num = 3.4028235E+38f;
				}
				bool flag = default(bool);
				if (flag)
				{
					if (_spawnedEnemies == null)
					{
						goto IL_0417;
					}
					List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
					while (enumerator.MoveNext())
					{
						float num2 = 0f;
					}
				}
				else
				{
					if (_spawnedEnemies == null)
					{
						goto IL_0417;
					}
					List<EnemyController>.Enumerator enumerator2 = default(List<EnemyController>.Enumerator);
					while (enumerator2.MoveNext())
					{
						float num3 = 0f;
					}
				}
				Func<object, float> keySelector = (Func<object, float>)_003C_003Ec._003C_003E9__280_0;
				if (_003C_003Ec._003C_003E9__280_0 == null)
				{
					keySelector = (Func<object, float>)(_003C_003Ec._003C_003E9__280_0 = (Func<object, float>)((EnemyController x) => x.Distance));
				}
				IOrderedEnumerable<object> orderedEnumerable = Enumerable.OrderBy(source, keySelector);
				if (orderedEnumerable != null)
				{
					return (List<EnemyController>)(object)new List<object>(orderedEnumerable);
				}
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
		}
		return _spawnedEnemies;
		IL_0417:
		return (List<EnemyController>)(object)new NullReferenceException();
	}

	public EnemyController PickRandomEnemyController(ref Unity.Mathematics.Random rng)
	{
		if (_spawnedEnemies != null)
		{
			List<EnemyController> spawnedEnemies = _spawnedEnemies;
			if (spawnedEnemies._size > 0)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._multiplayer != null)
				{
					if (core._multiplayer.IsOnlineMultiplayer)
					{
						return VampireSurvivors.App.Tools.Extensions.PickRnd(_spawnedEnemies);
					}
					return PickRandomEnemyFromList(_spawnedEnemies, ref rng);
				}
				return (EnemyController)(object)new NullReferenceException();
			}
		}
		return null;
	}

	public Transform PickRandomEnemy(ref Unity.Mathematics.Random rng)
	{
		if (_spawnedEnemies != null)
		{
			List<EnemyController> spawnedEnemies = _spawnedEnemies;
			if (spawnedEnemies._size > 0)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._multiplayer != null)
				{
					bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
					bool flag = !isOnlineMultiplayer;
					Stage stage = this;
					ref Unity.Mathematics.Random rng2 = ref rng;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 97 Invalid \"Jump target not found in method: 0x186E4F530\"");
						Stage stage2 = default(Stage);
						stage = stage2;
						ref Unity.Mathematics.Random reference = default(ref Unity.Mathematics.Random);
						rng2 = ref reference;
					}
					EnemyController enemyController = PickRandomEnemyFromList(stage._spawnedEnemies, ref rng2);
					if ((object)enemyController != null && (object)enemyController._EnemyRenderer != null)
					{
						return enemyController._EnemyRenderer.transform;
					}
				}
				return (Transform)(object)new NullReferenceException();
			}
		}
		return _cachedTransform;
	}

	public Transform PickRandomEnemyInScreenBounds(ref Unity.Mathematics.Random rng)
	{
		object obj = default(object);
		float x = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Center - (float)obj;
		float num = (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v3 (UnityEngine.Bounds)+10]");
		float y = num - 0f;
		float width = (float)obj * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v3 (UnityEngine.Bounds)+10]");
		float height = 0f * 2f;
		Rectangle rectangle = new Rectangle();
		rectangle._x = x;
		rectangle._y = y;
		rectangle._width = width;
		rectangle._height = height;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 87 Invalid \"Jump target not found in method: 0x186E4F650\"");
		return (Transform)(object)rectangle;
	}

	public Transform PickRandomEnemyInRectBounds(Rectangle _rect, ref Unity.Mathematics.Random rng)
	{
		//IL_00b7: Expected O, but got I
		//IL_0102: Expected O, but got I4
		//IL_071d: Expected O, but got I
		//IL_0551: Expected O, but got I
		//IL_056a: Expected O, but got I4
		//IL_0682: Expected O, but got I
		//IL_03fa: Expected O, but got I
		//IL_0403: Expected O, but got I4
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0322: Expected O, but got I4
		//IL_066d->IL0592: Incompatible stack heights: 5 vs 0
		//IL_03bf->IL0592: Incompatible stack heights: 5 vs 0
		//IL_06bf->IL0708: Incompatible stack heights: 8 vs 0
		//IL_0592->IL0592: Incompatible stack heights: 9 vs 0
		//IL_0410->IL06a3: Incompatible stack heights: 7 vs 8
		//IL_032b->IL0630: Incompatible stack heights: 7 vs 4
		//IL_0330->IL0330: Incompatible stack heights: 7 vs 4
		//IL_04e4->IL0708: Incompatible stack heights: 6 vs 0
		//IL_02e3->IL0309: Incompatible stack heights: 8 vs 7
		//IL_0309->IL0309: Incompatible stack heights: 8 vs 7
		if (_rect != null)
		{
			bool flag = (object)GM.Core == null;
			bool flag2 = (object)ArcadePhysics.s_instance == null;
			float height = default(float);
			bool includeDynamic = default(bool);
			bool includeStatic = default(bool);
			Group specificGroup = default(Group);
			List<BaseBody> list = ArcadePhysics.s_instance.OverlapRect(_rect._x, _rect._y, _rect._width, height, includeDynamic, includeStatic, specificGroup);
			SortedList<uint, EnemyController> queryEnemiesCache = _queryEnemiesCache;
			bool flag3 = _queryEnemiesCache == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rbx_v6 (System.Collections.Generic.SortedList`2<System.UInt32, VampireSurvivors.Objects.Characters.EnemyController>)+24]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rbx_v6 (System.Collections.Generic.SortedList`2<System.UInt32, VampireSurvivors.Objects.Characters.EnemyController>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rbx_v6 (System.Collections.Generic.SortedList`2<System.UInt32, VampireSurvivors.Objects.Characters.EnemyController>)+20]");
			Array.Clear((Array)num, 0, 0);
			_ = 0;
			SortedList<uint, object> queryEnemiesCache2 = (SortedList<uint, object>)(object)_queryEnemiesCache;
			bool flag4 = (nint)list < 0;
			bool flag5 = list == null;
			object obj = list._size - 1;
			if (!flag4)
			{
				object obj3;
				do
				{
					bool flag6 = (nint)obj >= list._size;
					BaseBody[] items = list._items;
					bool flag7 = list._items == null;
					bool flag8 = (nint)obj >= items.Length;
					BaseBody baseBody = items[obj];
					bool flag9 = items[obj] == null;
					Component component = (Component)(object)items[obj];
					if (!flag9)
					{
						component = baseBody._gameObject;
					}
					object obj2;
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						EnemyController component2 = component.GetComponent<EnemyController>();
						obj2 = component2;
					}
					else
					{
						obj2 = null;
					}
					bool flag10 = (nint)obj2 < 0;
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v13 (System.Object)+10]");
						flag10 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v13 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v13 (System.Object)+260]");
							flag10 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v13 (System.Object)+260]");
							if ((nint)0 == 0)
							{
								bool flag11 = _queryEnemiesCache == null;
								SortedList<uint, EnemyController> queryEnemiesCache3 = _queryEnemiesCache;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v13 (System.Object)+E0]");
								bool flag12 = ((SortedList<uint, object>)(object)queryEnemiesCache3).ContainsKey(0u);
								flag10 = (flag12 ? 1 : 0) < (false ? 1 : 0);
								if (!flag12)
								{
									SortedList<uint, EnemyController> queryEnemiesCache4 = _queryEnemiesCache;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v13 (System.Object)+E0]");
									((SortedList<uint, object>)(object)queryEnemiesCache4).Add(0u, obj2);
								}
							}
						}
					}
					obj--;
					obj3 = !flag10;
				}
				while (obj3 != null);
			}
			bool flag13 = _queryEnemiesCache == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rsi_v5 (System.Collections.Generic.SortedList`2<System.UInt32, System.Object>)+20]");
			if ((nint)0 <= (nint)0)
			{
				IList<EnemyController> spawnedEnemies = _spawnedEnemies;
				EnemyController enemyController = PickRandomEnemyFromList(_spawnedEnemies, ref rng);
				if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0592;
				}
				object enemyRenderer = enemyController._EnemyRenderer;
				bool flag14 = (object)enemyController._EnemyRenderer == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rbx_v25 (System.Object)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rbx_v25 (System.Object)+10]");
				bool flag15 = (nint)0 == 0;
				object obj5 = 0;
				object obj6 = 0;
				ref Unity.Mathematics.Random reference = ref rng;
			}
			else
			{
				IList<EnemyController> valueListHelper = _queryEnemiesCache.GetValueListHelper();
				EnemyController enemyController2 = PickRandomEnemyFromList(valueListHelper, ref rng);
				if ((object)enemyController2 != null && ((UnityEngine.Object)enemyController2).m_CachedPtr != (IntPtr)0)
				{
					SpriteRenderer enemyRenderer2 = enemyController2._EnemyRenderer;
					if ((object)enemyController2._EnemyRenderer != null && ((UnityEngine.Object)enemyRenderer2).m_CachedPtr != (IntPtr)0)
					{
						bool flag16 = (object)enemyController2._EnemyRenderer == null;
						return enemyController2._EnemyRenderer.transform;
					}
				}
				IList<EnemyController> spawnedEnemies = _spawnedEnemies;
				EnemyController enemyController3 = PickRandomEnemyFromList(_spawnedEnemies, ref rng);
				bool flag17 = (object)enemyController3 == null;
				object enemyRenderer3 = enemyController3._EnemyRenderer;
				bool flag18 = (object)enemyController3._EnemyRenderer == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rbx_v23 (System.Object)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rbx_v23 (System.Object)+10]");
				bool flag19 = (nint)0 == 0;
				object obj5 = 0;
				bool flag20 = (nint)0 != 0;
				object obj6 = 0;
				ref Unity.Mathematics.Random reference = ref rng;
				if (!flag20)
				{
					bool flag21 = (nint)0 == 0;
					goto IL_0592;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1206 @ rax_v54 (should have been resolved before IL gen)");
			IntPtr gcHandlePtr = default(IntPtr);
			return UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		}
		goto IL_0592;
		IL_0592:
		return null;
	}

	public void GetEnemyBodiesInRect(Rectangle _rect, ref List<BaseBody> list)
	{
		//IL_00ec: Expected O, but got I4
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027e: Expected O, but got I4
		if (_rect == null)
		{
			return;
		}
		List<BaseBody> list2 = list;
		int version = list2._version + 1;
		list2._version = version;
		list2._size = 0;
		if (list2._size > 0)
		{
			Array.Clear(list2._items, 0, list2._size);
		}
		float height = default(float);
		bool includeDynamic = default(bool);
		bool includeStatic = default(bool);
		Group specificGroup = default(Group);
		List<BaseBody> list3 = ArcadePhysics.s_instance.OverlapRect(_rect._x, _rect._y, _rect._width, height, includeDynamic, includeStatic, specificGroup);
		bool flag = (nint)list3 < 0;
		object obj = list3._size - 1;
		if (flag)
		{
			return;
		}
		while ((nint)obj < list3._size)
		{
			BaseBody[] items = list3._items;
			BaseBody baseBody = items[obj];
			Component component = ((items[obj] == null) ? null : baseBody._gameObject);
			EnemyController enemyController;
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				EnemyController component2 = component.GetComponent<EnemyController>();
				enemyController = component2;
			}
			else
			{
				enemyController = null;
			}
			bool flag2 = (nint)enemyController < 0;
			if ((object)enemyController != null)
			{
				flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
				if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
				{
					flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
					if (!enemyController._003CIsDead_003Ek__BackingField)
					{
						flag2 = (nint)list < 0;
						list.Add(items[obj]);
					}
				}
			}
			obj--;
			object obj2 = !flag2;
			if (obj2 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe EnemyController PickRandomEnemyFromList(IList<EnemyController> enemiesList, ref Unity.Mathematics.Random rng)
	{
		//IL_00b9: Expected I4, but got O
		if (enemiesList != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj2 = (object)rng << 13;
				object obj3 = obj2 ^ (object)rng;
				object obj4 = obj3 >> 17;
				object obj5 = obj3 ^ obj4;
				object obj6 = obj5 << 5;
				object obj7 = obj6 ^ obj5;
				ref Unity.Mathematics.Random reference = ref *(Unity.Mathematics.Random*)obj7;
				object obj9 = default(object);
				object obj8 = (object)rng * obj9;
				int index = obj8 >> 32;
				return enemiesList.get_Item(index);
			}
			return null;
		}
		return (EnemyController)(object)new NullReferenceException();
	}

	public unsafe Transform PickRandomEnemyInCircle(float2 position, float radius, ref Unity.Mathematics.Random rng)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		List<EnemyController> enemiesInCircle = GetEnemiesInCircle(position, radius);
		object obj = (object)rng << 13;
		object obj2 = obj ^ (object)rng;
		object obj3 = obj2 >> 17;
		object obj4 = obj2 ^ obj3;
		object obj5 = obj4 << 5;
		object obj6 = obj5 ^ obj4;
		ref Unity.Mathematics.Random reference = ref *(Unity.Mathematics.Random*)obj6;
		if (enemiesInCircle._size > 0)
		{
			object obj7 = rng * enemiesInCircle._size;
			object obj8 = obj7 >> 32;
			if ((nint)obj8 < enemiesInCircle._size)
			{
				EnemyController[] items = enemiesInCircle._items;
				EnemyController enemyController = items[obj8];
				return enemyController._EnemyRenderer.transform;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			Transform result = default(Transform);
			return result;
		}
		return null;
	}

	public List<EnemyController> GetEnemiesInCircle(float2 position, float radius)
	{
		//IL_0027: Expected F4, but got O
		//IL_00d6: Expected O, but got I4
		//IL_0197: Expected I4, but got O
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0272: Expected O, but got I4
		float y = default(float);
		bool includeDynamic = default(bool);
		bool includeStatic = default(bool);
		Group specificGroup = default(Group);
		List<BaseBody> list = ArcadePhysics.s_instance.OverlapCirc((float)position, y, radius, includeDynamic, includeStatic, specificGroup);
		List<EnemyController> unsortedEnemiesCache = _unsortedEnemiesCache;
		int version = unsortedEnemiesCache._version + 1;
		unsortedEnemiesCache._version = version;
		unsortedEnemiesCache._size = 0;
		if (unsortedEnemiesCache._size > 0)
		{
			Array.Clear(unsortedEnemiesCache._items, 0, unsortedEnemiesCache._size);
		}
		bool flag = (nint)list < 0;
		object obj = list._size - 1;
		if (!flag)
		{
			object obj2;
			List<EnemyController> result = default(List<EnemyController>);
			do
			{
				if ((nint)obj < list._size)
				{
					BaseBody[] items = list._items;
					BaseBody baseBody = items[obj];
					bool flag2 = items[obj] == null;
					Component component = (Component)(object)items[obj];
					if (!flag2)
					{
						component = baseBody._gameObject;
					}
					int num;
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						EnemyController component2 = component.GetComponent<EnemyController>();
						num = (int)component2;
					}
					else
					{
						num = 0;
					}
					bool flag3 = num < 0;
					if (num != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rbx_v8 (System.Int32)+10]");
						flag3 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rbx_v8 (System.Int32)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rbx_v8 (System.Int32)+260]");
							flag3 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rbx_v8 (System.Int32)+260]");
							if ((nint)0 == 0)
							{
								flag3 = (nint)_unsortedEnemiesCache < 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
							}
						}
					}
					obj--;
					obj2 = !flag3;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (obj2 != null);
		}
		return _unsortedEnemiesCache;
	}

	public List<EnemyController> GetAllEnemiesInScreenBounds()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x186E50670\"");
		List<EnemyController> result = default(List<EnemyController>);
		return result;
	}

	public List<EnemyController> GetAllEnemiesInScreenBounds(float excludedBorderPercentage01)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_033d: Expected O, but got I4
		//IL_03fd: Expected I4, but got O
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_04d9: Expected O, but got I4
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		object obj = default(object);
		float num = (float)obj * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		object obj2 = (object)bounds.m_Center - obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (UnityEngine.Bounds)+10]");
		object obj3 = obj - 0;
		float num3 = num * excludedBorderPercentage01;
		float num4 = num2 * excludedBorderPercentage01;
		float num5 = num3 * 0.5f;
		float num6 = num4 * 0.5f;
		float num7 = (float)obj2 + num5;
		float num8 = (float)obj3 + num6;
		object obj4 = (object)bounds.m_Center + obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (UnityEngine.Bounds)+10]");
		object obj5 = obj + 0;
		float num9 = (float)obj4 - num7;
		float num10 = (float)obj5 - num8;
		float num11 = num9 * 0.5f;
		float num12 = num10 * 0.5f;
		float num13 = num8 + num12;
		float num14 = num11 + num7;
		float num15 = num14 + num11;
		float num16 = num13 + num12;
		float num17 = num * excludedBorderPercentage01;
		float num18 = num2 * excludedBorderPercentage01;
		float num19 = num17 * 0.5f;
		float num20 = num18 * 0.5f;
		float num21 = num15 - num19;
		float num22 = num16 - num20;
		float num23 = num14 - num11;
		float num24 = num13 - num12;
		float num25 = num21 - num23;
		float num26 = num22 - num24;
		float num27 = num25 * 0.5f;
		float num28 = num26 * 0.5f;
		float num29 = num23 + num27;
		float num30 = num24 + num28;
		float x = num29 - num27;
		float y = num30 - num28;
		float width = num27 + num27;
		float height = default(float);
		bool includeDynamic = default(bool);
		bool includeStatic = default(bool);
		Group specificGroup = default(Group);
		List<BaseBody> list = ArcadePhysics.s_instance.OverlapRect(x, y, width, height, includeDynamic, includeStatic, specificGroup);
		List<EnemyController> unsortedEnemiesCache = _unsortedEnemiesCache;
		int version = unsortedEnemiesCache._version + 1;
		unsortedEnemiesCache._version = version;
		unsortedEnemiesCache._size = 0;
		if (unsortedEnemiesCache._size > 0)
		{
			Array.Clear(unsortedEnemiesCache._items, 0, unsortedEnemiesCache._size);
		}
		bool flag = (nint)list < 0;
		object obj6 = list._size - 1;
		if (!flag)
		{
			object obj7;
			List<EnemyController> result = default(List<EnemyController>);
			do
			{
				if ((nint)obj6 < list._size)
				{
					BaseBody[] items = list._items;
					BaseBody baseBody = items[obj6];
					bool flag2 = items[obj6] == null;
					Component component = (Component)(object)items[obj6];
					if (!flag2)
					{
						component = baseBody._gameObject;
					}
					int num31;
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						EnemyController component2 = component.GetComponent<EnemyController>();
						num31 = (int)component2;
					}
					else
					{
						num31 = 0;
					}
					bool flag3 = num31 < 0;
					if (num31 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v8 (System.Int32)+10]");
						flag3 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v8 (System.Int32)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v8 (System.Int32)+260]");
							flag3 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v8 (System.Int32)+260]");
							if ((nint)0 == 0)
							{
								flag3 = (nint)_unsortedEnemiesCache < 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
							}
						}
					}
					obj6--;
					obj7 = !flag3;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (obj7 != null);
		}
		return _unsortedEnemiesCache;
	}

	public unsafe void DebugSpawnDestructibles(float percentage = 1f)
	{
		//IL_02d0: Expected O, but got F4
		//IL_02e9: Invalid comparison between F4 and I4
		//IL_01b4: Expected O, but got I4
		//IL_01bd: Expected O, but got I4
		//IL_01ce: Expected O, but got I4
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0217: Invalid comparison between F4 and O
		//IL_0226: Expected O, but got I4
		//IL_02c2->IL0249: Incompatible stack heights: 1 vs 0
		//IL_013e->IL0249: Incompatible stack heights: 1 vs 0
		//IL_017d->IL0249: Incompatible stack heights: 1 vs 0
		//IL_02fb->IL026f: Incompatible stack heights: 1 vs 0
		//IL_0374->IL0249: Incompatible stack heights: 1 vs 0
		//IL_0249->IL026f: Incompatible stack heights: 1 vs 0
		if (_stageData == null)
		{
			return;
		}
		StageData stageData = _stageData;
		string text = stageData._003CdestructibleType_003Ek__BackingField;
		if (stageData._003CdestructibleType_003Ek__BackingField == null || text._stringLength <= 0)
		{
			return;
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						GizmoManager gizmoManager = core2._gizmoManager;
						if (core2._gizmoManager != null)
						{
							float y = default(float);
							core2._gizmoManager.ShowHighlightAt(ret, y);
							StageData stageData2 = _stageData;
							if (_stageData != null)
							{
								float num = (float)stageData2._003CmaxDestructibles_003Ek__BackingField * percentage;
								float num2 = (float)Math.PI * 2f / num;
								object obj = UnityEngine.Random.value;
								object obj2 = default(object);
								float num3 = (float)obj2 * (float)Math.PI;
								if (!(num > 0f))
								{
									return;
								}
								object obj3 = 0;
								object obj4 = 0;
								PropType propType = (PropType)(int)(&ret);
								object obj5 = 0;
								Vector2 pos = default(Vector2);
								while (true)
								{
									float num4 = (float)obj5 * num2;
									float num5 = num4 + num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
									float num6 = (float)obj5 * num2;
									float num7 = num6 + num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
									StageData stageData3 = _stageData;
									if (_stageData == null)
									{
										break;
									}
									PropType propType2 = Enum.Parse<PropType>(stageData3._003CdestructibleType_003Ek__BackingField);
									Destructible destructible = MakeDestructible(propType2, pos);
									obj3++;
									bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
									obj4 = 0;
									propType = propType2;
									gizmoManager = (GizmoManager)(object)this;
									obj5 = obj3;
									if (!flag2)
									{
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe Destructible MakeDestructible(PropType destructibleType, Vector2 pos)
	{
		//IL_0103: Expected O, but got Ref
		//IL_0103: Expected O, but got Ref
		Destructible destructible;
		if ((object)_destructibleFactory != null)
		{
			ObjectPool pool = _destructibleFactory.GetPool(destructibleType);
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					if ((object)pool == null || (object)pool._template == null)
					{
						goto IL_0156;
					}
					CoherenceSync component = pool._template.GetComponent<CoherenceSync>();
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						destructible = null;
						goto IL_01c2;
					}
				}
				if ((object)pool != null)
				{
					object obj2 = default(object);
					object obj3 = default(object);
					GameObject obj = pool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
					destructible = pool.GetObjectComponent<Destructible>(obj);
					if ((object)destructible != null)
					{
						destructible.Init(destructibleType);
						DespawnFarDestructibles(pool);
						goto IL_01c2;
					}
				}
			}
		}
		goto IL_0156;
		IL_0156:
		return (Destructible)(object)new NullReferenceException();
		IL_01c2:
		return destructible;
	}

	public unsafe List<Destructible> GetAllDestructiblesInScreenBounds()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<Destructible> list = DestructibleManager.AllActiveDestructibles();
		List<Destructible> result = new List<Destructible>();
		List<Destructible>.Enumerator enumerator = default(List<Destructible>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Destructible>.Enumerator enumerator2 = (List<Destructible>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe List<Pickup> GetAllPickupsInScreenBounds()
	{
		//IL_019f: Expected O, but got I4
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_013c: Expected O, but got I
		//IL_0189: Expected O, but got I4
		//IL_02b1->IL02b6: Incompatible stack heights: 3 vs 0
		//IL_01ce->IL02b6: Incompatible stack heights: 4 vs 0
		List<Pickup> onScreenPickupsCache = _onScreenPickupsCache;
		int version = onScreenPickupsCache._version + 1;
		onScreenPickupsCache._version = version;
		onScreenPickupsCache._size = 0;
		if (onScreenPickupsCache._size > 0)
		{
			Array.Clear(onScreenPickupsCache._items, 0, onScreenPickupsCache._size);
		}
		object obj = null;
		List<Pickup>.Enumerator pickupItems = (List<Pickup>.Enumerator)PickupManager.PickupItems;
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		object obj4 = default(object);
		while (enumerator.MoveNext())
		{
			object obj2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r14_v10 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r14_v10 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			object obj3 = ret;
			Rect containmentScreenRect = _containmentScreenRect;
			bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect);
			obj = ret;
			object obj6;
			if (!flag4)
			{
				Rect containmentScreenRect2 = _containmentScreenRect;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+138]");
				pickupItems = (List<Pickup>.Enumerator)(containmentScreenRect2 + 0);
				bool flag5 = System.Runtime.CompilerServices.Unsafe.As<List<Pickup>.Enumerator, UIntPtr>(ref pickupItems) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref ret);
				obj = ret;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+134]");
					bool flag6 = (nint)obj4 < 0;
					obj = obj4;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+134]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+13C]");
						pickupItems = (List<Pickup>.Enumerator)(num + 0);
						bool flag7 = System.Runtime.CompilerServices.Unsafe.As<List<Pickup>.Enumerator, UIntPtr>(ref pickupItems) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
						object obj5 = (object)pickupItems - obj4;
						bool flag8 = obj5 == null;
						bool flag9 = !flag7;
						bool flag10 = !flag8;
						obj6 = flag10 & flag9;
						obj = obj4;
						goto IL_0299;
					}
				}
			}
			obj6 = 0;
			goto IL_0299;
			IL_0299:
			if (obj6 != null)
			{
				bool flag11 = _onScreenPickupsCache == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
			}
		}
		return _onScreenPickupsCache;
	}

	public unsafe List<Pickup> GetAllGemsInScreenBounds()
	{
		//IL_01a8: Expected O, but got I4
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_0145: Expected O, but got I
		//IL_0192: Expected O, but got I4
		//IL_02b5->IL02ba: Incompatible stack heights: 3 vs 0
		//IL_01d7->IL02ba: Incompatible stack heights: 4 vs 0
		List<Pickup> onScreenPickupsCache = _onScreenPickupsCache;
		int version = onScreenPickupsCache._version + 1;
		onScreenPickupsCache._version = version;
		onScreenPickupsCache._size = 0;
		if (onScreenPickupsCache._size > 0)
		{
			Array.Clear(onScreenPickupsCache._items, 0, onScreenPickupsCache._size);
		}
		GameManager gameManager = _gameManager;
		object obj = null;
		HashSet<object>.Enumerator gems = (HashSet<object>.Enumerator)gameManager._gems;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		object obj4 = default(object);
		while (enumerator.MoveNext())
		{
			object obj2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v10 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v10 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			object obj3 = ret;
			Rect containmentScreenRect = _containmentScreenRect;
			bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect);
			obj = ret;
			object obj6;
			if (!flag4)
			{
				Rect containmentScreenRect2 = _containmentScreenRect;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+138]");
				gems = (HashSet<object>.Enumerator)(containmentScreenRect2 + 0);
				bool flag5 = System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref gems) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref ret);
				obj = ret;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+134]");
					bool flag6 = (nint)obj4 < 0;
					obj = obj4;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+134]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+13C]");
						gems = (HashSet<object>.Enumerator)(num + 0);
						bool flag7 = System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref gems) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
						object obj5 = (object)gems - obj4;
						bool flag8 = obj5 == null;
						bool flag9 = !flag7;
						bool flag10 = !flag8;
						obj6 = flag10 & flag9;
						obj = obj4;
						goto IL_029d;
					}
				}
			}
			obj6 = 0;
			goto IL_029d;
			IL_029d:
			if (obj6 != null)
			{
				bool flag11 = _onScreenPickupsCache == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
			}
		}
		return _onScreenPickupsCache;
	}

	public unsafe List<Pickup> GetAllFrozenSoulsInScreenBounds()
	{
		//IL_01a8: Expected O, but got I4
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_0145: Expected O, but got I
		//IL_0192: Expected O, but got I4
		//IL_02b5->IL02ba: Incompatible stack heights: 3 vs 0
		//IL_01d7->IL02ba: Incompatible stack heights: 4 vs 0
		List<Pickup> onScreenPickupsCache = _onScreenPickupsCache;
		int version = onScreenPickupsCache._version + 1;
		onScreenPickupsCache._version = version;
		onScreenPickupsCache._size = 0;
		if (onScreenPickupsCache._size > 0)
		{
			Array.Clear(onScreenPickupsCache._items, 0, onScreenPickupsCache._size);
		}
		GameManager gameManager = _gameManager;
		object obj = null;
		HashSet<object>.Enumerator frozenSouls = (HashSet<object>.Enumerator)gameManager._frozenSouls;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		object obj4 = default(object);
		while (enumerator.MoveNext())
		{
			object obj2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v10 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r14_v10 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			object obj3 = ret;
			Rect containmentScreenRect = _containmentScreenRect;
			bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect);
			obj = ret;
			object obj6;
			if (!flag4)
			{
				Rect containmentScreenRect2 = _containmentScreenRect;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+138]");
				frozenSouls = (HashSet<object>.Enumerator)(containmentScreenRect2 + 0);
				bool flag5 = System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref frozenSouls) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref ret);
				obj = ret;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+134]");
					bool flag6 = (nint)obj4 < 0;
					obj = obj4;
					if (!flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+134]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+13C]");
						frozenSouls = (HashSet<object>.Enumerator)(num + 0);
						bool flag7 = System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref frozenSouls) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
						object obj5 = (object)frozenSouls - obj4;
						bool flag8 = obj5 == null;
						bool flag9 = !flag7;
						bool flag10 = !flag8;
						obj6 = flag10 & flag9;
						obj = obj4;
						goto IL_029d;
					}
				}
			}
			obj6 = 0;
			goto IL_029d;
			IL_029d:
			if (obj6 != null)
			{
				bool flag11 = _onScreenPickupsCache == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
			}
		}
		return _onScreenPickupsCache;
	}

	public void FireEnemyBulletAt(Vector2 spawnPos, EnemyType bulletType = EnemyType.BULLET_1)
	{
		//IL_001a: Expected O, but got I4
		int permanentEnemiesNumber = PermanentEnemiesNumber;
		object obj = _maximum + 50;
		if (permanentEnemiesNumber < (nint)obj)
		{
			bool forceSpawn = default(bool);
			GameObject gameObject = SpawnEnemy(bulletType, spawnPos, asRemote: false, forceSpawn);
		}
	}

	private void SpawnEnemyBullet(Vector2 spawnPos, EnemyType bulletType = EnemyType.BULLET_1)
	{
		bool forceSpawn = default(bool);
		GameObject gameObject = SpawnEnemy(bulletType, spawnPos, asRemote: false, forceSpawn);
	}

	public unsafe Vector2 GetBossyPosition(VampireSurvivors.Objects.Characters.CharacterController player = null)
	{
		//IL_0372: Expected O, but got I
		//IL_0190: Expected O, but got I4
		//IL_0441: Expected O, but got I
		//IL_01d6: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		//IL_0706: Expected O, but got Ref
		//IL_0706: Expected O, but got Ref
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		VampireSurvivors.Objects.Characters.CharacterController characterController2;
		if ((object)player != null && ((UnityEngine.Object)player).m_CachedPtr != (IntPtr)0)
		{
			characterController = player;
			characterController2 = player;
			goto IL_00bd;
		}
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter;
		if (_gameSessionData != null)
		{
			characterController2 = gameSessionData._activeCharacter;
			bool flag = (object)gameSessionData._activeCharacter == null;
			characterController = gameSessionData._activeCharacter;
			activeCharacter = gameSessionData._activeCharacter;
			if (!flag)
			{
				goto IL_00bd;
			}
		}
		goto IL_0722;
		IL_0825:
		return (Vector2)new IndexOutOfRangeException();
		IL_0722:
		throw new NullReferenceException();
		IL_02a5:
		float2 position = characterController.position;
		bool flag2 = _spawnOuterRects == null;
		activeCharacter = characterController;
		object key;
		Vector2 vector2 = default(Vector2);
		if (!flag2)
		{
			int num = _spawnOuterRects.FindEntry(characterController);
			if (num < 0)
			{
				UpdateRectForPlayer(characterController);
			}
			Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> spawnOuterRects = _spawnOuterRects;
			bool flag3 = _spawnOuterRects == null;
			activeCharacter = characterController;
			if (!flag3)
			{
				int num2 = _spawnOuterRects.FindEntry(characterController);
				bool flag4 = num2 < 0;
				key = characterController;
				if (flag4)
				{
					System.ThrowHelper.ThrowKeyNotFoundException(key);
					goto IL_0833;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v8 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v8 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
				bool flag5 = (nint)0 == 0;
				activeCharacter = characterController;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v19+18]");
					if ((nint)num2 >= (nint)0)
					{
						goto IL_0825;
					}
					Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> spawnInnerRects = _spawnInnerRects;
					bool flag6 = _spawnInnerRects == null;
					activeCharacter = characterController;
					if (!flag6)
					{
						int num3 = _spawnInnerRects.FindEntry(characterController);
						bool flag7 = num3 < 0;
						key = characterController;
						if (flag7)
						{
							goto IL_0833;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v9 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v9 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
						bool flag8 = (nint)0 == 0;
						activeCharacter = characterController;
						if (!flag8)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v22+18]");
							if ((nint)num3 >= (nint)0)
							{
								goto IL_0825;
							}
							if (_spawnType == SpawnType.HORIZONTAL && _hasTileSet)
							{
								List<Vector2> enemySpawnLocations = _enemySpawnLocations;
								bool flag9 = _enemySpawnLocations == null;
								activeCharacter = characterController;
								if (flag9)
								{
									goto IL_0722;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v42 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								if ((nint)0 > (nint)0)
								{
									Vector2 horizontalSpawnPosition = GetHorizontalSpawnPosition();
									goto IL_0842;
								}
							}
							if (_spawnType == SpawnType.HORIZONTAL_SMOOTHED && _hasTileSet)
							{
								List<Vector2> enemySpawnLocations2 = _enemySpawnLocations;
								bool flag10 = _enemySpawnLocations == null;
								activeCharacter = characterController;
								if (flag10)
								{
									goto IL_0722;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v40 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								if ((nint)0 > (nint)0)
								{
									Vector2 horizontalSmoothedSpawnPosition = GetHorizontalSmoothedSpawnPosition();
									goto IL_0842;
								}
							}
							if (_spawnType == SpawnType.VERTICAL && _hasTileSet)
							{
								List<Vector2> enemySpawnLocations3 = _enemySpawnLocations;
								bool flag11 = _enemySpawnLocations == null;
								activeCharacter = characterController;
								if (flag11)
								{
									goto IL_0722;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v37 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									int num4 = UnityEngine.Random.Range(0, 0);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
									float value = UnityEngine.Random.value;
									if (value < 0.5f)
									{
									}
									goto IL_0842;
								}
							}
							if (_spawnType != SpawnType.TILED)
							{
								object obj3 = default(object);
								object obj4 = default(object);
								Vector2 vector = MathTools.RandomOutside((Rect)(&obj3), (Rect)(&obj4));
							}
							else
							{
								Vector2 positionOutOfSight = GetPositionOutOfSight(vector2);
							}
							goto IL_0842;
						}
					}
				}
			}
		}
		goto IL_0722;
		IL_0842:
		return vector2;
		IL_00bd:
		if (characterController2._PlayerIndex < 0 && characterController2._deficiencyControl != null)
		{
			CharacterADControl deficiencyControl = characterController2._deficiencyControl;
			VampireSurvivors.Objects.Characters.CharacterController followedCharacter = deficiencyControl._followedCharacter;
			if ((object)deficiencyControl._followedCharacter != null && ((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
			{
				activeCharacter = (VampireSurvivors.Objects.Characters.CharacterController)(object)characterController2._deficiencyControl;
				if (characterController2._deficiencyControl != null)
				{
					activeCharacter = (VampireSurvivors.Objects.Characters.CharacterController)((GameMonoBehaviour)activeCharacter)._onPauseSent;
					if (((GameMonoBehaviour)activeCharacter)._onPauseSent)
					{
						bool flag12 = activeCharacter._PlayerIndex >= 0;
						characterController = (VampireSurvivors.Objects.Characters.CharacterController)((GameMonoBehaviour)activeCharacter)._onPauseSent;
						if (!flag12)
						{
							object obj5 = 0;
							bool flag17;
							do
							{
								CharacterADControl deficiencyControl2 = activeCharacter._deficiencyControl;
								bool flag13 = activeCharacter._deficiencyControl == null;
								VampireSurvivors.Objects.Characters.CharacterController characterController3 = (VampireSurvivors.Objects.Characters.CharacterController)(object)activeCharacter._deficiencyControl;
								if (!flag13)
								{
									characterController3 = deficiencyControl2._followedCharacter;
								}
								bool flag14 = (object)characterController3 == null;
								characterController = activeCharacter;
								if (flag14)
								{
									break;
								}
								bool flag15 = ((UnityEngine.Object)characterController3).m_CachedPtr == (IntPtr)0;
								characterController = activeCharacter;
								if (flag15)
								{
									break;
								}
								bool flag16 = characterController3._PlayerIndex >= 0;
								characterController = characterController3;
								if (flag16)
								{
									break;
								}
								obj5++;
								flag17 = (nint)obj5 < 10;
								characterController = characterController3;
								activeCharacter = characterController3;
							}
							while (flag17);
						}
						goto IL_02a5;
					}
				}
				goto IL_0722;
			}
		}
		goto IL_02a5;
		IL_0833:
		System.ThrowHelper.ThrowKeyNotFoundException(key);
		goto IL_0825;
	}

	public void SpawnMerchant()
	{
		//IL_0168: Expected I, but got O
		//IL_0176: Expected I, but got O
		//IL_0186: Expected O, but got I
		//IL_0206: Expected O, but got I4
		//IL_01c2: Expected O, but got I
		//IL_01f8: Expected O, but got I4
		//IL_02d0->IL0256: Incompatible stack heights: 1 vs 0
		//IL_02e4->IL0218: Incompatible stack heights: 1 vs 0
		StageData stageData = _stageData;
		Pickup pickup;
		Pickup trouserMerchant;
		object obj3;
		if (_stageData != null)
		{
			if (stageData._003CisMerchantBanned_003Ek__BackingField)
			{
				return;
			}
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					return;
				}
				if (!_hasTileSet)
				{
					GameSessionData gameSessionData = _gameSessionData;
					if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
					{
						Transform transform = gameSessionData._activeCharacter.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							if ((object)_gameManager != null)
							{
								Vector2 pos = default(Vector2);
								float value = default(float);
								ItemType relicType = default(ItemType);
								bool validatePickups = default(bool);
								pickup = _gameManager.MakeStagePickup(pos, ItemType.MERCHANT, WeaponType.VOID, value, relicType, validatePickups);
								bool flag2 = (object)pickup == null;
								trouserMerchant = null;
								if (flag2)
								{
									goto IL_02d5;
								}
								nint num = (nint)pickup;
								nint num2 = (nint)typeof(PickupMerchant);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchant>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchant>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v29+FFFFFFF8+v466 @ rax_v25*8]");
									if (0 == (nint)typeof(PickupMerchant))
									{
										obj3 = 1;
										goto IL_02e4;
									}
								}
								obj3 = 0;
								goto IL_02e4;
							}
						}
					}
				}
				else if ((object)_tilingTileset != null)
				{
					PickupMerchant trouserMerchant2 = _tilingTileset.SpawnMerchant();
					TrouserMerchant = trouserMerchant2;
					return;
				}
			}
		}
		throw new NullReferenceException();
		IL_02e4:
		bool flag3 = obj3 == null;
		trouserMerchant = null;
		if (!flag3)
		{
			trouserMerchant = pickup;
		}
		goto IL_02d5;
		IL_02d5:
		TrouserMerchant = (PickupMerchant)trouserMerchant;
	}

	public PickupCustomMerchant SpawnStaticCustomMerchant(CharacterType merchantType, Vector2 spawnPos)
	{
		//IL_0475: Expected I4, but got O
		//IL_03a8: Expected I, but got O
		//IL_03b0: Expected I, but got O
		//IL_03c0: Expected O, but got I
		//IL_0440: Expected O, but got I4
		//IL_03fc: Expected O, but got I
		//IL_0432: Expected O, but got I4
		if (merchantType == CharacterType.VOID)
		{
			goto IL_0130;
		}
		if (merchantType == CharacterType.TP_LIBRARIAN)
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj = default(object);
							if ((nint)obj != -1)
							{
								goto IL_0130;
							}
						}
						if (_playerOptions != null)
						{
							PlayerOptionsData config2 = _playerOptions.Config;
							if (config2 != null)
							{
								if (!config2.HasCollectedItem(ItemType.TP_RELIC_PILEOFSECRETS))
								{
									goto IL_0130;
								}
								goto IL_0213;
							}
						}
					}
				}
			}
			goto IL_049b;
		}
		if (merchantType == CharacterType.MARIASOFIA)
		{
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			if (loadedDlc == null)
			{
				goto IL_049b;
			}
			int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)4);
			if (num < 0)
			{
				Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
				if (loadedDlc2 == null)
				{
					goto IL_049b;
				}
				int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)6);
				if (num2 < 0)
				{
					goto IL_0130;
				}
			}
		}
		goto IL_0213;
		IL_049b:
		return (PickupCustomMerchant)(object)new NullReferenceException();
		IL_0130:
		return null;
		IL_0213:
		DataManager dataManager = _dataManager;
		object obj2;
		Pickup pickup;
		object obj5;
		if (_dataManager != null)
		{
			if (dataManager._003CAllCustomMerchantsData_003Ek__BackingField != null)
			{
				int num3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCustomMerchantsData_003Ek__BackingField).FindEntry((System.Int32Enum)merchantType);
				if (num3 >= 0)
				{
					DataManager dataManager2 = _dataManager;
					if (_dataManager != null && dataManager2._003CAllCustomMerchantsData_003Ek__BackingField != null)
					{
						obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllCustomMerchantsData_003Ek__BackingField).get_Item((System.Int32Enum)merchantType);
						if (obj2 != null && CheckCanSpawnCustomMerchant((CustomMerchantData)obj2))
						{
							if ((object)GM.Core == null)
							{
								goto IL_049b;
							}
							float value = default(float);
							ItemType relicType = default(ItemType);
							bool validatePickups = default(bool);
							pickup = GM.Core.MakeStagePickup(spawnPos, ItemType.CUSTOM_MERCHANT, WeaponType.VOID, value, relicType, validatePickups);
							if ((object)pickup != null)
							{
								nint num4 = (nint)typeof(PickupCustomMerchant);
								nint num5 = (nint)pickup;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v23 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v23 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ rcx_v20+FFFFFFF8+v637 @ rcx_v16*8]");
									if (0 == (nint)typeof(PickupCustomMerchant))
									{
										obj5 = 1;
										goto IL_04f5;
									}
								}
								obj5 = 0;
								goto IL_04f5;
							}
						}
						goto IL_0130;
					}
					goto IL_049b;
				}
			}
			object obj7 = default(object);
			object obj6 = (CharacterType)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
			object message = default(object);
			Debug.Log(message);
			goto IL_0130;
		}
		goto IL_049b;
		IL_04f5:
		bool flag = obj5 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		if ((object)pickup2 != null)
		{
			((PickupCustomMerchant)pickup2).SetInventoryData((CustomMerchantData)obj2);
			return (PickupCustomMerchant)pickup2;
		}
		goto IL_0130;
	}

	public void SpawnCustomMerchants(List<CharacterType> merchantTypes)
	{
		//IL_03ce: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_01cd: Expected O, but got I4
		StageData stageData = _stageData;
		if (stageData._003CisMerchantBanned_003Ek__BackingField || merchantTypes == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [merchantTypes @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		List<PickupCustomMerchant> spawnedMerchants = new List<PickupCustomMerchant>();
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		List<PickupCustomMerchant> typeFromHandle;
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-38_v15+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-38_v15+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-38_v15+10]");
				object obj5 = 0;
				object obj6 = obj4 + 1;
				_003C_003Ec__DisplayClass305_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass305_0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v45+20+v180 @ stack_-30_v14*4]");
				CS_0024_003C_003E8__locals3.merchantType = CharacterType.VOID;
				DataManager dataManager = _dataManager;
				Dictionary<CharacterType, CustomMerchantData> dictionary = dataManager._003CAllCustomMerchantsData_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v45+20+v180 @ stack_-30_v14*4]");
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryGetValue((System.Int32Enum)0, out object value);
				bool flag2 = !flag;
				obj4 = obj6;
				if (flag2)
				{
					continue;
				}
				if (CS_0024_003C_003E8__locals3.merchantType == CharacterType.MARIASOFIA)
				{
					Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
					bool flag3 = loadedDlc == null;
					int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)4);
					object obj7 = !flag3;
					if (obj7 == null)
					{
						Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
						bool flag4 = loadedDlc2 == null;
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)6);
						obj4 = obj6;
						if (flag4)
						{
							continue;
						}
					}
				}
				GameManager core = GM.Core;
				Func<Pickup, bool> predicate = delegate(Pickup x)
				{
					//IL_0013: Expected I, but got O
					//IL_001b: Expected I, but got O
					//IL_002b: Expected O, but got I
					//IL_00ab: Expected O, but got I4
					//IL_0067: Expected O, but got I
					//IL_009d: Expected O, but got I4
					//IL_00cd: Expected O, but got I
					//IL_0131: Expected I4, but got O
					//IL_0109: Expected O, but got I
					if ((object)x == null)
					{
						goto IL_011d;
					}
					nint num4 = (nint)typeof(PickupCustomMerchant);
					nint num5 = (nint)x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
					object obj10;
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11+FFFFFFF8+v45 @ rax_v4*8]");
						if (0 == (nint)typeof(PickupCustomMerchant))
						{
							obj10 = 1;
							goto IL_014e;
						}
					}
					obj10 = 0;
					goto IL_014e;
					IL_011d:
					return false;
					IL_014e:
					bool flag9 = obj10 == null;
					Pickup pickup = null;
					if (!flag9)
					{
						pickup = x;
					}
					if ((object)pickup != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5 (VampireSurvivors.Objects.Pickups.Pickup)+190]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v5 (VampireSurvivors.Objects.Pickups.Pickup)+190]");
						if ((nint)0 == 0)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v6+10]");
						object obj12 = (nint)0 - (nint)CS_0024_003C_003E8__locals3.merchantType;
						return obj12 == null;
					}
					goto IL_011d;
				};
				int num3 = Enumerable.Count(core._stagePickups, (Func<object, bool>)predicate);
				bool flag5 = num3 > 0;
				obj4 = obj6;
				if (flag5)
				{
					continue;
				}
				PickupCustomMerchant pickupCustomMerchant = SpawnCustomMerchant((CustomMerchantData)value);
				typeFromHandle = (List<PickupCustomMerchant>)(object)typeof(UnityEngine.Object);
				bool flag6 = (object)pickupCustomMerchant == null;
				obj4 = obj6;
				if (!flag6)
				{
					bool flag7 = ((UnityEngine.Object)pickupCustomMerchant).m_CachedPtr == (IntPtr)0;
					obj4 = obj6;
					typeFromHandle = (List<PickupCustomMerchant>)(object)typeof(UnityEngine.Object);
					if (!flag7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4040");
						obj4 = obj6;
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag8 = obj == null;
		typeFromHandle = (List<PickupCustomMerchant>)0;
		if (!flag8)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ stack_-38_v15+1C]");
			if (obj2 == null)
			{
				PositionAllCustomMerchants(spawnedMerchants);
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			typeFromHandle = null;
		}
		throw new NullReferenceException();
	}

	private bool ShouldWeSeeShadowLayer()
	{
		//IL_003e: Expected F4, but got I4
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_00e3->IL01c8: Incompatible stack heights: 4 vs 0
		//IL_015c->IL0213: Incompatible stack heights: 5 vs 0
		//IL_014e->IL01ee: Incompatible stack heights: 5 vs 3
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		float num = 0f;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj2 = default(object);
		object obj3 = default(object);
		Rectangle rectangle = default(Rectangle);
		while (enumerator.MoveNext())
		{
			Transform transform = ((Component)null).transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			bool flag3 = (object)_tilingTileset == null;
			Vector2 defaultMapPosition = _tilingTileset.DefaultMapPosition;
			object obj = obj2 - obj3;
			object obj4 = (object)ret - (object)defaultMapPosition;
			float y = (float)obj * 100f;
			float num2 = (float)obj4 * 100f;
			Transform transform2 = null;
			while (true)
			{
				List<Rectangle> noShadowLocations = _noShadowLocations;
				bool flag4 = _noShadowLocations == null;
				if ((nint)transform2 >= noShadowLocations._size)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag5 = rectangle == null;
				if (!rectangle.Contains(num2, y))
				{
					transform2 = (Transform)(transform2 + 1);
					num = num2;
					characters = null;
					continue;
				}
				return false;
			}
		}
		return true;
	}

	public void CheckShadows()
	{
		List<Rectangle> noShadowLocations = _noShadowLocations;
		if (noShadowLocations._size > 0)
		{
			bool flag = ShouldWeSeeShadowLayer();
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 55 Invalid \"Jump target not found in method: 0x186E53460\"");
		}
	}

	public void ToggleShadows(bool value)
	{
		//IL_01a7: Expected F4, but got I4
		//IL_0248: Expected O, but got I
		_003C_003Ec__DisplayClass308_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass308_0();
		if (CS_0024_003C_003E8__locals15 != null)
		{
			CS_0024_003C_003E8__locals15._003C_003E4__this = this;
			if (value == _shadowsVisible || (_shadowsTween != null && _shadowsTween.IsAlive()))
			{
				return;
			}
			_shadowsVisible = value;
			List<string> list = new List<string>();
			if (list != null)
			{
				list.Add("Shadows");
				list.Add("ShadowDecals");
				List<Tilemap> shadowLayers = new List<Tilemap>();
				CS_0024_003C_003E8__locals15.shadowLayers = shadowLayers;
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				while (enumerator.MoveNext())
				{
					if ((object)_tilingTileset != null)
					{
						Tilemap tilemapLayer = _tilingTileset.GetTilemapLayer(null);
						if ((object)tilemapLayer != null && ((UnityEngine.Object)tilemapLayer).m_CachedPtr != (IntPtr)0)
						{
							if (CS_0024_003C_003E8__locals15.shadowLayers == null)
							{
								throw new NullReferenceException();
							}
							((List<string>)(object)CS_0024_003C_003E8__locals15.shadowLayers).Add((string)(object)tilemapLayer);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				float shadowAlpha = ((!_shadowsVisible) ? 1f : 0f);
				if ((object)this != null)
				{
					_ShadowAlpha = shadowAlpha;
					if (_shadowsTween != null)
					{
						_shadowsTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						object obj = array;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v943 @ rcx_v26+40]");
						((List<string>)(object)this).Add((string)0);
						object obj2 = default(object);
						if (obj2 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							Dictionary<string, object> dictionary = new Dictionary<string, object>();
							if (!_shadowsVisible)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							if (dictionary != null)
							{
								object value2 = default(object);
								bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_ShadowAlpha", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								tweenConfig.custom = dictionary;
								tweenConfig.duration = 100f;
								TweenCallback onUpdate = delegate
								{
									//IL_01cc: Expected O, but got I4
									//IL_01d5: Expected O, but got I4
									//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
									//IL_02ae: Expected O, but got Unknown
									//IL_0078->IL01a1: Incompatible stack heights: 1 vs 0
									//IL_00af->IL01a1: Incompatible stack heights: 1 vs 0
									//IL_02c8->IL01a1: Incompatible stack heights: 9 vs 0
									//IL_01a0->IL02cd: Incompatible stack heights: 9 vs 0
									List<Tilemap> shadowLayers2 = CS_0024_003C_003E8__locals15.shadowLayers;
									bool flag2 = CS_0024_003C_003E8__locals15.shadowLayers == null;
									object obj3 = 0;
									object obj4 = 0;
									if (!flag2)
									{
										Color value3 = default(Color);
										while (true)
										{
											if ((nint)obj4 >= shadowLayers2._size)
											{
												return;
											}
											List<Tilemap> shadowLayers3 = CS_0024_003C_003E8__locals15.shadowLayers;
											if (CS_0024_003C_003E8__locals15.shadowLayers == null)
											{
												break;
											}
											bool flag3 = (nint)obj3 >= shadowLayers3._size;
											Tilemap[] items = shadowLayers3._items;
											if (shadowLayers3._items == null)
											{
												break;
											}
											object obj5 = items[obj3];
											if ((object)items[obj3] == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v5 (System.Object)+10]");
											bool flag4 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v5 (System.Object)+10]");
											Tilemap.get_color_Injected((IntPtr)0, out Color _);
											List<Tilemap> shadowLayers4 = CS_0024_003C_003E8__locals15.shadowLayers;
											bool flag5 = CS_0024_003C_003E8__locals15.shadowLayers == null;
											bool flag6 = (nint)obj3 >= shadowLayers4._size;
											Tilemap[] items2 = shadowLayers4._items;
											bool flag7 = shadowLayers4._items == null;
											bool flag8 = (nint)obj3 >= items2.Length;
											object obj6 = items2[obj3];
											Stage stage = CS_0024_003C_003E8__locals15._003C_003E4__this;
											bool flag9 = (object)CS_0024_003C_003E8__locals15._003C_003E4__this == null;
											if (!(stage._ShadowAlpha > stage._SoleShadowAlpha))
											{
											}
											bool flag10 = (object)items2[obj3] == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6 (System.Object)+10]");
											bool flag11 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6 (System.Object)+10]");
											Tilemap.set_color_Injected((IntPtr)0, ref value3);
											shadowLayers2 = CS_0024_003C_003E8__locals15.shadowLayers;
											obj3++;
											if (CS_0024_003C_003E8__locals15.shadowLayers == null)
											{
												break;
											}
											obj4 = obj3;
										}
									}
									throw new NullReferenceException();
								};
								tweenConfig.onUpdate = onUpdate;
								MultiTargetTween shadowsTween = Tweens.Add(tweenConfig);
								_shadowsTween = shadowsTween;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public int SetTreasureLevelFromChance(Treasure treasure)
	{
		GameSessionData gameSessionData = _gameSessionData;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 37 Invalid \"Jump target not found in method: 0x186E53EEF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 49 Invalid \"Jump target not found in method: 0x186E53EEF\"");
		float num = gameSessionData._activeCharacter.PLuck();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 66 Invalid \"Jump target not found in method: 0x186E53EEF\"");
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 79 Invalid \"Jump target not found in method: 0x186E53EEF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 92 Invalid \"Jump target not found in method: 0x186E53D90\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 106 Invalid \"Jump target not found in method: 0x186E53D36\"");
		return config._003CBeginnersLuck_003Ek__BackingField;
	}

	public unsafe void SpawnStaticAdventureMerchant(CharacterType merchantType, float2 spawnPos)
	{
		//IL_01ec: Expected I4, but got O
		//IL_0211: Expected O, but got Ref
		//IL_0126: Expected I, but got O
		//IL_012e: Expected I, but got O
		//IL_013e: Expected O, but got I
		//IL_01be: Expected O, but got I4
		//IL_017a: Expected O, but got I
		//IL_01b0: Expected O, but got I4
		if (merchantType == CharacterType.VOID)
		{
			return;
		}
		DataManager dataManager = _dataManager;
		object obj;
		Pickup pickup;
		object obj4;
		if (dataManager._003CAllAdventureMerchantsData_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventureMerchantsData_003Ek__BackingField).FindEntry((System.Int32Enum)merchantType);
			if (num >= 0)
			{
				DataManager dataManager2 = _dataManager;
				obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllAdventureMerchantsData_003Ek__BackingField).get_Item((System.Int32Enum)merchantType);
				if (obj == null || !CheckCanSpawnAdventureMerchant((CustomMerchantData)obj))
				{
					return;
				}
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				pickup = GM.Core.MakeStagePickup(pos, ItemType.ADVENTURE_MERCHANT, WeaponType.VOID, value, relicType, validatePickups);
				if ((object)pickup == null)
				{
					return;
				}
				nint num2 = (nint)typeof(PickupMerchantAdventure);
				nint num3 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchantAdventure>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchantAdventure>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rcx_v19+FFFFFFF8+v371 @ rcx_v15*8]");
					if (0 == (nint)typeof(PickupMerchantAdventure))
					{
						obj4 = 1;
						goto IL_0241;
					}
				}
				obj4 = 0;
				goto IL_0241;
			}
		}
		object obj5 = default(object);
		object arg = (CharacterType)obj5;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj6 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Cannot spawn merchant for {0} as it does not exist in DataManager.AllAdventureMerchantsData", (System.ParamsArray)(&obj6));
		Debug.Log(message);
		return;
		IL_0241:
		bool flag = obj4 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		((PickupCustomMerchant)pickup2)?.SetInventoryData((CustomMerchantData)obj);
	}

	private unsafe void InitRects()
	{
		//IL_0008: Expected O, but got Ref
		//IL_029d: Expected O, but got Ref
		//IL_0538: Expected O, but got F4
		//IL_0546: Expected O, but got Ref
		//IL_0563: Expected O, but got Ref
		//IL_0577: Expected native int or pointer, but got O
		//IL_058a: Expected O, but got Ref
		//IL_03c0: Expected O, but got I4
		//IL_03ce: Expected O, but got Ref
		//IL_03eb: Expected O, but got I4
		//IL_03f9: Expected O, but got Ref
		//IL_0416: Expected O, but got Ref
		//IL_042e: Expected native int or pointer, but got O
		//IL_0441: Expected O, but got Ref
		//IL_047c: Expected O, but got I4
		//IL_048a: Expected O, but got Ref
		//IL_04a7: Expected O, but got I4
		//IL_04b5: Expected O, but got Ref
		//IL_04d2: Expected O, but got Ref
		//IL_04ea: Expected native int or pointer, but got O
		//IL_04fd: Expected O, but got Ref
		//IL_00f0: Expected O, but got Ref
		//IL_0114: Expected O, but got Ref
		//IL_0133: Expected O, but got Ref
		//IL_014b: Expected native int or pointer, but got O
		//IL_0163: Expected O, but got Ref
		//IL_01ac: Expected O, but got Ref
		//IL_01d0: Expected O, but got Ref
		//IL_01f9: Expected O, but got Ref
		//IL_021d: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		if ((object)_mainCamera != null)
		{
			ProCamera2DPixelPerfect component = _mainCamera.GetComponent<ProCamera2DPixelPerfect>();
			if ((object)component != null)
			{
				component.ResizeCameraToPixelPerfect();
				Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v27 (UnityEngine.Bounds)+10]");
				_ = 0;
				if ((object)_mainCamera != null)
				{
					Transform transform = _mainCamera.transform;
					if ((object)transform != null)
					{
						_ = 0;
						_ = 0;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
						Rect rect = default(Rect);
						float num = (float)rect * 2f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
						float num2 = 0f * 2f;
						_widthRect = num;
						_heightRect = num2;
						float num3 = num + 1.5f;
						float num4 = num2 + 1.5f;
						float num5 = num + 0.75f;
						_spawnOuterRect = rect;
						float num6 = num2 + 0.75f;
						float num7 = num * 1.2f;
						_spawnInnerRect = rect;
						float num8 = num2 * 1.3f;
						_containmentScreenRect = rect;
						float num9 = num * 0.5f;
						_containmentExactRect = rect;
						object obj4 = Screen.dpi;
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						_ = 0;
						_ = 0;
						object arg = default(object);
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
						System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
						_ = 0;
						string message = string.FormatHelper((IFormatProvider)null, "Screen - DPI: {0}", args);
						Debug.Log(message);
						object obj6 = Screen.width;
						object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object obj8 = Screen.height;
						object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						_ = 0;
						_ = 0;
						object arg2 = default(object);
						object arg3 = default(object);
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg2, arg3));
						System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
						_ = 0;
						string message2 = string.FormatHelper((IFormatProvider)null, "Screen - Width: {0}, Height: {1}", args2);
						Debug.Log(message2);
						object obj10 = Screen.width;
						object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object obj12 = Screen.height;
						object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						System.ParamsArray paramsArray3 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						_ = 0;
						_ = 0;
						object arg4 = default(object);
						object arg5 = default(object);
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray3, new System.ParamsArray(arg4, arg5));
						System.ParamsArray args3 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
						_ = 0;
						string message3 = string.FormatHelper((IFormatProvider)null, "Screen (Custom) - Width: {0}, Height: {1}", args3);
						Debug.Log(message3);
						object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						_ = _widthRect;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						_ = _heightRect;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						System.ParamsArray paramsArray4 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						_ = 0;
						_ = 0;
						object arg6 = default(object);
						object arg7 = default(object);
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray4, new System.ParamsArray(arg6, arg7));
						System.ParamsArray args4 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
						_ = 0;
						string message4 = string.FormatHelper((IFormatProvider)null, "ScreenBounds - Width: {0}, Height: {1}", args4);
						Debug.Log(message4);
						Rect rect2 = (Rect)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = _spawnOuterRect;
						LogRectInfo("SpawnOuterRect", rect2);
						Rect rect3 = (Rect)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = _spawnInnerRect;
						LogRectInfo("SpawnInnerRect", rect3);
						Rect rect4 = (Rect)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = _containmentScreenRect;
						LogRectInfo("ContainmentScreenRect", rect4);
						Rect rect5 = (Rect)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = _containmentExactRect;
						LogRectInfo("ContainmentExactRect", rect5);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void LogRectInfo(string rectName, Rect rect)
	{
		//IL_0014: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(rectName, arg, arg2);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "{0} - Width: {1}, Height: {2}", (System.ParamsArray)(&obj));
		Debug.Log(message);
	}

	private void InitTiledPositions()
	{
		//IL_024d: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_025b: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_01bf: Expected O, but got F4
		//IL_01cc: Expected O, but got F4
		//IL_0061: Expected O, but got I4
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0077: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0207: Expected O, but got F4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00a2: Expected O, but got F4
		object obj = Screen.height;
		object obj2 = Screen.width;
		object obj3 = Screen.height;
		object obj4 = Screen.width;
		nint num = default(nint);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
			num = 448;
			if (!flag)
			{
				num = 736;
			}
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
		}
		float num2 = default(float);
		_tiledOuterRect = (Rect)num2;
		_tiledInnerRect = (Rect)num2;
		List<Vector2> list = (_tiledPositions = new List<Vector2>());
		List<Vector2> list2 = list;
		list._002Ector();
		list._002Ector();
		List<Vector2> list3 = default(List<Vector2>);
		if ((nint)list3 >= 0)
		{
			object obj5 = obj2;
			object obj6 = 0;
			List<Vector2> list5 = default(List<Vector2>);
			List<Vector2> list4 = list5;
			do
			{
				if ((nint)list5 >= 0)
				{
					object obj7 = 0;
					object obj8 = 0;
					nint num3 = num;
					bool flag2;
					do
					{
						list2 = (List<Vector2>)(this + 352);
						list2.Add((Vector2)num2);
						if (list4 == null)
						{
							_tiledPositions.Add((Vector2)num2);
							num3 = 0;
							list2 = _tiledPositions;
						}
						obj8++;
						obj5 = obj7 + 32;
						flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<List<Vector2>, UIntPtr>(ref list5);
						num = num3;
						obj7 = obj5;
					}
					while (flag2);
				}
				obj6++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) <= System.Runtime.CompilerServices.Unsafe.As<List<Vector2>, UIntPtr>(ref list3));
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divps xmm0,xmm6\"");
		_tiledOuterRect = _tiledOuterRect;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divps xmm0,xmm6\"");
		_tiledInnerRect = _tiledInnerRect;
	}

	private unsafe void UpdateRectPositions()
	{
		//IL_019a: Expected O, but got F4
		//IL_0204: Expected O, but got F4
		//IL_02eb: Expected O, but got F4
		//IL_0353: Expected O, but got F4
		//IL_03bb: Expected O, but got F4
		//IL_0423: Expected O, but got F4
		//IL_0259: Expected O, but got Ref
		//IL_02b1: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		GameManager core = GM.Core;
		float num;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
			if (mainCharacters._size != 0)
			{
				GameManager core3 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core3._mainCharacters;
				if (mainCharacters2._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
					goto IL_045c;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[0];
				if (characterController._multiplayerRevivalUI.IsVisible())
				{
					GameManager core4 = GM.Core;
					if (core4._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField != 0)
					{
						num = 0.5f;
						goto IL_02b6;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+118]");
		float num2 = 0f * 0.5f;
		float num3 = (float)renderer.screenCenter - num2;
		_spawnOuterRect = (Rect)num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+11C]");
		float num4 = 0f * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v8 (PhaserScene+Renderer)+38]");
		float num5 = 0f - num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+128]");
		float num6 = 0f * 0.5f;
		float num7 = (float)renderer.screenCenter - num6;
		_spawnInnerRect = (Rect)num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+12C]");
		float num8 = 0f * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v8 (PhaserScene+Renderer)+38]");
		float num9 = 0f - num8;
		num = 0.5f;
		goto IL_02b6;
		IL_045c:
		throw new NullReferenceException();
		IL_02b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+138]");
		float num10 = 0f * num;
		float num11 = (float)renderer.screenCenter - num10;
		_containmentScreenRect = (Rect)num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+13C]");
		float num12 = 0f * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v8 (PhaserScene+Renderer)+38]");
		float num13 = 0f - num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+148]");
		float num14 = 0f * num;
		float num15 = (float)renderer.screenCenter - num14;
		_containmentExactRect = (Rect)num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+14C]");
		float num16 = 0f * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v8 (PhaserScene+Renderer)+38]");
		float num17 = 0f - num16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+158]");
		float num18 = 0f * num;
		float num19 = (float)renderer.screenCenter - num18;
		_tiledOuterRect = (Rect)num19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+15C]");
		float num20 = 0f * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v8 (PhaserScene+Renderer)+38]");
		float num21 = 0f - num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+168]");
		float num22 = 0f * num;
		float num23 = (float)renderer.screenCenter - num22;
		_tiledInnerRect = (Rect)num23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+16C]");
		float num24 = 0f * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v8 (PhaserScene+Renderer)+38]");
		float num25 = 0f - num24;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator2.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator2);
			goto IL_045c;
		}
	}

	private unsafe void UpdateRectForPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_023f: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_0168: Expected O, but got Ref
		//IL_0189: Expected O, but got Ref
		//IL_00bc: Expected O, but got Ref
		//IL_01df: Expected O, but got Ref
		//IL_0112: Expected O, but got Ref
		//IL_0200: Expected O, but got Ref
		bool flag = player._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = player._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = player._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		object obj3 = default(object);
		if (obj2 == null)
		{
			int num3 = _playerRects.FindEntry(player);
			if (num3 < 0)
			{
				bool flag5 = ((Dictionary<object, Rect>)(object)_playerRects).TryInsert((object)player, (Rect)(&obj3), System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			if (player._coherenceSync.HasStateAuthority)
			{
			}
			bool flag6 = ((Dictionary<object, Rect>)(object)_playerRects).TryInsert((object)player, (Rect)(&obj3), System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
		int num4 = _spawnOuterRects.FindEntry(player);
		if (num4 < 0)
		{
			bool flag7 = ((Dictionary<object, Rect>)(object)_spawnOuterRects).TryInsert((object)player, (Rect)(&obj3), System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		bool flag8 = ((Dictionary<object, Rect>)(object)_spawnOuterRects).TryInsert((object)player, (Rect)(&obj3), System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		int num5 = _spawnInnerRects.FindEntry(player);
		if (num5 < 0)
		{
			bool flag9 = ((Dictionary<object, Rect>)(object)_spawnInnerRects).TryInsert((object)player, (Rect)(&obj3), System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		bool flag10 = ((Dictionary<object, Rect>)(object)_spawnInnerRects).TryInsert((object)player, (Rect)(&obj3), System.Collections.Generic.InsertionBehavior.OverwriteExisting);
	}

	private unsafe void PreloadAssets()
	{
		//IL_00b7: Expected O, but got Ref
		StageData stageData = _stageData;
		PreloadData preloadData = stageData._003Cpreload_003Ek__BackingField;
		if (stageData._003Cpreload_003Ek__BackingField == null)
		{
			return;
		}
		List<string> list = preloadData._003Ctextures_003Ek__BackingField;
		if (preloadData._003Ctextures_003Ek__BackingField == null || list._size <= 0)
		{
			return;
		}
		StageType stageType = default(StageType);
		object arg = stageType;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string path = string.FormatHelper((IFormatProvider)null, "{0}", (System.ParamsArray)(&paramsArray2));
		string path2 = Path.Combine("Preload", path);
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			string path3 = Path.Combine(path2, null);
			Sprite sprite = Resources.Load<Sprite>(path3);
			if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
			{
				SpriteManager.RegisterSprite(sprite);
			}
		}
	}

	private void UnloadAssets()
	{
		StageData stageData = _stageData;
		PreloadData preloadData = stageData._003Cpreload_003Ek__BackingField;
		if (stageData._003Cpreload_003Ek__BackingField != null)
		{
			PreloadData preloadData2 = (PreloadData)(object)preloadData._003Ctextures_003Ek__BackingField;
			if (preloadData._003Ctextures_003Ek__BackingField != null && (nint)preloadData2._003Ctextures_003Ek__BackingField > 0)
			{
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				while (enumerator.MoveNext())
				{
					Sprite sprite = SpriteManager.UnregisterSprite(null);
					if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
					{
						Resources.UnloadAsset(sprite);
					}
				}
			}
		}
		IntPtr intPtr = Resources.UnloadUnusedAssets_Injected();
		if (intPtr != (IntPtr)0)
		{
			AsyncOperation asyncOperation = AsyncOperation.BindingsMarshaller.ConvertToManaged(intPtr);
		}
	}

	private void SetupFancyBackground()
	{
		//IL_00b0: Expected O, but got I4
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fe: Expected O, but got I8
		//IL_01cc: Expected O, but got I8
		//IL_01e6: Expected O, but got I8
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_012b: Expected O, but got I
		//IL_0145: Expected O, but got I8
		//IL_0198: Expected O, but got I8
		StageData stageData = _stageData;
		if (stageData._003Cbackground_003Ek__BackingField == null)
		{
			return;
		}
		GameObject gameObject = _diContainer.CreateEmptyGameObject("FancyBackgroundManager");
		StageData stageData2 = _stageData;
		Background background = stageData2._003Cbackground_003Ek__BackingField;
		StageType? stageType;
		if ((object)background._003CstageType_003Ek__BackingField != null)
		{
			StageData stageData3 = _stageData;
			Background background2 = stageData3._003Cbackground_003Ek__BackingField;
			stageType = background2._003CstageType_003Ek__BackingField;
		}
		else
		{
			stageType = (StageType?)(object)1;
		}
		if ((object)stageType == null)
		{
			return;
		}
		object obj = (object?)stageType >> 32;
		if ((nint)obj > 1000)
		{
			object obj2 = obj - 1024;
			object obj3 = 6442450944L;
			if ((nint)obj2 <= 39)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v3+6E56924+v139 @ rcx_v11]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v3+6E568F0+v200 @ rcx_v15*4]");
				object obj5 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v194 @ rdx_v6 (should have been resolved before IL gen)");
			}
			object obj6 = obj + 4294966216L;
			if ((nint)obj6 > 9)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v3+6E5694C+v136 @ rax_v13*4]");
			object obj7 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v201 @ rcx_v13 (should have been resolved before IL gen)");
		}
		if ((nint)obj <= 41)
		{
			object obj8 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ r9_v2+6E56974+v69 @ rax_v10*4]");
			object obj9 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v202 @ rcx_v10 (should have been resolved before IL gen)");
		}
		else if ((nint)obj == 1000)
		{
			BackgroundBazaar fancyBg = gameObject.AddComponent<BackgroundBazaar>();
			_fancyBg = fancyBg;
		}
	}

	private void UpdateTimers()
	{
		//IL_00af: Invalid comparison between F4 and I4
		if (!(_003CPause_003Ek__BackingField > 0f))
		{
			StartTimers();
			return;
		}
		if (_pauseTimer != null)
		{
			_pauseTimer.Cancel();
		}
		Action onComplete = StartTimers;
		float duration = _003CPause_003Ek__BackingField * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer pauseTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_pauseTimer = pauseTimer;
	}

	private void PlayEvents()
	{
		if (_stageEventTwitchManager != null)
		{
			bool flag = _stageEventTwitchManager.TriggerEvents();
		}
		List<VampireSurvivors.Data.Stage.Event>.Enumerator enumerator = default(List<VampireSurvivors.Data.Stage.Event>.Enumerator);
		while (enumerator.MoveNext())
		{
			VampireSurvivors.Data.Stage.Event obj = null;
		}
	}

	public unsafe bool GetStageDataForMinute(int minute, StageType stageType, out StageData stageData, out JObject stageJsonObject)
	{
		//IL_0083: Expected I4, but got O
		ref JObject reference = ref *(JObject*)null;
		ref StageData reference2 = ref *(StageData*)null;
		bool flag = GetStageDataForMinute(minute, stageType, out reference);
		if (flag)
		{
			if (reference == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			object obj = reference.ToObject<object>();
			reference2 = ref *(StageData*)obj;
			flag = true;
		}
		return flag;
	}

	public unsafe bool GetStageDataForMinute(int minute, StageType stageType, out JObject stageJsonObject)
	{
		//IL_03d7: Expected I4, but got O
		//IL_00cb: Expected I, but got O
		//IL_00e3: Expected O, but got I
		//IL_0163: Expected O, but got I4
		//IL_011f: Expected O, but got I
		//IL_0155: Expected O, but got I4
		//IL_02ce: Expected I, but got O
		//IL_0185: Expected I, but got O
		//IL_0195: Expected O, but got I
		//IL_0215: Expected O, but got I4
		//IL_01d1: Expected O, but got I
		//IL_0207: Expected O, but got I4
		ref JObject reference = ref *(JObject*)null;
		if (minute > _maxStageDataMinute)
		{
			goto IL_03a2;
		}
		DataManager dataManager = _dataManager;
		if (_dataManager == null || dataManager._003CAllStages_003Ek__BackingField == null)
		{
			goto IL_03c9;
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllStages_003Ek__BackingField).get_Item((System.Int32Enum)stageType);
		BackgroundManager fancyBg = _fancyBg;
		bool flag = (object)_fancyBg == null;
		ref JObject reference2 = ref stageJsonObject;
		object stageDataArray = obj;
		if (flag)
		{
			goto IL_03d7;
		}
		nint num = (nint)typeof(BackgroundTP_Basic);
		reference2 = ref *(JObject*)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r9_v4 (Newtonsoft.Json.Linq.JObject&)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
		object obj4;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r9_v4 (Newtonsoft.Json.Linq.JObject&)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v24+FFFFFFF8+v375 @ rcx_v14*8]");
			if (0 == (nint)typeof(BackgroundTP_Basic))
			{
				obj4 = 1;
				goto IL_0405;
			}
		}
		obj4 = 0;
		goto IL_0405;
		IL_03d7:
		JToken minuteDataFromStageDataList = DataHelper.GetMinuteDataFromStageDataList(minute, (JArray)stageDataArray);
		if (minuteDataFromStageDataList != null && minuteDataFromStageDataList.HasValues)
		{
			IEnumerable<JToken> value = minuteDataFromStageDataList.CloneToken((JsonCloneSettings)null);
			object obj5 = Newtonsoft.Json.Linq.Extensions.Value<object>(value);
			if (obj5 != null)
			{
				nint num3 = (nint)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v550 @ rdx_v12 (Il2CppClass<System.Object>)+238] (should have been resolved before IL gen)");
				object obj6 = default(object);
				if (obj6 != null)
				{
					reference = ref *(JObject*)obj5;
					return true;
				}
			}
		}
		goto IL_03a2;
		IL_0405:
		bool flag2 = obj4 == null;
		BackgroundManager backgroundManager = null;
		if (!flag2)
		{
			backgroundManager = _fancyBg;
		}
		object obj9;
		if ((object)backgroundManager == null)
		{
			nint num4 = (nint)typeof(BackgroundEmerald);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r9_v4 (Newtonsoft.Json.Linq.JObject&)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r9_v4 (Newtonsoft.Json.Linq.JObject&)+C8]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v27+FFFFFFF8+v510 @ rax_v23*8]");
				if (0 == (nint)typeof(BackgroundEmerald))
				{
					obj9 = 1;
					goto IL_0427;
				}
			}
			obj9 = 0;
			goto IL_0427;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rdx_v16 (VampireSurvivors.Objects.Stages.BackgroundManager)+130]");
		bool flag3 = (nint)0 == 0;
		stageDataArray = obj;
		int key;
		Dictionary<int, JArray> stageDataByBiome;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rdx_v16 (VampireSurvivors.Objects.Stages.BackgroundManager)+130]");
			if ((nint)0 != 0)
			{
				if (_stageDataByBiome != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rdx_v16 (VampireSurvivors.Objects.Stages.BackgroundManager)+130]");
					key = (int)((nint)0 >> 32);
					stageDataByBiome = _stageDataByBiome;
					goto IL_044e;
				}
			}
			else
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
			goto IL_03c9;
		}
		goto IL_03d7;
		IL_03a2:
		return false;
		IL_044e:
		object obj10 = stageDataByBiome.get_Item(key);
		stageDataArray = obj10;
		goto IL_03d7;
		IL_03c9:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0427:
		bool flag4 = obj9 == null;
		BackgroundManager backgroundManager2 = null;
		if (!flag4)
		{
			backgroundManager2 = _fancyBg;
		}
		bool flag5 = (object)backgroundManager2 == null;
		stageDataArray = obj;
		if (flag5)
		{
			goto IL_03d7;
		}
		if (_stageDataByBiome == null)
		{
			goto IL_03c9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdi_v8 (VampireSurvivors.Objects.Stages.BackgroundManager)+D0]");
		key = 0;
		stageDataByBiome = _stageDataByBiome;
		goto IL_044e;
	}

	public void RemoveCharm()
	{
		if (_isCharmApplied)
		{
			StageData stageData = _stageData;
			_isCharmApplied = false;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			PlayerModifierStats playerStats = activeCharacter._playerStats;
			int num = stageData._003Cminimum_003Ek__BackingField - playerStats._003CCharm_003Ek__BackingField;
			stageData._003Cminimum_003Ek__BackingField = num;
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
			PlayerModifierStats playerStats2 = activeCharacter2._playerStats;
			int maximum = _defaultMaximum - playerStats2._003CCharm_003Ek__BackingField;
			_maximum = maximum;
		}
	}

	public void ApplyCharm()
	{
		if (!_isCharmApplied)
		{
			StageData stageData = _stageData;
			_isCharmApplied = true;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			PlayerModifierStats playerStats = activeCharacter._playerStats;
			int num = stageData._003Cminimum_003Ek__BackingField + playerStats._003CCharm_003Ek__BackingField;
			stageData._003Cminimum_003Ek__BackingField = num;
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
			PlayerModifierStats playerStats2 = activeCharacter2._playerStats;
			int maximum = playerStats2._003CCharm_003Ek__BackingField + _defaultMaximum;
			_maximum = maximum;
		}
	}

	private void UpdateAllData(JObject stageJsonObject)
	{
		ResetStageDataForUpdate();
		if (_stageJsonData != null && _stageJsonData.HasValues)
		{
			JObject stageJsonData = DataHelper.UpgradeStageJsonData(_stageJsonData, stageJsonObject);
			_stageJsonData = stageJsonData;
		}
		else
		{
			_stageJsonData = stageJsonObject;
		}
		object stageData = _stageJsonData.ToObject<object>();
		_stageData = (StageData)stageData;
		if (_stageData != null)
		{
			RecalculateCurseAndCharm();
			StageData stageData2 = _stageData;
			UpdateEnemyPools(stageData2._003Cenemies_003Ek__BackingField, stageData2._003Cbosses_003Ek__BackingField);
			UpdateTimers();
			PlayEvents();
			StageData stageData3 = _stageData;
			_lastMinimum = stageData3._003Cminimum_003Ek__BackingField;
			_lastMaximum = _maximum;
			GameManager core = GM.Core;
			if (core._003CHasGfBonus_003Ek__BackingField)
			{
				StageData stageData4 = _stageData;
				stageData4._003Cminimum_003Ek__BackingField = 500;
				_maximum = 500;
			}
		}
	}

	private int GetCharmForMinute(int minute)
	{
		//IL_0138: Expected I4, but got O
		BackgroundManager fancyBg = _fancyBg;
		bool flag = (object)_fancyBg == null;
		float num = 1f;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
			num = 1f;
			if (!flag2)
			{
				BackgroundManager fancyBg2 = _fancyBg;
				if ((object)_fancyBg == null)
				{
					goto IL_012a;
				}
				num = fancyBg2.CharmMod;
			}
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				if ((object)gameSessionData._activeCharacter != null)
				{
					PlayerModifierStats playerStats = activeCharacter._playerStats;
					if (activeCharacter._playerStats != null)
					{
						float num2 = (float)playerStats._003CCharm_003Ek__BackingField * num;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
						int result = default(int);
						return result;
					}
				}
			}
		}
		goto IL_012a;
		IL_012a:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private void ResetStageDataForUpdate()
	{
		List<EnemyType?> bossTypes = _bossTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		if (_stageJsonData != null)
		{
			if (_stageJsonData.ContainsKey("bosses"))
			{
				JArray value = new JArray();
				_stageJsonData.set_Item("bosses", (JToken)value);
			}
			if (_stageJsonData.ContainsKey("events"))
			{
				JArray value2 = new JArray();
				_stageJsonData.set_Item("events", (JToken)value2);
			}
			if (_stageJsonData.ContainsKey("arcanaHolder"))
			{
				_stageJsonData.set_Item("arcanaHolder", (JToken)null);
			}
			if (_stageJsonData.ContainsKey("treasure"))
			{
				_stageJsonData.set_Item("treasure", (JToken)null);
			}
			if (_stageJsonData.ContainsKey("arcanaTreasure"))
			{
				_stageJsonData.set_Item("arcanaTreasure", (JToken)null);
			}
		}
	}

	private unsafe void UpdateMinuteData()
	{
		//IL_0180: Expected O, but got I
		//IL_010a: Expected O, but got I
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_03ec: Expected O, but got I4
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_01f4: Expected O, but got I
		//IL_024d: Expected O, but got I
		//IL_02c1: Expected O, but got I
		//IL_0328: Expected O, but got I
		//IL_0328: Expected O, but got I
		ResetStageDataForUpdate();
		StageData stageData = _stageData;
		StageType stageType = _stageType;
		if (stageData._003CrandomMinutes_003Ek__BackingField)
		{
			List<StageType> validUnlockedStages = GetValidUnlockedStages();
			if (validUnlockedStages != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v80 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
				if ((nint)0 >= (nint)2)
				{
					StageType stageType2 = VampireSurvivors.App.Tools.Extensions.PickRnd(validUnlockedStages);
					stageType = stageType2;
				}
			}
		}
		object obj = null;
		object obj2;
		if (GetStageDataForMinute(_currentMinute, stageType, out var stageJsonObject))
		{
			obj2 = stageJsonObject.ToObject<object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			obj = obj2;
			if (flag)
			{
				goto IL_0170;
			}
			object obj3 = (nint)(&obj) >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj5 * 8;
			object obj7 = obj6 + 6603577472L;
			object obj8 = obj4 & 0x3F;
			nint num2;
			do
			{
				object obj9 = 1 << (int)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v27+462E0]");
				object obj10 = 0 | obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v27+462E0]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v27+462E0]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v27+462E0]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v27+462E0]");
			}
			while (num2 != 0);
		}
		obj2 = obj;
		goto IL_0170;
		IL_0170:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v12 (System.Object)+178]");
		List<VampireSurvivors.Data.Stage.Event> list = (List<VampireSurvivors.Data.Stage.Event>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v12 (System.Object)+178]");
		StageData stageData2;
		if ((nint)0 != 0)
		{
			stageData2 = _stageData;
		}
		else
		{
			StageData stageData3 = _stageData;
			stageData2 = _stageData;
			list = stageData3._003Cevents_003Ek__BackingField;
		}
		stageData2._003Cevents_003Ek__BackingField = list;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+158]");
		List<EnemyType?> bossTypes = (List<EnemyType?>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+158]");
		if ((nint)0 == 0)
		{
			StageData stageData4 = _stageData;
			bossTypes = stageData4._003Cbosses_003Ek__BackingField;
		}
		_bossTypes = bossTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+160]");
		Treasure treasure = (Treasure)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+160]");
		StageData stageData5;
		if ((nint)0 != 0)
		{
			stageData5 = _stageData;
		}
		else
		{
			StageData stageData6 = _stageData;
			stageData5 = _stageData;
			treasure = stageData6._003Ctreasure_003Ek__BackingField;
		}
		stageData5._003Ctreasure_003Ek__BackingField = treasure;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+150]");
		List<EnemyType?> enemyTypes = (List<EnemyType?>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+150]");
		if ((nint)0 == 0)
		{
			StageData stageData7 = _stageData;
			enemyTypes = stageData7._003Cenemies_003Ek__BackingField;
		}
		_enemyTypes = enemyTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+150]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_8_v3 (System.Object)+158]");
		UpdateEnemyPools((List<EnemyType?>)num3, (List<EnemyType?>)0);
		UpdateTimers();
		PlayEvents();
	}

	private unsafe StageData CompressTime(JObject originalData)
	{
		//IL_014d: Expected O, but got Ref
		//IL_0155: Expected O, but got Ref
		//IL_01b0: Expected I, but got O
		//IL_023f: Expected O, but got I4
		//IL_01e8: Expected O, but got I
		//IL_024c: Expected I, but got O
		//IL_025c: Expected O, but got I
		//IL_0299: Expected O, but got I
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_049c: Expected O, but got I4
		//IL_04fd: Expected O, but got I4
		//IL_03eb: Expected O, but got I
		//IL_056d: Expected O, but got I
		//IL_0471: Expected O, but got I
		//IL_05e8: Expected O, but got I
		//IL_05b8: Expected O, but got I8
		//IL_05fb: Expected O, but got I4
		//IL_09e2: Expected O, but got I
		//IL_09e2: Expected O, but got I
		//IL_0c2c: Expected O, but got I
		//IL_0c69: Expected O, but got I
		//IL_0cce: Expected O, but got I
		//IL_0d20: Expected O, but got I
		//IL_0d55: Expected O, but got I
		//IL_0db2: Expected O, but got I
		//IL_0e4f: Expected O, but got I
		//IL_0e8c: Expected O, but got I
		//IL_0ef1: Expected O, but got I
		//IL_0f43: Expected O, but got I
		//IL_0f78: Expected O, but got I
		//IL_0fd5: Expected O, but got I
		//IL_105b: Expected O, but got I
		//IL_1098: Expected O, but got I
		//IL_10fd: Expected O, but got I
		//IL_114f: Expected O, but got I
		//IL_1184: Expected O, but got I
		//IL_11e1: Expected O, but got I
		//IL_1271: Expected O, but got I
		//IL_1281: Expected O, but got I
		//IL_12a0: Expected O, but got I
		//IL_12be: Expected O, but got I
		//IL_12e5: Expected O, but got I
		//IL_131a: Expected O, but got I
		//IL_1362: Expected O, but got I
		//IL_13c9: Expected O, but got I
		//IL_13c9: Expected O, but got I
		int num = _currentMinute + _currentMinute;
		object obj = null;
		JToken jToken;
		if (GetStageDataForMinute(num, _stageType, out var stageJsonObject))
		{
			bool flag = stageJsonObject == null;
			jToken = stageJsonObject;
			if (flag)
			{
				goto IL_14db;
			}
			object obj2 = stageJsonObject.ToObject<object>();
			obj = obj2;
		}
		JToken jToken2 = null;
		int minute = num + 1;
		if (GetStageDataForMinute(minute, _stageType, out var stageJsonObject2))
		{
			bool flag2 = stageJsonObject2 == null;
			jToken = stageJsonObject2;
			if (flag2)
			{
				goto IL_14db;
			}
			object obj3 = stageJsonObject2.ToObject<object>();
			jToken2 = (JToken)obj3;
		}
		JObject jObject = new JObject();
		bool flag3 = originalData == null;
		jToken = jObject;
		object obj16;
		object result;
		if (!flag3)
		{
			IEnumerable<object> enumerable = Enumerable.Cast<object>(originalData._properties);
			bool flag4 = enumerable == null;
			jToken = (JToken)(object)originalData._properties;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				JToken jToken3 = default(JToken);
				object obj4 = (object)(&jToken3);
				object obj5 = (object)(&stageJsonObject2);
				jToken = null;
				object obj6 = default(object);
				object content = default(object);
				object obj15 = default(object);
				while (true)
				{
					object obj14;
					object obj7;
					if (jToken3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj6 == null)
						{
							break;
						}
						bool flag5 = jToken3 == null;
						jToken = null;
						if (!flag5)
						{
							nint num2 = (nint)jToken3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ r10_v12 (Il2CppClass<Newtonsoft.Json.Linq.JToken>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0224;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ r10_v12 (Il2CppClass<Newtonsoft.Json.Linq.JToken>)+B0]");
							obj7 = 0;
							object obj8 = null;
							while (true)
							{
								object obj9 = obj8 + obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ r8_v72+v2088 @ rax_v180*8]");
								if (0 == (nint)typeof(IEnumerator<JProperty>))
								{
									break;
								}
								obj8++;
								object obj10 = obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ r10_v12 (Il2CppClass<Newtonsoft.Json.Linq.JToken>)+12E]");
								if ((nint)obj10 < 0)
								{
									continue;
								}
								goto IL_0224;
							}
							object obj11 = obj8 + obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ r8_v72+8+v2201 @ rcx_v132*8]");
							object obj12 = (nint)0 << 4;
							object obj13 = obj12 + 312;
							obj14 = obj13 + num2;
							goto IL_15d8;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_15d8:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2206 @ rdx_v91] (should have been resolved before IL gen)");
					bool flag6 = jObject == null;
					jToken = jToken3;
					if (!flag6)
					{
						nint num3 = (nint)jObject;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2234 @ r8_v73 (Il2CppClass<Newtonsoft.Json.Linq.JObject>)+6E8]");
						obj5 = 0;
						jObject.Add(content);
						jToken = jObject;
						continue;
					}
					throw new NullReferenceException();
					IL_0224:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj14 = obj15;
					obj7 = 0;
					goto IL_15d8;
				}
				bool flag7 = obj4 == null;
				jToken = null;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					jToken = null;
				}
				if (jObject != null)
				{
					obj16 = jObject.ToObject<object>();
					if (stageJsonObject == null || stageJsonObject2 == null)
					{
						result = obj;
						goto IL_16fa;
					}
					if (!stageJsonObject.ContainsKey("minimum"))
					{
						goto IL_1624;
					}
					bool flag8 = stageJsonObject2 == null;
					jToken = stageJsonObject2;
					if (!flag8)
					{
						if (!stageJsonObject2.ContainsKey("minimum"))
						{
							goto IL_1624;
						}
						bool flag9 = obj == null;
						jToken = stageJsonObject2;
						if (!flag9)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+140]");
							object obj17 = 0;
							bool flag10 = jToken2 == null;
							jToken = jToken2;
							if (!flag10)
							{
								bool flag11 = obj16 == null;
								jToken = jToken2;
								if (!flag11)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+140]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+140]");
									if (num4 <= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+140]");
										obj17 = 0;
									}
									goto IL_1624;
								}
							}
						}
					}
				}
			}
		}
		goto IL_14db;
		IL_14db:
		throw new NullReferenceException();
		IL_1670:
		bool flag12 = obj16 == null;
		jToken = (JToken)(object)typeof(Math);
		if (flag12)
		{
			goto IL_14db;
		}
		object obj18 = 0;
		jToken = (JToken)(object)typeof(Math);
		goto IL_1653;
		IL_08db:
		bool flag13 = stageJsonObject == null;
		jToken = stageJsonObject;
		if (!flag13)
		{
			if (!stageJsonObject.ContainsKey("events"))
			{
				goto IL_0a2f;
			}
			bool flag14 = stageJsonObject2 == null;
			jToken = stageJsonObject2;
			if (!flag14)
			{
				if (!stageJsonObject2.ContainsKey("events"))
				{
					goto IL_0a2f;
				}
				bool flag15 = obj == null;
				jToken = stageJsonObject2;
				if (!flag15)
				{
					bool flag16 = jToken2 == null;
					jToken = stageJsonObject2;
					if (!flag16)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+178]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+178]");
						IEnumerable<VampireSurvivors.Data.Stage.Event> enumerable2 = Enumerable.Concat((IEnumerable<VampireSurvivors.Data.Stage.Event>)num5, (IEnumerable<VampireSurvivors.Data.Stage.Event>)0);
						if (enumerable2 != null)
						{
							List<object> list = new List<object>(enumerable2);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1859DE620");
							goto IL_0b2f;
						}
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
				}
			}
		}
		goto IL_14db;
		IL_1624:
		bool flag17 = stageJsonObject == null;
		jToken = stageJsonObject;
		if (!flag17)
		{
			bool flag18 = stageJsonObject.ContainsKey("frequency");
			bool flag19 = !flag18;
			obj18 = 0;
			jToken = stageJsonObject;
			if (flag19)
			{
				goto IL_1653;
			}
			bool flag20 = stageJsonObject2 == null;
			jToken = stageJsonObject2;
			if (!flag20)
			{
				bool flag21 = stageJsonObject2.ContainsKey("frequency");
				bool flag22 = !flag21;
				obj18 = 0;
				jToken = stageJsonObject2;
				if (flag22)
				{
					goto IL_1653;
				}
				bool flag23 = obj == null;
				jToken = stageJsonObject2;
				if (!flag23)
				{
					bool flag24 = jToken2 == null;
					jToken = stageJsonObject2;
					if (!flag24)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+144]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+144]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+144]");
						if (num6 <= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+144]");
							object obj20 = 0 & -2147483649L;
							if ((nint)obj20 <= 2139095040)
							{
								goto IL_1670;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+144]");
						obj19 = 0;
						goto IL_1670;
					}
				}
			}
		}
		goto IL_14db;
		IL_1653:
		if (obj != null && jToken2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3DC0");
			IEnumerable<System.Int32Enum?> enumerable3 = default(IEnumerable<System.Int32Enum?>);
			if (enumerable3 == null)
			{
				goto IL_169b;
			}
			List<System.Int32Enum?> list2 = new List<System.Int32Enum?>(enumerable3);
			bool flag25 = obj16 == null;
			jToken = (JToken)(object)list2;
			if (!flag25)
			{
				bool flag26 = stageJsonObject == null;
				jToken = stageJsonObject;
				if (!flag26)
				{
					if (!stageJsonObject.ContainsKey("bosses"))
					{
						goto IL_07db;
					}
					bool flag27 = stageJsonObject2 == null;
					jToken = stageJsonObject2;
					if (!flag27)
					{
						if (!stageJsonObject2.ContainsKey("bosses"))
						{
							goto IL_07db;
						}
						bool flag28 = obj == null;
						jToken = stageJsonObject2;
						if (!flag28)
						{
							bool flag29 = jToken2 == null;
							jToken = stageJsonObject2;
							if (!flag29)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3DC0");
								IEnumerable<System.Int32Enum?> enumerable4 = default(IEnumerable<System.Int32Enum?>);
								if (enumerable4 != null)
								{
									List<System.Int32Enum?> list3 = new List<System.Int32Enum?>(enumerable4);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18666C0C0");
									goto IL_08db;
								}
								Exception ex2 = System.Linq.Error.ArgumentNull("source");
								throw ex2;
							}
						}
					}
				}
			}
		}
		goto IL_14db;
		IL_13d6:
		if (stageJsonObject == null)
		{
			goto IL_14db;
		}
		if (!stageJsonObject.ContainsKey("treasure"))
		{
			if (stageJsonObject2 == null)
			{
				goto IL_14db;
			}
			bool flag30 = stageJsonObject2.ContainsKey("treasure");
			bool flag31 = !flag30;
			result = obj16;
			if (!flag31)
			{
				if (jToken2 == null)
				{
					goto IL_14db;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B0BEB0");
				result = obj16;
			}
		}
		else
		{
			if (obj == null)
			{
				goto IL_14db;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+160]");
			_ = 0;
			result = obj16;
		}
		goto IL_16fa;
		IL_07db:
		bool flag32 = stageJsonObject == null;
		jToken = stageJsonObject;
		if (!flag32)
		{
			if (!stageJsonObject.ContainsKey("bosses"))
			{
				bool flag33 = stageJsonObject2 == null;
				jToken = stageJsonObject2;
				if (!flag33)
				{
					if (stageJsonObject2.ContainsKey("bosses"))
					{
						bool flag34 = jToken2 == null;
						jToken = stageJsonObject2;
						if (flag34)
						{
							goto IL_14db;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18666C0C0");
					}
					goto IL_08db;
				}
			}
			else
			{
				bool flag35 = obj == null;
				jToken = stageJsonObject;
				if (!flag35)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+158]");
					_ = 0;
					goto IL_08db;
				}
			}
		}
		goto IL_14db;
		IL_0a2f:
		bool flag36 = stageJsonObject == null;
		jToken = stageJsonObject;
		if (!flag36)
		{
			if (!stageJsonObject.ContainsKey("events"))
			{
				bool flag37 = stageJsonObject2 == null;
				jToken = stageJsonObject2;
				if (!flag37)
				{
					if (stageJsonObject2.ContainsKey("events"))
					{
						bool flag38 = jToken2 == null;
						jToken = stageJsonObject2;
						if (flag38)
						{
							goto IL_14db;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1859DE620");
					}
					goto IL_0b2f;
				}
			}
			else
			{
				bool flag39 = obj == null;
				jToken = stageJsonObject;
				if (!flag39)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+178]");
					_ = 0;
					goto IL_0b2f;
				}
			}
		}
		goto IL_14db;
		IL_0b2f:
		bool flag40 = stageJsonObject == null;
		jToken = stageJsonObject;
		if (!flag40)
		{
			if (!stageJsonObject.ContainsKey("treasure"))
			{
				goto IL_13d6;
			}
			bool flag41 = stageJsonObject2 == null;
			jToken = stageJsonObject2;
			if (!flag41)
			{
				if (!stageJsonObject2.ContainsKey("treasure"))
				{
					goto IL_13d6;
				}
				Treasure treasure = new Treasure();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B0BEB0");
				List<float> list4 = new List<float>();
				bool flag42 = obj == null;
				jToken = (JToken)(object)list4;
				if (!flag42)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+160]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+160]");
					bool flag43 = (nint)0 == 0;
					jToken = (JToken)(object)list4;
					if (!flag43)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v84+10]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v84+10]");
						bool flag44 = (nint)0 == 0;
						jToken = (JToken)(object)list4;
						if (!flag44)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v85+18]");
							if ((nint)0 <= (nint)0)
							{
								goto IL_16e3;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v85+10]");
							jToken = (JToken)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v85+10]");
							if ((nint)0 != 0 && jToken2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
								object obj23 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v87+10]");
									object obj24 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v87+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v88+18]");
										if ((nint)0 <= (nint)0)
										{
											goto IL_16e3;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v88+10]");
										jToken = (JToken)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v88+10]");
										if ((nint)0 != 0 && list4 != null)
										{
											float item = (float)jToken._next + (float)jToken._next;
											list4.Add(item);
											bool flag45 = obj == null;
											jToken = (JToken)(object)list4;
											if (!flag45)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+160]");
												object obj25 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+160]");
												bool flag46 = (nint)0 == 0;
												jToken = (JToken)(object)list4;
												if (!flag46)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rax_v91+10]");
													object obj26 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rax_v91+10]");
													bool flag47 = (nint)0 == 0;
													jToken = (JToken)(object)list4;
													if (!flag47)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rax_v92+18]");
														if ((nint)0 <= (nint)1)
														{
															goto IL_16e3;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rax_v92+10]");
														jToken = (JToken)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rax_v92+10]");
														if ((nint)0 != 0 && jToken2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
															object obj27 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v94+10]");
																object obj28 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v94+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v95+18]");
																	if ((nint)0 <= (nint)1)
																	{
																		goto IL_16e3;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v95+10]");
																	jToken = (JToken)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v95+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1547 @ rcx_v23 (Newtonsoft.Json.Linq.JToken)+24]");
																		float num7 = 0f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1547 @ rcx_v23 (Newtonsoft.Json.Linq.JToken)+24]");
																		float item2 = num7 + 0f;
																		list4.Add(item2);
																		bool flag48 = obj == null;
																		jToken = (JToken)(object)list4;
																		if (!flag48)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+160]");
																			object obj29 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_20_v12 (System.Object)+160]");
																			bool flag49 = (nint)0 == 0;
																			jToken = (JToken)(object)list4;
																			if (!flag49)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rax_v98+10]");
																				object obj30 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rax_v98+10]");
																				bool flag50 = (nint)0 == 0;
																				jToken = (JToken)(object)list4;
																				if (!flag50)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rax_v99+18]");
																					if ((nint)0 <= (nint)2)
																					{
																						goto IL_16e3;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rax_v99+10]");
																					jToken = (JToken)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rax_v99+10]");
																					if ((nint)0 != 0 && jToken2 != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
																						object obj31 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
																						if ((nint)0 != 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rax_v101+10]");
																							object obj32 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rax_v101+10]");
																							if ((nint)0 != 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v102+18]");
																								if ((nint)0 <= (nint)2)
																								{
																									goto IL_16e3;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v102+10]");
																								object obj33 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v102+10]");
																								if ((nint)0 != 0)
																								{
																									float num8 = (float)jToken._annotations;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rdx_v55+28]");
																									float item3 = num8 + 0f;
																									list4.Add(item3);
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																									bool flag51 = (nint)0 == 0;
																									jToken = (JToken)(object)list4;
																									if (!flag51)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																										((JToken)0).Parent = (JContainer)(object)list4;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																										object obj34 = 0;
																										bool flag52 = jToken2 == null;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																										jToken = (JToken)0;
																										if (!flag52)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
																											object obj35 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
																											bool flag53 = (nint)0 == 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																											jToken = (JToken)0;
																											if (!flag53)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																												bool flag54 = (nint)0 == 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																												jToken = (JToken)0;
																												if (!flag54)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rax_v106+18]");
																													_ = 0;
																													if (jToken2 != null)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
																														object obj36 = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_8_v12 (Newtonsoft.Json.Linq.JToken)+160]");
																														if ((nint)0 != 0)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																															if ((nint)0 != 0)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rax_v47 (System.Object)+160]");
																																nint num9 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rdx_v58+20]");
																																((JToken)num9).Next = (JToken)0;
																																result = obj16;
																																goto IL_16fa;
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
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_14db;
		IL_169b:
		Exception ex3 = System.Linq.Error.ArgumentNull("source");
		throw ex3;
		IL_16fa:
		return (StageData)result;
		IL_16e3:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_169b;
	}

	private void ReleasePool()
	{
		_enemyFactory.PurgePools();
	}

	public void UpdateNormalEnemyPoolsOnly(List<EnemyType?> enemies)
	{
		//IL_031c: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_0165: Expected O, but got I
		//IL_02ae: Expected O, but got I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		_enemyTypes = enemies;
		Dictionary<EnemyType, bool>.KeyCollection keys = _enemyPoolStates.Keys;
		List<EnemyType> list = (List<EnemyType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)(object)keys);
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ stack_-58_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ stack_-58_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ stack_-58_v3+10]");
						object obj5 = 0;
						obj4++;
						Dictionary<EnemyType, bool> enemyPoolStates = _enemyPoolStates;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rdx_v33+20+v768 @ rcx_v41*4]");
						bool flag = ((Dictionary<System.Int32Enum, bool>)(object)enemyPoolStates).TryInsert((System.Int32Enum)0, false, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ stack_-58_v3+1C]");
			object obj6 = default(object);
			object obj7 = default(object);
			object obj8 = default(object);
			System.Int32Enum key2 = default(System.Int32Enum);
			if (obj2 == null)
			{
				while (true)
				{
					obj6 = obj6;
					while (true)
					{
						if (obj7 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ stack_-98_v12+1C]");
							if (obj8 == null)
							{
								object obj9 = obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ stack_-98_v12+18]");
								if ((nint)obj9 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ stack_-98_v12+10]");
									object obj10 = 0;
									obj6++;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rdx_v24+20+v310 @ r8_v18*8]");
									if ((nint)0 != 0)
									{
										break;
									}
									continue;
								}
							}
							if (obj7 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ stack_-98_v12+1C]");
								if (obj8 == null)
								{
									return;
								}
								System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
								object obj11 = 0;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					bool flag3 = _enemyPoolStates == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rdx_v24+20+v310 @ r8_v18*8]");
					EnemyType key = (EnemyType)((nint)0 >> 32);
					int num = _enemyPoolStates.FindEntry(key);
					System.Collections.Generic.InsertionBehavior behavior;
					bool value;
					if (!flag3)
					{
						behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
						value = true;
					}
					else
					{
						behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
						value = true;
					}
					bool flag4 = ((Dictionary<System.Int32Enum, bool>)(object)_enemyPoolStates).TryInsert(key2, value, behavior);
				}
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list2 = null;
		}
		throw new NullReferenceException();
	}

	public void UpdateEnemyPools(List<EnemyType?> enemies, List<EnemyType?> bosses)
	{
		//IL_0648: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_0113: Expected O, but got I
		//IL_01af: Expected O, but got I
		//IL_0526: Expected I, but got O
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_028d: Expected O, but got I
		//IL_0580: Expected O, but got I4
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_0382: Expected O, but got I
		//IL_03f7: Expected O, but got I
		//IL_05da: Expected O, but got I4
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		_enemyTypes = enemies;
		_bossTypes = bosses;
		Dictionary<EnemyType, bool>.KeyCollection keys = _enemyPoolStates.Keys;
		List<EnemyType> list = (List<EnemyType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)(object)keys);
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ stack_-88_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ stack_-88_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ stack_-88_v3+10]");
						object obj5 = 0;
						obj4++;
						Dictionary<EnemyType, bool> enemyPoolStates = _enemyPoolStates;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ rdx_v70+20+v912 @ rcx_v88*4]");
						bool flag = ((Dictionary<System.Int32Enum, bool>)(object)enemyPoolStates).TryInsert((System.Int32Enum)0, false, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ stack_-88_v3+1C]");
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ stack_-88_v3+18]");
				object obj6 = (nint)0 + (nint)1;
				Dictionary<EnemyType, bool>.KeyCollection keys2 = _bossPoolStates.Keys;
				List<EnemyType> list3 = (List<EnemyType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)(object)keys2);
				object obj7 = obj6;
				object obj8 = default(object);
				while (true)
				{
					if (obj8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ stack_-88_v27+1C]");
						if (obj2 == null)
						{
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ stack_-88_v27+18]");
							if ((nint)obj9 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ stack_-88_v27+10]");
								object obj10 = 0;
								object obj11 = obj7 + 1;
								Dictionary<EnemyType, bool> bossPoolStates = _bossPoolStates;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v763 @ rdx_v66+20+v748 @ stack_-80_v29*4]");
								bool flag3 = ((Dictionary<System.Int32Enum, bool>)(object)bossPoolStates).TryInsert((System.Int32Enum)0, false, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
								obj7 = obj11;
								continue;
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				bool flag4 = obj8 == null;
				nint num = 0;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ stack_-88_v27+1C]");
					object obj12 = default(object);
					object obj13 = default(object);
					object obj14 = default(object);
					object obj20 = default(object);
					System.Int32Enum key2 = default(System.Int32Enum);
					System.Int32Enum key4 = default(System.Int32Enum);
					if (obj2 == null)
					{
						while (true)
						{
							obj12 = obj12;
							while (true)
							{
								if (obj13 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-A0_v20+1C]");
									if (obj14 == null)
									{
										object obj15 = obj12;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-A0_v20+18]");
										if ((nint)obj15 < 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-A0_v20+10]");
											object obj16 = 0;
											obj12++;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdx_v57+20+v319 @ r8_v37*8]");
											if ((nint)0 != 0)
											{
												break;
											}
											continue;
										}
									}
									if (obj13 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-A0_v20+1C]");
										if (obj14 == null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ stack_-A0_v20+18]");
											object obj17 = (nint)0 + (nint)1;
											object obj18 = obj17;
											while (true)
											{
												object obj19 = obj18;
												while (true)
												{
													if (obj20 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ stack_-A0_v22+1C]");
														if (obj14 == null)
														{
															object obj21 = obj19;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ stack_-A0_v22+18]");
															if ((nint)obj21 < 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ stack_-A0_v22+10]");
																object obj22 = 0;
																obj19++;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1653 @ rdx_v49+20+v459 @ r8_v41*8]");
																if ((nint)0 != 0)
																{
																	break;
																}
																continue;
															}
														}
														if (obj20 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ stack_-A0_v22+1C]");
															if (obj14 == null)
															{
																return;
															}
															System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
															object obj23 = 0;
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												bool flag5 = _bossPoolStates == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1653 @ rdx_v49+20+v459 @ r8_v41*8]");
												EnemyType key = (EnemyType)((nint)0 >> 32);
												int num2 = _bossPoolStates.FindEntry(key);
												System.Collections.Generic.InsertionBehavior behavior;
												bool value;
												if (!flag5)
												{
													behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
													value = true;
												}
												else
												{
													behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
													value = true;
												}
												bool flag6 = ((Dictionary<System.Int32Enum, bool>)(object)_bossPoolStates).TryInsert(key2, value, behavior);
												obj18 = obj19;
											}
										}
										System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
										object obj24 = 0;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							bool flag7 = _enemyPoolStates == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ rdx_v57+20+v319 @ r8_v37*8]");
							EnemyType key3 = (EnemyType)((nint)0 >> 32);
							int num3 = _enemyPoolStates.FindEntry(key3);
							System.Collections.Generic.InsertionBehavior behavior2;
							bool value2;
							if (!flag7)
							{
								behavior2 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
								value2 = true;
							}
							else
							{
								behavior2 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
								value2 = true;
							}
							bool flag8 = ((Dictionary<System.Int32Enum, bool>)(object)_enemyPoolStates).TryInsert(key4, value2, behavior2);
						}
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list2 = null;
		}
		throw new NullReferenceException();
	}

	public unsafe Vector2? GetPickupPositionOutOfSight(float _movementAngle = 45f)
	{
		//IL_017f: Expected I, but got O
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01e2: Invalid comparison between F4 and O
		//IL_01f1: Expected F4, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_021e: Expected O, but got Ref
		//IL_021e: Expected O, but got Ref
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0129: Expected O, but got I4
		Stage stage = default(Stage);
		GameSessionData gameSessionData = stage._gameSessionData;
		if (stage._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Vector2 velocity = gameSessionData._activeCharacter.Velocity;
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v7 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			object obj = velocity - Vector2.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			object obj3 = default(object);
			object obj2 = obj3 - 0;
			object obj4 = obj * obj;
			object obj5 = obj2 * obj2;
			object obj6 = obj5 + obj4;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
			float inPlayerDirectionAngle = 0f;
			if (!flag)
			{
				float num3 = default(float);
				inPlayerDirectionAngle = num3;
			}
			if (!stage._hasWallsCheckDestructibleLogic)
			{
				GameSessionData gameSessionData2 = stage._gameSessionData;
				if (stage._gameSessionData != null)
				{
					Vector2 positionOutOfSight = stage.GetPositionOutOfSight(gameSessionData2._activeCharacter, inPlayerDirectionAngle);
					goto IL_01ff;
				}
			}
			else
			{
				object obj7 = 0;
				Rect spawnOuterRect = default(Rect);
				Rect spawnInnerRect = default(Rect);
				while (true)
				{
					Vector2 spawnPoint = MathTools.RandomOutside((Rect)(&spawnOuterRect), (Rect)(&spawnInnerRect));
					if ((object)stage._tilingTileset == null)
					{
						break;
					}
					if (stage._tilingTileset.IsPointWithinCollisionLayer(spawnPoint))
					{
						obj7++;
						bool flag2 = (nint)obj7 < 10;
						spawnOuterRect = stage._spawnOuterRect;
						spawnInnerRect = stage._spawnInnerRect;
						if (flag2)
						{
							continue;
						}
						goto IL_0120;
					}
					goto IL_01ff;
				}
			}
		}
		return (Vector2?)new NullReferenceException();
		IL_0120:
		Stage stage2 = (Stage)0;
		_ = 0;
		goto IL_0244;
		IL_0244:
		return (Vector2?)this;
		IL_01ff:
		object obj8 = default(object);
		stage2 = (Stage)obj8;
		goto IL_0244;
	}

	private void HandleDestructibleSpawning()
	{
		//IL_0221: Expected O, but got F4
		if (!_hasWallsCheckDestructibleLogic)
		{
			if (_hasTileSet)
			{
				List<Vector2> destructibleLocations = _destructibleLocations;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v7 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)0 > (nint)0)
				{
					SpawnWindowInRandomLocation();
					PropType destructibleType = DestructibleType;
					SpawnChosenDestructibleInRandomLocation(destructibleType);
					List<Vector2> cartLocations = _cartLocations;
					if (_cartLocations != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if ((nint)0 <= (nint)0)
						{
							return;
						}
					}
					object obj = UnityEngine.Random.value;
					GameSessionData gameSessionData = _gameSessionData;
					object obj2 = default(object);
					float num = (float)obj2 * 100f;
					float num2 = gameSessionData._activeCharacter.PLuck();
					float num3 = (float)obj2 * 50f;
					if (num3 < num)
					{
						return;
					}
					VampireSurvivors.Objects.Characters.CharacterController randomCharacter = GetRandomCharacter();
					List<Vector2> locationsOutOfSight = GetLocationsOutOfSight(_cartLocations, randomCharacter);
					if (locationsOutOfSight != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v22 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
							Vector2 pos = default(Vector2);
							Destructible destructible = MakeDestructible(PropType.CART, pos);
						}
					}
					return;
				}
			}
			PropType destructibleType2 = DestructibleType;
			SpawnChocenDestructibleOutOfSight(destructibleType2);
		}
		else
		{
			PropType destructibleType3 = DestructibleType;
			SpawnChosenDestructibleWallsCheck(destructibleType3);
		}
	}

	public void SpawnChosenDestructiblesInClosestLocations(PropType _propType, int number)
	{
		GameSessionData gameSessionData = _gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		Vector2 position2 = default(Vector2);
		SpawnChosenDestructiblesInClosestLocations(_propType, number, position2);
	}

	public void SpawnChosenDestructiblesInClosestLocations(PropType _propType, int number, Vector2 position)
	{
		//IL_0064: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_01f5: Expected O, but got F4
		//IL_00ac: Expected I, but got O
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00f1: Invalid comparison between F4 and O
		//IL_021c: Invalid comparison between O and F4
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_0112: Expected O, but got F4
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0190: Expected I, but got O
		_003C_003Ec__DisplayClass336_0 obj = new _003C_003Ec__DisplayClass336_0();
		Vector2 vector = default(Vector2);
		obj.position = vector;
		Comparison<Vector2> comparison = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D04D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4100");
		if (number <= 0)
		{
			return;
		}
		nint num = 0;
		object obj2 = 0;
		float num3 = default(float);
		float num2 = num3;
		Vector2 vector2 = vector;
		object obj3 = 0;
		object obj8 = default(object);
		Vector2 vector4 = default(Vector2);
		bool flag;
		do
		{
			object obj4 = UnityEngine.Random.value;
			StageData stageData = _stageData;
			GameSessionData gameSessionData = _gameSessionData;
			Stage activeCharacter = (Stage)(object)gameSessionData._activeCharacter;
			nint num4 = (nint)activeCharacter;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v443 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Stage>)+4E8] (should have been resolved before IL gen)");
			StageData stageData2 = _stageData;
			num2 = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
			Vector2 vector3 = vector2 * stageData._003CdestructibleChance_003Ek__BackingField;
			float num5 = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector3))
			{
				vector3 = (Vector2)stageData2._003CdestructibleChanceMax_003Ek__BackingField;
			}
			float num6 = (float)vector2 * 100f;
			if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
			{
				List<Vector2> destructibleLocations = _destructibleLocations;
				object obj5 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj6 = obj5 % 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				object obj7 = obj2 + 1;
				Vector2 defaultMapPosition = _tilingTileset.DefaultMapPosition;
				num2 = num3 + (float)obj8;
				Destructible destructible = MakeDestructible(_propType, vector4);
				num = (nint)vector4;
				obj2 = obj7;
				vector3 = vector4;
				activeCharacter = this;
			}
			obj3++;
			flag = (nint)obj3 < number;
			vector2 = vector3;
		}
		while (flag);
	}

	public void SortByDistance(Vector2 position)
	{
	}

	public void SpawnChosenDestructibleInRandomLocation(PropType _propType)
	{
		//IL_0162: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		StageData stageData = _stageData;
		GameSessionData gameSessionData = _gameSessionData;
		float num = gameSessionData._activeCharacter.PLuck();
		StageData stageData2 = _stageData;
		object obj2 = default(object);
		float num2 = (float)obj2 * 100f;
		float num3 = (float)obj2 * stageData._003CdestructibleChance_003Ek__BackingField;
		if (num3 > stageData2._003CdestructibleChanceMax_003Ek__BackingField)
		{
			num3 = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
		}
		if (num3 < num2)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController randomCharacter = GetRandomCharacter();
		List<Vector2> locationsOutOfSight = GetLocationsOutOfSight(_destructibleLocations, randomCharacter);
		if (locationsOutOfSight != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v13 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v13 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				int num4 = UnityEngine.Random.Range(0, 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Vector2 pos = default(Vector2);
				Destructible destructible = MakeDestructible(_propType, pos);
			}
		}
	}

	private void SpawnDestructibleInRandomLocation()
	{
		PropType destructibleType = DestructibleType;
		SpawnChosenDestructibleInRandomLocation(destructibleType);
	}

	public unsafe void SpawnChosenDestructibleWallsCheck(PropType _propType, bool force = false)
	{
		//IL_02a2: Expected O, but got F4
		//IL_0158: Expected I, but got O
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01a6: Invalid comparison between F4 and O
		//IL_031e: Invalid comparison between O and F4
		//IL_0331: Expected O, but got F4
		//IL_01c7: Expected O, but got F4
		//IL_01e7: Expected O, but got Ref
		//IL_01e7: Expected O, but got Ref
		//IL_0226: Expected O, but got F4
		//IL_0253: Expected O, but got F4
		//IL_033a->IL02f0: Incompatible stack heights: 6 vs 0
		//IL_022f->IL02f0: Incompatible stack heights: 7 vs 0
		//IL_025d->IL02f0: Incompatible stack heights: 7 vs 0
		List<VampireSurvivors.Objects.Characters.CharacterController> groupedPlayersBasedOnDistance = GetGroupedPlayersBasedOnDistance();
		List<VampireSurvivors.Objects.Characters.CharacterController> list = groupedPlayersBasedOnDistance;
		object obj = null;
		List<VampireSurvivors.Objects.Characters.CharacterController> list2 = groupedPlayersBasedOnDistance;
		List<VampireSurvivors.Objects.Characters.CharacterController> list3 = groupedPlayersBasedOnDistance;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj4 = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			object obj2 = null;
			Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> spawnOuterRects = _spawnOuterRects;
			bool flag = _spawnOuterRects == null;
			int num = _spawnOuterRects.FindEntry((VampireSurvivors.Objects.Characters.CharacterController)null);
			if (num >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdi_v4 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
				bool flag2 = (nint)0 == 0;
				Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> spawnInnerRects = _spawnInnerRects;
				bool flag3 = _spawnInnerRects == null;
				int num2 = _spawnInnerRects.FindEntry((VampireSurvivors.Objects.Characters.CharacterController)null);
				if (num2 < 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdi_v16 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
				bool flag4 = (nint)0 == 0;
				object obj3 = UnityEngine.Random.value;
				float num3 = (float)list2 * 100f;
				StageData stageData = _stageData;
				bool flag5 = _stageData == null;
				nint num4 = (nint)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v809 @ rdx_v28 (Il2CppClass<System.Object>)+4E8] (should have been resolved before IL gen)");
				StageData stageData2 = _stageData;
				bool flag6 = _stageData == null;
				list2 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(list2 * stageData._003CdestructibleChance_003Ek__BackingField);
				float num5 = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>, UIntPtr>(ref list2))
				{
					list2 = (List<VampireSurvivors.Objects.Characters.CharacterController>)stageData2._003CdestructibleChanceMax_003Ek__BackingField;
				}
				if (force)
				{
					num3 = -1f;
				}
				bool flag7 = System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>, UIntPtr>(ref list2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3);
				obj = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
				if (!flag7)
				{
					Vector2 vector = MathTools.RandomOutside((Rect)(&list), (Rect)(&obj4));
					bool flag8 = (object)_tilingTileset == null;
					bool flag9 = _tilingTileset.IsPointWithinCollisionLayer(vector);
					obj = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
					if (!flag9)
					{
						Destructible destructible = MakeDestructible(_propType, vector);
						obj = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
						list3 = null;
					}
				}
				continue;
			}
			System.ThrowHelper.ThrowKeyNotFoundException((object)null);
			throw new IndexOutOfRangeException();
		}
		System.ThrowHelper.ThrowKeyNotFoundException((object)null);
		throw new IndexOutOfRangeException();
	}

	private unsafe void SpawnChosenDestructibleWallsCheckForPlayer(VampireSurvivors.Objects.Characters.CharacterController player, Rect spawnOuterRect, Rect spawnInnerRect, PropType _propType, bool force)
	{
		//IL_00e4: Expected O, but got F4
		//IL_0099: Expected O, but got Ref
		//IL_0099: Expected O, but got Ref
		object obj = UnityEngine.Random.value;
		StageData stageData = _stageData;
		object obj2 = default(object);
		float num = (float)obj2 * 100f;
		float num2 = player.PLuck();
		StageData stageData2 = _stageData;
		float num3 = (float)obj2 * stageData._003CdestructibleChance_003Ek__BackingField;
		bool flag = num3 == stageData2._003CdestructibleChanceMax_003Ek__BackingField;
		if (num3 > stageData2._003CdestructibleChanceMax_003Ek__BackingField)
		{
			num3 = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
		}
		if (!flag)
		{
			num = -1f;
		}
		if (!(num3 < num))
		{
			object obj3 = default(object);
			object obj4 = default(object);
			Vector2 vector = MathTools.RandomOutside((Rect)(&obj3), (Rect)(&obj4));
			if (!_tilingTileset.IsPointWithinCollisionLayer(vector))
			{
				PropType destructibleType = default(PropType);
				Destructible destructible = MakeDestructible(destructibleType, vector);
			}
		}
	}

	private void SpawnDestructibleWallsCheck()
	{
		PropType destructibleType = DestructibleType;
		SpawnChosenDestructibleWallsCheck(destructibleType);
	}

	private void SpawnCartInRandomLocation()
	{
		//IL_0142: Expected O, but got F4
		List<Vector2> cartLocations = _cartLocations;
		if (_cartLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				return;
			}
		}
		object obj = UnityEngine.Random.value;
		GameSessionData gameSessionData = _gameSessionData;
		object obj2 = default(object);
		float num = (float)obj2 * 100f;
		float num2 = gameSessionData._activeCharacter.PLuck();
		float num3 = (float)obj2 * 50f;
		if (num3 < num)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController randomCharacter = GetRandomCharacter();
		List<Vector2> locationsOutOfSight = GetLocationsOutOfSight(_cartLocations, randomCharacter);
		if (locationsOutOfSight != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
				Vector2 pos = default(Vector2);
				Destructible destructible = MakeDestructible(PropType.CART, pos);
			}
		}
	}

	private VampireSurvivors.Objects.Characters.CharacterController GetRandomCharacter()
	{
		//IL_0153: Expected O, but got I4
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
			bool flag = enumerable == null;
			List<object> list = new List<object>(enumerable);
			Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__344_0;
			if (_003C_003Ec._003C_003E9__344_0 == null)
			{
				match = (Predicate<object>)(_003C_003Ec._003C_003E9__344_0 = (PlayerInfo player) => (object)player == null || ((UnityEngine.Object)player).m_CachedPtr == (IntPtr)0);
			}
			int num = list.RemoveAll(match);
			object obj = UnityEngine.Random.RandomRangeInt(0, list._size);
			bool flag2 = (nint)obj >= list._size;
			object[] items = list._items;
			return ((PlayerInfo)items[obj]).CharacterController;
		}
		return GM.Core.PlayerOne;
	}

	private void SpawnWindowInRandomLocation()
	{
		//IL_0155: Expected O, but got F4
		List<Vector2> windowLocations = _windowLocations;
		if (_windowLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				return;
			}
		}
		object obj = UnityEngine.Random.value;
		GameSessionData gameSessionData = _gameSessionData;
		object obj2 = default(object);
		float num = (float)obj2 * 100f;
		float num2 = gameSessionData._activeCharacter.PLuck();
		float num3 = (float)obj2 * 50f;
		if (num3 < num)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
		List<Vector2> locationsOutOfSight = GetLocationsOutOfSight(_windowLocations, playerOne);
		if (locationsOutOfSight != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v17 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
				Vector2 defaultMapPosition = _tilingTileset.DefaultMapPosition;
				Vector2 pos = default(Vector2);
				Destructible destructible = MakeDestructible(PropType.WINDOW, pos);
			}
		}
	}

	public Destructible SpawnPropInRandomLocation(float baseChance, PropType propType, ref List<Vector2> positions)
	{
		//IL_015e: Expected O, but got F4
		List<Vector2> list = positions;
		if (positions != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0124;
			}
		}
		object obj = UnityEngine.Random.value;
		GameSessionData gameSessionData = _gameSessionData;
		object obj2 = default(object);
		float num = (float)obj2 * 100f;
		float num2 = gameSessionData._activeCharacter.PLuck();
		float num3 = (float)obj2 * baseChance;
		if (!(num3 < num))
		{
			VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
			List<Vector2> locationsOutOfSight = GetLocationsOutOfSight(positions, playerOne);
			if (locationsOutOfSight != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v18 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
					Vector2 defaultMapPosition = _tilingTileset.DefaultMapPosition;
					Vector2 pos = default(Vector2);
					return MakeDestructible(propType, pos);
				}
			}
		}
		goto IL_0124;
		IL_0124:
		return null;
	}

	public List<Destructible> SpawnPropInAllLocations(PropType propType, ref List<Vector2> positions)
	{
		List<Destructible> list = new List<Destructible>();
		List<Vector2> list2 = positions;
		if (positions != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_019a;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
		List<Vector2> locationsOutOfSight = GetLocationsOutOfSight(positions, playerOne);
		if (locationsOutOfSight != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v15 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
				object obj2 = default(object);
				Vector2 pos = default(Vector2);
				while (enumerator.MoveNext())
				{
					if ((object)_tilingTileset != null)
					{
						Vector2 defaultMapPosition = _tilingTileset.DefaultMapPosition;
						object obj = obj2 + obj2;
						Destructible destructible = MakeDestructible(propType, pos);
						if ((object)destructible != null && ((UnityEngine.Object)destructible).m_CachedPtr != (IntPtr)0)
						{
							bool flag = list == null;
							TilingTileset typeFromHandle = (TilingTileset)(object)typeof(UnityEngine.Object);
							if (flag)
							{
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2070");
						}
						continue;
					}
					throw new NullReferenceException();
				}
			}
		}
		goto IL_019a;
		IL_019a:
		return list;
	}

	public int ActivateProps(PropType propType, ref List<SuperObject> scripts)
	{
		//IL_0209->IL02d6: Incompatible stack heights: 4 vs 0
		//IL_015b->IL01e1: Incompatible stack heights: 6 vs 4
		//IL_0239->IL02d6: Incompatible stack heights: 5 vs 0
		//IL_01a2->IL01e1: Incompatible stack heights: 7 vs 4
		//IL_01e1->IL01e1: Incompatible stack heights: 8 vs 4
		ref List<SuperObject> reference = default(ref List<SuperObject>);
		List<SuperObject> list = reference;
		if (reference != null)
		{
			if (list._size <= 0)
			{
				return 0;
			}
			List<SuperObject>.Enumerator enumerator = default(List<SuperObject>.Enumerator);
			List<SuperObject> list2 = default(List<SuperObject>);
			while (enumerator.MoveNext())
			{
				Transform transform = ((Component)null).transform;
				bool flag = (object)transform == null;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag3 = (object)_tilingTileset == null;
				Vector2 defaultMapPosition = _tilingTileset.DefaultMapPosition;
				Destructible destructible = MakeDestructible(propType, (Vector2)list2);
				TilingTileset tilingTileset = _tilingTileset;
				bool flag4 = (object)_tilingTileset == null;
				if (tilingTileset._inverted)
				{
					bool flag5 = _playerOptions == null;
					PlayerOptionsData config = _playerOptions.Config;
					bool flag6 = config == null;
					if (config._003CVisuallyInvertStages_003Ek__BackingField)
					{
						StageData stageData = _stageData;
						bool flag7 = _stageData == null;
						if (stageData._003CallowVisualInversion_003Ek__BackingField)
						{
							bool flag8 = (object)destructible == null;
							float2 position = destructible.position;
							destructible.position = (float2)list2;
						}
					}
				}
				if ((bool)destructible)
				{
					bool flag9 = (object)destructible == null;
					destructible.OnDestructibleSpawned(null);
				}
			}
			List<SuperObject> list3 = reference;
			if (reference != null)
			{
				return list3._size;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe List<Vector2> GetLocationsOutOfSight(List<Vector2> locations, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0053: Expected O, but got Ref
		//IL_00a1: Expected O, but got I
		//IL_00fb: Expected O, but got I4
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_0223: Expected O, but got I4
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_020d: Expected O, but got I4
		List<Vector2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		List<Vector2> list2 = locations;
		List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
		object obj4 = default(object);
		List<Vector2> list3 = default(List<Vector2>);
		while (enumerator.MoveNext())
		{
			Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> spawnOuterRects = _spawnOuterRects;
			bool flag = _spawnOuterRects == null;
			List<Vector2>.Enumerator enumerator2 = (List<Vector2>.Enumerator)(&enumerator);
			object obj7;
			if (!flag)
			{
				int num = _spawnOuterRects.FindEntry(character);
				if (num >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v10 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v10 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v28+18]");
					if ((nint)num < (nint)0)
					{
						object obj2 = num << 5;
						if ((object)character != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [character @ r8 (VampireSurvivors.Objects.Characters.CharacterController)+5C]");
							object obj3 = obj4 + 0;
							Vector2 currentDefaultMapPosition = character.CurrentDefaultMapPosition;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v14+30+v338 @ rax_v28]");
							if ((nint)currentDefaultMapPosition >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v14+30+v338 @ rax_v28]");
								list2 = (List<Vector2>)(list3 + 0);
								List<Vector2> list4 = list2;
								Vector2 currentDefaultMapPosition2 = character.CurrentDefaultMapPosition;
								if (System.Runtime.CompilerServices.Unsafe.As<List<Vector2>, UIntPtr>(ref list4) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref currentDefaultMapPosition2))
								{
									bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<List<Vector2>, UIntPtr>(ref list3);
									list2 = list3;
									if (!flag2)
									{
										object obj5 = (object)list3 + (object)list3;
										bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
										object obj6 = obj5 - obj3;
										bool flag4 = obj6 == null;
										bool flag5 = !flag3;
										bool flag6 = !flag4;
										obj7 = flag6 & flag5;
										list2 = list3;
										goto IL_02c7;
									}
								}
							}
							obj7 = 0;
							goto IL_02c7;
						}
						throw new NullReferenceException();
					}
				}
				else
				{
					System.ThrowHelper.ThrowKeyNotFoundException((object)character);
				}
				throw new IndexOutOfRangeException();
			}
			throw new NullReferenceException();
			IL_02c7:
			if (obj7 == null)
			{
				if (list == null)
				{
					throw new NullReferenceException();
				}
				list.Add((Vector2)list3);
				list2 = list3;
			}
		}
		return list;
	}

	public void SpawnChocenDestructibleOutOfSight(PropType propType, bool force = false, float distance = 0f)
	{
		//IL_01a4: Expected O, but got F4
		//IL_0084: Expected I, but got O
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d2: Invalid comparison between F4 and O
		//IL_01d5: Invalid comparison between O and F4
		//IL_01e8: Expected O, but got F4
		//IL_00f3: Expected O, but got F4
		//IL_015b: Invalid comparison between F4 and O
		//IL_016a: Expected F4, but got I4
		//IL_0223: Expected I4, but got O
		//IL_01f1->IL022d: Incompatible stack heights: 2 vs 0
		//IL_022d->IL022d: Incompatible stack heights: 2 vs 0
		List<VampireSurvivors.Objects.Characters.CharacterController> groupedPlayersBasedOnDistance = GetGroupedPlayersBasedOnDistance();
		MissingMethodException ex = null;
		bool flag2 = default(bool);
		bool flag = flag2;
		List<VampireSurvivors.Objects.Characters.CharacterController> list = groupedPlayersBasedOnDistance;
		List<VampireSurvivors.Objects.Characters.CharacterController> list2 = groupedPlayersBasedOnDistance;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj3 = default(object);
		object obj5 = default(object);
		object obj6 = default(object);
		float distance2 = default(float);
		while (enumerator.MoveNext())
		{
			MissingMethodException ex2 = null;
			object obj = UnityEngine.Random.value;
			float num = (float)list * 100f;
			if (flag2)
			{
				num = -1f;
			}
			StageData stageData = _stageData;
			bool flag3 = _stageData == null;
			nint num2 = (nint)ex2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v454 @ rdx_v6 (Il2CppClass<System.MissingMethodException>)+4E8] (should have been resolved before IL gen)");
			StageData stageData2 = _stageData;
			bool flag4 = _stageData == null;
			list = (List<VampireSurvivors.Objects.Characters.CharacterController>)(list * stageData._003CdestructibleChance_003Ek__BackingField);
			float num3 = stageData2._003CdestructibleChanceMax_003Ek__BackingField;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) <= System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>, UIntPtr>(ref list))
			{
				list = (List<VampireSurvivors.Objects.Characters.CharacterController>)stageData2._003CdestructibleChanceMax_003Ek__BackingField;
			}
			bool flag5 = System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>, UIntPtr>(ref list) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
			ex = (MissingMethodException)stageData2._003CdestructibleChanceMax_003Ek__BackingField;
			if (!flag5)
			{
				Vector2 velocity = ((VampireSurvivors.Objects.Characters.CharacterController)null).Velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
				object obj2 = (object)velocity - obj3;
				object obj4 = obj5 - obj6;
				list = (List<VampireSurvivors.Objects.Characters.CharacterController>)(obj4 * obj4);
				object obj7 = obj2 * obj2;
				ex = (MissingMethodException)(object)(obj7 + (object)list);
				bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<MissingMethodException, UIntPtr>(ref ex);
				float inPlayerDirectionAngle = 0f;
				if (!flag6)
				{
					inPlayerDirectionAngle = 45f;
				}
				Vector2 positionOutOfSight = GetPositionOutOfSight(null, inPlayerDirectionAngle, distance2);
				Destructible destructible = MakeDestructible(propType, positionOutOfSight);
				flag = (byte)(int)positionOutOfSight != 0;
				list2 = null;
			}
		}
	}

	public bool IsCharacterNearYourPlayer(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_00d3: Expected O, but got I
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_019a: Expected O, but got I
		if ((object)character != null)
		{
			CoherenceSync coherenceSync = character._coherenceSync;
			if ((object)character._coherenceSync != null)
			{
				NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
				if (coherenceSync._003CEntityState_003Ek__BackingField == null)
				{
					goto IL_01f2;
				}
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					bool flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						bool flag2 = obj == null;
						flag = flag2;
					}
					if (flag)
					{
						goto IL_01f2;
					}
					Transform transform = character.transform;
					if ((object)transform != null)
					{
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						Vector3 vector = ret;
						Rect containmentExactRect = _containmentExactRect;
						if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentExactRect))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+148]");
							object obj2 = 0 + _containmentExactRect;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+144]");
								object obj3 = default(object);
								if ((nint)obj3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+14C]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stage)+144]");
									object obj4 = num + 0;
									bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
									object obj5 = obj4 - obj3;
									bool flag5 = obj5 == null;
									bool flag6 = !flag4;
									bool flag7 = !flag5;
									return flag7 & flag6;
								}
							}
						}
						return false;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_01f2:
		return true;
	}

	private List<VampireSurvivors.Objects.Characters.CharacterController> GetGroupedPlayersBasedOnDistance()
	{
		//IL_01b0: Expected O, but got I4
		//IL_01c1: Expected O, but got I4
		//IL_0519: Expected O, but got I4
		//IL_054e: Expected O, but got I
		//IL_05f8: Expected O, but got I4
		//IL_05c0: Expected O, but got I
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0760: Expected I, but got O
		//IL_0950: Expected I, but got O
		//IL_0438: Expected O, but got F8
		//IL_044f: Invalid comparison between F4 and O
		//IL_041e: Expected O, but got I4
		//IL_0888: Unknown result type (might be due to invalid IL or missing references)
		//IL_088d: Expected O, but got Unknown
		//IL_0138->IL072d: Incompatible stack heights: 1 vs 0
		//IL_016c->IL072d: Incompatible stack heights: 1 vs 0
		//IL_01a2->IL072d: Incompatible stack heights: 1 vs 0
		//IL_08e0->IL072d: Incompatible stack heights: 1 vs 0
		//IL_020e->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0923->IL072d: Incompatible stack heights: 1 vs 0
		//IL_023d->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0261->IL0713: Incompatible stack heights: 1 vs 0
		//IL_064c->IL072d: Incompatible stack heights: 1 vs 0
		//IL_05fe->IL08e5: Incompatible stack heights: 2 vs 1
		//IL_0290->IL072d: Incompatible stack heights: 1 vs 0
		//IL_05c6->IL08e5: Incompatible stack heights: 2 vs 1
		//IL_067b->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0307->IL0713: Incompatible stack heights: 2 vs 0
		//IL_06a0->IL0713: Incompatible stack heights: 1 vs 0
		//IL_06cf->IL072d: Incompatible stack heights: 1 vs 0
		//IL_0376->IL072d: Incompatible stack heights: 3 vs 0
		//IL_070e->IL070e: Incompatible stack heights: 2 vs 1
		//IL_0789->IL072d: Incompatible stack heights: 4 vs 0
		//IL_07e5->IL072d: Incompatible stack heights: 5 vs 0
		//IL_0845->IL072d: Incompatible stack heights: 6 vs 0
		//IL_04dc->IL072d: Incompatible stack heights: 7 vs 0
		//IL_048a->IL072d: Incompatible stack heights: 7 vs 0
		//IL_08b1->IL072d: Incompatible stack heights: 7 vs 0
		//IL_050a->IL08b6: Incompatible stack heights: 7 vs 1
		List<VampireSurvivors.Objects.Characters.CharacterController> list = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		Vector3 center = CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		List<List<VampireSurvivors.Objects.Characters.CharacterController>> list2 = new List<List<VampireSurvivors.Objects.Characters.CharacterController>>();
		List<VampireSurvivors.Objects.Characters.CharacterController> list3 = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = gameManager._mainCharacters;
			if (gameManager._mainCharacters != null)
			{
				if (mainCharacters._size <= 0)
				{
					goto IL_0713;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				if (mainCharacters._items != null)
				{
					bool flag = items.Length <= 0;
					if (list3 != null)
					{
						list3.AddWithResize(items[0]);
						if (list2 != null)
						{
							((List<VampireSurvivors.Objects.Characters.CharacterController>)(object)list2).AddWithResize((VampireSurvivors.Objects.Characters.CharacterController)(object)list3);
							GameManager gameManager2 = _gameManager;
							if ((object)_gameManager != null)
							{
								object obj = 1;
								List<VampireSurvivors.Objects.Characters.CharacterController> list4 = list3;
								object obj2 = 1;
								object obj8 = default(object);
								object obj9 = default(object);
								object obj10 = default(object);
								List<List<VampireSurvivors.Objects.Characters.CharacterController>>.Enumerator enumerator = default(List<List<VampireSurvivors.Objects.Characters.CharacterController>>.Enumerator);
								while (true)
								{
									List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = gameManager2._mainCharacters;
									if (gameManager2._mainCharacters == null)
									{
										break;
									}
									if ((nint)obj2 < mainCharacters2._size)
									{
										GameManager gameManager3 = _gameManager;
										if ((object)_gameManager == null)
										{
											break;
										}
										List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters3 = gameManager3._mainCharacters;
										if (gameManager3._mainCharacters == null)
										{
											break;
										}
										if ((nint)obj < mainCharacters3._size)
										{
											VampireSurvivors.Objects.Characters.CharacterController[] items2 = mainCharacters3._items;
											if (mainCharacters3._items == null)
											{
												break;
											}
											bool flag2 = (nint)obj >= items2.Length;
											object obj3 = items2[obj];
											GameManager gameManager4 = _gameManager;
											List<List<VampireSurvivors.Objects.Characters.CharacterController>> mainCharacters4 = (List<List<VampireSurvivors.Objects.Characters.CharacterController>>)(object)gameManager4._mainCharacters;
											object obj4 = obj - 1;
											if ((nint)obj4 < mainCharacters4._size)
											{
												List<VampireSurvivors.Objects.Characters.CharacterController>[] items3 = mainCharacters4._items;
												object obj5 = obj - 1;
												bool flag3 = (nint)obj5 >= items3.Length;
												List<List<VampireSurvivors.Objects.Characters.CharacterController>> list5 = (List<List<VampireSurvivors.Objects.Characters.CharacterController>>)(object)items3[obj5];
												if (items3[obj5] == null)
												{
													break;
												}
												bool flag4 = list5._items == null;
												IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)list5._items);
												Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
												if ((object)transform == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v89 (UnityEngine.Transform)+10]");
												bool flag5 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v89 (UnityEngine.Transform)+10]");
												Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
												if ((object)items2[obj] == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r13_v20 (System.Object)+10]");
												bool flag6 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r13_v20 (System.Object)+10]");
												IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
												Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
												if ((object)transform2 == null)
												{
													break;
												}
												bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
												object obj6 = ret - ret2;
												object obj7 = obj8 - obj9;
												nint num = (nint)typeof(Math);
												float num2 = (float)obj10 * 2f;
												object obj11 = obj7 * obj7;
												object obj12 = obj6 * obj6;
												double d = (double)obj11 + (double)obj12;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v73 (Il2CppClass<System.Math>)+E4]");
												if ((nint)0 <= (nint)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
													center = (Vector3)0;
												}
												else
												{
													double num3 = Math.Sqrt(d);
													center = (Vector3)num3;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
												if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref center))
												{
													List<VampireSurvivors.Objects.Characters.CharacterController> list6 = new List<VampireSurvivors.Objects.Characters.CharacterController>();
													if (list6 == null)
													{
														break;
													}
													list6.AddWithResize(items2[obj]);
													((List<VampireSurvivors.Objects.Characters.CharacterController>)(object)list2).AddWithResize((VampireSurvivors.Objects.Characters.CharacterController)(object)list6);
													list4 = list6;
												}
												else
												{
													if (list4 == null)
													{
														break;
													}
													list4.AddWithResize(items2[obj]);
												}
												obj++;
												gameManager2 = _gameManager;
												if ((object)_gameManager == null)
												{
													break;
												}
												obj2 = obj;
												continue;
											}
										}
										goto IL_0713;
									}
									while (enumerator.MoveNext())
									{
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1176 @ rax_v69+18]");
										bool flag8 = (nint)0 <= (nint)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1176 @ rax_v69+10]");
										object obj14 = 0;
										int version = list._version + 1;
										list._version = version;
										List<VampireSurvivors.Objects.Characters.CharacterController> items4 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)list._items;
										if (list._size >= items4._size)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rcx_v51+20]");
											((List<object>)(object)list).AddWithResize((object)0);
										}
										else
										{
											int size = list._size + 1;
											list._size = size;
											items4.AddWithResize((VampireSurvivors.Objects.Characters.CharacterController)list._size);
										}
									}
									if (list == null)
									{
										break;
									}
									if (list._size == 0)
									{
										GameManager gameManager5 = _gameManager;
										if ((object)_gameManager == null)
										{
											break;
										}
										List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters5 = gameManager5._mainCharacters;
										if (gameManager5._mainCharacters == null)
										{
											break;
										}
										if (mainCharacters5._size <= 0)
										{
											goto IL_0713;
										}
										VampireSurvivors.Objects.Characters.CharacterController[] items5 = mainCharacters5._items;
										if (mainCharacters5._items == null)
										{
											break;
										}
										bool flag9 = items5.Length <= 0;
										list.AddWithResize(items5[0]);
									}
									return list;
								}
							}
						}
					}
				}
			}
		}
		goto IL_072d;
		IL_0713:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_072d;
		IL_072d:
		throw new NullReferenceException();
	}

	private void SpawnDestructibleOutOfSight(bool force = false)
	{
		PropType destructibleType = DestructibleType;
		SpawnChocenDestructibleOutOfSight(destructibleType, force);
	}

	private unsafe void DespawnFarDestructibles(ObjectPool pool)
	{
		//IL_0027: Expected O, but got I
		//IL_02ee: Expected O, but got I4
		//IL_0093: Expected O, but got I
		//IL_00a3: Expected O, but got I
		//IL_0120: Expected O, but got I
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_0167->IL02b4: Incompatible stack heights: 6 vs 0
		//IL_010a->IL02b4: Incompatible stack heights: 5 vs 0
		Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v26 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v26 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		object obj = num - 0;
		List<VampireSurvivors.Objects.Characters.CharacterController> groupedPlayersBasedOnDistance = GetGroupedPlayersBasedOnDistance();
		List<Vector2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<VampireSurvivors.Objects.Characters.CharacterController> item = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
		while (enumerator.MoveNext())
		{
			object obj2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v16 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v16 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			List<VampireSurvivors.Objects.Characters.CharacterController> ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			bool flag4 = list == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v52+18]");
			nint num3;
			if (num2 >= 0)
			{
				list.AddWithResize((Vector2)item);
				num3 = 0;
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj5 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v28 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v52+18]");
			bool flag6 = num4 >= 0;
			num3 = 0;
		}
		while (true)
		{
			object obj6 = _003CMaxDestructibles_003Ek__BackingField * groupedPlayersBasedOnDistance._size;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
				break;
			}
			GameObject gameObject = MathTools.FurthestGameObject(list, pool._aliveObjects);
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				Destructible component = gameObject.GetComponent<Destructible>();
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					component.Despawn();
					obj--;
				}
				continue;
			}
			break;
		}
	}

	private void HandleSpawning(bool checkMaxEnemyCount = true)
	{
		if ((checkMaxEnemyCount && !CanSpawnEnemies()) || _disableMinueteSpawning)
		{
			return;
		}
		if (_spawnType == SpawnType.HORIZONTAL)
		{
			if (!_hasTileSet)
			{
				goto IL_0205;
			}
			List<Vector2> enemySpawnLocations = _enemySpawnLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v18 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				SpawnEnemiesInRandomLocationHorizontal();
				return;
			}
		}
		if (_spawnType == SpawnType.HORIZONTAL_SMOOTHED)
		{
			if (!_hasTileSet)
			{
				goto IL_0205;
			}
			List<Vector2> enemySpawnLocations2 = _enemySpawnLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				SpawnEnemiesInRandomLocationHorizontalSmoothed();
				return;
			}
		}
		if (_spawnType == SpawnType.VERTICAL)
		{
			if (!_hasTileSet)
			{
				goto IL_0205;
			}
			List<Vector2> enemySpawnLocations3 = _enemySpawnLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v14 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				SpawnEnemiesInRandomLocationVertical();
				return;
			}
		}
		if (_spawnType != SpawnType.TILED)
		{
			if (_spawnType != SpawnType.MAPPED)
			{
				goto IL_0205;
			}
			SpawnEnemiesMapped();
			return;
		}
		SpawnEnemiesTiled();
		return;
		IL_0205:
		if (SpawnEnemiesInOuterRect())
		{
			SwarmCheck();
		}
	}

	private bool HasReachedMaxEnemies()
	{
		bool flag = CanSpawnEnemies();
		return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
	}

	private bool SpawnEnemiesInOuterRect()
	{
		//IL_01f2: Expected I4, but got O
		//IL_0095: Expected O, but got I
		//IL_019b: Expected O, but got I4
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		if (CanSpawnEnemies())
		{
			if (_enemyTypes != null)
			{
				bool result = false;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj4 = default(object);
				EnemyType poolName = default(EnemyType);
				while (true)
				{
					object obj = obj2;
					while (true)
					{
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v3+1C]");
							if (obj4 == null)
							{
								object obj5 = obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v3+18]");
								if ((nint)obj5 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v3+10]");
									object obj6 = 0;
									obj++;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rdx_v10+20+v182 @ r8_v5*8]");
									if ((nint)0 != 0)
									{
										break;
									}
									continue;
								}
							}
							if (obj3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-28_v3+1C]");
								if (obj4 == null)
								{
									return result;
								}
								System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
								object obj7 = 0;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rdx_v10+20+v182 @ r8_v5*8]");
					System.Int32Enum key = (System.Int32Enum)((nint)0 >> 32);
					bool flag = ((Dictionary<System.Int32Enum, bool>)(object)_enemyPoolStates).get_Item(key);
					bool flag2 = !flag;
					obj2 = obj;
					if (!flag2)
					{
						GameObject gameObject = SpawnOneUnitInOuterRect(poolName, checkWalls: true, forceSpawn: true);
						bool flag3 = gameObject;
						obj2 = obj;
						result = flag3;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private bool CanSpawnEnemies()
	{
		//IL_014e: Expected I4, but got O
		//IL_00db: Expected O, but got I4
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected I4, but got Unknown
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				int permanentEnemiesNumber = PermanentEnemiesNumber;
				if (permanentEnemiesNumber < _maximum)
				{
					return true;
				}
				return false;
			}
			if ((object)OnlineStageManager._instance != null)
			{
				int numberOfConnectedPlayers = OnlineStageManager._instance.NumberOfConnectedPlayers;
				HashSet<EnemyController> authoritativePermanentEnemies = _authoritativePermanentEnemies;
				if (_authoritativePermanentEnemies != null)
				{
					int num = _maximum / numberOfConnectedPlayers;
					object obj = authoritativePermanentEnemies._count - num;
					int num2 = authoritativePermanentEnemies._count ^ num;
					int num3 = authoritativePermanentEnemies._count ^ obj;
					int num4 = num2 & num3;
					bool flag = num4 < 0;
					bool flag2 = (nint)obj < 0;
					return flag2 != flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void SpawnEnemiesTiled()
	{
		//IL_008e: Expected I4, but got O
		//IL_00a1: Expected F4, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_0168->IL02d2: Incompatible stack heights: 3 vs 0
		//IL_01f7->IL02d2: Incompatible stack heights: 3 vs 0
		//IL_0201->IL021a: Incompatible stack heights: 3 vs 0
		if (!CanSpawnEnemies())
		{
			return;
		}
		VampireSurvivors.App.Tools.Extensions.Shuffle(_tiledPositions);
		List<EnemyType> allEnabledPools = GetAllEnabledPools();
		if (allEnabledPools != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			if ((nint)0 != 0)
			{
				bool flag = (byte)(int)_tiledPositions != 0;
				float num = 0f;
				List<Vector2>.Enumerator tiledPositions = (List<Vector2>.Enumerator)_tiledPositions;
				object obj = 0;
				List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
				object obj3 = default(object);
				object obj4 = default(object);
				bool flag5 = default(bool);
				bool includeStatic = default(bool);
				Group specificGroup = default(Group);
				EnemyType enemyType = default(EnemyType);
				List<Vector2>.Enumerator enumerator2 = default(List<Vector2>.Enumerator);
				while (enumerator.MoveNext())
				{
					bool flag2 = (object)_mainCamera == null;
					Transform transform = _mainCamera.transform;
					bool flag3 = (object)transform == null;
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					float num2 = (float)ret / 0.32f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
					float num3 = num2 * 0.32f;
					object obj2 = obj3 + obj4;
					tiledPositions = (List<Vector2>.Enumerator)(obj2 / 0.32f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
					float num4 = (float)tiledPositions * 0.32f;
					List<BaseBody> list = ArcadePhysics.s_instance.OverlapCirc(num3, num4, 0.01f, flag5, includeStatic, specificGroup);
					bool flag6 = list._size > 0;
					float num5 = num4;
					float num6 = 0.01f;
					num = num3;
					if (!flag6)
					{
						object obj5 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
						object obj6 = obj5 % 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
						GameObject gameObject = SpawnEnemy(enemyType, (Vector2)enumerator2, asRemote: false, flag5);
						obj++;
						bool flag7 = CanSpawnEnemies();
						num5 = num4;
						num6 = 0.01f;
						num = num3;
						tiledPositions = enumerator2;
						flag = false;
						if (!flag7)
						{
							break;
						}
					}
				}
				return;
			}
		}
		Debug.LogWarning("Enemy Pools are empty when trying to SpawnEnemiesTiled");
	}

	private unsafe void SpawnEnemiesMapped()
	{
		//IL_0032: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_02ed: Invalid comparison between F4 and I4
		//IL_0076: Expected O, but got Ref
		//IL_0076: Expected O, but got Ref
		//IL_0092: Expected F4, but got I4
		//IL_0092: Expected F4, but got O
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		if (!CanSpawnEnemies())
		{
			return;
		}
		int spawnData = GetSpawnData(out var currentEnemies, out var minimumEnemies);
		List<EnemyType?>.Enumerator enumerator = (List<EnemyType?>.Enumerator)0;
		int num = currentEnemies;
		object obj = 0;
		Rect rect = default(Rect);
		Rect rect2 = default(Rect);
		EnemyType enemyType = default(EnemyType);
		Vector2 vector2 = default(Vector2);
		bool forceSpawn = default(bool);
		List<EnemyType?>.Enumerator enumerator2 = default(List<EnemyType?>.Enumerator);
		while (minimumEnemies > (float)num && (nint)obj < spawnData)
		{
			Vector2 vector = MathTools.RandomOutside((Rect)(&rect), (Rect)(&rect2));
			SuperTile spawningLayerTile = _tilingTileset.GetSpawningLayerTile((float)vector, (float)enemyType);
			if ((object)spawningLayerTile != null && ((UnityEngine.Object)spawningLayerTile).m_CachedPtr != (IntPtr)0)
			{
				int num2 = spawningLayerTile.m_TileId + 1;
				StageData stageData = _stageData;
				List<PoolsMapping> list = stageData._003CpoolsMapping_003Ek__BackingField;
				if (num2 < list._size)
				{
					StageData stageData2 = _stageData;
					PoolsMapping poolsMapping = stageData2._003CpoolsMapping_003Ek__BackingField.get_Item(num2);
					GameObject gameObject = SpawnEnemy(poolsMapping._003Ctype_003Ek__BackingField, vector2, asRemote: false, forceSpawn);
				}
			}
			else
			{
				if (_tilingTileset.IsPointWithinCollisionLayer(vector2))
				{
					obj++;
					continue;
				}
				while (enumerator.MoveNext())
				{
				}
				enumerator = enumerator2;
			}
			obj++;
			int num3 = UpdateCurrentEnemies();
			num = num3;
		}
	}

	private int UpdateCurrentEnemies()
	{
		//IL_00a2: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				return PermanentEnemiesNumber;
			}
			HashSet<EnemyController> authoritativePermanentEnemies = _authoritativePermanentEnemies;
			if (_authoritativePermanentEnemies != null)
			{
				return authoritativePermanentEnemies._count;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe int GetSpawnData(out int currentEnemies, out float minimumEnemies)
	{
		//IL_0158: Expected I4, but got O
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected I4, but got Unknown
		StageData stageData = _stageData;
		int num;
		int num2;
		if (_stageData != null)
		{
			num = _maximum;
			object obj = stageData._003Cminimum_003Ek__BackingField * _minMultiplier;
			num2 = (int)(obj * _onlineEnemyMultiplier);
			int permanentEnemiesNumber = PermanentEnemiesNumber;
			ref int reference = ref *(int*)permanentEnemiesNumber;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._multiplayer != null)
			{
				if (!core._multiplayer.IsOnlineMultiplayer)
				{
					goto IL_0181;
				}
				if ((object)OnlineStageManager._instance != null)
				{
					int numberOfConnectedPlayers = OnlineStageManager._instance.NumberOfConnectedPlayers;
					num2 /= numberOfConnectedPlayers;
					if ((object)OnlineStageManager._instance != null)
					{
						int numberOfConnectedPlayers2 = OnlineStageManager._instance.NumberOfConnectedPlayers;
						int num3 = _maximum / numberOfConnectedPlayers2;
						HashSet<EnemyController> authoritativePermanentEnemies = _authoritativePermanentEnemies;
						if (_authoritativePermanentEnemies != null)
						{
							reference = ref *(int*)authoritativePermanentEnemies._count;
							num = num3;
							goto IL_0181;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_0181:
		if (num2 > num)
		{
			num2 = num;
		}
		ref float reference2 = ref *(float*)num2;
		return num;
	}

	private List<EnemyType> GetAllEnabledPools()
	{
		List<EnemyType> list = new List<EnemyType>();
		Dictionary<EnemyType, bool>.Enumerator enumerator = default(Dictionary<EnemyType, bool>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			if (obj != null)
			{
				bool flag = list == null;
				nint num = 0;
				if (flag)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF90");
			}
		}
		return list;
	}

	private void SpawnEnemiesInRandomLocationHorizontal()
	{
		//IL_0020: Expected O, but got I4
		//IL_0171: Invalid comparison between F4 and I4
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		if (!CanSpawnEnemies())
		{
			return;
		}
		int spawnData = GetSpawnData(out var currentEnemies, out var minimumEnemies);
		object obj = 0;
		int num = currentEnemies;
		List<EnemyType?>.Enumerator enumerator = default(List<EnemyType?>.Enumerator);
		while (minimumEnemies > (float)num && (nint)obj < spawnData)
		{
			while (enumerator.MoveNext())
			{
				currentEnemies = 0;
			}
			obj++;
			num = UpdateCurrentEnemies();
		}
	}

	private void SpawnEnemiesInRandomLocationHorizontalSmoothed()
	{
		//IL_0020: Expected O, but got I4
		//IL_0171: Invalid comparison between F4 and I4
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		if (!CanSpawnEnemies())
		{
			return;
		}
		int spawnData = GetSpawnData(out var currentEnemies, out var minimumEnemies);
		object obj = 0;
		int num = currentEnemies;
		List<EnemyType?>.Enumerator enumerator = default(List<EnemyType?>.Enumerator);
		while (minimumEnemies > (float)num && (nint)obj < spawnData)
		{
			while (enumerator.MoveNext())
			{
				currentEnemies = 0;
			}
			obj++;
			num = UpdateCurrentEnemies();
		}
	}

	private void SpawnEnemiesInRandomLocationVertical()
	{
		//IL_0020: Expected O, but got I4
		//IL_0171: Invalid comparison between F4 and I4
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		if (!CanSpawnEnemies())
		{
			return;
		}
		int spawnData = GetSpawnData(out var currentEnemies, out var minimumEnemies);
		object obj = 0;
		int num = currentEnemies;
		List<EnemyType?>.Enumerator enumerator = default(List<EnemyType?>.Enumerator);
		while (minimumEnemies > (float)num && (nint)obj < spawnData)
		{
			while (enumerator.MoveNext())
			{
				currentEnemies = 0;
			}
			obj++;
			num = UpdateCurrentEnemies();
		}
	}

	public void SwarmCheck()
	{
		//IL_003d: Invalid comparison between F4 and I4
		//IL_004f: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00af: Invalid comparison between F4 and I4
		//IL_0097: Expected O, but got I4
		if (!CanSpawnEnemies())
		{
			return;
		}
		int spawnData = GetSpawnData(out var currentEnemies, out var minimumEnemies);
		bool flag = !(minimumEnemies > (float)currentEnemies);
		object obj = 0;
		if (flag)
		{
			return;
		}
		while ((nint)obj < spawnData)
		{
			bool flag2 = SpawnEnemiesInOuterRect();
			obj++;
			if (flag2)
			{
				obj = 0;
			}
			int num = UpdateCurrentEnemies();
			if (!(minimumEnemies > (float)num))
			{
				break;
			}
		}
	}

	private unsafe EnemyController SpawnEnemyUnit(ObjectPool pool, EnemyType enemyType, Vector2 spawnPos, bool asRemote)
	{
		//IL_0020: Expected O, but got Ref
		//IL_0020: Expected O, but got Ref
		if ((object)pool != null)
		{
			object obj2 = default(object);
			object obj3 = default(object);
			GameObject obj = pool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
			EnemyController objectComponent = pool.GetObjectComponent<EnemyController>(obj);
			if ((object)objectComponent != null)
			{
				bool asRemote2 = default(bool);
				objectComponent.InitEnemy(enemyType, asRemote2);
				return objectComponent;
			}
		}
		return (EnemyController)(object)new NullReferenceException();
	}

	public void SpawnBoss()
	{
		//IL_008f: Expected O, but got I
		//IL_0299: Expected O, but got I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4 = default(object);
		EnemyType enemyType = default(EnemyType);
		while (true)
		{
			object obj = obj2;
			while (true)
			{
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v4+1C]");
					if (obj4 == null)
					{
						object obj5 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v4+18]");
						if ((nint)obj5 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v4+10]");
							object obj6 = 0;
							obj++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rdx_v11+20+v154 @ r8_v6*8]");
							if ((nint)0 != 0)
							{
								break;
							}
							continue;
						}
					}
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v4+1C]");
						if (obj4 == null)
						{
							return;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						object obj7 = 0;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rdx_v11+20+v154 @ r8_v6*8]");
			System.Int32Enum key = (System.Int32Enum)((nint)0 >> 32);
			bool flag = ((Dictionary<System.Int32Enum, bool>)(object)_bossPoolStates).get_Item(key);
			bool flag2 = !flag;
			obj2 = obj;
			if (flag2)
			{
				continue;
			}
			GameObject gameObject = SpawnEnemyUsingSpawnType(enemyType);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			component._003CIsTeleportOnCull_003Ek__BackingField = true;
			if (component._003CIsDefanged_003Ek__BackingField)
			{
				component._003CIsDefanged_003Ek__BackingField = false;
				component.RestoreTint();
			}
			bool flag3 = _hasAttachedTreasure;
			obj2 = obj;
			if (flag3)
			{
				continue;
			}
			StageData stageData = _stageData;
			bool flag4 = stageData._003Ctreasure_003Ek__BackingField == null;
			obj2 = obj;
			if (!flag4)
			{
				int num = SetTreasureLevelFromChance(stageData._003Ctreasure_003Ek__BackingField);
				bool flag5 = num <= 0;
				obj2 = obj;
				if (!flag5)
				{
					_hasAttachedTreasure = true;
					StageData stageData2 = _stageData;
					component.AttachTreasure(stageData2._003Ctreasure_003Ek__BackingField);
					obj2 = obj;
				}
			}
		}
	}

	public void SpawnBatGoblin()
	{
		//IL_102e: Expected O, but got F4
		//IL_103b: Invalid comparison between F4 and O
		//IL_0206: Invalid comparison between F4 and O
		//IL_03f7: Expected O, but got I
		//IL_0407: Expected O, but got I
		//IL_0481: Expected O, but got I
		//IL_0466: Expected O, but got I4
		//IL_0c83: Expected O, but got I
		//IL_0c93: Expected O, but got I
		//IL_04eb: Expected O, but got I
		//IL_04d0: Expected O, but got I4
		//IL_0cdb: Expected O, but got I
		//IL_0ceb: Expected O, but got I
		//IL_0555: Expected O, but got I
		//IL_053a: Expected O, but got I4
		//IL_0d33: Expected O, but got I
		//IL_0d43: Expected O, but got I
		//IL_05bf: Expected O, but got I
		//IL_05a4: Expected O, but got I4
		//IL_0d8b: Expected O, but got I
		//IL_0d9b: Expected O, but got I
		//IL_062a: Expected O, but got I
		//IL_060e: Expected O, but got I4
		//IL_0749: Expected O, but got I
		//IL_0759: Expected O, but got I
		//IL_09f1: Expected O, but got I
		//IL_0a01: Expected O, but got I
		//IL_07d3: Expected O, but got I
		//IL_06a3: Expected O, but got I4
		//IL_06b1: Expected O, but got I4
		//IL_07b8: Expected O, but got I4
		//IL_06c4: Expected O, but got I4
		//IL_06d2: Expected O, but got I4
		//IL_0e09: Expected O, but got I
		//IL_0e19: Expected O, but got I
		//IL_0a7b: Expected O, but got I
		//IL_06e5: Expected O, but got I4
		//IL_0f69: Expected O, but got I
		//IL_0f79: Expected O, but got I
		//IL_083d: Expected O, but got I
		//IL_0822: Expected O, but got I4
		//IL_0e61: Expected O, but got I
		//IL_0e71: Expected O, but got I
		//IL_0ae5: Expected O, but got I
		//IL_0fc1: Expected O, but got I
		//IL_0fd1: Expected O, but got I
		//IL_08a7: Expected O, but got I
		//IL_088c: Expected O, but got I4
		//IL_0eb9: Expected O, but got I
		//IL_0ec9: Expected O, but got I
		//IL_0b4f: Expected O, but got I
		//IL_0911: Expected O, but got I
		//IL_08f6: Expected O, but got I4
		//IL_0f11: Expected O, but got I
		//IL_0f21: Expected O, but got I
		//IL_0983: Expected O, but got I
		//IL_0960: Expected O, but got I4
		GameManager core = GM.Core;
		EnemyType enemyType;
		bool flag3;
		bool flag4;
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				ArcanaManager arcanaManager = core2._arcanaManager;
				if (core2._arcanaManager != null)
				{
					core = (GameManager)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
					if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
					{
						GameManager core3 = GM.Core;
						ArcanaManager arcanaManager2 = core3._arcanaManager;
						core = GM.Core;
						bool flag = (nint)((MonoBehaviour)core).m_CancellationTokenSource < arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField;
						float num = 0.1f;
						if (!flag)
						{
							num = 0.05f;
						}
						if (core._characters != null)
						{
							float num2 = 0.2f;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								GameManager gameManager = null;
								core = null;
								throw new NullReferenceException();
							}
							object obj = UnityEngine.Random.value;
							float num3 = num;
							List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) <= System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>, UIntPtr>(ref characters))
							{
								List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core._characters;
								bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>, UIntPtr>(ref characters2);
								enemyType = EnemyType.EX_BATGOBLIN;
								flag3 = false;
								flag4 = false;
								if (!flag2)
								{
									enemyType = EnemyType.EX_TREASURE_VICIOUSHUNGER;
									flag3 = true;
									flag4 = false;
								}
							}
							else
							{
								bool flag5 = (nint)((MonoBehaviour)core).m_CancellationTokenSource < arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField;
								enemyType = EnemyType.EX_BATGOBLIN2;
								flag3 = false;
								flag4 = true;
								if (!flag5)
								{
									core = GM.Core;
									if ((object)GM.Core != null)
									{
										core = (GameManager)(object)core._arcanaManager;
										if (core._arcanaManager != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ rcx_v10 (VampireSurvivors.Framework.GameManager)+DC]");
											_ = (nint)0 + (nint)1;
											enemyType = EnemyType.EX_BATGOBLIN2;
											flag3 = false;
											flag4 = true;
											goto IL_0c30;
										}
									}
									goto IL_0b89;
								}
							}
							goto IL_0c30;
						}
					}
				}
			}
		}
		goto IL_0b89;
		IL_0dce:
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		list._002Ector();
		bool flag6 = list == null;
		core = (GameManager)(object)list;
		List<PrizeType?> list2;
		EnemyController component;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			core = (GameManager)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v31+18]");
				if (num4 >= 0)
				{
					list.AddWithResize(0.5f);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj3 = (nint)0 + (nint)1;
					_ = 1056964608;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
				core = (GameManager)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdx_v32+18]");
					if (num5 >= 0)
					{
						list.AddWithResize(2f);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
						object obj5 = (nint)0 + (nint)1;
						_ = 1073741824;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
					core = (GameManager)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdx_v33+18]");
						if (num6 >= 0)
						{
							list.AddWithResize(100f);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1613 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
							object obj7 = (nint)0 + (nint)1;
							_ = 1120403456;
						}
						if (treasure != null)
						{
							treasure._003Cchances_003Ek__BackingField = list;
							treasure._003CprizeTypes_003Ek__BackingField = list2;
							treasure._003ChasRandoms_003Ek__BackingField = flag3;
							treasure._003ChasArcana_003Ek__BackingField = flag4;
							component._treasure = treasure;
							component._hasATreasure = true;
							return;
						}
					}
				}
			}
		}
		goto IL_0b89;
		IL_0b89:
		throw new NullReferenceException();
		IL_0c30:
		GameObject gameObject = SpawnEnemyUsingSpawnType(enemyType);
		bool flag7 = (object)gameObject == null;
		core = (GameManager)(object)this;
		if (!flag7)
		{
			component = gameObject.GetComponent<EnemyController>();
			bool flag8 = (object)component == null;
			core = (GameManager)(object)gameObject;
			if (!flag8)
			{
				component._003CIsTeleportOnCull_003Ek__BackingField = true;
				if (component._003CIsDefanged_003Ek__BackingField)
				{
					component._003CIsDefanged_003Ek__BackingField = false;
					component.RestoreTint();
				}
				List<PrizeType?> list3 = new List<PrizeType?>();
				bool flag9 = list3 == null;
				core = (GameManager)(object)list3;
				if (!flag9)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
					core = (GameManager)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdx_v18+18]");
						if (num7 >= 0)
						{
							list3.AddWithResize((PrizeType?)(object)1);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
							object obj9 = (nint)0 + (nint)1;
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
						core = (GameManager)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v20+18]");
							if (num8 >= 0)
							{
								list3.AddWithResize((PrizeType?)(object)1);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
								object obj11 = (nint)0 + (nint)1;
								_ = 1;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
							object obj12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
							core = (GameManager)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
								nint num9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v22+18]");
								if (num9 >= 0)
								{
									list3.AddWithResize((PrizeType?)(object)1);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									object obj13 = (nint)0 + (nint)1;
									_ = 1;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
								object obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
								core = (GameManager)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									nint num10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v24+18]");
									if (num10 >= 0)
									{
										list3.AddWithResize((PrizeType?)(object)1);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										object obj15 = (nint)0 + (nint)1;
										_ = 1;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
									object obj16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									core = (GameManager)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										nint num11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v26+18]");
										if (num11 >= 0)
										{
											list3.AddWithResize((PrizeType?)(object)1);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v40 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											object obj17 = (nint)0 + (nint)1;
											_ = 1;
										}
										if (!flag4)
										{
											bool flag10 = !flag3;
											list2 = list3;
											if (!flag10)
											{
												List<PrizeType?> list4 = new List<PrizeType?>();
												bool flag11 = list4 == null;
												core = (GameManager)(object)list4;
												if (flag11)
												{
													goto IL_0b89;
												}
												list4.Add((PrizeType?)(object)1);
												list4.Add((PrizeType?)(object)1);
												list4.Add((PrizeType?)(object)1);
												list4.Add((PrizeType?)(object)1);
												list4.Add((PrizeType?)(object)1);
												list2 = list4;
											}
											goto IL_0dce;
										}
										List<PrizeType?> list5 = new List<PrizeType?>();
										bool flag12 = list5 == null;
										core = (GameManager)(object)list5;
										if (!flag12)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
											object obj18 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											core = (GameManager)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
												nint num12 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v44+18]");
												if (num12 >= 0)
												{
													list5.AddWithResize((PrizeType?)(object)1);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													object obj19 = (nint)0 + (nint)1;
													_ = 1;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
												object obj20 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
												core = (GameManager)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													nint num13 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v46+18]");
													if (num13 >= 0)
													{
														list5.AddWithResize((PrizeType?)(object)1);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
														object obj21 = (nint)0 + (nint)1;
														_ = 1;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
													object obj22 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													core = (GameManager)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
														nint num14 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v48+18]");
														if (num14 >= 0)
														{
															list5.AddWithResize((PrizeType?)(object)1);
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
															object obj23 = (nint)0 + (nint)1;
															_ = 1;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
														_ = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
														object obj24 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
														core = (GameManager)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
															nint num15 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v50+18]");
															if (num15 >= 0)
															{
																list5.AddWithResize((PrizeType?)(object)1);
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																object obj25 = (nint)0 + (nint)1;
																_ = 1;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
															object obj26 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
															core = (GameManager)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																nint num16 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdx_v52+18]");
																if (num16 >= 0)
																{
																	list5.AddWithResize((PrizeType?)(object)1);
																	list2 = list5;
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1569 @ rax_v84 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																	object obj27 = (nint)0 + (nint)1;
																	_ = 1;
																	list2 = list5;
																}
																goto IL_0dce;
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
		goto IL_0b89;
	}

	public EnemyController SpawnMadMoonBlinder()
	{
		//IL_0b7c: Expected I, but got O
		//IL_004b: Expected I, but got O
		//IL_00bc: Expected I, but got O
		//IL_00c1: Expected I, but got O
		//IL_0fe2: Expected O, but got F4
		//IL_0fef: Invalid comparison between F4 and O
		//IL_0bee: Expected I, but got O
		//IL_01c0: Expected I, but got O
		//IL_0240: Expected I, but got O
		//IL_0271: Expected O, but got I
		//IL_02fb: Expected O, but got I
		//IL_02e0: Expected O, but got I4
		//IL_0c1f: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_0370: Expected O, but got I4
		//IL_0c77: Expected O, but got I
		//IL_041b: Expected O, but got I
		//IL_0400: Expected O, but got I4
		//IL_0ccf: Expected O, but got I
		//IL_04ab: Expected O, but got I
		//IL_0490: Expected O, but got I4
		//IL_0d27: Expected O, but got I
		//IL_053b: Expected O, but got I
		//IL_0520: Expected O, but got I4
		//IL_0902: Expected I, but got O
		//IL_059c: Expected I, but got O
		//IL_0933: Expected O, but got I
		//IL_05cd: Expected O, but got I
		//IL_09bd: Expected O, but got I
		//IL_0657: Expected O, but got I
		//IL_0f18: Expected O, but got I
		//IL_063c: Expected O, but got I4
		//IL_0da0: Expected O, but got I
		//IL_0a4d: Expected O, but got I
		//IL_06e7: Expected O, but got I
		//IL_0f70: Expected O, but got I
		//IL_06cc: Expected O, but got I4
		//IL_0df8: Expected O, but got I
		//IL_0add: Expected O, but got I
		//IL_0777: Expected O, but got I
		//IL_075c: Expected O, but got I4
		//IL_0e50: Expected O, but got I
		//IL_0807: Expected O, but got I
		//IL_07ec: Expected O, but got I4
		//IL_0ea8: Expected O, but got I
		//IL_089f: Expected O, but got I
		//IL_087c: Expected O, but got I4
		//IL_02e5->IL0bfc: Incompatible stack heights: 0 vs 1
		//IL_0c4f->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0375->IL0c54: Incompatible stack heights: 1 vs 2
		//IL_0ca7->IL0b47: Incompatible stack heights: 2 vs 0
		//IL_0405->IL0cac: Incompatible stack heights: 2 vs 3
		//IL_0cff->IL0b47: Incompatible stack heights: 3 vs 0
		//IL_0495->IL0d04: Incompatible stack heights: 3 vs 4
		//IL_0d57->IL0b47: Incompatible stack heights: 4 vs 0
		//IL_0525->IL0d5c: Incompatible stack heights: 4 vs 5
		//IL_090b->IL0b47: Incompatible stack heights: 5 vs 0
		//IL_05a5->IL0b47: Incompatible stack heights: 5 vs 0
		//IL_0963->IL0b47: Incompatible stack heights: 5 vs 0
		//IL_05fd->IL0b47: Incompatible stack heights: 5 vs 0
		//IL_09a7->IL0ef5: Incompatible stack heights: 5 vs 6
		//IL_0f48->IL0b47: Incompatible stack heights: 6 vs 0
		//IL_0641->IL0d7d: Incompatible stack heights: 5 vs 6
		//IL_0dd0->IL0b47: Incompatible stack heights: 6 vs 0
		//IL_0a37->IL0f4d: Incompatible stack heights: 6 vs 7
		//IL_0fa0->IL0b47: Incompatible stack heights: 7 vs 0
		//IL_06d1->IL0dd5: Incompatible stack heights: 6 vs 7
		//IL_0e28->IL0b47: Incompatible stack heights: 7 vs 0
		//IL_0ac7->IL0fa5: Incompatible stack heights: 7 vs 8
		//IL_0fbd->IL0b47: Incompatible stack heights: 8 vs 0
		//IL_0761->IL0e2d: Incompatible stack heights: 7 vs 8
		//IL_0e80->IL0b47: Incompatible stack heights: 8 vs 0
		//IL_0b3d->IL0fd4: Incompatible stack heights: 8 vs 0
		//IL_07f1->IL0e85: Incompatible stack heights: 8 vs 9
		//IL_0ed8->IL0b47: Incompatible stack heights: 9 vs 0
		//IL_08e2->IL0edd: Incompatible stack heights: 10 vs 5
		//IL_0889->IL0edd: Incompatible stack heights: 9 vs 5
		bool flag = (object)GM.Core == null;
		nint num = (nint)GM.Core;
		EnemyController enemyController;
		bool flag3;
		List<PrizeType?> list2;
		if (!flag)
		{
			if (!GM.Core.IsStageHost)
			{
				enemyController = null;
				goto IL_0fd4;
			}
			nint num2 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rax_v21 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			num = 0;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._characters != null)
			{
				float num3 = 0.2f;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					nint num4 = unchecked((nint)null);
					num = unchecked((nint)null);
					throw new NullReferenceException();
				}
				object obj = UnityEngine.Random.value;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) <= System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>, UIntPtr>(ref characters);
				flag3 = false;
				if (!flag2)
				{
					flag3 = true;
				}
				GameObject gameObject = SpawnEnemyUsingSpawnType(EnemyType.BOSS_BLINDER_NORMAL);
				bool flag4 = (object)gameObject == null;
				num = (nint)this;
				if (!flag4)
				{
					enemyController = gameObject.GetComponent<EnemyController>();
					bool flag5 = (object)enemyController == null;
					num = (nint)gameObject;
					if (!flag5)
					{
						enemyController._003CIsTeleportOnCull_003Ek__BackingField = true;
						if (enemyController._003CIsDefanged_003Ek__BackingField)
						{
							enemyController._003CIsDefanged_003Ek__BackingField = false;
							enemyController.RestoreTint();
						}
						List<PrizeType?> list = new List<PrizeType?>();
						bool flag6 = list == null;
						num = (nint)list;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v17+18]");
								if (num5 >= 0)
								{
									list.AddWithResize((PrizeType?)(object)1);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									object obj3 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v17+18]");
									bool flag7 = num6 >= 0;
									_ = 1;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
								num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v19+18]");
									if (num7 >= 0)
									{
										list.AddWithResize((PrizeType?)(object)1);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										object obj5 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										nint num8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v19+18]");
										bool flag8 = num8 >= 0;
										_ = 1;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v21+18]");
										if (num9 >= 0)
										{
											list.AddWithResize((PrizeType?)(object)1);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											object obj7 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											nint num10 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v21+18]");
											bool flag9 = num10 >= 0;
											_ = 1;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
										num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											nint num11 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v23+18]");
											if (num11 >= 0)
											{
												list.AddWithResize((PrizeType?)(object)1);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
												object obj9 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
												nint num12 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v23+18]");
												bool flag10 = num12 >= 0;
												_ = 1;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
											object obj10 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
											num = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
												nint num13 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v25+18]");
												if (num13 >= 0)
												{
													list.AddWithResize((PrizeType?)(object)1);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													object obj11 = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													nint num14 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v25+18]");
													bool flag11 = num14 >= 0;
													_ = 1;
												}
												bool flag12 = !flag3;
												list2 = list;
												if (flag12)
												{
													goto IL_0edd;
												}
												List<PrizeType?> list3 = new List<PrizeType?>();
												bool flag13 = list3 == null;
												num = (nint)list3;
												if (!flag13)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
													object obj12 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
													num = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
														nint num15 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v43+18]");
														if (num15 >= 0)
														{
															list3.AddWithResize((PrizeType?)(object)1);
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
															object obj13 = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
															nint num16 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v43+18]");
															bool flag14 = num16 >= 0;
															_ = 1;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
														_ = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
														object obj14 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
														num = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
															nint num17 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v45+18]");
															if (num17 >= 0)
															{
																list3.AddWithResize((PrizeType?)(object)1);
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																object obj15 = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																nint num18 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v45+18]");
																bool flag15 = num18 >= 0;
																_ = 1;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
															object obj16 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
															num = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																nint num19 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v47+18]");
																if (num19 >= 0)
																{
																	list3.AddWithResize((PrizeType?)(object)1);
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																	object obj17 = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																	nint num20 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v47+18]");
																	bool flag16 = num20 >= 0;
																	_ = 1;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
																_ = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
																object obj18 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																num = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																	nint num21 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v49+18]");
																	if (num21 >= 0)
																	{
																		list3.AddWithResize((PrizeType?)(object)1);
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																		object obj19 = (nint)0 + (nint)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																		nint num22 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v49+18]");
																		bool flag17 = num22 >= 0;
																		_ = 1;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
																	_ = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
																	object obj20 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																	num = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																		nint num23 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v51+18]");
																		if (num23 >= 0)
																		{
																			list3.AddWithResize((PrizeType?)(object)1);
																			list2 = list3;
																		}
																		else
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																			object obj21 = (nint)0 + (nint)1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ rax_v81 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
																			nint num24 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v51+18]");
																			bool flag18 = num24 >= 0;
																			_ = 1;
																			list2 = list3;
																		}
																		goto IL_0edd;
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
		goto IL_0b47;
		IL_0fd4:
		return enemyController;
		IL_0b47:
		throw new NullReferenceException();
		IL_0edd:
		Treasure treasure = new Treasure();
		List<float> list4 = new List<float>();
		list4._002Ector();
		bool flag19 = list4 == null;
		num = (nint)list4;
		if (!flag19)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
			num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v30+18]");
				if (num25 >= 0)
				{
					list4.AddWithResize(0.5f);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj23 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v30+18]");
					bool flag20 = num26 >= 0;
					_ = 1056964608;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
				num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v31+18]");
					if (num27 >= 0)
					{
						list4.AddWithResize(2f);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
						object obj25 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
						nint num28 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v31+18]");
						bool flag21 = num28 >= 0;
						_ = 1073741824;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
						nint num29 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v32+18]");
						if (num29 >= 0)
						{
							list4.AddWithResize(100f);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
							object obj27 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v47 (System.Collections.Generic.List`1<System.Single>)+18]");
							nint num30 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v32+18]");
							bool flag22 = num30 >= 0;
							_ = 1120403456;
						}
						if (treasure != null)
						{
							treasure._003Cchances_003Ek__BackingField = list4;
							treasure._003CprizeTypes_003Ek__BackingField = list2;
							treasure._003ChasRandoms_003Ek__BackingField = flag3;
							enemyController._treasure = treasure;
							enemyController._hasATreasure = true;
							goto IL_0fd4;
						}
					}
				}
			}
		}
		goto IL_0b47;
	}

	private GameObject SpawnEnemyUsingSpawnType(EnemyType enemyType)
	{
		//IL_032d->IL008d: Incompatible stack heights: 1 vs 0
		if (_spawnType == SpawnType.HORIZONTAL)
		{
			if (!_hasTileSet)
			{
				goto IL_0205;
			}
			List<Vector2> enemySpawnLocations = _enemySpawnLocations;
			if (_enemySpawnLocations == null)
			{
				goto IL_02a6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v30 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				return SpawnOneUnitInRandomLocationHorizontal(enemyType);
			}
		}
		if (_spawnType == SpawnType.HORIZONTAL_SMOOTHED)
		{
			if (!_hasTileSet)
			{
				goto IL_0205;
			}
			List<Vector2> enemySpawnLocations2 = _enemySpawnLocations;
			if (_enemySpawnLocations == null)
			{
				goto IL_02a6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				return SpawnOneUnitInRandomLocationHorizontalSmoothed(enemyType);
			}
		}
		if (_spawnType == SpawnType.VERTICAL)
		{
			if (!_hasTileSet)
			{
				goto IL_0205;
			}
			List<Vector2> enemySpawnLocations3 = _enemySpawnLocations;
			if (_enemySpawnLocations == null)
			{
				goto IL_02a6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v25 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				return SpawnOneUnitInRandomLocationVertical(enemyType);
			}
		}
		if (_spawnType != SpawnType.TILED)
		{
			goto IL_0205;
		}
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 playerPos = default(Vector2);
				Vector2 positionOutOfSight = GetPositionOutOfSight(playerPos);
				bool forceSpawn = default(bool);
				return SpawnEnemy(enemyType, positionOutOfSight, asRemote: false, forceSpawn);
			}
		}
		goto IL_02a6;
		IL_0205:
		return SpawnOneUnitInOuterRect(enemyType);
		IL_02a6:
		throw new NullReferenceException();
	}

	private unsafe GameObject SpawnOneUnitInOuterRect(EnemyType poolName, bool checkWalls = false, bool forceSpawn = false)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_008b: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		//IL_00a6: Expected O, but got Ref
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		object obj = default(object);
		Rect inner = (Rect)(obj - 56);
		_ = _spawnInnerRect;
		Rect outer = (Rect)(obj - 40);
		_ = _spawnOuterRect;
		Vector2 vector = MathTools.RandomOutside(outer, inner);
		bool flag = IsPointWithinOtherPlayerRects(vector);
		bool flag2 = !flag;
		Vector2 vector2 = vector;
		Vector2 vector3 = vector;
		object obj2 = 0;
		if (!flag2)
		{
			Rect spawnOuterRect = default(Rect);
			Rect spawnInnerRect = default(Rect);
			bool flag4;
			do
			{
				bool flag3 = (nint)obj2 >= 20;
				vector2 = vector3;
				if (flag3)
				{
					break;
				}
				Vector2 vector4 = MathTools.RandomOutside((Rect)(&spawnOuterRect), (Rect)(&spawnInnerRect));
				obj2++;
				flag4 = IsPointWithinOtherPlayerRects(vector4);
				vector2 = vector4;
				spawnOuterRect = _spawnOuterRect;
				spawnInnerRect = _spawnInnerRect;
				vector3 = vector4;
			}
			while (flag4);
		}
		if (checkWalls && _hasTileSet)
		{
			if ((object)_tilingTileset == null)
			{
				return (GameObject)(object)new NullReferenceException();
			}
			if (_tilingTileset.IsPointWithinCollisionLayer(vector2))
			{
				return null;
			}
		}
		bool forceSpawn2 = default(bool);
		return SpawnEnemy(poolName, vector2, asRemote: false, forceSpawn2);
	}

	private unsafe bool IsPointWithinOtherPlayerRects(Vector2 point)
	{
		//IL_0036: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	private GameObject SpawnOneUnitInRandomLocationHorizontal(EnemyType poolName, bool forceSpawn = false)
	{
		//IL_0039: Expected O, but got I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		Vector2 horizontalSpawnPosition = GetHorizontalSpawnPosition();
		bool flag = IsPointWithinOtherPlayerRects(horizontalSpawnPosition);
		bool flag2 = !flag;
		Vector2 vector = horizontalSpawnPosition;
		object obj = 0;
		Vector2 spawnPos = horizontalSpawnPosition;
		if (!flag2)
		{
			bool flag4;
			do
			{
				bool flag3 = (nint)obj >= 20;
				spawnPos = vector;
				if (flag3)
				{
					break;
				}
				Vector2 horizontalSpawnPosition2 = GetHorizontalSpawnPosition();
				obj++;
				flag4 = IsPointWithinOtherPlayerRects(horizontalSpawnPosition2);
				vector = horizontalSpawnPosition2;
				spawnPos = horizontalSpawnPosition2;
			}
			while (flag4);
		}
		bool forceSpawn2 = default(bool);
		return SpawnEnemy(poolName, spawnPos, asRemote: false, forceSpawn2);
	}

	private GameObject SpawnOneUnitInRandomLocationHorizontalSmoothed(EnemyType poolName, bool forceSpawn = false)
	{
		//IL_0039: Expected O, but got I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		Vector2 horizontalSmoothedSpawnPosition = GetHorizontalSmoothedSpawnPosition();
		bool flag = IsPointWithinOtherPlayerRects(horizontalSmoothedSpawnPosition);
		bool flag2 = !flag;
		Vector2 vector = horizontalSmoothedSpawnPosition;
		object obj = 0;
		Vector2 spawnPos = horizontalSmoothedSpawnPosition;
		if (!flag2)
		{
			bool flag4;
			do
			{
				bool flag3 = (nint)obj >= 20;
				spawnPos = vector;
				if (flag3)
				{
					break;
				}
				Vector2 horizontalSmoothedSpawnPosition2 = GetHorizontalSmoothedSpawnPosition();
				obj++;
				flag4 = IsPointWithinOtherPlayerRects(horizontalSmoothedSpawnPosition2);
				vector = horizontalSmoothedSpawnPosition2;
				spawnPos = horizontalSmoothedSpawnPosition2;
			}
			while (flag4);
		}
		bool forceSpawn2 = default(bool);
		return SpawnEnemy(poolName, spawnPos, asRemote: false, forceSpawn2);
	}

	private Vector2 GetHorizontalSpawnPosition()
	{
		//IL_006e: Expected O, but got F4
		//IL_0077: Invalid comparison between F4 and O
		//IL_0042: Expected O, but got I4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
		}
		List<Vector2> enemySpawnLocations = _enemySpawnLocations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj3 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		bool flag = (nint)obj3 >= 0;
		Vector2 result = default(Vector2);
		return result;
	}

	private Vector2 GetHorizontalSmoothedSpawnPosition()
	{
		//IL_015f: Expected O, but got F4
		//IL_0168: Invalid comparison between F4 and O
		//IL_0131: Expected O, but got I4
		//IL_0042: Expected O, but got I
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_009d: Expected F4, but got I
		//IL_00ee: Expected F4, but got I
		//IL_00fe: Expected F4, but got I
		//IL_00d9: Expected F4, but got I
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
		}
		List<Vector2> enemySpawnLocations = _enemySpawnLocations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj3 = UnityEngine.Random.RandomRangeInt(0, 0);
		List<Vector2> enemySpawnLocations2 = _enemySpawnLocations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		bool flag = (nint)obj3 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
		object obj4 = 0;
		object obj5 = obj3 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj6 = obj5 % 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		bool flag2 = (nint)obj6 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v2+24+v262 @ rdx_v5*8]");
		float maxInclusive = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v2+24+v162 @ rax_v10*8]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v2+24+v262 @ rdx_v5*8]");
		float minInclusive;
		if (num <= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v2+24+v162 @ rax_v10*8]");
			minInclusive = 0f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v2+24+v262 @ rdx_v5*8]");
			minInclusive = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v2+24+v162 @ rax_v10*8]");
			maxInclusive = 0f;
		}
		float num2 = UnityEngine.Random.Range(minInclusive, maxInclusive);
		Vector2 result = default(Vector2);
		return result;
	}

	private GameObject SpawnOneUnitInRandomLocationVertical(EnemyType poolName, bool forceSpawn = false)
	{
		//IL_0039: Expected O, but got I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		Vector2 verticalSpawnPosition = GetVerticalSpawnPosition();
		bool flag = IsPointWithinOtherPlayerRects(verticalSpawnPosition);
		bool flag2 = !flag;
		Vector2 vector = verticalSpawnPosition;
		object obj = 0;
		Vector2 spawnPos = verticalSpawnPosition;
		if (!flag2)
		{
			bool flag4;
			do
			{
				bool flag3 = (nint)obj >= 20;
				spawnPos = vector;
				if (flag3)
				{
					break;
				}
				Vector2 verticalSpawnPosition2 = GetVerticalSpawnPosition();
				obj++;
				flag4 = IsPointWithinOtherPlayerRects(verticalSpawnPosition2);
				vector = verticalSpawnPosition2;
				spawnPos = verticalSpawnPosition2;
			}
			while (flag4);
		}
		bool forceSpawn2 = default(bool);
		return SpawnEnemy(poolName, spawnPos, asRemote: false, forceSpawn2);
	}

	private Vector2 GetVerticalSpawnPosition()
	{
		//IL_006e: Expected O, but got F4
		//IL_0077: Invalid comparison between O and F4
		//IL_0042: Expected O, but got I4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
		{
		}
		List<Vector2> enemySpawnLocations = _enemySpawnLocations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj3 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		bool flag = (nint)obj3 >= 0;
		Vector2 result = default(Vector2);
		return result;
	}

	private GameObject SpawnOneUnitOutOfSight(EnemyType poolName)
	{
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 playerPos = default(Vector2);
				Vector2 positionOutOfSight = GetPositionOutOfSight(playerPos);
				bool forceSpawn = default(bool);
				return SpawnEnemy(poolName, positionOutOfSight, asRemote: false, forceSpawn);
			}
		}
		throw new NullReferenceException();
	}

	private void SpawnArcanaHolder()
	{
		//IL_005c: Expected I4, but got O
		StageData stageData = _stageData;
		if ((object)stageData._003CarcanaHolder_003Ek__BackingField == null)
		{
			return;
		}
		if ((object)stageData._003CarcanaHolder_003Ek__BackingField != null)
		{
			EnemyType enemyType = (EnemyType)((object?)stageData._003CarcanaHolder_003Ek__BackingField >> 32);
			GameObject gameObject = SpawnEnemyUsingSpawnType(enemyType);
			if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			EnemyController component = gameObject.GetComponent<EnemyController>();
			component._003CIsTeleportOnCull_003Ek__BackingField = true;
			StageData stageData2 = _stageData;
			if (stageData2._003CarcanaTreasure_003Ek__BackingField != null)
			{
				int num = SetTreasureLevelFromChance(stageData2._003CarcanaTreasure_003Ek__BackingField);
				if (num > 0)
				{
					StageData stageData3 = _stageData;
					Treasure treasure = stageData3._003CarcanaTreasure_003Ek__BackingField;
					treasure._003ChasArcana_003Ek__BackingField = true;
					StageData stageData4 = _stageData;
					component.AttachTreasure(stageData4._003CarcanaTreasure_003Ek__BackingField);
				}
			}
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	public Vector2 GetPositionWithinSight(VampireSurvivors.Objects.Characters.CharacterController player, float inPlayerDirectionAngle, float distance = 0f)
	{
		//IL_00ce: Invalid comparison between I4 and F4
		//IL_0157: Expected O, but got F4
		//IL_0183: Expected F4, but got I4
		//IL_018c: Expected F4, but got I4
		//IL_00ee: Expected O, but got F4
		//IL_0149: Expected F4, but got O
		//IL_00a5: Invalid comparison between F4 and I4
		//IL_01e2: Invalid comparison between F4 and I4
		float num5;
		if (0f < inPlayerDirectionAngle)
		{
			if ((object)player != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				object obj = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [player @ rdx (VampireSurvivors.Objects.Characters.CharacterController)+238]");
				float num = 0f - 0.5f;
				float num2 = num * ((float)Math.PI / 180f);
				float num3 = num2 * inPlayerDirectionAngle;
				float num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [player @ rdx (VampireSurvivors.Objects.Characters.CharacterController)+238]");
				num5 = num4 + 0f;
				float num6 = (float)player._lastFacingDirection;
				goto IL_004a;
			}
		}
		else
		{
			object obj2 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A10830h]\"");
			bool flag = (object)player == null;
			num5 = 0f;
			float num6 = 0f;
			if (!flag)
			{
				goto IL_004a;
			}
		}
		goto IL_00be;
		IL_004a:
		Transform transform = player.transform;
		if ((object)transform != null)
		{
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if (!(num5 < 0f))
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			if (num5 < 0f)
			{
			}
			Vector2 result = default(Vector2);
			return result;
		}
		goto IL_00be;
		IL_00be:
		throw new NullReferenceException();
	}

	private Vector2 GetPositionOutOfSight(Vector2 playerPos)
	{
		//IL_0058: Expected O, but got F4
		//IL_0036: Expected O, but got F4
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		object obj = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (UnityEngine.Bounds)+10]");
		float num = 0f * ((float)Math.PI * 2f);
		object obj2 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}

	public Vector2 GetPositionOutOfSight(VampireSurvivors.Objects.Characters.CharacterController player, float inPlayerDirectionAngle, float distance = 0f)
	{
		// ILSpy could not decompile this. Please report the exception below,
		// along with the assembly it came from, at https://github.com/icsharpcode/ILSpy/issues/new
		// System.IndexOutOfRangeException: Index was outside the bounds of the array.
		//    at ICSharpCode.Decompiler.IL.ILReader.ReadBlock(ImportedBlock block, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/IL/ILReader.cs:line 521
		//    at ICSharpCode.Decompiler.IL.ILReader.ReadInstructions(CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/IL/ILReader.cs:line 504
		//    at ICSharpCode.Decompiler.IL.ILReader.ReadIL(MethodDefinitionHandle method, MethodBodyBlock body, GenericContext genericContext, ILFunctionKind kind, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/IL/ILReader.cs:line 724
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext, ExtensionInfo extensionInfo) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 2282
	}

	private void UpdateCulling()
	{
		//IL_00f1: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_01d8: Expected O, but got I
		//IL_0222: Expected O, but got I
		if (_spawnedEnemies == null)
		{
			return;
		}
		List<EnemyController> spawnedEnemies = _spawnedEnemies;
		if (spawnedEnemies._size == 0)
		{
			return;
		}
		List<EnemyController> enemiesToCull = _enemiesToCull;
		int version = enemiesToCull._version + 1;
		enemiesToCull._version = version;
		enemiesToCull._size = 0;
		if (enemiesToCull._size > 0)
		{
			Array.Clear(enemiesToCull._items, 0, enemiesToCull._size);
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		bool flag = stage._spawnType == SpawnType.TILED;
		object obj = 100;
		if (!flag)
		{
			obj = 20;
		}
		object obj2 = default(object);
		object obj4 = default(object);
		for (int i = 0; i < (nint)obj; i++)
		{
			List<EnemyController> spawnedEnemies2 = _spawnedEnemies;
			if (_cullIterator % spawnedEnemies2._size == 0)
			{
				_cullIterator = 0;
			}
			int cullIterator = _cullIterator + 1;
			_cullIterator = cullIterator;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			if (obj2 == null)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v31+10]");
			if ((nint)0 == 0)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v31+28]");
			if ((nint)0 == 0)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v31+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v31+C8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ r14_v10+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v31+C8]");
					if (!((CoherenceSync)0).HasStateAuthority)
					{
						continue;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E69360");
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
			}
		}
		List<EnemyController> enemiesToCull2 = _enemiesToCull;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < enemiesToCull2._size)
			{
				List<EnemyController> enemiesToCull3 = _enemiesToCull;
				if (num >= enemiesToCull3._size)
				{
					break;
				}
				EnemyController[] items = enemiesToCull3._items;
				items[num].Despawn();
				num++;
				enemiesToCull2 = _enemiesToCull;
				num2 = num;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	[MethodImpl((MethodImplOptions)256)]
	private bool ShouldDespawnEnemyOutsideRect(EnemyController element)
	{
		//IL_0407: Expected I4, but got O
		//IL_026a: Expected O, but got I
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_032e: Expected O, but got I4
		//IL_0474: Expected O, but got I4
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
				if (mainCharacters._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new IndexOutOfRangeException();
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[0];
				if (characterController._multiplayerRevivalUI.IsVisible())
				{
					GameManager core3 = GM.Core;
					if (core3._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField > 0)
					{
						goto IL_03f3;
					}
				}
			}
			if (element._003CDontTeleportOnFreeRoam_003Ek__BackingField)
			{
				goto IL_03f3;
			}
		}
		if (element._003CIsCullable_003Ek__BackingField || element._003CIsTeleportOnCull_003Ek__BackingField)
		{
			BaseBody body = element.body;
			Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> playerRects = _playerRects;
			Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>.ValueCollection values = _playerRects.Values;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v27 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>+ValueCollection<VampireSurvivors.Objects.Characters.CharacterController, UnityEngine.Rect>)+10]");
			if ((nint)0 == 0)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = default(object);
			object obj4 = default(object);
			object obj10 = default(object);
			bool flag11;
			do
			{
				object obj7;
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ stack_-30_v9+2C]");
					if (obj4 == null)
					{
						while (true)
						{
							object obj5 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ stack_-30_v9+20]");
							if ((nint)obj5 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ stack_-30_v9+18]");
								object obj6 = 0;
								obj7 = obj + 1;
								object obj8 = obj << 5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rcx_v24+20+v427 @ rax_v40]");
								bool flag = (nint)0 < (nint)0;
								obj = obj7;
								if (flag)
								{
									continue;
								}
								goto IL_02b8;
							}
							break;
						}
						if (!element._003CIsTeleportOnCull_003Ek__BackingField)
						{
							return true;
						}
						if (element.CanEnemyTeleport())
						{
							element.OnTeleportOnCull();
						}
						break;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					playerRects = null;
				}
				throw new NullReferenceException();
				IL_02b8:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rcx_v24+30+v427 @ rax_v40]");
				object obj9 = obj10 + 0;
				object obj11 = obj10 + obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rsi_v12 (BaseBody)+54]");
				bool flag2 = 0 < (nint)obj10;
				bool flag3 = !flag2;
				float2 position = body._position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rcx_v24+30+v427 @ rax_v40]");
				bool flag4 = (nint)position < 0;
				bool flag5 = !flag4;
				playerRects = (Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>)(flag3 & flag5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rsi_v12 (BaseBody)+54]");
				bool flag6 = (nint)obj11 <= 0;
				Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> dictionary = null;
				if (!flag6)
				{
					dictionary = playerRects;
				}
				float2 position2 = body._position;
				bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position2);
				object obj12 = obj9 - (object)body._position;
				bool flag8 = obj12 == null;
				bool flag9 = !flag7;
				bool flag10 = !flag8;
				object obj13 = flag10 & flag9;
				object obj14 = obj13 & (object)dictionary;
				flag11 = obj14 == null;
				obj = obj7;
			}
			while (flag11);
		}
		goto IL_03f3;
		IL_03f3:
		return false;
	}

	private void OnEnemyKilled(GameplaySignals.RemoveEnemyFromStageSignal signal)
	{
		bool flag = ((List<object>)(object)_spawnedEnemies).Remove((object)signal);
		bool flag2 = ((HashSet<object>)(object)_authoritativePermanentEnemies).Remove((object)signal);
	}

	private unsafe void GenerateTilingTileset()
	{
		//IL_002c: Expected O, but got Ref
		//IL_002c: Expected O, but got Ref
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		object obj = default(object);
		object obj2 = default(object);
		Transform parentTransform = default(Transform);
		GameObject gameObject = _diContainer.InstantiatePrefab(_TilingTilesetPrefab, (Vector3)(&obj), (Quaternion)(&obj2), parentTransform);
		TilingTileset component = gameObject.GetComponent<TilingTileset>();
		_tilingTileset = component;
		_tilingTileset.Init(_stageType, this);
	}

	private void InitTilingTileset()
	{
		TilingTileset tilingTileset = _tilingTileset;
		List<SuperMap> maps = tilingTileset._maps;
		if (maps._size > 0)
		{
			SuperMap[] items = maps._items;
			tilingTileset.HandleCustomScriptProperties(items[0]);
			tilingTileset.SpawnMoongates();
			tilingTileset.MakeTeleporters();
			bool centered;
			if (_stageType != StageType.MACHINE && _stageType != StageType.STAGEX)
			{
				bool flag = _stageType != StageType.ASTRALSTAIR;
				centered = true;
				if (!flag)
				{
					centered = true;
				}
			}
			else
			{
				centered = false;
			}
			float2 float5 = default(float2);
			bool flag2 = default(bool);
			_gameManager.TeleportPlayers(float5, float5, centered, flag2);
			_tilingTileset.InternalUpdate();
			List<Vector2> enemySpawnLocations = _enemySpawnLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v12 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			List<Vector2> destructibleLocations = _destructibleLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			List<Vector2> destructibleLocations2 = _destructibleLocations;
			IEnumerable<Vector2> locationsFromMapObjectLayer = GetLocationsFromMapObjectLayer("Destructibles");
			List<Vector2> destructibleLocations3 = _destructibleLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v5 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			destructibleLocations3.InsertRange(0, locationsFromMapObjectLayer);
			List<Vector2> enemySpawnLocations2 = _enemySpawnLocations;
			IEnumerable<Vector2> locationsFromMapObjectLayer2 = GetLocationsFromMapObjectLayer("Spawners");
			List<Vector2> enemySpawnLocations3 = _enemySpawnLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			enemySpawnLocations3.InsertRange(0, locationsFromMapObjectLayer2);
			CalcMinMaxTreasures();
			List<Rectangle> scriptRectangularLocations = _tilingTileset.GetScriptRectangularLocations("NoShadow");
			_noShadowLocations = scriptRectangularLocations;
			List<Rectangle> noShadowLocations = _noShadowLocations;
			_ShadowAlpha = 1f;
			if (noShadowLocations._size > 0)
			{
				Action onComplete = delegate
				{
					List<Rectangle> noShadowLocations2 = _noShadowLocations;
					if (noShadowLocations2._size > 0)
					{
						bool flag3 = ShouldWeSeeShadowLayer();
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 55 Invalid \"Jump target not found in method: 0x186E53460\"");
					}
				};
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer noShadowsTimer = Timers.Register(0.1f, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_noShadowsTimer = noShadowsTimer;
			}
			HandleCartsAndPizzas();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe IEnumerable<Vector2> GetLocationsFromMapObjectLayer(string objectLayerName)
	{
		//IL_011d: Expected I, but got O
		//IL_03f6: Expected O, but got Ref
		//IL_0412: Expected O, but got Ref
		//IL_01f5: Expected O, but got I4
		//IL_051e: Expected I, but got O
		//IL_01a2: Expected O, but got I
		//IL_01ab: Expected O, but got I4
		//IL_022a: Expected O, but got I
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_0260: Expected I, but got O
		//IL_0270: Expected O, but got I
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_02a8: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0391: Expected O, but got I
		//IL_03e9: Expected I, but got O
		//IL_0376: Expected I, but got O
		//IL_05af->IL059d: Incompatible stack heights: 3 vs 0
		//IL_044b->IL04c4: Incompatible stack heights: 4 vs 3
		//IL_03ee->IL0584: Incompatible stack heights: 11 vs 3
		//IL_037b->IL0584: Incompatible stack heights: 10 vs 3
		List<Vector2> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		SuperMap defaultMap = _tilingTileset.DefaultMap;
		if ((object)defaultMap != null && ((UnityEngine.Object)defaultMap).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = defaultMap.transform;
			bool flag = (object)transform == null;
			bool flag2 = "Grid" == null;
			Transform transform2 = transform.FindRelativeTransformWithPath("Grid", false);
			bool flag3 = objectLayerName == null;
			Transform transform3 = transform2.FindRelativeTransformWithPath(objectLayerName, false);
			if ((object)transform3 != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
			{
				IEnumerator enumerator = transform3.GetEnumerator();
				nint num = unchecked((nint)null);
				object obj = default(object);
				object obj2 = default(object);
				object obj13 = default(object);
				Stage stage = default(Stage);
				Vector2 vector = default(Vector2);
				object obj17 = default(object);
				while (true)
				{
					bool flag4 = obj == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj2 == null)
					{
						break;
					}
					bool flag5 = obj == null;
					object obj3 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v17+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_01e2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v17+B0]");
					object obj4 = 0;
					object obj5 = 0;
					while (true)
					{
						object obj6 = obj5 + obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v23+v1174 @ rax_v93*8]");
						if (0 == (nint)typeof(IEnumerator))
						{
							break;
						}
						obj5++;
						object obj7 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r10_v17+12E]");
						if ((nint)obj7 < 0)
						{
							continue;
						}
						goto IL_01e2;
					}
					object obj8 = obj5 + obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v23+8+v1233 @ rcx_v73*8]");
					object obj9 = (nint)0 + (nint)1;
					object obj10 = obj9 << 4;
					object obj11 = obj10 + 312;
					object obj12 = obj11 + obj3;
					goto IL_0506;
					IL_01e2:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj4 = 1;
					obj12 = obj13;
					goto IL_0506;
					IL_0506:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1240 @ rdx_v35] (should have been resolved before IL gen)");
					nint num2 = (nint)typeof(Transform);
					if ((object)stage != null)
					{
						nint num3 = (nint)stage;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v37 (Il2CppClass<UnityEngine.Transform>)+130]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Stage>)+130]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v37 (Il2CppClass<UnityEngine.Transform>)+130]");
						bool flag6 = num4 < 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Stage>)+C8]");
						object obj15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v78+FFFFFFF8+v539 @ rax_v77*8]");
						bool flag7 = 0 != (nint)typeof(Transform);
						bool flag8 = ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0;
						Vector2 ret;
						Transform.get_position_Injected(((UnityEngine.Object)stage).m_CachedPtr, out *(Vector3*)(&ret));
						bool flag9 = list == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						Transform transform4 = (Transform)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						bool flag10 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rcx_v65 (UnityEngine.Transform)+18]");
						object obj16;
						Vector2 vector2;
						if (num5 >= 0)
						{
							list.AddWithResize(vector);
							obj16 = obj17;
							vector2 = vector;
							num = (nint)typeof(IEnumerator);
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						object obj18 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rcx_v65 (UnityEngine.Transform)+18]");
						bool flag11 = num6 >= 0;
						obj16 = obj17;
						vector2 = ret;
						num = (nint)typeof(IEnumerator);
						continue;
					}
					throw new NullReferenceException();
				}
				object obj19 = (object)(&obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
				object obj20 = (object)(&obj);
				object obj21 = default(object);
				obj20 = obj21;
				if (obj21 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
			}
			return list;
		}
		List<Vector2> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		return result;
	}

	private unsafe void CalcMinMaxTreasures()
	{
		//IL_0124: Expected O, but got Ref
		//IL_00c0: Expected O, but got I4
		//IL_04fc: Expected O, but got I4
		//IL_00f7: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_02ca: Expected O, but got I4
		//IL_0398: Expected O, but got I4
		//IL_0466: Expected O, but got I4
		List<Vector2> enemySpawnLocations = _enemySpawnLocations;
		bool flag = _enemySpawnLocations == null;
		Stage stage = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0 && (_spawnType == SpawnType.HORIZONTAL || _spawnType == SpawnType.HORIZONTAL_SMOOTHED))
			{
				List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
				object obj = default(object);
				object obj2 = default(object);
				while (enumerator.MoveNext())
				{
					bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
					object obj3 = obj - obj2;
					bool flag3 = obj3 == null;
					bool flag4 = !flag2;
					bool flag5 = !flag3;
					object obj4 = flag5 & flag4;
					object obj5 = (object?)_003CMinTreasureY_003Ek__BackingField & obj4;
					if (obj5 != null)
					{
						_003CMinTreasureY_003Ek__BackingField = (float?)(object)1;
						obj = obj2;
					}
					bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
					object obj6 = obj2 - obj;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					bool flag9 = !flag7;
					object obj7 = flag9 & flag8;
					object obj8 = (object?)_003CMaxTreasureY_003Ek__BackingField & obj7;
					if (obj8 != null)
					{
						_003CMaxTreasureY_003Ek__BackingField = (float?)(object)1;
						obj = obj2;
					}
				}
				stage = (Stage)(&enumerator);
			}
			else
			{
				stage = this;
			}
			if (_stageData == null)
			{
				return;
			}
			StageData stageData = _stageData;
			if (stageData._003Ctileset_003Ek__BackingField == null)
			{
				return;
			}
			Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
			if ((object)tileset._003CminTreasureY_003Ek__BackingField != null)
			{
				stage = (Stage)(object)_stageData;
				if (_stageData == null || stage._checkPizzasTimer == null)
				{
					goto IL_046b;
				}
				if ((object)tileset._003CminTreasureY_003Ek__BackingField == null)
				{
					goto IL_0579;
				}
				_003CMaxTreasureY_003Ek__BackingField = (float?)(object)1;
			}
			StageData stageData2 = _stageData;
			if (_stageData != null)
			{
				Tileset tileset2 = stageData2._003Ctileset_003Ek__BackingField;
				if (stageData2._003Ctileset_003Ek__BackingField != null)
				{
					if ((object)tileset2._003CmaxTreasureY_003Ek__BackingField != null)
					{
						stage = (Stage)(object)_stageData;
						if (_stageData == null || stage._checkPizzasTimer == null)
						{
							goto IL_046b;
						}
						if ((object)tileset2._003CmaxTreasureY_003Ek__BackingField == null)
						{
							goto IL_0579;
						}
						_003CMinTreasureY_003Ek__BackingField = (float?)(object)1;
					}
					StageData stageData3 = _stageData;
					if (_stageData != null)
					{
						Tileset tileset3 = stageData3._003Ctileset_003Ek__BackingField;
						if (stageData3._003Ctileset_003Ek__BackingField != null)
						{
							if ((object)tileset3._003CmaxTreasureX_003Ek__BackingField != null)
							{
								stage = (Stage)(object)_stageData;
								if (_stageData == null || stage._checkPizzasTimer == null)
								{
									goto IL_046b;
								}
								if ((object)tileset3._003CmaxTreasureX_003Ek__BackingField == null)
								{
									goto IL_0579;
								}
								_003CMaxTreasureX_003Ek__BackingField = (float?)(object)1;
							}
							StageData stageData4 = _stageData;
							if (_stageData != null)
							{
								Tileset tileset4 = stageData4._003Ctileset_003Ek__BackingField;
								if (stageData4._003Ctileset_003Ek__BackingField != null)
								{
									if ((object)tileset4._003CminTreasureX_003Ek__BackingField == null)
									{
										return;
									}
									stage = (Stage)(object)_stageData;
									if (_stageData != null && stage._checkPizzasTimer != null)
									{
										if ((object)tileset4._003CminTreasureX_003Ek__BackingField != null)
										{
											_003CMinTreasureX_003Ek__BackingField = (float?)(object)1;
											return;
										}
										goto IL_0579;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_046b;
		IL_0579:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_046b:
		throw new NullReferenceException();
	}

	private unsafe void HandleCartsAndPizzas()
	{
		//IL_0383: Expected I, but got O
		//IL_0399: Expected O, but got I
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_041d: Expected I, but got O
		//IL_05a0: Expected I, but got O
		//IL_05c1: Expected O, but got I
		//IL_053a: Expected O, but got I4
		//IL_0551: Expected I, but got I8
		//IL_03f9: Expected I, but got I8
		//IL_022a: Expected O, but got Ref
		//IL_022a: Expected O, but got Ref
		TilingTileset cartLocations = (TilingTileset)(object)_cartLocations;
		Action action;
		if (_cartLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v9 (VampireSurvivors.Objects.TilingTileset)+1C]");
			_ = (nint)0 + (nint)1;
			((MonoBehaviour)cartLocations).m_CancellationTokenSource = null;
			cartLocations = _tilingTileset;
			if ((object)_tilingTileset != null)
			{
				List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("CART");
				_cartLocations = specialLocations;
				cartLocations = (TilingTileset)(object)_pizzaLocations;
				if (_pizzaLocations != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v9 (VampireSurvivors.Objects.TilingTileset)+1C]");
					_ = (nint)0 + (nint)1;
					((MonoBehaviour)cartLocations).m_CancellationTokenSource = null;
					cartLocations = _tilingTileset;
					if ((object)_tilingTileset != null)
					{
						List<Vector2> specialLocations2 = _tilingTileset.GetSpecialLocations("PIZZA");
						_pizzaLocations = specialLocations2;
						cartLocations = (TilingTileset)(object)_windowLocations;
						if (_windowLocations != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v9 (VampireSurvivors.Objects.TilingTileset)+1C]");
							_ = (nint)0 + (nint)1;
							((MonoBehaviour)cartLocations).m_CancellationTokenSource = null;
							if ((object)_tilingTileset != null)
							{
								List<Vector2> specialLocations3 = _tilingTileset.GetSpecialLocations("Window");
								_windowLocations = specialLocations3;
								List<Vector2> pizzaLocations = _pizzaLocations;
								if (_pizzaLocations == null)
								{
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v853 @ rcx_v18 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								if ((nint)0 <= (nint)0)
								{
									return;
								}
								List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
								object obj = default(object);
								Quaternion quaternion2 = default(Quaternion);
								while (enumerator.MoveNext())
								{
									nint num = (nint)typeof(Quaternion);
									bool flag = (object)MasterObjectPooler._003CInstance_003Ek__BackingField == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rax_v53 (Il2CppClass<UnityEngine.Quaternion>)+B8]");
									List<object> list = (List<object>)0;
									if (!flag)
									{
										ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
										bool flag2 = (object)pool == null;
										list = (List<object>)(object)MasterObjectPooler._003CInstance_003Ek__BackingField;
										if (!flag2)
										{
											GameObject gameObject = pool.GetObject((Vector3)(&obj), (Quaternion)(&quaternion2));
											bool flag3 = (object)gameObject == null;
											list = (List<object>)(object)pool;
											if (!flag3)
											{
												PizzaCircle component = gameObject.GetComponent<PizzaCircle>();
												bool flag4 = (object)component == null;
												list = (List<object>)(object)gameObject;
												if (!flag4)
												{
													component.Init(16f);
													list = (List<object>)(object)_pizzaCircles;
													if (_pizzaCircles != null)
													{
														int version = list._version + 1;
														list._version = version;
														object[] items = list._items;
														if (list._items != null)
														{
															if (list._size >= items.Length)
															{
																((List<object>)(object)_pizzaCircles).AddWithResize((object)component);
																continue;
															}
															int size = list._size + 1;
															list._size = size;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															continue;
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								action = null;
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v904 @ r10_v2 (Il2CppMethodInfo)+8]");
								((Delegate)action).method_ptr = (IntPtr)0;
								((Delegate)action).method = (nint)__ldftn(Stage.CheckPizzas);
								((Delegate)action).m_target = this;
								((Delegate)action).method_code = (IntPtr)action;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v904 @ r10_v2 (Il2CppMethodInfo)+4C]");
								object obj2 = (nint)0 >> 4;
								object obj3 = obj2 & 1;
								nint num3;
								if (obj3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v904 @ r10_v2 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num3 = unchecked((nint)6447293664L);
										goto IL_0531;
									}
								}
								num3 = ((Delegate)action).method_ptr;
								((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
								goto IL_0531;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0531:
		object obj4 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer checkPizzasTimer = Timers.Register(0.1f, action, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_checkPizzasTimer = checkPizzasTimer;
	}

	private void CheckPizzas()
	{
		//IL_01ed: Expected F4, but got I4
		//IL_0197: Expected O, but got F4
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		float num = 0f;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			object obj = UnityEngine.Random.value;
		}
	}

	private void TriggerPizzaEvent(PizzaCircle pizzaCircle, VampireSurvivors.Objects.Characters.CharacterController triggeringPlayer)
	{
		//IL_0064: Invalid comparison between F4 and I4
		//IL_017a: Expected I4, but got O
		//IL_0388->IL0305: Incompatible stack heights: 1 vs 0
		StageData stageData = _stageData;
		if (_stageData != null)
		{
			if (stageData._003CpizzaEvents_003Ek__BackingField == null)
			{
				return;
			}
			List<VampireSurvivors.Data.Stage.Event> list = stageData._003CpizzaEvents_003Ek__BackingField;
			if (list._size <= 0 || _pizzaDelay > 0f)
			{
				return;
			}
			List<EnemyController> spawnedEnemies = _spawnedEnemies;
			if (_spawnedEnemies != null)
			{
				if (spawnedEnemies._size >= 500)
				{
					return;
				}
				if ((object)triggeringPlayer != null)
				{
					float num = triggeringPlayer.PLuck();
					float num2 = _pizzaDelay * 20000f;
					bool flag = !(5000f < num2);
					float num3 = 5000f;
					if (!flag)
					{
						num3 = num2;
					}
					float pizzaDelay = num3 * 0.001f;
					StageData stageData2 = _stageData;
					_pizzaDelay = pizzaDelay;
					if (_stageData != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = (VampireSurvivors.Objects.Characters.CharacterController)(object)stageData2._003CpizzaEvents_003Ek__BackingField;
						if (stageData2._003CpizzaEvents_003Ek__BackingField != null)
						{
							int num4 = UnityEngine.Random.Range(0, (int)((MonoBehaviour)characterController).m_CancellationTokenSource);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							VampireSurvivors.Data.Stage.Event obj = default(VampireSurvivors.Data.Stage.Event);
							if (obj == null)
							{
								return;
							}
							if (_stageEventManager != null)
							{
								if (!_stageEventManager.TriggerEvent(obj))
								{
									return;
								}
								if ((object)pizzaCircle != null)
								{
									Transform transform = pizzaCircle.transform;
									if (pizzaCircle._circle != null && (object)_tilingTileset != null)
									{
										Vector2 defaultMapPosition = _tilingTileset.DefaultMapPosition;
										if (pizzaCircle._circle != null && (object)_tilingTileset != null)
										{
											Vector2 defaultMapPosition2 = _tilingTileset.DefaultMapPosition;
											bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											Vector3 value = default(Vector3);
											Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
											ShowPizzaWarning(pizzaCircle);
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
		throw new NullReferenceException();
	}

	public void ShowPizzaWarning(PizzaCircle pizzaCircle)
	{
		//IL_004b: Expected O, but got I4
		//IL_0067: Expected O, but got F4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * 500f;
		soundConfig.Rate = 1f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, time);
		pizzaCircle.ShowWarning();
	}

	private unsafe void GenerateTilingBackground()
	{
		//IL_00a9: Expected O, but got Ref
		//IL_00a9: Expected O, but got Ref
		//IL_0196->IL0117: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0117: Incompatible stack heights: 1 vs 0
		//IL_0100->IL0117: Incompatible stack heights: 1 vs 0
		//IL_0116->IL0116: Incompatible stack heights: 1 vs 0
		StageData stageData = _stageData;
		if (_stageData != null)
		{
			string text = stageData._003CBGTextureName_003Ek__BackingField;
			if (stageData._003CBGTextureName_003Ek__BackingField == null || text._stringLength <= 0)
			{
				return;
			}
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				if (_diContainer != null)
				{
					object obj = default(object);
					object obj2 = default(object);
					Transform parentTransform = default(Transform);
					GameObject gameObject = _diContainer.InstantiatePrefab(_TilingBackgroundPrefab, (Vector3)(&obj), (Quaternion)(&obj2), parentTransform);
					if ((object)gameObject != null)
					{
						TilingBackground component = gameObject.GetComponent<TilingBackground>();
						_tilingBackground = component;
						if ((object)_tilingBackground != null)
						{
							_tilingBackground.Init(this);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SpawnYellowItems()
	{
		//IL_00c5: Expected I, but got O
		//IL_00d3: Expected I, but got O
		//IL_00e3: Expected O, but got I
		//IL_0163: Expected O, but got I4
		//IL_011f: Expected O, but got I
		//IL_01d0: Expected I, but got O
		//IL_01de: Expected I, but got O
		//IL_01ee: Expected O, but got I
		//IL_0155: Expected O, but got I4
		//IL_026e: Expected O, but got I4
		//IL_022a: Expected O, but got I
		//IL_02db: Expected I, but got O
		//IL_02e9: Expected I, but got O
		//IL_02f9: Expected O, but got I
		//IL_0260: Expected O, but got I4
		//IL_0379: Expected O, but got I4
		//IL_0335: Expected O, but got I
		//IL_036b: Expected O, but got I4
		//IL_03de: Expected I, but got O
		//IL_03ec: Expected I, but got O
		//IL_03fc: Expected O, but got I
		//IL_047c: Expected O, but got I4
		//IL_0438: Expected O, but got I
		//IL_046e: Expected O, but got I4
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
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
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = _gameManager.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.SILVER, value, relicType, validatePickups);
		Pickup pickup2;
		if ((object)pickup == null)
		{
			pickup2 = null;
			goto IL_0175;
		}
		nint num = (nint)pickup;
		nint num2 = (nint)typeof(PickupGuarded);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v85+FFFFFFF8+v409 @ rax_v81*8]");
			if (0 == (nint)typeof(PickupGuarded))
			{
				obj4 = 1;
				goto IL_05f1;
			}
		}
		obj4 = 0;
		goto IL_05f1;
		IL_0280:
		Pickup pickup3 = _gameManager.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.LEFT, value, relicType, validatePickups);
		Pickup pickup4;
		if ((object)pickup3 == null)
		{
			pickup4 = null;
			goto IL_038b;
		}
		nint num4 = (nint)pickup3;
		nint num5 = (nint)typeof(PickupGuarded);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
		object obj7;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rax_v73+FFFFFFF8+v605 @ rax_v69*8]");
			if (0 == (nint)typeof(PickupGuarded))
			{
				obj7 = 1;
				goto IL_0635;
			}
		}
		obj7 = 0;
		goto IL_0635;
		IL_0175:
		Pickup pickup5 = _gameManager.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.GOLD, value, relicType, validatePickups);
		Pickup pickup6;
		if ((object)pickup5 == null)
		{
			pickup6 = null;
			goto IL_0280;
		}
		nint num7 = (nint)pickup5;
		nint num8 = (nint)typeof(PickupGuarded);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
		object obj10;
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rax_v79+FFFFFFF8+v507 @ rax_v75*8]");
			if (0 == (nint)typeof(PickupGuarded))
			{
				obj10 = 1;
				goto IL_0613;
			}
		}
		obj10 = 0;
		goto IL_0613;
		IL_038b:
		Pickup pickup7 = _gameManager.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.RIGHT, value, relicType, validatePickups);
		bool flag = (object)pickup7 == null;
		Pickup pickup8 = null;
		object obj13;
		if (!flag)
		{
			nint num10 = (nint)pickup7;
			nint num11 = (nint)typeof(PickupGuarded);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupGuarded>)+130]");
			if (num12 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v752 @ rax_v67+FFFFFFF8+v699 @ rax_v63*8]");
				if (0 == (nint)typeof(PickupGuarded))
				{
					obj13 = 1;
					goto IL_065c;
				}
			}
			obj13 = 0;
			goto IL_065c;
		}
		goto IL_0683;
		IL_0635:
		bool flag2 = obj7 == null;
		pickup4 = null;
		if (!flag2)
		{
			pickup4 = pickup3;
		}
		goto IL_038b;
		IL_065c:
		bool flag3 = obj13 == null;
		pickup8 = null;
		if (!flag3)
		{
			pickup8 = pickup7;
		}
		goto IL_0683;
		IL_0613:
		bool flag4 = obj10 == null;
		pickup6 = null;
		if (!flag4)
		{
			pickup6 = pickup5;
		}
		goto IL_0280;
		IL_05f1:
		bool flag5 = obj4 == null;
		pickup2 = null;
		if (!flag5)
		{
			pickup2 = pickup;
		}
		goto IL_0175;
		IL_0683:
		if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
		{
			_ = 200;
			_ = 1;
			_ = 1;
			_ = 1;
			_ = 1086918619;
		}
		if ((object)pickup6 != null && ((UnityEngine.Object)pickup6).m_CachedPtr != (IntPtr)0)
		{
			_ = 199;
			_ = 1;
			_ = 1;
			_ = 1;
			_ = 1086918619;
		}
		if ((object)pickup4 != null && ((UnityEngine.Object)pickup4).m_CachedPtr != (IntPtr)0)
		{
			_ = 201;
			_ = 1;
			_ = 1;
			_ = 1;
			_ = 1086918619;
		}
		if ((object)pickup8 != null && ((UnityEngine.Object)pickup8).m_CachedPtr != (IntPtr)0)
		{
			_ = 202;
			_ = 1;
			_ = 1;
			_ = 1;
			_ = 1086918619;
		}
	}

	private void SpawnAdventureMerchants()
	{
		StageData stageData = _stageData;
		List<CustomMerchantData> list = stageData._003CadventureMerchants_003Ek__BackingField;
		if (stageData._003CadventureMerchants_003Ek__BackingField != null && list._size > 0)
		{
			List<CustomMerchantData>.Enumerator enumerator = default(List<CustomMerchantData>.Enumerator);
			while (enumerator.MoveNext())
			{
				SpawnCustomAdventureMerchant(null);
			}
		}
	}

	private void SpawnCustomAdventureMerchant(CustomMerchantData customMerchantData)
	{
		//IL_01f4: Expected I, but got O
		//IL_01fc: Expected I, but got O
		//IL_020c: Expected O, but got I
		//IL_028c: Expected O, but got I4
		//IL_0248: Expected O, but got I
		//IL_027e: Expected O, but got I4
		Pickup pickup;
		object obj3;
		if (customMerchantData != null && (object)customMerchantData._003CMerchantXPos_003Ek__BackingField != null && (object)customMerchantData._003CMerchantYPos_003Ek__BackingField != null)
		{
			if (!CheckCanSpawnAdventureMerchant(customMerchantData))
			{
				return;
			}
			if ((object)customMerchantData._003CMerchantXPos_003Ek__BackingField != null && (object)customMerchantData._003CMerchantYPos_003Ek__BackingField != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config._003CSelectedInverse_003Ek__BackingField)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2._003CVisuallyInvertStages_003Ek__BackingField)
					{
						StageData stageData = _stageData;
						if (stageData._003CallowVisualInversion_003Ek__BackingField)
						{
							SuperMap defaultMap = _tilingTileset.DefaultMap;
							SuperMap defaultMap2 = _tilingTileset.DefaultMap;
							SuperMap defaultMap3 = _tilingTileset.DefaultMap;
							SuperMap defaultMap4 = _tilingTileset.DefaultMap;
						}
					}
				}
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				pickup = GM.Core.MakeStagePickup(pos, ItemType.ADVENTURE_MERCHANT, WeaponType.VOID, value, relicType, validatePickups);
				if ((object)pickup == null)
				{
					return;
				}
				nint num = (nint)typeof(PickupMerchantAdventure);
				nint num2 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchantAdventure>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupMerchantAdventure>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rcx_v18+FFFFFFF8+v575 @ rcx_v14*8]");
					if (0 == (nint)typeof(PickupMerchantAdventure))
					{
						obj3 = 1;
						goto IL_02e4;
					}
				}
				obj3 = 0;
				goto IL_02e4;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			return;
		}
		Debug.LogError("AdventureMerchantData is NULL");
		return;
		IL_02e4:
		bool flag = obj3 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		((PickupCustomMerchant)pickup2)?.SetInventoryData(customMerchantData);
	}

	private bool CheckCanSpawnAdventureMerchant(CustomMerchantData customMerchantData)
	{
		//IL_03f8: Expected I4, but got O
		//IL_0068: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_00d4: Expected O, but got I
		//IL_0479: Expected O, but got I
		//IL_0226: Expected O, but got I
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_02ee: Expected O, but got I
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		if (customMerchantData == null)
		{
			goto IL_036b;
		}
		if (customMerchantData._003CDLC_003Ek__BackingField == null)
		{
			goto IL_013b;
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		if (loadedDlc != null)
		{
			Dictionary<DlcType, BundleManifestData>.KeyCollection keys = loadedDlc.Keys;
			object obj = 0;
			object obj2 = 0;
			while (true)
			{
				List<DlcType> list = customMerchantData._003CDLC_003Ek__BackingField;
				if (customMerchantData._003CDLC_003Ek__BackingField == null)
				{
					break;
				}
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				if ((nint)obj3 < 0)
				{
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					if ((nint)obj4 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rdx_v27+20+v70 @ rbx_v18*4]");
						if (!Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)keys, (System.Int32Enum)0))
						{
							obj++;
							obj2 = obj;
							continue;
						}
						goto IL_013b;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new IndexOutOfRangeException();
				}
				goto IL_036b;
			}
		}
		goto IL_03ea;
		IL_03ea:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_013b:
		if (customMerchantData._003CMerchantInventory_003Ek__BackingField != null)
		{
			List<WeaponType> list2 = customMerchantData._003CMerchantInventory_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)0)
			{
				List<WeaponType> list3 = new List<WeaponType>();
				if (customMerchantData._003CMerchantInventory_003Ek__BackingField != null)
				{
					object obj6 = default(object);
					object obj7 = default(object);
					object obj9 = default(object);
					object obj12 = default(object);
					while (true)
					{
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-38_v13+1C]");
							if (obj7 == null)
							{
								object obj8 = obj9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-38_v13+18]");
								if ((nint)obj8 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-38_v13+10]");
									object obj10 = 0;
									object obj11 = obj9 + 1;
									PlayerOptions playerOptions = _playerOptions;
									PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
									bool flag = obj12 == null;
									obj9 = obj11;
									if (!flag)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
										obj9 = obj11;
									}
									continue;
								}
								break;
							}
							break;
						}
						throw new NullReferenceException();
					}
					bool flag2 = obj6 == null;
					List<WeaponType> list4 = (List<WeaponType>)0;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-38_v13+1C]");
						if (obj7 == null)
						{
							if (list3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								object obj13 = num ^ 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								object obj14 = 0 & obj13;
								bool flag3 = (nint)obj14 < 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								bool flag4 = (nint)0 < (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								bool flag5 = (nint)0 == 0;
								bool flag6 = flag4 == flag3;
								bool flag7 = !flag5;
								return flag7 & flag6;
							}
							goto IL_03ea;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						list4 = null;
					}
					throw new NullReferenceException();
				}
				goto IL_03ea;
			}
		}
		goto IL_036b;
		IL_036b:
		return false;
	}

	public bool ShouldShowCursor(float2 position)
	{
		//IL_0085: Expected I4, but got O
		//IL_0067: Expected I, but got O
		BackgroundManager fancyBg = _fancyBg;
		if ((object)_fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			BackgroundManager fancyBg2 = _fancyBg;
			if ((object)_fancyBg == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			nint num = (nint)fancyBg2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v185 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+338] (should have been resolved before IL gen)");
		}
		return true;
	}

	private PickupCustomMerchant SpawnCustomMerchant(CustomMerchantData customMerchantData)
	{
		//IL_0310: Expected I, but got O
		//IL_0318: Expected I, but got O
		//IL_0328: Expected O, but got I
		//IL_03a8: Expected O, but got I4
		//IL_0364: Expected O, but got I
		//IL_039a: Expected O, but got I4
		if (customMerchantData != null)
		{
			if (CheckCanSpawnCustomMerchant(customMerchantData))
			{
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						if (config._003CSelectedInverse_003Ek__BackingField)
						{
							TilingTileset tilingTileset = _tilingTileset;
							if ((object)_tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
							{
								if (_playerOptions != null)
								{
									PlayerOptionsData config2 = _playerOptions.Config;
									if (config2 != null)
									{
										if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
										{
											goto IL_041f;
										}
										StageData stageData = _stageData;
										if (_stageData != null)
										{
											if (!stageData._003CallowVisualInversion_003Ek__BackingField)
											{
												goto IL_041f;
											}
											if ((object)_tilingTileset != null)
											{
												SuperMap defaultMap = _tilingTileset.DefaultMap;
												if ((object)defaultMap != null && (object)_tilingTileset != null)
												{
													SuperMap defaultMap2 = _tilingTileset.DefaultMap;
													if ((object)defaultMap2 != null && (object)_tilingTileset != null)
													{
														SuperMap defaultMap3 = _tilingTileset.DefaultMap;
														if ((object)defaultMap3 != null && (object)_tilingTileset != null)
														{
															SuperMap defaultMap4 = _tilingTileset.DefaultMap;
															if ((object)defaultMap4 != null)
															{
																goto IL_041f;
															}
														}
													}
												}
											}
										}
									}
								}
								goto IL_03f4;
							}
						}
						goto IL_041f;
					}
				}
				goto IL_03f4;
			}
		}
		else
		{
			Debug.LogError("CustomMerchantData is NULL");
		}
		return null;
		IL_03f4:
		return (PickupCustomMerchant)(object)new NullReferenceException();
		IL_041f:
		if ((object)GM.Core == null)
		{
			goto IL_03f4;
		}
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.CUSTOM_MERCHANT, WeaponType.VOID, value, relicType, validatePickups);
		if ((object)pickup == null)
		{
			goto IL_03d4;
		}
		nint num = (nint)typeof(PickupCustomMerchant);
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ rcx_v17+FFFFFFF8+v547 @ rcx_v13*8]");
			if (0 == (nint)typeof(PickupCustomMerchant))
			{
				obj3 = 1;
				goto IL_0461;
			}
		}
		obj3 = 0;
		goto IL_0461;
		IL_03d4:
		return null;
		IL_0461:
		bool flag = obj3 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		if ((object)pickup2 != null)
		{
			((PickupCustomMerchant)pickup2).SetInventoryData(customMerchantData);
			return (PickupCustomMerchant)pickup2;
		}
		goto IL_03d4;
	}

	private bool CheckCanSpawnCustomMerchant(CustomMerchantData customMerchantData)
	{
		//IL_0382: Expected I4, but got O
		//IL_0068: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_02b1: Expected O, but got I4
		//IL_00d4: Expected O, but got I
		//IL_02f9: Expected O, but got I4
		//IL_02a3: Expected O, but got I4
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected O, but got Unknown
		//IL_0430: Expected O, but got I4
		//IL_02eb: Expected O, but got I4
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected I4, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		if (customMerchantData != null)
		{
			if (customMerchantData._003CDLC_003Ek__BackingField != null)
			{
				Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
				if (loadedDlc != null)
				{
					Dictionary<DlcType, BundleManifestData>.KeyCollection keys = loadedDlc.Keys;
					object obj = 0;
					object obj2 = 0;
					while (true)
					{
						List<DlcType> list = customMerchantData._003CDLC_003Ek__BackingField;
						if (customMerchantData._003CDLC_003Ek__BackingField == null)
						{
							break;
						}
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						if ((nint)obj3 < 0)
						{
							object obj4 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
							if ((nint)obj4 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rdx_v16+20+v69 @ rbx_v12*4]");
								if (!Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)keys, (System.Int32Enum)0))
								{
									obj++;
									obj2 = obj;
									continue;
								}
								goto IL_013b;
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							break;
						}
						goto IL_0349;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_013b;
		}
		goto IL_0349;
		IL_013b:
		if (customMerchantData._003CMerchantCharacter_003Ek__BackingField == CharacterType.EX_GIOCARE)
		{
			goto IL_033b;
		}
		if (customMerchantData._003CMerchantInventory_003Ek__BackingField != null)
		{
			List<WeaponType> list2 = customMerchantData._003CMerchantInventory_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 != 0)
			{
				goto IL_0208;
			}
		}
		if (customMerchantData._003CMerchantInventoryItems_003Ek__BackingField != null)
		{
			List<ItemType> list3 = customMerchantData._003CMerchantInventoryItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				goto IL_0208;
			}
		}
		goto IL_0349;
		IL_0349:
		return false;
		IL_033b:
		return true;
		IL_0208:
		if (customMerchantData._003CMerchantCharacter_003Ek__BackingField != CharacterType.TP_LIBRARIAN && customMerchantData._003CMerchantCharacter_003Ek__BackingField != CharacterType.MARIASOFIA)
		{
			object obj6;
			if (customMerchantData._003CMerchantInventory_003Ek__BackingField != null)
			{
				Func<WeaponType, bool> predicate = delegate
				{
					//IL_0073: Expected I4, but got O
					PlayerOptions playerOptions = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
						if (playerOptions._mainGameConfig != null && mainGameConfig._003CUnlockedWeapons_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
							bool result = default(bool);
							return result;
						}
					}
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				};
				bool flag = Enumerable.Any((IEnumerable<System.Int32Enum>)customMerchantData._003CMerchantInventory_003Ek__BackingField, (Func<System.Int32Enum, bool>)(object)predicate);
				obj6 = 1;
			}
			else
			{
				obj6 = 0;
			}
			object obj7;
			if (customMerchantData._003CMerchantInventoryItems_003Ek__BackingField != null)
			{
				Func<ItemType, bool> predicate2 = delegate
				{
					//IL_0070: Unknown result type (might be due to invalid IL or missing references)
					//IL_0075: Expected I4, but got Unknown
					PlayerOptions playerOptions = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
						if (playerOptions._mainGameConfig != null)
						{
							Stage stage = (Stage)(object)mainGameConfig._003CCollectedItems_003Ek__BackingField;
							if (mainGameConfig._003CCollectedItems_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
								object obj14 = default(object);
								return (byte)(obj14 ^ 1) != 0;
							}
						}
					}
					throw new NullReferenceException();
				};
				bool flag2 = Enumerable.Any((IEnumerable<System.Int32Enum>)customMerchantData._003CMerchantInventoryItems_003Ek__BackingField, (Func<System.Int32Enum, bool>)(object)predicate2);
				obj7 = 1;
			}
			else
			{
				obj7 = 0;
			}
			object obj8 = obj6 >> 8;
			object obj9 = obj8 - 1;
			bool flag3 = obj9 == null;
			object obj10 = obj6 & flag3;
			bool flag4 = obj10 == null;
			object obj11 = !flag4;
			if (obj11 == null)
			{
				object obj12 = obj7 >> 8;
				object obj13 = obj12 - 1;
				bool flag5 = obj13 == null;
				return (byte)((flag5 & obj7) ? 1 : 0) != 0;
			}
		}
		goto IL_033b;
	}

	private unsafe void ForceRepositionMerchants()
	{
		//IL_02fe: Expected I, but got O
		//IL_032f: Expected O, but got I
		//IL_006b: Expected O, but got Ref
		//IL_00c2: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_00fa: Expected O, but got I
		//IL_0103: Expected O, but got I4
		//IL_0236: Expected O, but got I
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		List<PickupCustomMerchant> list = (List<PickupCustomMerchant>)num2;
		if (!flag)
		{
			Func<Pickup, bool> predicate = _003C_003Ec._003C_003E9__413_0;
			if (_003C_003Ec._003C_003E9__413_0 == null)
			{
				Func<Pickup, bool> func = (_003C_003Ec._003C_003E9__413_0 = delegate(Pickup pickup)
				{
					//IL_0049: Expected O, but got I4
					if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
					{
						object obj12 = pickup._003CPickupType_003Ek__BackingField - 80;
						return obj12 == null;
					}
					return false;
				});
				PickupCustomMerchant pickupCustomMerchant = null;
				predicate = func;
			}
			IEnumerable<Pickup> enumerable = Enumerable.Where(core._stagePickups, predicate);
			List<PickupCustomMerchant> list2 = new List<PickupCustomMerchant>();
			bool flag2 = enumerable == null;
			list = list2;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Component component = default(Component);
				object obj = (object)(&component);
				object obj2 = default(object);
				object obj11 = default(object);
				Component component3 = default(Component);
				while (true)
				{
					object obj10;
					object obj3;
					if ((object)component != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 != null)
						{
							bool flag3 = (object)component == null;
							Component component2 = null;
							if (!flag3)
							{
								nint num3 = (nint)component;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r10_v9 (Il2CppClass<UnityEngine.Component>)+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_013a;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r10_v9 (Il2CppClass<UnityEngine.Component>)+B0]");
								obj3 = 0;
								object obj4 = 0;
								while (true)
								{
									object obj5 = obj4 + obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r8_v15+v593 @ rcx_v30*8]");
									if (0 == (nint)typeof(IEnumerator<Pickup>))
									{
										break;
									}
									obj4++;
									object obj6 = obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r10_v9 (Il2CppClass<UnityEngine.Component>)+12E]");
									if ((nint)obj6 < 0)
									{
										continue;
									}
									goto IL_013a;
								}
								object obj7 = obj4 + obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r8_v15+8+v647 @ rcx_v32*8]");
								object obj8 = (nint)0 << 4;
								object obj9 = obj8 + 312;
								obj10 = obj9 + num3;
								goto IL_0401;
							}
							throw new NullReferenceException();
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						break;
					}
					throw new NullReferenceException();
					IL_013a:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj10 = obj11;
					obj3 = 0;
					goto IL_0401;
					IL_0401:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v652 @ rdx_v17] (should have been resolved before IL gen)");
					if ((object)component3 != null)
					{
						PickupCustomMerchant component4 = component3.GetComponent<PickupCustomMerchant>();
						if (list2 != null)
						{
							int version = list2._version + 1;
							list2._version = version;
							list = (List<PickupCustomMerchant>)(object)list2._items;
							if (list2._items != null)
							{
								PickupCustomMerchant pickupCustomMerchant;
								if (list2._size >= list._size)
								{
									((List<object>)(object)list2).AddWithResize((object)component4);
									pickupCustomMerchant = component4;
									continue;
								}
								int size = list2._size + 1;
								list2._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								pickupCustomMerchant = component4;
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				PositionAllCustomMerchants(list2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PositionAllCustomMerchants(List<PickupCustomMerchant> spawnedMerchants)
	{
		//IL_071e: Expected O, but got I
		//IL_014e: Expected O, but got I
		//IL_0388: Expected O, but got I
		//IL_0449: Expected O, but got F4
		//IL_02e2: Expected O, but got I
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Expected O, but got Unknown
		//IL_0652->IL0652: Incompatible stack heights: 1 vs 0
		//IL_0201->IL0377: Incompatible stack heights: 4 vs 2
		//IL_064d->IL07a4: Incompatible stack heights: 7 vs 1
		//IL_07e9->IL07a4: Incompatible stack heights: 3 vs 1
		//IL_0265->IL0377: Incompatible stack heights: 6 vs 2
		//IL_0409->IL07a4: Incompatible stack heights: 3 vs 1
		//IL_0809->IL07a4: Incompatible stack heights: 3 vs 1
		//IL_079f->IL0377: Incompatible stack heights: 6 vs 2
		//IL_04b8->IL04f9: Incompatible stack heights: 4 vs 3
		//IL_031e->IL0377: Incompatible stack heights: 6 vs 2
		//IL_04bd->IL04bd: Incompatible stack heights: 4 vs 3
		//IL_0579->IL07a4: Incompatible stack heights: 4 vs 1
		//IL_0377->IL07a4: Incompatible stack heights: 7 vs 1
		GameManager core = GM.Core;
		if (core._stagePickups == null)
		{
			return;
		}
		List<Pickup> stagePickups = core._stagePickups;
		if (stagePickups._size <= 0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__414_0;
		if (_003C_003Ec._003C_003E9__414_0 == null)
		{
			predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__414_0 = delegate(Pickup pickup2)
			{
				//IL_0049: Expected O, but got I4
				if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
				{
					object obj5 = pickup2._003CPickupType_003Ek__BackingField - 29;
					return obj5 == null;
				}
				return false;
			});
		}
		object obj = Enumerable.FirstOrDefault(core2._stagePickups, predicate);
		GameSessionData gameSessionData = _gameSessionData;
		Transform transform = gameSessionData._activeCharacter.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v12 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				float2 position = ((ArcadeSprite)obj).position;
			}
		}
		List<float2> list = null;
		Pickup pickup = Enumerable.FirstOrDefault((IEnumerable<Pickup>)list, (Func<Pickup, bool>)0);
		List<PickupCustomMerchant> list2 = null;
		List<PickupCustomMerchant> list3 = spawnedMerchants;
		List<PickupCustomMerchant>.Enumerator enumerator = default(List<PickupCustomMerchant>.Enumerator);
		List<PickupCustomMerchant> list4 = default(List<PickupCustomMerchant>);
		List<PickupCustomMerchant> list7 = default(List<PickupCustomMerchant>);
		Transform transform4 = default(Transform);
		while (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ r14_v9 (ArcadeSprite)+190]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ r14_v9 (ArcadeSprite)+190]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ rax_v38+10]");
			Transform transform2;
			if ((nint)0 == 256)
			{
				bool flag3 = _playerOptions == null;
				PlayerOptionsData config = _playerOptions.Config;
				bool flag4 = config == null;
				if (config.HasCollectedItem(ItemType.TP_RELIC_PILEOFSECRETS))
				{
					bool flag5 = _playerOptions == null;
					PlayerOptionsData config2 = _playerOptions.Config;
					bool flag6 = config2 == null;
					if (!config2.HasCollectedItem(ItemType.TP_RELIC_LIBRARIAN))
					{
						if ((object)_tilingTileset != null)
						{
							List<Tuple<SuperObject, SuperCustomProperties>> allMerchants = _tilingTileset.GetAllMerchants();
							Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__414_1;
							if (_003C_003Ec._003C_003E9__414_1 == null)
							{
								predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__414_1 = delegate(Tuple<SuperObject, SuperCustomProperties> m)
								{
									//IL_0145: Expected I4, but got O
									//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
									//IL_00e7: Expected Ref, but got Unknown
									//IL_00fe: Expected I8, but got I4
									//IL_010c: Unknown result type (might be due to invalid IL or missing references)
									//IL_0111: Expected Ref, but got Unknown
									if (m != null)
									{
										SuperObject item = m.m_Item1;
										if ((object)m.m_Item1 != null)
										{
											string type = item.m_Type;
											object obj5 = "TP_LIBRARIAN";
											if ((object)item.m_Type != "TP_LIBRARIAN")
											{
												if (item.m_Type != null && "TP_LIBRARIAN" != null)
												{
													int stringLength = type._stringLength;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v1+10]");
													if ((nint)stringLength == 0)
													{
														ref byte second = ref *(byte*)("TP_LIBRARIAN" + 20);
														ulong length = (ulong)(type._stringLength + type._stringLength);
														return System.SpanHelpers.SequenceEqual(ref *(byte*)(item.m_Type + 20), ref second, length);
													}
												}
												return false;
											}
											return true;
										}
									}
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								});
							}
							object obj3 = Enumerable.FirstOrDefault(allMerchants, predicate2);
							if (obj3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2052 @ rax_v91 (System.Object)+10]");
								transform2 = (Transform)0;
								goto IL_0787;
							}
						}
						transform2 = null;
						goto IL_0787;
					}
				}
			}
			goto IL_0377;
			IL_0377:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ r14_v9 (ArcadeSprite)+190]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ r14_v9 (ArcadeSprite)+190]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1788 @ rax_v40+10]");
			if ((nint)0 != 42)
			{
				Transform trouserMerchant = (Transform)(object)TrouserMerchant;
				if ((object)TrouserMerchant == null || ((UnityEngine.Object)trouserMerchant).m_CachedPtr == (IntPtr)0)
				{
					continue;
				}
				float num;
				for (Transform transform3 = null; (nint)transform3 < 100; transform3 = (Transform)(transform3 + 1), num = 0.96f)
				{
					float2 float5 = MathUtils.RandomPointInAnnulus((float2)list4, 0.48f, 0.96f);
					bool flag8 = !_hasTileSet;
					List<PickupCustomMerchant> list5 = (List<PickupCustomMerchant>)0.48f;
					List<PickupCustomMerchant> list6 = list4;
					if (!flag8)
					{
						bool flag9 = (object)_tilingTileset == null;
						bool flag10 = _tilingTileset.IsPointWithinCollisionLayerWrapped((Vector2)list4);
						list5 = list7;
						list6 = list4;
						list2 = list7;
						list3 = list4;
						if (flag10)
						{
							continue;
						}
					}
					bool flag11 = DoesNewPositionOverlapMerchants(list, float5);
					bool flag12 = !flag11;
					list2 = list5;
					list3 = list6;
					if (!flag12)
					{
						continue;
					}
					Debug.Log("We found a valid spawn point");
					((ArcadeSprite)null).position = float5;
					bool flag13 = list == null;
					list.Add(float5);
					num = 0.96f;
					list2 = list5;
					list3 = list6;
					break;
				}
			}
			else
			{
				bool flag14 = (object)_tilingTileset == null;
				List<SuperObject> scriptsFromName = _tilingTileset.GetScriptsFromName("DISK_MRC");
				bool flag15 = scriptsFromName == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag16 = (object)transform4 == null;
				SuperCustomProperties component = transform4.GetComponent<SuperCustomProperties>();
				bool flag17 = (object)_tilingTileset == null;
				Vector2 spawnPosFromSuperObject = _tilingTileset.GetSpawnPosFromSuperObject((SuperObject)(object)transform4, component);
				((ArcadeSprite)null).position = (float2)list4;
				list2 = list4;
				list3 = list7;
			}
			continue;
			IL_0787:
			if ((object)transform2 != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0)
			{
				Transform transform5 = transform2.transform;
				bool flag18 = (object)transform5 == null;
				Vector3 position2 = transform5.position;
				((ArcadeSprite)null).position = (float2)list4;
				list2 = list4;
				list3 = list4;
				continue;
			}
			goto IL_0377;
		}
	}

	private bool DoesNewPositionOverlapMerchants(List<float2> positionsToAvoid, float2 newPos)
	{
		//IL_0054: Invalid comparison between F4 and O
		//IL_0073: Invalid comparison between F4 and I4
		//IL_009c: Expected O, but got I4
		List<float2>.Enumerator enumerator = default(List<float2>.Enumerator);
		object obj2 = default(object);
		object obj3 = default(object);
		while (enumerator.MoveNext())
		{
			object obj = obj2 - obj3;
			object obj4 = obj2 - obj3;
			object obj5 = obj * obj4;
			object obj6 = newPos * newPos;
			object obj7 = obj6 + obj5;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.2304f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
			float num = 0.2304f - (float)obj7;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj8 = flag4 & flag3;
			if (obj8 != null)
			{
				return true;
			}
		}
		return false;
	}

	public Stage()
	{
		//IL_021c: Expected I4, but got I8
		_maximum = 300;
		_defaultMaximum = 300;
		_minMultiplier = 1f;
		_onlineEnemyMultiplier = 1f;
		_effectiveSpawnFrequency = 1000f;
		StageData stageData = new StageData();
		_stageData = stageData;
		StageData baseStageData = new StageData();
		_baseStageData = baseStageData;
		Dictionary<int, JArray> stageDataByBiome = new Dictionary<int, JArray>();
		_stageDataByBiome = stageDataByBiome;
		List<Vector2> enemySpawnLocations = new List<Vector2>();
		_enemySpawnLocations = enemySpawnLocations;
		List<Vector2> destructibleLocations = new List<Vector2>();
		_destructibleLocations = destructibleLocations;
		List<Vector2> cartLocations = new List<Vector2>();
		_cartLocations = cartLocations;
		List<Vector2> windowLocations = new List<Vector2>();
		_windowLocations = windowLocations;
		List<Vector2> pizzaLocations = new List<Vector2>();
		_pizzaLocations = pizzaLocations;
		List<PizzaCircle> pizzaCircles = new List<PizzaCircle>();
		_pizzaCircles = pizzaCircles;
		List<Vector2> tiledPositions = new List<Vector2>();
		_tiledPositions = tiledPositions;
		List<Rectangle> noShadowLocations = new List<Rectangle>();
		_noShadowLocations = noShadowLocations;
		_shadowsVisible = true;
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> spawnOuterRects = (Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>)(object)new List<Rectangle>();
		_spawnOuterRects = spawnOuterRects;
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> spawnInnerRects = (Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>)(object)new List<Rectangle>();
		_spawnInnerRects = spawnInnerRects;
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> playerRects = (Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect>)(object)new List<Rectangle>();
		_playerRects = playerRects;
		List<EnemyController> list = null;
		EnemyController[] items = null;
		list._items = items;
		_spawnedEnemies = list;
		HashSet<EnemyController> hashSet = null;
		EqualityComparer<object> equalityComparer = EqualityComparer<object>.Default;
		if (equalityComparer == null)
		{
			equalityComparer = EqualityComparer<object>.Default;
		}
		hashSet._comparer = equalityComparer;
		hashSet._freeList = -1;
		hashSet._count = 0;
		hashSet._version = 0;
		int num = hashSet.Initialize(600);
		_authoritativePermanentEnemies = hashSet;
		_isCharmApplied = true;
		List<EnemyType?> enemyTypes = new List<EnemyType?>();
		_enemyTypes = enemyTypes;
		List<EnemyType?> bossTypes = new List<EnemyType?>();
		_bossTypes = bossTypes;
		Dictionary<EnemyType, bool> enemyPoolStates = new Dictionary<EnemyType, bool>();
		_enemyPoolStates = enemyPoolStates;
		Dictionary<EnemyType, bool> bossPoolStates = new Dictionary<EnemyType, bool>();
		_bossPoolStates = bossPoolStates;
		List<Weapon> list2 = new List<Weapon>();
		_003CStageHazardWeapons_003Ek__BackingField = list2;
		_ShadowAlpha = 1f;
		_SoleShadowAlpha = 1f;
		_003CEnemyHealthMultiplier_003Ek__BackingField = 1f;
		_003CEnemySpeedMultiplier_003Ek__BackingField = 1f;
		_003CMaxDestructibles_003Ek__BackingField = 10;
		_003CStageMods_003Ek__BackingField = new StageModifiers
		{
			_003CBGM_rate_003Ek__BackingField = 1f,
			_003CBGM_new_rate_003Ek__BackingField = 1f
		};
		SortedList<uint, EnemyController> queryEnemiesCache = (SortedList<uint, EnemyController>)(object)new SortedList<uint, object>();
		_queryEnemiesCache = queryEnemiesCache;
		List<EnemyController> unsortedEnemiesCache = new List<EnemyController>();
		_unsortedEnemiesCache = unsortedEnemiesCache;
		List<Pickup> onScreenPickupsCache = new List<Pickup>();
		_onScreenPickupsCache = onScreenPickupsCache;
		List<EnemyController> enemiesToCull = new List<EnemyController>();
		_enemiesToCull = enemiesToCull;
		base._onResumeSent = true;
	}

	static Stage()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_09de: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0a06: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0a2e: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0a56: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0a7e: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0aa6: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0ace: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_0af6: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_0b1e: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_0b46: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_0b6e: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_0b96: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_0bbe: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_0be6: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_0c0e: Expected O, but got I
		//IL_06b8: Expected O, but got I
		//IL_0c36: Expected O, but got I
		//IL_0722: Expected O, but got I
		//IL_0c5e: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_0c86: Expected O, but got I
		//IL_07f6: Expected O, but got I
		//IL_0cae: Expected O, but got I
		//IL_0860: Expected O, but got I
		//IL_08b8: Expected O, but got I
		//IL_08e3: Expected O, but got I
		//IL_0909: Expected O, but got I
		//IL_0934: Expected O, but got I
		//IL_095a: Expected O, but got I
		//IL_0985: Expected O, but got I
		//IL_09ab: Expected O, but got I
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)11);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)13);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 13;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)14);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 14;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)16);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v28+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v30+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v32+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v34+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v36+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v38+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)21);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 21;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v40+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)18);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v42+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 20;
		}
		_validStageCharacters = list;
		Coherence.Log.Logger logger = Log.GetLogger<EnemyController>();
		_logger = logger;
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("Stage.SpawnEnemy", 1, MarkerFlags.Default, 0);
		MarkerSpawnEnemy = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("FindClosestEnemy", 1, MarkerFlags.Default, 0);
		MarkerFindClosestEnemy = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("HandleSpawning", 1, MarkerFlags.Default, 0);
		MarkerHandleSpawning = (ProfilerMarker)(nint)intPtr3;
		IntPtr intPtr4 = ProfilerUnsafeUtility.CreateMarker("Stage.SpawnEnemyUnit", 1, MarkerFlags.Default, 0);
		MarkerSpawnEnemyUnit = (ProfilerMarker)(nint)intPtr4;
		IntPtr intPtr5 = ProfilerUnsafeUtility.CreateMarker("Stage.SpawnEnemyUnit.Resolve", 1, MarkerFlags.Default, 0);
		MarkerSpawnEnemyResolve = (ProfilerMarker)(nint)intPtr5;
		IntPtr intPtr6 = ProfilerUnsafeUtility.CreateMarker("Stage.UpdateCulling", 1, MarkerFlags.Default, 0);
		MarkerUpdateCulling = (ProfilerMarker)(nint)intPtr6;
		IntPtr intPtr7 = ProfilerUnsafeUtility.CreateMarker("Stage.DespawnEnemyIfOutsideRect", 1, MarkerFlags.Default, 0);
		MarkerDespawnEnemyIfOutsideRect = (ProfilerMarker)(nint)intPtr7;
	}

	private void _003CCheckHalfMinute_003Eb__253_0()
	{
		_trisection.Spinnn();
	}

	private void _003CStartTimers_003Eb__274_0()
	{
		HandleSpawning();
	}

	private void _003CInitTilingTileset_003Eb__398_0()
	{
		List<Rectangle> noShadowLocations = _noShadowLocations;
		if (noShadowLocations._size > 0)
		{
			bool flag = ShouldWeSeeShadowLayer();
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 55 Invalid \"Jump target not found in method: 0x186E53460\"");
		}
	}

	private bool _003CCheckCanSpawnCustomMerchant_003Eb__412_0(WeaponType w)
	{
		//IL_0073: Expected I4, but got O
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			if (playerOptions._mainGameConfig != null && mainGameConfig._003CUnlockedWeapons_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				bool result = default(bool);
				return result;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool _003CCheckCanSpawnCustomMerchant_003Eb__412_1(ItemType i)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected I4, but got Unknown
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			if (playerOptions._mainGameConfig != null)
			{
				Stage stage = (Stage)(object)mainGameConfig._003CCollectedItems_003Ek__BackingField;
				if (mainGameConfig._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
					object obj = default(object);
					return (byte)(obj ^ 1) != 0;
				}
			}
		}
		throw new NullReferenceException();
	}
}
