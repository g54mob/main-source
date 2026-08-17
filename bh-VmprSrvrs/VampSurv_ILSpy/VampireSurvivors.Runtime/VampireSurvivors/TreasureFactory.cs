using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors;

public class TreasureFactory : IInitializable, IDisposable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, bool> _003C_003E9__12_2;

		public static Func<Equipment, bool> _003C_003E9__12_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CMakePrizePairFromAvailablePowerUps_003Eb__12_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 88;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CMakePrizePairFromAvailablePowerUps_003Eb__12_3(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 100;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public TreasurePrizeTypePair pair;

		internal bool _003CMakePrizePairFromAvailablePowerUps_003Eb__0(WeaponType c)
		{
			//IL_005d: Expected I4, but got O
			//IL_003b: Expected O, but got I4
			TreasurePrizeTypePair treasurePrizeTypePair = pair;
			if (pair != null)
			{
				object obj = c - treasurePrizeTypePair.prizeWeapon;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CMakePrizePairFromAvailablePowerUps_003Eb__1(WeaponType c)
		{
			//IL_005d: Expected I4, but got O
			//IL_003b: Expected O, but got I4
			TreasurePrizeTypePair treasurePrizeTypePair = pair;
			if (pair != null)
			{
				object obj = c - treasurePrizeTypePair.prizeWeapon;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private LevelUpFactory _levelUpFactory;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private List<WeaponType> _accumulatedWeaponPrizes;

	private List<WeaponType> _accumulatedWorldSpacePrizes;

	private int _accumulatedCoinPrize;

	public List<PrizeType> currentTreasureTypes;

	private float _coinsAward;

	private List<TreasurePrizeTypePair> _prizes;

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public List<TreasurePrizeTypePair> GenerateNewPrizes(Treasure data)
	{
		List<WeaponType> accumulatedWeaponPrizes = new List<WeaponType>();
		_accumulatedWeaponPrizes = accumulatedWeaponPrizes;
		List<WeaponType> accumulatedWorldSpacePrizes = new List<WeaponType>();
		_accumulatedWorldSpacePrizes = accumulatedWorldSpacePrizes;
		List<TreasurePrizeTypePair> prizes = new List<TreasurePrizeTypePair>();
		_prizes = prizes;
		_accumulatedCoinPrize = 0;
		MakePrizes(data);
		if (data != null)
		{
			List<WeaponType> argAccumulatedWorldSpacePrizes = default(List<WeaponType>);
			data.AddPrizes(_prizes, _accumulatedWeaponPrizes, _accumulatedCoinPrize, argAccumulatedWorldSpacePrizes);
			return _prizes;
		}
		return (List<TreasurePrizeTypePair>)(object)new NullReferenceException();
	}

	private unsafe TreasurePrizeTypePair MakePrizePairFromAvailablePowerUps(PrizeType prizeType, WeaponType fixedPrize, VampireSurvivors.Objects.Characters.CharacterController character, bool isSpecial = false)
	{
		//IL_0042: Expected O, but got I8
		//IL_0a65: Expected O, but got F4
		//IL_0a6f: Invalid comparison between I4 and F4
		//IL_00e8: Expected O, but got I8
		//IL_0ad6: Expected O, but got Ref
		//IL_0210: Expected O, but got I4
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_084a: Expected I4, but got Unknown
		//IL_043d: Expected O, but got I4
		//IL_030b: Expected O, but got I4
		//IL_0327: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_0576: Expected O, but got I4
		//IL_0380: Expected O, but got I4
		//IL_039f: Expected O, but got I4
		//IL_05d3: Expected O, but got I4
		//IL_03f8: Expected O, but got I4
		//IL_0413: Expected O, but got I4
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass12_0();
		TreasurePrizeTypePair treasurePrizeTypePair = new TreasurePrizeTypePair();
		PrizeType prizeType2 = default(PrizeType);
		treasurePrizeTypePair.prizeType = prizeType2;
		CS_0024_003C_003E8__locals27.pair = treasurePrizeTypePair;
		object obj = 6442450944L;
		TreasurePrizeTypePair pair = CS_0024_003C_003E8__locals27.pair;
		int num;
		if (pair.prizeType != PrizeType.RANDOM)
		{
			num = 0;
		}
		else
		{
			object obj2 = UnityEngine.Random.value;
			bool flag = 0f > 0.5f;
			PrizeType prizeType3 = PrizeType.POWERUP;
			if (!flag)
			{
				prizeType3 = PrizeType.EXISTING_ANY;
			}
			pair.prizeType = prizeType3;
			num = 0;
		}
		TreasurePrizeTypePair pair2 = CS_0024_003C_003E8__locals27.pair;
		PrizeType prizeType4 = pair2.prizeType;
		if (pair2.prizeType <= PrizeType.SURVAROT)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v4+696541C+v229 @ rcx_v10 (VampireSurvivors.Data.PrizeType)*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v1282 @ rcx_v115 (should have been resolved before IL gen)");
			TreasurePrizeTypePair result = default(TreasurePrizeTypePair);
			return result;
		}
		TreasurePrizeTypePair pair3 = CS_0024_003C_003E8__locals27.pair;
		int num10;
		if (pair3.prizeType == PrizeType.FILLER)
		{
			object obj4 = default(object);
			bool flag2;
			if (obj4 != null)
			{
				flag2 = true;
			}
			else
			{
				float value = UnityEngine.Random.value;
				GameManager core = GM.Core;
				GameSessionData gameSessionData = core._gameSessionData;
				float num2 = gameSessionData._activeCharacter.PLuck();
				float num3 = value * 0.01f;
				bool flag3 = num3 < value;
				flag2 = !flag3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			string message = string.FormatHelper((IFormatProvider)null, "Special change: {0}", (System.ParamsArray)(&paramsArray2));
			Debug.Log(message);
			if (!flag2)
			{
				goto IL_07f0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BB90");
			IEnumerable<Equipment> enumerable = default(IEnumerable<Equipment>);
			LinkedListNode<WeaponType> linkedListNode = ((LinkedList<WeaponType>)enumerable).Find(WeaponType.CANDYBOX);
			bool flag4 = linkedListNode == null;
			Func<Equipment, bool> predicate = (Func<Equipment, bool>)88;
			IEnumerable<Equipment> source = enumerable;
			if (!flag4)
			{
				GameManager core2 = GM.Core;
				GameSessionData gameSessionData2 = core2._gameSessionData;
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData2._activeCharacter;
				CharacterWeaponsManager weaponsManager = activeCharacter._weaponsManager;
				Func<object, bool> func = (Func<object, bool>)_003C_003Ec._003C_003E9__12_2;
				if (_003C_003Ec._003C_003E9__12_2 == null)
				{
					func = (Func<object, bool>)(_003C_003Ec._003C_003E9__12_2 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj6 = x._equipmentType - 88;
						return obj6 == null;
					});
				}
				int num4 = Enumerable.Count(((EquipmentManager)weaponsManager)._003CRemovedEquipment_003Ek__BackingField, func);
				bool flag5 = num4 != 0;
				predicate = func;
				source = ((EquipmentManager)weaponsManager)._003CRemovedEquipment_003Ek__BackingField;
				if (!flag5)
				{
					GameManager core3 = GM.Core;
					PlayerOptionsData config = core3._playerOptions.Config;
					source = (IEnumerable<Equipment>)config._003CUnlockedWeapons_003Ek__BackingField;
					int num5 = Enumerable.Count((IEnumerable<Equipment>)config._003CUnlockedWeapons_003Ek__BackingField, (Func<Equipment, bool>)88);
					bool flag6 = num5 == 0;
					predicate = (Func<Equipment, bool>)88;
					if (!flag6)
					{
						GameManager core4 = GM.Core;
						PlayerOptionsData config2 = core4._playerOptions.Config;
						source = (IEnumerable<Equipment>)config2._003CSealedWeapons_003Ek__BackingField;
						int num6 = Enumerable.Count((IEnumerable<Equipment>)config2._003CSealedWeapons_003Ek__BackingField, (Func<Equipment, bool>)88);
						bool flag7 = num6 != 0;
						predicate = (Func<Equipment, bool>)88;
						if (!flag7)
						{
							GameManager core5 = GM.Core;
							PlayerOptionsData config3 = core5._playerOptions.Config;
							source = (IEnumerable<Equipment>)config3._003CContentGroupSealedWeapons_003Ek__BackingField;
							int num7 = Enumerable.Count((IEnumerable<Equipment>)config3._003CContentGroupSealedWeapons_003Ek__BackingField, (Func<Equipment, bool>)88);
							num = num7 ^ 1;
							predicate = (Func<Equipment, bool>)88;
						}
					}
				}
			}
			int num8 = Enumerable.Count(source, predicate);
			LinkedListNode<WeaponType> linkedListNode2 = ((LinkedList<WeaponType>)num8).Find(WeaponType.CANDYBOX2);
			if (linkedListNode2 != null)
			{
				GameManager core6 = GM.Core;
				GameSessionData gameSessionData3 = core6._gameSessionData;
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData3._activeCharacter;
				CharacterWeaponsManager weaponsManager2 = activeCharacter2._weaponsManager;
				Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__12_3;
				if (_003C_003Ec._003C_003E9__12_3 == null)
				{
					predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__12_3 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj6 = x._equipmentType - 100;
						return obj6 == null;
					});
				}
				if (Enumerable.Count(((EquipmentManager)weaponsManager2)._003CRemovedEquipment_003Ek__BackingField, predicate2) == 0)
				{
					GameManager core7 = GM.Core;
					PlayerOptionsData config4 = core7._playerOptions.Config;
					if (Enumerable.Count((IEnumerable<Equipment>)config4._003CUnlockedWeapons_003Ek__BackingField, (Func<Equipment, bool>)100) != 0)
					{
						GameManager core8 = GM.Core;
						PlayerOptionsData config5 = core8._playerOptions.Config;
						if (Enumerable.Count((IEnumerable<Equipment>)config5._003CSealedWeapons_003Ek__BackingField, (Func<Equipment, bool>)100) == 0)
						{
							GameManager core9 = GM.Core;
							PlayerOptionsData config6 = core9._playerOptions.Config;
							int num9 = Enumerable.Count((IEnumerable<Equipment>)config6._003CContentGroupSealedWeapons_003Ek__BackingField, (Func<Equipment, bool>)100);
							num10 = num9 ^ 1;
							goto IL_0b89;
						}
					}
				}
			}
			num10 = 0;
			goto IL_0b89;
		}
		TreasurePrizeTypePair pair4 = CS_0024_003C_003E8__locals27.pair;
		if (pair4.prizeType != PrizeType.NEW_WEAPON)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			TreasurePrizeTypePair pair5 = CS_0024_003C_003E8__locals27.pair;
			_levelUpFactory.RemoveFromStore(pair5.prizeWeapon, character);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
		}
		TreasurePrizeTypePair pair6 = CS_0024_003C_003E8__locals27.pair;
		Weapon weaponByType = character._weaponsManager.GetWeaponByType(pair6.prizeWeapon);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			Func<WeaponType, bool> predicate3 = delegate(WeaponType c)
			{
				//IL_005d: Expected I4, but got O
				//IL_003b: Expected O, but got I4
				TreasurePrizeTypePair pair19 = CS_0024_003C_003E8__locals27.pair;
				if (CS_0024_003C_003E8__locals27.pair == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = c - pair19.prizeWeapon;
				return obj6 == null;
			};
			int num11 = Enumerable.Count((IEnumerable<System.Int32Enum>)_accumulatedWeaponPrizes, (Func<System.Int32Enum, bool>)(object)predicate3);
			num = ((Equipment)weaponByType)._003CLevel_003Ek__BackingField + num11;
		}
		TreasurePrizeTypePair pair7 = CS_0024_003C_003E8__locals27.pair;
		Accessory accessoryByType = character._accessoriesManager.GetAccessoryByType(pair7.prizeWeapon);
		if ((object)accessoryByType != null && ((UnityEngine.Object)accessoryByType).m_CachedPtr != (IntPtr)0)
		{
			Func<WeaponType, bool> predicate4 = delegate(WeaponType c)
			{
				//IL_005d: Expected I4, but got O
				//IL_003b: Expected O, but got I4
				TreasurePrizeTypePair pair19 = CS_0024_003C_003E8__locals27.pair;
				if (CS_0024_003C_003E8__locals27.pair == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = c - pair19.prizeWeapon;
				return obj6 == null;
			};
			int num12 = Enumerable.Count((IEnumerable<System.Int32Enum>)_accumulatedWeaponPrizes, (Func<System.Int32Enum, bool>)(object)predicate4);
			num = ((Equipment)accessoryByType)._003CLevel_003Ek__BackingField + num12;
		}
		TreasurePrizeTypePair pair8 = CS_0024_003C_003E8__locals27.pair;
		pair8.Level = num;
		return CS_0024_003C_003E8__locals27.pair;
		IL_07f0:
		DataManager dataManager = _dataManager;
		TreasurePrizeTypePair pair9 = CS_0024_003C_003E8__locals27.pair;
		object obj5 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)pair9.prizeItem);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+4Ch]\"");
		int accumulatedCoinPrize = obj5 + _accumulatedCoinPrize;
		_accumulatedCoinPrize = accumulatedCoinPrize;
		return CS_0024_003C_003E8__locals27.pair;
		IL_0b89:
		if (num != 0)
		{
			LinkedListNode<WeaponType> linkedListNode3 = ((LinkedList<WeaponType>)(object)_accumulatedWeaponPrizes).Find(WeaponType.CANDYBOX);
			if (linkedListNode3 == null)
			{
				TreasurePrizeTypePair pair10 = CS_0024_003C_003E8__locals27.pair;
				pair10.prizeWeapon = WeaponType.CANDYBOX;
				TreasurePrizeTypePair pair11 = CS_0024_003C_003E8__locals27.pair;
				pair11.prizeType = PrizeType.EXISTING_WEAPON;
				TreasurePrizeTypePair pair12 = CS_0024_003C_003E8__locals27.pair;
				LinkedListNode<WeaponType> linkedListNode4 = ((LinkedList<WeaponType>)(object)_accumulatedWeaponPrizes).Find(pair12.prizeWeapon);
				TreasurePrizeTypePair pair13 = CS_0024_003C_003E8__locals27.pair;
				_levelUpFactory.RemoveFromStore(pair13.prizeWeapon, character);
				return CS_0024_003C_003E8__locals27.pair;
			}
		}
		if (num10 != 0)
		{
			LinkedListNode<WeaponType> linkedListNode5 = ((LinkedList<WeaponType>)(object)_accumulatedWeaponPrizes).Find(WeaponType.CANDYBOX2);
			if (linkedListNode5 == null)
			{
				TreasurePrizeTypePair pair14 = CS_0024_003C_003E8__locals27.pair;
				pair14.prizeWeapon = WeaponType.CANDYBOX2;
				TreasurePrizeTypePair pair15 = CS_0024_003C_003E8__locals27.pair;
				pair15.prizeType = PrizeType.EXISTING_WEAPON;
				TreasurePrizeTypePair pair16 = CS_0024_003C_003E8__locals27.pair;
				LinkedListNode<WeaponType> linkedListNode6 = ((LinkedList<WeaponType>)(object)_accumulatedWeaponPrizes).Find(pair16.prizeWeapon);
				TreasurePrizeTypePair pair17 = CS_0024_003C_003E8__locals27.pair;
				_levelUpFactory.RemoveFromStore(pair17.prizeWeapon, character);
				TreasurePrizeTypePair pair18 = CS_0024_003C_003E8__locals27.pair;
				_levelUpFactory.RemoveFromSpecialWeapons(pair18.prizeWeapon);
				return CS_0024_003C_003E8__locals27.pair;
			}
		}
		goto IL_07f0;
	}

	private void MakePrizes(Treasure treasure)
	{
		//IL_0109: Expected O, but got I
		//IL_0b72: Expected O, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0157: Expected O, but got I
		//IL_019f: Expected I, but got O
		//IL_01c0: Expected O, but got I4
		//IL_0de6: Expected O, but got F4
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_0a69: Expected O, but got I
		//IL_0d3d: Expected O, but got F4
		//IL_0b54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b59: Expected I4, but got Unknown
		//IL_0762: Expected O, but got I
		//IL_0c18: Expected O, but got F4
		//IL_0243: Expected O, but got I
		//IL_0b09: Expected O, but got I
		//IL_0867: Expected O, but got I
		//IL_07f2: Expected O, but got I
		//IL_0348: Expected O, but got I
		//IL_02d3: Expected O, but got I
		//IL_0976: Expected O, but got I
		//IL_08f7: Expected O, but got I
		//IL_044d: Expected O, but got I
		//IL_03d8: Expected O, but got I
		//IL_0a16: Expected O, but got I
		//IL_0552: Expected O, but got I
		//IL_04dd: Expected O, but got I
		//IL_0661: Expected O, but got I
		//IL_05e2: Expected O, but got I
		//IL_0701: Expected O, but got I
		//IL_0b40->IL0b40: Incompatible stack heights: 1 vs 0
		//IL_0b23->IL0d10: Incompatible stack heights: 2 vs 1
		//IL_080c->IL0d85: Incompatible stack heights: 2 vs 1
		//IL_02ed->IL0c60: Incompatible stack heights: 2 vs 1
		//IL_09a8->IL0b23: Incompatible stack heights: 3 vs 1
		//IL_0911->IL0db1: Incompatible stack heights: 3 vs 2
		//IL_09dd->IL0b23: Incompatible stack heights: 3 vs 1
		//IL_03f2->IL0c8c: Incompatible stack heights: 3 vs 2
		//IL_0a30->IL0d10: Incompatible stack heights: 4 vs 1
		//IL_04f7->IL0cb8: Incompatible stack heights: 4 vs 3
		//IL_05fc->IL0ce4: Incompatible stack heights: 5 vs 4
		//IL_0729->IL0d10: Incompatible stack heights: 5 vs 1
		//IL_071b->IL0d10: Incompatible stack heights: 6 vs 1
		List<TreasurePrizeTypePair> prizes = _prizes;
		int version = prizes._version + 1;
		prizes._version = version;
		prizes._size = 0;
		if (prizes._size > 0)
		{
			Array.Clear(prizes._items, 0, prizes._size);
		}
		List<PrizeType> list = currentTreasureTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		bool isSpecial = default(bool);
		object obj26 = default(object);
		while (true)
		{
			obj = obj;
			while (true)
			{
				WeaponType fixedPrize;
				WeaponType fixedPrize2;
				PrizeType prizeType;
				WeaponType fixedPrize3;
				List<TreasurePrizeTypePair> prizes2;
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-38_v14+1C]");
					if (obj3 == null)
					{
						object obj4 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-38_v14+18]");
						if ((nint)obj4 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-38_v14+10]");
							object obj5 = 0;
							obj++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rdx_v42+20+v163 @ r8_v17*8]");
							if ((nint)0 != 0)
							{
								break;
							}
							continue;
						}
					}
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-38_v14+1C]");
						if (obj3 == null)
						{
							VampireSurvivors.Objects.Characters.CharacterController winningPlayer = treasure.winningPlayer;
							bool flag = (object)treasure.winningPlayer == null;
							nint num = (nint)winningPlayer;
							treasure.winningPlayer.GetTreasureModifier();
							object obj6 = treasure._003Clevel_003Ek__BackingField - 1;
							float coinsAward;
							if (!flag)
							{
								object obj7 = obj6 - 1;
								if (!flag)
								{
									if ((nint)obj7 != 1)
									{
										goto IL_0b40;
									}
									object obj8 = UnityEngine.Random.value;
									float num2 = (float)treasure._003CprizeTypes_003Ek__BackingField * 500f;
									coinsAward = num2 + 500f;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
									_coinsAward = coinsAward;
									List<PrizeType> list2 = currentTreasureTypes;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v90 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
									bool flag2 = (nint)0 <= (nint)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v90 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
									object obj9 = 0;
									if (treasure._003CfixedPrizes_003Ek__BackingField != null)
									{
										List<WeaponType> list3 = treasure._003CfixedPrizes_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ rax_v125 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										if ((nint)0 > (nint)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ rax_v125 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
											bool flag3 = (nint)0 <= (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ rax_v125 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
											object obj10 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v126+20]");
											fixedPrize = WeaponType.VOID;
											goto IL_0c60;
										}
									}
									fixedPrize = WeaponType.VOID;
									goto IL_0c60;
								}
								object obj11 = UnityEngine.Random.value;
								float num3 = (float)treasure._003CprizeTypes_003Ek__BackingField * 300f;
								coinsAward = num3 + 300f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
								_coinsAward = coinsAward;
								List<PrizeType> list4 = currentTreasureTypes;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v65 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
								bool flag4 = (nint)0 <= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v65 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
								object obj12 = 0;
								if (treasure._003CfixedPrizes_003Ek__BackingField != null)
								{
									List<WeaponType> list5 = treasure._003CfixedPrizes_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1695 @ rax_v83 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1695 @ rax_v83 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										bool flag5 = (nint)0 <= (nint)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1695 @ rax_v83 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v84+20]");
										fixedPrize2 = WeaponType.VOID;
										goto IL_0d85;
									}
								}
								fixedPrize2 = WeaponType.VOID;
								goto IL_0d85;
							}
							object obj14 = UnityEngine.Random.value;
							float num4 = (float)treasure._003CprizeTypes_003Ek__BackingField * 100f;
							coinsAward = num4 + 100f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
							_coinsAward = coinsAward;
							prizes2 = _prizes;
							List<PrizeType> list6 = currentTreasureTypes;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v56 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
							bool flag6 = (nint)0 <= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v56 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
							object obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v57+20]");
							prizeType = PrizeType.POWERUP;
							if (treasure._003CfixedPrizes_003Ek__BackingField != null)
							{
								List<WeaponType> list7 = treasure._003CfixedPrizes_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1698 @ rax_v58 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1698 @ rax_v58 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									bool flag7 = (nint)0 <= (nint)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1698 @ rax_v58 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
									object obj16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v59+20]");
									fixedPrize3 = WeaponType.VOID;
									goto IL_0d10;
								}
							}
							goto IL_0b23;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						object obj17 = 0;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0ce4:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v106+2C]");
				WeaponType fixedPrize4;
				TreasurePrizeTypePair treasurePrizeTypePair = MakePrizePairFromAvailablePowerUps(PrizeType.POWERUP, fixedPrize4, treasure.winningPlayer, isSpecial);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A80");
				prizes2 = _prizes;
				List<PrizeType> list8 = currentTreasureTypes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v110 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
				bool flag8 = (nint)0 <= (nint)4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v110 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v111+30]");
				prizeType = PrizeType.POWERUP;
				if (treasure._003CfixedPrizes_003Ek__BackingField != null)
				{
					List<WeaponType> list9 = treasure._003CfixedPrizes_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1694 @ rax_v113 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1694 @ rax_v113 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						bool flag9 = (nint)0 <= (nint)4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1694 @ rax_v113 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v114+30]");
						fixedPrize3 = WeaponType.VOID;
						goto IL_0d10;
					}
				}
				fixedPrize3 = WeaponType.VOID;
				goto IL_0d10;
				IL_0c60:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v91+20]");
				TreasurePrizeTypePair treasurePrizeTypePair2 = MakePrizePairFromAvailablePowerUps(PrizeType.POWERUP, fixedPrize, treasure.winningPlayer, isSpecial);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A80");
				List<PrizeType> list10 = currentTreasureTypes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v95 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
				bool flag10 = (nint)0 <= (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v95 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj20 = 0;
				WeaponType fixedPrize5;
				if (treasure._003CfixedPrizes_003Ek__BackingField != null)
				{
					List<WeaponType> list11 = treasure._003CfixedPrizes_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1691 @ rax_v122 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1691 @ rax_v122 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						bool flag11 = (nint)0 <= (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1691 @ rax_v122 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v123+24]");
						fixedPrize5 = WeaponType.VOID;
						goto IL_0c8c;
					}
				}
				fixedPrize5 = WeaponType.VOID;
				goto IL_0c8c;
				IL_0db1:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v71+24]");
				WeaponType fixedPrize6;
				TreasurePrizeTypePair treasurePrizeTypePair3 = MakePrizePairFromAvailablePowerUps(PrizeType.POWERUP, fixedPrize6, treasure.winningPlayer, isSpecial);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A80");
				prizes2 = _prizes;
				List<PrizeType> list12 = currentTreasureTypes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v75 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
				bool flag12 = (nint)0 <= (nint)2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v75 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v76+28]");
				prizeType = PrizeType.POWERUP;
				if (treasure._003CfixedPrizes_003Ek__BackingField != null)
				{
					List<WeaponType> list13 = treasure._003CfixedPrizes_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1697 @ rax_v77 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1697 @ rax_v77 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						bool flag13 = (nint)0 <= (nint)2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1697 @ rax_v77 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v78+28]");
						fixedPrize3 = WeaponType.VOID;
						goto IL_0d10;
					}
				}
				goto IL_0b23;
				IL_0d85:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v66+20]");
				TreasurePrizeTypePair treasurePrizeTypePair4 = MakePrizePairFromAvailablePowerUps(PrizeType.POWERUP, fixedPrize2, treasure.winningPlayer, isSpecial);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A80");
				List<PrizeType> list14 = currentTreasureTypes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v70 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
				bool flag14 = (nint)0 <= (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v70 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj24 = 0;
				if (treasure._003CfixedPrizes_003Ek__BackingField != null)
				{
					List<WeaponType> list15 = treasure._003CfixedPrizes_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1696 @ rax_v80 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1696 @ rax_v80 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						bool flag15 = (nint)0 <= (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1696 @ rax_v80 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj25 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v81+24]");
						fixedPrize6 = WeaponType.VOID;
						goto IL_0db1;
					}
				}
				fixedPrize6 = WeaponType.VOID;
				goto IL_0db1;
				IL_0b40:
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rdi+48h]\"");
				int accumulatedCoinPrize = _accumulatedCoinPrize + obj26;
				_accumulatedCoinPrize = accumulatedCoinPrize;
				return;
				IL_0c8c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v96+24]");
				TreasurePrizeTypePair treasurePrizeTypePair5 = MakePrizePairFromAvailablePowerUps(PrizeType.POWERUP, fixedPrize5, treasure.winningPlayer, isSpecial);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A80");
				List<PrizeType> list16 = currentTreasureTypes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v100 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
				bool flag16 = (nint)0 <= (nint)2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v100 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj27 = 0;
				WeaponType fixedPrize7;
				if (treasure._003CfixedPrizes_003Ek__BackingField != null)
				{
					List<WeaponType> list17 = treasure._003CfixedPrizes_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1692 @ rax_v119 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1692 @ rax_v119 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						bool flag17 = (nint)0 <= (nint)2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1692 @ rax_v119 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj28 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v120+28]");
						fixedPrize7 = WeaponType.VOID;
						goto IL_0cb8;
					}
				}
				fixedPrize7 = WeaponType.VOID;
				goto IL_0cb8;
				IL_0b23:
				fixedPrize3 = WeaponType.VOID;
				goto IL_0d10;
				IL_0cb8:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v101+28]");
				TreasurePrizeTypePair treasurePrizeTypePair6 = MakePrizePairFromAvailablePowerUps(PrizeType.POWERUP, fixedPrize7, treasure.winningPlayer, isSpecial);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A80");
				List<PrizeType> list18 = currentTreasureTypes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v105 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
				bool flag18 = (nint)0 <= (nint)3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v105 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
				object obj29 = 0;
				if (treasure._003CfixedPrizes_003Ek__BackingField != null)
				{
					List<WeaponType> list19 = treasure._003CfixedPrizes_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1693 @ rax_v116 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1693 @ rax_v116 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						bool flag19 = (nint)0 <= (nint)3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1693 @ rax_v116 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj30 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v117+2C]");
						fixedPrize4 = WeaponType.VOID;
						goto IL_0ce4;
					}
				}
				fixedPrize4 = WeaponType.VOID;
				goto IL_0ce4;
				IL_0d10:
				TreasurePrizeTypePair treasurePrizeTypePair7 = MakePrizePairFromAvailablePowerUps(prizeType, fixedPrize3, treasure.winningPlayer, isSpecial);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A80");
				goto IL_0b40;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rdx_v42+20+v163 @ r8_v17*8]");
			object obj31 = (nint)0 >> 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96A20");
		}
	}

	public int GetCoins()
	{
		return _accumulatedCoinPrize;
	}

	public List<WeaponType> GetAccumulatedWeaponPrizes()
	{
		return _accumulatedWeaponPrizes;
	}

	private void AddFiller(TreasurePrizeTypePair pair)
	{
		pair.prizeItem = ItemType.COINBAG2;
		pair.prizeType = PrizeType.FILLER;
	}

	public TreasureFactory()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0290: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02b8: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02e0: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0308: Expected O, but got I
		//IL_022a: Expected O, but got I
		List<PrizeType> list = new List<PrizeType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PrizeType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 0;
		}
		currentTreasureTypes = list;
		List<TreasurePrizeTypePair> prizes = new List<TreasurePrizeTypePair>();
		_prizes = prizes;
	}
}
