using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.UI;

public class ArcanaInfoPanel : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, WeaponType> _003C_003E9__16_0;

		public static Func<Pickup, bool> _003C_003E9__20_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal WeaponType _003CInitialize_003Eb__16_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal bool _003CPopulateAffectedWeaponCarousel_003Eb__20_2(Pickup x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._003CPickupType_003Ek__BackingField - 13;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private Localize _InfoTitle;

	private Localize _InfoDescription;

	private RectTransform _AffectedWeaponGroup;

	private RectTransform _DynamicGrid;

	private bool _ReorderWeaponsBasedOnOwnership = true;

	private Image _AffectedWeaponImageTemplate;

	private int _MaxWeaponsBeforeGrid = 16;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private VampireSurvivors.Objects.Characters.CharacterController _controllingCharacter;

	private readonly List<GameObject> _affectedWeapons;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private Dictionary<ItemType, ItemData> _items;

	private readonly List<Equipment> _equipment;

	private List<WeaponType> _ownedWeapons;

	private void Construct(DataManager data, PlayerOptions player, GameManager game, ArcanaManager arcana)
	{
		_data = data;
		_playerOptions = player;
	}

	public void Initialize()
	{
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		_weapons = convertedWeapons;
		DataManager data = _data;
		_items = data._003CAllItems_003Ek__BackingField;
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController = core._003CPausingPlayer_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController2;
		if ((object)core._003CPausingPlayer_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			characterController2 = core2._003CPausingPlayer_003Ek__BackingField;
		}
		else
		{
			GameManager core3 = GM.Core;
			GameSessionData gameSessionData = core3._gameSessionData;
			characterController2 = gameSessionData._activeCharacter;
		}
		List<object> equipment = (List<object>)(object)_equipment;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		((List<object>)(object)_equipment).InsertRange(equipment._size, (IEnumerable<object>)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
		CharacterAccessoriesManager accessoriesManager = characterController2._accessoriesManager;
		List<object> equipment2 = (List<object>)(object)_equipment;
		((List<object>)(object)_equipment).InsertRange(equipment2._size, (IEnumerable<object>)((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField);
		Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__16_0;
		if (_003C_003Ec._003C_003E9__16_0 == null)
		{
			selector = (_003C_003Ec._003C_003E9__16_0 = delegate(Equipment x)
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
		IEnumerable<WeaponType> enumerable = Enumerable.Select(_equipment, selector);
		if (enumerable != null)
		{
			List<System.Int32Enum> ownedWeapons = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			_ownedWeapons = (List<WeaponType>)(object)ownedWeapons;
			GameObject gameObject = _DynamicGrid.gameObject;
			gameObject.SetActive(value: false);
			ClearAffectedWeapons();
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void SetControllingCharacter(VampireSurvivors.Objects.Characters.CharacterController controllingCharacter)
	{
		_controllingCharacter = controllingCharacter;
	}

	public void SetInfo(ArcanaData arcanaData, ArcanaType arcanaType)
	{
		ClearAffectedWeapons();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C17]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix = arcanaData.GetLocalPrefix(arcanaType);
		string term = localPrefix + "name";
		_InfoTitle.Term = term;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C18]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string localPrefix2 = arcanaData.GetLocalPrefix(arcanaType);
		string term2 = localPrefix2 + "description";
		_InfoDescription.Term = term2;
		GameObject gameObject = _DynamicGrid.gameObject;
		gameObject.SetActive(value: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 141 Invalid \"Jump target not found in method: 0x18697FA00\"");
		throw new NullReferenceException();
	}

	private bool IsWeaponSelectorType(WeaponType? weaponType)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_0105: Expected O, but got I4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		if ((object)weaponType != null)
		{
			object obj = default(object);
			bool flag;
			if ((nint)obj > 404)
			{
				object obj2 = obj - 1407;
				if ((nint)obj2 <= 3 || (nint)obj == 1507)
				{
					goto IL_00d1;
				}
				object obj3 = obj - 1589;
				flag = obj3 == null;
			}
			else
			{
				if ((nint)obj == 88)
				{
					goto IL_00d1;
				}
				object obj4 = obj - 404;
				flag = obj4 == null;
			}
			object obj5 = !flag;
			if (obj5 == null)
			{
				goto IL_00d1;
			}
		}
		return false;
		IL_00d1:
		return true;
	}

	private unsafe void PopulateAffectedWeaponCarousel(ArcanaData arcanaData, ArcanaType type)
	{
		//IL_0f8b: Expected I4, but got O
		//IL_0fe0: Expected O, but got I
		//IL_0fff: Expected O, but got I
		//IL_014c: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_11de: Expected O, but got Ref
		//IL_11f0: Expected I, but got O
		//IL_1273: Expected I, but got O
		//IL_1537: Expected O, but got I
		//IL_1540: Unknown result type (might be due to invalid IL or missing references)
		//IL_1545: Expected O, but got Unknown
		//IL_154d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1552: Expected O, but got Unknown
		//IL_15c9: Expected I, but got O
		//IL_123b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1240: Expected O, but got Unknown
		//IL_12ad: Expected I, but got O
		//IL_1334: Expected O, but got I4
		//IL_12e5: Expected O, but got I
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_0681: Expected O, but got I4
		//IL_1349: Expected I, but got O
		//IL_1357: Expected I, but got O
		//IL_1367: Expected O, but got I
		//IL_157a: Expected O, but got I
		//IL_1583: Unknown result type (might be due to invalid IL or missing references)
		//IL_1588: Expected O, but got Unknown
		//IL_1590: Unknown result type (might be due to invalid IL or missing references)
		//IL_1595: Expected O, but got Unknown
		//IL_042c: Expected O, but got I4
		//IL_12f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fd: Expected O, but got Unknown
		//IL_13a3: Expected O, but got I
		//IL_06c6: Expected O, but got I4
		//IL_13d8: Expected I, but got O
		//IL_13e8: Expected O, but got I
		//IL_13f8: Expected O, but got I
		//IL_140e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1413: Expected O, but got Unknown
		//IL_0479: Expected O, but got I
		//IL_0491: Expected O, but got I4
		//IL_049a: Expected O, but got I4
		//IL_0340: Expected O, but got I
		//IL_0364: Expected O, but got I
		//IL_037e: Expected O, but got I4
		//IL_039e: Expected O, but got I
		//IL_147a: Expected I, but got O
		//IL_0572: Expected O, but got I
		//IL_03c0: Expected O, but got I
		//IL_03c9: Expected O, but got I4
		//IL_14a8: Expected O, but got I
		//IL_05fb: Expected O, but got I
		//IL_07c1: Expected O, but got I
		//IL_1697: Expected I, but got O
		//IL_0b83: Expected O, but got I
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_081b: Expected O, but got Unknown
		//IL_08aa: Expected O, but got I
		//IL_0c29: Expected O, but got I
		//IL_0907: Expected O, but got I
		//IL_0d53: Expected O, but got I
		//IL_0cb7: Expected O, but got I
		//IL_093c: Expected O, but got I
		//IL_09c6: Expected O, but got I
		//IL_09e0: Expected O, but got I
		//IL_099c: Expected O, but got I
		//IL_0dd8: Expected O, but got I
		//IL_0e6a: Expected O, but got I
		//IL_16dc: Expected I, but got O
		//IL_0ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec4: Expected O, but got Unknown
		//IL_0b0a: Expected O, but got I
		//IL_0b3c: Expected O, but got I
		//IL_1c21->IL1c5c: Incompatible stack heights: 1 vs 0
		List<WeaponType> list;
		List<WeaponType> list2;
		CharacterData currentSkinData;
		WeaponType? weaponType;
		List<WeaponType> list3;
		if (type == ArcanaType.T10_BEGINNING)
		{
			list = new List<WeaponType>();
			list2 = new List<WeaponType>();
			bool flag = _data == null;
			list3 = list2;
			if (!flag)
			{
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
				bool flag2 = _playerOptions == null;
				list3 = list2;
				if (!flag2)
				{
					PlayerOptionsData config = _playerOptions.Config;
					bool flag3 = config == null;
					list3 = list2;
					if (!flag3)
					{
						bool flag4 = convertedCharacterData == null;
						list3 = list2;
						if (!flag4)
						{
							object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)config._selectedChar);
							bool flag5 = obj == null;
							list3 = list2;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v228 (System.Object)+18]");
								if ((nint)0 <= (nint)0)
								{
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									Dictionary<System.Int32Enum, object> dictionary = null;
									goto IL_19d6;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v228 (System.Object)+10]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v228 (System.Object)+10]");
								bool flag6 = (nint)0 == 0;
								list3 = list2;
								if (!flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r13_v47+18]");
									bool flag7 = (nint)0 <= (nint)0;
									list3 = list2;
									if (flag7)
									{
										throw new IndexOutOfRangeException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r13_v47+20]");
									object obj3 = 0;
									bool flag8 = (object)GM.Core == null;
									list3 = list2;
									if (!flag8)
									{
										VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
										if ((object)interactingPlayer == null || ((UnityEngine.Object)interactingPlayer).m_CachedPtr == (IntPtr)0)
										{
											return;
										}
										bool flag9 = (object)GM.Core == null;
										list3 = list2;
										if (!flag9)
										{
											VampireSurvivors.Objects.Characters.CharacterController interactingPlayer2 = GM.Core.InteractingPlayer;
											bool flag10 = (object)interactingPlayer2 == null;
											list3 = list2;
											if (!flag10)
											{
												currentSkinData = interactingPlayer2._currentSkinData;
												bool flag11 = interactingPlayer2._currentSkinData == null;
												list3 = list2;
												if (!flag11)
												{
													if ((object)currentSkinData._003CstartingWeapon_003Ek__BackingField == null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r13_v47+20]");
														bool flag12 = (nint)0 == 0;
														list3 = list2;
														if (flag12)
														{
															goto IL_1614;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+1C]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+1C]");
															object obj4 = (nint)0 >> 32;
															bool flag13 = obj4 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+1C]");
															object obj5 = (nint)0 & (nint)(flag13 ? 1 : 0);
															bool flag14 = obj5 == null;
															object obj6 = !flag14;
															if (obj6 == null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+1C]");
																if (!IsWeaponSelectorType((WeaponType?)(object)0))
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+1C]");
																	weaponType = (WeaponType?)(object)0;
																	object obj7 = 0;
																	goto IL_17eb;
																}
															}
														}
													}
													else
													{
														object obj8 = (object?)currentSkinData._003CstartingWeapon_003Ek__BackingField >> 32;
														bool flag15 = obj8 == null;
														object obj9 = (_003F?)currentSkinData._003CstartingWeapon_003Ek__BackingField & flag15;
														bool flag16 = obj9 == null;
														object obj10 = !flag16;
														if (obj10 == null && !IsWeaponSelectorType(currentSkinData._003CstartingWeapon_003Ek__BackingField))
														{
															weaponType = currentSkinData._003CstartingWeapon_003Ek__BackingField;
															object obj7 = 0;
															goto IL_17eb;
														}
													}
													goto IL_0410;
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
		else
		{
			bool flag17 = arcanaData == null;
			list3 = (List<WeaponType>)(object)arcanaData;
			if (!flag17)
			{
				List<object> list4;
				nint num = default(nint);
				ArcanaType arcanaType;
				if (_ReorderWeaponsBasedOnOwnership)
				{
					Func<object, bool> func = delegate(object obj52)
					{
						//IL_0060: Expected I4, but got O
						if (obj52 != null)
						{
							string value3 = obj52.ToString();
							WeaponType weaponType4 = Enum.Parse<WeaponType>(value3);
							if (_ownedWeapons != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
								bool result2 = default(bool);
								return result2;
							}
						}
						NullReferenceException ex3 = new NullReferenceException();
						return (byte)(int)ex3 != 0;
					};
					List<WeaponType> source = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A8E590");
					list4 = Enumerable.ToList((IEnumerable<object>)source);
					num = 1;
					arcanaType = (ArcanaType)func;
				}
				else
				{
					list4 = arcanaData._003Cweapons_003Ek__BackingField;
					arcanaType = type;
				}
				bool flag18 = list4 == null;
				list3 = (List<WeaponType>)(object)arcanaData;
				if (!flag18)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					while (enumerator.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v6+10]");
						bool flag19 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v6+10]");
						Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)0;
						if (!flag19)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rax_v6+10]");
							string value = ((object)0).ToString();
							WeaponType weaponType2 = Enum.Parse<WeaponType>(value);
							dictionary = (Dictionary<System.Int32Enum, object>)(object)_weapons;
							bool flag20 = _weapons == null;
							if (!flag20)
							{
								int num2 = ((Dictionary<System.Int32Enum, object>)(object)_weapons).FindEntry((System.Int32Enum)weaponType2);
								arcanaType = ArcanaType.T00_KILLER;
								if (!flag20)
								{
									AddAffectedWeapon(weaponType2);
									arcanaType = ArcanaType.T00_KILLER;
								}
								continue;
							}
							goto IL_19d6;
						}
						throw new NullReferenceException();
					}
					bool flag21 = arcanaData == null;
					list3 = (List<WeaponType>)(object)arcanaData;
					if (!flag21)
					{
						List<object> list5 = arcanaData._003Citems_003Ek__BackingField;
						bool flag22 = arcanaData._003Citems_003Ek__BackingField == null;
						list3 = (List<WeaponType>)(object)arcanaData;
						if (!flag22)
						{
							List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
							if (enumerator2.MoveNext())
							{
								Dictionary<System.Int32Enum, object> dictionary = null;
								throw new NullReferenceException();
							}
							bool flag23 = type != ArcanaType.T08_MAD_FOREST;
							nint num3 = (nint)arcanaType;
							list3 = (List<WeaponType>)(object)arcanaData;
							if (flag23)
							{
								goto IL_1988;
							}
							GameManager core = GM.Core;
							bool flag24 = (object)GM.Core == null;
							list3 = (List<WeaponType>)(object)arcanaData;
							if (!flag24)
							{
								list3 = (List<WeaponType>)(object)_003C_003Ec._003C_003E9__20_2;
								if (_003C_003Ec._003C_003E9__20_2 == null)
								{
									Func<Pickup, bool> func2 = (_003C_003Ec._003C_003E9__20_2 = delegate(Pickup x)
									{
										//IL_0052: Expected I4, but got O
										//IL_0030: Expected O, but got I4
										if ((object)x == null)
										{
											NullReferenceException ex3 = new NullReferenceException();
											return (byte)(int)ex3 != 0;
										}
										object obj52 = x._003CPickupType_003Ek__BackingField - 13;
										return obj52 == null;
									});
									list5 = null;
									list3 = (List<WeaponType>)(object)func2;
								}
								IEnumerable<Pickup> enumerable = Enumerable.Where(core._stagePickups, (Func<Pickup, bool>)(object)list3);
								List<WeaponType> list6 = new List<WeaponType>();
								if (enumerable != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									List<WeaponType> list8 = default(List<WeaponType>);
									List<WeaponType> list7 = (List<WeaponType>)(&list8);
									Dictionary<System.Int32Enum, object> dictionary = null;
									object obj16 = default(object);
									object obj19 = default(object);
									object obj20 = default(object);
									Dictionary<System.Int32Enum, object> dictionary6 = default(Dictionary<System.Int32Enum, object>);
									object obj29 = default(object);
									while (true)
									{
										object obj15;
										if (list8 != null)
										{
											nint num4 = (nint)list8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2101 @ r10_v4 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+12E]");
											if ((nint)0 >= (nint)0)
											{
												goto IL_1264;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2101 @ r10_v4 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+B0]");
											num3 = 0;
											Dictionary<System.Int32Enum, object> dictionary2 = null;
											while (true)
											{
												object obj11 = (object)dictionary2 + (object)dictionary2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2591 @ r8_v45 (Il2CppMethodInfo)+v3705 @ rax_v56*8]");
												if (0 == (nint)typeof(IEnumerator))
												{
													break;
												}
												dictionary2 = (Dictionary<System.Int32Enum, object>)(dictionary2 + 1);
												Dictionary<System.Int32Enum, object> dictionary3 = dictionary2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2101 @ r10_v4 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+12E]");
												if ((nint)dictionary3 < 0)
												{
													continue;
												}
												goto IL_1264;
											}
											object obj12 = (object)dictionary2 + (object)dictionary2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2591 @ r8_v45 (Il2CppMethodInfo)+8+v3934 @ rcx_v47*8]");
											object obj13 = (nint)0 << 4;
											object obj14 = obj13 + 312;
											obj15 = obj14 + num4;
											goto IL_1b8f;
										}
										throw new NullReferenceException();
										IL_1264:
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
										num3 = unchecked((nint)null);
										obj15 = obj16;
										goto IL_1b8f;
										IL_1321:
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
										object obj17 = 0;
										object obj18 = obj19;
										goto IL_1bb6;
										IL_1b8f:
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3939 @ rdx_v15] (should have been resolved before IL gen)");
										if (obj20 == null)
										{
											break;
										}
										bool flag25 = list8 == null;
										dictionary = (Dictionary<System.Int32Enum, object>)(object)list8;
										if (!flag25)
										{
											nint num5 = (nint)list8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1816 @ r10_v5 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+12E]");
											if ((nint)0 >= (nint)0)
											{
												goto IL_1321;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1816 @ r10_v5 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+B0]");
											obj17 = 0;
											Dictionary<System.Int32Enum, object> dictionary4 = null;
											while (true)
											{
												object obj21 = (object)dictionary4 + (object)dictionary4;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4362 @ r8_v13+v4155 @ rax_v51*8]");
												if (0 == (nint)typeof(IEnumerator<Pickup>))
												{
													break;
												}
												dictionary4 = (Dictionary<System.Int32Enum, object>)(dictionary4 + 1);
												Dictionary<System.Int32Enum, object> dictionary5 = dictionary4;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1816 @ r10_v5 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+12E]");
												if ((nint)dictionary5 < 0)
												{
													continue;
												}
												goto IL_1321;
											}
											object obj22 = (object)dictionary4 + (object)dictionary4;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4362 @ r8_v13+8+v4357 @ rcx_v41*8]");
											object obj23 = (nint)0 << 4;
											object obj24 = obj23 + 312;
											obj18 = obj24 + num5;
											goto IL_1bb6;
										}
										throw new NullReferenceException();
										IL_1bb6:
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4363 @ rdx_v20] (should have been resolved before IL gen)");
										bool flag26 = dictionary6 == null;
										dictionary = (Dictionary<System.Int32Enum, object>)(object)list8;
										if (!flag26)
										{
											nint num6 = (nint)dictionary6;
											nint num7 = (nint)typeof(PickupWeapon);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1845 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
											dictionary = (Dictionary<System.Int32Enum, object>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ rax_v34 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+130]");
											nint num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1845 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
											if (num8 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ rax_v34 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+C8]");
												object obj25 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1985 @ rax_v35+FFFFFFF8+v2294 @ rcx_v118 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)*8]");
												if (0 == (nint)typeof(PickupWeapon))
												{
													nint num9 = (nint)dictionary6;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1845 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
													object obj26 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4443 @ rax_v36 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+C8]");
													object obj27 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4445 @ rax_v37+FFFFFFF8+v4444 @ rcx_v29*8]");
													object obj28 = 0 - typeof(PickupWeapon);
													bool flag27 = obj28 == null;
													bool flag28 = !flag27;
													dictionary = null;
													if (!flag28)
													{
														dictionary = dictionary6;
													}
													if (list6 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3173 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
														bool flag29 = (nint)0 == 0;
														nint num10 = num;
														nint num11 = (nint)typeof(IEnumerator<Pickup>);
														if (!flag29)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3173 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
															num11 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3173 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
															dictionary = (Dictionary<System.Int32Enum, object>)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
															bool flag30 = (nint)obj29 != -1;
															num10 = 0;
															num = 0;
															if (flag30)
															{
																continue;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2294 @ rcx_v118 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+1F0]");
														AddAffectedWeapon(WeaponType.VOID);
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
														num = num10;
														dictionary = (Dictionary<System.Int32Enum, object>)(object)list6;
														continue;
													}
													throw new NullReferenceException();
												}
											}
										}
										throw new NullReferenceException();
									}
									if (list7 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
										num3 = (nint)list7;
									}
									goto IL_1988;
								}
							}
						}
					}
				}
			}
		}
		goto IL_1614;
		IL_1988:
		List<GameObject> affectedWeapons = _affectedWeapons;
		if (_affectedWeapons != null)
		{
			if (affectedWeapons._size > _MaxWeaponsBeforeGrid)
			{
				List<GameObject>.Enumerator enumerator3 = default(List<GameObject>.Enumerator);
				while (enumerator3.MoveNext())
				{
					List<WeaponType> list9 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2627 @ rbx_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					bool flag31 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2627 @ rbx_v20 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					GameObject.SetActive_Injected((IntPtr)0, false);
				}
				SetGridActive();
			}
			return;
		}
		goto IL_1614;
		IL_17b5:
		throw new NullReferenceException();
		IL_06ee:
		bool flag32 = list == null;
		list3 = list2;
		if (!flag32)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)list2);
			bool flag33 = list2 == null;
			list3 = list2;
			if (!flag33)
			{
				list3 = list2;
				object obj30 = default(object);
				object obj31 = default(object);
				object obj33 = default(object);
				while (true)
				{
					if (obj30 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-118_v45+1C]");
						if (obj31 != null)
						{
							break;
						}
						object obj32 = obj33;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-118_v45+18]");
						if ((nint)obj32 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-118_v45+10]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-118_v45+10]");
						if ((nint)0 != 0)
						{
							object obj35 = obj33;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1018 @ rdx_v160+18]");
							if ((nint)obj35 < 0)
							{
								object obj36 = obj33 + 1;
								if (_weapons != null)
								{
									Dictionary<WeaponType, List<WeaponData>> weapons = _weapons;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1018 @ rdx_v160+20+v997 @ stack_-110_v43*4]");
									object obj37 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)0);
									if (obj37 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rax_v324 (System.Object)+18]");
										if ((nint)0 > (nint)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rax_v324 (System.Object)+10]");
											list3 = (List<WeaponType>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1194 @ rax_v324 (System.Object)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
												if ((nint)0 > (nint)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+20]");
													list3 = (List<WeaponType>)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+20]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+50]");
														CharacterData characterData = (CharacterData)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+50]");
														if ((nint)0 != 0 && (characterData._003CallowCoopOutline_003Ek__BackingField ? 1 : 0) > (false ? 1 : 0))
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+50]");
															WeaponType key = Enum.Parse<WeaponType>((string)0);
															List<WeaponData> list10 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item(key);
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+50]");
														list3 = (List<WeaponType>)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3545 @ r14_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+50]");
														bool flag34 = Enum.TryParse<WeaponType>((string)0, out var result);
														bool flag35 = result == WeaponType.VOID;
														obj33 = obj36;
														if (flag35)
														{
															continue;
														}
														if (_weapons != null)
														{
															object obj38 = ((Dictionary<System.Int32Enum, object>)(object)_weapons).get_Item((System.Int32Enum)result);
															if (obj38 != null)
															{
																List<WeaponData> list11 = ((Dictionary<WeaponType, List<WeaponData>>)obj38).get_Item(WeaponType.VOID);
																if (list11 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1267 @ rax_v330 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+50]");
																	nint num12 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1267 @ rax_v330 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+50]");
																	bool flag36 = (nint)0 == 0;
																	obj33 = obj36;
																	if (!flag36)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4574 @ rcx_v234 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>>)+10]");
																		bool flag37 = (nint)0 <= (nint)0;
																		obj33 = obj36;
																		if (!flag37)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1267 @ rax_v330 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+50]");
																			WeaponType key2 = Enum.Parse<WeaponType>((string)0);
																			List<WeaponData> list12 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item(key2);
																			obj33 = obj36;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1267 @ rax_v330 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+50]");
																			list3 = (List<WeaponType>)0;
																		}
																	}
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
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new IndexOutOfRangeException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				bool flag38 = obj30 == null;
				nint num13 = 0;
				if (!flag38)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-118_v45+1C]");
					if (obj31 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ stack_-118_v45+18]");
						object obj39 = (nint)0 + (nint)1;
						if (arcanaData != null && arcanaData._003Cweapons_003Ek__BackingField != null)
						{
							List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
							while (enumerator4.MoveNext())
							{
								List<WeaponType> list13 = null;
								string value2 = null;
								WeaponType item = Enum.Parse<WeaponType>(value2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								object obj40 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								nint num14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								bool flag39 = (nint)0 == 0;
								list3 = null;
								if (!flag39)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									nint num15 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3350 @ rcx_v219+18]");
									if (num15 >= 0)
									{
										((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)item);
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									object obj41 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v222 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									nint num16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3350 @ rcx_v219+18]");
									bool flag40 = num16 >= 0;
									list3 = null;
									if (!flag40)
									{
										continue;
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							IEnumerable<WeaponType> enumerable2 = Enumerable.Distinct(list);
							if (enumerable2 == null)
							{
								Exception ex = System.Linq.Error.ArgumentNull("source");
								throw ex;
							}
							List<WeaponType> list14 = (List<WeaponType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable2);
							bool flag41 = !_ReorderWeaponsBasedOnOwnership;
							List<WeaponType> list15 = list14;
							list3 = (List<WeaponType>)0;
							if (!flag41)
							{
								Func<WeaponType, bool> func3 = delegate
								{
									//IL_0057: Expected O, but got Ref
									//IL_004e: Expected I4, but got O
									object obj52 = default(object);
									string value3 = ((Enum)(&obj52)).ToString();
									WeaponType weaponType4 = Enum.Parse<WeaponType>(value3);
									if (_ownedWeapons == null)
									{
										NullReferenceException ex3 = new NullReferenceException();
										return (byte)(int)ex3 != 0;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
									bool result2 = default(bool);
									return result2;
								};
								IEnumerable<System.Int32Enum> enumerable3 = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A8E590");
								if (enumerable3 == null)
								{
									Exception ex2 = System.Linq.Error.ArgumentNull("source");
									throw ex2;
								}
								List<WeaponType> list16 = (List<WeaponType>)(object)new List<System.Int32Enum>(enumerable3);
								list15 = list16;
								list3 = (List<WeaponType>)0;
							}
							if (list15 != null)
							{
								object obj42 = obj39;
								object obj43 = default(object);
								while (true)
								{
									if (obj43 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ stack_-118_v47+1C]");
										if (obj31 == null)
										{
											object obj44 = obj42;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ stack_-118_v47+18]");
											if ((nint)obj44 < 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ stack_-118_v47+10]");
												object obj45 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ stack_-118_v47+10]");
												if ((nint)0 != 0)
												{
													object obj46 = obj42;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3657 @ rdx_v146+18]");
													if ((nint)obj46 < 0)
													{
														object obj47 = obj42 + 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3657 @ rdx_v146+20+v3636 @ stack_-110_v45*4]");
														AddAffectedWeapon(WeaponType.VOID);
														obj42 = obj47;
														continue;
													}
													throw new IndexOutOfRangeException();
												}
												throw new NullReferenceException();
											}
											break;
										}
										break;
									}
									throw new NullReferenceException();
								}
								bool flag42 = obj43 == null;
								nint num17 = 0;
								if (!flag42)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2329 @ stack_-118_v47+1C]");
									if (obj31 == null)
									{
										nint num3 = 0;
										goto IL_1988;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									num17 = unchecked((nint)null);
								}
								throw new NullReferenceException();
							}
						}
						goto IL_1614;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num13 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
		}
		goto IL_1614;
		IL_19d6:
		throw new NullReferenceException();
		IL_0410:
		bool flag43 = IsWeaponSelectorType(currentSkinData._003CstartingWeapon_003Ek__BackingField);
		object obj48 = 0;
		if (!flag43)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r13_v47+20]");
			bool flag44 = (nint)0 == 0;
			list3 = list2;
			if (flag44)
			{
				goto IL_1614;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+1C]");
			bool flag45 = IsWeaponSelectorType((WeaponType?)(object)0);
			bool flag46 = !flag45;
			obj48 = 0;
			object obj49 = 0;
			if (flag46)
			{
				goto IL_053d;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController controllingCharacter = _controllingCharacter;
		bool flag47 = (object)_controllingCharacter == null;
		list3 = list2;
		if (!flag47)
		{
			bool flag48 = list2 == null;
			list3 = list2;
			if (!flag48)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r13_v47+20]");
				bool flag49 = (nint)0 == 0;
				object obj49 = obj48;
				list3 = list2;
				if (!flag49)
				{
					goto IL_053d;
				}
			}
		}
		goto IL_1614;
		IL_053d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+158]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+158]");
			object obj50 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4381 @ rax_v346+18]");
			if ((nint)0 > (nint)0)
			{
				List<WeaponType> list17 = new List<WeaponType>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ r13_v48+158]");
				bool flag50 = (nint)0 == 0;
				list3 = list2;
				if (!flag50)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
					List<string>.Enumerator enumerator5 = default(List<string>.Enumerator);
					while (enumerator5.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4491 @ rax_v349+10]");
						WeaponType weaponType3 = Enum.Parse<WeaponType>((string)0);
						bool flag51 = list17 == null;
						list3 = list2;
						if (!flag51)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							continue;
						}
						goto IL_17b5;
					}
					bool flag52 = list2 == null;
					list3 = list2;
					if (!flag52)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rax_v224 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						((List<System.Int32Enum>)(object)list2).InsertRange(0, (IEnumerable<System.Int32Enum>)list17);
						goto IL_06ee;
					}
				}
				goto IL_1614;
			}
		}
		goto IL_06ee;
		IL_1614:
		throw new NullReferenceException();
		IL_17eb:
		bool flag53 = (object)weaponType == null;
		list3 = list2;
		if (!flag53)
		{
			bool flag54 = list2 == null;
			list3 = list2;
			if (!flag54)
			{
				object obj51 = (object?)weaponType >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				goto IL_0410;
			}
			goto IL_1614;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		string text = null;
		goto IL_17b5;
	}

	private unsafe void SetGridActive()
	{
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0128: Expected O, but got I4
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_0195: Invalid comparison between F4 and O
		//IL_01a7->IL01a7: Incompatible stack heights: 1 vs 0
		//IL_0279->IL01b1: Incompatible stack heights: 1 vs 0
		//IL_03ed->IL040b: Incompatible stack heights: 6 vs 0
		GameObject gameObject = _DynamicGrid.gameObject;
		gameObject.SetActive(value: true);
		List<GameObject> affectedWeapons = _affectedWeapons;
		int num = affectedWeapons._size / _MaxWeaponsBeforeGrid;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		GridLayoutGroup component = _DynamicGrid.GetComponent<GridLayoutGroup>();
		object obj = default(object);
		Vector2 vector = default(Vector2);
		if ((nint)obj != 2)
		{
			object obj2 = obj - 3;
			object obj3 = obj ^ 3;
			object obj4 = obj ^ obj2;
			object obj5 = obj3 & obj4;
			bool flag = (nint)obj5 < 0;
			bool flag2 = (nint)obj2 < 0;
			bool flag3 = (nint)obj == 3;
			if (!flag3)
			{
				bool flag4 = flag2 == flag;
				object obj6 = !flag4;
				object obj7 = obj6 | flag3;
				if (obj7 != null)
				{
					goto IL_040b;
				}
				RectTransform component2 = component.GetComponent<RectTransform>();
				bool flag5 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				List<GameObject> ret;
				RectTransform.get_rect_Injected(((UnityEngine.Object)component2).m_CachedPtr, out *(Rect*)(&ret));
				List<GameObject> affectedWeapons2 = _affectedWeapons;
				float num2 = (float)affectedWeapons2._size / 3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
				object obj9 = default(object);
				object obj10 = default(object);
				object obj8 = obj9 / obj10;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)50f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
				{
					component.cellSize = vector;
					component.spacing = vector;
					goto IL_01b1;
				}
			}
			object obj11 = component + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
			object obj12 = component + 112;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
		}
		else
		{
			object obj13 = component + 104;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
			object obj14 = component + 112;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
		}
		goto IL_01b1;
		IL_01b1:
		_DynamicGrid.anchoredPosition = vector;
		goto IL_040b;
		IL_040b:
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		List<GameObject>.Enumerator value = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			GridLayoutGroup gridLayoutGroup = null;
			bool flag6 = ((UnityEngine.Object)gridLayoutGroup).m_CachedPtr == (IntPtr)0;
			GameObject.SetActive_Injected(((UnityEngine.Object)gridLayoutGroup).m_CachedPtr, true);
			bool flag7 = ((UnityEngine.Object)gridLayoutGroup).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gridLayoutGroup).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag8 = (object)transform == null;
			transform.SetParent(_DynamicGrid, worldPositionStays: true);
			bool flag9 = ((UnityEngine.Object)gridLayoutGroup).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)gridLayoutGroup).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			bool flag10 = (object)transform2 == null;
			bool flag11 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	private unsafe void AddAffectedWeapon(WeaponType weaponType)
	{
		//IL_006d: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_016e: Expected I, but got O
		//IL_0203: Expected O, but got I4
		//IL_020b: Expected O, but got Ref
		Dictionary<System.Int32Enum, object> weapons = (Dictionary<System.Int32Enum, object>)(object)_weapons;
		if (_weapons != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)_weapons).get_Item((System.Int32Enum)weaponType);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v20 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v20 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v20 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v21+18]");
					if ((nint)0 <= (nint)0)
					{
						throw new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v21+20]");
					weapons = (Dictionary<System.Int32Enum, object>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v21+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v4 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+40]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v4 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+38]");
						Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
						if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
						{
							WeaponType weaponType2 = default(WeaponType);
							object message = weaponType2;
							nint num2 = (nint)typeof(Debug);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ rcx_v35 (Il2CppClass<UnityEngine.Debug>)+E4]");
							bool flag = (nint)0 != 0;
							Debug.LogError(message);
						}
						GameManager core = GM.Core;
						if ((object)GM.Core != null && core._mainCharacters != null)
						{
							bool isOwned = false;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							GenerateImageForAffectedWeapon(sprite, isOwned);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void AddAffectedItem(ItemType itemType)
	{
		//IL_0044: Expected O, but got I
		//IL_0044: Expected O, but got I
		//IL_008a: Expected I4, but got O
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_items).get_Item((System.Int32Enum)itemType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Object)+38]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Object)+30]");
		Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
		if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
		{
			object obj2 = default(object);
			object message = (ItemType)obj2;
			Debug.LogError(message);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 213 Invalid \"Jump target not found in method: 0x186982200\"");
		throw new NullReferenceException();
	}

	private unsafe void GenerateImageForAffectedWeapon(Sprite weaponSprite, bool isOwned)
	{
		//IL_0084: Expected O, but got Ref
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_01ea->IL0184: Incompatible stack heights: 1 vs 0
		//IL_00ae->IL0184: Incompatible stack heights: 1 vs 0
		Image image = UnityEngine.Object.Instantiate(_AffectedWeaponImageTemplate, _AffectedWeaponGroup);
		if ((object)image != null)
		{
			Transform transform = image.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			RectTransform rectTransform = image.rectTransform;
			Vector2 sizeDelta = default(Vector2);
			rectTransform.sizeDelta = sizeDelta;
			RectTransform rectTransform2 = image.rectTransform;
			if ((object)rectTransform2 != null)
			{
				Vector3 value2 = default(Vector3);
				rectTransform2.localEulerAngles = (Vector3)(&value2);
				RectTransform rectTransform3 = image.rectTransform;
				if ((object)rectTransform3 != null)
				{
					Transform transform2 = rectTransform3.transform;
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
					image.enabled = isOwned;
					Transform transform3 = image.transform;
					bool flag4 = (object)transform3 == null;
					Transform child = transform3.GetChild(0);
					bool flag5 = (object)child == null;
					Image component = child.GetComponent<Image>();
					bool flag6 = (object)component == null;
					component.sprite = weaponSprite;
					object obj = image + 244;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77350");
					object obj2 = default(object);
					if (obj2 != null)
					{
						image.SetVerticesDirty();
					}
					GameObject gameObject = image.gameObject;
					bool flag7 = _affectedWeapons == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					GameObject gameObject2 = image.gameObject;
					bool flag8 = (object)gameObject2 == null;
					gameObject2.SetActive(value: true);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ClearAffectedWeapons()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		bool flag = _affectedWeapons == null;
		ArcanaInfoPanel arcanaInfoPanel = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			arcanaInfoPanel = (ArcanaInfoPanel)(object)_affectedWeapons;
			if (_affectedWeapons != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v2 (VampireSurvivors.UI.ArcanaInfoPanel)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)arcanaInfoPanel).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)arcanaInfoPanel).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 0, (int)((MonoBehaviour)arcanaInfoPanel).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
	}

	public ArcanaInfoPanel()
	{
		List<GameObject> affectedWeapons = new List<GameObject>();
		_affectedWeapons = affectedWeapons;
		List<Equipment> equipment = new List<Equipment>();
		_equipment = equipment;
		List<WeaponType> ownedWeapons = new List<WeaponType>();
		_ownedWeapons = ownedWeapons;
	}

	private unsafe bool _003CPopulateAffectedWeaponCarousel_003Eb__20_0(WeaponType weaponType)
	{
		//IL_0057: Expected O, but got Ref
		//IL_004e: Expected I4, but got O
		object obj = default(object);
		string value = ((Enum)(&obj)).ToString();
		WeaponType weaponType2 = Enum.Parse<WeaponType>(value);
		if (_ownedWeapons != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool _003CPopulateAffectedWeaponCarousel_003Eb__20_1(object weaponType)
	{
		//IL_0060: Expected I4, but got O
		if (weaponType != null)
		{
			string value = weaponType.ToString();
			WeaponType weaponType2 = Enum.Parse<WeaponType>(value);
			if (_ownedWeapons != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				bool result = default(bool);
				return result;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
