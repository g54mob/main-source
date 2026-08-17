using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Framework;

public class LevelUpFactory : IInitializable, IDisposable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, WeaponType> _003C_003E9__44_0;

		public static Func<Equipment, WeaponType> _003C_003E9__44_1;

		public static Func<Equipment, WeaponType> _003C_003E9__45_0;

		public static Func<Equipment, WeaponType> _003C_003E9__52_0;

		public static Func<Equipment, WeaponType> _003C_003E9__52_1;

		public static Func<Equipment, WeaponType> _003C_003E9__53_0;

		public static Func<Equipment, WeaponType> _003C_003E9__53_1;

		public static Func<Equipment, bool> _003C_003E9__60_0;

		public static Func<Equipment, bool> _003C_003E9__60_1;

		public static Func<Equipment, bool> _003C_003E9__61_0;

		public static Predicate<Equipment> _003C_003E9__62_1;

		public static Predicate<Equipment> _003C_003E9__62_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal WeaponType _003CGetExistingNotMaxedWeapons_003Eb__44_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CGetExistingNotMaxedWeapons_003Eb__44_1(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CAddLateWeapon_003Eb__45_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CPullRemainingExistingWeapon_003Eb__52_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CPullRemainingExistingWeapon_003Eb__52_1(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CPullNewWeapon_003Eb__53_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CPullNewWeapon_003Eb__53_1(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal bool _003CAlucardShieldUniqueRequirements_003Eb__60_0(Equipment o)
		{
			//IL_0098: Expected I4, but got O
			if ((object)o != null)
			{
				if (o.IsMaxLevel())
				{
					if (o._currentJsonDataObject == null)
					{
						goto IL_008a;
					}
					object obj = o._currentJsonDataObject.ToObject<object>();
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v7 (System.Object)+60]");
						return false;
					}
				}
				return false;
			}
			goto IL_008a;
			IL_008a:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CAlucardShieldUniqueRequirements_003Eb__60_1(Equipment o)
		{
			//IL_007d: Expected I4, but got O
			//IL_0045: Expected I, but got O
			//IL_0055: Expected O, but got I
			//IL_0065: Expected O, but got I
			if ((object)o != null)
			{
				bool flag = o.IsMaxLevel();
				if (!flag)
				{
					return flag;
				}
				nint num = (nint)o;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1E8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1F0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v39 @ rax_v3 (should have been resolved before IL gen)");
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CCalamityRingUniqueRequirements_003Eb__61_0(Equipment o)
		{
			//IL_007d: Expected I4, but got O
			//IL_0045: Expected I, but got O
			//IL_0055: Expected O, but got I
			//IL_0065: Expected O, but got I
			if ((object)o != null)
			{
				bool flag = o.IsMaxLevel();
				if (!flag)
				{
					return flag;
				}
				nint num = (nint)o;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1E8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1F0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v39 @ rax_v3 (should have been resolved before IL gen)");
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSaboteurWeaponsUniqueRequirements_003Eb__62_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSaboteurWeaponsUniqueRequirements_003Eb__62_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public WeaponType weapontype;

		internal bool _003CPullExisting_003Eb__0(WeightedWeapon x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (x != null)
			{
				object obj = x.Weapon - weapontype;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass58_0
	{
		public WeaponType s;

		internal bool _003CHasEvolutionRequirements_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - s;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass58_1
	{
		public WeaponType s;

		internal bool _003CHasEvolutionRequirements_003Eb__1(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - s;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass58_2
	{
		public WeaponType s;

		public int maxLv;

		internal bool _003CHasEvolutionRequirements_003Eb__2(Equipment x)
		{
			//IL_00cc: Expected I4, but got O
			//IL_005a: Expected O, but got I4
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected I4, but got Unknown
			if ((object)x != null)
			{
				if (x._equipmentType != s)
				{
					return false;
				}
				object obj = x._003CLevel_003Ek__BackingField - maxLv;
				int num = x._003CLevel_003Ek__BackingField ^ maxLv;
				int num2 = x._003CLevel_003Ek__BackingField ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass62_0
	{
		public WeaponType currentWeaponType;

		internal bool _003CSaboteurWeaponsUniqueRequirements_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - currentWeaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass64_0
	{
		public WeaponType t;

		internal bool _003CCalculateWeights_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - t;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CCalculateWeights_003Eb__1(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - t;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private float _defaultXPFactor = 5f;

	private float _currentXpFactor = 5f;

	private float _previousXpFactor = 5f;

	private float _chanceForExistingPowerUp = 0.3f;

	private int _levelUpOptions = 3;

	private int _accumulatedWeight;

	private bool _useDebugLog;

	private static LinkedList<WeaponType> _weaponStore;

	private static LinkedList<WeaponType> _excludedWeapons;

	private static LinkedList<WeaponType> _specialWeapons;

	private static LinkedList<WeaponType> _banishedWeapons;

	private static List<WeightedWeapon> _weightedStore;

	private GameSessionData _gameSessionData;

	private SignalBus _signalBus;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private CoopConfig _coopConfig;

	private List<WeaponType> _unlockedWeapons;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _cachedPlayerList;

	private List<bool> _coopAmuletBag;

	public float XpRequiredToLevelUp => _currentXpFactor;

	public float PreviousXpRequiredToLevelUp => _previousXpFactor;

	public List<WeightedWeapon> WeightedStore => _weightedStore;

	public LinkedList<WeaponType> WeaponStore => _weaponStore;

	public LinkedList<WeaponType> ExcludedWeapons => _excludedWeapons;

	public LinkedList<WeaponType> BanishedWeapons => _banishedWeapons;

	public LinkedList<WeaponType> SpecialWeapons => _specialWeapons;

	public void Initialize()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_01bb: Expected O, but got I
		//IL_0154: Expected O, but got I4
		//IL_0154: Expected O, but got I
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_01f6: Expected O, but got I
		Action action = InitializeWeaponStores;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.PreInitializeGameSessionSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.PreInitializeGameSessionSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v12 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = InitialiseWeights;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2530");
		Action<GameplaySignals.RemoveWeaponFromExcluded> action4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB46B0");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action5 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.RemoveWeaponFromExcluded>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.RemoveWeaponFromExcluded>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v30 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
	}

	public void Dispose()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		Action token = InitializeWeaponStores;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action action = InitialiseWeights;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA64D0");
		Action<GameplaySignals.RemoveWeaponFromExcluded> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB46B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	public void Init()
	{
		CalculateXpFactor();
		GameSessionData gameSessionData = _gameSessionData;
		CalculateWeights(gameSessionData._activeCharacter);
		int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
		if (playerCount <= 1 && !MultiplayerManager.s_instance.IsOnlineMultiplayer)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
		}
		InitAmuletBag();
	}

	public unsafe void CalculateXpFactor()
	{
		//IL_003d: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_017d: Invalid comparison between F4 and I
		//IL_0434: Invalid comparison between F4 and I
		//IL_0490: Expected O, but got I4
		//IL_04a3: Expected O, but got I4
		//IL_01a4: Expected F4, but got I
		//IL_0091: Expected O, but got I4
		//IL_009a: Expected O, but got I4
		//IL_01b9: Expected F4, but got I
		//IL_00cb: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_01e3: Expected I, but got O
		//IL_0248: Expected I, but got O
		//IL_02ae: Expected I, but got O
		//IL_0313: Expected I, but got O
		//IL_03ca: Expected O, but got Ref
		//IL_0378: Expected I, but got O
		GameManager core = GM.Core;
		MultiplayerManager multiplayer = core._multiplayer;
		bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
		bool flag = !isOnlineMultiplayer;
		object obj = 0;
		float defaultXPFactor;
		VampireSurvivors.Objects.Characters.CharacterController characterController2;
		if (!flag)
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			PlayerInfo playerInfo = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
			VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
			bool flag2 = (object)characterController == null;
			object obj2 = 0;
			obj = 0;
			multiplayer = (MultiplayerManager)(object)playerInfo;
			if (!flag2)
			{
				defaultXPFactor = _defaultXPFactor;
				characterController2 = characterController;
				obj2 = 0;
				obj = 0;
				multiplayer = (MultiplayerManager)(object)playerInfo;
				goto IL_010c;
			}
		}
		GameSessionData gameSessionData = _gameSessionData;
		characterController2 = gameSessionData._activeCharacter;
		defaultXPFactor = _defaultXPFactor;
		goto IL_010c;
		IL_010c:
		float num = (float)characterController2._level / 20f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj3 = characterController2._level - 1;
		object obj4 = default(object);
		float num2 = (float)obj4 * 1.5f;
		float num3 = num2 + defaultXPFactor;
		float num4 = (float)obj3 / 20f;
		float num5 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10AE0]");
		if (num5 > 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10AE0]");
			num3 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj5 = default(object);
		float num6 = (float)obj5 * 1.5f;
		float num7 = num6 + _defaultXPFactor;
		float num8 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10AE0]");
		if (num8 > 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10AE0]");
			num7 = 0f;
		}
		float num9 = (float)characterController2._level * num3;
		float currentXpFactor = num9 * (float)characterController2._level;
		_currentXpFactor = currentXpFactor;
		object obj6 = characterController2._level - 1;
		object obj7 = characterController2._level - 1;
		float num10 = (float)obj6 * num7;
		float previousXpFactor = num10 * (float)obj7;
		_previousXpFactor = previousXpFactor;
		object[] array = new object[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj8 = default(object);
		if (obj8 != null)
		{
			nint num11 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			if (obj9 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj10 = default(object);
		if (obj10 != null)
		{
			nint num12 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			if (obj11 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj12 = default(object);
		if (obj12 != null)
		{
			nint num13 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj13 = default(object);
			if (obj13 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj14 = default(object);
		if (obj14 != null)
		{
			nint num14 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj15 = default(object);
			if (obj15 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj16 = default(object);
		if (obj16 != null)
		{
			nint num15 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj17 = default(object);
			if (obj17 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		object obj18 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "New Xp Factors. Current Char Xp: {0}. Required Xp To Level Up: {1}. Player Level: {2}. Previous Xp Req: {3}. Previous Level: {4}", (System.ParamsArray)(&obj18));
		Debug.Log(message);
	}

	public void ForceExclude(WeaponType t)
	{
		LinkedListNode<WeaponType> linkedListNode = _excludedWeapons.Find(t);
		if (linkedListNode == null)
		{
			LinkedListNode<WeaponType> linkedListNode2 = _excludedWeapons.AddLast(t);
		}
		GameSessionData gameSessionData = _gameSessionData;
		CalculateWeights(gameSessionData._activeCharacter);
	}

	public unsafe void Banish(WeaponType t)
	{
		//IL_0060: Expected O, but got Ref
		LinkedListNode<WeaponType> linkedListNode = _excludedWeapons.AddLast(t);
		LinkedListNode<WeaponType> linkedListNode2 = _banishedWeapons.AddLast(t);
		GameSessionData gameSessionData = _gameSessionData;
		CalculateWeights(gameSessionData._activeCharacter);
		LinkedList<WeaponType>.Enumerator enumerator = default(LinkedList<WeaponType>.Enumerator);
		IntPtr intPtr = default(IntPtr);
		while (enumerator.MoveNext())
		{
			string text = ((Enum)(&intPtr)).ToString();
			string message = "Banished: " + text;
			Debug.Log(message);
		}
	}

	public bool IsBanished(WeaponType t)
	{
		//IL_0044: Expected I4, but got O
		if (_banishedWeapons != null)
		{
			LinkedListNode<WeaponType> linkedListNode = _banishedWeapons.Find(t);
			bool flag = linkedListNode == null;
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsBlockedDueToCoop(WeaponType t, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_01db: Expected O, but got I4
		//IL_0238: Expected I, but got O
		//IL_0351: Expected I, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			if (core._mainCharacters != null)
			{
				if (mainCharacters._size > 1 && t != WeaponType.FB_WEAPONPU)
				{
					if ((object)character == null || (object)character._weaponsManager == null)
					{
						goto IL_04a2;
					}
					Equipment equipmentByType = character._weaponsManager.GetEquipmentByType(t);
					if ((object)equipmentByType == null || ((UnityEngine.Object)equipmentByType).m_CachedPtr == (IntPtr)0)
					{
						if ((object)character._accessoriesManager == null)
						{
							goto IL_04a2;
						}
						Equipment equipmentByType2 = character._accessoriesManager.GetEquipmentByType(t);
						if ((object)equipmentByType2 == null || ((UnityEngine.Object)equipmentByType2).m_CachedPtr == (IntPtr)0)
						{
							GameManager core2 = GM.Core;
							if ((object)GM.Core == null || core2._mainCharacters == null)
							{
								goto IL_04a2;
							}
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							while (enumerator.MoveNext())
							{
								object obj = 0;
								if (((UnityEngine.Object)character).m_CachedPtr != (IntPtr)0)
								{
									nint num = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ rax_v53 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num2 = 0;
									GameManager core3 = GM.Core;
									if ((object)GM.Core == null)
									{
										throw new NullReferenceException();
									}
									CoopConfig coopConfig = core3.CoopConfig;
									if ((object)core3.CoopConfig == null)
									{
										throw new NullReferenceException();
									}
									if (coopConfig._blockWeaponsOwnedByOtherPlayers)
									{
										throw new NullReferenceException();
									}
									nint num3 = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v59 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num4 = 0;
									GameManager core4 = GM.Core;
									bool flag = (object)GM.Core == null;
									num2 = num4;
									if (flag)
									{
										throw new NullReferenceException();
									}
									CoopConfig coopConfig2 = core4.CoopConfig;
									bool flag2 = (object)core4.CoopConfig == null;
									num2 = num4;
									if (flag2)
									{
										throw new NullReferenceException();
									}
									if (coopConfig2._blockAccessoriesOwnedByOtherPlayers)
									{
										num2 = num4;
										throw new NullReferenceException();
									}
								}
							}
						}
					}
				}
				return false;
			}
		}
		goto IL_04a2;
		IL_04a2:
		throw new NullReferenceException();
	}

	public LinkedList<WeaponType> GetBanishedWeapons()
	{
		return _banishedWeapons;
	}

	public Dictionary<WeaponType, List<WeaponData>> GetWeapons()
	{
		if (_data != null)
		{
			return _data.GetConvertedWeapons();
		}
		return (Dictionary<WeaponType, List<WeaponData>>)(object)new NullReferenceException();
	}

	public List<WeaponType> GetExistingNotMaxedWeapons(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_03b3: Expected I, but got O
		//IL_03c9: Expected O, but got I
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_051e: Expected O, but got I4
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected O, but got Unknown
		//IL_01f4: Expected O, but got I
		//IL_032c: Expected I, but got O
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0224: Expected O, but got I
		//IL_0266: Expected O, but got I
		//IL_02a5: Expected O, but got I
		//IL_02e4: Expected O, but got I
		CharacterWeaponsManager weaponsManager = character._weaponsManager;
		Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__44_0;
		if (_003C_003Ec._003C_003E9__44_0 == null)
		{
			Func<Equipment, WeaponType> func = (_003C_003Ec._003C_003E9__44_0 = delegate(Equipment x)
			{
				//IL_0035: Expected I4, but got O
				if ((object)x == null)
				{
					NullReferenceException ex3 = new NullReferenceException();
					return (WeaponType)ex3;
				}
				return x._equipmentType;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v114 (Il2CppClass<VampireSurvivors.Framework.LevelUpFactory+<>c>)+B8]");
			object obj = (nint)0 + (nint)8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			selector = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj4 * 8;
				object obj6 = 6603577472L + obj5;
				object obj7 = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj8 = 1 << (int)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v41+462E0]");
					object obj9 = 0 | obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v41+462E0]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v41+462E0]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v41+462E0]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v41+462E0]");
				}
				while (num3 != 0);
				selector = func;
			}
		}
		IEnumerable<WeaponType> enumerable = Enumerable.Select(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, selector);
		if (enumerable != null)
		{
			List<System.Int32Enum> collection = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			CharacterAccessoriesManager accessoriesManager = character._accessoriesManager;
			Func<Equipment, WeaponType> selector2 = _003C_003Ec._003C_003E9__44_1;
			if (_003C_003Ec._003C_003E9__44_1 == null)
			{
				selector2 = (_003C_003Ec._003C_003E9__44_1 = delegate(Equipment x)
				{
					//IL_0035: Expected I4, but got O
					if ((object)x == null)
					{
						NullReferenceException ex3 = new NullReferenceException();
						return (WeaponType)ex3;
					}
					return x._equipmentType;
				});
			}
			IEnumerable<WeaponType> enumerable2 = Enumerable.Select(((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField, selector2);
			if (enumerable2 != null)
			{
				List<System.Int32Enum> collection2 = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable2);
				List<WeaponType> list = new List<WeaponType>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1073 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)collection);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1073 @ rax_v48 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)collection2);
				List<WeaponType> list2 = new List<WeaponType>();
				object obj10 = default(object);
				object obj11 = default(object);
				object obj13 = default(object);
				object obj16 = default(object);
				object obj17 = default(object);
				object obj18 = default(object);
				while (true)
				{
					if (obj10 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-48_v12+1C]");
						if (obj11 != null)
						{
							break;
						}
						object obj12 = obj13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-48_v12+18]");
						if ((nint)obj12 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-48_v12+10]");
						object obj14 = 0;
						object obj15 = obj13 + 1;
						LinkedList<WeaponType> weaponStore = _weaponStore;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v18+20+v149 @ stack_-40_v11*4]");
						((List<WeaponType>)(object)weaponStore).InsertRange(0, (IEnumerable<WeaponType>)0);
						bool flag2 = obj16 == null;
						obj13 = obj15;
						if (flag2)
						{
							continue;
						}
						LinkedList<WeaponType> excludedWeapons = _excludedWeapons;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v18+20+v1264 @ rcx_v53*4]");
						((List<WeaponType>)(object)excludedWeapons).InsertRange(0, (IEnumerable<WeaponType>)0);
						bool flag3 = obj17 != null;
						obj13 = obj15;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v18+20+v1264 @ rcx_v53*4]");
							list.InsertRange(0, (IEnumerable<WeaponType>)0);
							bool flag4 = obj18 != null;
							obj13 = obj15;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rbx_v18+20+v1264 @ rcx_v53*4]");
								list2.InsertRange(0, (IEnumerable<WeaponType>)0);
								obj13 = obj15;
							}
						}
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag5 = obj10 == null;
				nint num4 = 0;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-48_v12+1C]");
					if (obj11 == null)
					{
						return list2;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num4 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	public void AddLateWeapon(WeaponType weapon, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		CharacterWeaponsManager weaponsManager = character._weaponsManager;
		Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__45_0;
		if (_003C_003Ec._003C_003E9__45_0 == null)
		{
			selector = (_003C_003Ec._003C_003E9__45_0 = delegate(Equipment x)
			{
				//IL_0035: Expected I4, but got O
				if ((object)x == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (WeaponType)ex2;
				}
				return x._equipmentType;
			});
		}
		IEnumerable<WeaponType> enumerable = Enumerable.Select(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, selector);
		if (enumerable != null)
		{
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj = default(object);
			if (obj != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD7E0");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			LinkedListNode<WeaponType> linkedListNode = _specialWeapons.AddLast(weapon);
			object obj3 = default(object);
			LinkedListNode<WeaponType> linkedListNode2 = default(LinkedListNode<WeaponType>);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD7E0");
				if (obj3 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD7E0");
				if (linkedListNode2 != null)
				{
					_excludedWeapons.InternalRemoveNode(linkedListNode2);
				}
			}
			CalculateWeights(character);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public List<WeaponType> RerollLevelUpPowerUps(List<WeaponType> excludedWeapons, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_00c2: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0157: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		List<WeaponType> list = new List<WeaponType>();
		VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		int num;
		object obj2;
		List<WeaponType> exclusions = default(List<WeaponType>);
		if (GetRandomExistingWeapon(character2) != WeaponType.VOID)
		{
			if (list == null)
			{
				goto IL_018b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			int levelUpOptions = GetLevelUpOptions();
			CalculateWeightsWithExclusions(exclusions, character2);
			num = levelUpOptions;
			object obj = 0;
			obj2 = 0;
		}
		else
		{
			int levelUpOptions2 = GetLevelUpOptions();
			CalculateWeightsWithExclusions(exclusions, character2);
			bool flag = list == null;
			num = levelUpOptions2;
			object obj = 0;
			obj2 = 0;
			if (flag)
			{
				goto IL_018b;
			}
		}
		object obj3 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 >= (nint)num || (nint)obj2 >= 1000)
			{
				break;
			}
			obj2++;
			WeaponType randomWeightedWeaponOrPowerUp = GetRandomWeightedWeaponOrPowerUp();
			bool flag2 = randomWeightedWeaponOrPowerUp == WeaponType.VOID;
			exclusions = null;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				bool flag3 = obj3 != null;
				exclusions = (List<WeaponType>)randomWeightedWeaponOrPowerUp;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					exclusions = (List<WeaponType>)randomWeightedWeaponOrPowerUp;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F650");
		return list;
		IL_018b:
		return (List<WeaponType>)(object)new NullReferenceException();
	}

	private void CalculateWeightsWithExclusions(List<WeaponType> exclusions, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		_accumulatedWeight = 0;
		List<WeightedWeapon> weightedStore = new List<WeightedWeapon>();
		_weightedStore = weightedStore;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			if (_excludedWeapons == null)
			{
				break;
			}
			LinkedListNode<WeaponType> linkedListNode = _excludedWeapons.Find(WeaponType.VOID);
			if (linkedListNode != null)
			{
				continue;
			}
			bool flag = _specialWeapons == null;
			LinkedList<WeaponType> specialWeapons = _specialWeapons;
			if (!flag)
			{
				LinkedListNode<WeaponType> linkedListNode2 = _specialWeapons.Find(WeaponType.VOID);
				if (linkedListNode2 == null)
				{
					bool flag2 = exclusions == null;
					specialWeapons = _specialWeapons;
					if (flag2)
					{
						throw new NullReferenceException();
					}
					LinkedListNode<WeaponType> linkedListNode3 = ((LinkedList<WeaponType>)(object)exclusions).Find(WeaponType.VOID);
					if (linkedListNode3 == null && !IsBlockedDueToCoop(WeaponType.VOID, character))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
						specialWeapons = null;
						throw new NullReferenceException();
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public WeaponType GetSpecialWeapon(WeaponType weapon)
	{
		//IL_0066: Expected I4, but got O
		//IL_0017: Expected I4, but got O
		if (_specialWeapons != null)
		{
			WeaponType weaponType = (WeaponType)_specialWeapons.Find(weapon);
			if (weaponType == WeaponType.VOID)
			{
				return weaponType;
			}
			if (_specialWeapons != null)
			{
				LinkedListNode<WeaponType> linkedListNode = _specialWeapons.Find(weapon);
				return weapon;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (WeaponType)ex;
	}

	public bool HasPowerupsInStore(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_009e: Expected I4, but got O
		CalculateWeights(character);
		List<WeightedWeapon> weightedStore = _weightedStore;
		if (_weightedStore != null)
		{
			int num = weightedStore._size ^ weightedStore._size;
			int num2 = weightedStore._size & num;
			bool flag = num2 < 0;
			bool flag2 = weightedStore._size < 0;
			bool flag3 = weightedStore._size == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void ValidatePurchasedPassiveFromMerchant(WeaponType weaponType)
	{
		RemoveFromExcluded(weaponType);
	}

	public unsafe WeaponType PullRemainingPowerUp(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0059: Expected F4, but got I4
		//IL_0404: Expected O, but got I
		//IL_0426: Expected O, but got Ref
		//IL_02cf: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A661B]");
		bool flag = (nint)0 != 0;
		List<WeightedWeapon> store = new List<WeightedWeapon>();
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		int num = 0;
		float num2 = 2f;
		Dictionary<WeaponType, List<WeaponData>> dictionary = convertedWeapons;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr = intPtr2;
			Dictionary<WeaponType, List<WeaponData>> dictionary2 = dictionary;
			bool flag2 = flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			DataManager dataManager = null;
			throw new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag3 = (nint)0 != 0;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator2 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)(&enumerator);
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			enumerator2 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v682 @ rax_v30 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
		return GetWeaponFromWeightedStore(store, 0.0);
	}

	public WeaponType PullRemainingExistingWeapon(VampireSurvivors.Objects.Characters.CharacterController character, bool includePowerUps = true)
	{
		//IL_00a8: Expected O, but got I
		//IL_04f6: Expected I, but got O
		//IL_050c: Expected O, but got I
		//IL_0528: Expected I, but got O
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_006e: Expected O, but got I8
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0726: Expected O, but got I4
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_073b: Expected O, but got Unknown
		//IL_01e8: Expected F4, but got O
		//IL_010f: Expected O, but got I
		//IL_0090: Expected I, but got O
		//IL_0133: Expected O, but got I
		//IL_06b8: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_024b: Expected O, but got I
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_06d6: Expected O, but got I
		//IL_02a6: Expected O, but got I
		//IL_03e5: Expected I, but got I8
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected I4, but got Unknown
		//IL_036a: Expected I4, but got O
		List<WeightedWeapon> list = new List<WeightedWeapon>();
		CharacterWeaponsManager weaponsManager = character._weaponsManager;
		Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__52_0;
		if (_003C_003Ec._003C_003E9__52_0 == null)
		{
			Func<Equipment, WeaponType> func = (_003C_003Ec._003C_003E9__52_0 = delegate(Equipment x)
			{
				//IL_0035: Expected I4, but got O
				if ((object)x == null)
				{
					NullReferenceException ex4 = new NullReferenceException();
					return (WeaponType)ex4;
				}
				return x._equipmentType;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v127 (Il2CppClass<VampireSurvivors.Framework.LevelUpFactory+<>c>)+B8]");
			object obj = (nint)0 + (nint)32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			nint num2 = unchecked((nint)null);
			selector = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = 6603577472L;
				object obj6 = obj3 & 0x3F;
				nint num4;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdi_v22+462E0+v303 @ rdx_v52*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdi_v22+462E0+v303 @ rdx_v52*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdi_v22+462E0+v303 @ rdx_v52*8]");
					if (num3 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdi_v22+462E0+v303 @ rdx_v52*8]");
					num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdi_v22+462E0+v303 @ rdx_v52*8]");
				}
				while (num4 != 0);
				num2 = unchecked((nint)null);
				selector = func;
			}
		}
		IEnumerable<WeaponType> enumerable = Enumerable.Select(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, selector);
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			IEnumerable<WeaponType> enumerable2 = Enumerable.Select((IEnumerable<Equipment>)0, selector);
		}
		if (enumerable != null)
		{
			List<System.Int32Enum> list2 = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			if (includePowerUps)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ stack_10+C8]");
				object obj9 = 0;
				Func<Equipment, WeaponType> selector2 = _003C_003Ec._003C_003E9__52_1;
				if (_003C_003Ec._003C_003E9__52_1 == null)
				{
					selector2 = (_003C_003Ec._003C_003E9__52_1 = delegate(Equipment x)
					{
						//IL_0035: Expected I4, but got O
						if ((object)x == null)
						{
							NullReferenceException ex4 = new NullReferenceException();
							return (WeaponType)ex4;
						}
						return x._equipmentType;
					});
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v94+28]");
				IEnumerable<WeaponType> enumerable3 = Enumerable.Select((IEnumerable<Equipment>)0, selector2);
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v25 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					IEnumerable<WeaponType> enumerable4 = Enumerable.Select((IEnumerable<Equipment>)0, selector2);
				}
				if (enumerable3 == null)
				{
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				}
				List<System.Int32Enum> collection = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v51 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				list2.InsertRange(0, collection);
				nint num2 = 0;
			}
			int num7 = 0;
			float num8 = (float)list2;
			object obj10 = default(object);
			object obj11 = default(object);
			object obj13 = default(object);
			object obj16 = default(object);
			object obj19 = default(object);
			List<WeaponData> list4 = default(List<WeaponData>);
			while (true)
			{
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ stack_-90_v16+1C]");
					if (obj11 != null)
					{
						break;
					}
					object obj12 = obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ stack_-90_v16+18]");
					if ((nint)obj12 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ stack_-90_v16+10]");
					object obj14 = 0;
					object obj15 = obj13 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD7E0");
					bool flag2 = obj16 != null;
					obj13 = obj15;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ stack_8+40]");
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = ((DataManager)0).GetConvertedWeapons();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rdx_v32+20+v1573 @ rcx_v48*4]");
						object obj17 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
						List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)obj17).get_Item(WeaponType.VOID);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rax_v80 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+191]");
						if ((nint)0 != 0)
						{
							object obj18 = obj19;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1643 @ rdx_v40+4E8] (should have been resolved before IL gen)");
						}
						else
						{
							num8 = 1f;
							list4 = list3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
						List<WeaponData> list5 = list4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rax_v80 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+9C]");
						object obj20 = list5 * 0;
						num7 += obj20;
						WeightedWeapon weightedWeapon = new WeightedWeapon();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rdx_v32+20+v359 @ stack_-88_v15*4]");
						weightedWeapon.Weapon = WeaponType.VOID;
						weightedWeapon.Weight = num7;
						List<WeaponData> list6 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)weightedWeapon);
						obj13 = obj15;
					}
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag3 = obj10 == null;
			List<System.Int32Enum> list7 = (List<System.Int32Enum>)0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ stack_-90_v16+1C]");
				if (obj11 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					bool flag4 = (nint)0 != 0;
					nint num9 = 0;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj21 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
						num9 = unchecked((nint)6573110936L);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1621 @ rax_v65 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
					return GetWeaponFromWeightedStore(list, 0.0);
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				list7 = null;
			}
			throw new NullReferenceException();
		}
		Exception ex3 = System.Linq.Error.ArgumentNull("source");
		throw ex3;
	}

	public unsafe WeaponType PullNewWeapon(VampireSurvivors.Objects.Characters.CharacterController character, bool includePowerUps = true)
	{
		//IL_009e: Expected O, but got I
		//IL_06b8: Expected I, but got O
		//IL_06ce: Expected O, but got I
		//IL_00e0: Expected O, but got I
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0069: Expected O, but got I8
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0127: Expected O, but got I
		//IL_090c: Expected O, but got I4
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0921: Expected O, but got Unknown
		//IL_0295: Expected F4, but got I4
		//IL_08ba: Expected O, but got I
		//IL_08dc: Expected O, but got Ref
		//IL_01a8: Expected O, but got I
		//IL_01ea: Expected O, but got I
		//IL_05d6: Expected O, but got I8
		List<WeightedWeapon> store = new List<WeightedWeapon>();
		CharacterWeaponsManager weaponsManager = character._weaponsManager;
		Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__53_0;
		if (_003C_003Ec._003C_003E9__53_0 == null)
		{
			Func<Equipment, WeaponType> func = (_003C_003Ec._003C_003E9__53_0 = delegate(Equipment x)
			{
				//IL_0035: Expected I4, but got O
				if ((object)x == null)
				{
					NullReferenceException ex4 = new NullReferenceException();
					return (WeaponType)ex4;
				}
				return x._equipmentType;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v111 (Il2CppClass<VampireSurvivors.Framework.LevelUpFactory+<>c>)+B8]");
			object obj = (nint)0 + (nint)48;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			selector = func;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdi_v17+462E0+v330 @ rdx_v47*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdi_v17+462E0+v330 @ rdx_v47*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdi_v17+462E0+v330 @ rdx_v47*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdi_v17+462E0+v330 @ rdx_v47*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rdi_v17+462E0+v330 @ rdx_v47*8]");
				}
				while (num3 != 0);
				selector = func;
			}
		}
		IEnumerable<WeaponType> enumerable = Enumerable.Select(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, selector);
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v13 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			IEnumerable<WeaponType> enumerable2 = Enumerable.Select((IEnumerable<Equipment>)0, selector);
		}
		if (enumerable != null)
		{
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v39 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+135]");
			object obj9 = (nint)0 & (nint)1;
			bool flag2 = obj9 == null;
			bool flag3 = !flag2;
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			object obj10 = default(object);
			bool flag4 = obj10 == null;
			IEnumerable<System.Int32Enum> enumerable3 = (IEnumerable<System.Int32Enum>)0;
			List<System.Int32Enum> list2 = list;
			if (!flag4)
			{
				CharacterAccessoriesManager accessoriesManager = character._accessoriesManager;
				Func<Equipment, WeaponType> selector2 = _003C_003Ec._003C_003E9__53_1;
				if (_003C_003Ec._003C_003E9__53_1 == null)
				{
					selector2 = (_003C_003Ec._003C_003E9__53_1 = delegate(Equipment x)
					{
						//IL_0035: Expected I4, but got O
						if ((object)x == null)
						{
							NullReferenceException ex4 = new NullReferenceException();
							return (WeaponType)ex4;
						}
						return x._equipmentType;
					});
				}
				IEnumerable<WeaponType> enumerable4 = Enumerable.Select(((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField, selector2);
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v19 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					IEnumerable<WeaponType> enumerable5 = Enumerable.Select((IEnumerable<Equipment>)0, selector2);
				}
				if (enumerable4 == null)
				{
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				}
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1360 @ rax_v84 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+135]");
				object obj11 = (nint)0 & (nint)1;
				bool flag5 = obj11 == null;
				flag3 = !flag5;
				List<System.Int32Enum> list3 = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable4);
				if (list == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rax_v41 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				list.InsertRange(0, list3);
				enumerable3 = list3;
				list2 = list;
			}
			LevelUpFactory levelUpFactory = default(LevelUpFactory);
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = levelUpFactory._data.GetConvertedWeapons();
			int num8 = 0;
			float num9 = 2f;
			Dictionary<WeaponType, List<WeaponData>> dictionary = convertedWeapons;
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
			if (enumerator.MoveNext())
			{
				IEnumerable<System.Int32Enum> enumerable6 = enumerable3;
				Dictionary<WeaponType, List<WeaponData>> dictionary2 = dictionary;
				bool flag6 = flag3;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
				WeaponType weaponType = WeaponType.VOID;
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag7 = (nint)0 != 0;
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator2 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)(&enumerator);
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj12 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				enumerator2 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1468 @ rax_v51 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			return GetWeaponFromWeightedStore(store, 0.0);
		}
		Exception ex3 = System.Linq.Error.ArgumentNull("source");
		throw ex3;
	}

	public WeaponType PullExisting(WeaponType weapontype)
	{
		//IL_0066: Expected I4, but got O
		//IL_0029: Expected I4, but got O
		_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass54_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.weapontype = weapontype;
			Predicate<WeightedWeapon> match = delegate(WeightedWeapon x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if (x == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				object obj = x.Weapon - CS_0024_003C_003E8__locals3.weapontype;
				return obj == null;
			};
			if (_weightedStore != null)
			{
				WeaponType weaponType = (WeaponType)_weightedStore.Find(match);
				if (weaponType != WeaponType.VOID)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v10 (VampireSurvivors.Data.WeaponType)+10]");
					return WeaponType.VOID;
				}
				return weaponType;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (WeaponType)ex;
	}

	private unsafe List<Equipment> GetAvailableEquipmentForEvolution(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_008b: Expected I, but got O
		//IL_00bc: Expected O, but got I
		//IL_00e6: Expected O, but got I
		//IL_040f: Expected O, but got I4
		//IL_057d: Expected I, but got O
		//IL_05aa: Expected I, but got O
		//IL_0529: Expected I, but got O
		//IL_0556: Invalid comparison between F4 and I4
		//IL_056a: Expected I, but got O
		List<Equipment> list = new List<Equipment>();
		bool flag = (object)character == null;
		List<Equipment> list2 = list;
		if (!flag)
		{
			CharacterWeaponsManager weaponsManager = character._weaponsManager;
			bool flag2 = (object)character._weaponsManager == null;
			list2 = list;
			if (!flag2)
			{
				bool flag3 = list == null;
				list2 = list;
				if (!flag3)
				{
					((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
					nint num = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v30 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num2 = 0;
					GameManager core = GM.Core;
					bool flag4 = (object)GM.Core == null;
					list2 = (List<Equipment>)num2;
					if (!flag4)
					{
						bool flag5 = core._multiplayer == null;
						list2 = (List<Equipment>)num2;
						if (!flag5)
						{
							int playerCount = core._multiplayer.GetPlayerCount();
							bool flag6 = playerCount > 1;
							list2 = (List<Equipment>)(object)core._multiplayer;
							if (!flag6)
							{
								bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
								bool flag7 = !isOnlineMultiplayer;
								list2 = (List<Equipment>)(object)core._multiplayer;
								if (flag7)
								{
									goto IL_0849;
								}
							}
							CoopConfig coopConfig = _coopConfig;
							if ((object)_coopConfig != null)
							{
								if (!coopConfig._shareEvolutionPassives)
								{
									goto IL_0849;
								}
								if (_playerOptions != null)
								{
									PlayerOptionsData config = _playerOptions.Config;
									if (config != null)
									{
										if (!config._003CSelectedSharePassives_003Ek__BackingField)
										{
											goto IL_0849;
										}
										GameManager core2 = GM.Core;
										if ((object)GM.Core != null && core2._mainCharacters != null)
										{
											List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
											if (enumerator.MoveNext())
											{
												List<Equipment> list3 = null;
												list2 = null;
												throw new NullReferenceException();
											}
											goto IL_08ba;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07c3;
		IL_08ba:
		return list;
		IL_0640:
		nint num4;
		nint num3 = num4;
		throw new NullReferenceException();
		IL_07c3:
		throw new NullReferenceException();
		IL_0849:
		if (character._PlayerIndex >> 31 == 0 || character.IsFollowerSharingPassives)
		{
			CharacterAccessoriesManager accessoriesManager = character._accessoriesManager;
			if ((object)character._accessoriesManager == null)
			{
				goto IL_07c3;
			}
			((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField);
		}
		GameManager core3 = GM.Core;
		if ((object)GM.Core == null || core3._mainCharacters == null)
		{
			goto IL_07c3;
		}
		LevelUpFactory levelUpFactory = this;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator2.MoveNext())
		{
			object obj = 0;
			int num5 = character._PlayerIndex >> 31;
			bool flag8 = num5 == 0;
			num4 = (nint)(&enumerator2);
			if (!flag8)
			{
				bool flag9 = !character.IsFollowerSharingPassives;
				num4 = (nint)(&enumerator2);
				if (!flag9)
				{
					CharacterADControl deficiencyControl = character._deficiencyControl;
					bool flag10 = character._deficiencyControl == null;
					num3 = (nint)(&enumerator2);
					if (!flag10)
					{
						levelUpFactory = (LevelUpFactory)(object)deficiencyControl._followedCharacter;
						bool flag11 = (object)deficiencyControl._followedCharacter == null;
						bool flag12 = !flag11;
						bool flag13 = !flag12;
						num3 = 1;
						if (!flag13)
						{
							if ((object)deficiencyControl._followedCharacter == null)
							{
								nint num6 = (nint)typeof(UnityEngine.Object);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rcx_v47 (Il2CppClass<UnityEngine.Object>)+E4]");
								flag13 = (nint)0 != 0;
								num3 = (nint)typeof(UnityEngine.Object);
								throw new NullReferenceException();
							}
							nint num7 = (nint)typeof(UnityEngine.Object);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1418 @ rcx_v48 (Il2CppClass<UnityEngine.Object>)+E4]");
							flag13 = (nint)0 != 0;
							bool flag14 = levelUpFactory._defaultXPFactor == 0f;
							num3 = (nint)typeof(UnityEngine.Object);
							bool flag15 = !flag14;
							num4 = num3;
							if (flag15)
							{
								goto IL_0640;
							}
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
			}
			goto IL_0640;
		}
		goto IL_08ba;
	}

	public bool HasPotentialEvolution(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_00bb: Expected O, but got I
		//IL_00da: Expected O, but got I
		List<Equipment> availableEquipmentForEvolution = GetAvailableEquipmentForEvolution(character);
		LinkedList<WeaponType>.Enumerator enumerator = default(LinkedList<WeaponType>.Enumerator);
		System.Int32Enum key = default(System.Int32Enum);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (_data == null)
				{
					break;
				}
				Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
				if (convertedWeapons != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(key);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v29 (System.Object)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v29 (System.Object)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v15+20]");
							if (HasEvolutionRequirements((WeaponData)0, availableEquipmentForEvolution, character))
							{
								return true;
							}
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						DataManager dataManager = null;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			return false;
		}
		throw new NullReferenceException();
	}

	public WeaponType PullEvolution(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_043b: Expected F8, but got I4
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0121: Expected O, but got I
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_0136: Expected O, but got I
		//IL_0150: Expected O, but got I
		//IL_044e: Expected O, but got F4
		//IL_0457: Invalid comparison between F4 and O
		List<WeightedWeapon> store = new List<WeightedWeapon>();
		List<Equipment> availableEquipmentForEvolution = GetAvailableEquipmentForEvolution(character);
		LinkedListNode<WeaponType> linkedListNode = _specialWeapons.Find(WeaponType.CANDYBOX2);
		if (linkedListNode != null)
		{
			LinkedListNode<WeaponType> linkedListNode2 = _specialWeapons.Find(WeaponType.CANDYBOX2);
		}
		LinkedList<WeaponType> specialWeapons = _specialWeapons;
		int num = 0;
		LinkedList<WeaponType>.Enumerator enumerator = default(LinkedList<WeaponType>.Enumerator);
		System.Int32Enum int32Enum = default(System.Int32Enum);
		while (enumerator.MoveNext())
		{
			if (_data != null)
			{
				Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
				if (convertedWeapons != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(int32Enum);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v85 (System.Object)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v85 (System.Object)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v56+20]");
							WeaponData weaponData = (WeaponData)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v56+20]");
							bool flag = HasEvolutionRequirements((WeaponData)0, availableEquipmentForEvolution, character);
							bool flag2 = !flag;
							VampireSurvivors.Objects.Characters.CharacterController characterController = character;
							if (!flag2)
							{
								num += weaponData._003Crarity_003Ek__BackingField;
								WeightedWeapon weightedWeapon = new WeightedWeapon();
								weightedWeapon.Weapon = (WeaponType)int32Enum;
								weightedWeapon.Weight = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4790");
								characterController = character;
							}
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						DataManager dataManager = null;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		float num2;
		if ((nint)linkedListNode > 0)
		{
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			PlayerModifierStats playerStats = activeCharacter._playerStats;
			EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
			num2 = eggFloat._eggVal + eggFloat._val;
			object obj3 = num2 & -2147483649L;
			if ((nint)obj3 != 2139095040)
			{
				object obj4 = num2 & -2147483649L;
				if ((nint)obj4 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877E1E2Ah\"");
					if (num2 == -1f / 0f)
					{
						num2 = -3.4028235E+38f;
					}
					goto IL_0414;
				}
			}
			num2 = 3.4028235E+38f;
			goto IL_0414;
		}
		goto IL_0429;
		IL_0440:
		WeaponType weaponType;
		return weaponType;
		IL_0429:
		double value = UnityEngine.Random.RandomRangeInt(0, num);
		weaponType = GetWeaponFromWeightedStore(store, value);
		if (weaponType != WeaponType.VOID)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1CF0");
		}
		CalculateWeights(character);
		goto IL_0440;
		IL_0414:
		float num3 = num2 * 0.01f;
		object obj5 = UnityEngine.Random.value;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<LinkedList<WeaponType>, UIntPtr>(ref _specialWeapons))
		{
			LinkedListNode<WeaponType> linkedListNode3 = _specialWeapons.AddLast(WeaponType.CANDYBOX2);
			goto IL_0429;
		}
		weaponType = WeaponType.CANDYBOX2;
		goto IL_0440;
	}

	private bool HasEvolutionRequirements(WeaponData data, List<Equipment> held, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_06ef: Expected O, but got I
		//IL_06b6: Expected I4, but got I8
		//IL_00da: Expected O, but got I
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0738: Expected O, but got I
		//IL_0214: Expected O, but got I
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0324: Expected O, but got I
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 103 Invalid \"Jump target not found in method: 0x1877E2AAF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 114 Invalid \"Jump target not found in method: 0x1877E2A35\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 127 Invalid \"Jump target not found in method: 0x1877E2A35\"");
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 148 Invalid \"Jump target not found in method: 0x1877E2AAF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 160 Invalid \"Jump target not found in method: 0x1877E2AAF\"");
		int playerCount = core._multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 206 Invalid \"Jump target not found in method: 0x1877E2AAF\"");
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core2._characters;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 218 Invalid \"Jump target not found in method: 0x1877E2AAF\"");
			if (characters._size <= 1)
			{
				goto IL_04f9;
			}
		}
		if (data._003CevolvesFrom_003Ek__BackingField == null)
		{
			goto IL_04f9;
		}
		object obj = default(object);
		object obj3 = default(object);
		object obj5 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 318 Invalid \"Jump target not found in method: 0x1877E2AD1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ stack_-A0_v11 (System.Object)+1C]");
			bool flag = obj != null;
			object obj2 = obj3;
			if (flag)
			{
				break;
			}
			object obj4 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ stack_-A0_v11 (System.Object)+18]");
			bool flag2 = (nint)obj4 >= 0;
			obj2 = obj3;
			if (flag2)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ stack_-A0_v11 (System.Object)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 356 Invalid \"Jump target not found in method: 0x1877E2AC0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 368 Invalid \"Jump target not found in method: 0x1877E2AB5\"");
			object obj7 = obj5 + 1;
			_003C_003Ec__DisplayClass58_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass58_0();
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 386 Invalid \"Jump target not found in method: 0x1877E2ABB\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rax_v118+20+v1121 @ stack_-98_v5*4]");
			CS_0024_003C_003E8__locals8.s = WeaponType.VOID;
			Func<Equipment, bool> predicate = delegate(Equipment x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj22 = x._equipmentType - CS_0024_003C_003E8__locals8.s;
				return obj22 == null;
			};
			object obj8 = Enumerable.FirstOrDefault(held, (Func<object, bool>)predicate);
			obj2 = obj8;
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1404 @ rax_v125 (System.Object)+10]");
				bool flag3 = (nint)0 != 0;
				obj5 = obj7;
				if (flag3)
				{
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 499 Invalid \"Jump target not found in method: 0x1877E2AAB\"");
			break;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 524 Invalid \"Jump target not found in method: 0x1877E2ACC\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 536 Invalid \"Jump target not found in method: 0x1877E2AC5\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rax_v112 (System.Object)+18]");
		object obj9 = (nint)0 + (nint)1;
		List<WeaponType> list = data._003CrequiresMax_003Ek__BackingField;
		obj5 = obj9;
		goto IL_056b;
		IL_04f9:
		list = data._003CrequiresMax_003Ek__BackingField;
		goto IL_056b;
		IL_056b:
		WeaponData weaponData = data;
		if (!data._003ChasUniqueRequirements_003Ek__BackingField)
		{
			if (data._003Crequires_003Ek__BackingField != null)
			{
				object obj11 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 662 Invalid \"Jump target not found in method: 0x1877E2AF8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ stack_-A0_v9 (System.Object)+1C]");
					bool flag4 = obj != null;
					object obj10 = obj11;
					if (flag4)
					{
						break;
					}
					object obj12 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ stack_-A0_v9 (System.Object)+18]");
					bool flag5 = (nint)obj12 >= 0;
					obj10 = obj11;
					if (flag5)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ stack_-A0_v9 (System.Object)+10]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 700 Invalid \"Jump target not found in method: 0x1877E2AE7\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 712 Invalid \"Jump target not found in method: 0x1877E2ADD\"");
					object obj14 = obj5 + 1;
					_003C_003Ec__DisplayClass58_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass58_1();
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 730 Invalid \"Jump target not found in method: 0x1877E2AE2\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rax_v79+20+v1121 @ stack_-98_v5*4]");
					CS_0024_003C_003E8__locals9.s = WeaponType.VOID;
					Func<Equipment, bool> predicate2 = delegate(Equipment x)
					{
						//IL_0053: Expected I4, but got O
						//IL_0031: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj22 = x._equipmentType - CS_0024_003C_003E8__locals9.s;
						return obj22 == null;
					};
					object obj15 = Enumerable.FirstOrDefault(held, (Func<object, bool>)predicate2);
					obj10 = obj15;
					if (obj15 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rax_v86 (System.Object)+10]");
						bool flag6 = (nint)0 != 0;
						obj5 = obj14;
						if (flag6)
						{
							continue;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 843 Invalid \"Jump target not found in method: 0x1877E2AAB\"");
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 868 Invalid \"Jump target not found in method: 0x1877E2AF3\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 880 Invalid \"Jump target not found in method: 0x1877E2AEC\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1261 @ rax_v73 (System.Object)+18]");
				object obj16 = (nint)0 + (nint)1;
				list = data._003CrequiresMax_003Ek__BackingField;
				obj5 = obj16;
			}
			bool flag7 = list == null;
			weaponData = data;
			if (!flag7)
			{
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 992 Invalid \"Jump target not found in method: 0x1877E2B2E\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ stack_-A0_v7+1C]");
					if (obj != null)
					{
						break;
					}
					object obj17 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ stack_-A0_v7+18]");
					if ((nint)obj17 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ stack_-A0_v7+10]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1030 Invalid \"Jump target not found in method: 0x1877E2B1D\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1042 Invalid \"Jump target not found in method: 0x1877E2B04\"");
					object obj19 = obj5 + 1;
					_003C_003Ec__DisplayClass58_2 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass58_2();
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1060 Invalid \"Jump target not found in method: 0x1877E2B18\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1359 @ rax_v39+20+v1121 @ stack_-98_v5*4]");
					CS_0024_003C_003E8__locals12.s = WeaponType.VOID;
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1074 Invalid \"Jump target not found in method: 0x1877E2B13\"");
					Dictionary<WeaponType, List<WeaponData>> convertedWeapons = ((DataManager)(object)((WeaponData)this)._003CframeName_003Ek__BackingField).GetConvertedWeapons();
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1087 Invalid \"Jump target not found in method: 0x1877E2B0E\"");
					object obj20 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals12.s);
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1102 Invalid \"Jump target not found in method: 0x1877E2B09\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rax_v44 (System.Object)+18]");
					CS_0024_003C_003E8__locals12.maxLv = 0;
					Func<Equipment, bool> predicate3 = delegate(Equipment x)
					{
						//IL_00cc: Expected I4, but got O
						//IL_005a: Expected O, but got I4
						//IL_007b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0080: Expected I4, but got Unknown
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						if (x._equipmentType != CS_0024_003C_003E8__locals12.s)
						{
							return false;
						}
						object obj22 = x._003CLevel_003Ek__BackingField - CS_0024_003C_003E8__locals12.maxLv;
						int num = x._003CLevel_003Ek__BackingField ^ CS_0024_003C_003E8__locals12.maxLv;
						int num2 = x._003CLevel_003Ek__BackingField ^ obj22;
						int num3 = num & num2;
						bool flag10 = num3 < 0;
						bool flag11 = (nint)obj22 < 0;
						return flag11 == flag10;
					};
					object obj21 = Enumerable.FirstOrDefault(held, (Func<object, bool>)predicate3);
					if (obj21 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1590 @ rax_v48 (System.Object)+10]");
						bool flag8 = (nint)0 != 0;
						obj5 = obj19;
						if (flag8)
						{
							continue;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1215 Invalid \"Jump target not found in method: 0x1877E2AAB\"");
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1240 Invalid \"Jump target not found in method: 0x1877E2B29\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1252 Invalid \"Jump target not found in method: 0x1877E2B22\"");
				weaponData = (WeaponData)(object)this;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1273 Invalid \"Jump target not found in method: 0x1877E2A35\"");
		}
		bool flag9 = (byte)weaponData._003CbulletType_003Ek__BackingField != 0;
		if (weaponData._003CbulletType_003Ek__BackingField == WeaponType.EME_MAGIC2)
		{
			flag9 = CalamityRingUniqueRequirements(held);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1337 Invalid \"Jump target not found in method: 0x1877E2A35\"");
		}
		if ((flag9 ? 1 : 0) == 1451)
		{
			flag9 = AlucardShieldUniqueRequirements(held);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1367 Invalid \"Jump target not found in method: 0x1877E2A35\"");
		}
		bool result = (byte)((flag9 ? 1 : 0) + 4294965594L) != 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1382 Invalid \"Jump target not found in method: 0x1877E2AAB\"");
		return result;
	}

	public static bool CheckUniqueRequirements(WeaponData data, List<Equipment> held, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_00c0: Expected I4, but got O
		//IL_00f4: Expected O, but got I8
		//IL_0087: Expected O, but got I8
		//IL_00a1: Expected O, but got I8
		if (data != null)
		{
			if (data._003CbulletType_003Ek__BackingField == WeaponType.EME_MAGIC2)
			{
				return CalamityRingUniqueRequirements(held);
			}
			if (data._003CbulletType_003Ek__BackingField == WeaponType.TP_ALUCARDSHIELD)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 104 Invalid \"Jump target not found in method: 0x1877E2D10\"");
			}
			object obj = (long)data._003CbulletType_003Ek__BackingField + 4294965594L;
			if ((nint)obj <= 6)
			{
				object obj2 = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v2+77E2CF4+v125 @ rax_v5*4]");
				object obj3 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v145 @ rcx_v4 (should have been resolved before IL gen)");
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static bool AlucardShieldUniqueRequirements(List<Equipment> held)
	{
		//IL_00f0: Expected O, but got I4
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected I4, but got Unknown
		Func<Equipment, bool> predicate = _003C_003Ec._003C_003E9__60_0;
		if (_003C_003Ec._003C_003E9__60_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__60_0 = delegate(Equipment o)
			{
				//IL_0098: Expected I4, but got O
				if ((object)o != null)
				{
					if (o.IsMaxLevel())
					{
						if (o._currentJsonDataObject == null)
						{
							goto IL_008a;
						}
						object obj2 = o._currentJsonDataObject.ToObject<object>();
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v7 (System.Object)+60]");
							return false;
						}
					}
					return false;
				}
				goto IL_008a;
				IL_008a:
				NullReferenceException ex3 = new NullReferenceException();
				return (byte)(int)ex3 != 0;
			});
		}
		IEnumerable<Equipment> enumerable = Enumerable.Where(held, predicate);
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			Func<Equipment, bool> predicate2 = _003C_003Ec._003C_003E9__60_1;
			if (_003C_003Ec._003C_003E9__60_1 == null)
			{
				predicate2 = (_003C_003Ec._003C_003E9__60_1 = delegate(Equipment o)
				{
					//IL_007d: Expected I4, but got O
					//IL_0045: Expected I, but got O
					//IL_0055: Expected O, but got I
					//IL_0065: Expected O, but got I
					if ((object)o != null)
					{
						bool flag3 = o.IsMaxLevel();
						if (!flag3)
						{
							return flag3;
						}
						nint num4 = (nint)o;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1E8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1F0]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v39 @ rax_v3 (should have been resolved before IL gen)");
					}
					NullReferenceException ex3 = new NullReferenceException();
					return (byte)(int)ex3 != 0;
				});
			}
			IEnumerable<Equipment> enumerable2 = Enumerable.Where(held, predicate2);
			if (enumerable2 != null)
			{
				List<object> list2 = new List<object>(enumerable2);
				if (list._size < 6)
				{
					return false;
				}
				object obj = list2._size - 6;
				int num = list2._size ^ 6;
				int num2 = list2._size ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private static bool CalamityRingUniqueRequirements(List<Equipment> held)
	{
		//IL_0144: Expected I4, but got O
		//IL_0085: Expected O, but got I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected I4, but got Unknown
		Func<Equipment, bool> predicate = _003C_003Ec._003C_003E9__61_0;
		if (_003C_003Ec._003C_003E9__61_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__61_0 = delegate(Equipment o)
			{
				//IL_007d: Expected I4, but got O
				//IL_0045: Expected I, but got O
				//IL_0055: Expected O, but got I
				//IL_0065: Expected O, but got I
				if ((object)o != null)
				{
					bool flag3 = o.IsMaxLevel();
					if (!flag3)
					{
						return flag3;
					}
					nint num4 = (nint)o;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1E8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+1F0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v39 @ rax_v3 (should have been resolved before IL gen)");
				}
				NullReferenceException ex3 = new NullReferenceException();
				return (byte)(int)ex3 != 0;
			});
		}
		IEnumerable<Equipment> enumerable = Enumerable.Where(held, predicate);
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			if (list != null)
			{
				object obj = list._size - 5;
				int num = list._size ^ 5;
				int num2 = list._size ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private static bool SaboteurWeaponsUniqueRequirements(WeaponType currentWeaponType, List<Equipment> held, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_022d: Expected I4, but got O
		_003C_003Ec__DisplayClass62_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass62_0();
		Equipment equipment3;
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.currentWeaponType = currentWeaponType;
			Predicate<Equipment> match = delegate(Equipment x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				object obj = x._equipmentType - CS_0024_003C_003E8__locals3.currentWeaponType;
				return obj == null;
			};
			if (held != null)
			{
				Equipment equipment = held.Find(match);
				if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0 && !equipment.IsMaxLevel())
				{
					goto IL_0211;
				}
				Predicate<Equipment> match2 = _003C_003Ec._003C_003E9__62_1;
				if (_003C_003Ec._003C_003E9__62_1 == null)
				{
					match2 = (_003C_003Ec._003C_003E9__62_1 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex2 = new NullReferenceException();
							return (byte)(int)ex2 != 0;
						}
						object obj = x._equipmentType - 1700;
						return obj == null;
					});
				}
				Equipment equipment2 = held.Find(match2);
				if ((object)equipment2 != null)
				{
					bool flag = ((UnityEngine.Object)equipment2).m_CachedPtr != (IntPtr)0;
					equipment3 = equipment2;
					if (flag)
					{
						goto IL_01dd;
					}
				}
				if ((object)characterController != null)
				{
					CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
					if ((object)characterController._accessoriesManager != null)
					{
						Predicate<Equipment> match3 = _003C_003Ec._003C_003E9__62_2;
						if (_003C_003Ec._003C_003E9__62_2 == null)
						{
							match3 = (_003C_003Ec._003C_003E9__62_2 = delegate(Equipment x)
							{
								//IL_0052: Expected I4, but got O
								//IL_0030: Expected O, but got I4
								if ((object)x == null)
								{
									NullReferenceException ex2 = new NullReferenceException();
									return (byte)(int)ex2 != 0;
								}
								object obj = x._equipmentType - 1700;
								return obj == null;
							});
						}
						if (((EquipmentManager)accessoriesManager)._003CRemovedEquipment_003Ek__BackingField != null)
						{
							Equipment equipment4 = ((EquipmentManager)accessoriesManager)._003CRemovedEquipment_003Ek__BackingField.Find(match3);
							if ((object)equipment4 != null)
							{
								bool flag2 = ((UnityEngine.Object)equipment4).m_CachedPtr == (IntPtr)0;
								equipment3 = equipment4;
								if (!flag2)
								{
									goto IL_01dd;
								}
							}
							goto IL_0211;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0211:
		return false;
		IL_01dd:
		if (equipment3.IsMaxLevel())
		{
			return true;
		}
		goto IL_0211;
	}

	public void InitialiseWeights()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x1877E3820\"");
		throw new NullReferenceException();
	}

	public unsafe void CalculateWeights(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_004e: Expected O, but got I4
		//IL_0056: Expected O, but got Ref
		//IL_013e: Expected O, but got I4
		//IL_0146: Expected O, but got Ref
		//IL_02ae: Expected F4, but got I4
		//IL_02bc: Expected I, but got O
		_accumulatedWeight = 0;
		List<WeightedWeapon> weightedStore = new List<WeightedWeapon>();
		_weightedStore = weightedStore;
		List<WeaponType> list = new List<WeaponType>();
		List<WeaponType> list2 = new List<WeaponType>();
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
		if (enumerator3.MoveNext())
		{
			object obj2 = 0;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
		LevelUpFactory levelUpFactory = default(LevelUpFactory);
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = levelUpFactory._data.GetConvertedWeapons();
		LevelUpFactory levelUpFactory2 = levelUpFactory;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator4 = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		if (enumerator4.MoveNext())
		{
			_003C_003Ec__DisplayClass64_0 obj3 = new _003C_003Ec__DisplayClass64_0();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			float num = 0f;
			nint num2 = (nint)typeof(_003C_003Ec__DisplayClass64_0);
			throw new NullReferenceException();
		}
	}

	public unsafe List<WeaponType> GetLevelUpPowerups(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0dd7: Expected O, but got Ref
		//IL_0072: Expected O, but got Ref
		//IL_0215: Expected O, but got Ref
		//IL_0235: Expected O, but got Ref
		//IL_0731: Expected I, but got O
		//IL_0741: Expected O, but got I
		//IL_0751: Expected O, but got I
		//IL_041e: Expected O, but got I
		//IL_042e: Expected O, but got I
		//IL_0808: Expected I, but got O
		//IL_0839: Expected O, but got I
		//IL_05ca: Expected O, but got I
		//IL_05da: Expected O, but got I
		//IL_04a7: Expected O, but got I
		//IL_0f23: Expected O, but got I
		//IL_0659: Expected O, but got I
		//IL_063e: Expected O, but got I
		//IL_04ee: Expected O, but got Ref
		//IL_0878: Expected O, but got I
		//IL_0698: Expected O, but got I
		//IL_06a6: Expected O, but got Ref
		//IL_0c23: Expected O, but got Ref
		//IL_0b45: Expected O, but got I
		//IL_0b55: Expected O, but got I
		//IL_0939: Expected O, but got I4
		//IL_0a29: Expected O, but got I4
		//IL_0bd9: Expected O, but got I
		//IL_0bb8: Expected O, but got I4
		//IL_0bbe: Expected O, but got I
		//IL_0a62: Expected O, but got I4
		//IL_0c15: Expected O, but got I
		//IL_0a81: Expected O, but got Ref
		bool flag = (object)character == null;
		LevelUpFactory levelUpFactory = this;
		List<WeaponType> list2;
		if (!flag)
		{
			CharacterWeaponsManager weaponsManager = character._weaponsManager;
			bool flag2 = (object)character._weaponsManager == null;
			levelUpFactory = this;
			if (!flag2)
			{
				bool flag3 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
				levelUpFactory = this;
				if (!flag3)
				{
					List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
					if (enumerator.MoveNext())
					{
						Dictionary<System.Int32Enum, object> dictionary = null;
						Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&enumerator);
						throw new NullReferenceException();
					}
					CharacterAccessoriesManager accessoriesManager = character._accessoriesManager;
					bool flag4 = (object)character._accessoriesManager == null;
					levelUpFactory = (LevelUpFactory)(&enumerator);
					if (!flag4)
					{
						List<Equipment> list = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
						bool flag5 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField == null;
						levelUpFactory = (LevelUpFactory)(&enumerator);
						if (!flag5)
						{
							List<Equipment>.Enumerator enumerator2 = default(List<Equipment>.Enumerator);
							if (enumerator2.MoveNext())
							{
								Dictionary<System.Int32Enum, object> dictionary3 = null;
								Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&enumerator2);
								throw new NullReferenceException();
							}
							list2 = new List<WeaponType>();
							WeaponType randomExistingWeapon = GetRandomExistingWeapon(character);
							bool flag6 = randomExistingWeapon == WeaponType.VOID;
							string text = (string)(object)list;
							if (flag6)
							{
								goto IL_0526;
							}
							bool flag7 = list2 == null;
							levelUpFactory = this;
							if (!flag7)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								levelUpFactory = (LevelUpFactory)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v58+18]");
									if (num >= 0)
									{
										((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)randomExistingWeapon);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										object obj2 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										nint num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v58+18]");
										if (num2 >= 0)
										{
											goto IL_0eab;
										}
									}
									bool flag8 = !_useDebugLog;
									text = (string)(object)list;
									if (!flag8)
									{
										IntPtr intPtr = default(IntPtr);
										string text2 = ((Enum)(&intPtr)).ToString();
										string message = "LUF : " + text2 + " added to Level Up Pool (slot1)";
										Debug.Log(message);
										text = null;
									}
									goto IL_0526;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0c78;
		IL_0eab:
		return (List<WeaponType>)(object)new IndexOutOfRangeException();
		IL_0c78:
		throw new NullReferenceException();
		IL_0526:
		WeaponType randomExistingWeapon2 = GetRandomExistingWeapon(character);
		bool flag9 = randomExistingWeapon2 == WeaponType.VOID;
		string text3 = null;
		if (!flag9)
		{
			bool flag10 = list2 == null;
			levelUpFactory = this;
			if (flag10)
			{
				goto IL_0c78;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj3 = default(object);
			bool flag11 = obj3 != null;
			text3 = null;
			if (!flag11)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				levelUpFactory = (LevelUpFactory)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 == 0)
				{
					goto IL_0c78;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v52+18]");
				if (num3 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)randomExistingWeapon2);
					text3 = (string)0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj5 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v52+18]");
					if (num4 >= 0)
					{
						goto IL_0eab;
					}
					text3 = (string)0;
				}
				if (_useDebugLog)
				{
					IntPtr intPtr2 = default(IntPtr);
					string text4 = ((Enum)(&intPtr2)).ToString();
					string message2 = "LUF : " + text4 + " added to Level Up Pool (slot2)";
					Debug.Log(message2);
					text3 = " added to Level Up Pool (slot2)";
					string text = null;
				}
			}
		}
		int levelUpOptions = GetLevelUpOptions();
		bool flag12 = !character.HasFourthLevelUpOption;
		int num5 = levelUpOptions;
		VampireSurvivors.Objects.Characters.CharacterController characterController = null;
		WeaponType weaponType = WeaponType.VOID;
		if (!flag12)
		{
			nint num6 = (nint)character;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1817 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+358]");
			text3 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1817 @ rdx_v49 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+360]");
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)0;
			WeaponType fourthLevelUpOption = character.GetFourthLevelUpOption();
			bool flag13 = fourthLevelUpOption == WeaponType.VOID;
			num5 = levelUpOptions;
			weaponType = fourthLevelUpOption;
			if (!flag13)
			{
				bool flag14 = levelUpOptions != 4;
				num5 = levelUpOptions;
				weaponType = fourthLevelUpOption;
				if (!flag14)
				{
					num5 = 3;
					weaponType = fourthLevelUpOption;
				}
			}
		}
		levelUpFactory = (LevelUpFactory)(object)character._weaponsManager;
		if ((object)character._weaponsManager != null)
		{
			bool useDebugLog = levelUpFactory._useDebugLog;
			if (~(levelUpFactory._useDebugLog ? 1u : 0u) == 0)
			{
				nint num7 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v53 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num8 = 0;
				GameManager core = GM.Core;
				bool flag15 = (object)GM.Core == null;
				levelUpFactory = (LevelUpFactory)num8;
				if (!flag15)
				{
					bool flag16 = core._mainCharacters == null;
					levelUpFactory = (LevelUpFactory)num8;
					if (!flag16)
					{
						List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
						bool flag17 = mainCharacters._size <= 1;
						levelUpFactory = (LevelUpFactory)num8;
						if (!flag17)
						{
							CalculateWeights(character);
							characterController = character;
							text3 = null;
							levelUpFactory = this;
						}
					}
					if (list2 != null)
					{
						int num9 = 0;
						object obj7 = default(object);
						object obj8 = default(object);
						IntPtr intPtr3 = default(IntPtr);
						int num10 = default(int);
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							if ((nint)0 >= (nint)num5 || num9 >= 1000)
							{
								break;
							}
							num9++;
							WeaponType weaponType2;
							string text5;
							if (character._level <= 3)
							{
								object obj6 = character._maxWeaponBonus + character._maxWeaponCount;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v52 (System.Boolean)+18]");
								if (0 < (nint)obj6)
								{
									WeaponType randomWeightedWeapon = GetRandomWeightedWeapon(character);
									bool flag18 = randomWeightedWeapon == WeaponType.VOID;
									text3 = null;
									if (!flag18)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
										bool flag19 = obj7 == null;
										text3 = null;
										weaponType2 = randomWeightedWeapon;
										text5 = null;
										if (flag19)
										{
											goto IL_0a05;
										}
									}
								}
							}
							WeaponType randomWeightedWeaponOrPowerUp = GetRandomWeightedWeaponOrPowerUp();
							bool flag20 = randomWeightedWeaponOrPowerUp == WeaponType.VOID;
							weaponType2 = randomWeightedWeaponOrPowerUp;
							text5 = text3;
							characterController = null;
							if (flag20)
							{
								continue;
							}
							goto IL_0a05;
							IL_0a05:
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
							bool flag21 = obj8 != null;
							characterController = (VampireSurvivors.Objects.Characters.CharacterController)weaponType2;
							text3 = text5;
							if (!flag21)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
								bool flag22 = !_useDebugLog;
								characterController = (VampireSurvivors.Objects.Characters.CharacterController)weaponType2;
								text3 = text5;
								if (!flag22)
								{
									string text6 = ((Enum)(&intPtr3)).ToString();
									string text7 = num10.ToString();
									string message3 = "LUF : " + text6 + " added to Level Up Pool (slot3 : " + text7;
									Debug.Log(message3);
									characterController = null;
									text3 = " added to Level Up Pool (slot3 : ";
									string text = text7;
								}
							}
						}
						if (weaponType != WeaponType.VOID)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
							object obj9 = default(object);
							if (obj9 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								characterController = (VampireSurvivors.Objects.Characters.CharacterController)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								levelUpFactory = (LevelUpFactory)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								if ((nint)0 == 0)
								{
									goto IL_0c78;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								if (0 >= (nint)((MonoBehaviour)characterController).m_CancellationTokenSource)
								{
									((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)weaponType);
									characterController = (VampireSurvivors.Objects.Characters.CharacterController)weaponType;
									text3 = (string)0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									object obj10 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									if (0 >= (nint)((MonoBehaviour)characterController).m_CancellationTokenSource)
									{
										goto IL_0eab;
									}
									text3 = (string)0;
								}
							}
							else
							{
								IntPtr intPtr4 = default(IntPtr);
								string text8 = ((Enum)(&intPtr4)).ToString();
								string message4 = "Already displaying " + text8 + " as one of the 3 original options. Skipping duplicate as 4th pick.";
								Debug.Log(message4);
								characterController = null;
								text3 = " as one of the 3 original options. Skipping duplicate as 4th pick.";
								string text = null;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F650");
						return list2;
					}
				}
			}
		}
		goto IL_0c78;
	}

	public List<ItemType> GetLevelUpItems()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0333: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_01d4: Expected O, but got I
		//IL_022e: Expected O, but got I
		//IL_037d: Expected O, but got I
		//IL_02c2: Expected O, but got I
		List<ItemType> list = new List<ItemType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
			if (num2 >= 0)
			{
				goto IL_0338;
			}
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)12);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v6+18]");
			if (num4 >= 0)
			{
				goto IL_0338;
			}
			_ = 12;
		}
		PlayerOptions playerOptions = _playerOptions;
		if (!HasEnoughCoinBag2Pickups(playerOptions._mainGameConfig))
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (!HasEnoughCoinBag2Pickups(config))
			{
				goto IL_0355;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)41);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v12+18]");
			if (num6 >= 0)
			{
				goto IL_0338;
			}
			_ = 41;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)42);
			return list;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		object obj8 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14+18]");
		if (num8 >= 0)
		{
			goto IL_0338;
		}
		_ = 42;
		goto IL_0355;
		IL_0338:
		return (List<ItemType>)(object)new IndexOutOfRangeException();
		IL_0355:
		return list;
	}

	private bool HasEnoughCoinBag2Pickups(PlayerOptionsData config)
	{
		//IL_0112: Expected I4, but got O
		//IL_00ab: Expected O, but got I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected I4, but got Unknown
		if (config != null && config._003CPickupCount_003Ek__BackingField != null)
		{
			int num = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.COINBAG2);
			if (num < 0)
			{
				return false;
			}
			if (config._003CPickupCount_003Ek__BackingField != null)
			{
				int num2 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.COINBAG2);
				object obj = num2 - 100;
				int num3 = num2 ^ 0x64;
				int num4 = num2 ^ obj;
				int num5 = num3 & num4;
				bool flag = num5 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void RemoveFromStore(WeaponType weapon, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1CF0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BD7E0");
		object obj = default(object);
		if (obj == null)
		{
			LinkedListNode<WeaponType> linkedListNode = _excludedWeapons.AddLast(weapon);
		}
		CalculateWeights(character);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4120");
	}

	public void RemoveFromSpecialWeapons(WeaponType weapon)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1CF0");
	}

	public WeaponType GetRandomExistingWeapon(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_059a: Expected I4, but got O
		//IL_00e8: Expected O, but got I4
		//IL_05e7: Expected O, but got I4
		//IL_02ad: Expected I, but got O
		//IL_0366: Expected O, but got I
		//IL_0383: Invalid comparison between F4 and I4
		//IL_04ed: Expected O, but got I
		//IL_03b4: Expected O, but got I
		//IL_0493: Expected O, but got I
		//IL_03f1: Expected O, but got I
		//IL_0439: Expected O, but got I
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		random._002Ector(seed);
		if (random != null)
		{
			double num = random.NextDouble();
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				if ((object)gameSessionData._activeCharacter != null)
				{
					int num2 = activeCharacter._level & 1;
					bool flag = num2 == 0;
					bool flag2 = num2 < 0;
					GameSessionData gameSessionData2 = _gameSessionData;
					object obj = !flag;
					if (obj == null)
					{
					}
					float num3 = gameSessionData2._activeCharacter.PLuck();
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm8\"");
					bool flag3 = !flag2;
					object obj2 = !flag3;
					if (obj2 != null)
					{
						goto IL_054b;
					}
					GameSessionData gameSessionData3 = _gameSessionData;
					if (_gameSessionData != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData3._activeCharacter;
						if ((object)gameSessionData3._activeCharacter != null)
						{
							CharacterWeaponsManager weaponsManager = activeCharacter2._weaponsManager;
							if ((object)activeCharacter2._weaponsManager != null)
							{
								List<Equipment> list = (List<Equipment>)(object)new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
								GameSessionData gameSessionData4 = _gameSessionData;
								if (_gameSessionData != null)
								{
									VampireSurvivors.Objects.Characters.CharacterController activeCharacter3 = gameSessionData4._activeCharacter;
									if ((object)gameSessionData4._activeCharacter != null)
									{
										CharacterAccessoriesManager accessoriesManager = activeCharacter3._accessoriesManager;
										if ((object)activeCharacter3._accessoriesManager != null && list != null)
										{
											IEnumerable<object> collection = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
											((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField);
											int num7 = default(int);
											object obj3 = default(object);
											object obj5 = default(object);
											object obj6 = default(object);
											while (list._size > 0)
											{
												double num4 = random.NextDouble();
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm7\"");
												int index;
												if (list._size <= 0)
												{
													nint num5 = (nint)random;
													double num6 = random.NextDouble();
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rdx_v32 (Il2CppClass<System.Random>)+1C0]");
													((List<Equipment>)(object)random).InsertRange(0, (IEnumerable<Equipment>)collection);
													index = num7;
												}
												else
												{
													index = 0;
												}
												list.InsertRange(index, (IEnumerable<Equipment>)collection);
												if (obj3 != null)
												{
													GameSessionData gameSessionData5 = _gameSessionData;
													if (_gameSessionData != null)
													{
														VampireSurvivors.Objects.Characters.CharacterController activeCharacter4 = gameSessionData5._activeCharacter;
														if ((object)gameSessionData5._activeCharacter != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v34 (System.Object)+4C]");
															object obj4 = (nint)0 + (nint)1;
															float num8 = (float)obj4 * 2.5f;
															string text;
															string text2;
															string text3;
															if (num8 > (float)activeCharacter4._level)
															{
																bool flag4 = ((List<object>)(object)list).Remove(obj3);
																bool flag5 = !_useDebugLog;
																collection = (IEnumerable<object>)0;
																if (flag5)
																{
																	continue;
																}
																text = obj3.ToString();
																text2 = "LUF : Removing ";
																text3 = " from upgrade pool as it is too strong for current player level.";
															}
															else
															{
																if (_banishedWeapons == null)
																{
																	goto IL_058c;
																}
																LinkedList<WeaponType> banishedWeapons = _banishedWeapons;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v34 (System.Object)+48]");
																((List<Equipment>)(object)banishedWeapons).InsertRange(0, (IEnumerable<Equipment>)0);
																if (obj5 != null)
																{
																	bool flag6 = ((List<object>)(object)list).Remove(obj3);
																	bool flag7 = !_useDebugLog;
																	collection = (IEnumerable<object>)0;
																	if (flag7)
																	{
																		continue;
																	}
																	text = obj3.ToString();
																	text2 = "LUF : Removing ";
																	text3 = " from upgrade pool as it has been banished.";
																}
																else
																{
																	if (_weaponStore == null)
																	{
																		goto IL_058c;
																	}
																	LinkedList<WeaponType> weaponStore = _weaponStore;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v34 (System.Object)+48]");
																	((List<Equipment>)(object)weaponStore).InsertRange(0, (IEnumerable<Equipment>)0);
																	if (obj6 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v34 (System.Object)+48]");
																		return WeaponType.VOID;
																	}
																	bool flag8 = ((List<object>)(object)list).Remove(obj3);
																	bool flag9 = !_useDebugLog;
																	collection = (IEnumerable<object>)0;
																	if (flag9)
																	{
																		continue;
																	}
																	text = obj3.ToString();
																	text2 = "LUF : Removing ";
																	text3 = " from upgrade pool as there are no instances left in the Weapon Store.";
																}
															}
															string message = text2 + text + text3;
															Debug.Log(message);
															collection = (IEnumerable<object>)(object)text3;
															continue;
														}
													}
												}
												goto IL_058c;
											}
											goto IL_054b;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_058c;
		IL_058c:
		NullReferenceException ex = new NullReferenceException();
		return (WeaponType)ex;
		IL_054b:
		if (_useDebugLog)
		{
			Debug.Log("LUF : Failed roll to upgrade existing weapon directly");
		}
		return WeaponType.VOID;
	}

	public bool DoesWeaponStoreContainWeaponType(WeaponType weaponType)
	{
		//IL_0044: Expected I4, but got O
		if (_weaponStore != null)
		{
			LinkedListNode<WeaponType> linkedListNode = _weaponStore.Find(weaponType);
			bool flag = linkedListNode == null;
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void RemoveFromExcluded(GameplaySignals.RemoveWeaponFromExcluded signal)
	{
		//IL_000a: Expected I4, but got O
		RemoveFromExcluded((WeaponType)signal);
	}

	public unsafe void RemoveFromExcluded(WeaponType type)
	{
		//IL_00ea: Expected I4, but got O
		//IL_010f: Expected O, but got Ref
		LinkedListNode<WeaponType> linkedListNode = _banishedWeapons.Find(type);
		if (linkedListNode != null)
		{
			return;
		}
		LinkedListNode<WeaponType> linkedListNode2 = _excludedWeapons.Find(type);
		if (linkedListNode2 == null)
		{
			return;
		}
		while (true)
		{
			LinkedListNode<WeaponType> linkedListNode3 = _excludedWeapons.Find(type);
			if (linkedListNode3 == null)
			{
				break;
			}
			LinkedListNode<WeaponType> linkedListNode4 = _excludedWeapons.Find(type);
			if (linkedListNode4 != null)
			{
				_excludedWeapons.InternalRemoveNode(linkedListNode4);
			}
		}
		object obj = default(object);
		object arg = (WeaponType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Unexcluded weapon: {0}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
	}

	public void BanishedSealedWeapons()
	{
		//IL_056f: Expected O, but got I4
		//IL_0578: Expected O, but got I4
		//IL_02b6: Expected O, but got I4
		//IL_02bf: Expected O, but got I4
		//IL_01df: Expected O, but got I
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_049e: Expected O, but got I
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected O, but got Unknown
		PlayerOptions playerOptions = _playerOptions;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
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
							goto IL_05a2;
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
			goto IL_05a2;
			IL_05d9:
			PlayerOptionsData playerOptionsData2;
			List<WeaponType> list = playerOptionsData2._003CSealedWeapons_003Ek__BackingField;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)obj3 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj4 = 0;
			LinkedList<WeaponType> banishedWeapons = _banishedWeapons;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v14+20+v59 @ rdi_v5*4]");
			LinkedListNode<WeaponType> linkedListNode = banishedWeapons.Find(WeaponType.VOID);
			if (linkedListNode == null)
			{
				LinkedList<WeaponType> excludedWeapons = _excludedWeapons;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v14+20+v59 @ rdi_v5*4]");
				LinkedListNode<WeaponType> linkedListNode2 = excludedWeapons.AddLast(WeaponType.VOID);
				LinkedList<WeaponType> banishedWeapons2 = _banishedWeapons;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v14+20+v59 @ rdi_v5*4]");
				LinkedListNode<WeaponType> linkedListNode3 = banishedWeapons2.AddLast(WeaponType.VOID);
			}
			playerOptions = _playerOptions;
			obj2++;
			bool flag = _playerOptions != null;
			obj = obj2;
			if (flag)
			{
				continue;
			}
			throw new NullReferenceException();
			IL_05a2:
			List<WeaponType> list2 = playerOptionsData._003CSealedWeapons_003Ek__BackingField;
			PlayerOptions playerOptions2 = _playerOptions;
			object obj5 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)obj5 >= 0)
			{
				object obj6 = 0;
				object obj7 = 0;
				while (true)
				{
					PlayerOptionsData playerOptionsData3;
					if (playerOptions2._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions2._hostGameConfig == null)
						{
							if (playerOptions2._currentAdventureSaveData != null)
							{
								playerOptionsData3 = playerOptions2._currentAdventureSaveData;
								if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_0622;
								}
							}
							playerOptionsData3 = playerOptions2._mainGameConfig;
						}
						else
						{
							playerOptionsData3 = playerOptions2._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
					}
					goto IL_0622;
					IL_0659:
					PlayerOptionsData playerOptionsData4;
					List<WeaponType> list3 = playerOptionsData4._003CContentGroupSealedWeapons_003Ek__BackingField;
					object obj8 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)obj8 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj9 = 0;
					LinkedList<WeaponType> banishedWeapons3 = _banishedWeapons;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v8+20+v108 @ rsi_v5*4]");
					LinkedListNode<WeaponType> linkedListNode4 = banishedWeapons3.Find(WeaponType.VOID);
					if (linkedListNode4 == null)
					{
						LinkedList<WeaponType> excludedWeapons2 = _excludedWeapons;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v8+20+v108 @ rsi_v5*4]");
						LinkedListNode<WeaponType> linkedListNode5 = excludedWeapons2.AddLast(WeaponType.VOID);
						LinkedList<WeaponType> banishedWeapons4 = _banishedWeapons;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v8+20+v108 @ rsi_v5*4]");
						LinkedListNode<WeaponType> linkedListNode6 = banishedWeapons4.AddLast(WeaponType.VOID);
					}
					playerOptions2 = _playerOptions;
					obj6++;
					obj7 = obj6;
					continue;
					IL_0622:
					List<WeaponType> list4 = playerOptionsData3._003CContentGroupSealedWeapons_003Ek__BackingField;
					object obj10 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)obj10 >= 0)
					{
						return;
					}
					PlayerOptions playerOptions3 = _playerOptions;
					if (playerOptions3._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions3._hostGameConfig == null)
						{
							if (playerOptions3._currentAdventureSaveData != null)
							{
								playerOptionsData4 = playerOptions3._currentAdventureSaveData;
								if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_0659;
								}
							}
							playerOptionsData4 = playerOptions3._mainGameConfig;
						}
						else
						{
							playerOptionsData4 = playerOptions3._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData4 = playerOptions3._onlineClientWithRunDataConfig;
					}
					goto IL_0659;
				}
				break;
			}
			if (playerOptions2._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions2._hostGameConfig == null)
				{
					if (playerOptions2._currentAdventureSaveData != null)
					{
						playerOptionsData2 = playerOptions2._currentAdventureSaveData;
						if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_05d9;
						}
					}
					playerOptionsData2 = playerOptions2._mainGameConfig;
				}
				else
				{
					playerOptionsData2 = playerOptions2._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
			}
			goto IL_05d9;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public List<WeaponType> GetRemainingPowerupsAndWeapons()
	{
		List<WeaponType> list = new List<WeaponType>();
		LinkedList<WeaponType>.Enumerator enumerator = default(LinkedList<WeaponType>.Enumerator);
		WeaponType value = default(WeaponType);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (_excludedWeapons == null)
				{
					break;
				}
				LinkedListNode<WeaponType> linkedListNode = _excludedWeapons.Find(value);
				if (linkedListNode == null)
				{
					if (list == null)
					{
						throw new NullReferenceException();
					}
					LinkedListNode<WeaponType> linkedListNode2 = ((LinkedList<WeaponType>)(object)list).Find(value);
					if (linkedListNode2 == null)
					{
						LinkedListNode<WeaponType> linkedListNode3 = ((LinkedList<WeaponType>)(object)list).Find(value);
					}
				}
				continue;
			}
			return list;
		}
		throw new NullReferenceException();
	}

	public unsafe List<VampireSurvivors.Objects.Characters.CharacterController> FindFriendshipAmuletTargets(bool checkAmuletBag)
	{
		//IL_087d: Expected I, but got O
		//IL_008b: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_011d: Expected O, but got I
		//IL_01b8: Expected O, but got Ref
		//IL_06da: Expected I, but got O
		//IL_071e: Expected O, but got I
		//IL_0728: Expected I, but got O
		//IL_0771: Expected O, but got I
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> cachedPlayerList;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			int playerCount = core._multiplayer.GetPlayerCount();
			if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
			{
				goto IL_07a7;
			}
			num2 = (nint)_cachedPlayerList;
			if (_cachedPlayerList != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v21 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v21 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
				int num3 = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v21 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v21 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+10]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v21 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
					Array.Clear((Array)num4, 0, 0);
				}
				nint num5 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v47 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num6 = 0;
				GameManager core2 = GM.Core;
				bool flag = (object)GM.Core == null;
				num2 = num6;
				if (!flag)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
					bool flag2 = core2._mainCharacters == null;
					num2 = num6;
					if (!flag2)
					{
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator.MoveNext())
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController = null;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						cachedPlayerList = _cachedPlayerList;
						bool flag3 = _cachedPlayerList == null;
						num2 = (nint)(&enumerator);
						if (!flag3)
						{
							if (cachedPlayerList._size == 0)
							{
								goto IL_07a7;
							}
							if (!checkAmuletBag)
							{
								goto IL_0988;
							}
							List<bool> coopAmuletBag = _coopAmuletBag;
							bool flag4 = _coopAmuletBag == null;
							num2 = (nint)(&enumerator);
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v56 (System.Collections.Generic.List`1<System.Boolean>)+18]");
								bool flag5 = (nint)0 != 0;
								num2 = (nint)(&enumerator);
								if (!flag5)
								{
									InitAmuletBag();
									num2 = (nint)this;
								}
								List<bool> coopAmuletBag2 = _coopAmuletBag;
								if (_coopAmuletBag != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v29 (System.Collections.Generic.List`1<System.Boolean>)+18]");
									object obj = -1;
									num2 = (nint)_coopAmuletBag;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18057A5E0");
									List<bool> coopAmuletBag3 = _coopAmuletBag;
									if (_coopAmuletBag != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v32 (System.Collections.Generic.List`1<System.Boolean>)+18]");
										object obj2 = -1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047F780");
										object obj3 = default(object);
										if (obj3 == null)
										{
											goto IL_07a7;
										}
										cachedPlayerList = _cachedPlayerList;
										goto IL_0988;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0988:
		return cachedPlayerList;
		IL_07a7:
		return null;
	}

	private void InitializeWeaponStores()
	{
		PlayerOptionsData config = _playerOptions.Config;
		_unlockedWeapons = config._003CUnlockedWeapons_003Ek__BackingField;
		if (_excludedWeapons != null)
		{
			_excludedWeapons.Clear();
		}
		if (_specialWeapons != null)
		{
			_specialWeapons.Clear();
		}
		if (_weaponStore != null)
		{
			_weaponStore.Clear();
		}
		if (_banishedWeapons != null)
		{
			_banishedWeapons.Clear();
		}
		LinkedList<WeaponType> excludedWeapons = null;
		_excludedWeapons = excludedWeapons;
		LinkedList<WeaponType> specialWeapons = null;
		_specialWeapons = specialWeapons;
		LinkedList<WeaponType> weaponStore = null;
		_weaponStore = weaponStore;
		LinkedList<WeaponType> banishedWeapons = null;
		_banishedWeapons = banishedWeapons;
		ApplyUnlocks();
		ProcessBaseWeaponData();
		BanishedSealedWeapons();
	}

	private void ApplyUnlocks()
	{
		//IL_0068: Expected O, but got I
		//IL_018e: Expected O, but got I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4 = default(object);
		while (true)
		{
			object obj = obj2;
			while (true)
			{
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ stack_-28_v3+1C]");
					if (obj4 == null)
					{
						object obj5 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ stack_-28_v3+18]");
						if ((nint)obj5 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ stack_-28_v3+10]");
							object obj6 = 0;
							obj++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v25+20+v253 @ rdx_v5*4]");
							if ((nint)0 != 0)
							{
								break;
							}
							continue;
						}
					}
					if (obj3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ stack_-28_v3+1C]");
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
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
			bool flag = convertedWeapons == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v25+20+v253 @ rdx_v5*4]");
			int num = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
			obj2 = obj;
			if (!flag)
			{
				Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _data.GetConvertedWeapons();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v25+20+v253 @ rdx_v5*4]");
				object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)0);
				List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)obj8).get_Item(WeaponType.VOID);
				_ = 1;
				obj2 = obj;
			}
		}
	}

	private void ProcessBaseWeaponData()
	{
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			LinkedList<WeaponType> linkedList = null;
			LinkedList<WeaponType> linkedList2 = null;
			throw new NullReferenceException();
		}
	}

	public unsafe void ExcludeNonOwnedLockedWeapons(List<VampireSurvivors.Objects.Characters.CharacterController> allPlayers)
	{
		//IL_002d: Expected O, but got I4
		//IL_0035: Expected O, but got Ref
		//IL_023b: Expected O, but got Ref
		//IL_03c1: Expected O, but got I4
		//IL_0281: Expected O, but got I
		//IL_0296: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6636]");
		bool flag = (nint)0 != 0;
		List<WeaponType> list = new List<WeaponType>();
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator3 = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		object obj2 = default(object);
		while (true)
		{
			if (enumerator3.MoveNext())
			{
				bool flag2 = obj2 == null;
				Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator4 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)(&enumerator3);
				if (flag2)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1246 @ stack_-78+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1246 @ stack_-78+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rcx_v20+20]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v884 @ rax_v36+88]");
					if ((nint)0 != 0)
					{
					}
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				enumerator4 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)0;
				break;
			}
			return;
		}
		throw new NullReferenceException();
	}

	private static WeaponType TryParseType(string type)
	{
		return Enum.Parse<WeaponType>(type);
	}

	private List<WeaponType> GetRemainingNotMaxedWeapons()
	{
		//IL_004e: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		CharacterWeaponsManager weaponsManager = activeCharacter._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		List<WeaponType> list2 = new List<WeaponType>();
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < list._size)
			{
				if ((nint)obj2 >= list._size)
				{
					break;
				}
				Equipment[] items = list._items;
				Equipment equipment = items[obj2];
				LinkedListNode<WeaponType> linkedListNode = _excludedWeapons.Find(equipment._equipmentType);
				if (linkedListNode == null)
				{
					LinkedListNode<WeaponType> linkedListNode2 = _weaponStore.Find(equipment._equipmentType);
					if (linkedListNode2 != null)
					{
						LinkedListNode<WeaponType> linkedListNode3 = ((LinkedList<WeaponType>)(object)list2).Find(equipment._equipmentType);
					}
				}
				obj2++;
				obj = obj2;
				continue;
			}
			return list2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<WeaponType> result = default(List<WeaponType>);
		return result;
	}

	private unsafe static WeaponType GetWeaponFromWeightedStore(List<WeightedWeapon> store, double value)
	{
		//IL_0035: Expected O, but got I4
		//IL_003d: Expected O, but got Ref
		List<WeightedWeapon> list = default(List<WeightedWeapon>);
		List<WeightedWeapon>.Enumerator enumerator = default(List<WeightedWeapon>.Enumerator);
		if (list._size != 0 && enumerator.MoveNext())
		{
			object obj = 0;
			List<WeightedWeapon>.Enumerator enumerator2 = (List<WeightedWeapon>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return WeaponType.VOID;
	}

	private WeaponType GetRandomWeightedWeaponOrPowerUp()
	{
		//IL_0067: Expected I4, but got O
		//IL_008e: Expected F8, but got I4
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		random._002Ector(seed);
		if (random != null)
		{
			double num = random.NextDouble();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm0\"");
			return GetWeaponFromWeightedStore(_weightedStore, _accumulatedWeight);
		}
		NullReferenceException ex = new NullReferenceException();
		return (WeaponType)ex;
	}

	private WeaponType GetRandomWeightedWeapon(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0044: Expected F4, but got I4
		//IL_0066: Expected F4, but got I4
		//IL_02c1: Expected F4, but got I4
		List<WeightedWeapon> store = new List<WeightedWeapon>();
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		int num = 0;
		float num2 = 2f;
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			float num3 = 0f;
			num2 = 0f;
		}
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		random._002Ector(seed);
		double num4 = random.NextDouble();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm0\"");
		return GetWeaponFromWeightedStore(store, num2);
	}

	private int GetLevelUpOptions()
	{
		//IL_0010: Expected O, but got I
		//IL_00c1: Invalid comparison between I4 and F4
		//IL_00e0: Invalid comparison between F4 and I4
		//IL_0109: Expected O, but got I4
		//IL_0076: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		LevelUpFactory levelUpFactory = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			levelUpFactory = (LevelUpFactory)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46 @ rax_v5 (should have been resolved before IL gen)");
		GameSessionData gameSessionData = _gameSessionData;
		float num = gameSessionData._activeCharacter.PLuck();
		int result = _levelUpOptions;
		float num2 = 1f / 0f;
		int num3 = _levelUpOptions + 1;
		bool flag2 = 0f < num2;
		float num4 = 0f - num2;
		bool flag3 = num4 == 0f;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		object obj2 = flag5 & flag4;
		if (obj2 != null)
		{
			result = num3;
		}
		return result;
	}

	private float ChanceForExistingPowerUp()
	{
		//IL_0058: Expected O, but got I4
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		int num = activeCharacter._level & 1;
		bool flag = num == 0;
		GameSessionData gameSessionData2 = _gameSessionData;
		object obj = !flag;
		float num2 = ((obj != null) ? 1f : 2f);
		float num3 = _chanceForExistingPowerUp * num2;
		float num4 = num3 + 1f;
		float num5 = gameSessionData2._activeCharacter.PLuck();
		float num6 = 1f / num2;
		return num4 - num6;
	}

	private unsafe void InitAmuletBag()
	{
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected I4, but got Unknown
		//IL_0088: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_0249: Expected O, but got I
		//IL_029f: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected I4, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected I4, but got Unknown
		//IL_014c: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		if (_coopAmuletBag != null)
		{
			List<bool> coopAmuletBag = _coopAmuletBag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v22 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		else
		{
			List<bool> coopAmuletBag2 = new List<bool>();
			_coopAmuletBag = coopAmuletBag2;
		}
		CoopConfig coopConfig = _coopConfig;
		if (coopConfig._amuletBagSize > 0)
		{
			object obj = 0;
			object obj2 = 0;
			CoopConfig coopConfig2 = coopConfig;
			while ((nint)obj2 < coopConfig2._amuletBagSize)
			{
				CoopConfig coopConfig3 = _coopConfig;
				object obj3 = obj - coopConfig3._amuletsInAmuletBag;
				int num = obj ^ coopConfig3._amuletsInAmuletBag;
				object obj4 = obj ^ obj3;
				int num2 = num & obj4;
				bool flag = num2 < 0;
				bool flag2 = (nint)obj3 < 0;
				List<bool> coopAmuletBag3 = _coopAmuletBag;
				bool item = flag2 != flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v13 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v13 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v13 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r9_v6+18]");
				if (num3 >= 0)
				{
					coopAmuletBag3.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v13 (System.Collections.Generic.List`1<System.Boolean>)+18]");
					object obj6 = (nint)0 + (nint)1;
				}
				coopConfig2 = _coopConfig;
				obj++;
				obj2 = obj;
			}
			Extensions.Shuffle(_coopAmuletBag);
		}
		else
		{
			int num4 = coopConfig + 164;
			string text = ((int*)num4)->ToString();
			string message = "Our Amulet Bag size is " + text + ", this will never give you Friendship Amulets!";
			Debug.LogWarning(message);
			List<bool> coopAmuletBag4 = _coopAmuletBag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ r8_v5+18]");
			if (num5 >= 0)
			{
				coopAmuletBag4.AddWithResize(false);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v10 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 0;
		}
	}

	public LevelUpFactory()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController> cachedPlayerList = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_cachedPlayerList = cachedPlayerList;
	}

	static LevelUpFactory()
	{
		List<WeightedWeapon> weightedStore = new List<WeightedWeapon>();
		_weightedStore = weightedStore;
	}
}
