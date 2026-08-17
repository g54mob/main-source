using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Bindings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Props;
using Zenject;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundTP_Basic : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<PickupTeleporter, int> _003C_003E9__34_0;

		public static Func<TPSoftBound, bool> _003C_003E9__59_0;

		public static Func<TPSoftBound, bool> _003C_003E9__60_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CCreateCycleGates_003Eb__34_0(PickupTeleporter x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x.GateIndex;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal bool _003CIsWithinAccessibleBounds_003Eb__59_0(TPSoftBound s)
		{
			//IL_0035: Expected I4, but got O
			if (s != null)
			{
				return s.IsAwake;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CIsWithinUnlockedBounds_003Eb__60_0(TPSoftBound s)
		{
			//IL_0035: Expected I4, but got O
			if (s != null)
			{
				return s.IsAwake;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public PizzaCircle triggered;

		public Action _003C_003E9__0;

		internal void _003CCheckBossPizzas_003Eb__0()
		{
			PizzaCircle pizzaCircle = triggered;
			if ((object)triggered == null || ((UnityEngine.Object)pizzaCircle).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			GameObject gameObject = triggered.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject obj;
				if ((object)triggered != null)
				{
					GameObject gameObject2 = triggered.gameObject;
					obj = gameObject2;
				}
				else
				{
					obj = null;
				}
				ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
				pool.Release(obj);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public TPBiomeType biome;

		public Func<TPSoftBound, bool> _003C_003E9__0;

		internal bool _003CTryGreenlight_003Eb__0(TPSoftBound x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (x != null)
			{
				object obj = x.BiomeType - biome;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private TilingTileset _tilingTileset;

	private PlatformZoneMovement _platformMovement;

	private DopplegangerGate _dopplegangerGate;

	private TileSprite _AqueductBG;

	private TileSprite _AqueductWater;

	private List<TileSprite> _AqueductWaters;

	private List<PizzaCircle> BossPizzas;

	private Timer checkBossPizzasTimer;

	private List<PickupTeleporter> cycleGates;

	private PolygonGroupComponent[] _polygonGroups;

	private PolygonGroupComponent _currentPlatformingArea;

	private List<Rectangle> _platformingZones;

	private bool _created;

	private List<TPSoftBound> _softBounds;

	private List<TPSoftBound> _awakeSoftBounds;

	private List<TPBiomeType> _unlockedBiomes;

	private List<TPBiomeType> _accessibleBiomes;

	private TileSprite _deathFightBG;

	private TileSprite _deathFightTile;

	private PhaserSprite _deathFightTileTop;

	private float2? _deathFightStartCameraPos;

	private bool hasWater;

	private TPBiomeType? _currentBiome;

	public TPBiomeType? CurrentBiome => _currentBiome;

	private void DifficultyModifier()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_055a: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0589: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_05b1: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_05d9: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0601: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_02db: Expected O, but got I4
		//IL_034e: Expected O, but got I
		//IL_0502: Expected O, but got I4
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected O, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		List<ItemType> list = new List<ItemType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v15+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)220);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 220;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v17+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)221);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 221;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v19+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)222);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 222;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v21+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)223);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 223;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v23+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)224);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 224;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v25+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)225);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 225;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list2 = config._003CCollectedItems_003Ek__BackingField;
		object obj13 = 0;
		object obj15 = default(object);
		object obj14 = obj15;
		object obj17 = default(object);
		object obj16 = obj17;
		object obj18 = default(object);
		object obj21 = default(object);
		while (true)
		{
			if (obj16 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rcx_v10+1C]");
				if (obj18 != null)
				{
					break;
				}
				object obj19 = obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rcx_v10+18]");
				if ((nint)obj19 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rcx_v10+10]");
				object obj20 = 0;
				obj14++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rsi_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag = (nint)obj21 == -1;
					obj16 = obj17;
					if (!flag)
					{
						obj13++;
						obj16 = obj17;
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		if (obj16 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rcx_v10+1C]");
			if (obj18 == null)
			{
				float num7 = (float)obj13 * 0.1f;
				float charmMod = num7 + 0.4f;
				CharmMod = charmMod;
				float num8 = (float)obj13 * 0.1f;
				float curseMod = num8 + 0.4f;
				CurseMod = curseMod;
				GameManager core2 = GM.Core;
				core2._stage.ResetStageMinimumSpawnToDefault();
				GameManager core3 = GM.Core;
				Stage stage = core3._stage;
				stage._maximum = stage._defaultMaximum;
				GameManager core4 = GM.Core;
				core4._stage.RecalculateCurseAndCharm();
				GameManager core5 = GM.Core;
				Stage stage2 = core5._stage;
				StageModifiers stageModifiers = stage2._003CStageMods_003Ek__BackingField;
				float num9 = (float)obj13 * 0.02f;
				float num10 = 1f - num9;
				if ((object)stageModifiers._003CEnemyHealthMultiplier_003Ek__BackingField != null)
				{
					float num11 = (float)obj13 * 0.05f;
					float num12 = num11 + 1f;
					object obj22 = default(object);
					float enemyHealthMultiplier = num12 * (float)obj22;
					GameManager.EnemyHealthMultiplier = enemyHealthMultiplier;
					if ((object)stageModifiers._003CXpBonus_003Ek__BackingField != null)
					{
						float experienceMultiplier = (float)obj22 * num10;
						GameManager.ExperienceMultiplier = experienceMultiplier;
						return;
					}
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new IndexOutOfRangeException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			obj16 = 0;
		}
		throw new NullReferenceException();
	}

	private void SnapEggs()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			float num = core2._eggManager.RemoveBonuses();
		}
	}

	public override string GetDetailedMap(StageData stageData)
	{
		//IL_013f: Expected O, but got I4
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					bool flag = (nint)0 == 0;
					string text = "MapTP";
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						bool flag2 = (nint)obj == -1;
						text = "MapTP";
						if (!flag2)
						{
							text = "MapTP_Full";
						}
					}
					bool flag3 = SpriteLoader.LoadTexture(text, "Gameplay", (DlcType?)(object)1);
					return text;
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public override void Create()
	{
		//IL_0544: Expected O, but got I4
		//IL_0202: Expected I4, but got O
		//IL_042d: Expected O, but got I
		//IL_0442: Expected O, but got I
		DifficultyModifier();
		base.Create();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		_tilingTileset = stage._tilingTileset;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		List<Rectangle> scriptRectangularLocations = stage2._tilingTileset.GetScriptRectangularLocations("PlatformingZone", autoScaleAndOffset: true);
		_platformingZones = scriptRectangularLocations;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		List<Rectangle> scriptRectangularLocations2 = stage3._tilingTileset.GetScriptRectangularLocations("CutscenePlatformingZone", autoScaleAndOffset: true);
		if (scriptRectangularLocations2 != null && scriptRectangularLocations2._size > 0)
		{
			if (scriptRectangularLocations2._size <= 0)
			{
				goto IL_0534;
			}
			Rectangle[] items = scriptRectangularLocations2._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4C30");
		}
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		bool flag;
		if ((object)stage4._tilingTileset != null)
		{
			GameObject defaultSupportMap = stage4._tilingTileset.DefaultSupportMap;
			if ((object)defaultSupportMap != null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v853 @ rbx_v10 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				PolygonGroupComponent[] componentsInChildren = defaultSupportMap.GetComponentsInChildren<PolygonGroupComponent>(includeInactive: false);
				flag = (byte)(int)componentsInChildren != 0;
				goto IL_053a;
			}
		}
		flag = false;
		goto IL_053a;
		IL_053a:
		_polygonGroups = (PolygonGroupComponent[])flag;
		if (_polygonGroups != null)
		{
			PolygonGroupComponent[] polygonGroups = _polygonGroups;
			if (polygonGroups.Length != 0)
			{
				_platformMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
			}
		}
		GameManager core5 = GM.Core;
		PlayerOptionsData config = core5._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1 && GM.Core.IsStageHost)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F972D0");
				AsyncOperationHandle<object> asyncOperationHandle = default(AsyncOperationHandle<object>);
				object obj2 = asyncOperationHandle.WaitForCompletion();
				TP_BossArena tP_BossArena = TryAddingBossArena((GameObject)obj2, "Beelzebub", EnemyType.TP_BOSS_BEELZEBUB);
				tP_BossArena._fadeToSilenceInsteadOfMusic = false;
				TP_BossArena tP_BossArena2 = TryAddingBossArena((GameObject)obj2, "Legion", EnemyType.TP_BOSS_LEGION);
				Addressables.Release((GameObject)obj2);
				object obj4 = default(object);
				object obj3 = obj4;
			}
		}
		GameManager core6 = GM.Core;
		Stage stage5 = core6._stage;
		List<Vector2> specialLocations = stage5._tilingTileset.GetSpecialLocations("DopplegangerSpawn");
		if (specialLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0534;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v39 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v44+24]");
				object obj3 = 0;
				float2 position = default(float2);
				CreateDopplegangerGate(position);
			}
		}
		CreateAqueductWater();
		CreateBossPizzas();
		if (checkBossPizzasTimer != null)
		{
			checkBossPizzasTimer.Cancel();
		}
		Action onComplete = CheckBossPizzas;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.3f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		checkBossPizzasTimer = timer;
		CreateCycleGates();
		CreateSoftBounds();
		LinkDoorsToBiomes();
		_created = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
		return;
		IL_0534:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private TP_BossArena TryAddingBossArena(GameObject prefab, string enemyName, EnemyType enemyType)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
		if ((object)gameObject != null)
		{
			TP_BossArena component = gameObject.GetComponent<TP_BossArena>();
			if ((object)component != null)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._multiplayer != null)
				{
					if (!core._multiplayer.IsOnlineMultiplayer)
					{
						component.PerformSetup((int)enemyType, enemyName);
					}
					else
					{
						Action<int, string> action = component.PerformSetup;
						if ((object)component._sync == null)
						{
							goto IL_011e;
						}
						object param = default(object);
						bool flag = component._sync.SendCommand((Action<int, object>)action, MessageTarget.All, (int)enemyType, param);
					}
					return component;
				}
			}
		}
		goto IL_011e;
		IL_011e:
		return (TP_BossArena)(object)new NullReferenceException();
	}

	private void CreateAqueductWater()
	{
		//IL_00da: Expected O, but got I4
		//IL_013d: Expected I4, but got I8
		//IL_01f6: Expected I4, but got I8
		//IL_0305: Expected O, but got I4
		//IL_0333: Expected O, but got I4
		//IL_045f: Expected O, but got I4
		//IL_041e: Expected O, but got I4
		//IL_046d->IL05a7: Incompatible stack heights: 16 vs 0
		//IL_042c->IL05a7: Incompatible stack heights: 16 vs 0
		List<TileSprite> aqueductWaters = new List<TileSprite>();
		_AqueductWaters = aqueductWaters;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("AqueductCorner");
		if (scriptsFromName == null || scriptsFromName._size <= 0)
		{
			return;
		}
		hasWater = true;
		object obj = 4;
		BackgroundTP_Basic behaviour = this;
		List<SuperObject>.Enumerator enumerator = default(List<SuperObject>.Enumerator);
		float height = default(float);
		string textureName = default(string);
		string spriteName = default(string);
		object obj2 = default(object);
		Vector3 value = default(Vector3);
		Vector3 value2 = default(Vector3);
		BackgroundTP_Basic backgroundTP_Basic = default(BackgroundTP_Basic);
		while (enumerator.MoveNext())
		{
			TileSprite tileSprite = RenderingExtensions.AddTileSprite(behaviour, 0f, 0f, 1.28f, height, textureName, spriteName);
			bool flag = (object)tileSprite == null;
			TileSprite tileSprite2 = tileSprite.SetDepth(-2002);
			bool flag2 = (object)tileSprite2 == null;
			GameObject gameObject = tileSprite2.gameObject;
			bool flag3 = (object)gameObject == null;
			((UnityEngine.Object)gameObject).SetName("TP_VFX_CanalBG");
			float width = (float)obj * 0.32f;
			TileSprite tileSprite3 = RenderingExtensions.AddTileSprite(behaviour, 0f, 0f, width, height, textureName, spriteName);
			bool flag4 = (object)tileSprite3 == null;
			TileSprite tileSprite4 = tileSprite3.SetDepth(-2001);
			bool flag5 = (object)tileSprite4 == null;
			GameObject gameObject2 = tileSprite4.gameObject;
			bool flag6 = (object)gameObject2 == null;
			((UnityEngine.Object)gameObject2).SetName("TP_VFX_CanalWater");
			Material material = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
			bool flag7 = (object)tileSprite4._spriteRenderer == null;
			((Renderer)tileSprite4._spriteRenderer).SetMaterial(material);
			bool flag8 = (object)tileSprite2._spriteRenderer == null;
			((Renderer)tileSprite2._spriteRenderer).SetMaterial(material);
			float num = 84f * 0.32f;
			float num2 = num * -0.5f;
			TileSprite tileSprite5 = RenderingExtensions.SetScale(tileSprite2, 1f);
			TileSprite tileSprite6 = tileSprite2.SetTileScale(1f, (float?)(object)0);
			TileSprite tileSprite7 = RenderingExtensions.SetScale(tileSprite4, 1f);
			TileSprite tileSprite8 = tileSprite4.SetTileScale(1f, (float?)(object)0);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(tileSprite4._spriteRenderer, 0.5f);
			Transform transform = ((Component)null).transform;
			bool flag9 = (object)transform == null;
			bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Transform transform2 = tileSprite2.transform;
			float num3 = (float)obj2 + num2;
			bool flag11 = (object)transform2 == null;
			bool flag12 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
			Transform transform3 = tileSprite4.transform;
			bool flag13 = (object)transform3 == null;
			bool flag14 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
			List<object> aqueductWaters2 = (List<object>)(object)backgroundTP_Basic._AqueductWaters;
			bool flag15 = backgroundTP_Basic._AqueductWaters == null;
			int version = aqueductWaters2._version + 1;
			aqueductWaters2._version = version;
			object[] items = aqueductWaters2._items;
			bool flag16 = aqueductWaters2._items == null;
			if (aqueductWaters2._size >= items.Length)
			{
				((List<object>)(object)backgroundTP_Basic._AqueductWaters).AddWithResize((object)tileSprite4);
				obj = 4;
				behaviour = backgroundTP_Basic;
			}
			else
			{
				int size = aqueductWaters2._size + 1;
				aqueductWaters2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				obj = 4;
				behaviour = backgroundTP_Basic;
			}
		}
	}

	private unsafe void CreateBossPizzas()
	{
		//IL_00be: Expected F4, but got I4
		//IL_026b: Expected O, but got I4
		//IL_029e: Expected O, but got Ref
		//IL_029e: Expected O, but got Ref
		//IL_01f2->IL03d6: Incompatible stack heights: 3 vs 0
		//IL_0175->IL01c1: Incompatible stack heights: 4 vs 3
		//IL_0241->IL03d6: Incompatible stack heights: 4 vs 0
		//IL_01bc->IL03d6: Incompatible stack heights: 5 vs 0
		//IL_01c1->IL01c1: Incompatible stack heights: 5 vs 3
		//IL_036f->IL03d6: Incompatible stack heights: 9 vs 0
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("BossSpawn");
		if (scriptsFromName == null || scriptsFromName._size <= 0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		float num = 0f;
		List<SuperObject> list = scriptsFromName;
		List<SuperObject>.Enumerator enumerator = default(List<SuperObject>.Enumerator);
		object obj = default(object);
		List<SuperObject> list2 = default(List<SuperObject>);
		Quaternion quaternion2 = default(Quaternion);
		while (enumerator.MoveNext())
		{
			Transform transform = ((Component)null).transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			List<SuperObject> ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			SuperCustomProperties component = ((Component)null).GetComponent<SuperCustomProperties>();
			bool flag3 = (object)component == null;
			if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "requiresItem", out var property))
			{
				bool flag4 = property == null;
				if (Enum.Parse<ItemType>(property.m_Value) != ItemType.VOID)
				{
					bool flag5 = config._003CCollectedItems_003Ek__BackingField == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
					if (obj == null)
					{
						continue;
					}
				}
			}
			if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "enemyType", out var property2))
			{
				bool flag6 = property2 == null;
				if (Enum.Parse<EnemyType>(property2.m_Value) != EnemyType.BAT1)
				{
					EnemyType enemyType = Enum.Parse<EnemyType>(property2.m_Value);
					bool flag7 = enemyType == EnemyType.BAT1;
					ObjectPool pool = ((MasterObjectPooler)enemyType).GetPool("PizzaCircles");
					bool flag8 = (object)pool == null;
					GameObject gameObject = pool.GetObject((Vector3)(&list2), (Quaternion)(&quaternion2));
					bool flag9 = (object)gameObject == null;
					PizzaCircle component2 = gameObject.GetComponent<PizzaCircle>();
					bool flag10 = (object)component2 == null;
					component2.Init(24f);
					component2.SetAlpha(1f);
					component2.SetSprite("TP_items", "TP_BOSSPIZZA");
					component2.SetMapToken("TP_items", "TP_BossToken");
					bool flag11 = BossPizzas == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4300");
					num = 1f;
					list = ret;
				}
			}
		}
	}

	private unsafe void CheckBossPizzas()
	{
		//IL_0038: Expected O, but got Ref
		//IL_0058: Expected O, but got Ref
		//IL_0260: Expected O, but got I4
		//IL_03c5: Expected I4, but got F4
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass32_0();
		CS_0024_003C_003E8__locals21.triggered = null;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<PizzaCircle>.Enumerator enumerator3 = default(List<PizzaCircle>.Enumerator);
		SoundManager.SoundConfig soundConfig2 = default(SoundManager.SoundConfig);
		SoundManager.SoundConfig triggered4;
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			bool flag = BossPizzas == null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			if (flag)
			{
				throw new NullReferenceException();
			}
			if (enumerator3.MoveNext())
			{
				SoundManager.SoundConfig soundConfig = null;
				List<PizzaCircle>.Enumerator enumerator4 = (List<PizzaCircle>.Enumerator)(&enumerator3);
				throw new NullReferenceException();
			}
			PizzaCircle triggered = CS_0024_003C_003E8__locals21.triggered;
			if ((object)CS_0024_003C_003E8__locals21.triggered == null || ((UnityEngine.Object)triggered).m_CachedPtr == (IntPtr)0)
			{
				continue;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				PizzaCircle triggered2 = CS_0024_003C_003E8__locals21.triggered;
				if ((object)CS_0024_003C_003E8__locals21.triggered != null)
				{
					bool flag2 = !((SoundManager.SoundConfig)(object)triggered2).Mute;
					object triggered3 = CS_0024_003C_003E8__locals21.triggered;
					if (!flag2)
					{
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)(((SoundManager.SoundConfig)(object)triggered2).Mute ? 1 : 0));
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						bool flag3 = (object)transform == null;
						triggered4 = (SoundManager.SoundConfig)(object)CS_0024_003C_003E8__locals21.triggered;
						if (!flag3)
						{
							Vector3 position = transform.position;
							bool flag4 = (object)core._stage == null;
							triggered4 = (SoundManager.SoundConfig)(object)CS_0024_003C_003E8__locals21.triggered;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
								if (soundConfig2 != null && soundConfig2.Mute)
								{
									_ = 257;
									_ = 1;
								}
								break;
							}
							throw new NullReferenceException();
						}
						triggered3 = triggered4;
						throw new NullReferenceException();
					}
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(triggered3);
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		bool flag5 = (object)CS_0024_003C_003E8__locals21.triggered == null;
		triggered4 = soundConfig2;
		if (!flag5)
		{
			CS_0024_003C_003E8__locals21.triggered.ShowFinalWarning();
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Rate = 1f;
			soundConfig3.Volume = (float?)(object)1;
			float value = UnityEngine.Random.value;
			float detune = value * 500f;
			soundConfig3.Detune = detune;
			soundConfig3.Rate = 1f;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig3, 150f, 2, num);
			bool flag6 = (object)CS_0024_003C_003E8__locals21.triggered == null;
			triggered4 = soundConfig3;
			if (!flag6)
			{
				CS_0024_003C_003E8__locals21.triggered.CleanUp();
				bool flag7 = BossPizzas == null;
				triggered4 = soundConfig3;
				if (!flag7)
				{
					bool flag8 = ((List<object>)(object)BossPizzas).Remove((object)CS_0024_003C_003E8__locals21.triggered);
					Action onComplete = CS_0024_003C_003E8__locals21._003C_003E9__0;
					if (CS_0024_003C_003E8__locals21._003C_003E9__0 == null)
					{
						onComplete = (CS_0024_003C_003E8__locals21._003C_003E9__0 = delegate
						{
							PizzaCircle triggered5 = CS_0024_003C_003E8__locals21.triggered;
							if ((object)CS_0024_003C_003E8__locals21.triggered != null && ((UnityEngine.Object)triggered5).m_CachedPtr != (IntPtr)0)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals21.triggered.gameObject;
								if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
								{
									GameObject obj;
									if ((object)CS_0024_003C_003E8__locals21.triggered != null)
									{
										GameObject gameObject2 = CS_0024_003C_003E8__locals21.triggered.gameObject;
										obj = gameObject2;
									}
									else
									{
										obj = null;
									}
									ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
									pool.Release(obj);
								}
							}
						});
					}
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					return;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public void CreateCycleGatesDelayed()
	{
		Action onComplete = delegate
		{
			CreateCycleGates();
			GreenlightBiomes();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void CreateCycleGates()
	{
		//IL_0067: Expected O, but got I
		//IL_00c1: Expected O, but got I
		//IL_0145: Expected O, but got I
		//IL_019f: Expected O, but got I
		//IL_01fe: Expected O, but got I
		//IL_0258: Expected O, but got I
		//IL_02b7: Expected O, but got I
		//IL_0311: Expected O, but got I
		//IL_0370: Expected O, but got I
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6c: Expected O, but got Unknown
		//IL_03ca: Expected O, but got I
		//IL_0429: Expected O, but got I
		//IL_0a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa3: Expected O, but got Unknown
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Expected O, but got Unknown
		//IL_0483: Expected O, but got I
		//IL_04e2: Expected O, but got I
		//IL_053c: Expected O, but got I
		//IL_0a0d: Expected O, but got I
		//IL_083e: Expected I, but got O
		//IL_084c: Expected I, but got O
		//IL_085c: Expected O, but got I
		//IL_08dc: Expected O, but got I4
		//IL_0898: Expected O, but got I
		//IL_08ce: Expected O, but got I4
		//IL_0971: Expected O, but got I4
		//IL_0988: Expected O, but got I4
		//IL_071b->IL0c76: Incompatible stack heights: 3 vs 0
		//IL_0a12->IL0a12: Incompatible stack heights: 1 vs 0
		//IL_077b->IL0c76: Incompatible stack heights: 4 vs 0
		//IL_0d0d->IL0c76: Incompatible stack heights: 5 vs 0
		//IL_092e->IL0c76: Incompatible stack heights: 5 vs 0
		//IL_09a5->IL0c76: Incompatible stack heights: 7 vs 0
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		List<int> list2 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v13+18]");
		if (num >= 0)
		{
			list2.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rbx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v145+18]");
				if (num2 >= 0)
				{
					list2.AddWithResize(1);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
					object obj5 = (nint)0 + (nint)1;
					_ = 1;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rbx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj6 = default(object);
				if ((nint)obj6 != -1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v143+18]");
					if (num3 >= 0)
					{
						list2.AddWithResize(2);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj8 = (nint)0 + (nint)1;
						_ = 2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rbx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj9 = default(object);
					if ((nint)obj9 != -1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rcx_v141+18]");
						if (num4 >= 0)
						{
							list2.AddWithResize(3);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj11 = (nint)0 + (nint)1;
							_ = 3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rbx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj12 = default(object);
						if ((nint)obj12 != -1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v139+18]");
							if (num5 >= 0)
							{
								list2.AddWithResize(4);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj14 = (nint)0 + (nint)1;
								_ = 4;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rbx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj15 = default(object);
							if ((nint)obj15 != -1)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj16 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v137+18]");
								if (num6 >= 0)
								{
									list2.AddWithResize(5);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
									object obj17 = (nint)0 + (nint)1;
									_ = 5;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rbx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj18 = default(object);
								if ((nint)obj18 != -1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
									object obj19 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rcx_v135+18]");
									if (num7 >= 0)
									{
										list2.AddWithResize(6);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
										object obj20 = (nint)0 + (nint)1;
										_ = 6;
									}
								}
							}
						}
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)0 < (nint)2)
		{
			return;
		}
		List<PickupTeleporter>.Enumerator enumerator = default(List<PickupTeleporter>.Enumerator);
		if (enumerator.MoveNext())
		{
			throw new NullReferenceException();
		}
		List<PickupTeleporter> list3 = cycleGates;
		int version = list3._version + 1;
		list3._version = version;
		list3._size = 0;
		if (list3._size > 0)
		{
			Array.Clear(list3._items, 0, list3._size);
		}
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("CYCLEGATE");
		bool flag = scriptsFromName == null;
		PickupGuarded pickupGuarded = null;
		List<PickupTeleporter>.Enumerator enumerator2 = (List<PickupTeleporter>.Enumerator)cycleGates;
		List<SuperObject> list4 = scriptsFromName;
		string text = "Scripts";
		if (!flag)
		{
			bool flag2 = scriptsFromName._size <= 0;
			pickupGuarded = null;
			enumerator2 = (List<PickupTeleporter>.Enumerator)cycleGates;
			list4 = scriptsFromName;
			text = "Scripts";
			if (!flag2)
			{
				enumerator2 = (List<PickupTeleporter>.Enumerator)scriptsFromName;
				list4 = scriptsFromName;
				List<SuperObject>.Enumerator enumerator3 = default(List<SuperObject>.Enumerator);
				Vector2 vector2 = default(Vector2);
				while (enumerator3.MoveNext())
				{
					Transform transform = ((Component)null).transform;
					bool flag3 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v92 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ rax_v92 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					SuperCustomProperties component = ((Component)null).GetComponent<SuperCustomProperties>();
					bool flag5 = (object)component == null;
					bool flag6 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "index", out var property);
					bool flag7 = !flag6;
					list4 = null;
					if (flag7)
					{
						continue;
					}
					bool flag8 = property == null;
					int num8 = StringExtensions.ToInt(property.m_Value);
					bool flag9 = list2.Contains(num8);
					bool flag10 = !flag9;
					list4 = null;
					if (flag10)
					{
						continue;
					}
					bool flag11 = (object)GM.Core == null;
					Vector2 vector;
					Pickup pickup;
					if (!GM.Core.IsStageHost)
					{
						bool flag12 = NetworkItems.IsNetworkItem(ItemType.TP_CYCLEGATE);
						vector = (Vector2)enumerator2;
						pickup = null;
						if (flag12)
						{
							goto IL_081b;
						}
					}
					Pickup pickup2 = PickupManager.CreatePickup(vector2, ItemType.TP_CYCLEGATE);
					bool flag13 = (object)pickup2 != null;
					vector = vector2;
					pickup = pickup2;
					if (!flag13)
					{
						goto IL_081b;
					}
					nint num9 = (nint)pickup2;
					nint num10 = (nint)typeof(TP_CycleGate);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2552 @ rdx_v56 (Il2CppClass<VampireSurvivors.Objects.Items.TP_CycleGate>)+130]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2551 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2552 @ rdx_v56 (Il2CppClass<VampireSurvivors.Objects.Items.TP_CycleGate>)+130]");
					object obj23;
					if (num11 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2551 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2610 @ rax_v129+FFFFFFF8+v2553 @ rax_v125*8]");
						if (0 == (nint)typeof(TP_CycleGate))
						{
							obj23 = 1;
							goto IL_0cbd;
						}
					}
					obj23 = 0;
					goto IL_0cbd;
					IL_0cbd:
					bool flag14 = obj23 == null;
					enumerator2 = (List<PickupTeleporter>.Enumerator)vector2;
					list4 = (List<SuperObject>)(object)pickup2;
					List<ItemType> list5 = null;
					if (!flag14)
					{
						enumerator2 = (List<PickupTeleporter>.Enumerator)vector2;
						list4 = (List<SuperObject>)(object)pickup2;
						list5 = (List<ItemType>)(object)pickup2;
					}
					goto IL_0cf5;
					IL_0cf5:
					if (list5 == null)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rbx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
					if ((nint)0 != 0)
					{
						((TP_CycleGate)(object)list5).SetGateIndex(num8);
						bool flag15 = (object)GM.Core == null;
						bool isMultiplayer = GM.Core.IsMultiplayer;
						List<PickupTeleporter>.Enumerator enumerator4 = (List<PickupTeleporter>.Enumerator)5000;
						if (!isMultiplayer)
						{
							enumerator4 = (List<PickupTeleporter>.Enumerator)2000;
						}
						bool flag16 = cycleGates == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4E00");
						enumerator2 = enumerator4;
					}
					continue;
					IL_081b:
					enumerator2 = (List<PickupTeleporter>.Enumerator)vector;
					list4 = (List<SuperObject>)(object)pickup;
					list5 = null;
					goto IL_0cf5;
				}
				Func<PickupTeleporter, int> keySelector = _003C_003Ec._003C_003E9__34_0;
				if (_003C_003Ec._003C_003E9__34_0 == null)
				{
					Func<PickupTeleporter, int> func = (_003C_003Ec._003C_003E9__34_0 = delegate(PickupTeleporter x)
					{
						//IL_0035: Expected I4, but got O
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (int)ex;
						}
						return x.GateIndex;
					});
					list4 = null;
					keySelector = func;
				}
				IOrderedEnumerable<PickupTeleporter> orderedEnumerable = Enumerable.OrderBy(cycleGates, keySelector);
				bool flag17 = orderedEnumerable == null;
				List<object> list6 = new List<object>(orderedEnumerable);
				cycleGates = (List<PickupTeleporter>)(object)list6;
				pickupGuarded = null;
				text = (string)0;
			}
		}
		List<PickupTeleporter> list7 = cycleGates;
		List<ItemType> list8 = null;
		List<ItemType> list9 = null;
		PickupTeleporter pickupTeleporter = default(PickupTeleporter);
		PickupTeleporter gate = default(PickupTeleporter);
		while ((nint)list9 < list7._size)
		{
			List<PickupTeleporter> list10 = cycleGates;
			object obj24 = list8 + 1;
			bool flag18 = (nint)obj24 >= list10._size;
			List<ItemType> list11 = null;
			if (!flag18)
			{
				list11 = (List<ItemType>)(list8 + 1);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			pickupTeleporter.LinkTo(gate);
			list8 = (List<ItemType>)(list8 + 1);
			list7 = cycleGates;
			text = null;
			list9 = list8;
		}
	}

	public unsafe Rect GetRectFromSuperObject(float xMin, float yMin, float xMax, float yMax, bool skipInverseCalculation = false)
	{
		//IL_0057: Expected native int or pointer, but got O
		//IL_0064: Expected native int or pointer, but got O
		//IL_0080: Expected native int or pointer, but got O
		//IL_008d: Expected native int or pointer, but got O
		float num = xMin * 0.01f;
		object obj = default(object);
		float num2 = (float)obj * -0.01f;
		object obj2 = default(object);
		float num3 = (float)obj2 * 0.01f;
		float num4 = yMin * -0.01f;
		float width = num3 - num;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = num;
		((Rect*)(nint)rect)->m_YMin = num2;
		float height = num4 - num2;
		((Rect*)(nint)rect)->m_Width = width;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	private unsafe void LinkDoorsToBiomes()
	{
		//IL_0171: Expected O, but got Ref
		//IL_0196: Expected I, but got O
		//IL_01a6: Expected O, but got I
		//IL_0226: Expected O, but got I4
		//IL_01e2: Expected O, but got I
		//IL_0218: Expected O, but got I4
		//IL_017b->IL0326: Incompatible stack heights: 5 vs 0
		//IL_0389->IL0326: Incompatible stack heights: 5 vs 0
		//IL_02c4->IL0326: Incompatible stack heights: 7 vs 0
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("TP_DOOR");
		if (scriptsFromName == null || scriptsFromName._size <= 0)
		{
			return;
		}
		string text = "Scripts";
		List<SuperObject>.Enumerator enumerator = default(List<SuperObject>.Enumerator);
		List<SuperObject> pos = default(List<SuperObject>);
		while (enumerator.MoveNext())
		{
			SuperCustomProperties component = ((Component)null).GetComponent<SuperCustomProperties>();
			GameManager core2 = GM.Core;
			bool flag = (object)GM.Core == null;
			bool flag2 = (object)component == null;
			Transform transform = component.transform;
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			bool flag5 = (object)core2._stage == null;
			Destructible destructible = core2._stage.MakeDestructible(PropType.TP_DOOR, (Vector2)pos);
			bool flag6 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "BiomeType", out var property);
			bool flag7 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "DoorType", out var property2);
			bool flag8 = (object)destructible == null;
			text = (string)(&property2);
			if (flag8)
			{
				continue;
			}
			text = (string)(object)destructible;
			nint num = (nint)typeof(TP_PropDoor);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Props.TP_PropDoor>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r8_v5 (System.String)+130]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Props.TP_PropDoor>)+130]");
			object obj3;
			if (num2 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r8_v5 (System.String)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v48+FFFFFFF8+v875 @ rax_v37*8]");
				if (0 == (nint)typeof(TP_PropDoor))
				{
					obj3 = 1;
					goto IL_034c;
				}
			}
			obj3 = 0;
			goto IL_034c;
			IL_034c:
			bool flag9 = obj3 == null;
			Destructible destructible2 = null;
			if (!flag9)
			{
				destructible2 = destructible;
			}
			if ((object)destructible2 != null)
			{
				bool flag10 = property == null;
				TPBiomeType relicFromBiomeType = Enum.Parse<TPBiomeType>(property.m_Value);
				((TP_PropDoor)destructible2).SetRelicFromBiomeType(relicFromBiomeType);
				bool flag11 = property2 == null;
				int type = StringExtensions.ToInt(property2.m_Value);
				((TP_PropDoor)destructible2).SetType(type);
				text = null;
			}
		}
	}

	private unsafe void CreateSoftBounds()
	{
		//IL_011a: Expected O, but got Ref
		List<TPSoftBound> softBounds = new List<TPSoftBound>();
		_softBounds = softBounds;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._tilingTileset != null)
			{
				List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("SoftBounds", "SoftBounds");
				List<SuperObject>.Enumerator enumerator = default(List<SuperObject>.Enumerator);
				if (scriptsFromName != null && scriptsFromName._size > 0 && enumerator.MoveNext())
				{
					Component component = null;
					List<SuperObject>.Enumerator enumerator2 = (List<SuperObject>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				GreenlightBiomes();
				List<TPSoftBound> awakeSoftBounds = new List<TPSoftBound>();
				_awakeSoftBounds = awakeSoftBounds;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void GreenlightBiomes()
	{
		//IL_00b0: Expected O, but got I
		List<TPBiomeType> accessibleBiomes = _accessibleBiomes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Stages.TPBiomeType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<System.Int32Enum> accessibleBiomes2 = (List<System.Int32Enum>)(object)_accessibleBiomes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4 (Il2CppMethodInfo)+18]");
		if (num2 >= 0)
		{
			accessibleBiomes2.AddWithResize((System.Int32Enum)0);
			num = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj = (nint)0 + (nint)1;
			_ = 0;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CCollectedItems_003Ek__BackingField != null)
		{
			((List<TPBiomeType>)(object)config._003CCollectedItems_003Ek__BackingField).Add((TPBiomeType)220);
			object obj2 = default(object);
			if (obj2 != null)
			{
				_accessibleBiomes.Add(TPBiomeType.Entrance);
				_accessibleBiomes.Add(TPBiomeType.Gallery);
				_accessibleBiomes.Add(TPBiomeType.Alchemy);
			}
			((List<TPBiomeType>)(object)config._003CCollectedItems_003Ek__BackingField).Add((TPBiomeType)221);
			object obj3 = default(object);
			if (obj3 != null)
			{
				_accessibleBiomes.Add(TPBiomeType.Library);
			}
			((List<TPBiomeType>)(object)config._003CCollectedItems_003Ek__BackingField).Add((TPBiomeType)222);
			object obj4 = default(object);
			if (obj4 != null)
			{
				_accessibleBiomes.Add(TPBiomeType.Tower);
			}
			((List<TPBiomeType>)(object)config._003CCollectedItems_003Ek__BackingField).Add((TPBiomeType)219);
			object obj5 = default(object);
			if (obj5 != null)
			{
				_accessibleBiomes.Add(TPBiomeType.Aqueduct);
			}
			((List<TPBiomeType>)(object)config._003CCollectedItems_003Ek__BackingField).Add((TPBiomeType)224);
			object obj6 = default(object);
			if (obj6 != null)
			{
				_accessibleBiomes.Add(TPBiomeType.Underground);
			}
			((List<TPBiomeType>)(object)config._003CCollectedItems_003Ek__BackingField).Add((TPBiomeType)225);
			object obj7 = default(object);
			if (obj7 != null)
			{
				_accessibleBiomes.Add(TPBiomeType.Chapel);
			}
		}
		else
		{
			Debug.LogWarning("BackgroundTP_Basic: No collected items to setup softbounds");
		}
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_TELEPORT1);
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_TELEPORT2);
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_TELEPORT2);
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_TELEPORT3);
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_TELEPORT4);
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_BLACK_DISK);
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_TELEPORT5);
		TryGreenlight(config._003CCollectedItems_003Ek__BackingField, ItemType.TP_RELIC_TELEPORT6);
	}

	private unsafe void TryGreenlight(List<ItemType> collected, ItemType item, TPBiomeType biome)
	{
		//IL_010f: Expected O, but got Ref
		//IL_011d: Expected O, but got I4
		//IL_0173: Expected I, but got O
		//IL_01fe: Expected O, but got I4
		//IL_01ab: Expected O, but got I
		//IL_01b4: Expected O, but got I4
		//IL_028e: Expected O, but got I
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_036c: Expected I4, but got O
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_0266: Expected O, but got I4
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass39_0();
		TPBiomeType biome2 = default(TPBiomeType);
		CS_0024_003C_003E8__locals5.biome = biome2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA60A0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6040");
		}
		Func<TPSoftBound, bool> predicate = CS_0024_003C_003E8__locals5._003C_003E9__0;
		if (CS_0024_003C_003E8__locals5._003C_003E9__0 == null)
		{
			Func<TPSoftBound, bool> func = (CS_0024_003C_003E8__locals5._003C_003E9__0 = delegate(TPSoftBound x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if (x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj16 = x.BiomeType - CS_0024_003C_003E8__locals5.biome;
				return obj16 == null;
			});
			biome2 = TPBiomeType.Forest;
			predicate = func;
		}
		IEnumerable<TPSoftBound> enumerable = Enumerable.Where(_softBounds, predicate);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		SignalBus signalBus = default(SignalBus);
		object obj3 = (object)(&signalBus);
		SignalBus signalBus2 = null;
		object obj4 = 0;
		object obj5 = default(object);
		object obj14 = default(object);
		object obj15 = default(object);
		while (true)
		{
			object obj6;
			object obj13;
			if (signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj5 != null)
				{
					bool flag = signalBus == null;
					signalBus2 = null;
					if (!flag)
					{
						nint num = (nint)signalBus;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r10_v6 (Il2CppClass<Zenject.SignalBus>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_01eb;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r10_v6 (Il2CppClass<Zenject.SignalBus>)+B0]");
						obj6 = 0;
						object obj7 = 0;
						while (true)
						{
							object obj8 = obj7 + obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ r8_v12+v519 @ rax_v33*8]");
							if (0 == (nint)typeof(IEnumerator<TPSoftBound>))
							{
								break;
							}
							obj7++;
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ r10_v6 (Il2CppClass<Zenject.SignalBus>)+12E]");
							if ((nint)obj9 < 0)
							{
								continue;
							}
							goto IL_01eb;
						}
						object obj10 = obj7 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ r8_v12+8+v575 @ rcx_v27*8]");
						object obj11 = (nint)0 << 4;
						object obj12 = obj11 + 312;
						obj13 = obj12 + num;
						goto IL_0371;
					}
					throw new NullReferenceException();
				}
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return;
			}
			throw new NullReferenceException();
			IL_01eb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj6 = 0;
			obj13 = obj14;
			goto IL_0371;
			IL_0371:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v580 @ rdx_v16] (should have been resolved before IL gen)");
			if (obj15 == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v23+34]");
			if ((nint)0 == 0 && obj4 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6110");
				obj4 = 1;
			}
			_ = 1;
			biome2 = (TPBiomeType)typeof(IEnumerator<TPSoftBound>);
		}
		throw new NullReferenceException();
	}

	private unsafe void TryGreenlight(List<ItemType> collected, ItemType item)
	{
		//IL_003a: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_0050: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj != null)
		{
			object obj2 = 0;
			List<TPSoftBound>.Enumerator enumerator = default(List<TPSoftBound>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj3 = 0;
				List<TPSoftBound>.Enumerator enumerator2 = (List<TPSoftBound>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	public unsafe bool AwakeBoundsContainingPlayers()
	{
		//IL_003e: Expected O, but got Ref
		List<TPSoftBound> softBounds = _softBounds;
		if (_softBounds != null)
		{
			bool flag = false;
			bool result = false;
			ArcadeSprite arcadeSprite = null;
			List<TPSoftBound>.Enumerator softBounds2 = (List<TPSoftBound>.Enumerator)_softBounds;
			List<TPSoftBound>.Enumerator enumerator = default(List<TPSoftBound>.Enumerator);
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite2 = null;
				List<TPSoftBound>.Enumerator enumerator2 = (List<TPSoftBound>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (flag)
			{
				if (_signalBus == null)
				{
					goto IL_026f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6110");
			}
			return result;
		}
		goto IL_026f;
		IL_026f:
		throw new NullReferenceException();
	}

	public unsafe float2 RestrictInsideAwakeBounds(float2 pos)
	{
		//IL_0049: Expected O, but got I4
		//IL_0051: Expected O, but got Ref
		List<TPSoftBound>.Enumerator enumerator2 = default(List<TPSoftBound>.Enumerator);
		List<TPSoftBound>.Enumerator enumerator = enumerator2;
		List<TPSoftBound>.Enumerator awakeSoftBounds = (List<TPSoftBound>.Enumerator)_awakeSoftBounds;
		List<TPSoftBound>.Enumerator enumerator3 = default(List<TPSoftBound>.Enumerator);
		if (enumerator3.MoveNext())
		{
			object obj = 0;
			List<TPSoftBound>.Enumerator enumerator4 = (List<TPSoftBound>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
		return pos;
	}

	public unsafe void ContainPlayersWithinSoftBounds()
	{
		//IL_001d: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void UpdateAwakeBounds()
	{
		//IL_0096: Expected O, but got I4
		List<TPSoftBound> awakeSoftBounds = _awakeSoftBounds;
		int version = awakeSoftBounds._version + 1;
		awakeSoftBounds._version = version;
		awakeSoftBounds._size = 0;
		if (awakeSoftBounds._size > 0)
		{
			Array.Clear(awakeSoftBounds._items, 0, awakeSoftBounds._size);
		}
		List<TPSoftBound> softBounds = _softBounds;
		List<TPSoftBound>.Enumerator enumerator = default(List<TPSoftBound>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public void CreateTestDopplegangerGate()
	{
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 76 Invalid \"Jump target not found in method: 0x186F95BD0\"");
		throw new NullReferenceException();
	}

	private void CreateDopplegangerGate(float2 position)
	{
		GameObject gameObject = base.gameObject;
		DopplegangerGate dopplegangerGate = gameObject.AddComponent<DopplegangerGate>();
		_dopplegangerGate = dopplegangerGate;
		_dopplegangerGate.SetupGate(position, 2f);
	}

	public override void OnInitCompleted()
	{
		//IL_0019: Expected O, but got I4
		base.OnInitCompleted();
		object obj = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		TP_Character.AddTPItemsToLootTable();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0032: Expected O, but got I4
		//IL_003a: Expected O, but got Ref
		UpdateCurrentPlatformingArea();
		if (hasWater)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 0.1f;
			List<TileSprite>.Enumerator enumerator = default(List<TileSprite>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<TileSprite>.Enumerator enumerator2 = (List<TileSprite>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	private unsafe bool IsAnyPlayerInAPlatformingZone()
	{
		//IL_003f: Expected O, but got Ref
		List<Rectangle>.Enumerator enumerator = default(List<Rectangle>.Enumerator);
		if (enumerator.MoveNext())
		{
			Rectangle rectangle = null;
			List<Rectangle>.Enumerator enumerator2 = (List<Rectangle>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public void DeactivatePlatformingAltogether()
	{
		ExitPlatformingZone();
		_polygonGroups = null;
	}

	public void DisableAllSoftBounds()
	{
		List<TPSoftBound> softBounds = _softBounds;
		int version = softBounds._version + 1;
		softBounds._version = version;
		softBounds._size = 0;
		if (softBounds._size > 0)
		{
			Array.Clear(softBounds._items, 0, softBounds._size);
		}
		List<TPSoftBound> awakeSoftBounds = _awakeSoftBounds;
		int version2 = awakeSoftBounds._version + 1;
		awakeSoftBounds._version = version2;
		awakeSoftBounds._size = 0;
		if (awakeSoftBounds._size > 0)
		{
			Array.Clear(awakeSoftBounds._items, 0, awakeSoftBounds._size);
		}
	}

	private void ExitPlatformingZone()
	{
		//IL_0050: Expected I, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._characters != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				nint num = (nint)typeof(float2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v25 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
				nint num2 = 0;
				throw new NullReferenceException();
			}
			_currentPlatformingArea = null;
			if ((object)_platformMovement != null)
			{
				_platformMovement.LoadStageEdges(null);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateCurrentPlatformingArea()
	{
		//IL_019c: Expected O, but got Ref
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		if (_polygonGroups == null)
		{
			return;
		}
		PolygonGroupComponent polygonGroupComponent = _currentPlatformingArea;
		if ((object)_currentPlatformingArea != null && ((UnityEngine.Object)polygonGroupComponent).m_CachedPtr != (IntPtr)0)
		{
			if (!IsAnyPlayerInAPlatformingZone())
			{
				ExitPlatformingZone();
			}
		}
		else
		{
			if (!IsAnyPlayerInAPlatformingZone())
			{
				return;
			}
			BackgroundTP_Basic backgroundTP_Basic = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			while (true)
			{
				PolygonGroupComponent[] polygonGroups = _polygonGroups;
				VampireSurvivors.Objects.Characters.CharacterController characterController;
				if (_polygonGroups != null)
				{
					if ((nint)backgroundTP_Basic >= polygonGroups.Length)
					{
						return;
					}
					if ((nint)backgroundTP_Basic >= polygonGroups.Length)
					{
						break;
					}
					if ((object)polygonGroups[(object)backgroundTP_Basic] != null)
					{
						Rect bounds = polygonGroups[(object)backgroundTP_Basic].Bounds;
						GameManager core = GM.Core;
						if ((object)GM.Core != null && core._mainCharacters != null)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator mainCharacters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._mainCharacters;
							characterController = (VampireSurvivors.Objects.Characters.CharacterController)(object)polygonGroupComponent;
							if (enumerator.MoveNext())
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)(&enumerator);
								throw new NullReferenceException();
							}
							VampireSurvivors.Objects.Characters.CharacterController characterController3 = null;
							if ((object)characterController3 == null)
							{
								goto IL_0387;
							}
							if ((object)characterController3 != null)
							{
								if (((UnityEngine.Object)characterController3).m_CachedPtr == (IntPtr)0)
								{
									goto IL_0387;
								}
								_currentPlatformingArea = polygonGroups[(object)backgroundTP_Basic];
								Action onYoyo = delegate
								{
									_platformMovement.LoadStageEdges(_currentPlatformingArea);
								};
								if ((object)GM.Core != null)
								{
									bool flag = GM.Core.TeleportMyPlayerToRemotePlayer(characterController3, onYoyo);
									return;
								}
							}
						}
					}
				}
				throw new NullReferenceException();
				IL_0387:
				backgroundTP_Basic = (BackgroundTP_Basic)(backgroundTP_Basic + 1);
				polygonGroupComponent = (PolygonGroupComponent)(object)characterController;
			}
			throw new IndexOutOfRangeException();
		}
	}

	private void LateUpdate()
	{
		if (_created)
		{
			UpdateBackground();
			if (!AwakeBoundsContainingPlayers())
			{
				UpdateAwakeBounds();
				ContainPlayersWithinSoftBounds();
			}
		}
	}

	public override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
		if (checkBossPizzasTimer != null)
		{
			checkBossPizzasTimer.Cancel();
		}
		RemoveDeathFightBackground();
	}

	public override bool HasCustomMadGrooveRestriction()
	{
		return true;
	}

	public override bool IsPositionPulledByMadGroove(float2 position)
	{
		return IsWithinAccessibleBounds(position);
	}

	public override bool ShouldShowCursor(float2 position)
	{
		return IsWithinAccessibleBounds(position);
	}

	private unsafe bool IsWithinAccessibleBounds(float2 position)
	{
		//IL_0087: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_03cd: Expected I, but got O
		//IL_03e3: Expected O, but got I
		//IL_04a4: Expected I4, but got O
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0046: Expected O, but got I8
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0510: Expected O, but got I4
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I
		//IL_017f: Expected O, but got I4
		//IL_0187: Expected O, but got Ref
		//IL_033d: Expected O, but got I4
		//IL_013a: Expected O, but got I
		if (_softBounds == null)
		{
			return true;
		}
		Func<TPSoftBound, bool> predicate = _003C_003Ec._003C_003E9__59_0;
		if (_003C_003Ec._003C_003E9__59_0 == null)
		{
			Func<TPSoftBound, bool> func = (_003C_003Ec._003C_003E9__59_0 = delegate(TPSoftBound s)
			{
				//IL_0035: Expected I4, but got O
				if (s == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				return s.IsAwake;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v49 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic+<>c>)+B8]");
			object obj = (nint)0 + (nint)16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			predicate = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = 6603577472L;
				object obj6 = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v14+462E0+v363 @ rdx_v22*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v14+462E0+v363 @ rdx_v22*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v14+462E0+v363 @ rdx_v22*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v14+462E0+v363 @ rdx_v22*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v14+462E0+v363 @ rdx_v22*8]");
				}
				while (num3 != 0);
				predicate = func;
			}
		}
		object obj9 = Enumerable.FirstOrDefault(_softBounds, (Func<object, bool>)predicate);
		if ((object)(_currentBiome = (TPBiomeType?)((obj9 == null) ? ((object)0) : ((object)1))) != null)
		{
			if (_accessibleBiomes == null)
			{
				goto IL_0496;
			}
			List<TPBiomeType> accessibleBiomes = _accessibleBiomes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundTP_Basic)+134]");
			TPSoftBound tPSoftBound = Enumerable.FirstOrDefault((IEnumerable<TPSoftBound>)accessibleBiomes, (Func<TPSoftBound, bool>)0);
			if (tPSoftBound == null)
			{
				if ((object)_currentBiome == tPSoftBound)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					List<TPSoftBound>.Enumerator enumerator = (List<TPSoftBound>.Enumerator)0;
					throw new NullReferenceException();
				}
				if (_accessibleBiomes == null)
				{
					goto IL_0496;
				}
				List<TPBiomeType> accessibleBiomes2 = _accessibleBiomes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundTP_Basic)+134]");
				TPSoftBound tPSoftBound2 = Enumerable.FirstOrDefault((IEnumerable<TPSoftBound>)accessibleBiomes2, (Func<TPSoftBound, bool>)0);
			}
		}
		if (_softBounds != null)
		{
			List<TPSoftBound>.Enumerator softBounds = (List<TPSoftBound>.Enumerator)_softBounds;
			List<TPSoftBound>.Enumerator enumerator2 = default(List<TPSoftBound>.Enumerator);
			if (enumerator2.MoveNext())
			{
				object obj10 = 0;
				List<TPSoftBound>.Enumerator enumerator = (List<TPSoftBound>.Enumerator)(&enumerator2);
				throw new NullReferenceException();
			}
			return false;
		}
		goto IL_0496;
		IL_0496:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool IsWithinUnlockedBounds(float2 position)
	{
		//IL_0087: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_0383: Expected I, but got O
		//IL_0399: Expected O, but got I
		//IL_0450: Expected I4, but got O
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0046: Expected O, but got I8
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_04b1: Expected O, but got I4
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		//IL_0167: Expected O, but got I4
		//IL_016f: Expected O, but got Ref
		//IL_0122: Expected O, but got I
		if (_softBounds == null)
		{
			return true;
		}
		Func<TPSoftBound, bool> predicate = _003C_003Ec._003C_003E9__60_0;
		if (_003C_003Ec._003C_003E9__60_0 == null)
		{
			Func<TPSoftBound, bool> func = (_003C_003Ec._003C_003E9__60_0 = delegate(TPSoftBound s)
			{
				//IL_0035: Expected I4, but got O
				if (s == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				return s.IsAwake;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v45 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic+<>c>)+B8]");
			object obj = (nint)0 + (nint)24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			predicate = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = 6603577472L;
				object obj6 = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v11+462E0+v363 @ rdx_v24*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v11+462E0+v363 @ rdx_v24*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v11+462E0+v363 @ rdx_v24*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v11+462E0+v363 @ rdx_v24*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v11+462E0+v363 @ rdx_v24*8]");
				}
				while (num3 != 0);
				predicate = func;
			}
		}
		object obj9 = Enumerable.FirstOrDefault(_softBounds, (Func<object, bool>)predicate);
		object obj10 = ((obj9 == null) ? ((object)0) : ((object)1));
		if (obj10 != null)
		{
			if (_unlockedBiomes == null)
			{
				goto IL_0442;
			}
			Func<TPSoftBound, bool> predicate2 = (Func<TPSoftBound, bool>)(obj10 >> 32);
			TPSoftBound tPSoftBound = Enumerable.FirstOrDefault((IEnumerable<TPSoftBound>)_unlockedBiomes, predicate2);
			if (tPSoftBound == null)
			{
				if (_unlockedBiomes == null)
				{
					goto IL_0442;
				}
				List<TPBiomeType> unlockedBiomes = _unlockedBiomes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rax_v8 (System.Object)+30]");
				TPSoftBound tPSoftBound2 = Enumerable.FirstOrDefault((IEnumerable<TPSoftBound>)unlockedBiomes, (Func<TPSoftBound, bool>)0);
			}
		}
		if (_softBounds != null)
		{
			List<TPSoftBound>.Enumerator softBounds = (List<TPSoftBound>.Enumerator)_softBounds;
			List<TPSoftBound>.Enumerator enumerator = default(List<TPSoftBound>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj11 = 0;
				List<TPSoftBound>.Enumerator enumerator2 = (List<TPSoftBound>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			return false;
		}
		goto IL_0442;
		IL_0442:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override bool HasExtraSafeXYLogic()
	{
		return true;
	}

	public override float2 ExtraSafeXY(float2 position, float2 playerPosition)
	{
		//IL_012d: Expected O, but got I4
		//IL_0135: Invalid comparison between F4 and O
		//IL_0153: Invalid comparison between F4 and I4
		//IL_017c: Expected O, but got I4
		//IL_02f7: Invalid comparison between O and F4
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_01b1: Expected O, but got I4
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_0267: Invalid comparison between O and F4
		PolygonGroupComponent currentPlatformingArea = _currentPlatformingArea;
		bool flag = (object)_currentPlatformingArea == null;
		float2 result = position;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)currentPlatformingArea).m_CachedPtr == (IntPtr)0;
			result = position;
			if (!flag2)
			{
				PlatformZoneMovement platformMovement = _platformMovement;
				if ((object)_platformMovement == null)
				{
					goto IL_029c;
				}
				bool flag3 = platformMovement._stageEdges == null;
				result = position;
				if (!flag3)
				{
					if ((object)_currentPlatformingArea == null)
					{
						goto IL_029c;
					}
					Rect bounds = _currentPlatformingArea.Bounds;
					float2 float5 = default(float2);
					object obj = float5 + float5;
					float num = (float)float5 + bounds.m_XMin;
					object obj2 = default(object);
					bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
					object obj3 = obj - obj2;
					bool flag5 = obj3 == null;
					bool flag6 = !flag4;
					bool flag7 = !flag5;
					object obj4 = flag7 & flag6;
					bool flag8 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position);
					float num2 = num - (float)position;
					bool flag9 = num2 == 0f;
					bool flag10 = !flag8;
					bool flag11 = !flag9;
					object obj5 = flag11 & flag10;
					object obj6 = obj4 & obj5;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
					{
						obj6 = 0;
					}
					bool flag12 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)bounds.m_XMin);
					bool flag13 = !flag12;
					object obj7 = flag13 & obj6;
					bool flag14 = obj7 == null;
					result = position;
					if (!flag14)
					{
						float num3 = (float)obj2 + 5f;
						if ((object)_platformMovement == null)
						{
							goto IL_029c;
						}
						bool flag15 = _platformMovement.FindClosestWalkableEdgeBelow(float5)._edge == null;
						result = position;
						if (!flag15)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v17 (VampireSurvivors.Objects.Stages.PlatformZoneMovement+ClosestEdge)+C]");
							float num4 = 0f - num3;
							float num5 = num4 + 5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj8 = num5 & 0;
							bool flag16 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f);
							result = position;
							if (!flag16)
							{
								float deltaTime = PauseSystem.DeltaTime;
								result = float5;
							}
						}
					}
				}
			}
		}
		return result;
		IL_029c:
		return (float2)new NullReferenceException();
	}

	public unsafe void TestSpawnDeathFightBackground()
	{
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_0211: Expected O, but got I4
		//IL_021a: Expected O, but got I4
		//IL_00ee->IL019e: Incompatible stack heights: 1 vs 0
		//IL_021f->IL00d2: Incompatible stack heights: 3 vs 1
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null && tilingTileset._maps != null)
				{
					List<SuperMap>.Enumerator value = (List<SuperMap>.Enumerator)tilingTileset._maps;
					List<SuperMap>.Enumerator maps = (List<SuperMap>.Enumerator)tilingTileset._maps;
					List<SuperMap>.Enumerator enumerator = default(List<SuperMap>.Enumerator);
					while (enumerator.MoveNext())
					{
						Tilemap[] componentsInChildren = ((Component)null).GetComponentsInChildren<Tilemap>();
						bool flag = componentsInChildren == null;
						Tilemap tilemap = null;
						while ((nint)tilemap < componentsInChildren.Length)
						{
							if ((nint)tilemap < componentsInChildren.Length)
							{
								Tilemap tilemap2 = componentsInChildren[(object)tilemap];
								bool flag2 = (object)componentsInChildren[(object)tilemap] == null;
								bool flag3 = ((UnityEngine.Object)tilemap2).m_CachedPtr == (IntPtr)0;
								Tilemap.set_color_Injected(((UnityEngine.Object)tilemap2).m_CachedPtr, ref *(Color*)(&value));
								tilemap = (Tilemap)(tilemap + 1);
								value = (List<SuperMap>.Enumerator)0;
								maps = (List<SuperMap>.Enumerator)0;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
					}
					if (_signalBus != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
						SpawnDeathFightTile();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void TestRemoveDeathFightBackground()
	{
		RemoveDeathFightBackground();
	}

	public void SpawnDeathFightBackground()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
	}

	public unsafe void SpawnDeathFightTile()
	{
		//IL_007b: Expected O, but got F4
		//IL_00ae: Expected I4, but got I8
		//IL_039a: Expected I4, but got I8
		//IL_03be: Expected O, but got I
		//IL_0414: Expected O, but got I
		//IL_0231: Expected I, but got O
		//IL_0494: Expected F4, but got I4
		//IL_058a: Expected I4, but got O
		//IL_05b8: Expected I, but got O
		//IL_071d: Expected O, but got F4
		//IL_072a: Expected F4, but got O
		//IL_0097->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_00f9->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_0128->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_0152->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_01a9->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_021f->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_01fd->IL01fd: Incompatible stack heights: 2 vs 1
		//IL_0259->IL0259: Incompatible stack heights: 1 vs 0
		//IL_0577->IL0577: Incompatible stack heights: 1 vs 0
		//IL_072f->IL06be: Incompatible stack heights: 1 vs 0
		if (_deathFightStartCameraPos != null)
		{
			goto IL_0259;
		}
		Camera main = Camera.main;
		Vector3 ret;
		float num = default(float);
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				GameObject gameObject = base.gameObject;
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)num, "DeathFightTop", "DeathFightTop");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setDepth(-8001);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Normal);
							if ((object)phaserSprite4 != null)
							{
								GameObject gameObject2 = phaserSprite4.gameObject;
								if ((object)gameObject2 != null)
								{
									((UnityEngine.Object)gameObject2).SetName("DeathFightTop");
									_deathFightTileTop = phaserSprite4;
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										if ((object)_deathFightTileTop != null)
										{
											void* value = ((IntPtr*)(&array))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj = default(object);
											bool flag2 = obj == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
											_ = 1148846080;
											_ = 1;
											MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
											goto IL_0259;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05dc;
		IL_05dc:
		throw new NullReferenceException();
		IL_0259:
		float scrollFactor;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						if (s_scene2._renderer != null)
						{
							float y = renderer2.height * 0.5f;
							float x = renderer.width * 0.5f;
							float height = default(float);
							string textureName = default(string);
							string spriteName = default(string);
							TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, 6.72f, height, textureName, spriteName);
							TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
							if ((object)tileSprite != null)
							{
								TileSprite tileSprite2 = tileSprite.SetDepth(-8000);
								if ((object)tileSprite2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ rax_v34 (VampireSurvivors.Graphics.TileSprite)+28]");
									SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha((SpriteRenderer)0, 0f);
									Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ rax_v34 (VampireSurvivors.Graphics.TileSprite)+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ rax_v34 (VampireSurvivors.Graphics.TileSprite)+28]");
										((Renderer)0).SetMaterial(material);
										GameObject gameObject3 = tileSprite2.gameObject;
										if ((object)gameObject3 != null)
										{
											((UnityEngine.Object)gameObject3).SetName("DeathFightTile");
											TileSprite deathFightTile = tileSprite2.SetMaterial(MaterialType.ScrollableSprite);
											_deathFightTile = deathFightTile;
											bool flag3 = _deathFightStartCameraPos != null;
											scrollFactor = 0f;
											if (flag3)
											{
												goto IL_06be;
											}
											Camera main2 = Camera.main;
											if ((object)main2 != null)
											{
												Transform transform2 = main2.transform;
												if ((object)transform2 != null)
												{
													bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
													object obj2 = default(object);
													float num2 = (float)obj2 - 0.98f;
													_deathFightStartCameraPos = (float2?)(object)num;
													scrollFactor = (float)ret;
													goto IL_06be;
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
		goto IL_05dc;
		IL_06be:
		UpdateBackground();
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if (array2 != null)
		{
			if ((object)_deathFightTile != null)
			{
				TileSprite tileSprite3 = RenderingExtensions.SetScrollFactor(_deathFightTile, scrollFactor);
				bool flag5 = (object)tileSprite3 == null;
			}
			TileSprite tileSprite4 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array2, scrollFactor, (byte)(int)_deathFightTile != 0);
			if (tweenConfig2 != null)
			{
				((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
				_ = 1148846080;
				_ = 1;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
				return;
			}
		}
		goto IL_05dc;
	}

	public void RemoveDeathFightBackground()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
		TileSprite deathFightBG = _deathFightBG;
		if ((object)_deathFightBG != null && ((UnityEngine.Object)deathFightBG).m_CachedPtr != (IntPtr)0)
		{
			_deathFightBG.destroy();
			_deathFightBG = null;
		}
		PhaserSprite deathFightTileTop = _deathFightTileTop;
		if ((object)_deathFightTileTop != null && ((UnityEngine.Object)deathFightTileTop).m_CachedPtr != (IntPtr)0)
		{
			_deathFightTileTop.destroy();
			_deathFightTileTop = null;
		}
		TileSprite deathFightTile = _deathFightTile;
		if ((object)_deathFightTile != null && ((UnityEngine.Object)deathFightTile).m_CachedPtr != (IntPtr)0)
		{
			_deathFightTile.destroy();
			_deathFightTile = null;
		}
	}

	private unsafe void UpdateBackground()
	{
		//IL_034c: Invalid comparison between F4 and I4
		//IL_00e0: Expected F4, but got I4
		//IL_0186: Expected O, but got I
		//IL_04b0: Invalid comparison between F4 and O
		//IL_0205: Expected O, but got I
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_04e2: Invalid comparison between F4 and O
		//IL_027a: Invalid comparison between O and F4
		//IL_02b8->IL02b8: Incompatible stack heights: 8 vs 0
		//IL_0245->IL0490: Incompatible stack heights: 11 vs 10
		//IL_052f->IL04f9: Incompatible stack heights: 10 vs 8
		TileSprite deathFightTile = _deathFightTile;
		if ((object)_deathFightTile == null || ((UnityEngine.Object)deathFightTile).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		bool flag = _deathFightStartCameraPos == null;
		TileSprite deathFightTile2 = _deathFightTile;
		deathFightTile2._xScrollOffset = 0f;
		deathFightTile2._spriteScroller.SetScrollOffsetX(deathFightTile2._xScrollOffset);
		Camera main = Camera.main;
		Transform transform = main.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundTP_Basic)+128]");
		float num2 = default(float);
		float num = 0f - num2;
		float num3 = num - 10.725f;
		if (num3 > 0f)
		{
			num3 = 0f;
		}
		Transform transform2 = _deathFightTile.transform;
		Camera main2 = Camera.main;
		Transform transform3 = main2.transform;
		bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
		Transform deathFightTile3 = (Transform)(object)_deathFightTile;
		Camera main3 = Camera.main;
		bool flag6 = (object)main3 == null;
		Transform transform4 = main3.transform;
		bool flag7 = (object)transform4 == null;
		bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
		float scrollOffsetY = num2 + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdi_v18 (UnityEngine.Transform)+30]");
		((SpriteScroller)0).SetScrollOffsetY(scrollOffsetY);
		GameManager core = GM.Core;
		float num4 = 10f;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		float2 position = default(float2);
		while (enumerator.MoveNext())
		{
			BackgroundTP_Basic backgroundTP_Basic = null;
			Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
			bool flag9 = (object)cachedTrans == null;
			bool flag10 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out ret);
			object obj2;
			if ((object)backgroundTP_Basic._mainCamera != null)
			{
				Camera mainCamera = backgroundTP_Basic._mainCamera;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1256 @ rax_v79 (UnityEngine.Camera)+28]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1256 @ rax_v79 (UnityEngine.Camera)+28]");
				bool flag11 = (nint)0 == 0;
				num4 = num2;
				obj2 = ret;
			}
			else
			{
				num4 = num2;
				obj2 = ret;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundTP_Basic)+124]");
			float num5 = 0f - 2.56f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundTP_Basic)+124]");
				float num6 = 0f + 2.56f;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundTP_Basic)+128]");
			characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(0 + 0.16f);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref characters))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundTP_Basic)+128]");
				num4 = 0f + 0.16f;
			}
			((ArcadeSprite)null).position = position;
		}
	}

	public BackgroundTP_Basic()
	{
		List<PizzaCircle> bossPizzas = new List<PizzaCircle>();
		BossPizzas = bossPizzas;
		cycleGates = new List<PickupTeleporter>();
		_awakeSoftBounds = new List<TPSoftBound>();
		_unlockedBiomes = new List<TPBiomeType>();
		_accessibleBiomes = new List<TPBiomeType>();
		base._002Ector();
	}

	private void _003CCreateCycleGatesDelayed_003Eb__33_0()
	{
		CreateCycleGates();
		GreenlightBiomes();
	}

	private void _003CUpdateCurrentPlatformingArea_003Eb__53_0()
	{
		_platformMovement.LoadStageEdges(_currentPlatformingArea);
	}
}
