using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class UnlocksUi : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public string internalName;

		internal bool _003CUpdateExclamationMarks_003Eb__0(CharacterData c)
		{
			//IL_0050: Expected I4, but got O
			if ((object)c != null)
			{
				string text = c.GetInternalName();
				return text == internalName;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__1(WeaponData w)
		{
			//IL_0050: Expected I4, but got O
			if ((object)w != null)
			{
				string text = w.GetInternalName();
				return text == internalName;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__2(TomeData t)
		{
			//IL_0050: Expected I4, but got O
			if ((object)t != null)
			{
				string text = t.GetInternalName();
				return text == internalName;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__3(ItemData i)
		{
			//IL_0050: Expected I4, but got O
			if ((object)i != null)
			{
				string text = i.GetInternalName();
				return text == internalName;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__4(HatData i)
		{
			//IL_0050: Expected I4, but got O
			if ((object)i != null)
			{
				string text = i.GetInternalName();
				return text == internalName;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private List<UnlockContainer> unlockContainers;

	public GameObject unlockContainerPrefab;

	public Transform contentParent;

	public ButtonNavigationSelectionOnly tabButtons;

	public TabGridNavigation tabGridNavigation;

	public GameObject exclChar;

	public GameObject exclWeapon;

	public GameObject exclTome;

	public GameObject exclItem;

	public GameObject exclHats;

	public GameObject[] exclamationMarks;

	private void Awake()
	{
		//IL_03e5: Expected I, but got O
		//IL_0085: Expected O, but got I4
		//IL_0098: Expected I, but got O
		//IL_00e5: Expected O, but got I4
		//IL_00f8: Expected I, but got O
		//IL_0343: Expected O, but got I4
		//IL_0354: Expected I, but got O
		//IL_0362: Expected I, but got O
		//IL_0390: Expected O, but got I4
		//IL_0213: Expected O, but got I4
		//IL_025b: Expected O, but got I4
		//IL_02a3: Expected O, but got I4
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabButtons;
		Delegate obj6;
		Action action3 = default(Action);
		NullReferenceException typeFromHandle;
		nint num;
		Delegate obj4;
		if ((object)tabButtons != null)
		{
			Action<int> b = OnTabSelected;
			Delegate obj = Delegate.Combine(buttonNavigationSelectionOnly.A_ButtonSelected, b);
			object obj2;
			Delegate obj3;
			if ((object)obj == null)
			{
				buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<int> action = default(Action<int>);
				bool flag = action == null;
				obj2 = 0;
				obj3 = null;
				num = (nint)typeof(Action<int>);
				obj4 = obj;
				if (flag)
				{
					goto IL_0300;
				}
				buttonNavigationSelectionOnly.A_ButtonSelected = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				obj6 = obj;
				obj2 = 0;
				obj3 = null;
				num = (nint)typeof(Action<int>);
				if (flag2)
				{
					goto IL_030b;
				}
			}
			Action action2 = UpdateExclamationMarks;
			Delegate obj7 = Delegate.Combine(UnlockContainer.A_RemovedAlert, action2);
			if ((object)obj7 == null)
			{
				UnlockContainer.A_RemovedAlert = null;
			}
			else
			{
				bool flag3 = (object)obj7.GetType() != typeof(Action);
				Delegate obj8 = null;
				if (!flag3)
				{
					obj8 = obj7;
				}
				bool flag4 = (object)obj8 == null;
				obj6 = action2;
				obj2 = 0;
				obj3 = obj7;
				num = (nint)UnlockContainer.A_RemovedAlert;
				nint num2 = (nint)typeof(Action);
				if (flag4)
				{
					goto IL_03b9;
				}
				UnlockContainer.A_RemovedAlert = (Action)obj8;
				bool flag5 = (object)obj7.GetType() != typeof(Action);
				Delegate obj9 = null;
				if (!flag5)
				{
					obj9 = obj7;
				}
				bool flag6 = (object)obj9 == null;
				action3 = action2;
				obj2 = 0;
				obj3 = obj7;
				typeFromHandle = (NullReferenceException)(object)typeof(Action);
				if (flag6)
				{
					goto IL_03c9;
				}
			}
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			bool flag7 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
			action3 = action2;
			obj2 = 0;
			obj3 = obj7;
			if (!flag7)
			{
				ProgressionSaveFile progression = saveManager.progression;
				bool flag8 = saveManager.progression == null;
				action3 = action2;
				obj2 = 0;
				obj3 = obj7;
				if (!flag8)
				{
					MenuMeta menuMeta = progression.menuMeta;
					bool flag9 = progression.menuMeta == null;
					action3 = action2;
					obj2 = 0;
					obj3 = obj7;
					if (!flag9)
					{
						menuMeta.hasVisitedUnlocks = true;
						return;
					}
				}
			}
		}
		typeFromHandle = new NullReferenceException();
		goto IL_03c9;
		IL_03c9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj6 = action3;
		num = (nint)UnlockContainer.A_RemovedAlert;
		goto IL_03b9;
		IL_0300:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03b9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_030b;
		IL_030b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_0300;
	}

	private void OnDestroy()
	{
		//IL_02f0: Expected I, but got O
		//IL_0085: Expected O, but got I4
		//IL_0098: Expected I, but got O
		//IL_00e5: Expected O, but got I4
		//IL_00f8: Expected I, but got O
		//IL_025b: Expected O, but got I4
		//IL_026c: Expected I, but got O
		//IL_027a: Expected I, but got O
		//IL_02a0: Expected O, but got I4
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabButtons;
		Delegate obj6;
		Action action2 = default(Action);
		nint num;
		Delegate obj4;
		if ((object)tabButtons != null)
		{
			Action<int> value = OnTabSelected;
			Delegate obj = Delegate.Remove(buttonNavigationSelectionOnly.A_ButtonSelected, value);
			object obj2;
			Delegate obj3;
			if ((object)obj == null)
			{
				buttonNavigationSelectionOnly.A_ButtonSelected = (Action<int>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<int> action = default(Action<int>);
				bool flag = action == null;
				obj2 = 0;
				obj3 = null;
				num = (nint)typeof(Action<int>);
				obj4 = obj;
				if (flag)
				{
					goto IL_0218;
				}
				buttonNavigationSelectionOnly.A_ButtonSelected = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				obj6 = obj;
				obj2 = 0;
				obj3 = null;
				num = (nint)typeof(Action<int>);
				if (flag2)
				{
					goto IL_0223;
				}
			}
			action2 = UpdateExclamationMarks;
			Delegate obj7 = Delegate.Remove(UnlockContainer.A_RemovedAlert, action2);
			if ((object)obj7 == null)
			{
				UnlockContainer.A_RemovedAlert = null;
				return;
			}
			bool flag3 = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag3)
			{
				obj8 = obj7;
			}
			bool flag4 = (object)obj8 == null;
			obj6 = action2;
			obj2 = 0;
			obj3 = obj7;
			num = (nint)UnlockContainer.A_RemovedAlert;
			nint num2 = (nint)typeof(Action);
			if (flag4)
			{
				goto IL_02c4;
			}
			UnlockContainer.A_RemovedAlert = (Action)obj8;
			bool flag5 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag5)
			{
				obj9 = obj7;
			}
			bool flag6 = (object)obj9 == null;
			obj2 = 0;
			obj3 = obj7;
			NullReferenceException typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (!flag6)
			{
				return;
			}
		}
		else
		{
			NullReferenceException typeFromHandle = new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj6 = action2;
		num = (nint)UnlockContainer.A_RemovedAlert;
		goto IL_02c4;
		IL_0218:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0223;
		IL_0223:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_0218;
	}

	private void OnEnable()
	{
		UpdateExclamationMarks();
	}

	public unsafe void FocusCharacterPurchase(CharacterData character)
	{
		//IL_0066: Expected O, but got I
		tabButtons.ButtonPressed(0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Component component = default(Component);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ stack_-50 (UnityEngine.Component)+20]");
				if ((UnityEngine.Object)0 == character)
				{
					MyButton component2 = component.GetComponent<MyButton>();
					ButtonManager.ForceHoverButton(component2);
				}
				continue;
			}
			((List<UnlockContainer>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateExclamationMarks()
	{
		//IL_00f9: Expected I, but got O
		//IL_01a5: Expected I, but got O
		//IL_022e: Expected I, but got O
		//IL_02bf: Expected I, but got O
		//IL_0357: Expected I, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.newUnlockables != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
				nint num = 0;
				bool flag = false;
				bool flag2 = false;
				bool active = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
				string internalName = default(string);
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass9_0();
					bool flag6 = CS_0024_003C_003E8__locals8 == null;
					nint num2 = (nint)CS_0024_003C_003E8__locals8;
					if (!flag6)
					{
						CS_0024_003C_003E8__locals8.internalName = internalName;
						nint num3 = num;
						if (!flag5)
						{
							DataManager instance = DataManager.Instance;
							if ((object)DataManager.Instance == null)
							{
								throw new NullReferenceException();
							}
							Func<CharacterData, bool> predicate = delegate(CharacterData c)
							{
								//IL_0050: Expected I4, but got O
								if ((object)c == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								string internalName2 = c.GetInternalName();
								return internalName2 == CS_0024_003C_003E8__locals8.internalName;
							};
							bool flag7 = Enumerable.Any(instance.unsortedCharacterData, (Func<object, bool>)predicate);
							num3 = 0;
							flag5 = flag7;
						}
						nint num4 = num3;
						if (!flag4)
						{
							nint num5 = (nint)typeof(DataManager);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ rax_v54 (Il2CppClass<DataManager>)+B8]");
							num2 = 0;
							DataManager instance2 = DataManager.Instance;
							if ((object)DataManager.Instance == null)
							{
								throw new NullReferenceException();
							}
							Func<WeaponData, bool> predicate2 = delegate(WeaponData w)
							{
								//IL_0050: Expected I4, but got O
								if ((object)w == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								string internalName2 = w.GetInternalName();
								return internalName2 == CS_0024_003C_003E8__locals8.internalName;
							};
							bool flag8 = Enumerable.Any(instance2.unsortedWeapons, (Func<object, bool>)predicate2);
							num4 = 0;
							flag4 = flag8;
						}
						nint num6 = num4;
						if (!flag3)
						{
							nint num7 = (nint)typeof(DataManager);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ rax_v49 (Il2CppClass<DataManager>)+B8]");
							nint num8 = 0;
							DataManager instance3 = DataManager.Instance;
							bool flag9 = (object)DataManager.Instance == null;
							num2 = num8;
							if (flag9)
							{
								throw new NullReferenceException();
							}
							Func<TomeData, bool> predicate3 = delegate(TomeData t)
							{
								//IL_0050: Expected I4, but got O
								if ((object)t == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								string internalName2 = t.GetInternalName();
								return internalName2 == CS_0024_003C_003E8__locals8.internalName;
							};
							bool flag10 = Enumerable.Any(instance3.unsortedTomes, (Func<object, bool>)predicate3);
							num6 = 0;
							flag3 = flag10;
						}
						num = num6;
						active = flag2;
						if (!flag2)
						{
							nint num9 = (nint)typeof(DataManager);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ rax_v44 (Il2CppClass<DataManager>)+B8]");
							nint num10 = 0;
							DataManager instance4 = DataManager.Instance;
							bool flag11 = (object)DataManager.Instance == null;
							num2 = num10;
							if (flag11)
							{
								throw new NullReferenceException();
							}
							Func<ItemData, bool> predicate4 = delegate(ItemData i)
							{
								//IL_0050: Expected I4, but got O
								if ((object)i == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								string internalName2 = i.GetInternalName();
								return internalName2 == CS_0024_003C_003E8__locals8.internalName;
							};
							bool flag12 = Enumerable.Any(instance4.unsortedItems, (Func<object, bool>)predicate4);
							num = 0;
							flag2 = flag12;
							active = flag12;
						}
						if (flag)
						{
							continue;
						}
						nint num11 = (nint)typeof(DataManager);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v39 (Il2CppClass<DataManager>)+B8]");
						nint num12 = 0;
						DataManager instance5 = DataManager.Instance;
						bool flag13 = (object)DataManager.Instance == null;
						num2 = num12;
						if (!flag13)
						{
							Func<HatData, bool> predicate5 = delegate(HatData i)
							{
								//IL_0050: Expected I4, but got O
								if ((object)i == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								string internalName2 = i.GetInternalName();
								return internalName2 == CS_0024_003C_003E8__locals8.internalName;
							};
							bool flag14 = Enumerable.Any(instance5.unsortedHats, (Func<object, bool>)predicate5);
							num = 0;
							flag = flag14;
							active = flag2;
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				((HashSet<string>.Enumerator*)(&enumerator))->Dispose();
				if ((object)exclChar != null)
				{
					exclChar.SetActive(flag5);
					if ((object)exclWeapon != null)
					{
						exclWeapon.SetActive(flag4);
						if ((object)exclTome != null)
						{
							exclTome.SetActive(flag3);
							if ((object)exclItem != null)
							{
								exclItem.SetActive(active);
								if ((object)exclHats != null)
								{
									exclHats.SetActive(flag);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnTabSelected(int index)
	{
		//IL_0013: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		bool flag = index == 0;
		IEnumerable source;
		if (!flag)
		{
			object obj = index - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 != 1)
						{
							return;
						}
						DataManager instance = DataManager.Instance;
						source = instance.unsortedHats;
					}
					else
					{
						DataManager instance2 = DataManager.Instance;
						source = instance2.unsortedItems;
					}
				}
				else
				{
					DataManager instance3 = DataManager.Instance;
					source = instance3.unsortedTomes;
				}
			}
			else
			{
				DataManager instance4 = DataManager.Instance;
				source = instance4.unsortedWeapons;
			}
		}
		else
		{
			DataManager instance5 = DataManager.Instance;
			source = instance5.unsortedCharacterData;
		}
		IEnumerable<object> source2 = Enumerable.Cast<object>(source);
		List<object> unlockables = Enumerable.ToList(source2);
		Refresh((List<UnlockableBase>)(object)unlockables);
	}

	private unsafe void Refresh(List<UnlockableBase> unlockables)
	{
		//IL_0175: Expected O, but got Ref
		//IL_04f9: Expected O, but got I
		bool flag = unlockables == null;
		List<object> list = (List<object>)(object)this;
		if (!flag)
		{
			((List<object>)(object)unlockables).Sort();
			List<UnlockContainer> list2 = unlockContainers;
			bool flag2 = unlockContainers == null;
			list = (List<object>)(object)unlockables;
			if (!flag2)
			{
				bool flag3 = list2._size > 0;
				list = (List<object>)(object)unlockables;
				if (!flag3)
				{
					bool flag4 = (object)unlockContainerPrefab == null;
					list = (List<object>)(object)unlockContainerPrefab;
					if (flag4)
					{
						goto IL_052c;
					}
					UnlockContainer component = unlockContainerPrefab.GetComponent<UnlockContainer>();
					unlockContainers.Add(component);
					list = (List<object>)(object)unlockContainers;
				}
				if (unlockContainers != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					Component component2 = default(Component);
					while (enumerator.MoveNext())
					{
						if ((object)component2 != null)
						{
							GameObject gameObject = component2.gameObject;
							if ((object)gameObject != null)
							{
								gameObject.SetActive(value: false);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					((List<UnlockContainer>.Enumerator*)(&enumerator))->Dispose();
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					list = (List<object>)(&enumerator);
					while (true)
					{
						if (num2 < unlockables._size)
						{
							UnlockableBase unlockableBase = unlockables.get_Item(num3);
							bool flag5 = (object)unlockableBase == null;
							list = (List<object>)(object)unlockables;
							if (flag5)
							{
								break;
							}
							bool flag6 = !unlockableBase.isEnabled;
							list = (List<object>)(object)unlockables;
							if (!flag6)
							{
								UnlockableBase unlockableBase2 = unlockables.get_Item(num3);
								bool flag7 = (object)unlockableBase2 == null;
								list = (List<object>)(object)unlockables;
								if (flag7)
								{
									break;
								}
								bool flag8 = !unlockableBase2.showInUnlocks;
								list = (List<object>)(object)unlockables;
								if (!flag8)
								{
									List<UnlockContainer> list3 = unlockContainers;
									bool flag9 = unlockContainers == null;
									list = (List<object>)(object)unlockables;
									if (flag9)
									{
										break;
									}
									if (num >= list3._size)
									{
										GameObject gameObject2 = UnityEngine.Object.Instantiate(unlockContainerPrefab, contentParent);
										bool flag10 = (object)gameObject2 == null;
										list = (List<object>)(object)unlockContainerPrefab;
										if (flag10)
										{
											break;
										}
										UnlockContainer component3 = gameObject2.GetComponent<UnlockContainer>();
										bool flag11 = unlockContainers == null;
										list = (List<object>)(object)unlockContainers;
										if (flag11)
										{
											break;
										}
										unlockContainers.Add(component3);
									}
									bool flag12 = unlockContainers == null;
									list = (List<object>)(object)unlockContainers;
									if (flag12)
									{
										break;
									}
									UnlockContainer unlockContainer = unlockContainers.get_Item(num);
									UnlockableBase unlockable = unlockables.get_Item(num3);
									bool flag13 = (object)unlockContainer == null;
									list = (List<object>)(object)unlockables;
									if (flag13)
									{
										break;
									}
									unlockContainer.Set(unlockable);
									bool flag14 = unlockContainers == null;
									list = (List<object>)(object)unlockContainers;
									if (flag14)
									{
										break;
									}
									UnlockContainer unlockContainer2 = unlockContainers.get_Item(num);
									bool flag15 = (object)unlockContainer2 == null;
									list = (List<object>)(object)unlockContainers;
									if (flag15)
									{
										break;
									}
									GameObject gameObject3 = unlockContainer2.gameObject;
									bool flag16 = (object)gameObject3 == null;
									list = (List<object>)(object)unlockContainer2;
									if (flag16)
									{
										break;
									}
									gameObject3.SetActive(value: true);
									num++;
									list = (List<object>)(object)gameObject3;
								}
							}
							num3++;
							num2 = num3;
							continue;
						}
						ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabButtons;
						if ((object)tabButtons == null)
						{
							break;
						}
						list = (List<object>)(object)buttonNavigationSelectionOnly.buttons;
						if (buttonNavigationSelectionOnly.buttons == null)
						{
							break;
						}
						int current = buttonNavigationSelectionOnly.current;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+20+v116 @ rdx_v12 (System.Int32)*8]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v5 (System.Collections.Generic.List`1<System.Object>)+20+v116 @ rdx_v12 (System.Int32)*8]");
						Button button = ((MyButton)0).GetButton();
						if ((object)tabGridNavigation == null)
						{
							break;
						}
						tabGridNavigation.Set(button);
						return;
					}
				}
			}
		}
		goto IL_052c;
		IL_052c:
		throw new NullReferenceException();
	}

	public UnlocksUi()
	{
		List<UnlockContainer> list = new List<UnlockContainer>();
		unlockContainers = list;
		base._002Ector();
	}
}
