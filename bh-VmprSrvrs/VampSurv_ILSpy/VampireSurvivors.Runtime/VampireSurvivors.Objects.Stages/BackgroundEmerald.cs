using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using QFSW.MOP2;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.UI;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundEmerald : BackgroundManager
{
	public enum EmeraldsBiomes
	{
		Biome1,
		Biome2,
		Biome3,
		Biome4,
		Biome5,
		Biome6,
		Junction,
		nil
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public BackgroundEmerald _003C_003E4__this;

		public VampireSurvivors.Objects.Characters.CharacterController localPlayer;

		internal void _003COnInitCompleted_003Eb__0()
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			int num = core._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
			if (core._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField < mainCharacters._size)
			{
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				BackgroundEmerald backgroundEmerald = _003C_003E4__this;
				float2 position = items[num].position;
				Vector2 position2 = default(Vector2);
				bool flag = backgroundEmerald._biomeBounds.TryGetBiomePositionIsInside(position2, out var biome);
				_003C_003E4__this.ActivateBiome(localPlayer, biome);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public BackgroundEmerald _003C_003E4__this;

		public EmeraldsBiomes targetBiome;

		internal void _003CConfigureJunctionToBiomeTeleporter_003Eb__0(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			_003C_003E4__this.ActivateBiome(player, targetBiome);
		}
	}

	private sealed class _003C_003Ec__DisplayClass59_0
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

	private EME_BiomeBounds _biomeBounds;

	private EME_RibbonController _emeraldRibbonController;

	private EME_TeleportFader _teleportFader;

	private EME_BiomeNameUI _biomeNameUi;

	private EmeraldsBiomes _nextBossBiome = EmeraldsBiomes.Biome2;

	private readonly Dictionary<EmeraldsBiomes, PizzaCircle> _bossPizzas;

	private Timer _checkBossPizzasTimer;

	private readonly Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter> _biomeToJunctionTeleporterLookup;

	private readonly Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter> _junctionToBiomeTeleporterLookup;

	private const string DestinationNameIsDestination = "isDestination";

	private const string EmeItems = "EME_items";

	private const string PizzasPoolName = "PizzaCircles";

	private const string JunctionDestination = "biome0";

	private readonly Dictionary<EmeraldsBiomes, string> _localizedBiomeNamesLookup;

	private EmeraldsBiomes _003CCurrentBiome_003Ek__BackingField;

	private bool _003CHasLeftJunction_003Ek__BackingField;

	private bool _finalBossDefeated;

	private bool _ribbonTargetBossPizzas;

	private Transform _junctionSpawnTransform;

	public EmeraldsBiomes CurrentBiome
	{
		get
		{
			return _003CCurrentBiome_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentBiome_003Ek__BackingField = value;
		}
	}

	public EME_BiomeBounds GetBiomeBounds => _biomeBounds;

	public bool HasLeftJunction
	{
		get
		{
			return _003CHasLeftJunction_003Ek__BackingField;
		}
		private set
		{
			_003CHasLeftJunction_003Ek__BackingField = value;
		}
	}

	private bool IsStageInverted
	{
		get
		{
			//IL_0184: Expected I4, but got O
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage = core._stage;
				if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0170;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage2 = core2._stage;
					if ((object)core2._stage != null)
					{
						TilingTileset tilingTileset = stage2._tilingTileset;
						if ((object)stage2._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
						{
							goto IL_0170;
						}
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage3 = core3._stage;
							if ((object)core3._stage != null)
							{
								TilingTileset tilingTileset2 = stage3._tilingTileset;
								if ((object)stage3._tilingTileset != null)
								{
									return tilingTileset2._visuallyInverted;
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0170:
			return false;
		}
	}

	public override bool HasCustomMapRules()
	{
		return true;
	}

	public override bool HasCustomMadGrooveRestriction()
	{
		return true;
	}

	public override bool IsPositionPulledByMadGroove(float2 position)
	{
		//IL_00eb: Expected I4, but got O
		//IL_005e: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		if ((object)_biomeBounds != null)
		{
			Vector2 position2 = default(Vector2);
			if (_biomeBounds.TryGetBiomePositionIsInside(position2, out var biome))
			{
				object obj = biome - _nextBossBiome;
				object obj2 = biome ^ _nextBossBiome;
				object obj3 = biome ^ obj;
				object obj4 = obj2 & obj3;
				bool flag = (nint)obj4 < 0;
				bool flag2 = (nint)obj < 0;
				bool flag3 = obj == null;
				bool flag4 = flag2 != flag;
				return flag4 | flag3;
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override bool ShouldShowPickupIconOnMap(Vector3 worldPosition)
	{
		//IL_007a: Expected I4, but got O
		//IL_0058: Expected O, but got I4
		if ((object)_biomeBounds != null)
		{
			Vector2 position = default(Vector2);
			bool flag = _biomeBounds.TryGetBiomePositionIsInside(position, out var biome);
			if (!flag)
			{
				return flag;
			}
			object obj = _003CCurrentBiome_003Ek__BackingField - biome;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool IsWithinAccessibleBounds(float2 position)
	{
		//IL_00eb: Expected I4, but got O
		//IL_005e: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		if ((object)_biomeBounds != null)
		{
			Vector2 position2 = default(Vector2);
			if (_biomeBounds.TryGetBiomePositionIsInside(position2, out var biome))
			{
				object obj = biome - _nextBossBiome;
				object obj2 = biome ^ _nextBossBiome;
				object obj3 = biome ^ obj;
				object obj4 = obj2 & obj3;
				bool flag = (nint)obj4 < 0;
				bool flag2 = (nint)obj < 0;
				bool flag3 = obj == null;
				bool flag4 = flag2 != flag;
				return flag4 | flag3;
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe Bounds GetBoundsForCurrentBiome(float xPosition, float width)
	{
		//IL_003c: Expected native int or pointer, but got O
		//IL_004f: Expected native int or pointer, but got O
		if ((object)_biomeBounds != null)
		{
			EME_BiomeBounds.EmeraldsBiomeBounds boundsForBiome = _biomeBounds.GetBoundsForBiome(_003CCurrentBiome_003Ek__BackingField);
			Bounds bounds = default(Bounds);
			Vector3 vector = default(Vector3);
			((Bounds*)(nint)bounds)->m_Center = vector;
			_ = 0;
			((Bounds*)(nint)bounds)->m_Extents = vector;
			_ = 0;
			return bounds;
		}
		return (Bounds)new NullReferenceException();
	}

	public override void CustomPreload(Action onComplete)
	{
		//IL_007a: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3CEC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = SpriteLoader.LoadTexture("background_Astral", "Gameplay", (DlcType?)(object)0);
		if (onComplete != null)
		{
			IntPtr method = ((Delegate)onComplete).method;
			IntPtr method_code = ((Delegate)onComplete).method_code;
			IntPtr invoke_impl = ((Delegate)onComplete).invoke_impl;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v51 @ rax_v3 (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0292: Expected O, but got I4
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_04c9: Expected O, but got I4
		//IL_038d: Expected O, but got I4
		//IL_0194: Expected O, but got Ref
		//IL_00f9->IL054b: Incompatible stack heights: 1 vs 0
		//IL_0142->IL054b: Incompatible stack heights: 1 vs 0
		//IL_0176->IL054b: Incompatible stack heights: 1 vs 0
		//IL_0364->IL060a: Incompatible stack heights: 1 vs 0
		//IL_0392->IL0619: Incompatible stack heights: 1 vs 0
		//IL_05e1->IL054b: Incompatible stack heights: 2 vs 0
		//IL_0199->IL01f4: Incompatible stack heights: 2 vs 0
		base.OnUpdate();
		EME_RibbonController emeraldRibbonController = _emeraldRibbonController;
		if ((object)_emeraldRibbonController == null || ((UnityEngine.Object)emeraldRibbonController).m_CachedPtr == (IntPtr)0)
		{
			goto IL_01f4;
		}
		if (!_finalBossDefeated)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
				if (core._mainCharacters != null)
				{
					bool flag = mainCharacters._size <= 0;
					VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
					if (mainCharacters._items != null)
					{
						if (items.Length <= 0)
						{
							throw new IndexOutOfRangeException();
						}
						if ((object)items[0] != null)
						{
							Transform transform = items[0].transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								if ((object)_emeraldRibbonController != null)
								{
									object obj = default(object);
									_emeraldRibbonController.UpdateRibbon((Vector3)(&obj));
									goto IL_01f4;
								}
							}
						}
					}
				}
			}
		}
		else
		{
			EME_RibbonController emeraldRibbonController2 = _emeraldRibbonController;
			if ((object)_emeraldRibbonController != null)
			{
				if (emeraldRibbonController2._currentState != EME_RibbonController.RibbonState.Disabled)
				{
					_emeraldRibbonController.DisableRibbon();
				}
				goto IL_01f4;
			}
		}
		goto IL_054b;
		IL_060a:
		EME_BiomeNameUI biomeNameUi = _biomeNameUi;
		if ((object)_biomeNameUi != null && ((UnityEngine.Object)biomeNameUi).m_CachedPtr != (IntPtr)0)
		{
			float deltaTime = PauseSystem.DeltaTime;
			if ((object)_biomeNameUi != null)
			{
				_biomeNameUi.UpdateNameUi(deltaTime);
				return;
			}
			goto IL_054b;
		}
		return;
		IL_0619:
		Action action;
		if (action != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v472.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		goto IL_060a;
		IL_01f4:
		EME_TeleportFader teleportFader = _teleportFader;
		if ((object)_teleportFader != null && ((UnityEngine.Object)teleportFader).m_CachedPtr != (IntPtr)0)
		{
			EME_TeleportFader teleportFader2 = _teleportFader;
			if ((object)_teleportFader == null)
			{
				goto IL_054b;
			}
			bool flag3 = teleportFader2._currentState == EME_TeleportFader.FadeState.Idle;
			if (!flag3)
			{
				object obj2 = teleportFader2._currentState - 1;
				if (!flag3)
				{
					object obj3 = obj2 - 1;
					if (!flag3)
					{
						bool flag4 = (nint)obj3 != 1;
						float deltaTime2 = PauseSystem.DeltaTime;
						float num = deltaTime2 / teleportFader2._fadeOutTime;
						float num2 = num + teleportFader2._fadeTimer;
						float fadeProgress = 1f - num2;
						teleportFader2._fadeTimer = num2;
						_teleportFader.SetFadeProgress(fadeProgress);
						float fadeTimer = teleportFader2._fadeTimer;
						if (!(teleportFader2._fadeTimer < 1f))
						{
							teleportFader2._fadeTimer = 0f;
							action = teleportFader2.OnFadeOutComplete;
							object obj4 = 0;
							goto IL_0619;
						}
					}
					else
					{
						float deltaTime3 = PauseSystem.DeltaTime;
						float num3 = deltaTime3 / teleportFader2._fadeHoldTime;
						if (!((teleportFader2._fadeTimer = num3 + teleportFader2._fadeTimer) < 1f))
						{
							teleportFader2._currentState = EME_TeleportFader.FadeState.FadeOut;
							teleportFader2._fadeTimer = 0f;
						}
					}
				}
				else
				{
					float deltaTime4 = PauseSystem.DeltaTime;
					float num4 = deltaTime4 / teleportFader2._fadeInTime;
					float num5 = (teleportFader2._fadeTimer = num4 + teleportFader2._fadeTimer);
					_teleportFader.SetFadeProgress(num5);
					float fadeTimer = teleportFader2._fadeTimer;
					if (!(teleportFader2._fadeTimer < 1f))
					{
						teleportFader2._currentState = EME_TeleportFader.FadeState.Hold;
						teleportFader2._fadeTimer = 0f;
						action = teleportFader2.OnFadeInComplete;
						float fadeProgress = num5;
						object obj4 = 0;
						goto IL_0619;
					}
				}
			}
		}
		goto IL_060a;
		IL_054b:
		throw new NullReferenceException();
	}

	public override void Create()
	{
		//IL_02d3: Expected O, but got I
		//IL_0364: Expected O, but got I
		//IL_03f5: Expected O, but got I
		SetBiomeDifficulty();
		base.Create();
		if (!GM.Core.IsStageHost)
		{
			Action<Pickup> b = OnRemoteItemInstantiated;
			Delegate obj = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b);
			if ((object)obj == null)
			{
				ItemInstantiator.OnRemoteItemInstantiated = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<Pickup> action = default(Action<Pickup>);
				if (action == null)
				{
					throw new InvalidCastException();
				}
				ItemInstantiator.OnRemoteItemInstantiated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3CF1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome1, "EME_BIOME_01");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome2, "EME_BIOME_02");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome3, "EME_BIOME_03");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome4, "EME_BIOME_04");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome5, "EME_BIOME_05");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome6, "EME_BIOME_06");
		AddBiomeNameToDictionary(EmeraldsBiomes.Junction, "EME_BIOME_07");
		GameManager core = GM.Core;
		Stage stage = core._stage;
		GameObject gameObject;
		if ((object)stage._tilingTileset != null)
		{
			GameObject defaultSupportMap = stage._tilingTileset.DefaultSupportMap;
			gameObject = defaultSupportMap;
			EmeraldsBiomes emeraldsBiomes = EmeraldsBiomes.Biome1;
		}
		else
		{
			gameObject = null;
			EmeraldsBiomes emeraldsBiomes = EmeraldsBiomes.Junction;
		}
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ rdi_v7 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			EME_BiomeBounds componentInChildren = gameObject.GetComponentInChildren<EME_BiomeBounds>(includeInactive: false);
			_biomeBounds = componentInChildren;
			EME_BiomeBounds biomeBounds = _biomeBounds;
			object message;
			if ((object)_biomeBounds != null && ((UnityEngine.Object)biomeBounds).m_CachedPtr != (IntPtr)0)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rdi_v10 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					EME_BiomeBounds componentInChildren2 = ((GameObject)0).GetComponentInChildren<EME_BiomeBounds>(includeInactive: false);
				}
				EME_RibbonController componentInChildren3 = gameObject.GetComponentInChildren<EME_RibbonController>(includeInactive: false);
				_emeraldRibbonController = componentInChildren3;
				if ((bool)_emeraldRibbonController)
				{
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ rdi_v12 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						EME_RibbonController componentInChildren4 = ((GameObject)0).GetComponentInChildren<EME_RibbonController>(includeInactive: false);
					}
					EME_TeleportFader componentInChildren5 = gameObject.GetComponentInChildren<EME_TeleportFader>(includeInactive: false);
					_teleportFader = componentInChildren5;
					if ((bool)_teleportFader)
					{
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdi_v14 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							EME_TeleportFader componentInChildren6 = ((GameObject)0).GetComponentInChildren<EME_TeleportFader>(includeInactive: false);
						}
						EME_BiomeNameUI componentInChildren7 = gameObject.GetComponentInChildren<EME_BiomeNameUI>(includeInactive: false);
						_biomeNameUi = componentInChildren7;
						if ((bool)_biomeNameUi)
						{
							GameManager core2 = GM.Core;
							PlayerOptionsData config = core2._playerOptions.Config;
							_nextBossBiome = (EmeraldsBiomes)config._003CEME_NextBossBiome_003Ek__BackingField;
							SetupTeleportFader();
							SetupBiomeNameUi();
							CreateBossPizzas();
							if (_checkBossPizzasTimer != null)
							{
								_checkBossPizzasTimer.Cancel();
							}
							Action onComplete = CheckBossPizzas;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer checkBossPizzasTimer = Timers.Register(0.3f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_checkBossPizzasTimer = checkBossPizzasTimer;
							return;
						}
						message = "Couldn't find EME_BiomeNameUI component on tileset support prefab, something's gone wrong!";
					}
					else
					{
						message = "Couldn't find EME_TeleportFader component on tileset support prefab, something's gone wrong!";
					}
				}
				else
				{
					message = "Couldn't find EME_Ribbon component on tileset support prefab, something's gone wrong!";
				}
			}
			else
			{
				message = "Couldn't find EME_BiomeBounds component on tileset support prefab, something's gone wrong!";
			}
			Debug.LogError(message);
		}
		else
		{
			Exception exception = new Exception("Couldn't find support map");
			Debug.LogException(exception);
		}
	}

	private void OnRemoteItemInstantiated(Pickup item)
	{
		//IL_018f: Expected O, but got I4
		//IL_023b: Expected O, but got I4
		//IL_02e1->IL0268: Incompatible stack heights: 1 vs 0
		//IL_0330->IL0268: Incompatible stack heights: 2 vs 0
		//IL_0148->IL0268: Incompatible stack heights: 2 vs 0
		//IL_0177->IL0268: Incompatible stack heights: 2 vs 0
		//IL_01f4->IL0268: Incompatible stack heights: 2 vs 0
		//IL_0223->IL0268: Incompatible stack heights: 2 vs 0
		//IL_0267->IL0267: Incompatible stack heights: 2 vs 0
		if ((object)item != null)
		{
			if (item._003CPickupType_003Ek__BackingField != ItemType.EME_TELEPORTER)
			{
				return;
			}
			Pickup_EME_Teleporter component = item.GetComponent<Pickup_EME_Teleporter>();
			if ((object)component != null)
			{
				component.Init(_teleportFader);
				SetupTeleporter(component);
				if (_nextBossBiome == EmeraldsBiomes.Biome1)
				{
					return;
				}
				if (_junctionToBiomeTeleporterLookup != null)
				{
					if (!((Dictionary<System.Int32Enum, object>)(object)_junctionToBiomeTeleporterLookup).TryGetValue((System.Int32Enum)_nextBossBiome, out object value))
					{
						return;
					}
					EME_RibbonController emeraldRibbonController = _emeraldRibbonController;
					if (value != null)
					{
						bool flag = ((UnityEngine.Object)value).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)value).m_CachedPtr);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							if ((object)_emeraldRibbonController != null)
							{
								emeraldRibbonController._currentState = EME_RibbonController.RibbonState.TravelingToNewTarget;
								if ((object)emeraldRibbonController._ribbon != null)
								{
									GameObject gameObject = emeraldRibbonController._ribbon.gameObject;
									if ((object)gameObject != null)
									{
										object obj = emeraldRibbonController._currentState - 3;
										bool flag3 = obj == null;
										bool active = !flag3;
										gameObject.SetActive(active);
										emeraldRibbonController._targetPosition = ret;
										_ = 0;
										emeraldRibbonController._currentState = EME_RibbonController.RibbonState.TravelingToNewTarget;
										if ((object)emeraldRibbonController._ribbon != null)
										{
											GameObject gameObject2 = emeraldRibbonController._ribbon.gameObject;
											if ((object)gameObject2 != null)
											{
												object obj2 = emeraldRibbonController._currentState - 3;
												bool flag4 = obj2 == null;
												bool active2 = !flag4;
												gameObject2.SetActive(active2);
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
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Action<Pickup> value = OnRemoteItemInstantiated;
		Delegate obj = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value);
		if ((object)obj == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<Pickup> action = default(Action<Pickup>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			ItemInstantiator.OnRemoteItemInstantiated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		base.OnDestroy();
	}

	private void InitBiomeNames()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3CF1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome1, "EME_BIOME_01");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome2, "EME_BIOME_02");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome3, "EME_BIOME_03");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome4, "EME_BIOME_04");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome5, "EME_BIOME_05");
		AddBiomeNameToDictionary(EmeraldsBiomes.Biome6, "EME_BIOME_06");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 75 Invalid \"Jump target not found in method: 0x186F550E0\"");
	}

	private void AddBiomeNameToDictionary(EmeraldsBiomes biome, string localizationKey)
	{
		string text = "stageLang/{" + localizationKey + "}biomeName";
		bool ignoreRTLnumbers = default(bool);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		Dictionary<System.Int32Enum, object> localizedBiomeNamesLookup;
		object value;
		System.Collections.Generic.InsertionBehavior behavior;
		if (LocalizationManager.TryGetTranslation(text, out var Translation, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage) && Translation != null && Translation._stringLength > 0)
		{
			localizedBiomeNamesLookup = (Dictionary<System.Int32Enum, object>)(object)_localizedBiomeNamesLookup;
			value = Translation;
			behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		}
		else
		{
			string message = "Couldn't find localization for term " + text + ", using placeholder name";
			Debug.LogError(message);
			localizedBiomeNamesLookup = (Dictionary<System.Int32Enum, object>)(object)_localizedBiomeNamesLookup;
			value = localizationKey;
			behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		}
		bool flag = localizedBiomeNamesLookup.TryInsert((System.Int32Enum)biome, value, behavior);
	}

	private void RemoveBonusesFromEggs()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			float num = core2._eggManager.RemoveBonuses();
		}
	}

	public unsafe override void OnInitCompleted()
	{
		//IL_02cb: Expected O, but got I
		//IL_0214: Expected O, but got I
		//IL_0b00->IL0a32: Incompatible stack heights: 1 vs 0
		//IL_0420->IL0a32: Incompatible stack heights: 1 vs 0
		//IL_0b4f->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_09fd->IL0a32: Incompatible stack heights: 1 vs 0
		//IL_01ca->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_053d->IL0a32: Incompatible stack heights: 1 vs 0
		//IL_0465->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_077f->IL0a32: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_0491->IL0491: Incompatible stack heights: 2 vs 0
		//IL_0582->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_0252->IL0b54: Incompatible stack heights: 2 vs 0
		//IL_0c1f->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_05b6->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_07cd->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_0816->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_0be0->IL0a32: Incompatible stack heights: 3 vs 0
		//IL_05ec->IL0a32: Incompatible stack heights: 3 vs 0
		//IL_087e->IL0a32: Incompatible stack heights: 2 vs 0
		//IL_062e->IL0a32: Incompatible stack heights: 3 vs 0
		//IL_065d->IL0a32: Incompatible stack heights: 3 vs 0
		//IL_06ad->IL0a32: Incompatible stack heights: 4 vs 0
		//IL_0c4f->IL08c4: Incompatible stack heights: 3 vs 2
		//IL_06de->IL0be5: Incompatible stack heights: 5 vs 2
		_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass44_0();
		if (CS_0024_003C_003E8__locals8 != null)
		{
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			if (_nextBossBiome == EmeraldsBiomes.Junction)
			{
				_finalBossDefeated = true;
				goto IL_0a86;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				if (config != null)
				{
					if (config._003CSelectedGoldenEggs_003Ek__BackingField)
					{
						GameManager core2 = GM.Core;
						if ((object)GM.Core == null || core2._eggManager == null)
						{
							goto IL_0a32;
						}
						float num = core2._eggManager.RemoveBonuses();
					}
					goto IL_0a86;
				}
			}
		}
		goto IL_0a32;
		IL_0a32:
		throw new NullReferenceException();
		IL_0a86:
		List<SuperObject> emeraldRibbonController;
		float ret;
		if (_nextBossBiome != EmeraldsBiomes.Biome1)
		{
			if (_biomeToJunctionTeleporterLookup != null)
			{
				if (!((Dictionary<System.Int32Enum, object>)(object)_biomeToJunctionTeleporterLookup).TryGetValue((System.Int32Enum)_003CCurrentBiome_003Ek__BackingField, out object value))
				{
					goto IL_02f7;
				}
				emeraldRibbonController = (List<SuperObject>)(object)_emeraldRibbonController;
				if (value != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_18_v14 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_18_v14 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
						if ((object)_emeraldRibbonController != null)
						{
							_ = 0;
							if (emeraldRibbonController._syncRoot != null)
							{
								GameObject gameObject = ((Component)emeraldRibbonController._syncRoot).gameObject;
								if ((object)gameObject != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v11 (System.Collections.Generic.List`1<SuperTiled2Unity.SuperObject>)+30]");
									object obj = -3;
									bool flag3 = obj == null;
									bool active = !flag3;
									gameObject.SetActive(active);
									_ = 0;
									_ = 0;
									goto IL_0b54;
								}
							}
						}
					}
				}
			}
		}
		else
		{
			emeraldRibbonController = (List<SuperObject>)(object)_emeraldRibbonController;
			if ((object)_emeraldRibbonController != null)
			{
				_ = 3;
				goto IL_0b54;
			}
		}
		goto IL_0a32;
		IL_0b54:
		if (emeraldRibbonController._syncRoot != null)
		{
			GameObject gameObject2 = ((Component)emeraldRibbonController._syncRoot).gameObject;
			if ((object)gameObject2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v11 (System.Collections.Generic.List`1<SuperTiled2Unity.SuperObject>)+30]");
				object obj2 = -3;
				bool flag4 = obj2 == null;
				bool active2 = !flag4;
				gameObject2.SetActive(active2);
				goto IL_02f7;
			}
		}
		goto IL_0a32;
		IL_0491:
		List<SuperObject> scriptsFromName;
		VampireSurvivors.Objects.Characters.CharacterController[] items2;
		EmeraldsBiomes biomeToActivate;
		bool num2;
		bool num3;
		if (_nextBossBiome != EmeraldsBiomes.Biome1)
		{
			if (scriptsFromName != null && scriptsFromName._size > 0)
			{
				bool flag5 = scriptsFromName._size <= 0;
				SuperObject[] items = scriptsFromName._items;
				if (scriptsFromName._items != null)
				{
					bool flag6 = items.Length <= 0;
					if ((object)items[0] != null)
					{
						Transform transform2 = items[0].transform;
						if ((object)transform2 != null)
						{
							bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
							Transform junctionSpawnTransform = items[0].transform;
							_junctionSpawnTransform = junctionSpawnTransform;
							if ((object)GM.Core != null)
							{
								float2 float5 = default(float2);
								GM.Core.CheckAllWeaponsForTeleport(float5);
								if ((object)GM.Core != null)
								{
									bool focusCameraOnPlayer = default(bool);
									GM.Core.TeleportPlayers(float5, float5, centered: true, focusCameraOnPlayer);
									GameManager core3 = GM.Core;
									if ((object)GM.Core != null)
									{
										List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core3._mainCharacters;
										if (core3._mainCharacters != null)
										{
											bool flag8 = mainCharacters._size <= 0;
											items2 = mainCharacters._items;
											if (mainCharacters._items != null)
											{
												bool flag9 = items2.Length <= 0;
												biomeToActivate = EmeraldsBiomes.Junction;
												goto IL_0be5;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				GameManager core4 = GM.Core;
				if ((object)GM.Core != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core4._mainCharacters;
					if (core4._mainCharacters != null)
					{
						bool flag10 = mainCharacters2._size <= 0;
						num2 = flag10;
						items2 = mainCharacters2._items;
						if (mainCharacters2._items != null)
						{
							bool flag11 = items2.Length <= 0;
							num3 = flag11;
							goto IL_07a2;
						}
					}
				}
			}
		}
		else
		{
			GameManager core5 = GM.Core;
			if ((object)GM.Core != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters3 = core5._mainCharacters;
				if (core5._mainCharacters != null)
				{
					bool flag12 = mainCharacters3._size <= 0;
					num2 = flag12;
					VampireSurvivors.Objects.Characters.CharacterController[] items3 = mainCharacters3._items;
					if (mainCharacters3._items != null)
					{
						bool flag13 = items3.Length <= 0;
						num3 = flag13;
						items2 = mainCharacters3._items;
						goto IL_07a2;
					}
				}
			}
		}
		goto IL_0a32;
		IL_07a2:
		biomeToActivate = EmeraldsBiomes.Biome1;
		goto IL_0be5;
		IL_0be5:
		ActivateBiome(items2[0], biomeToActivate);
		GameManager core6 = GM.Core;
		if ((object)GM.Core != null && core6._multiplayer != null)
		{
			if (!core6._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
			if ((object)GM.Core != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController myOnlinePlayer = GM.Core.MyOnlinePlayer;
				CS_0024_003C_003E8__locals8.localPlayer = myOnlinePlayer;
				VampireSurvivors.Objects.Characters.CharacterController localPlayer = CS_0024_003C_003E8__locals8.localPlayer;
				Action b = delegate
				{
					GameManager core8 = GM.Core;
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters4 = core8._mainCharacters;
					int num4 = core8._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
					if (core8._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField < mainCharacters4._size)
					{
						VampireSurvivors.Objects.Characters.CharacterController[] items5 = mainCharacters4._items;
						BackgroundEmerald backgroundEmerald = CS_0024_003C_003E8__locals8._003C_003E4__this;
						float2 position = items5[num4].position;
						Vector2 position2 = default(Vector2);
						bool flag21 = backgroundEmerald._biomeBounds.TryGetBiomePositionIsInside(position2, out var biome);
						CS_0024_003C_003E8__locals8._003C_003E4__this.ActivateBiome(CS_0024_003C_003E8__locals8.localPlayer, biome);
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
				};
				if ((object)CS_0024_003C_003E8__locals8.localPlayer != null)
				{
					Delegate obj3 = localPlayer.OnRevivalStarted;
					bool flag18;
					do
					{
						Delegate obj4 = Delegate.Combine(obj3, b);
						bool flag14 = (object)obj4 == null;
						Delegate obj5 = null;
						if (!flag14)
						{
							bool flag15 = (object)obj4.GetType() != typeof(Action);
							obj5 = null;
							if (!flag15)
							{
								obj5 = obj4;
							}
							bool flag16 = (object)obj5 == null;
						}
						bool flag17 = (object)obj3 == localPlayer.OnRevivalStarted;
						Delegate obj6;
						if ((object)obj3 == localPlayer.OnRevivalStarted)
						{
							localPlayer.OnRevivalStarted = (Action)obj5;
							obj6 = obj3;
						}
						else
						{
							obj6 = localPlayer.OnRevivalStarted;
						}
						Delegate obj7 = obj3;
						if (!flag17)
						{
							obj7 = obj6;
						}
						flag18 = (object)obj7 != obj3;
						obj3 = obj7;
					}
					while (flag18);
					return;
				}
			}
		}
		goto IL_0a32;
		IL_02f7:
		SetUpTeleporters();
		GameManager core7 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core7._stage;
			if ((object)core7._stage != null && (object)stage._tilingTileset != null)
			{
				scriptsFromName = stage._tilingTileset.GetScriptsFromName("JunctionPlayerStart");
				if (scriptsFromName == null || scriptsFromName._size <= 0)
				{
					goto IL_0491;
				}
				bool flag19 = scriptsFromName._size <= 0;
				SuperObject[] items4 = scriptsFromName._items;
				if (scriptsFromName._items != null)
				{
					bool flag20 = items4.Length <= 0;
					if ((object)items4[0] != null)
					{
						Transform junctionSpawnTransform2 = items4[0].transform;
						_junctionSpawnTransform = junctionSpawnTransform2;
						goto IL_0491;
					}
				}
			}
		}
		goto IL_0a32;
	}

	public void TeleportBossKilled(EmeraldsBiomes bossBiome, string[] teleportKeys)
	{
		//IL_00e4: Expected O, but got I4
		//IL_0190: Expected O, but got I4
		//IL_03c7->IL033c: Incompatible stack heights: 1 vs 0
		//IL_041c->IL033c: Incompatible stack heights: 2 vs 0
		//IL_009d->IL033c: Incompatible stack heights: 2 vs 0
		//IL_00cc->IL033c: Incompatible stack heights: 2 vs 0
		//IL_0149->IL033c: Incompatible stack heights: 2 vs 0
		//IL_0178->IL033c: Incompatible stack heights: 2 vs 0
		//IL_01bc->IL01bc: Incompatible stack heights: 2 vs 0
		ActivateTeleporters(teleportKeys);
		if (_biomeToJunctionTeleporterLookup != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)_biomeToJunctionTeleporterLookup).TryGetValue((System.Int32Enum)_003CCurrentBiome_003Ek__BackingField, out object value))
			{
				goto IL_01bc;
			}
			EME_RibbonController emeraldRibbonController = _emeraldRibbonController;
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_8_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_8_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v28 (UnityEngine.Transform)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v28 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
					if ((object)_emeraldRibbonController != null)
					{
						emeraldRibbonController._currentState = EME_RibbonController.RibbonState.TravelingToNewTarget;
						if ((object)emeraldRibbonController._ribbon != null)
						{
							GameObject gameObject = emeraldRibbonController._ribbon.gameObject;
							if ((object)gameObject != null)
							{
								object obj = emeraldRibbonController._currentState - 3;
								bool flag3 = obj == null;
								bool active = !flag3;
								gameObject.SetActive(active);
								emeraldRibbonController._targetPosition = ret;
								_ = 0;
								emeraldRibbonController._currentState = EME_RibbonController.RibbonState.TravelingToNewTarget;
								if ((object)emeraldRibbonController._ribbon != null)
								{
									GameObject gameObject2 = emeraldRibbonController._ribbon.gameObject;
									if ((object)gameObject2 != null)
									{
										object obj2 = emeraldRibbonController._currentState - 3;
										bool flag4 = obj2 == null;
										bool active2 = !flag4;
										gameObject2.SetActive(active2);
										goto IL_01bc;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_033c;
		IL_033c:
		throw new NullReferenceException();
		IL_01bc:
		if (bossBiome == _nextBossBiome)
		{
			if (_003CCurrentBiome_003Ek__BackingField == EmeraldsBiomes.Biome6)
			{
				_finalBossDefeated = true;
				_nextBossBiome = EmeraldsBiomes.Junction;
			}
			else
			{
				EmeraldsBiomes nextBossBiome = _nextBossBiome + 1;
				_nextBossBiome = nextBossBiome;
			}
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				if ((int)_nextBossBiome <= config._003CEME_NextBossBiome_003Ek__BackingField)
				{
					return;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._playerOptions != null)
				{
					PlayerOptionsData config2 = core2._playerOptions.Config;
					if (config2 != null)
					{
						config2._003CEME_NextBossBiome_003Ek__BackingField = (int)_nextBossBiome;
						return;
					}
				}
			}
		}
		goto IL_033c;
	}

	private void IncrementNextBiome()
	{
		if (_003CCurrentBiome_003Ek__BackingField == EmeraldsBiomes.Biome6)
		{
			_finalBossDefeated = true;
			_nextBossBiome = EmeraldsBiomes.Junction;
		}
		else
		{
			EmeraldsBiomes nextBossBiome = _nextBossBiome + 1;
			_nextBossBiome = nextBossBiome;
		}
	}

	private unsafe void ActivateTeleporters(string[] teleportKeys)
	{
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_0096: Expected O, but got Ref
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if ((object)stage._tilingTileset == null || tilingTileset._003CListOfTeleporters_003Ek__BackingField == null)
		{
			return;
		}
		Component component = null;
		List<PickupTeleporter>.Enumerator enumerator = default(List<PickupTeleporter>.Enumerator);
		while ((nint)component < teleportKeys.Length)
		{
			string text = teleportKeys[(object)component];
			if (enumerator.MoveNext())
			{
				Component component2 = null;
				List<PickupTeleporter>.Enumerator enumerator2 = (List<PickupTeleporter>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			component = (Component)(component + 1);
		}
	}

	private void SetBiomeDifficulty()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		EmeraldsBiomes emeraldsBiomes = ((_003CCurrentBiome_003Ek__BackingField != EmeraldsBiomes.Junction) ? _003CCurrentBiome_003Ek__BackingField : EmeraldsBiomes.Biome1);
		float num = (float)emeraldsBiomes * 0.02f;
		float num2 = 1f - num;
		object obj = default(object);
		if ((object)stageModifiers._003CEnemyHealthMultiplier_003Ek__BackingField != null)
		{
			float num3 = (float)emeraldsBiomes * 0.05f;
			float num4 = num3 + 1f;
			if ((object)stageModifiers._003CEnemyHealthMultiplier_003Ek__BackingField == null)
			{
				goto IL_0148;
			}
			float enemyHealthMultiplier = (float)obj * num4;
			GameManager.EnemyHealthMultiplier = enemyHealthMultiplier;
		}
		if ((object)stageModifiers._003CXpBonus_003Ek__BackingField != null)
		{
			if ((object)stageModifiers._003CXpBonus_003Ek__BackingField != null)
			{
				float experienceMultiplier = (float)obj * num2;
				GameManager.ExperienceMultiplier = experienceMultiplier;
				return;
			}
			goto IL_0148;
		}
		return;
		IL_0148:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private void SetUpTeleporters()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					List<PickupTeleporter> list = tilingTileset._003CListOfTeleporters_003Ek__BackingField;
					if (tilingTileset._003CListOfTeleporters_003Ek__BackingField != null && list._size != 0)
					{
						List<PickupTeleporter>.Enumerator enumerator = default(List<PickupTeleporter>.Enumerator);
						while (enumerator.MoveNext())
						{
							Pickup_EME_Teleporter pickup_EME_Teleporter = null;
						}
						return;
					}
				}
				if ((object)GM.Core != null)
				{
					if (GM.Core.IsStageHost)
					{
						Debug.LogError("This level is expected to have teleporters, but we don't have any. Something's gone wrong!");
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SetupTeleporter(Pickup_EME_Teleporter emeTeleporter)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_0092: Expected O, but got I4
		//IL_009f: Expected O, but got I8
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_09eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Expected Ref, but got Unknown
		//IL_0a07: Expected I8, but got I4
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Expected Ref, but got Unknown
		//IL_0af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afe: Expected Ref, but got Unknown
		//IL_0b15: Expected I8, but got I4
		//IL_0b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b24: Expected Ref, but got Unknown
		//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Expected Ref, but got Unknown
		//IL_07df: Expected I8, but got I4
		//IL_07e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected Ref, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected Ref, but got Unknown
		//IL_0437: Expected I8, but got I4
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected Ref, but got Unknown
		//IL_08d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Expected Ref, but got Unknown
		//IL_08f3: Expected I8, but got I4
		//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0902: Expected Ref, but got Unknown
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected Ref, but got Unknown
		//IL_06a7: Expected I8, but got I4
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected Ref, but got Unknown
		//IL_0540: Expected O, but got I4
		//IL_054f: Expected O, but got I4
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected Ref, but got Unknown
		//IL_020f: Expected I8, but got I4
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected Ref, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected Ref, but got Unknown
		//IL_0323: Expected I8, but got I4
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected Ref, but got Unknown
		if (emeTeleporter._mapToken != null)
		{
			MapToken mapToken = emeTeleporter._mapToken;
			mapToken.Hidden = true;
		}
		Action<VampireSurvivors.Objects.Characters.CharacterController> value = OnTeleportStart;
		emeTeleporter.OnTeleportStartedAction += value;
		string text = emeTeleporter._003CDestinationName_003Ek__BackingField;
		if (emeTeleporter._003CDestinationName_003Ek__BackingField == null)
		{
			return;
		}
		object obj = emeTeleporter._003CDestinationName_003Ek__BackingField + 20;
		object obj2 = 0;
		object obj3 = 2166136261L;
		Vector2 position2 = default(Vector2);
		while (true)
		{
			if ((nint)obj2 < text._stringLength)
			{
				if ((nint)obj2 >= text._stringLength)
				{
					break;
				}
				obj2++;
				object obj4 = obj ^ obj3;
				obj3 = obj4 * 16777619;
				obj += 2;
				continue;
			}
			if ((long)obj3 > 3505968886L)
			{
				if ((long)obj3 > 3556301743L)
				{
					if ((long)obj3 == 3573079362L)
					{
						object obj5 = "biome5";
						if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "biome5")
						{
							if ("biome5" == null)
							{
								return;
							}
							int stringLength = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rdx_v48+10]");
							if ((nint)stringLength != 0)
							{
								return;
							}
							ref byte first = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							if (!System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("biome5" + 20), length))
							{
								return;
							}
						}
						ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes.Biome5, emeTeleporter);
					}
					else
					{
						if ((long)obj3 != 3589856981L)
						{
							return;
						}
						object obj6 = "biome4";
						if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "biome4")
						{
							if ("biome4" == null)
							{
								return;
							}
							int stringLength2 = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rdx_v44+10]");
							if ((nint)stringLength2 != 0)
							{
								return;
							}
							ref byte first2 = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
							ulong length2 = (ulong)(text._stringLength + text._stringLength);
							if (!System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("biome4" + 20), length2))
							{
								return;
							}
						}
						ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes.Biome4, emeTeleporter);
					}
				}
				else if ((long)obj3 == 3522746505L)
				{
					object obj7 = "biome0";
					if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "biome0")
					{
						if ("biome0" == null)
						{
							return;
						}
						int stringLength3 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rdx_v28+10]");
						if ((nint)stringLength3 != 0)
						{
							return;
						}
						ref byte first3 = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
						ulong length3 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("biome0" + 20), length3))
						{
							return;
						}
					}
					Action<VampireSurvivors.Objects.Characters.CharacterController> value2 = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
					{
						ActivateBiome(player, EmeraldsBiomes.Junction);
					};
					emeTeleporter.OnPlayersTeleported += value2;
					Transform transform = emeTeleporter.transform;
					Vector3 position = transform.position;
					bool doorOpen;
					Pickup_EME_Teleporter pickup_EME_Teleporter;
					if (!_biomeBounds.TryGetBiomePositionIsInside(position2, out var biome))
					{
						doorOpen = false;
						pickup_EME_Teleporter = emeTeleporter;
					}
					else
					{
						bool flag = ((Dictionary<System.Int32Enum, object>)(object)_biomeToJunctionTeleporterLookup).TryInsert((System.Int32Enum)biome, (object)emeTeleporter, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						if (biome != EmeraldsBiomes.Biome6)
						{
							object obj8 = _nextBossBiome - biome;
							object obj9 = _nextBossBiome ^ biome;
							object obj10 = _nextBossBiome ^ obj8;
							object obj11 = obj9 & obj10;
							bool flag2 = (nint)obj11 < 0;
							bool flag3 = (nint)obj8 < 0;
							bool flag4 = obj8 == null;
							bool flag5 = flag3 == flag2;
							bool flag6 = !flag4;
							doorOpen = flag6 & flag5;
							pickup_EME_Teleporter = emeTeleporter;
						}
						else
						{
							doorOpen = _finalBossDefeated;
							pickup_EME_Teleporter = emeTeleporter;
						}
					}
					pickup_EME_Teleporter.SetDoorOpen(doorOpen);
				}
				else
				{
					if ((long)obj3 != 3556301743L)
					{
						return;
					}
					object obj12 = "biome6";
					if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "biome6")
					{
						if ("biome6" == null)
						{
							return;
						}
						int stringLength4 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rdx_v24+10]");
						if ((nint)stringLength4 != 0)
						{
							return;
						}
						ref byte first4 = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
						ulong length4 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("biome6" + 20), length4))
						{
							return;
						}
					}
					ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes.Biome6, emeTeleporter);
				}
			}
			else if ((long)obj3 > 3472413648L)
			{
				if ((long)obj3 == 3489191267L)
				{
					object obj13 = "biome2";
					if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "biome2")
					{
						if ("biome2" == null)
						{
							return;
						}
						int stringLength5 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rdx_v20+10]");
						if ((nint)stringLength5 != 0)
						{
							return;
						}
						ref byte first5 = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
						ulong length5 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("biome2" + 20), length5))
						{
							return;
						}
					}
					ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes.Biome2, emeTeleporter);
				}
				else
				{
					if ((long)obj3 != 3505968886L)
					{
						return;
					}
					object obj14 = "biome1";
					if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "biome1")
					{
						if ("biome1" == null)
						{
							return;
						}
						int stringLength6 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rdx_v16+10]");
						if ((nint)stringLength6 != 0)
						{
							return;
						}
						ref byte first6 = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
						ulong length6 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("biome1" + 20), length6))
						{
							return;
						}
					}
					ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes.Biome1, emeTeleporter);
				}
			}
			else if ((long)obj3 == 3441521455L)
			{
				object obj15 = "isDestination";
				if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "isDestination")
				{
					if ("isDestination" == null)
					{
						return;
					}
					int stringLength7 = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rdx_v12+10]");
					if ((nint)stringLength7 != 0)
					{
						return;
					}
					ref byte first7 = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
					ulong length7 = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("isDestination" + 20), length7))
					{
						return;
					}
				}
				DisableTeleporter(emeTeleporter);
			}
			else
			{
				if ((long)obj3 != 3472413648L)
				{
					return;
				}
				object obj16 = "biome3";
				if ((object)emeTeleporter._003CDestinationName_003Ek__BackingField != "biome3")
				{
					if ("biome3" == null)
					{
						return;
					}
					int stringLength8 = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdx_v8+10]");
					if ((nint)stringLength8 != 0)
					{
						return;
					}
					ref byte first8 = ref *(byte*)(emeTeleporter._003CDestinationName_003Ek__BackingField + 20);
					ulong length8 = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref first8, ref *(byte*)("biome3" + 20), length8))
					{
						return;
					}
				}
				ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes.Biome3, emeTeleporter);
			}
			return;
		}
		System.ThrowHelper.ThrowIndexOutOfRangeException();
	}

	private static void DisableTeleporter(Pickup_EME_Teleporter emeTeleporter)
	{
		//IL_0059: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0130->IL0130: Incompatible stack heights: 1 vs 0
		if ((object)emeTeleporter != null)
		{
			GameObject gameObject = emeTeleporter.gameObject;
			if ((object)gameObject != null)
			{
				SpriteRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
				bool flag = componentsInChildren == null;
				object obj = 0;
				object obj2 = 0;
				if (!flag)
				{
					while (true)
					{
						if ((nint)obj2 < componentsInChildren.Length)
						{
							SpriteRenderer spriteRenderer = componentsInChildren[obj];
							if ((object)componentsInChildren[obj] == null)
							{
								break;
							}
							bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
							Renderer.set_enabled_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, false);
							obj++;
							obj2 = obj;
							continue;
						}
						((Pickup)emeTeleporter)._003CDisableGet_003Ek__BackingField = true;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ConfigureJunctionToBiomeTeleporter(EmeraldsBiomes targetBiome, Pickup_EME_Teleporter teleporter)
	{
		//IL_00b5: Expected O, but got I4
		//IL_00c9: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		_003C_003Ec__DisplayClass52_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass52_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		CS_0024_003C_003E8__locals7.targetBiome = targetBiome;
		Action<VampireSurvivors.Objects.Characters.CharacterController> value = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			CS_0024_003C_003E8__locals7._003C_003E4__this.ActivateBiome(player, CS_0024_003C_003E8__locals7.targetBiome);
		};
		teleporter.OnPlayersTeleported += value;
		if (!((PickupTeleporter)teleporter)._teleporterKey.Contains("junction_to"))
		{
			DisableTeleporter(teleporter);
			return;
		}
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_junctionToBiomeTeleporterLookup).TryInsert((System.Int32Enum)CS_0024_003C_003E8__locals7.targetBiome, (object)teleporter, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj = _nextBossBiome - CS_0024_003C_003E8__locals7.targetBiome;
		object obj2 = _nextBossBiome ^ CS_0024_003C_003E8__locals7.targetBiome;
		object obj3 = _nextBossBiome ^ obj;
		object obj4 = obj2 & obj3;
		bool flag2 = (nint)obj4 < 0;
		bool flag3 = (nint)obj < 0;
		bool doorOpen = flag3 == flag2;
		teleporter.SetDoorOpen(doorOpen);
	}

	private unsafe void OnTeleportStart(VampireSurvivors.Objects.Characters.CharacterController playerTeleported)
	{
		//IL_0015: Expected O, but got I
		//IL_004b: Expected O, but got I
		//IL_0309: Expected O, but got Ref
		//IL_014d: Expected O, but got Ref
		//IL_0190: Expected O, but got I
		//IL_0366: Expected O, but got Ref
		//IL_01bc: Expected O, but got Ref
		//IL_01ff: Expected O, but got I
		//IL_022b: Expected O, but got Ref
		//IL_026e: Expected O, but got I
		PlayerOptions playerOptions = (PlayerOptions)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
			playerOptions = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v10 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					if (!config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
					{
						goto IL_0112;
					}
					if ((object)playerTeleported != null)
					{
						bool flag = (object)playerTeleported._coherenceSync == null;
						playerOptions = (PlayerOptions)(object)playerTeleported._coherenceSync;
						if (!flag)
						{
							bool hasStateAuthority = playerTeleported._coherenceSync.HasStateAuthority;
							bool flag2 = !hasStateAuthority;
							playerOptions = (PlayerOptions)(object)playerTeleported._coherenceSync;
							if (!flag2)
							{
								goto IL_0112;
							}
							return;
						}
					}
				}
			}
		}
		goto IL_027f;
		IL_0112:
		Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator enumerator2;
		if (_bossPizzas != null)
		{
			Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator enumerator = default(Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator);
			object obj = default(object);
			while (enumerator.MoveNext())
			{
				bool flag3 = obj == null;
				enumerator2 = (Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator)(&enumerator);
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ stack_-30+48]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ stack_-30+48]");
						object obj2 = 0;
						_ = 1;
					}
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag4 = _biomeToJunctionTeleporterLookup == null;
			playerOptions = (PlayerOptions)(&enumerator);
			if (!flag4)
			{
				Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator enumerator3 = default(Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator);
				object obj3 = default(object);
				while (enumerator3.MoveNext())
				{
					bool flag5 = obj3 == null;
					Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator enumerator4 = (Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator)(&enumerator3);
					if (!flag5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ stack_-58+258]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ stack_-58+258]");
							object obj4 = 0;
							_ = 1;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag6 = _junctionToBiomeTeleporterLookup == null;
				playerOptions = (PlayerOptions)(&enumerator3);
				if (!flag6)
				{
					Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator enumerator5 = default(Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator);
					while (enumerator5.MoveNext())
					{
						bool flag7 = obj3 == null;
						Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator enumerator6 = (Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator)(&enumerator5);
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ stack_-58+258]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ stack_-58+258]");
								object obj5 = 0;
								_ = 1;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					DisablePositionLimitingOnTeleportStart();
					return;
				}
			}
		}
		goto IL_027f;
		IL_027f:
		enumerator2 = (Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator)playerOptions;
		throw new NullReferenceException();
	}

	private void DisablePositionLimitingOnTeleportStart()
	{
		//IL_0019: Expected O, but got I4
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private unsafe void ActivateBiome(VampireSurvivors.Objects.Characters.CharacterController playerTeleported, EmeraldsBiomes biomeToActivate)
	{
		//IL_0030: Expected O, but got I
		//IL_0066: Expected O, but got I
		//IL_01a6: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_0331: Expected I, but got O
		//IL_0362: Expected O, but got I
		//IL_022d: Expected I, but got O
		//IL_025e: Expected O, but got I
		//IL_0399: Expected O, but got I
		//IL_03e6: Expected O, but got F4
		//IL_03ef: Expected F4, but got I4
		//IL_0e2a: Expected I, but got O
		//IL_0e5b: Expected O, but got I
		//IL_0425: Expected O, but got I
		//IL_030c: Expected O, but got I4
		//IL_047d: Expected O, but got I
		//IL_0eb4: Expected I, but got O
		//IL_0ee5: Expected O, but got I
		//IL_055f: Expected O, but got I
		//IL_05b6: Expected F4, but got O
		//IL_0642: Expected O, but got I
		//IL_066f: Expected I, but got O
		//IL_0778: Expected O, but got Ref
		//IL_0722: Expected O, but got I
		//IL_07bc: Expected O, but got Ref
		//IL_0b0e: Expected O, but got I
		//IL_0ccf: Expected O, but got I4
		//IL_0cff: Expected O, but got I4
		//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d33: Expected O, but got Unknown
		//IL_083e: Expected F4, but got I4
		//IL_084f: Expected O, but got I4
		//IL_0854: Expected I, but got O
		//IL_0873: Expected O, but got I
		//IL_0882: Expected F4, but got I4
		//IL_0893: Expected O, but got I4
		//IL_0898: Expected I, but got O
		//IL_0fee: Expected O, but got I
		//IL_08f3: Expected O, but got I
		//IL_08fc: Expected O, but got I4
		//IL_1101: Expected O, but got I
		//IL_0c39: Expected O, but got I
		//IL_0c52: Expected O, but got I4
		//IL_0c5b: Expected F4, but got I4
		//IL_0c64: Expected O, but got I4
		//IL_0c6c: Expected O, but got Ref
		//IL_093b: Expected O, but got I4
		//IL_096a: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Expected O, but got Unknown
		//IL_09ae: Expected O, but got I4
		//IL_09de: Expected O, but got I4
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Expected O, but got Unknown
		//IL_0486->IL0d5f: Incompatible stack heights: 1 vs 0
		//IL_04e1->IL0d5f: Incompatible stack heights: 1 vs 0
		//IL_0527->IL0d5f: Incompatible stack heights: 1 vs 0
		//IL_0eee->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0568->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_05f1->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_062d->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0662->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0699->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0ab6->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_06e8->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0747->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_1073->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0af9->IL1033: Incompatible stack heights: 3 vs 2
		//IL_0cbc->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_07dd->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_08b2->IL0d97: Incompatible stack heights: 2 vs 0
		//IL_0b19->IL1033: Incompatible stack heights: 3 vs 2
		//IL_0cec->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0b6a->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_08d9->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0bc6->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0d1b->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0b9c->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0bf8->IL0d97: Incompatible stack heights: 2 vs 0
		//IL_0d5f->IL0d97: Incompatible stack heights: 2 vs 0
		//IL_0811->IL0d5f: Incompatible stack heights: 3 vs 0
		//IL_0c1f->IL0d5f: Incompatible stack heights: 2 vs 0
		//IL_0fdc->IL0d5f: Incompatible stack heights: 3 vs 0
		//IL_085e->IL0f61: Incompatible stack heights: 3 vs 2
		//IL_089e->IL0f12: Incompatible stack heights: 3 vs 2
		//IL_10ef->IL0d5f: Incompatible stack heights: 3 vs 0
		//IL_102e->IL0d5f: Incompatible stack heights: 4 vs 0
		//IL_0928->IL0d5f: Incompatible stack heights: 4 vs 0
		//IL_0957->IL0d5f: Incompatible stack heights: 4 vs 0
		//IL_09cb->IL0d5f: Incompatible stack heights: 4 vs 0
		//IL_0c98->IL0c98: Incompatible stack heights: 5 vs 2
		//IL_09fa->IL0d5f: Incompatible stack heights: 4 vs 0
		//IL_0a5d->IL0d5f: Incompatible stack heights: 4 vs 0
		//IL_0a8c->IL0d5f: Incompatible stack heights: 4 vs 0
		//IL_0a9c->IL0d97: Incompatible stack heights: 4 vs 0
		PlayerOptions core = (PlayerOptions)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v38 (VampireSurvivors.Objects.PlayerOptions)+90]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v38 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v38 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					if (!config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
					{
						goto IL_0120;
					}
					if ((object)playerTeleported != null)
					{
						bool flag = (object)playerTeleported._coherenceSync == null;
						core = (PlayerOptions)(object)playerTeleported._coherenceSync;
						if (!flag)
						{
							if (playerTeleported._coherenceSync.HasStateAuthority)
							{
								goto IL_0120;
							}
							return;
						}
					}
				}
			}
		}
		goto IL_0d5f;
		IL_0f61:
		if (_003CCurrentBiome_003Ek__BackingField == _nextBossBiome)
		{
			goto IL_0c98;
		}
		bool flag2;
		if (!flag2)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController emeraldRibbonController = (VampireSurvivors.Objects.Characters.CharacterController)(object)_emeraldRibbonController;
		object obj;
		bool num;
		bool num2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r14_v27 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			num = flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r14_v27 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform != null)
			{
				object obj2 = (nint)((UnityEngine.Object)transform).m_CachedPtr;
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				num2 = flag4;
				object obj3 = 0;
				object obj4 = 0;
				goto IL_100c;
			}
		}
		goto IL_0d5f;
		IL_100c:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3014 @ rax_v73 (should have been resolved before IL gen)");
		if ((object)emeraldRibbonController != null)
		{
			((PhaserGameObject)emeraldRibbonController)._scene = null;
			if (((GameMonoBehaviour)emeraldRibbonController)._onPauseSent)
			{
				GameObject gameObject = ((Component)((GameMonoBehaviour)emeraldRibbonController)._onPauseSent).gameObject;
				if ((object)gameObject != null)
				{
					object obj5 = ((PhaserGameObject)emeraldRibbonController)._scene - 3;
					bool flag5 = obj5 == null;
					bool active = !flag5;
					gameObject.SetActive(active);
					((PhaserGameObject)emeraldRibbonController)._scene = (PhaserScene)1;
					if (((GameMonoBehaviour)emeraldRibbonController)._onPauseSent)
					{
						GameObject gameObject2 = ((Component)((GameMonoBehaviour)emeraldRibbonController)._onPauseSent).gameObject;
						if ((object)gameObject2 != null)
						{
							object obj6 = ((PhaserGameObject)emeraldRibbonController)._scene - 3;
							bool flag6 = obj6 == null;
							bool active2 = !flag6;
							gameObject2.SetActive(active2);
							bool onPauseSent = ((GameMonoBehaviour)emeraldRibbonController)._onPauseSent;
							if (~(((GameMonoBehaviour)emeraldRibbonController)._onPauseSent ? 1u : 0u) == 0)
							{
								_ = 1065353216;
								bool onPauseSent2 = ((GameMonoBehaviour)emeraldRibbonController)._onPauseSent;
								if (~(((GameMonoBehaviour)emeraldRibbonController)._onPauseSent ? 1u : 0u) == 0)
								{
									_ = 0;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0d5f;
		IL_0d5f:
		throw new NullReferenceException();
		IL_0f12:
		object value;
		obj = value;
		goto IL_0f61;
		IL_0c98:
		VampireSurvivors.Objects.Characters.CharacterController emeraldRibbonController2 = (VampireSurvivors.Objects.Characters.CharacterController)(object)_emeraldRibbonController;
		if ((object)_emeraldRibbonController != null)
		{
			((PhaserGameObject)emeraldRibbonController2)._scene = (PhaserScene)3;
			if (((GameMonoBehaviour)emeraldRibbonController2)._onPauseSent)
			{
				GameObject gameObject3 = ((Component)((GameMonoBehaviour)emeraldRibbonController2)._onPauseSent).gameObject;
				if ((object)gameObject3 != null)
				{
					object obj7 = ((PhaserGameObject)emeraldRibbonController2)._scene - 3;
					bool flag7 = obj7 == null;
					bool active3 = !flag7;
					gameObject3.SetActive(active3);
					return;
				}
			}
		}
		goto IL_0d5f;
		IL_1078:
		if (_finalBossDefeated)
		{
			goto IL_0c98;
		}
		float num3;
		if (_junctionToBiomeTeleporterLookup != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)_junctionToBiomeTeleporterLookup).TryGetValue((System.Int32Enum)_nextBossBiome, out object value2))
			{
				return;
			}
			emeraldRibbonController = (VampireSurvivors.Objects.Characters.CharacterController)(object)_emeraldRibbonController;
			if (value2 != null)
			{
				bool flag8 = ((UnityEngine.Object)value2).m_CachedPtr == (IntPtr)0;
				num = flag8;
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)value2).m_CachedPtr);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				if ((object)transform2 != null)
				{
					object obj2 = (nint)((UnityEngine.Object)transform2).m_CachedPtr;
					bool flag9 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					num2 = flag9;
					object obj3 = 0;
					bool flag10 = (nint)0 != 0;
					object obj4 = 0;
					num3 = 0f;
					Vector2 vector = (Vector2)2;
					object obj8 = (object)(&value2);
					nint num4 = 0;
					if (!flag10)
					{
						bool flag11 = (nint)0 == 0;
						goto IL_0c98;
					}
					goto IL_100c;
				}
			}
		}
		goto IL_0d5f;
		IL_0120:
		if (biomeToActivate != EmeraldsBiomes.Junction)
		{
			_003CHasLeftJunction_003Ek__BackingField = true;
		}
		_003CCurrentBiome_003Ek__BackingField = biomeToActivate;
		SetBiomeDifficulty();
		bool flag12 = (object)_biomeBounds == null;
		core = (PlayerOptions)(object)this;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3;
		if (!flag12)
		{
			num3 = _biomeBounds.GetBoundsForBiome(_003CCurrentBiome_003Ek__BackingField).UpperLimit;
			core = (PlayerOptions)(object)GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v38 (VampireSurvivors.Objects.PlayerOptions)+90]");
				core = (PlayerOptions)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v38 (VampireSurvivors.Objects.PlayerOptions)+90]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v38 (VampireSurvivors.Objects.PlayerOptions)+90]");
					PlayerOptionsData config2 = ((PlayerOptions)0).Config;
					if (config2 != null)
					{
						if (!config2._003CSelectedOnlineFreeRoam_003Ek__BackingField)
						{
							goto IL_0323;
						}
						nint num5 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1570 @ rax_v167 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num6 = 0;
						GameManager core2 = GM.Core;
						bool flag13 = (object)GM.Core == null;
						core = (PlayerOptions)num6;
						if (!flag13)
						{
							bool flag14 = core2._multiplayer == null;
							core = (PlayerOptions)(object)core2._multiplayer;
							if (!flag14)
							{
								if (!core2._multiplayer.IsOnlineMultiplayer)
								{
									goto IL_0323;
								}
								bool flag15 = (object)playerTeleported == null;
								core = (PlayerOptions)(object)core2._multiplayer;
								if (!flag15)
								{
									playerTeleported._useWorldSpaceMovementLimits = true;
									playerTeleported._worldSpaceMovementLimits = (VampireSurvivors.Objects.Characters.CharacterController.WorldSpaceLimits)0;
									_ = 0;
									_ = 1;
									_ = 1;
									List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
									enumerator = enumerator2;
									enumerator3 = enumerator2;
									List<VampireSurvivors.Objects.Characters.CharacterController> list = null;
									goto IL_0e1c;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0d5f;
		IL_0323:
		nint num7 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v853 @ rax_v154 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num8 = 0;
		GameManager core3 = GM.Core;
		bool flag16 = (object)GM.Core == null;
		core = (PlayerOptions)num8;
		if (!flag16)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> list = core3._characters;
			bool flag17 = core3._characters == null;
			core = (PlayerOptions)num8;
			if (!flag17)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator4 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator4.MoveNext())
				{
					PlayerOptions playerOptions = null;
					core = null;
					throw new NullReferenceException();
				}
				enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)num3;
				num3 = 0f;
				enumerator3 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)list;
				goto IL_0e1c;
			}
		}
		goto IL_0d5f;
		IL_0e1c:
		nint num9 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rax_v55 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num10 = 0;
		GameManager core4 = GM.Core;
		bool flag18 = (object)GM.Core == null;
		core = (PlayerOptions)num10;
		if (!flag18)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core4._mainCharacters;
			bool flag19 = core4._mainCharacters == null;
			core = (PlayerOptions)num10;
			if (!flag19)
			{
				bool flag20 = mainCharacters._size <= 0;
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				bool flag21 = mainCharacters._items == null;
				core = (PlayerOptions)num10;
				if (!flag21)
				{
					if (items.Length <= 0)
					{
						throw new IndexOutOfRangeException();
					}
					bool flag22 = (object)items[0] == null;
					core = (PlayerOptions)(object)items[0];
					if (!flag22)
					{
						Transform transform3 = items[0].transform;
						bool flag23 = (object)transform3 == null;
						core = (PlayerOptions)(object)items[0];
						if (!flag23)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v856 @ rax_v59 (UnityEngine.Transform)+10]");
							bool flag24 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v856 @ rax_v59 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
							nint num11 = (nint)typeof(GM);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2426 @ rax_v65 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
							nint num12 = 0;
							GameManager core5 = GM.Core;
							bool flag25 = (object)GM.Core == null;
							core = (PlayerOptions)num12;
							if (!flag25)
							{
								Stage stage = core5._stage;
								bool flag26 = (object)core5._stage == null;
								core = (PlayerOptions)num12;
								if (!flag26)
								{
									bool flag27 = (object)stage._tilingTileset == null;
									Vector2 vector = (Vector2)enumerator3;
									if (!flag27)
									{
										Vector2 vector2 = default(Vector2);
										stage._tilingTileset.UpdateHorizontalTilesetOnTeleport(vector2);
										num3 = (float)enumerator;
										vector = vector2;
									}
									object biomeNameUi = _biomeNameUi;
									bool flag28 = _localizedBiomeNamesLookup == null;
									core = (PlayerOptions)(object)_localizedBiomeNamesLookup;
									if (!flag28)
									{
										object obj9 = ((Dictionary<System.Int32Enum, object>)(object)_localizedBiomeNamesLookup).get_Item((System.Int32Enum)biomeToActivate);
										bool flag29 = (object)_biomeNameUi == null;
										core = (PlayerOptions)(object)_localizedBiomeNamesLookup;
										if (!flag29)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r14_v21 (System.Object)+28]");
											core = (PlayerOptions)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r14_v21 (System.Object)+28]");
											if ((nint)0 != 0)
											{
												nint num13 = (nint)core;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2541 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+558] (should have been resolved before IL gen)");
												_ = 1;
												if (_bossPizzas != null)
												{
													if (((Dictionary<System.Int32Enum, object>)(object)_bossPizzas).TryGetValue((System.Int32Enum)_003CCurrentBiome_003Ek__BackingField, out object value3))
													{
														if (value3 == null)
														{
															goto IL_0d5f;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ stack_-B0_v20 (System.Object)+48]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ stack_-B0_v20 (System.Object)+48]");
															object obj10 = 0;
															_ = 0;
														}
													}
													if (_003CCurrentBiome_003Ek__BackingField != EmeraldsBiomes.Junction)
													{
														if (_biomeToJunctionTeleporterLookup != null)
														{
															flag2 = ((Dictionary<System.Int32Enum, object>)(object)_biomeToJunctionTeleporterLookup).TryGetValue((System.Int32Enum)_003CCurrentBiome_003Ek__BackingField, out value);
															bool flag30 = !flag2;
															object obj8 = (object)(&value);
															nint num4 = 0;
															if (flag30)
															{
																goto IL_0f12;
															}
															EmeraldsBiomes emeraldsBiomes = default(EmeraldsBiomes);
															object arg = emeraldsBiomes;
															System.ParamsArray paramsArray = new System.ParamsArray(arg);
															Vector2 vector3 = default(Vector2);
															string message = string.FormatHelper((IFormatProvider)null, "Enabling map token for teleporter in {0}", (System.ParamsArray)(&vector3));
															bool flag31 = value == null;
															core = null;
															if (!flag31)
															{
																bool flag32 = ((UnityEngine.Object)value).m_CachedPtr == (IntPtr)0;
																IntPtr gcHandlePtr3 = Component.get_gameObject_Injected(((UnityEngine.Object)value).m_CachedPtr);
																GameObject context = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
																Debug.Log(message, context);
																if (value != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ stack_-108_v23 (System.Object)+258]");
																	bool flag33 = (nint)0 == 0;
																	obj = value;
																	num3 = 0f;
																	vector = (Vector2)paramsArray;
																	obj8 = 0;
																	num4 = unchecked((nint)null);
																	if (!flag33)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ stack_-108_v23 (System.Object)+258]");
																		object obj11 = 0;
																		_ = 0;
																		num3 = 0f;
																		vector = (Vector2)paramsArray;
																		obj8 = 0;
																		num4 = unchecked((nint)null);
																		goto IL_0f12;
																	}
																	goto IL_0f61;
																}
															}
														}
													}
													else if (_junctionToBiomeTeleporterLookup != null)
													{
														Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator enumerator5 = default(Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>.Enumerator);
														object obj12 = default(object);
														while (enumerator5.MoveNext())
														{
															bool flag34 = obj12 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2794 @ stack_-70+258]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2794 @ stack_-70+258]");
																object obj13 = 0;
																_ = 0;
															}
														}
														if (_junctionToBiomeTeleporterLookup != null)
														{
															int num14 = ((Dictionary<System.Int32Enum, object>)(object)_junctionToBiomeTeleporterLookup).FindEntry((System.Int32Enum)_003CCurrentBiome_003Ek__BackingField);
															if (num14 < 0)
															{
																goto IL_1078;
															}
															if (_junctionToBiomeTeleporterLookup != null)
															{
																object obj14 = ((Dictionary<System.Int32Enum, object>)(object)_junctionToBiomeTeleporterLookup).get_Item((System.Int32Enum)_003CCurrentBiome_003Ek__BackingField);
																if (obj14 != null)
																{
																	_ = 1;
																	goto IL_1078;
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
		goto IL_0d5f;
	}

	private void SetupTeleportFader()
	{
		//IL_02b0: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected I4, but got Unknown
		//IL_0160: Expected I, but got O
		Canvas canvas = UIHelper.Canvas;
		Transform parent = canvas.transform;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		Transform transform = safeAreaObject.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		object obj = Transform.GetSiblingIndex_Injected(((UnityEngine.Object)transform).m_CachedPtr);
		Transform transform2 = _teleportFader.transform;
		transform2.SetParent(parent, worldPositionStays: true);
		Transform transform3 = _teleportFader.transform;
		int siblingIndex = obj - 1;
		transform3.SetSiblingIndex(siblingIndex);
		Transform transform4 = _teleportFader.transform;
		bool flag2 = (object)transform4 == null;
		bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value);
		bool flag4 = (object)_teleportFader == null;
		Transform transform5 = _teleportFader.transform;
		bool flag5 = (object)transform5 == null;
		bool flag6 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value2);
		bool flag7 = (object)_teleportFader == null;
		RectTransform component = _teleportFader.GetComponent<RectTransform>();
		Vector2 vector = default(Vector2);
		component.anchorMax = vector;
		component.anchorMin = vector;
		component.sizeDelta = vector;
		_teleportFader.SetFadeProgress(0f);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		nint num = (nint)tilingTileset._003CListOfTeleporters_003Ek__BackingField;
		List<PickupTeleporter>.Enumerator enumerator = default(List<PickupTeleporter>.Enumerator);
		while (enumerator.MoveNext())
		{
			Pickup_EME_Teleporter pickup_EME_Teleporter = null;
			Pickup_EME_Teleporter pickup_EME_Teleporter2 = null;
			if ((object)pickup_EME_Teleporter2 != null && ((UnityEngine.Object)pickup_EME_Teleporter2).m_CachedPtr != (IntPtr)0)
			{
				pickup_EME_Teleporter2.Init(_teleportFader);
			}
		}
	}

	private void SetupBiomeNameUi()
	{
		//IL_022b: Expected O, but got I4
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected I4, but got Unknown
		//IL_01a6: Expected O, but got I
		//IL_0356: Expected O, but got I
		//IL_0370: Expected O, but got I
		//IL_0245->IL01ef: Incompatible stack heights: 1 vs 0
		//IL_00b4->IL01ef: Incompatible stack heights: 1 vs 0
		//IL_00e5->IL01ef: Incompatible stack heights: 1 vs 0
		//IL_0111->IL01ef: Incompatible stack heights: 1 vs 0
		//IL_014b->IL01ef: Incompatible stack heights: 1 vs 0
		//IL_033c->IL01ef: Incompatible stack heights: 7 vs 0
		//IL_0394->IL01ef: Incompatible stack heights: 7 vs 0
		//IL_01d6->IL01ef: Incompatible stack heights: 7 vs 0
		Canvas canvas = UIHelper.Canvas;
		if ((object)canvas != null)
		{
			Transform parent = canvas.transform;
			if ((object)_teleportFader != null)
			{
				Transform transform = _teleportFader.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform transform2 = (Transform)Transform.GetSiblingIndex_Injected(((UnityEngine.Object)transform).m_CachedPtr);
					if ((object)_biomeNameUi != null)
					{
						Transform transform3 = _biomeNameUi.transform;
						if ((object)transform3 != null)
						{
							transform3.SetParent(parent, worldPositionStays: true);
							if ((object)_biomeNameUi != null)
							{
								Transform transform4 = _biomeNameUi.transform;
								if ((object)transform4 != null)
								{
									int siblingIndex = transform2 + 1;
									transform4.SetSiblingIndex(siblingIndex);
									if ((object)_biomeNameUi != null)
									{
										Transform transform5 = _biomeNameUi.transform;
										bool flag2 = (object)transform5 == null;
										bool flag3 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value);
										bool flag4 = (object)_biomeNameUi == null;
										Transform transform6 = _biomeNameUi.transform;
										bool flag5 = (object)transform6 == null;
										bool flag6 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
										Vector3 value2 = default(Vector3);
										Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value2);
										Transform biomeNameUi = (Transform)(object)_biomeNameUi;
										bool flag7 = (object)_biomeNameUi == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rbx_v14 (UnityEngine.Transform)+20]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rbx_v14 (UnityEngine.Transform)+20]");
											Vector2 vector = default(Vector2);
											((RectTransform)0).anchorMax = vector;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rbx_v14 (UnityEngine.Transform)+20]");
											((RectTransform)0).anchorMin = vector;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rbx_v14 (UnityEngine.Transform)+20]");
											((RectTransform)0).sizeDelta = vector;
											EME_BiomeNameUI biomeNameUi2 = _biomeNameUi;
											if ((object)_biomeNameUi != null)
											{
												biomeNameUi2._currentState = EME_BiomeNameUI.ShowState.Hidden;
												if ((object)biomeNameUi2._canvasGroup != null)
												{
													biomeNameUi2._canvasGroup.alpha = 0f;
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
		throw new NullReferenceException();
	}

	private unsafe void CreateBossPizzas()
	{
		//IL_00a5: Expected O, but got Ref
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("BossSpawn");
		List<SuperObject>.Enumerator enumerator = default(List<SuperObject>.Enumerator);
		if (scriptsFromName != null && scriptsFromName._size > 0 && enumerator.MoveNext())
		{
			List<SuperObject>.Enumerator enumerator2 = (List<SuperObject>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private unsafe void CheckBossPizzas()
	{
		//IL_0038: Expected O, but got Ref
		//IL_0062: Expected O, but got Ref
		//IL_0288: Expected O, but got I4
		//IL_0436: Expected I4, but got F4
		_003C_003Ec__DisplayClass59_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass59_0();
		CS_0024_003C_003E8__locals20.triggered = null;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator enumerator3 = default(Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator);
		System.Int32Enum key;
		SoundManager.SoundConfig soundConfig2 = default(SoundManager.SoundConfig);
		SoundManager.SoundConfig triggered4;
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			bool flag = _bossPizzas == null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			if (flag)
			{
				throw new NullReferenceException();
			}
			if (enumerator3.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				SoundManager.SoundConfig soundConfig = null;
				Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator enumerator4 = (Dictionary<EmeraldsBiomes, PizzaCircle>.Enumerator)(&enumerator3);
				throw new NullReferenceException();
			}
			key = (System.Int32Enum)6;
			PizzaCircle triggered = CS_0024_003C_003E8__locals20.triggered;
			if ((object)CS_0024_003C_003E8__locals20.triggered == null || ((UnityEngine.Object)triggered).m_CachedPtr == (IntPtr)0)
			{
				continue;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				PizzaCircle triggered2 = CS_0024_003C_003E8__locals20.triggered;
				if ((object)CS_0024_003C_003E8__locals20.triggered != null)
				{
					bool flag2 = !((SoundManager.SoundConfig)(object)triggered2).Mute;
					object triggered3 = CS_0024_003C_003E8__locals20.triggered;
					if (!flag2)
					{
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)(((SoundManager.SoundConfig)(object)triggered2).Mute ? 1 : 0));
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						bool flag3 = (object)transform == null;
						triggered4 = (SoundManager.SoundConfig)(object)CS_0024_003C_003E8__locals20.triggered;
						if (!flag3)
						{
							Vector3 position = transform.position;
							bool flag4 = (object)core._stage == null;
							triggered4 = (SoundManager.SoundConfig)(object)CS_0024_003C_003E8__locals20.triggered;
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
		bool flag5 = (object)CS_0024_003C_003E8__locals20.triggered == null;
		triggered4 = soundConfig2;
		if (!flag5)
		{
			CS_0024_003C_003E8__locals20.triggered.ShowFinalWarning();
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Rate = 1f;
			soundConfig3.Volume = (float?)(object)1;
			float value = UnityEngine.Random.value;
			float detune = value * 500f;
			soundConfig3.Detune = detune;
			soundConfig3.Rate = 1f;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig3, 150f, 2, num);
			bool flag6 = (object)CS_0024_003C_003E8__locals20.triggered == null;
			triggered4 = soundConfig3;
			if (!flag6)
			{
				CS_0024_003C_003E8__locals20.triggered.CleanUp();
				bool flag7 = _bossPizzas == null;
				triggered4 = soundConfig3;
				if (!flag7)
				{
					int num2 = ((Dictionary<System.Int32Enum, object>)(object)_bossPizzas).FindEntry(key);
					if (!flag7)
					{
						bool flag8 = _bossPizzas == null;
						triggered4 = soundConfig3;
						if (flag8)
						{
							throw new NullReferenceException();
						}
						bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)_bossPizzas).Remove(key);
					}
					Action onComplete = CS_0024_003C_003E8__locals20._003C_003E9__0;
					if (CS_0024_003C_003E8__locals20._003C_003E9__0 == null)
					{
						onComplete = (CS_0024_003C_003E8__locals20._003C_003E9__0 = delegate
						{
							PizzaCircle triggered5 = CS_0024_003C_003E8__locals20.triggered;
							if ((object)CS_0024_003C_003E8__locals20.triggered != null && ((UnityEngine.Object)triggered5).m_CachedPtr != (IntPtr)0)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals20.triggered.gameObject;
								if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
								{
									GameObject obj;
									if ((object)CS_0024_003C_003E8__locals20.triggered != null)
									{
										GameObject gameObject2 = CS_0024_003C_003E8__locals20.triggered.gameObject;
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

	public void DebugTeleportToNextBiome()
	{
		//IL_0013: Expected I, but got O
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007b: Expected O, but got I
		nint num = (nint)typeof(EmeraldsBiomes);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v136 @ rdx_v4+8F8] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497AD0");
			IEnumerable<int> source = default(IEnumerable<int>);
			int num2 = Enumerable.Max(source);
			if ((int)_003CCurrentBiome_003Ek__BackingField < num2)
			{
				DisablePositionLimitingOnTeleportStart();
				EmeraldsBiomes emeraldsBiomes = _003CCurrentBiome_003Ek__BackingField + 1;
				_003CCurrentBiome_003Ek__BackingField = emeraldsBiomes;
				SetBiomeDifficulty();
				DebugTeleportToBiomeEntrance();
			}
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
	}

	public void DebugTeleportToPreviousBiome()
	{
		//IL_0013: Expected I, but got O
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007b: Expected O, but got I
		nint num = (nint)typeof(EmeraldsBiomes);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v136 @ rdx_v4+8F8] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497AD0");
			IEnumerable<int> source = default(IEnumerable<int>);
			int num2 = Enumerable.Min(source);
			if ((int)_003CCurrentBiome_003Ek__BackingField > num2)
			{
				DisablePositionLimitingOnTeleportStart();
				EmeraldsBiomes emeraldsBiomes = _003CCurrentBiome_003Ek__BackingField - 1;
				_003CCurrentBiome_003Ek__BackingField = emeraldsBiomes;
				SetBiomeDifficulty();
				DebugTeleportToBiomeEntrance();
			}
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
	}

	private void DebugTeleportToBiomeEntrance()
	{
		EME_BiomeBounds.EmeraldsBiomeBounds boundsForBiome = _biomeBounds.GetBoundsForBiome(_003CCurrentBiome_003Ek__BackingField);
		float2 float5 = default(float2);
		bool focusCameraOnPlayer = default(bool);
		GM.Core.TeleportPlayers(float5, float5, centered: false, focusCameraOnPlayer);
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		if (mainCharacters._size > 0)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
			ActivateBiome(items[0], _003CCurrentBiome_003Ek__BackingField);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void DebugEnableAllTwoWayTeleporters()
	{
		//IL_0049: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		List<PickupTeleporter>.Enumerator enumerator = (List<PickupTeleporter>.Enumerator)tilingTileset._003CListOfTeleporters_003Ek__BackingField;
		List<PickupTeleporter>.Enumerator enumerator2 = default(List<PickupTeleporter>.Enumerator);
		while (enumerator2.MoveNext())
		{
			object obj = 0;
		}
	}

	public unsafe override void Cleanup()
	{
		//IL_0094: Expected O, but got I4
		//IL_009c: Expected O, but got Ref
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				List<PickupTeleporter>.Enumerator enumerator = default(List<PickupTeleporter>.Enumerator);
				if ((object)stage._tilingTileset != null && tilingTileset._003CListOfTeleporters_003Ek__BackingField != null && enumerator.MoveNext())
				{
					object obj = 0;
					List<PickupTeleporter>.Enumerator enumerator2 = (List<PickupTeleporter>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				EME_TeleportFader teleportFader = _teleportFader;
				if ((object)_teleportFader == null || ((UnityEngine.Object)teleportFader).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if ((object)_teleportFader != null)
				{
					GameObject obj2 = _teleportFader.gameObject;
					UnityEngine.Object.Destroy(obj2, 0f);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Log(string message, GameObject debugGameObject = null)
	{
		//IL_0026: Expected O, but got I4
		//IL_0050: Expected O, but got Ref
		object obj = Time.frameCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, message);
		object obj2 = default(object);
		string message2 = string.FormatHelper((IFormatProvider)null, "[BackgroundEmerald] {0} | {1}", (System.ParamsArray)(&obj2));
		Debug.Log(message2, debugGameObject);
	}

	public override string GetDetailedMapStaticBackgroundImage(StageData stageData)
	{
		//IL_001a: Expected O, but got I4
		bool flag = SpriteLoader.LoadTexture("eme_map_static_background", "Gameplay", (DlcType?)(object)1);
		return "eme_map_static_background";
	}

	public override string GetDetailedMap(StageData stageData)
	{
		//IL_0016: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 63 Invalid \"Jump target not found in method: 0x186F5AD7E\"");
		return (string)_003CCurrentBiome_003Ek__BackingField;
	}

	public override float GetMap_SizeX()
	{
		return 20.48f;
	}

	public override float GetMap_SizeY()
	{
		return 22.4f;
	}

	public override int GetMap_SupportHorizontal()
	{
		bool flag = _003CCurrentBiome_003Ek__BackingField == EmeraldsBiomes.Junction;
		int result = 0;
		if (!flag)
		{
			result = 4;
		}
		return result;
	}

	public override float2 GetMap_PlayerPos()
	{
		//IL_00e3: Expected O, but got I
		//IL_0115: Expected O, but got I
		//IL_00a6: Expected O, but got I4
		//IL_0310: Expected I, but got O
		//IL_026a: Expected O, but got I4
		//IL_046c->IL03b0: Incompatible stack heights: 1 vs 0
		//IL_04b0->IL0405: Incompatible stack heights: 2 vs 0
		//IL_052c->IL03b0: Incompatible stack heights: 1 vs 0
		//IL_03b0->IL0531: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		ArcadeSprite arcadeSprite;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				OnlineStageManager core2 = (OnlineStageManager)(object)GM.Core;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v15 (VampireSurvivors.OnlineStageManager)+E0]");
					OnlineStageManager onlineStageManager = (OnlineStageManager)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v15 (VampireSurvivors.OnlineStageManager)+E0]");
					if ((nint)0 != 0)
					{
						arcadeSprite = (ArcadeSprite)(nint)((UnityEngine.Object)onlineStageManager).m_CachedPtr;
						goto IL_03e3;
					}
				}
			}
			else if ((object)OnlineStageManager._instance != null)
			{
				int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
				if ((object)OnlineStageManager._instance != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterForSeatNumber = OnlineStageManager._instance.GetCharacterForSeatNumber(mySeatNumber);
					arcadeSprite = characterForSeatNumber;
					object obj = 0;
					goto IL_03e3;
				}
			}
		}
		goto IL_03b0;
		IL_0405:
		float2 result = default(float2);
		return result;
		IL_03e3:
		Vector3 ret2;
		ArcadeSprite arcadeSprite2;
		if (_003CCurrentBiome_003Ek__BackingField == EmeraldsBiomes.Junction)
		{
			if ((object)arcadeSprite != null)
			{
				float2 position = arcadeSprite.position;
				if (!IsStageInverted)
				{
					float map_SizeY = GetMap_SizeY();
					goto IL_0405;
				}
				Transform transform = arcadeSprite.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v63 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v63 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					OnlineStageManager junctionSpawnTransform = (OnlineStageManager)(object)_junctionSpawnTransform;
					if ((object)_junctionSpawnTransform != null)
					{
						bool flag2 = ((UnityEngine.Object)junctionSpawnTransform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)junctionSpawnTransform).m_CachedPtr, out ret2);
						float map_SizeY2 = GetMap_SizeY();
						goto IL_0405;
					}
				}
			}
		}
		else
		{
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null && core3._multiplayer != null)
			{
				if (!core3._multiplayer.IsOnlineMultiplayer)
				{
					GameManager core4 = GM.Core;
					if ((object)GM.Core != null)
					{
						GameSessionData gameSessionData = core4._gameSessionData;
						if (core4._gameSessionData != null)
						{
							arcadeSprite2 = gameSessionData._activeCharacter;
							if ((object)gameSessionData._activeCharacter != null)
							{
								goto IL_02fe;
							}
						}
					}
				}
				else if ((object)OnlineStageManager._instance != null)
				{
					int mySeatNumber2 = OnlineStageManager._instance.GetMySeatNumber();
					if ((object)OnlineStageManager._instance != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterForSeatNumber2 = OnlineStageManager._instance.GetCharacterForSeatNumber(mySeatNumber2);
						if ((object)characterForSeatNumber2 != null)
						{
							object obj = 0;
							arcadeSprite2 = characterForSeatNumber2;
							goto IL_02fe;
						}
					}
				}
			}
		}
		goto IL_03b0;
		IL_03b0:
		throw new NullReferenceException();
		IL_02fe:
		float2 position2 = arcadeSprite2.position;
		nint num = (nint)this;
		float map_SizeX = GetMap_SizeX();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float map_SizeY3 = GetMap_SizeY();
		if ((object)arcadeSprite != null)
		{
			Transform transform2 = arcadeSprite.transform;
			if ((object)transform2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v35 (UnityEngine.Transform)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v35 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret2);
				if ((object)_biomeBounds != null)
				{
					EME_BiomeBounds.EmeraldsBiomeBounds boundsForBiome = _biomeBounds.GetBoundsForBiome(_003CCurrentBiome_003Ek__BackingField);
					float map_SizeY4 = GetMap_SizeY();
					return result;
				}
			}
		}
		goto IL_03b0;
	}

	public override bool GetMap_DrawGrid()
	{
		return false;
	}

	public BackgroundEmerald()
	{
		Dictionary<EmeraldsBiomes, PizzaCircle> bossPizzas = new Dictionary<EmeraldsBiomes, PizzaCircle>();
		_bossPizzas = bossPizzas;
		_biomeToJunctionTeleporterLookup = new Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>();
		_junctionToBiomeTeleporterLookup = new Dictionary<EmeraldsBiomes, Pickup_EME_Teleporter>();
		_localizedBiomeNamesLookup = new Dictionary<EmeraldsBiomes, string>();
		base._002Ector();
	}

	private void _003CSetupTeleporter_003Eb__50_0(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		ActivateBiome(player, EmeraldsBiomes.Junction);
	}
}
