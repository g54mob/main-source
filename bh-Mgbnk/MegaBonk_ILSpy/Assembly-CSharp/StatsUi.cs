using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI;
using Cpp2ILInjected;
using UnityEngine;

public class StatsUi : MonoBehaviour
{
	private sealed class _003CDelayedRebuild_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StatsUi _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDelayedRebuild_003Ed__10(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0067: Expected I4, but got I8
			//IL_00de: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				StatsUi statsUi = _003C_003E4__this;
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				if (statsUi.rootTransformToRefresh != null)
				{
					UiUtility.RebuildUi(statsUi.rootTransformToRefresh);
				}
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public Transform rootTransformToRefresh;

	public GameObject entryPrefab;

	public GameObject spacerPrefab;

	private List<StatEntry> entries;

	private int[] spacers;

	private List<EStat> statsToShow;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EStat> b = OnStatUpdate;
		Delegate obj = Delegate.Combine(PlayerStatsNew.A_StatUpdate, b);
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = (Action<EStat>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat> action = default(Action<EStat>);
		if (action != null)
		{
			PlayerStatsNew.A_StatUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EStat>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EStat>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<EStat> value = OnStatUpdate;
		Delegate obj = Delegate.Remove(PlayerStatsNew.A_StatUpdate, value);
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = (Action<EStat>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat> action = default(Action<EStat>);
		if (action != null)
		{
			PlayerStatsNew.A_StatUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<EStat>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<EStat>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnable()
	{
		Refresh();
	}

	private void OnStatUpdate(EStat stat)
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 36 Invalid \"Jump target not found in method: 0x18055BB40\"");
		}
	}

	private void TryInit()
	{
		//IL_0052: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0241: Expected O, but got I4
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		if (entries != null)
		{
			return;
		}
		List<StatEntry> list = new List<StatEntry>();
		entries = list;
		if (statsToShow != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			object obj = 0;
			object obj2 = 0;
			List<EStat>.Enumerator enumerator = default(List<EStat>.Enumerator);
			while (enumerator.MoveNext())
			{
				if ((object)entryPrefab != null)
				{
					Transform transform = entryPrefab.transform;
					if ((object)transform != null)
					{
						Transform parent = transform.parent;
						GameObject gameObject = UnityEngine.Object.Instantiate(entryPrefab, parent);
						if ((object)gameObject != null)
						{
							StatEntry component = gameObject.GetComponent<StatEntry>();
							List<object> list2 = (List<object>)(object)entries;
							bool flag = entries == null;
							GameObject gameObject2 = (GameObject)(object)entries;
							if (!flag)
							{
								int version = list2._version + 1;
								list2._version = version;
								object[] items = list2._items;
								if (list2._items != null)
								{
									int size = list2._size;
									if (list2._size >= items.Length)
									{
										list2.AddWithResize((object)component);
										size = 0;
									}
									else
									{
										int size2 = list2._size + 1;
										list2._size = size2;
										if (list2._size >= items.Length)
										{
											throw new IndexOutOfRangeException();
										}
										items[size] = component;
										object obj3 = list2._items + 32;
										object obj4 = list2._size * 8;
										list2 = (List<object>)(object)(obj3 + obj4);
									}
									List<object> list3 = (List<object>)(object)spacers;
									if (spacers != null)
									{
										if ((nint)obj < list3._size)
										{
											bool flag2 = (nint)obj >= list3._size;
											list2 = (List<object>)(object)spacers;
											if (flag2)
											{
												throw new IndexOutOfRangeException();
											}
											object obj5 = obj2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v42 (System.Collections.Generic.List`1<System.Object>)+20+v304 @ rsi_v16*4]");
											if ((nint)obj5 >= 0)
											{
												bool flag3 = (object)entryPrefab == null;
												list2 = (List<object>)(object)entryPrefab;
												if (flag3)
												{
													throw new NullReferenceException();
												}
												Transform transform2 = entryPrefab.transform;
												bool flag4 = (object)transform2 == null;
												list2 = (List<object>)(object)entryPrefab;
												if (flag4)
												{
													throw new NullReferenceException();
												}
												Transform parent2 = transform2.parent;
												obj++;
												GameObject gameObject3 = UnityEngine.Object.Instantiate(spacerPrefab, parent2);
											}
										}
										obj2++;
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
			enumerator.Dispose();
			if ((object)entryPrefab != null)
			{
				entryPrefab.SetActive(value: false);
				if ((object)spacerPrefab != null)
				{
					spacerPrefab.SetActive(value: false);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Refresh()
	{
		TryInit();
		List<EStat> list = statsToShow;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v6 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			if ((nint)num3 < (nint)0)
			{
				StatEntry statEntry = entries.get_Item(num);
				EStat stat = statsToShow.get_Item(num);
				statEntry.Set(stat);
				list = statsToShow;
				num++;
				num2 = num;
				continue;
			}
			break;
		}
		_003CDelayedRebuild_003Ed__10 obj = new _003CDelayedRebuild_003Ed__10(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DelayedRebuild()
	{
		_003CDelayedRebuild_003Ed__10 obj = new _003CDelayedRebuild_003Ed__10(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public static string FormatStat(EStat stat, float value)
	{
		//IL_004a: Expected O, but got I8
		//IL_0058: Expected O, but got I4
		//IL_0065: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317302E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 41 Invalid \"Jump target not found in method: 0x18055B943\"");
		object obj = 6442450944L;
		object obj2 = stat - 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v1+55B994+v47 @ rax_v3]");
		return (string)0;
	}

	public StatsUi()
	{
		//IL_0037: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_0d60: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0d88: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_0db0: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_0dd8: Expected O, but got I
		//IL_0239: Expected O, but got I
		//IL_0e00: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_0e28: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_0e50: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_0e78: Expected O, but got I
		//IL_03e1: Expected O, but got I
		//IL_0ea0: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_0ec8: Expected O, but got I
		//IL_04b5: Expected O, but got I
		//IL_0ef0: Expected O, but got I
		//IL_051f: Expected O, but got I
		//IL_0f18: Expected O, but got I
		//IL_0589: Expected O, but got I
		//IL_0f40: Expected O, but got I
		//IL_05f3: Expected O, but got I
		//IL_0f68: Expected O, but got I
		//IL_065d: Expected O, but got I
		//IL_0f90: Expected O, but got I
		//IL_06c7: Expected O, but got I
		//IL_0fb8: Expected O, but got I
		//IL_0731: Expected O, but got I
		//IL_0fe0: Expected O, but got I
		//IL_079b: Expected O, but got I
		//IL_1008: Expected O, but got I
		//IL_0805: Expected O, but got I
		//IL_1030: Expected O, but got I
		//IL_086f: Expected O, but got I
		//IL_1058: Expected O, but got I
		//IL_08d9: Expected O, but got I
		//IL_1080: Expected O, but got I
		//IL_0943: Expected O, but got I
		//IL_10a8: Expected O, but got I
		//IL_09ad: Expected O, but got I
		//IL_10d0: Expected O, but got I
		//IL_0a17: Expected O, but got I
		//IL_10f8: Expected O, but got I
		//IL_0a81: Expected O, but got I
		//IL_1120: Expected O, but got I
		//IL_0aeb: Expected O, but got I
		//IL_1148: Expected O, but got I
		//IL_0b55: Expected O, but got I
		//IL_1170: Expected O, but got I
		//IL_0bbf: Expected O, but got I
		//IL_1198: Expected O, but got I
		//IL_0c29: Expected O, but got I
		//IL_11c0: Expected O, but got I
		//IL_0c93: Expected O, but got I
		//IL_11e8: Expected O, but got I
		//IL_0cfd: Expected O, but got I
		spacers = new int[4] { 7, 13, 19, 23 };
		List<EStat> list = new List<EStat>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v9+18]");
		if (num >= 0)
		{
			list.AddWithResize(EStat.MaxHealth);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v11+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(EStat.HealthRegen);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v13+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(EStat.Overheal);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 47;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v15+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(EStat.Shield);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rcx_v17+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(EStat.Armor);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v19+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(EStat.Evasion);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rcx_v21+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(EStat.Lifesteal);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v23+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(EStat.Thorns);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v25+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(EStat.DamageMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v27+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(EStat.CritChance);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v29+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(EStat.CritDamage);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v31+18]");
		if (num12 >= 0)
		{
			list.AddWithResize(EStat.AttackSpeed);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v33+18]");
		if (num13 >= 0)
		{
			list.AddWithResize(EStat.Projectiles);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v35+18]");
		if (num14 >= 0)
		{
			list.AddWithResize(EStat.ProjectileBounces);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 45;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v37+18]");
		if (num15 >= 0)
		{
			list.AddWithResize(EStat.SizeMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v39+18]");
		if (num16 >= 0)
		{
			list.AddWithResize(EStat.ProjectileSpeedMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v41+18]");
		if (num17 >= 0)
		{
			list.AddWithResize(EStat.DurationMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v43+18]");
		if (num18 >= 0)
		{
			list.AddWithResize(EStat.EliteDamageMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 23;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v45+18]");
		if (num19 >= 0)
		{
			list.AddWithResize(EStat.KnockbackMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v47+18]");
		if (num20 >= 0)
		{
			list.AddWithResize(EStat.MoveSpeedMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 25;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v49+18]");
		if (num21 >= 0)
		{
			list.AddWithResize(EStat.ExtraJumps);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 46;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v51+18]");
		if (num22 >= 0)
		{
			list.AddWithResize(EStat.JumpHeight);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v53+18]");
		if (num23 >= 0)
		{
			list.AddWithResize(EStat.Luck);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v55+18]");
		if (num24 >= 0)
		{
			list.AddWithResize(EStat.Difficulty);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 38;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rcx_v57+18]");
		if (num25 >= 0)
		{
			list.AddWithResize(EStat.PickupRange);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 29;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v59+18]");
		if (num26 >= 0)
		{
			list.AddWithResize(EStat.XpIncreaseMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 32;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v61+18]");
		if (num27 >= 0)
		{
			list.AddWithResize(EStat.GoldIncreaseMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 31;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v63+18]");
		if (num28 >= 0)
		{
			list.AddWithResize(EStat.SilverIncreaseMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 49;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v65+18]");
		if (num29 >= 0)
		{
			list.AddWithResize(EStat.EliteSpawnIncrease);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 39;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rcx_v67+18]");
		if (num30 >= 0)
		{
			list.AddWithResize(EStat.PowerupBoostMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rcx_v69+18]");
		if (num31 >= 0)
		{
			list.AddWithResize(EStat.PowerupChance);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 41;
		}
		statsToShow = list;
		base._002Ector();
	}
}
