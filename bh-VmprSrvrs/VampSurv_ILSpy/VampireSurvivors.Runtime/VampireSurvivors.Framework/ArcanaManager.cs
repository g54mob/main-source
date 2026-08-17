using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Framework;

public class ArcanaManager : GameTickable, IInitializable, IDisposable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__152_2;

		public static Action _003C_003E9__152_3;

		public static Action _003C_003E9__152_4;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CGatherAllStageItems_003Eb__152_2()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = 200f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, time);
		}

		internal void _003CGatherAllStageItems_003Eb__152_3()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = 600f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, time);
		}

		internal void _003CGatherAllStageItems_003Eb__152_4()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = 1000f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, time);
		}
	}

	private sealed class _003C_003Ec__DisplayClass130_0
	{
		public Weapon weapon;

		internal void _003COnWeaponFired_003Eb__0()
		{
			weapon.ParadoxFire();
		}
	}

	private sealed class _003C_003Ec__DisplayClass152_0
	{
		public ArcanaManager _003C_003E4__this;

		public ItemType[] validItems;

		internal void _003CGatherAllStageItems_003Eb__0()
		{
			ArcanaManager arcanaManager = _003C_003E4__this;
			arcanaManager._003CCanGather_003Ek__BackingField = true;
		}

		internal bool _003CGatherAllStageItems_003Eb__1(Pickup i)
		{
			//IL_012f: Expected I4, but got O
			//IL_0013: Expected I, but got O
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			//IL_0067: Expected O, but got I
			//IL_009d: Expected O, but got I4
			if ((object)i == null)
			{
				goto IL_0121;
			}
			nint num = (nint)typeof(NetworkPickup);
			nint num2 = (nint)i;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v2 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v2 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v13+FFFFFFF8+v52 @ rax_v4*8]");
				if (0 == (nint)typeof(NetworkPickup))
				{
					obj3 = 1;
					goto IL_014c;
				}
			}
			obj3 = 0;
			goto IL_014c;
			IL_0121:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_014c:
			bool flag = obj3 == null;
			Pickup pickup = null;
			if (!flag)
			{
				pickup = i;
			}
			bool flag2 = Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)validItems, (System.Int32Enum)i._003CPickupType_003Ek__BackingField);
			if (!flag2)
			{
				return flag2;
			}
			if ((object)GM.Core != null)
			{
				if (GM.Core.IsStageHost)
				{
					return true;
				}
				return (object)pickup == null;
			}
			goto IL_0121;
		}
	}

	private sealed class _003C_003Ec__DisplayClass154_0
	{
		public PickupWeapon element;

		internal void _003CGatherStageItemsForPosition_003Eb__0()
		{
			PickupWeapon pickupWeapon = element;
			((Pickup)pickupWeapon)._003CDisableGet_003Ek__BackingField = true;
			PickupWeapon pickupWeapon2 = element;
			if (pickupWeapon2._floatTween != null)
			{
				TweenExtensions.Kill(pickupWeapon2._floatTween);
			}
		}

		internal void _003CGatherStageItemsForPosition_003Eb__1()
		{
			//IL_004f: Expected O, but got I4
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			//IL_007b: Expected O, but got I4
			PickupWeapon pickupWeapon = element;
			((Pickup)pickupWeapon)._003CDisableGet_003Ek__BackingField = false;
			element.ResumeFloat();
			PickupWeapon pickupWeapon2 = element;
			object obj = pickupWeapon2._weaponType - 67;
			object obj2 = obj & 0xFFFFFFFAL;
			bool flag = obj2 == null;
			object obj3 = !flag;
			if ((obj3 == null && pickupWeapon2._weaponType != WeaponType.RIGHT) || pickupWeapon2._weaponType == WeaponType.RIGHT)
			{
				pickupWeapon2._triggerOnGet = true;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass154_1
	{
		public Pickup element;

		internal void _003CGatherStageItemsForPosition_003Eb__2()
		{
			Pickup pickup = element;
			pickup._003CDisableGet_003Ek__BackingField = true;
		}

		internal void _003CGatherStageItemsForPosition_003Eb__3()
		{
			Pickup pickup = element;
			pickup._003CDisableGet_003Ek__BackingField = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass154_2
	{
		public Pickup element;

		internal void _003CGatherStageItemsForPosition_003Eb__4()
		{
			Pickup pickup = element;
			pickup._003CDisableGet_003Ek__BackingField = true;
		}

		internal void _003CGatherStageItemsForPosition_003Eb__5()
		{
			Pickup pickup = element;
			pickup._003CDisableGet_003Ek__BackingField = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass154_3
	{
		public Pickup element;

		internal void _003CGatherStageItemsForPosition_003Eb__6()
		{
			Pickup pickup = element;
			pickup._003CDisableGet_003Ek__BackingField = true;
		}

		internal void _003CGatherStageItemsForPosition_003Eb__7()
		{
			Pickup pickup = element;
			pickup._003CDisableGet_003Ek__BackingField = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass155_0
	{
		public Destructible d;

		internal void _003CGatherAllDestructibles_003Eb__0()
		{
			d.UpdateLightPosition();
		}
	}

	private GameSessionData _gameSessionData;

	private PlayerOptions _playerOptions;

	private WeaponsFacade _weaponsFacade;

	private DataManager _dataManager;

	private SignalBus _signalBus;

	private GameManager _gameManager;

	private LootManager _lootManager;

	private SarabandeWeapon _sarabandeWeapon;

	private FireExplosionWeapon _fireExplosionWeapon;

	private ColdExplosionWeapon _coldExplosionWeapon;

	private GemCannonWeapon _gemCannonWeapon;

	private DivineBloodlineWeapon _divineBloodlineWeapon;

	private WickedSeason _wickedSeason;

	private BloodAstronomiaWeapon _bloodAstronomiaWeapon;

	private JetBlackWeapon _jetBlackWeapon;

	private MadMoonWeapon _madMoonWeapon;

	private bool _hasWickedSeason;

	private bool _hasSilentSanctuary;

	private bool _hasAstronomia;

	private bool _hasSapphireMist;

	private bool _hasBreadAnathema;

	private bool _hasMoonlightBolero;

	private bool _hasHailFromTheFuture;

	private bool _hasJetBlackWeapon;

	private bool _hasCrystalCries;

	private bool _hasMadMoon;

	private bool _hasVictorianHorror;

	private float _003CSilentCooldown_003Ek__BackingField;

	private float _003CSilentMight_003Ek__BackingField;

	private float _heartOfFireStartingPower = 1f;

	private readonly Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<WeaponType>> _beginning;

	public static float CritMul = 1f;

	public static float ThornsValue = 0f;

	private List<ArcanaType> _003CActiveArcanas_003Ek__BackingField;

	private bool _003CHealOnCoins_003Ek__BackingField;

	private bool _003CCoinFever_003Ek__BackingField;

	private bool _003CMadGroove_003Ek__BackingField;

	private bool _003CCanGather_003Ek__BackingField;

	private List<WeaponType> _003CHeartOfFireWeapons_003Ek__BackingField;

	private float _003CXpMultiplier_003Ek__BackingField;

	private float _003CDivineBloodlineHpBonusUnit_003Ek__BackingField;

	private bool _003CHasDivineBloodline_003Ek__BackingField;

	private int _003CMinTreasureChestLevel_003Ek__BackingField;

	private bool _003CPewPew_003Ek__BackingField;

	private int _003CMaxArcanasPerRun_003Ek__BackingField;

	private List<Destructible> m_newDestructibles;

	private ArcanaManager_VFX arcanaManager_VFX;

	private ArcanaManager_Support arcanaManager_Support;

	public SarabandeWeapon SarabandeWeapon => _sarabandeWeapon;

	public float SilentCooldown
	{
		get
		{
			return _003CSilentCooldown_003Ek__BackingField;
		}
		private set
		{
			_003CSilentCooldown_003Ek__BackingField = value;
		}
	}

	public float SilentMight
	{
		get
		{
			return _003CSilentMight_003Ek__BackingField;
		}
		private set
		{
			_003CSilentMight_003Ek__BackingField = value;
		}
	}

	public ArcanaManager_Support ArcaneManagerSupport => arcanaManager_Support;

	public List<ArcanaType> ActiveArcanas
	{
		get
		{
			return _003CActiveArcanas_003Ek__BackingField;
		}
		private set
		{
			_003CActiveArcanas_003Ek__BackingField = value;
		}
	}

	private bool HealOnCoins
	{
		get
		{
			return _003CHealOnCoins_003Ek__BackingField;
		}
		set
		{
			_003CHealOnCoins_003Ek__BackingField = value;
		}
	}

	public bool CoinFever
	{
		get
		{
			return _003CCoinFever_003Ek__BackingField;
		}
		private set
		{
			_003CCoinFever_003Ek__BackingField = value;
		}
	}

	public bool MadGroove
	{
		get
		{
			return _003CMadGroove_003Ek__BackingField;
		}
		private set
		{
			_003CMadGroove_003Ek__BackingField = value;
		}
	}

	private bool CanGather
	{
		get
		{
			return _003CCanGather_003Ek__BackingField;
		}
		set
		{
			_003CCanGather_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> HeartOfFireWeapons
	{
		get
		{
			return _003CHeartOfFireWeapons_003Ek__BackingField;
		}
		private set
		{
			_003CHeartOfFireWeapons_003Ek__BackingField = value;
		}
	}

	public FireExplosionWeapon FireExplosionWeapon => _fireExplosionWeapon;

	private VampireSurvivors.Objects.Characters.CharacterController ActivePlayer
	{
		get
		{
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null)
			{
				return gameSessionData._activeCharacter;
			}
			return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
		}
	}

	public WickedSeason WickedSeason => _wickedSeason;

	public float XpMultiplier
	{
		get
		{
			return _003CXpMultiplier_003Ek__BackingField;
		}
		set
		{
			_003CXpMultiplier_003Ek__BackingField = value;
		}
	}

	public float DivineBloodlineHpBonusUnit
	{
		get
		{
			return _003CDivineBloodlineHpBonusUnit_003Ek__BackingField;
		}
		set
		{
			_003CDivineBloodlineHpBonusUnit_003Ek__BackingField = value;
		}
	}

	public bool HasDivineBloodline
	{
		get
		{
			return _003CHasDivineBloodline_003Ek__BackingField;
		}
		set
		{
			_003CHasDivineBloodline_003Ek__BackingField = value;
		}
	}

	public bool HasAstronomia => _hasAstronomia;

	public bool HasMoonlightBolero => _hasMoonlightBolero;

	public bool HasHailFromTheFuture => _hasHailFromTheFuture;

	public bool HasSapphireMist => _hasSapphireMist;

	public bool HasCrystalCries => _hasCrystalCries;

	public bool HasBreadAnathema => _hasBreadAnathema;

	public bool HasMadMoon => _hasMadMoon;

	public bool HasVictorianHorror => _hasVictorianHorror;

	public int MinTreasureChestLevel
	{
		get
		{
			return _003CMinTreasureChestLevel_003Ek__BackingField;
		}
		set
		{
			_003CMinTreasureChestLevel_003Ek__BackingField = value;
		}
	}

	public bool PewPew
	{
		get
		{
			return _003CPewPew_003Ek__BackingField;
		}
		set
		{
			_003CPewPew_003Ek__BackingField = value;
		}
	}

	public int MaxArcanasPerRun
	{
		get
		{
			return _003CMaxArcanasPerRun_003Ek__BackingField;
		}
		set
		{
			_003CMaxArcanasPerRun_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> Beginning(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		if (_beginning != null)
		{
			int num = _beginning.FindEntry(player);
			if (num < 0)
			{
				List<WeaponType> value = new List<WeaponType>();
				if (_beginning == null)
				{
					goto IL_00be;
				}
				bool flag = ((Dictionary<object, object>)(object)_beginning).TryInsert((object)player, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			if (_beginning != null)
			{
				return _beginning.get_Item(player);
			}
		}
		goto IL_00be;
		IL_00be:
		return (List<WeaponType>)(object)new NullReferenceException();
	}

	public void Initialize()
	{
		//IL_00d0: Expected O, but got I4
		//IL_00d0: Expected O, but got I
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_01b7: Expected O, but got I
		List<ArcanaType> list = new List<ArcanaType>();
		_003CActiveArcanas_003Ek__BackingField = list;
		CritMul = 1f;
		_003CHealOnCoins_003Ek__BackingField = false;
		_hasWickedSeason = false;
		_hasAstronomia = false;
		_003CMaxArcanasPerRun_003Ek__BackingField = 3;
		if (_wickedSeason == null)
		{
			WickedSeason wickedSeason = new WickedSeason();
			_wickedSeason = wickedSeason;
			WickedSeason wickedSeason2 = _wickedSeason;
			wickedSeason2._signalBus = _signalBus;
		}
		Action<GameplaySignals.OnAfterCoinsAddedSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB43E0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v5 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OnAfterCoinsAddedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OnAfterCoinsAddedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v19 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = Cleanup;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4420");
		InitializeVFX();
	}

	public void Dispose()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<GameplaySignals.OnAfterCoinsAddedSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB43E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action action = Cleanup;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA45A0");
	}

	protected override void OnTick()
	{
		//IL_00e8: Expected I, but got O
		//IL_0141: Invalid comparison between F4 and I4
		//IL_0040: Expected I, but got O
		//IL_0332->IL02de: Incompatible stack heights: 1 vs 0
		ColdExplosionWeapon coldExplosionWeapon = _coldExplosionWeapon;
		if ((object)_coldExplosionWeapon != null && ((UnityEngine.Object)coldExplosionWeapon).m_CachedPtr != (IntPtr)0)
		{
			nint num = (nint)_coldExplosionWeapon;
			if ((object)_coldExplosionWeapon != null)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v6 (Il2CppMethodInfo)+88]");
					if ((nint)0 != 0)
					{
						float num2 = core._003CSurvivedSeconds_003Ek__BackingField / 300f;
						float num3 = num2 + 1f;
						goto IL_02bf;
					}
				}
			}
			goto IL_0285;
		}
		goto IL_02bf;
		IL_0285:
		throw new NullReferenceException();
		IL_02de:
		if (arcanaManager_Support != null)
		{
			arcanaManager_Support.Update();
		}
		return;
		IL_02bf:
		if (_003CMadGroove_003Ek__BackingField)
		{
			nint num4 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v28 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num5 = 0;
			GameManager core2 = GM.Core;
			if ((object)GM.Core == null)
			{
				goto IL_0285;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877C2183h\"");
			if (core2._003CSurvivedSeconds_003Ek__BackingField == 0f)
			{
				GatherAllStageItems();
			}
		}
		if (_hasWickedSeason && _wickedSeason != null)
		{
			_wickedSeason.Update();
		}
		ArcanaManager_VFX arcanaManager_VFX = this.arcanaManager_VFX;
		if (this.arcanaManager_VFX != null)
		{
			if (!arcanaManager_VFX._SapphireMist_Ready)
			{
				goto IL_02de;
			}
			if ((object)arcanaManager_VFX._SapphireMist_well != null)
			{
				Transform transform = arcanaManager_VFX._SapphireMist_well.transform;
				if ((object)arcanaManager_VFX._SapphireMist_LastUser != null)
				{
					float2 cachedPosition = arcanaManager_VFX._SapphireMist_LastUser.cachedPosition;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					goto IL_02de;
				}
			}
		}
		goto IL_0285;
	}

	public void OnGameManagerInitialization()
	{
		InitializeSupportObjects();
	}

	public void InitializeVFX()
	{
		if (this.arcanaManager_VFX == null)
		{
			ArcanaManager_VFX arcanaManager_VFX = new ArcanaManager_VFX();
			this.arcanaManager_VFX = arcanaManager_VFX;
		}
	}

	public void InitializeSupportObjects()
	{
		InitializeVFX();
		if (this.arcanaManager_Support == null)
		{
			ArcanaManager_Support arcanaManager_Support = new ArcanaManager_Support();
			this.arcanaManager_Support = arcanaManager_Support;
			ArcanaManager_Support arcanaManager_Support2 = this.arcanaManager_Support;
			List<float> sapphireMistChances = Weapon.MakeChanceArray(1000);
			arcanaManager_Support2._sapphireMistChances = sapphireMistChances;
			arcanaManager_Support2._baseCandyboxChance = 0.05f;
			arcanaManager_Support2._sapphireMistIndex = 0;
			List<float> hailFromFutureChances = Weapon.MakeChanceArray(1000);
			arcanaManager_Support2._hailFromFutureChances = hailFromFutureChances;
			arcanaManager_Support2._hailFromFutureIndex = 0;
			arcanaManager_Support2.MakeHailFromTheFutureWeightedStore();
		}
	}

	public void TriggerArcana(ArcanaType arcanaType)
	{
		//IL_0085: Expected O, but got I4
		//IL_0028: Expected O, but got I8
		//IL_0042: Expected O, but got I8
		InitializeSupportObjects();
		object obj = arcanaType + 1;
		object actualValue = default(object);
		if ((nint)obj <= 44)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v2+77C499C+v66 @ rax_v5*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v86 @ rax_v16 (should have been resolved before IL gen)");
		}
		else
		{
			ArcanaType arcanaType2 = default(ArcanaType);
			actualValue = arcanaType2;
		}
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("arcanaType", actualValue, null);
		throw ex;
	}

	public unsafe void CheckSilent()
	{
		//IL_025f: Expected O, but got I4
		//IL_0267: Expected O, but got Ref
		//IL_0042: Expected O, but got I4
		//IL_004a: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6598]");
		bool flag = (nint)0 != 0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (_hasSilentSanctuary)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
		else if (enumerator3.MoveNext())
		{
			object obj2 = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator4 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
	}

	public void TriggerAwake(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_032b: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		bool flag = character._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = character._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = character._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 == null)
		{
			PlayerModifierStats playerStats = character._playerStats;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float num3 = character.MaxHp();
			object obj3 = default(object);
			float num4 = (float)obj3 * 0.1f;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = num4 + eggFloat._val;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = character._playerStats;
			EggFloat eggFloat3 = playerStats2._003CArmor_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + 1f;
			playerStats2._003CArmor_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = character._playerStats;
			EggFloat eggFloat5 = playerStats3._003CPower_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val + 0.05f;
			playerStats3._003CPower_003Ek__BackingField = eggFloat6;
			PlayerModifierStats playerStats4 = character._playerStats;
			EggFloat eggFloat7 = playerStats4._003CArea_003Ek__BackingField;
			float value4 = default(float);
			EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
			value4 = eggFloat7._val + 0.05f;
			playerStats4._003CArea_003Ek__BackingField = eggFloat8;
			PlayerModifierStats playerStats5 = character._playerStats;
			EggFloat eggFloat9 = playerStats5._003CDuration_003Ek__BackingField;
			float value5 = default(float);
			EggFloat eggFloat10 = new EggFloat(value5, eggFloat9._eggVal);
			value5 = eggFloat9._val + 0.05f;
			playerStats5._003CDuration_003Ek__BackingField = eggFloat10;
			PlayerModifierStats playerStats6 = character._playerStats;
			EggFloat eggFloat11 = playerStats6._003CSpeed_003Ek__BackingField;
			float value6 = default(float);
			EggFloat eggFloat12 = new EggFloat(value6, eggFloat11._eggVal);
			value6 = eggFloat11._val + 0.05f;
			playerStats6._003CSpeed_003Ek__BackingField = eggFloat12;
		}
	}

	public void TriggerSarabande(float damage, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_02f6: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_0173: Expected I, but got O
		//IL_0183: Expected O, but got I
		//IL_01fd: Expected O, but got I4
		//IL_01ef: Expected O, but got I4
		//IL_0275: Expected O, but got I4
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
		if (obj2 != null)
		{
			return;
		}
		SarabandeWeapon sarabandeWeapon = _sarabandeWeapon;
		if ((object)_sarabandeWeapon == null || ((UnityEngine.Object)sarabandeWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		Weapon weaponByType;
		object obj4;
		if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer)
		{
			weaponByType = player._weaponsManager.GetWeaponByType(WeaponType.SARABANDE, searchHidden: true);
			if ((object)weaponByType != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = (VampireSurvivors.Objects.Characters.CharacterController)(object)weaponByType;
				nint num3 = (nint)typeof(SarabandeWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.SarabandeWeapon>)+130]");
				object obj3 = 0;
				WeaponType startingWeaponType = characterController._startingWeaponType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.SarabandeWeapon>)+130]");
				if ((nint)startingWeaponType >= (nint)0)
				{
					CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v35 (VampireSurvivors.Objects.CharacterAccessoriesManager)+FFFFFFF8+v464 @ rax_v31*8]");
					if (0 == (nint)typeof(SarabandeWeapon))
					{
						obj4 = 1;
						goto IL_032e;
					}
				}
				obj4 = 0;
				goto IL_032e;
			}
			sarabandeWeapon = null;
		}
		goto IL_0355;
		IL_0355:
		if ((object)sarabandeWeapon != null && ((UnityEngine.Object)sarabandeWeapon).m_CachedPtr != (IntPtr)0 && ((Weapon)sarabandeWeapon)._isVisible)
		{
			object obj5 = player._characterType - 220;
			bool useJuliaAttack = obj5 == null;
			float healAmount = damage * 0.1f;
			sarabandeWeapon.UseJuliaAttack = useJuliaAttack;
			sarabandeWeapon._healAmount = healAmount;
			sarabandeWeapon.Fire();
		}
		return;
		IL_032e:
		bool flag5 = obj4 == null;
		sarabandeWeapon = null;
		if (!flag5)
		{
			sarabandeWeapon = (SarabandeWeapon)weaponByType;
		}
		goto IL_0355;
	}

	public void TriggerFireExplosion(Vector2 pos)
	{
		FireExplosionWeapon fireExplosionWeapon = _fireExplosionWeapon;
		if ((object)_fireExplosionWeapon != null && ((UnityEngine.Object)fireExplosionWeapon).m_CachedPtr != (IntPtr)0)
		{
			Projectile projectile = _fireExplosionWeapon.FireOneProjectile(pos, 0);
		}
	}

	public void TriggerColdExplosion(Vector2 pos)
	{
		ColdExplosionWeapon coldExplosionWeapon = _coldExplosionWeapon;
		if ((object)_coldExplosionWeapon != null && ((UnityEngine.Object)coldExplosionWeapon).m_CachedPtr != (IntPtr)0)
		{
			ColdExplosionWeapon coldExplosionWeapon2 = _coldExplosionWeapon;
			Transform transform = ((Equipment)coldExplosionWeapon2)._003COwner_003Ek__BackingField.transform;
			Projectile projectile = coldExplosionWeapon2.FireOneProjectile(pos, 0, transform);
		}
	}

	public void TriggerGemCannon(float damage, string frameName, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0277: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_013d: Expected I, but got O
		//IL_014d: Expected O, but got I
		//IL_01cd: Expected O, but got I4
		//IL_0189: Expected O, but got I
		//IL_01bf: Expected O, but got I4
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
		if (obj2 != null)
		{
			return;
		}
		GemCannonWeapon gemCannonWeapon = _gemCannonWeapon;
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		Weapon weaponByType;
		object obj5;
		if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer)
		{
			weaponByType = player._weaponsManager.GetWeaponByType(WeaponType.WINDOW2, searchHidden: true);
			if ((object)weaponByType != null)
			{
				string text = (string)(object)weaponByType;
				nint num3 = (nint)typeof(GemCannonWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.GemCannonWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v9 (System.String)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.GemCannonWeapon>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v9 (System.String)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v34+FFFFFFF8+v363 @ rax_v30*8]");
					if (0 == (nint)typeof(GemCannonWeapon))
					{
						obj5 = 1;
						goto IL_028a;
					}
				}
				obj5 = 0;
				goto IL_028a;
			}
			gemCannonWeapon = null;
		}
		goto IL_02b1;
		IL_02b1:
		if ((object)gemCannonWeapon != null && ((UnityEngine.Object)gemCannonWeapon).m_CachedPtr != (IntPtr)0)
		{
			gemCannonWeapon._003CGemValue_003Ek__BackingField = damage;
			gemCannonWeapon._003CGemFrame_003Ek__BackingField = frameName;
			gemCannonWeapon.Fire();
		}
		return;
		IL_028a:
		bool flag5 = obj5 == null;
		gemCannonWeapon = null;
		if (!flag5)
		{
			gemCannonWeapon = (GemCannonWeapon)weaponByType;
		}
		goto IL_02b1;
	}

	public void TriggerAstronomia(Weapon weapon)
	{
		//IL_058b: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0158: Expected I, but got O
		//IL_0166: Expected I, but got O
		//IL_0176: Expected O, but got I
		//IL_01f6: Expected O, but got I4
		//IL_0146: Expected I, but got O
		//IL_01b2: Expected O, but got I
		//IL_01e8: Expected O, but got I4
		//IL_0312: Expected O, but got I4
		//IL_031f: Expected O, but got I8
		//IL_0271: Expected O, but got I4
		//IL_0356: Expected O, but got I8
		//IL_02c2: Expected O, but got I4
		//IL_03fc: Expected I, but got O
		//IL_040a: Expected I, but got O
		//IL_041a: Expected O, but got I
		//IL_049a: Expected O, but got I4
		//IL_0456: Expected O, but got I
		//IL_048c: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		bool flag = characterController._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = characterController._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = characterController._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 != null)
		{
			return;
		}
		BloodAstronomiaWeapon bloodAstronomiaWeapon = _bloodAstronomiaWeapon;
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		Weapon weaponByType;
		object obj5;
		if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			weaponByType = characterController2._weaponsManager.GetWeaponByType(WeaponType.ASTRONOMIA, searchHidden: true);
			nint num3;
			if ((object)weaponByType != null)
			{
				num3 = (nint)weaponByType;
				nint num4 = (nint)typeof(BloodAstronomiaWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v81+FFFFFFF8+v563 @ rax_v77*8]");
					if (0 == (nint)typeof(BloodAstronomiaWeapon))
					{
						obj5 = 1;
						goto IL_059e;
					}
				}
				obj5 = 0;
				goto IL_059e;
			}
			num3 = unchecked((nint)null);
			bloodAstronomiaWeapon = null;
		}
		goto IL_05c5;
		IL_0620:
		BloodLancetProjectile bloodLancetProjectile;
		if ((object)bloodLancetProjectile != null && ((UnityEngine.Object)bloodLancetProjectile).m_CachedPtr != (IntPtr)0)
		{
			bloodLancetProjectile.OverrideWeaponData(bloodAstronomiaWeapon._003CLancet_003Ek__BackingField);
		}
		return;
		IL_059e:
		bool flag5 = obj5 == null;
		bloodAstronomiaWeapon = null;
		if (!flag5)
		{
			bloodAstronomiaWeapon = (BloodAstronomiaWeapon)weaponByType;
		}
		goto IL_05c5;
		IL_05c5:
		Projectile projectile;
		object obj13;
		if ((object)bloodAstronomiaWeapon != null && ((UnityEngine.Object)bloodAstronomiaWeapon).m_CachedPtr != (IntPtr)0)
		{
			if (((Equipment)weapon)._equipmentType > WeaponType.LANCET)
			{
				object obj6 = ((Equipment)weapon)._equipmentType - 32;
				if ((nint)obj6 <= 1)
				{
					bloodAstronomiaWeapon._003CSong_003Ek__BackingField = weapon;
					bloodAstronomiaWeapon.FireSong();
					return;
				}
				object obj7 = ((Equipment)weapon)._equipmentType - 1452;
				if ((nint)obj7 <= 1)
				{
					bloodAstronomiaWeapon._003CRapidus_003Ek__BackingField = weapon;
					bloodAstronomiaWeapon.FireTPRapidus();
				}
				return;
			}
			object obj8 = ((Equipment)weapon)._equipmentType - 18;
			object obj9 = 6442450944L;
			if ((nint)obj8 <= 8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v6+77C650C+v340 @ rax_v24*4]");
				object obj10 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v272 @ rcx_v40 (should have been resolved before IL gen)");
			}
			if (((Equipment)weapon)._equipmentType != WeaponType.LANCET)
			{
				return;
			}
			bloodAstronomiaWeapon._003CLancet_003Ek__BackingField = weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)bloodAstronomiaWeapon)._003COwner_003Ek__BackingField;
			float2 position = characterController3._magnet.position;
			float2 pos = default(float2);
			projectile = bloodAstronomiaWeapon._lancetPool.SpawnAt(pos, bloodAstronomiaWeapon);
			bool flag6 = (object)projectile == null;
			bloodLancetProjectile = null;
			if (!flag6)
			{
				nint num6 = (nint)projectile;
				nint num7 = (nint)typeof(BloodLancetProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v943 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLancetProjectile>)+130]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v943 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLancetProjectile>)+130]");
				if (num8 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ rax_v46+FFFFFFF8+v944 @ rax_v42*8]");
					if (0 == (nint)typeof(BloodLancetProjectile))
					{
						obj13 = 1;
						goto IL_05f9;
					}
				}
				obj13 = 0;
				goto IL_05f9;
			}
			goto IL_0620;
		}
		bool flag7 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
		string text = null;
		if (!flag7)
		{
			string text2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.ToString();
			text = text2;
		}
		string message = "Blood Astronomia is being triggered but no ASTRONOMIA weapon found on player " + text;
		Debug.LogWarning(message, ((Equipment)weapon)._003COwner_003Ek__BackingField);
		return;
		IL_05f9:
		bool flag8 = obj13 == null;
		bloodLancetProjectile = null;
		if (!flag8)
		{
			bloodLancetProjectile = (BloodLancetProjectile)projectile;
		}
		goto IL_0620;
	}

	public bool HasRandomazzoEnabled()
	{
		//IL_0105: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							if (_playerOptions != null)
							{
								PlayerOptionsData config2 = _playerOptions.Config;
								if (config2 != null)
								{
									return config2._003CSelectedMazzo_003Ek__BackingField;
								}
							}
							goto IL_00f7;
						}
					}
					return false;
				}
			}
		}
		goto IL_00f7;
		IL_00f7:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool HasSurvarotsEnabled()
	{
		//IL_0172: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							if (_playerOptions != null)
							{
								PlayerOptionsData config2 = _playerOptions.Config;
								if (config2 != null)
								{
									if (config2._003CSelectedSurvarots_003Ek__BackingField)
									{
										return true;
									}
									goto IL_010f;
								}
							}
							goto IL_0164;
						}
					}
					goto IL_010f;
				}
			}
		}
		goto IL_0164;
		IL_0164:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_010f:
		if (_playerOptions != null)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			if (config3 != null)
			{
				return config3._003CForcedSurvarots_003Ek__BackingField;
			}
		}
		goto IL_0164;
	}

	public void OnWeaponFired(Weapon weapon)
	{
		//IL_0267: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_0136: Expected O, but got I
		//IL_0191: Invalid comparison between F4 and I
		_003C_003Ec__DisplayClass130_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass130_0();
		CS_0024_003C_003E8__locals5.weapon = weapon;
		Weapon weapon2 = CS_0024_003C_003E8__locals5.weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		bool flag = characterController._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = characterController._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = characterController._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 != null || !_hasSapphireMist)
		{
			return;
		}
		Weapon weapon3 = CS_0024_003C_003E8__locals5.weapon;
		ArcanaManager_Support arcanaManager_Support = this.arcanaManager_Support;
		List<float> sapphireMistChances = arcanaManager_Support._sapphireMistChances;
		int sapphireMistIndex = arcanaManager_Support._sapphireMistIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num3 = (int)((nint)sapphireMistIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num3 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj3 = 0;
			int sapphireMistIndex2 = arcanaManager_Support._sapphireMistIndex + 1;
			arcanaManager_Support._sapphireMistIndex = sapphireMistIndex2;
			float num4 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.PLuck();
			object obj4 = default(object);
			float num5 = (float)obj4 * arcanaManager_Support._sapphireMistBaseChance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v12+20+v91 @ rdx_v9 (System.Int32)*4]");
			if (num5 > 0f)
			{
				Weapon weapon4 = CS_0024_003C_003E8__locals5.weapon;
				arcanaManager_VFX.Play_SapphireMist(((Equipment)weapon4)._003COwner_003Ek__BackingField);
				Action onComplete = delegate
				{
					CS_0024_003C_003E8__locals5.weapon.ParadoxFire();
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void OnFoodPickedUp(VampireSurvivors.Objects.Characters.CharacterController character, ItemType itemType, float value)
	{
		//IL_00dc: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		bool flag = character._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = character._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = character._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 == null && _hasBreadAnathema)
		{
			arcanaManager_Support.OnFoodPickedUp(character, itemType, value);
		}
	}

	public void OnPlayerLevelUp(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0150: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		bool flag = character._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = character._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = character._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 == null && _hasHailFromTheFuture)
		{
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			bool flag5;
			if ((object)gameSessionData._activeCharacter != null)
			{
				object obj3 = (object)character - (object)gameSessionData._activeCharacter;
				flag5 = obj3 == null;
			}
			else
			{
				flag5 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (flag5)
			{
				arcanaManager_Support.SendHailFromTheFutureGift(character);
			}
		}
	}

	public void OnPlayerHPRecovery(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
	{
		//IL_038a: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_01d5: Expected I, but got O
		//IL_01e3: Expected I, but got O
		//IL_01f3: Expected O, but got I
		//IL_0273: Expected O, but got I4
		//IL_022f: Expected O, but got I
		//IL_03e7: Expected O, but got I4
		//IL_0265: Expected O, but got I4
		bool flag = character._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = character._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = character._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj3 = default(object);
		if (obj3 != null)
		{
			GameManager gameManager = _gameManager;
			gameManager._arcanaManager.TriggerSarabande(rawValue, character);
		}
		if (!_hasJetBlackWeapon)
		{
			return;
		}
		JetBlackWeapon jetBlackWeapon = _jetBlackWeapon;
		if ((object)_jetBlackWeapon == null || ((UnityEngine.Object)jetBlackWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		Weapon weaponByType;
		object obj6;
		if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer)
		{
			weaponByType = character._weaponsManager.GetWeaponByType(WeaponType.D20_JETBLACK, searchHidden: true);
			if ((object)weaponByType != null)
			{
				nint num3 = (nint)weaponByType;
				nint num4 = (nint)typeof(JetBlackWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.JetBlackWeapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.JetBlackWeapon>)+130]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rax_v36+FFFFFFF8+v604 @ rax_v32*8]");
					if (0 == (nint)typeof(JetBlackWeapon))
					{
						obj6 = 1;
						goto IL_03bc;
					}
				}
				obj6 = 0;
				goto IL_03bc;
			}
			jetBlackWeapon = null;
		}
		goto IL_03de;
		IL_03de:
		object obj7 = 388;
		float num6 = ((5f > jetBlackWeapon.accumulatedRecovery) ? (rawValue * 0.005f) : (rawValue * 0.001f));
		float num7 = num6 + jetBlackWeapon.accumulatedRecovery;
		if (jetBlackWeapon.canFire && !(rawValue < 3.3f))
		{
			jetBlackWeapon.Fire();
			jetBlackWeapon.canFire = false;
			float2 position = ((Equipment)jetBlackWeapon)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(jetBlackWeapon.DamageVfx, pos, 50);
			float2 position2 = ((Equipment)jetBlackWeapon)._003COwner_003Ek__BackingField.position;
			RenderingExtensions.EmitParticleAt(jetBlackWeapon.ownerBloodVfx, pos, 25);
		}
		return;
		IL_03bc:
		bool flag5 = obj6 == null;
		jetBlackWeapon = null;
		if (!flag5)
		{
			jetBlackWeapon = (JetBlackWeapon)weaponByType;
		}
		goto IL_03de;
	}

	public void OnPlayerHPDamage(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
	{
		//IL_0281: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0192: Expected I, but got O
		//IL_01a2: Expected O, but got I
		//IL_0222: Expected O, but got I4
		//IL_01de: Expected O, but got I
		//IL_0214: Expected O, but got I4
		bool flag = character._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = character._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = character._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 != null || !_hasJetBlackWeapon)
		{
			return;
		}
		JetBlackWeapon jetBlackWeapon = _jetBlackWeapon;
		if ((object)_jetBlackWeapon == null || ((UnityEngine.Object)jetBlackWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		Weapon weaponByType;
		object obj5;
		if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer)
		{
			weaponByType = character._weaponsManager.GetWeaponByType(WeaponType.D20_JETBLACK, searchHidden: true);
			if ((object)weaponByType != null)
			{
				nint num3 = (nint)weaponByType;
				nint num4 = (nint)typeof(JetBlackWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.JetBlackWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.JetBlackWeapon>)+130]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v24+FFFFFFF8+v406 @ rax_v20*8]");
					if (0 == (nint)typeof(JetBlackWeapon))
					{
						obj5 = 1;
						goto IL_02b3;
					}
				}
				obj5 = 0;
				goto IL_02b3;
			}
			jetBlackWeapon = null;
		}
		goto IL_0234;
		IL_02b3:
		bool flag5 = obj5 == null;
		jetBlackWeapon = null;
		if (!flag5)
		{
			jetBlackWeapon = (JetBlackWeapon)weaponByType;
		}
		goto IL_0234;
		IL_0234:
		jetBlackWeapon.OnPlayerHitDamage(rawValue);
	}

	public void OnPlayerLastBreath(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
	{
		if (_hasVictorianHorror && character._hasLastBreath)
		{
			character.IsInvul = true;
			if (3.0000002f > character._invincibilityTimer)
			{
				character._invincibilityTimer = 3.0000002f;
			}
			ArcanaManager_VFX arcanaManager_VFX = this.arcanaManager_VFX;
			if (arcanaManager_VFX.WorldEaterVFX == null)
			{
				WorldEaterVFX worldEaterVFX = new WorldEaterVFX(character);
				arcanaManager_VFX.WorldEaterVFX = worldEaterVFX;
			}
			arcanaManager_VFX.WorldEaterVFX.CastSoulSteal(null, isCursed: true);
			character._hasLastBreath = false;
		}
	}

	public void OnPlayerCriticalHPTreshold(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue)
	{
		//IL_00e5: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		bool flag = character._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = character._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = character._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 == null && _hasCrystalCries)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD650");
			character._isCriticalHPEnabled = false;
		}
	}

	public void OnPlayerHPRecovery(VampireSurvivors.Objects.Characters.CharacterController character, float rawValue, float actualRecovery)
	{
	}

	public void AddHeartOfFireWeapon(Weapon weapon, float newWeaponPower)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			UpdateHeartOfFirePower(newWeaponPower);
		}
	}

	public void UpdateHeartOfFirePower(float newWeaponPower)
	{
		//IL_011f: Expected O, but got I
		FireExplosionWeapon fireExplosionWeapon = _fireExplosionWeapon;
		if ((object)_fireExplosionWeapon != null && ((UnityEngine.Object)fireExplosionWeapon).m_CachedPtr != (IntPtr)0)
		{
			float num = newWeaponPower * 0.5f;
			if (num > _heartOfFireStartingPower)
			{
				float heartOfFireStartingPower = newWeaponPower * 0.5f;
				_heartOfFireStartingPower = heartOfFireStartingPower;
			}
			FireExplosionWeapon fireExplosionWeapon2 = _fireExplosionWeapon;
			WeaponData currentWeaponData = ((Weapon)fireExplosionWeapon2)._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = _heartOfFireStartingPower;
			List<WeaponType> list = _003CHeartOfFireWeapons_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)1)
			{
				FireExplosionWeapon fireExplosionWeapon3 = _fireExplosionWeapon;
				WeaponData currentWeaponData2 = ((Weapon)fireExplosionWeapon3)._currentWeaponData;
				List<WeaponType> list2 = _003CHeartOfFireWeapons_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj = -1;
				float num2 = (float)obj * 0.5f;
				float num3 = num2 + currentWeaponData2._003Cpower_003Ek__BackingField;
				currentWeaponData2._003Cpower_003Ek__BackingField = num3;
			}
		}
	}

	private unsafe void ActivateSpeedSineBonus()
	{
		//IL_001d: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private unsafe void ActivateDurationSineBonus()
	{
		//IL_001d: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private unsafe void ActivateAreaSineBonus()
	{
		//IL_001d: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void ActivateHeartOfFireRetaliation()
	{
		//IL_007c: Expected I, but got O
		//IL_00b0: Expected I, but got O
		//IL_00c0: Expected O, but got I
		//IL_00fc: Expected O, but got I
		//IL_0141: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_0159: Expected O, but got I
		//IL_0195: Expected O, but got I
		FireExplosionWeapon fireExplosionWeapon = _fireExplosionWeapon;
		if ((object)_fireExplosionWeapon != null && ((UnityEngine.Object)fireExplosionWeapon).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameSessionData gameSessionData = _gameSessionData;
		bool allowDuplicates = default(bool);
		Weapon weapon = _weaponsFacade.AddHiddenWeapon(WeaponType.FIREEXPLOSION, gameSessionData._activeCharacter, removeFromStore: true, allowDuplicates);
		nint num = (nint)typeof(FireExplosionWeapon);
		if ((object)weapon == null)
		{
			_fireExplosionWeapon = null;
			goto IL_01c7;
		}
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.FireExplosionWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.FireExplosionWeapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v24+FFFFFFF8+v348 @ rax_v23*8]");
			if (0 == (nint)typeof(FireExplosionWeapon))
			{
				_fireExplosionWeapon = (FireExplosionWeapon)weapon;
				nint num4 = (nint)typeof(FireExplosionWeapon);
				nint num5 = (nint)weapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.FireExplosionWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.FireExplosionWeapon>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v26+FFFFFFF8+v307 @ rax_v25*8]");
					if (0 == (nint)typeof(FireExplosionWeapon))
					{
						goto IL_01c7;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
		IL_01c7:
		FireExplosionWeapon fireExplosionWeapon2 = _fireExplosionWeapon;
		WeaponData currentWeaponData = ((Weapon)fireExplosionWeapon2)._currentWeaponData;
		currentWeaponData._003Carea_003Ek__BackingField = 1.5f;
	}

	private unsafe void CheckOnAllWeapons()
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void PickedUpCoin(GameplaySignals.OnAfterCoinsAddedSignal signal)
	{
		//IL_004a: Expected F4, but got O
		if (_003CHealOnCoins_003Ek__BackingField)
		{
			GameSessionData gameSessionData = _gameSessionData;
			gameSessionData._activeCharacter.RecoverHp((float)signal, showRecovery: true);
		}
	}

	private unsafe void ActivateLevelUpBonus(string property, float value)
	{
		//IL_0037: Expected O, but got I4
		//IL_003f: Expected O, but got Ref
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator mainCharacters2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._mainCharacters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public void IncreaseBloodlineBonus(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_010d: Expected O, but got I4
		//IL_004b: Expected O, but got I4
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
		if (obj2 == null)
		{
			PlayerModifierStats playerStats = player._playerStats;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + _003CDivineBloodlineHpBonusUnit_003Ek__BackingField;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
		}
	}

	private void Cleanup()
	{
		DataManager dataManager = _dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)10);
		_ = 12;
	}

	private unsafe void GatherAllStageItems()
	{
		//IL_00ba: Expected I, but got O
		//IL_013d: Expected I, but got O
		//IL_02e9: Expected I, but got O
		//IL_031b: Expected I, but got O
		//IL_0409: Expected O, but got Ref
		//IL_041d: Expected O, but got I
		//IL_084b: Expected O, but got I8
		//IL_0854: Expected O, but got I4
		//IL_0861: Expected I, but got I8
		//IL_0878: Expected I, but got O
		//IL_088e: Expected O, but got I
		//IL_0897: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Expected O, but got Unknown
		//IL_0461: Expected O, but got I
		//IL_1069: Expected I4, but got I8
		//IL_08e0: Expected O, but got I8
		//IL_0938: Expected O, but got I8
		//IL_0ffc: Expected I, but got O
		//IL_1017: Expected O, but got I4
		//IL_102e: Expected I, but got I8
		//IL_1040: Expected O, but got I4
		//IL_104d: Expected I, but got I8
		//IL_08fb: Expected O, but got I8
		//IL_0908: Expected I, but got I8
		//IL_04e3: Expected I, but got O
		//IL_0986: Expected I, but got O
		//IL_099c: Expected O, but got I
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected O, but got Unknown
		//IL_0522: Expected I, but got O
		//IL_0b8a: Expected I, but got O
		//IL_0a87: Expected I, but got O
		//IL_0a9d: Expected O, but got I
		//IL_0aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aab: Expected O, but got Unknown
		//IL_111c: Expected I4, but got I8
		//IL_0566: Expected I, but got O
		//IL_0bb7: Invalid comparison between F4 and I4
		//IL_0a2c: Expected I, but got O
		//IL_0a39: Expected O, but got I
		//IL_0d7f: Expected F4, but got I4
		//IL_0d7f: Expected O, but got I4
		//IL_0d7f: Expected O, but got F4
		//IL_12b5: Expected I4, but got I8
		//IL_0afa: Expected O, but got I
		//IL_0b0c: Expected I, but got O
		//IL_1251: Expected F4, but got I4
		//IL_1251: Expected O, but got I4
		//IL_1251: Expected O, but got F4
		//IL_0ce5->IL0e0d: Incompatible stack heights: 1 vs 0
		//IL_1282->IL1282: Incompatible stack heights: 3 vs 0
		_003C_003Ec__DisplayClass152_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass152_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		if (!_003CCanGather_003Ek__BackingField)
		{
			return;
		}
		_003CCanGather_003Ek__BackingField = false;
		Action onComplete = delegate
		{
			ArcanaManager arcanaManager2 = CS_0024_003C_003E8__locals4._003C_003E4__this;
			arcanaManager2._003CCanGather_003Ek__BackingField = true;
		};
		bool flag = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, flag, monoBehaviour, num, type, isOnlineTimer: false, canPause: false);
		ItemType[] array = new ItemType[1];
		bool flag2 = array.Length <= 0;
		nint num2 = (nint)typeof(ItemType[]);
		List<Pickup> list3;
		List<Pickup> list4;
		List<Pickup> list5;
		IEnumerable<Pickup> items;
		Action onComplete2;
		nint extra_arg;
		Action action;
		object obj5;
		UnityEngine.Object obj4;
		if (!flag2)
		{
			_ = 13;
			CS_0024_003C_003E8__locals4.validItems = array;
			ItemType[] array2 = new ItemType[16]
			{
				ItemType.CLOVER,
				ItemType.GILDED,
				ItemType.NFT,
				ItemType.SORBETTO,
				ItemType.OROLOGION,
				ItemType.ROSARY,
				ItemType.VACUUM,
				ItemType.TREASURE,
				ItemType.ROAST,
				ItemType.RELIC_GOLDENEGG,
				ItemType.BONUS_FROZENSOUL,
				ItemType.GOLDFINGER,
				ItemType.PICKUP_REROLL_DICE,
				ItemType.SV_DRAFT1,
				ItemType.SV_DRAFT2,
				ItemType.SV_DRAFT3
			};
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			bool flag3 = loadedDlc == null;
			int num3 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)3);
			Array array3 = array2;
			nint num4 = unchecked((nint)null);
			if (!flag3)
			{
				ItemType[] collection = new ItemType[3]
				{
					ItemType.FB_RAPIDFIRE,
					ItemType.FB_BARRIER,
					ItemType.FB_GRENADE
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB44C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rax_v293 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				List<System.Int32Enum> list = default(List<System.Int32Enum>);
				list.InsertRange(0, (IEnumerable<System.Int32Enum>)(object)collection);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rax_v293 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				((List<ItemType>)(object)list).InsertRange(0, (IEnumerable<ItemType>)collection);
				Array array4 = default(Array);
				array3 = array4;
				num4 = 0;
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
			bool flag4 = loadedDlc2 == null;
			int num5 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)5);
			IEnumerable<System.Int32Enum> enumerable = (IEnumerable<System.Int32Enum>)array3;
			bool flag5 = (byte)num4 != 0;
			if (!flag4)
			{
				ItemType[] collection2 = new ItemType[5]
				{
					ItemType.TP_WALL_CHICKEN,
					ItemType.TP_NEUTRON_BOMB,
					ItemType.TP_KARMA_COIN,
					ItemType.TP_HEART_REFRESH,
					ItemType.TP_MIRROR_OF_TRUTH
				};
				((List<ItemType>)(object)array3).InsertRange(0, (IEnumerable<ItemType>)null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v287 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				List<System.Int32Enum> list2 = default(List<System.Int32Enum>);
				list2.InsertRange(0, (IEnumerable<System.Int32Enum>)(object)collection2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v287 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				((List<ItemType>)(object)list2).InsertRange(0, (IEnumerable<ItemType>)collection2);
				IEnumerable<System.Int32Enum> enumerable2 = default(IEnumerable<System.Int32Enum>);
				enumerable = enumerable2;
				flag5 = false;
			}
			GameManager core = GM.Core;
			Stage stage = core._stage;
			UnityEngine.Object fancyBg = stage._fancyBg;
			bool flag6 = default(bool);
			if (!(stage._fancyBg != null))
			{
				flag6 = false;
			}
			else
			{
				nint num6 = (nint)fancyBg;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2394 @ rdx_v109 (Il2CppClass<UnityEngine.Object>)+358] (should have been resolved before IL gen)");
			}
			ItemType[] array5 = new ItemType[3]
			{
				ItemType.COIN,
				ItemType.COINBAG1,
				ItemType.COINBAGMAX
			};
			ItemType[] array6 = new ItemType[1];
			bool flag7 = array6.Length <= 0;
			num2 = (nint)typeof(ItemType[]);
			if (!flag7)
			{
				_ = 6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
				GameManager gameManager = _gameManager;
				Func<Pickup, bool> predicate = delegate(Pickup i)
				{
					//IL_012f: Expected I4, but got O
					//IL_0013: Expected I, but got O
					//IL_001b: Expected I, but got O
					//IL_002b: Expected O, but got I
					//IL_00ab: Expected O, but got I4
					//IL_0067: Expected O, but got I
					//IL_009d: Expected O, but got I4
					if ((object)i == null)
					{
						goto IL_0121;
					}
					nint num15 = (nint)typeof(NetworkPickup);
					nint num16 = (nint)i;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v2 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v2 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
					object obj17;
					if (num17 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v13+FFFFFFF8+v52 @ rax_v4*8]");
						if (0 == (nint)typeof(NetworkPickup))
						{
							obj17 = 1;
							goto IL_014c;
						}
					}
					obj17 = 0;
					goto IL_014c;
					IL_0121:
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
					IL_014c:
					bool flag22 = obj17 == null;
					Pickup pickup = null;
					if (!flag22)
					{
						pickup = i;
					}
					bool flag23 = Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)CS_0024_003C_003E8__locals4.validItems, (System.Int32Enum)i._003CPickupType_003Ek__BackingField);
					if (!flag23)
					{
						return flag23;
					}
					if ((object)GM.Core != null)
					{
						if (GM.Core.IsStageHost)
						{
							return true;
						}
						return (object)pickup == null;
					}
					goto IL_0121;
				};
				IEnumerable<Pickup> source = Enumerable.Where(gameManager._stagePickups, predicate);
				IEnumerable<Pickup> enumerable3 = Enumerable.Where(source, predicate);
				list3 = new List<Pickup>();
				list4 = new List<Pickup>();
				list5 = new List<Pickup>();
				bool flag8 = !flag6;
				items = enumerable3;
				List<Pickup> list6 = list3;
				if (!flag8)
				{
					List<Pickup> list7 = new List<Pickup>();
					object obj = default(object);
					IEnumerable<Pickup> enumerable4 = Enumerable.Where((IEnumerable<Pickup>)(&obj), (Func<Pickup, bool>)(object)enumerable3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3037 @ rax_v269 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.Objects.Pickups.Pickup>)+10]");
					ArcadeSprite arcadeSprite = (ArcadeSprite)0;
					List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
					object obj2 = default(object);
					object obj3 = default(object);
					while (enumerator.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3037 @ rax_v269 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.Objects.Pickups.Pickup>)+10]");
						bool flag9 = (nint)0 == 0;
						num2 = (nint)(&enumerator);
						if (!flag9)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3037 @ rax_v269 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.Objects.Pickups.Pickup>)+10]");
							Transform cachedTrans = ((ArcadeSprite)0).CachedTrans;
							bool flag10 = (object)cachedTrans == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3037 @ rax_v269 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.Objects.Pickups.Pickup>)+10]");
							num2 = 0;
							if (!flag10)
							{
								Vector3 position = cachedTrans.position;
								bool flag11 = arcadeSprite.body == null;
								num2 = (nint)(&obj2);
								if (!flag11)
								{
									BaseBody body = arcadeSprite.body;
									num2 = (nint)body._transform;
									if (body._transform == null)
									{
										throw new NullReferenceException();
									}
									_ = position.x;
								}
								if ((object)stage._fancyBg != null)
								{
									nint num7 = (nint)fancyBg;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3412 @ r8_v79 (Il2CppClass<UnityEngine.Object>)+368] (should have been resolved before IL gen)");
									if (obj3 != null)
									{
										bool flag12 = list7 == null;
										num2 = (nint)stage._fancyBg;
										if (flag12)
										{
											throw new NullReferenceException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
									}
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					items = list7;
					list6 = list3;
				}
				HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
				if (enumerator2.MoveNext())
				{
					IEnumerable<System.Int32Enum> enumerable5 = null;
					throw new NullReferenceException();
				}
				onComplete2 = _003C_003Ec._003C_003E9__152_2;
				if (_003C_003Ec._003C_003E9__152_2 != null)
				{
					obj4 = (UnityEngine.Object)6447293664L;
					obj5 = 24;
					extra_arg = unchecked((nint)6447293568L);
					goto IL_093d;
				}
				action = null;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2267 @ r10_v29 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec._003CGatherAllStageItems_003Eb__152_2);
				((Delegate)action).m_target = _003C_003Ec._003C_003E9;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2267 @ r10_v29 (Il2CppMethodInfo)+4C]");
				object obj6 = (nint)0 >> 4;
				object obj7 = obj6 & 1;
				nint num9;
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2267 @ r10_v29 (Il2CppMethodInfo)+52]");
					bool flag13 = (nint)0 != 0;
					obj4 = (UnityEngine.Object)6447293664L;
					if (!flag13)
					{
						obj4 = (UnityEngine.Object)6447293664L;
						num9 = unchecked((nint)6447293664L);
						goto IL_100e;
					}
				}
				else
				{
					if (_003C_003Ec._003C_003E9 == null)
					{
						bool flag14 = Enumerable.Contains(null, (ItemType)(-2019369760));
						throw flag14;
					}
					obj4 = (UnityEngine.Object)6447293664L;
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num9 = ((Delegate)action).method_ptr;
				goto IL_100e;
			}
		}
		goto IL_0e0d;
		IL_093d:
		Timer timer2 = Timers.Register(0.25f, onComplete2, null, isLooped: false, flag, monoBehaviour, num, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = _003C_003Ec._003C_003E9__152_3;
		if (_003C_003Ec._003C_003E9__152_3 != null)
		{
			goto IL_0a3e;
		}
		Action action2 = null;
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2403 @ r10_v28 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(_003C_003Ec._003CGatherAllStageItems_003Eb__152_3);
		((Delegate)action2).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2403 @ r10_v28 (Il2CppMethodInfo)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		UnityEngine.Object obj10;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2403 @ r10_v28 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				obj10 = obj4;
				goto IL_10e5;
			}
		}
		else if (_003C_003Ec._003C_003E9 == null)
		{
			bool flag15 = Enumerable.Contains(null, (ItemType)(-2019369760));
			throw flag15;
		}
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		obj10 = (UnityEngine.Object)(nint)((Delegate)action2).method_ptr;
		goto IL_10e5;
		IL_10e5:
		((Delegate)action2).extra_arg = extra_arg;
		_003C_003Ec._003C_003E9__152_3 = action2;
		onComplete3 = action2;
		goto IL_0a3e;
		IL_0e0d:
		throw new IndexOutOfRangeException();
		IL_0b11:
		Action onComplete4;
		Timer timer3 = Timers.Register(0.75000006f, onComplete4, null, isLooped: false, flag, monoBehaviour, num, type, isOnlineTimer: false, canPause: false);
		GameManager core2 = GM.Core;
		float num13 = default(float);
		if (core2._multiplayer.IsOnlineMultiplayer)
		{
			nint num11 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4046 @ rax_v141 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num12 = 0;
			GameManager core3 = GM.Core;
			if (core3._003CSurvivedSeconds_003Ek__BackingField > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				OnlineStageManager onlineStageManager = default(OnlineStageManager);
				List<VampireSurvivors.Objects.Characters.CharacterController> playerCharacters = onlineStageManager.GetPlayerCharacters();
				List<Pickup> items2 = list3;
				ArcanaManager arcanaManager = this;
				bool flag16 = false;
				bool flag17 = false;
				while ((flag16 ? 1 : 0) < playerCharacters._size)
				{
					List<Pickup> subset = arcanaManager.GetSubset((List<Pickup>)items, flag17 ? 1 : 0, playerCharacters._size);
					List<Pickup> subset2 = arcanaManager.GetSubset(items2, flag17 ? 1 : 0, playerCharacters._size);
					List<Pickup> subset3 = arcanaManager.GetSubset(list4, flag17 ? 1 : 0, playerCharacters._size);
					List<Pickup> subset4 = arcanaManager.GetSubset(list5, flag17 ? 1 : 0, playerCharacters._size);
					bool flag18 = (flag17 ? 1 : 0) >= playerCharacters._size;
					VampireSurvivors.Objects.Characters.CharacterController[] items3 = playerCharacters._items;
					if ((flag17 ? 1 : 0) < items3.Length)
					{
						UnityEngine.Object obj11 = items3[flag17 ? 1u : 0u];
						bool flag19 = obj11.m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = Component.get_transform_Injected(obj11.m_CachedPtr);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						bool flag20 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						GatherStageItemsForPosition((float2)num13, subset, subset2, (List<Pickup>)flag, (List<Pickup>)(object)monoBehaviour, num);
						flag17 = (byte)((flag17 ? 1u : 0u) + 1u) != 0;
						items2 = list3;
						arcanaManager = this;
						flag = flag;
						flag16 = flag17;
						continue;
					}
					goto IL_0e0d;
				}
				goto IL_0d84;
			}
		}
		Extensions.Shuffle((IList<object>)list3);
		Extensions.Shuffle((IList<object>)list4);
		Extensions.Shuffle((IList<object>)list5);
		GatherStageItemsForPosition((float2)num13, (List<Pickup>)items, list3, (List<Pickup>)flag, (List<Pickup>)(object)monoBehaviour, num);
		goto IL_0d84;
		IL_0d84:
		GameManager core4 = GM.Core;
		if (core4._multiplayer.IsOnlineMultiplayer)
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			PlayerInfo playerInfo = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
			VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
			float2 position2 = characterController.position;
		}
		return;
		IL_1198:
		Action action3;
		((Delegate)action3).extra_arg = extra_arg;
		_003C_003Ec._003C_003E9__152_4 = action3;
		onComplete4 = action3;
		goto IL_0b11;
		IL_100e:
		object obj12 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		_003C_003Ec._003C_003E9__152_2 = action;
		obj5 = 24;
		extra_arg = unchecked((nint)6447293568L);
		onComplete2 = action;
		goto IL_093d;
		IL_0a3e:
		Timer timer4 = Timers.Register(0.5f, onComplete3, null, isLooped: false, flag, monoBehaviour, num, type, isOnlineTimer: false, canPause: false);
		onComplete4 = _003C_003Ec._003C_003E9__152_4;
		if (_003C_003Ec._003C_003E9__152_4 != null)
		{
			goto IL_0b11;
		}
		action3 = null;
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2512 @ r10_v27 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(_003C_003Ec._003CGatherAllStageItems_003Eb__152_4);
		((Delegate)action3).m_target = _003C_003Ec._003C_003E9;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2512 @ r10_v27 (Il2CppMethodInfo)+4C]");
		object obj13 = (nint)0 >> 4;
		object obj14 = obj13 & 1;
		if (obj14 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2512 @ r10_v27 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				goto IL_1198;
			}
		}
		else if (_003C_003Ec._003C_003E9 == null)
		{
			bool flag21 = Enumerable.Contains(null, (ItemType)(-2019369760));
			throw flag21;
		}
		obj4 = (UnityEngine.Object)(nint)((Delegate)action3).method_ptr;
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		goto IL_1198;
	}

	private List<Pickup> GetSubset(List<Pickup> items, int playerIndex, int playerCount)
	{
		//IL_0017: Expected O, but got I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected I4, but got Unknown
		//IL_0032: Expected O, but got I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected I4, but got Unknown
		//IL_0080: Expected O, but got I4
		List<Pickup> list = new List<Pickup>();
		int num;
		int num2;
		if (items != null)
		{
			object obj = playerIndex * items._size;
			num = obj / playerCount;
			object obj2 = playerIndex + 1;
			object obj3 = obj2 * items._size;
			num2 = obj3 / playerCount;
			if (num2 <= items._size)
			{
				object obj4 = playerIndex + 1;
				if ((nint)obj4 < playerCount)
				{
					goto IL_00e3;
				}
			}
			num2 = items._size;
			goto IL_00e3;
		}
		return (List<Pickup>)(object)new NullReferenceException();
		IL_00e3:
		int count = num2 - num;
		return items.GetRange(num, count);
	}

	private void GatherStageItemsForPosition(float2 playerPos, List<Pickup> items, List<Pickup> others, List<Pickup> coins, List<Pickup> gems, float destructiblesProportion)
	{
		//IL_008b: Expected F4, but got I4
		//IL_07b5: Expected F4, but got I
		//IL_0eb8: Expected F4, but got I4
		//IL_0af8: Expected F4, but got I
		//IL_00e9: Expected O, but got I
		//IL_082a: Expected O, but got I
		//IL_0b6d: Expected O, but got I
		//IL_0844: Expected O, but got I
		//IL_0b87: Expected O, but got I
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_0aa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa5: Expected O, but got Unknown
		//IL_0aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab3: Expected O, but got Unknown
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Expected O, but got Unknown
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Expected O, but got Unknown
		//IL_0de3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de8: Expected O, but got Unknown
		//IL_0df1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df6: Expected O, but got Unknown
		//IL_012d: Expected I, but got O
		//IL_0145: Expected O, but got I
		//IL_01c5: Expected O, but got I4
		//IL_0181: Expected O, but got I
		//IL_01da: Expected O, but got I
		//IL_01b7: Expected O, but got I4
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Expected O, but got Unknown
		//IL_08ea: Expected I, but got O
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Expected O, but got Unknown
		//IL_05a8: Expected I, but got O
		//IL_0c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c71: Expected O, but got Unknown
		//IL_0c2d: Expected I, but got O
		//IL_09a6: Expected O, but got I4
		//IL_09eb: Expected O, but got I4
		//IL_0663: Expected O, but got I4
		//IL_06a8: Expected O, but got I4
		//IL_0ce9: Expected O, but got I4
		//IL_0d2e: Expected O, but got I4
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_023d: Expected I, but got O
		//IL_02ca: Expected O, but got I4
		//IL_033b: Expected O, but got I4
		//IL_0a7b: Expected O, but got I
		//IL_0a84: Expected O, but got I4
		//IL_0738: Expected O, but got I
		//IL_0741: Expected O, but got I4
		//IL_0dbe: Expected O, but got I
		//IL_0dc7: Expected O, but got I4
		//IL_03cb: Expected O, but got I
		//IL_03d4: Expected O, but got I4
		bool flag = items._size <= 0;
		List<Pickup> list = others;
		List<Pickup> list2 = items;
		float2 float5 = playerPos;
		PickupWeapon pickupWeapon = null;
		if (!flag)
		{
			float num = (float)Math.PI / (float)items._size;
			list = others;
			list2 = items;
			float5 = playerPos;
			PickupWeapon pickupWeapon2 = null;
			PickupWeapon pickupWeapon3 = null;
			float num2 = items._size;
			PickupWeapon pickupWeapon4 = null;
			object obj4 = default(object);
			object obj6 = default(object);
			for (PickupWeapon pickupWeapon5 = null; (nint)pickupWeapon5 < items._size; pickupWeapon4 = (PickupWeapon)(pickupWeapon4 + 1), pickupWeapon2 = (PickupWeapon)(pickupWeapon2 - 1), pickupWeapon5 = pickupWeapon4)
			{
				_003C_003Ec__DisplayClass154_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass154_0();
				if ((nint)pickupWeapon4 >= items._size)
				{
					goto IL_0e03;
				}
				float5 = (float2)items._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ rdx_v19 (Unity.Mathematics.float2)+20+v271 @ rsi_v26 (VampireSurvivors.Objects.Items.PickupWeapon)*8]");
				PickupWeapon pickupWeapon6 = (PickupWeapon)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ rdx_v19 (Unity.Mathematics.float2)+20+v271 @ rsi_v26 (VampireSurvivors.Objects.Items.PickupWeapon)*8]");
				if ((nint)0 == 0 || ((UnityEngine.Object)pickupWeapon6).m_CachedPtr == (IntPtr)0)
				{
					continue;
				}
				nint num3 = (nint)typeof(PickupWeapon);
				list2 = (List<Pickup>)(object)pickupWeapon6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rdx_v65 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ r8_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rdx_v65 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj3;
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ r8_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1813 @ rax_v196+FFFFFFF8+v1718 @ rax_v166*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj3 = 1;
						goto IL_0e4b;
					}
				}
				obj3 = 0;
				goto IL_0e4b;
				IL_0e4b:
				bool flag2 = obj3 == null;
				PickupWeapon element = pickupWeapon3;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ rdx_v19 (Unity.Mathematics.float2)+20+v271 @ rsi_v26 (VampireSurvivors.Objects.Items.PickupWeapon)*8]");
					element = (PickupWeapon)0;
				}
				CS_0024_003C_003E8__locals23.element = element;
				bool flag3 = (object)CS_0024_003C_003E8__locals23.element == null;
				float5 = (float2)typeof(PickupWeapon);
				if (flag3)
				{
					continue;
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				Transform transform = CS_0024_003C_003E8__locals23.element.transform;
				if ((object)transform != null)
				{
					nint num5 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj5 = tweenConfig + 16;
				tweenConfig.targets = array;
				float num6 = (float)pickupWeapon2 - 0.5f;
				float num7 = num6 * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				tweenConfig.x = (float?)(object)1;
				float num8 = (float)pickupWeapon2 - 0.5f;
				float num9 = num8 * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				tweenConfig.duration = 1000f;
				float num10 = num9 + num9;
				tweenConfig.ease = Ease.InOutSine;
				float num11 = (float)obj6 - num10;
				tweenConfig.y = (float?)(object)1;
				Func<int, float> staggerDelay = Tweens.Stagger(100f);
				tweenConfig.staggerDelay = staggerDelay;
				TweenCallback onStart = delegate
				{
					PickupWeapon element5 = CS_0024_003C_003E8__locals23.element;
					((Pickup)element5)._003CDisableGet_003Ek__BackingField = true;
					PickupWeapon element6 = CS_0024_003C_003E8__locals23.element;
					if (element6._floatTween != null)
					{
						TweenExtensions.Kill(element6._floatTween);
					}
				};
				tweenConfig.onStart = onStart;
				TweenCallback onComplete = delegate
				{
					//IL_004f: Expected O, but got I4
					//IL_005c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0061: Expected O, but got Unknown
					//IL_007b: Expected O, but got I4
					PickupWeapon element5 = CS_0024_003C_003E8__locals23.element;
					((Pickup)element5)._003CDisableGet_003Ek__BackingField = false;
					CS_0024_003C_003E8__locals23.element.ResumeFloat();
					PickupWeapon element6 = CS_0024_003C_003E8__locals23.element;
					object obj15 = element6._weaponType - 67;
					object obj16 = obj15 & 0xFFFFFFFAL;
					bool flag4 = obj16 == null;
					object obj17 = !flag4;
					if ((obj17 == null && element6._weaponType != WeaponType.RIGHT) || element6._weaponType == WeaponType.RIGHT)
					{
						element6._triggerOnGet = true;
					}
				};
				tweenConfig.onComplete = onComplete;
				MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
				list = null;
				list2 = (List<Pickup>)0;
				float5 = (float2)0;
				pickupWeapon3 = null;
				num2 = 100f;
			}
			pickupWeapon = null;
		}
		if (others._size > 0)
		{
			int size = others._size;
			float num12 = (float)Math.PI / (float)others._size;
			if (items._size == 0)
			{
				size = others._size;
				num12 = (float)Math.PI * 2f / (float)others._size;
			}
			PickupWeapon pickupWeapon7 = pickupWeapon;
			float num13 = size;
			PickupWeapon pickupWeapon8 = pickupWeapon;
			PickupWeapon pickupWeapon9 = pickupWeapon;
			object obj7 = default(object);
			while ((nint)pickupWeapon8 < others._size)
			{
				_003C_003Ec__DisplayClass154_1 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass154_1();
				if ((nint)pickupWeapon7 < others._size)
				{
					Pickup[] items2 = others._items;
					CS_0024_003C_003E8__locals25.element = items2[(object)pickupWeapon7];
					Pickup element2 = CS_0024_003C_003E8__locals25.element;
					if ((object)CS_0024_003C_003E8__locals25.element != null && ((UnityEngine.Object)element2).m_CachedPtr != (IntPtr)0)
					{
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						Transform transform2 = CS_0024_003C_003E8__locals25.element.transform;
						if ((object)transform2 != null)
						{
							nint num14 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							if (obj7 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						object obj8 = tweenConfig2 + 16;
						tweenConfig2.targets = array2;
						float num15 = (float)pickupWeapon9 - 0.5f;
						float num16 = num15 * num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						float num17 = num16 + num16;
						float num11 = (float)playerPos - num17;
						float num18 = (float)pickupWeapon9 - 0.5f;
						tweenConfig2.x = (float?)(object)1;
						float num19 = num18 * num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						tweenConfig2.duration = 750f;
						tweenConfig2.ease = Ease.InOutSine;
						tweenConfig2.y = (float?)(object)1;
						Func<int, float> staggerDelay2 = Tweens.Stagger(100f);
						tweenConfig2.staggerDelay = staggerDelay2;
						TweenCallback onStart2 = delegate
						{
							Pickup element5 = CS_0024_003C_003E8__locals25.element;
							element5._003CDisableGet_003Ek__BackingField = true;
						};
						tweenConfig2.onStart = onStart2;
						TweenCallback onComplete2 = delegate
						{
							Pickup element5 = CS_0024_003C_003E8__locals25.element;
							element5._003CDisableGet_003Ek__BackingField = false;
						};
						tweenConfig2.onComplete = onComplete2;
						MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
						list = null;
						list2 = (List<Pickup>)0;
						float5 = (float2)0;
						num13 = 100f;
						pickupWeapon = null;
					}
					pickupWeapon7 = (PickupWeapon)(pickupWeapon7 + 1);
					pickupWeapon9 = (PickupWeapon)(pickupWeapon9 - 1);
					pickupWeapon8 = pickupWeapon7;
					continue;
				}
				goto IL_0e03;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28+18]");
			float num20 = 0f;
			float num21 = (float)Math.PI * 2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28+18]");
			float num22 = num21 / 0f;
			PickupWeapon pickupWeapon10 = pickupWeapon;
			PickupWeapon pickupWeapon11 = pickupWeapon;
			PickupWeapon pickupWeapon12 = pickupWeapon;
			object obj10 = default(object);
			while (true)
			{
				PickupWeapon pickupWeapon13 = pickupWeapon12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28+18]");
				if ((nint)pickupWeapon13 >= 0)
				{
					break;
				}
				_003C_003Ec__DisplayClass154_2 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass154_2();
				PickupWeapon pickupWeapon14 = pickupWeapon11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28+18]");
				if ((nint)pickupWeapon14 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ stack_28+10]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v56+20+v242 @ rbp_v17 (VampireSurvivors.Objects.Items.PickupWeapon)*8]");
					CS_0024_003C_003E8__locals27.element = (Pickup)0;
					Pickup element3 = CS_0024_003C_003E8__locals27.element;
					if ((object)CS_0024_003C_003E8__locals27.element != null && ((UnityEngine.Object)element3).m_CachedPtr != (IntPtr)0)
					{
						TweenConfig tweenConfig3 = new TweenConfig();
						object[] array3 = new object[1];
						Transform transform3 = CS_0024_003C_003E8__locals27.element.transform;
						if ((object)transform3 != null)
						{
							nint num23 = (nint)array3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							if (obj10 == null)
							{
								ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
								throw ex3;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						object obj11 = tweenConfig3 + 16;
						tweenConfig3.targets = array3;
						float num24 = (float)pickupWeapon10 - 0.5f;
						float num25 = num24 * num22;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						float num26 = num25 * 1.75f;
						float num11 = (float)playerPos - num26;
						float num27 = (float)pickupWeapon10 - 0.5f;
						tweenConfig3.x = (float?)(object)1;
						float num28 = num27 * num22;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						tweenConfig3.duration = 1000f;
						tweenConfig3.ease = Ease.InOutSine;
						tweenConfig3.y = (float?)(object)1;
						Func<int, float> staggerDelay3 = Tweens.Stagger(10f);
						tweenConfig3.staggerDelay = staggerDelay3;
						TweenCallback onStart3 = delegate
						{
							Pickup element5 = CS_0024_003C_003E8__locals27.element;
							element5._003CDisableGet_003Ek__BackingField = true;
						};
						tweenConfig3.onStart = onStart3;
						TweenCallback onComplete3 = delegate
						{
							Pickup element5 = CS_0024_003C_003E8__locals27.element;
							element5._003CDisableGet_003Ek__BackingField = false;
						};
						tweenConfig3.onComplete = onComplete3;
						MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
						list = null;
						list2 = (List<Pickup>)0;
						float5 = (float2)0;
						num20 = 10f;
						pickupWeapon = null;
					}
					pickupWeapon11 = (PickupWeapon)(pickupWeapon11 + 1);
					pickupWeapon10 = (PickupWeapon)(pickupWeapon10 - 1);
					pickupWeapon12 = pickupWeapon11;
					continue;
				}
				goto IL_0e03;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ stack_30+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ stack_30+18]");
			float num29 = 0f;
			float num30 = (float)Math.PI * 2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ stack_30+18]");
			float num31 = num30 / 0f;
			PickupWeapon pickupWeapon15 = pickupWeapon;
			PickupWeapon pickupWeapon16 = pickupWeapon;
			PickupWeapon pickupWeapon17 = pickupWeapon;
			object obj13 = default(object);
			while (true)
			{
				PickupWeapon pickupWeapon18 = pickupWeapon17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ stack_30+18]");
				if ((nint)pickupWeapon18 >= 0)
				{
					break;
				}
				_003C_003Ec__DisplayClass154_3 CS_0024_003C_003E8__locals29 = new _003C_003Ec__DisplayClass154_3();
				PickupWeapon pickupWeapon19 = pickupWeapon16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ stack_30+18]");
				if ((nint)pickupWeapon19 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1019 @ stack_30+10]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v21+20+v243 @ rbp_v14 (VampireSurvivors.Objects.Items.PickupWeapon)*8]");
					CS_0024_003C_003E8__locals29.element = (Pickup)0;
					Pickup element4 = CS_0024_003C_003E8__locals29.element;
					if ((object)CS_0024_003C_003E8__locals29.element != null && ((UnityEngine.Object)element4).m_CachedPtr != (IntPtr)0)
					{
						TweenConfig tweenConfig4 = new TweenConfig();
						object[] array4 = new object[1];
						Transform transform4 = CS_0024_003C_003E8__locals29.element.transform;
						if ((object)transform4 != null)
						{
							nint num32 = (nint)array4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							if (obj13 == null)
							{
								ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
								throw ex4;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						object obj14 = tweenConfig4 + 16;
						tweenConfig4.targets = array4;
						float num33 = (float)pickupWeapon15 - 0.5f;
						float num34 = num33 * num31;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						float num35 = num34 * 1.5f;
						float num11 = (float)playerPos - num35;
						float num36 = (float)pickupWeapon15 - 0.5f;
						tweenConfig4.x = (float?)(object)1;
						float num37 = num36 * num31;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						tweenConfig4.duration = 1000f;
						tweenConfig4.ease = Ease.InOutSine;
						tweenConfig4.y = (float?)(object)1;
						Func<int, float> staggerDelay4 = Tweens.Stagger(10f);
						tweenConfig4.staggerDelay = staggerDelay4;
						TweenCallback onStart4 = delegate
						{
							Pickup element5 = CS_0024_003C_003E8__locals29.element;
							element5._003CDisableGet_003Ek__BackingField = true;
						};
						tweenConfig4.onStart = onStart4;
						TweenCallback onComplete4 = delegate
						{
							Pickup element5 = CS_0024_003C_003E8__locals29.element;
							element5._003CDisableGet_003Ek__BackingField = false;
						};
						tweenConfig4.onComplete = onComplete4;
						MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
						list = null;
						list2 = (List<Pickup>)0;
						float5 = (float2)0;
						num29 = 10f;
						pickupWeapon = null;
					}
					pickupWeapon16 = (PickupWeapon)(pickupWeapon16 + 1);
					pickupWeapon15 = (PickupWeapon)(pickupWeapon15 - 1);
					pickupWeapon17 = pickupWeapon16;
					continue;
				}
				goto IL_0e03;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1756 Invalid \"Jump target not found in method: 0x1877CAEC0\"");
		throw new NullReferenceException();
		IL_0e03:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void GatherAllDestructibles(float2 playerPos, float radius4, float proportionOfMax)
	{
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_02cc: Expected O, but got I
		//IL_02d4: Expected I4, but got O
		//IL_034b: Expected O, but got I4
		//IL_04c2: Expected O, but got I
		//IL_04db: Expected I, but got O
		//IL_0550: Expected I, but got O
		//IL_0562: Expected O, but got I4
		//IL_057a: Expected I, but got O
		//IL_05cb: Expected O, but got I4
		//IL_060c: Expected O, but got I
		//IL_08cd: Expected I, but got O
		//IL_08e3: Expected O, but got I
		//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f1: Expected O, but got Unknown
		//IL_068e: Expected I, but got O
		//IL_0917: Expected O, but got I4
		//IL_092e: Expected I, but got I8
		//IL_0944: Expected O, but got I4
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Expected O, but got Unknown
		//IL_0677: Expected I, but got I8
		//IL_03c5->IL06e1: Incompatible stack heights: 1 vs 0
		//IL_03e2->IL06e1: Incompatible stack heights: 1 vs 0
		//IL_042c->IL06e1: Incompatible stack heights: 1 vs 0
		//IL_0500->IL0500: Incompatible stack heights: 9 vs 8
		//IL_06db->IL0949: Incompatible stack heights: 10 vs 0
		//IL_06e0->IL06e0: Incompatible stack heights: 10 vs 0
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			GameManager gameManager = _gameManager;
			if ((object)_gameManager != null)
			{
				Stage stage = gameManager._stage;
				if ((object)gameManager._stage != null)
				{
					float num = (float)stage._003CMaxDestructibles_003Ek__BackingField * proportionOfMax;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					List<Destructible> newDestructibles = m_newDestructibles;
					object obj = default(object);
					float num2 = (float)Math.PI * 2f / (float)obj;
					if (m_newDestructibles != null)
					{
						int version = newDestructibles._version + 1;
						newDestructibles._version = version;
						newDestructibles._size = 0;
						if (newDestructibles._size > 0)
						{
							Array.Clear(newDestructibles._items, 0, newDestructibles._size);
						}
						if ((nint)obj <= 0)
						{
							return;
						}
						Transform transform = null;
						Vector2 pos = default(Vector2);
						float num4 = default(float);
						Vector2 value = default(Vector2);
						while (true)
						{
							GameManager gameManager2 = _gameManager;
							if ((object)_gameManager == null)
							{
								break;
							}
							Stage stage2 = gameManager2._stage;
							if ((object)gameManager2._stage == null)
							{
								break;
							}
							StageData stageData = stage2._stageData;
							PropType destructibleType;
							if (stage2._stageData != null)
							{
								string text = stageData._003CdestructibleType_003Ek__BackingField;
								if (stageData._003CdestructibleType_003Ek__BackingField != null && text._stringLength > 0)
								{
									StageData stageData2 = stage2._stageData;
									destructibleType = Enum.Parse<PropType>(stageData2._003CdestructibleType_003Ek__BackingField);
									goto IL_0735;
								}
							}
							destructibleType = PropType.BRAZIER;
							goto IL_0735;
							IL_0735:
							Destructible destructible = gameManager2._stage.MakeDestructible(destructibleType, pos);
							List<object> newDestructibles2 = (List<object>)(object)m_newDestructibles;
							if (m_newDestructibles == null)
							{
								break;
							}
							int version2 = newDestructibles2._version + 1;
							newDestructibles2._version = version2;
							object[] items = newDestructibles2._items;
							if (newDestructibles2._items == null)
							{
								break;
							}
							int size = newDestructibles2._size;
							if (newDestructibles2._size >= items.Length)
							{
								((List<object>)(object)m_newDestructibles).AddWithResize((object)destructible);
								Destructible destructible2 = (Destructible)0;
								size = (int)destructible;
							}
							else
							{
								int size2 = newDestructibles2._size + 1;
								newDestructibles2._size = size2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								Destructible destructible2 = destructible;
							}
							transform = (Transform)(transform + 1);
							if (System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
							{
								continue;
							}
							float num3 = num4;
							object obj2 = 0;
							while (true)
							{
								_003C_003Ec__DisplayClass155_0 obj3 = new _003C_003Ec__DisplayClass155_0();
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,r15d\"");
								float num5 = 0f * num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,r15d\"");
								float num6 = 0f * num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
								List<Destructible> newDestructibles3 = m_newDestructibles;
								if (m_newDestructibles == null)
								{
									break;
								}
								bool flag = (nint)obj2 >= newDestructibles3._size;
								Destructible[] items2 = newDestructibles3._items;
								if (newDestructibles3._items == null || obj3 == null)
								{
									break;
								}
								obj3.d = items2[obj2];
								object d = obj3.d;
								if ((object)obj3.d == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v19 (System.Object)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v19 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								bool flag3 = (object)transform2 == null;
								bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
								bool flag5 = (object)obj3.d == null;
								obj3.d.UpdateLightPosition();
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								object d2 = obj3.d;
								bool flag6 = (object)obj3.d == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rbx_v21 (System.Object)+10]");
								bool flag7 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rbx_v21 (System.Object)+10]");
								IntPtr intPtr = Component.get_transform_Injected((IntPtr)0);
								Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr);
								bool flag8 = array == null;
								bool flag9 = (object)transform3 == null;
								Transform transform4 = (Transform)(nint)intPtr;
								if (!flag9)
								{
									Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform3);
									bool flag10 = (object)transform5 == null;
									transform4 = transform3;
								}
								bool flag11 = array.Length <= 0;
								array[0] = transform3;
								bool flag12 = tweenConfig == null;
								tweenConfig.targets = array;
								Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform4);
								tweenConfig.x = (float?)(object)1;
								float num7 = (float)obj2 * num2;
								Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform4);
								tweenConfig.duration = 500f;
								tweenConfig.ease = Ease.InOutSine;
								float num8 = num7 * radius4;
								num3 = num4 - num8;
								tweenConfig.y = (float?)(object)1;
								Func<int, float> staggerDelay = Tweens.Stagger(100f);
								tweenConfig.staggerDelay = staggerDelay;
								TweenCallback tweenCallback = null;
								nint num9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
								items = (object[])0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r10_v17 (Il2CppMethodInfo)+8]");
								((Delegate)tweenCallback).method_ptr = (IntPtr)0;
								((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass155_0._003CGatherAllDestructibles_003Eb__0);
								((Delegate)tweenCallback).m_target = obj3;
								((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r10_v17 (Il2CppMethodInfo)+4C]");
								object obj4 = (nint)0 >> 4;
								object obj5 = obj4 & 1;
								nint num10;
								if (obj5 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ r10_v17 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num10 = unchecked((nint)6447293664L);
										goto IL_090e;
									}
								}
								((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
								num10 = ((Delegate)tweenCallback).method_ptr;
								goto IL_090e;
								IL_090e:
								Destructible destructible3 = (Destructible)24;
								((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
								tweenConfig.onUpdate = tweenCallback;
								Destructible destructible2 = (Destructible)24;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								obj2++;
								bool flag13 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
								size = 0;
								if (!flag13)
								{
									return;
								}
							}
							break;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public ArcanaManager()
	{
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<WeaponType>> beginning = new Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<WeaponType>>();
		_beginning = beginning;
		List<ArcanaType> list = new List<ArcanaType>();
		_003CActiveArcanas_003Ek__BackingField = list;
		List<WeaponType> list2 = new List<WeaponType>();
		_003CHeartOfFireWeapons_003Ek__BackingField = list2;
		_003CXpMultiplier_003Ek__BackingField = 1f;
		_003CDivineBloodlineHpBonusUnit_003Ek__BackingField = 0.5f;
		_003CMinTreasureChestLevel_003Ek__BackingField = 1;
		_003CMaxArcanasPerRun_003Ek__BackingField = 3;
		List<Destructible> newDestructibles = new List<Destructible>();
		m_newDestructibles = newDestructibles;
	}
}
