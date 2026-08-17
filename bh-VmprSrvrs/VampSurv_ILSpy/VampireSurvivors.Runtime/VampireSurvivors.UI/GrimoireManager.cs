using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI;

public class GrimoireManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, WeaponType> _003C_003E9__23_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal WeaponType _003CInit_003Eb__23_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}
	}

	private GameObject _EvolutionPrefab;

	private List<RectTransform> _Containers;

	private GameObject _ButtonsNoMap;

	private GameObject _ButtonsHasMap;

	private GameObject _Pager;

	private PageManager _PageManager;

	private GameObject _ContainerPrefab;

	private RectTransform _ContainerContainer;

	private CanvasGroup _CanvasGroup;

	private float _DefaultAlpha;

	private float _AlphaWhileArcanaInfoShown;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private DataManager _data;

	private GameSessionData _session;

	private List<Equipment> _equipment;

	private List<EvolutionItemUI> _evolutionItems;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private List<EvolutionData> _evolutionData;

	private List<WeaponType> _ownedWeapons;

	private List<GameObject> _spawned;

	private RectTransform _ActiveContainer;

	private void Construct(SignalBus signal, PlayerOptions player, DataManager data, GameSessionData session)
	{
		_playerOptions = player;
		_signalBus = signal;
		_data = data;
		GameSessionData session2 = default(GameSessionData);
		_session = session2;
	}

	public void Init()
	{
		//IL_01db: Expected O, but got I4
		//IL_0451: Expected I, but got O
		//IL_18f7: Expected O, but got I8
		//IL_1900: Expected O, but got I4
		//IL_0525: Expected O, but got I
		//IL_0525: Expected I4, but got O
		//IL_0548: Expected I, but got O
		//IL_04f9: Expected O, but got I
		//IL_190a: Expected I, but got O
		//IL_050d: Expected I, but got O
		//IL_0608: Expected O, but got I
		//IL_0608: Expected I4, but got O
		//IL_1e5d: Expected O, but got I4
		//IL_1bea: Expected O, but got I
		//IL_1938: Expected O, but got I4
		//IL_1df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dfe: Expected O, but got Unknown
		//IL_05c3: Expected I, but got O
		//IL_05c8: Expected I, but got O
		//IL_2082: Expected O, but got I
		//IL_1bd5: Expected O, but got I
		//IL_1f3a: Expected I, but got O
		//IL_0684: Expected O, but got I
		//IL_0684: Expected I4, but got O
		//IL_1b9b: Expected O, but got I
		//IL_1c3c: Expected O, but got I4
		//IL_1c3c: Expected O, but got I
		//IL_1c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4a: Expected O, but got Unknown
		//IL_1c69: Expected I, but got O
		//IL_1b59: Expected O, but got I
		//IL_1ab0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab5: Expected O, but got Unknown
		//IL_1aba: Expected I, but got O
		//IL_0700: Expected O, but got I
		//IL_0700: Expected I4, but got O
		//IL_1c81: Expected O, but got I4
		//IL_1fcb: Expected I4, but got O
		//IL_1ebc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec1: Expected O, but got Unknown
		//IL_1a53: Expected O, but got I4
		//IL_07d7: Expected O, but got I
		//IL_07d7: Expected I4, but got O
		//IL_0b04: Expected O, but got I
		//IL_0b04: Expected I4, but got O
		//IL_084f: Expected O, but got I
		//IL_084f: Expected I4, but got O
		//IL_0db9: Expected O, but got I
		//IL_0db9: Expected I4, but got O
		//IL_0b7c: Expected O, but got I
		//IL_0b7c: Expected I4, but got O
		//IL_1686: Expected O, but got I
		//IL_1686: Expected I4, but got O
		//IL_115e: Expected O, but got I
		//IL_115e: Expected I4, but got O
		//IL_08c7: Expected O, but got I
		//IL_08c7: Expected I4, but got O
		//IL_0e31: Expected O, but got I
		//IL_0e31: Expected I4, but got O
		//IL_17ff: Expected O, but got I
		//IL_17ff: Expected I4, but got O
		//IL_180e: Expected I, but got O
		//IL_0bf4: Expected O, but got I
		//IL_0bf4: Expected I4, but got O
		//IL_16f8: Expected O, but got I
		//IL_16f8: Expected I4, but got O
		//IL_11d6: Expected O, but got I
		//IL_11d6: Expected I4, but got O
		//IL_093f: Expected O, but got I
		//IL_093f: Expected I4, but got O
		//IL_1862: Expected O, but got I
		//IL_0ea9: Expected O, but got I
		//IL_0ea9: Expected I4, but got O
		//IL_17b6: Expected O, but got I
		//IL_17b6: Expected I4, but got O
		//IL_0c6c: Expected O, but got I
		//IL_0c6c: Expected I4, but got O
		//IL_17ca: Expected I, but got O
		//IL_176d: Expected O, but got I
		//IL_176d: Expected I4, but got O
		//IL_1781: Expected I, but got O
		//IL_124e: Expected O, but got I
		//IL_124e: Expected I4, but got O
		//IL_09b7: Expected O, but got I
		//IL_09b7: Expected I4, but got O
		//IL_0f21: Expected O, but got I
		//IL_0f21: Expected I4, but got O
		//IL_0ce4: Expected O, but got I
		//IL_0ce4: Expected I4, but got O
		//IL_12c6: Expected O, but got I
		//IL_12c6: Expected I4, but got O
		//IL_0a2f: Expected O, but got I
		//IL_0a2f: Expected I4, but got O
		//IL_0f99: Expected O, but got I
		//IL_0f99: Expected I4, but got O
		//IL_133e: Expected O, but got I
		//IL_133e: Expected I4, but got O
		//IL_1011: Expected O, but got I
		//IL_1011: Expected I4, but got O
		//IL_13b6: Expected O, but got I
		//IL_13b6: Expected I4, but got O
		//IL_1089: Expected O, but got I
		//IL_1089: Expected I4, but got O
		//IL_142e: Expected O, but got I
		//IL_142e: Expected I4, but got O
		//IL_14a6: Expected O, but got I
		//IL_14a6: Expected I4, but got O
		//IL_151e: Expected O, but got I
		//IL_151e: Expected I4, but got O
		//IL_1596: Expected O, but got I
		//IL_1596: Expected I4, but got O
		//IL_160e: Expected O, but got I
		//IL_160e: Expected I4, but got O
		//IL_03f1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_046d->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_18e0->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1deb->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_04e1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_05f0->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_206d->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0570->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1ae8->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0620->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1e75->IL1ec6: Incompatible stack heights: 2 vs 1
		//IL_059c->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1e22->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_066c->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_20a2->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1f3f->IL2049: Incompatible stack heights: 2 vs 1
		//IL_1a71->IL1ec6: Incompatible stack heights: 3 vs 1
		//IL_069c->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1bbb->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1abf->IL1ec6: Incompatible stack heights: 4 vs 1
		//IL_1f90->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_06e8->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0718->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1fef->IL1cfc: Incompatible stack heights: 2 vs 0
		//IL_1ec6->IL1948: Incompatible stack heights: 4 vs 3
		//IL_0770->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1a45->IL1eb3: Incompatible stack heights: 6 vs 4
		//IL_2044->IL1cfc: Incompatible stack heights: 3 vs 0
		//IL_1a59->IL1eb3: Incompatible stack heights: 6 vs 4
		//IL_0a9d->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_07c1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_07ef->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0d52->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0aee->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0b1c->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0839->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_10f7->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0da3->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0867->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0dd1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0b66->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1670->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1148->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0b94->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_08b1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_169e->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1176->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0e1b->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_08df->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_17e9->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0e49->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0bde->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_16e2->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_11c0->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0c0c->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0929->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1837->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1710->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_11ee->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0e93->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0957->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_187a->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_17a0->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0ec1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0c56->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1757->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1238->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0c84->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_09a1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1266->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0f0b->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_09cf->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0f39->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0cce->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_12b0->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0cfc->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0a19->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_12de->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0f83->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0a47->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0fb1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1328->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1356->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_0ffb->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1029->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_13a0->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_13ce->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1073->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_10a1->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1418->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1446->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1490->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_14be->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1508->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1536->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1580->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_15ae->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_15f8->IL1cfc: Incompatible stack heights: 1 vs 0
		//IL_1626->IL1cfc: Incompatible stack heights: 1 vs 0
		Clear();
		if (_data != null)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
			_weapons = convertedWeapons;
			List<Equipment> equipment = new List<Equipment>();
			_equipment = equipment;
			List<object> equipment2 = (List<object>)(object)_equipment;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = core._003CPausingPlayer_003Ek__BackingField;
				if ((object)core._003CPausingPlayer_003Ek__BackingField != null)
				{
					CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
					if ((object)characterController._weaponsManager != null && _equipment != null)
					{
						((List<object>)(object)_equipment).InsertRange(equipment2._size, (IEnumerable<object>)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
						if (_playerOptions != null)
						{
							PlayerOptionsData config = _playerOptions.Config;
							if (config != null)
							{
								if (config._003CSelectedSharePassives_003Ek__BackingField)
								{
									GameManager core2 = GM.Core;
									if ((object)GM.Core != null && core2._characters != null)
									{
										List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
										if (enumerator.MoveNext())
										{
											List<object> equipment3 = (List<object>)(object)_equipment;
											object obj = 0;
											throw new NullReferenceException();
										}
										goto IL_1d6f;
									}
								}
								else
								{
									List<object> equipment4 = (List<object>)(object)_equipment;
									GameManager core3 = GM.Core;
									if ((object)GM.Core != null)
									{
										VampireSurvivors.Objects.Characters.CharacterController characterController2 = core3._003CPausingPlayer_003Ek__BackingField;
										if ((object)core3._003CPausingPlayer_003Ek__BackingField != null)
										{
											CharacterAccessoriesManager accessoriesManager = characterController2._accessoriesManager;
											if ((object)characterController2._accessoriesManager != null && _equipment != null)
											{
												((List<object>)(object)_equipment).InsertRange(equipment4._size, (IEnumerable<object>)((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField);
												goto IL_1d6f;
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
		goto IL_1cfc;
		IL_1d6f:
		Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__23_0;
		if (_003C_003Ec._003C_003E9__23_0 == null)
		{
			selector = (_003C_003Ec._003C_003E9__23_0 = delegate(Equipment x)
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
			List<Equipment> ownedWeapons = (List<Equipment>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			_ownedWeapons = (List<WeaponType>)(object)ownedWeapons;
			nint num = 0;
			CreateEvolutionList();
			AddNewContainer();
			List<RectTransform> containers = _Containers;
			if (_Containers != null)
			{
				bool flag = containers._size <= 0;
				RectTransform[] items = containers._items;
				if (containers._items != null)
				{
					if (items.Length <= 0)
					{
						throw new IndexOutOfRangeException();
					}
					_ActiveContainer = items[0];
					List<EvolutionData> evolutionData = _evolutionData;
					bool flag2 = _evolutionData == null;
					nint num2 = unchecked((nint)null);
					int num3 = 0;
					List<Equipment> list = null;
					List<Equipment> list2 = null;
					if (!flag2)
					{
						RectTransform activeContainer = default(RectTransform);
						EvolutionData d = default(EvolutionData);
						object obj2 = default(object);
						object obj3 = default(object);
						object obj4 = default(object);
						object obj5 = default(object);
						object obj6 = default(object);
						object obj7 = default(object);
						object obj8 = default(object);
						object obj9 = default(object);
						object obj10 = default(object);
						List<RectTransform>.Enumerator enumerator2 = default(List<RectTransform>.Enumerator);
						object obj14 = default(object);
						object obj15 = default(object);
						object obj16 = default(object);
						object obj17 = default(object);
						object obj18 = default(object);
						object obj19 = default(object);
						object obj20 = default(object);
						object obj21 = default(object);
						object obj22 = default(object);
						object obj23 = default(object);
						object obj24 = default(object);
						object obj25 = default(object);
						List<WeaponType> list6 = default(List<WeaponType>);
						object obj29 = default(object);
						object obj30 = default(object);
						EvolutionData d2 = default(EvolutionData);
						EvolutionData d3 = default(EvolutionData);
						EvolutionData d4 = default(EvolutionData);
						GameObject gameObject3 = default(GameObject);
						object obj31 = default(object);
						object obj32 = default(object);
						object obj33 = default(object);
						object obj34 = default(object);
						object obj35 = default(object);
						object obj36 = default(object);
						object obj37 = default(object);
						object obj38 = default(object);
						object obj39 = default(object);
						object obj40 = default(object);
						object obj41 = default(object);
						while (true)
						{
							if ((nint)list2 < evolutionData._size)
							{
								if (num2 >= 21)
								{
									num3++;
									AddNewContainer();
									if (_Containers == null)
									{
										break;
									}
									((List<Equipment>)(object)_Containers).InsertRange(num3, (IEnumerable<Equipment>)num);
									_ActiveContainer = activeContainer;
									num2 = unchecked((nint)null);
								}
								if (_evolutionData == null)
								{
									break;
								}
								((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)num);
								bool flag3 = RequiresYellowSign(d);
								bool flag4 = !flag3;
								nint num4 = unchecked((nint)null);
								if (!flag4)
								{
									if (_playerOptions == null)
									{
										break;
									}
									PlayerOptionsData config2 = _playerOptions.Config;
									if (config2 == null)
									{
										break;
									}
									bool flag5 = config2.HasCollectedItem(ItemType.RELIC_YELLOW);
									bool flag6 = !flag5;
									num4 = unchecked((nint)null);
									num = unchecked((nint)null);
									if (flag6)
									{
										goto IL_1df0;
									}
								}
								if (_evolutionData == null)
								{
									break;
								}
								((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)num4);
								if (obj2 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rax_v164+10]");
								bool flag7 = (nint)0 == 128;
								num = num4;
								if (!flag7)
								{
									if (_evolutionData == null)
									{
										break;
									}
									((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)num4);
									if (obj3 == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v165+10]");
									bool flag8 = (nint)0 == 98;
									num = num4;
									if (!flag8)
									{
										if (_evolutionData == null)
										{
											break;
										}
										((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)num4);
										if (obj4 == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v166+10]");
										bool flag9 = (nint)0 == 148;
										num = num4;
										if (!flag9)
										{
											Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
											if (loadedDlc == null)
											{
												break;
											}
											int num5 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)0);
											if (num5 >= 0)
											{
												goto IL_0a7c;
											}
											if (_evolutionData == null)
											{
												break;
											}
											((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
											if (obj5 == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v220+10]");
											bool flag10 = (nint)0 == 112;
											num = 0;
											if (!flag10)
											{
												if (_evolutionData == null)
												{
													break;
												}
												((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
												if (obj6 == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v221+10]");
												bool flag11 = (nint)0 == 114;
												num = 0;
												if (!flag11)
												{
													if (_evolutionData == null)
													{
														break;
													}
													((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
													if (obj7 == null)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v222+10]");
													bool flag12 = (nint)0 == 116;
													num = 0;
													if (!flag12)
													{
														if (_evolutionData == null)
														{
															break;
														}
														((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
														if (obj8 == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v223+10]");
														bool flag13 = (nint)0 == 118;
														num = 0;
														if (!flag13)
														{
															if (_evolutionData == null)
															{
																break;
															}
															((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
															if (obj9 == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v224+10]");
															bool flag14 = (nint)0 == 121;
															num = 0;
															if (!flag14)
															{
																if (_evolutionData == null)
																{
																	break;
																}
																((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
																if (obj10 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v225+10]");
																bool flag15 = (nint)0 == 119;
																num = 0;
																if (!flag15)
																{
																	goto IL_0a7c;
																}
															}
														}
													}
												}
											}
										}
									}
								}
								goto IL_1df0;
							}
							if (_Containers == null)
							{
								break;
							}
							RectTransform rectTransform = (RectTransform)6603577472L;
							object obj11 = 0;
							while (enumerator2.MoveNext())
							{
								nint num6 = unchecked((nint)null);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ rsi_v31 (Il2CppMethodInfo)+10]");
								bool flag16 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ rsi_v31 (Il2CppMethodInfo)+10]");
								object obj12 = Transform.get_childCount_Injected((IntPtr)0);
								if (obj12 == null)
								{
									continue;
								}
								RectTransform[] componentsInChildren = ((Component)null).GetComponentsInChildren<RectTransform>();
								bool flag17 = componentsInChildren == null;
								object obj13 = 0;
								List<Equipment> list3 = null;
								while ((nint)list3 < componentsInChildren.Length)
								{
									bool flag18 = (nint)list3 >= componentsInChildren.Length;
									rectTransform = componentsInChildren[(object)list3];
									bool flag19;
									if ((object)componentsInChildren[(object)list3] != null)
									{
										flag19 = (object)componentsInChildren[(object)list3] == null;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1510 @ rsi_v31 (Il2CppMethodInfo)+10]");
										flag19 = (nint)0 == 0;
									}
									if (!flag19)
									{
										bool flag20 = (object)rectTransform == null;
										GameObject gameObject = rectTransform.gameObject;
										bool flag21 = (object)gameObject == null;
										if (gameObject.activeSelf)
										{
											obj13 = 1;
										}
									}
									list3 = (List<Equipment>)(list3 + 1);
								}
								if (obj13 != null)
								{
									GameObject gameObject2 = ((Component)null).gameObject;
									bool flag22 = (object)gameObject2 == null;
									gameObject2.SetActive(value: true);
									obj11++;
									num = unchecked((nint)null);
								}
							}
							if ((nint)obj11 <= 1)
							{
								List<Equipment> pager = (List<Equipment>)(object)_Pager;
								if ((object)_Pager == null)
								{
									break;
								}
								bool flag23 = pager._items == null;
								GameObject.SetActive_Injected((IntPtr)pager._items, false);
							}
							List<Equipment> playerOptions = (List<Equipment>)(object)_playerOptions;
							if (_playerOptions == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+68]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+58]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+78]");
									List<Equipment> list5;
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+78]");
										List<Equipment> list4 = (List<Equipment>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3879 @ rax_v121 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+2CC]");
										if ((nint)0 != 0)
										{
											list5 = list4;
											goto IL_2072;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+50]");
									list5 = (List<Equipment>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+50]");
									if ((nint)0 == 0)
									{
										break;
									}
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+58]");
									List<Equipment> list5 = (List<Equipment>)0;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+68]");
								List<Equipment> list5 = (List<Equipment>)0;
							}
							goto IL_2072;
							IL_0d31:
							Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
							if (loadedDlc2 == null)
							{
								break;
							}
							int num7 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)2);
							if (num7 < 0)
							{
								if (_evolutionData == null)
								{
									break;
								}
								((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
								if (obj14 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v206+10]");
								bool flag24 = (nint)0 == 173;
								num = 0;
								if (!flag24)
								{
									if (_evolutionData == null)
									{
										break;
									}
									((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
									if (obj15 == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v207+10]");
									bool flag25 = (nint)0 == 175;
									num = 0;
									if (!flag25)
									{
										if (_evolutionData == null)
										{
											break;
										}
										((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
										if (obj16 == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v208+10]");
										bool flag26 = (nint)0 == 167;
										num = 0;
										if (!flag26)
										{
											if (_evolutionData == null)
											{
												break;
											}
											((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
											if (obj17 == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v209+10]");
											bool flag27 = (nint)0 == 177;
											num = 0;
											if (!flag27)
											{
												if (_evolutionData == null)
												{
													break;
												}
												((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
												if (obj18 == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v210+10]");
												bool flag28 = (nint)0 == 171;
												num = 0;
												if (!flag28)
												{
													if (_evolutionData == null)
													{
														break;
													}
													((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
													if (obj19 == null)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v211+10]");
													bool flag29 = (nint)0 == 179;
													num = 0;
													if (!flag29)
													{
														if (_evolutionData == null)
														{
															break;
														}
														((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
														if (obj20 == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v212+10]");
														bool flag30 = (nint)0 == 169;
														num = 0;
														if (!flag30)
														{
															goto IL_10d6;
														}
													}
												}
											}
										}
									}
								}
								goto IL_1df0;
							}
							goto IL_10d6;
							IL_0a7c:
							Dictionary<DlcType, BundleManifestData> loadedDlc3 = DlcSystem.LoadedDlc;
							if (loadedDlc3 == null)
							{
								break;
							}
							int num8 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc3).FindEntry((System.Int32Enum)1);
							if (num8 < 0)
							{
								if (_evolutionData == null)
								{
									break;
								}
								((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
								if (obj21 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rax_v214+10]");
								bool flag31 = (nint)0 == 127;
								num = 0;
								if (!flag31)
								{
									if (_evolutionData == null)
									{
										break;
									}
									((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
									if (obj22 == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v215+10]");
									bool flag32 = (nint)0 == 139;
									num = 0;
									if (!flag32)
									{
										if (_evolutionData == null)
										{
											break;
										}
										((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
										if (obj23 == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v216+10]");
										bool flag33 = (nint)0 == 136;
										num = 0;
										if (!flag33)
										{
											if (_evolutionData == null)
											{
												break;
											}
											((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
											if (obj24 == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v217+10]");
											bool flag34 = (nint)0 == 134;
											num = 0;
											if (!flag34)
											{
												if (_evolutionData == null)
												{
													break;
												}
												((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
												if (obj25 == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v218+10]");
												bool flag35 = (nint)0 == 132;
												num = 0;
												if (!flag35)
												{
													goto IL_0d31;
												}
											}
										}
									}
								}
								goto IL_1df0;
							}
							goto IL_0d31;
							IL_2072:
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+188]");
							object obj26 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Equipment>)+188]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v74+18]");
							bool flag36;
							if ((nint)0 == 0)
							{
								flag36 = false;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v74+10]");
								((List<WeaponType>)0)._002Ector((IEnumerable<WeaponType>)20);
								object obj27 = list6 - -1;
								bool flag37 = obj27 == null;
								flag36 = !flag37;
								num = unchecked((nint)null);
							}
							object buttonsNoMap = _ButtonsNoMap;
							if ((object)_ButtonsNoMap == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v31 (System.Object)+10]");
							bool flag38 = (nint)0 == 0;
							object obj28 = (flag36 ? 1 : 0) ^ 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v31 (System.Object)+10]");
							GameObject.SetActive_Injected((IntPtr)0, (byte)(int)obj28 != 0);
							object buttonsHasMap = _ButtonsHasMap;
							if ((object)_ButtonsHasMap == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v34 (System.Object)+10]");
							bool flag39 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v34 (System.Object)+10]");
							GameObject.SetActive_Injected((IntPtr)0, flag36);
							if ((object)_CanvasGroup == null)
							{
								break;
							}
							_CanvasGroup.alpha = _DefaultAlpha;
							return;
							IL_1656:
							if (_evolutionData == null)
							{
								break;
							}
							((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
							if (obj29 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v183+10]");
							if ((nint)0 != 97)
							{
								if (_evolutionData == null)
								{
									break;
								}
								((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
								if (obj30 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v189+30]");
								if ((nint)0 == 0)
								{
									if (_evolutionData == null)
									{
										break;
									}
									((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
									SpawnWeapon(d2);
									num = unchecked((nint)null);
								}
								else
								{
									if (_evolutionData == null)
									{
										break;
									}
									((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
									SpawnGenericLine(d3);
									num = unchecked((nint)null);
								}
							}
							else
							{
								if (_evolutionData == null)
								{
									break;
								}
								((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
								SpawnTriasso(d4);
								num = unchecked((nint)null);
							}
							List<Equipment> spawned = (List<Equipment>)(object)_spawned;
							if (_spawned == null)
							{
								break;
							}
							int index = spawned._size - 1;
							((List<Equipment>)(object)_spawned).InsertRange(index, (IEnumerable<Equipment>)num);
							if ((object)gameObject3 == null)
							{
								break;
							}
							if (gameObject3.activeSelf)
							{
								num2++;
							}
							goto IL_1df0;
							IL_10d6:
							Dictionary<DlcType, BundleManifestData> loadedDlc4 = DlcSystem.LoadedDlc;
							if (loadedDlc4 == null)
							{
								break;
							}
							int num9 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc4).FindEntry((System.Int32Enum)3);
							if (num9 >= 0)
							{
								goto IL_1656;
							}
							if (_evolutionData == null)
							{
								break;
							}
							((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
							if (obj31 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v194+10]");
							bool flag40 = (nint)0 == 334;
							num = 0;
							if (!flag40)
							{
								if (_evolutionData == null)
								{
									break;
								}
								((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
								if (obj32 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v195+10]");
								bool flag41 = (nint)0 == 322;
								num = 0;
								if (!flag41)
								{
									if (_evolutionData == null)
									{
										break;
									}
									((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
									if (obj33 == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rax_v196+10]");
									bool flag42 = (nint)0 == 335;
									num = 0;
									if (!flag42)
									{
										if (_evolutionData == null)
										{
											break;
										}
										((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
										if (obj34 == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v197+10]");
										bool flag43 = (nint)0 == 313;
										num = 0;
										if (!flag43)
										{
											if (_evolutionData == null)
											{
												break;
											}
											((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
											if (obj35 == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v198+10]");
											bool flag44 = (nint)0 == 314;
											num = 0;
											if (!flag44)
											{
												if (_evolutionData == null)
												{
													break;
												}
												((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
												if (obj36 == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v199+10]");
												bool flag45 = (nint)0 == 305;
												num = 0;
												if (!flag45)
												{
													if (_evolutionData == null)
													{
														break;
													}
													((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
													if (obj37 == null)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v200+10]");
													bool flag46 = (nint)0 == 337;
													num = 0;
													if (!flag46)
													{
														if (_evolutionData == null)
														{
															break;
														}
														((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
														if (obj38 == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v201+10]");
														bool flag47 = (nint)0 == 317;
														num = 0;
														if (!flag47)
														{
															if (_evolutionData == null)
															{
																break;
															}
															((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
															if (obj39 == null)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v202+10]");
															bool flag48 = (nint)0 == 316;
															num = 0;
															if (!flag48)
															{
																if (_evolutionData == null)
																{
																	break;
																}
																((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
																if (obj40 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v203+10]");
																bool flag49 = (nint)0 == 309;
																num = 0;
																if (!flag49)
																{
																	if (_evolutionData == null)
																	{
																		break;
																	}
																	((List<Equipment>)(object)_evolutionData).InsertRange((int)list, (IEnumerable<Equipment>)0);
																	if (obj41 == null)
																	{
																		break;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v204+10]");
																	bool flag50 = (nint)0 == 315;
																	num = 0;
																	if (!flag50)
																	{
																		goto IL_1656;
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
							goto IL_1df0;
							IL_1df0:
							list = (List<Equipment>)(list + 1);
							evolutionData = _evolutionData;
							if (_evolutionData == null)
							{
								break;
							}
							list2 = list;
						}
					}
				}
			}
			goto IL_1cfc;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
		IL_1cfc:
		throw new NullReferenceException();
	}

	public PageManager GetPageManager()
	{
		return _PageManager;
	}

	private void AddNewContainer()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_ContainerPrefab, _ContainerContainer);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)(object)_Containers, component);
		_PageManager.AddPage(gameObject);
		RectTransform component2 = gameObject.GetComponent<RectTransform>();
		Vector2 sizeDelta = _ContainerContainer.sizeDelta;
		Vector2 sizeDelta2 = _ContainerContainer.sizeDelta;
		Vector2 sizeDelta3 = default(Vector2);
		component2.sizeDelta = sizeDelta3;
		gameObject.SetActive(value: false);
	}

	public void ReduceAlphaOnArcanaInfoShown()
	{
		_CanvasGroup.alpha = _AlphaWhileArcanaInfoShown;
	}

	public void ResetToDefaultAlpha()
	{
		_CanvasGroup.alpha = _DefaultAlpha;
	}

	private void SpawnWeapon(EvolutionData d)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_EvolutionPrefab, _ActiveContainer);
		EvolutionItemUI component = gameObject.GetComponent<EvolutionItemUI>();
		EvolutionData evo = default(EvolutionData);
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		component.CreateWeaponContainer(_playerOptions, _weapons, _ownedWeapons, evo, character);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private void SpawnGenericLine(EvolutionData d)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_EvolutionPrefab, _ActiveContainer);
		EvolutionItemUI component = gameObject.GetComponent<EvolutionItemUI>();
		EvolutionData evo = default(EvolutionData);
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		component.CreateGenericContainer(_playerOptions, _weapons, _ownedWeapons, evo, character);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private void SpawnTriasso(EvolutionData d)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_EvolutionPrefab, _ActiveContainer);
		EvolutionItemUI component = gameObject.GetComponent<EvolutionItemUI>();
		EvolutionData evo = default(EvolutionData);
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		component.CreateTriassoContainer(_playerOptions, _weapons, _ownedWeapons, evo, character);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private unsafe void CreateEvolutionList()
	{
		//IL_009f: Expected O, but got Ref
		List<EvolutionData> evolutionData = _evolutionData;
		int version = evolutionData._version + 1;
		evolutionData._version = version;
		evolutionData._size = 0;
		if (evolutionData._size > 0)
		{
			Array.Clear(evolutionData._items, 0, evolutionData._size);
		}
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			WeaponType weaponType = WeaponType.VOID;
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator2 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private bool RequiresYellowSign(EvolutionData d)
	{
		//IL_0030: Expected O, but got I4
		//IL_0093: Expected O, but got I
		//IL_00f0: Expected O, but got I
		//IL_0105: Expected O, but got I
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		if (d.requires != null)
		{
			object obj = 0;
			bool result = default(bool);
			while (true)
			{
				List<WeaponType> requires = d.requires;
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj2 >= 0)
				{
					break;
				}
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj3 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj4 = 0;
					Dictionary<WeaponType, List<WeaponData>> weapons = _weapons;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v7+20+v80 @ rbx_v8*4]");
					object obj5 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v14 (System.Object)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v14 (System.Object)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v15+20]");
						object obj7 = 0;
						List<WeaponType> ownedWeapons = _ownedWeapons;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v7+20+v80 @ rbx_v8*4]");
						List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)(object)ownedWeapons).get_Item(WeaponType.VOID);
						if (list == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdi_v8+61]");
							if (0 != (nint)list)
							{
								PlayerOptionsData config = _playerOptions.Config;
								List<WeaponType> list2 = config._003CUnlockedWeapons_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v7+20+v80 @ rbx_v8*4]");
								List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list2).get_Item(WeaponType.VOID);
								if (list3 == null)
								{
									return true;
								}
							}
						}
						obj++;
						continue;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		return false;
	}

	private bool OwnsWeapon(WeaponType t)
	{
		//IL_0022: Expected I4, but got O
		if (_ownedWeapons != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void Clear()
	{
		//IL_00ce->IL01ee: Incompatible stack heights: 1 vs 0
		List<GameObject> spawned = _spawned;
		if (_spawned != null)
		{
			int version = spawned._version + 1;
			spawned._version = version;
			spawned._size = 0;
			if (spawned._size > 0)
			{
				Array.Clear(spawned._items, 0, spawned._size);
			}
			if (_Containers != null)
			{
				List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbx_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbx_v7 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
					GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj2, 0f);
				}
				List<RectTransform> containers = _Containers;
				if (_Containers != null)
				{
					int version2 = containers._version + 1;
					containers._version = version2;
					containers._size = 0;
					if (containers._size > 0)
					{
						Array.Clear(containers._items, 0, containers._size);
					}
					if ((object)_PageManager != null)
					{
						_PageManager.ClearAllPages();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public GrimoireManager()
	{
		List<RectTransform> containers = new List<RectTransform>();
		_Containers = containers;
		_DefaultAlpha = 1f;
		_AlphaWhileArcanaInfoShown = 0.6f;
		List<EvolutionItemUI> evolutionItems = new List<EvolutionItemUI>();
		_evolutionItems = evolutionItems;
		List<EvolutionData> evolutionData = new List<EvolutionData>();
		_evolutionData = evolutionData;
		List<WeaponType> ownedWeapons = new List<WeaponType>();
		_ownedWeapons = ownedWeapons;
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
	}
}
