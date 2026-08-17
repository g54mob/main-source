using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class MapStatsWindow : MonoBehaviour
{
	public TextMeshProUGUI t_mapSpecs;

	public SelectionGroupToggleSingle tierSelection;

	public SelectionGroupToggleSingle challengeSelection;

	public SelectionGroupToggleSingleButtonTier[] tierButtons;

	public MapSelectionUi mapSelectionUi;

	public MyButton btnChallenges;

	public GameObject newChallengesIndicator;

	private Dictionary<int, float> tierSilverMultipliers = new Dictionary<int, float>
	{
		{ 0, 1f },
		{ 1, 1.1f },
		{ 2, 1.2f }
	};

	private void Start()
	{
		Refresh();
	}

	private void Awake()
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		//IL_00e9: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0100: Expected I, but got O
		//IL_0193: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_01aa: Expected I, but got O
		//IL_01eb: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_0202: Expected I, but got O
		//IL_0295: Expected O, but got I4
		//IL_029e: Expected O, but got I4
		//IL_02ac: Expected I, but got O
		SelectionGroupToggleSingle selectionGroupToggleSingle = tierSelection;
		Action<SelectionGroupToggleSingleButton> b = OnInfoChanged;
		Delegate obj = Delegate.Combine(selectionGroupToggleSingle.A_ButtonSelected, b);
		Delegate obj6;
		object obj2;
		object obj3;
		nint num;
		Delegate obj4;
		if ((object)obj == null)
		{
			selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SelectionGroupToggleSingleButton> action = default(Action<SelectionGroupToggleSingleButton>);
			bool flag = action == null;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			obj4 = obj;
			if (flag)
			{
				goto IL_02fa;
			}
			selectionGroupToggleSingle.A_ButtonSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			if (flag2)
			{
				goto IL_0305;
			}
		}
		Action<RunConfig> b2 = OnRunConfigChanged;
		Delegate obj7 = Delegate.Combine(MapSelectionUi.A_RunConfigChanged, b2);
		if ((object)obj7 == null)
		{
			MapSelectionUi.A_RunConfigChanged = (Action<RunConfig>)obj7;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<RunConfig> action2 = default(Action<RunConfig>);
			bool flag3 = action2 == null;
			obj6 = obj7;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<RunConfig>);
			if (flag3)
			{
				goto IL_031d;
			}
			MapSelectionUi.A_RunConfigChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = default(object);
			bool flag4 = obj8 == null;
			obj6 = obj7;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<RunConfig>);
			if (flag4)
			{
				goto IL_032d;
			}
		}
		Action<SelectionGroupToggleSingleButton, MapData> b3 = OnMapSelected;
		Delegate obj9 = Delegate.Combine(MapSelectionUi.A_MapSelected, b3);
		if ((object)obj9 == null)
		{
			MapSelectionUi.A_MapSelected = (Action<SelectionGroupToggleSingleButton, MapData>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton, MapData> action3 = default(Action<SelectionGroupToggleSingleButton, MapData>);
		bool flag5 = action3 == null;
		obj6 = obj9;
		obj2 = 0;
		obj3 = 0;
		num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
		if (!flag5)
		{
			MapSelectionUi.A_MapSelected = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			if (obj10 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			Delegate obj11 = default(Delegate);
			obj6 = obj11;
			object obj12 = default(object);
			obj2 = obj12;
			object obj13 = default(object);
			obj3 = obj13;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_032d;
		IL_02fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_031d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0305;
		IL_0305:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_02fa;
		IL_032d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_031d;
	}

	private void OnDestroy()
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		//IL_00e9: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0100: Expected I, but got O
		//IL_0193: Expected O, but got I4
		//IL_019c: Expected O, but got I4
		//IL_01aa: Expected I, but got O
		//IL_01eb: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_0202: Expected I, but got O
		//IL_0295: Expected O, but got I4
		//IL_029e: Expected O, but got I4
		//IL_02ac: Expected I, but got O
		SelectionGroupToggleSingle selectionGroupToggleSingle = tierSelection;
		Action<SelectionGroupToggleSingleButton> value = OnInfoChanged;
		Delegate obj = Delegate.Remove(selectionGroupToggleSingle.A_ButtonSelected, value);
		Delegate obj6;
		object obj2;
		object obj3;
		nint num;
		Delegate obj4;
		if ((object)obj == null)
		{
			selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SelectionGroupToggleSingleButton> action = default(Action<SelectionGroupToggleSingleButton>);
			bool flag = action == null;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			obj4 = obj;
			if (flag)
			{
				goto IL_02fa;
			}
			selectionGroupToggleSingle.A_ButtonSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
			obj6 = obj;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
			if (flag2)
			{
				goto IL_0305;
			}
		}
		Action<RunConfig> value2 = OnRunConfigChanged;
		Delegate obj7 = Delegate.Remove(MapSelectionUi.A_RunConfigChanged, value2);
		if ((object)obj7 == null)
		{
			MapSelectionUi.A_RunConfigChanged = (Action<RunConfig>)obj7;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<RunConfig> action2 = default(Action<RunConfig>);
			bool flag3 = action2 == null;
			obj6 = obj7;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<RunConfig>);
			if (flag3)
			{
				goto IL_031d;
			}
			MapSelectionUi.A_RunConfigChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = default(object);
			bool flag4 = obj8 == null;
			obj6 = obj7;
			obj2 = 0;
			obj3 = 0;
			num = (nint)typeof(Action<RunConfig>);
			if (flag4)
			{
				goto IL_032d;
			}
		}
		Action<SelectionGroupToggleSingleButton, MapData> value3 = OnMapSelected;
		Delegate obj9 = Delegate.Remove(MapSelectionUi.A_MapSelected, value3);
		if ((object)obj9 == null)
		{
			MapSelectionUi.A_MapSelected = (Action<SelectionGroupToggleSingleButton, MapData>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton, MapData> action3 = default(Action<SelectionGroupToggleSingleButton, MapData>);
		bool flag5 = action3 == null;
		obj6 = obj9;
		obj2 = 0;
		obj3 = 0;
		num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
		if (!flag5)
		{
			MapSelectionUi.A_MapSelected = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			if (obj10 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			Delegate obj11 = default(Delegate);
			obj6 = obj11;
			object obj12 = default(object);
			obj2 = obj12;
			object obj13 = default(object);
			obj3 = obj13;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_032d;
		IL_02fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_031d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0305;
		IL_0305:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj4 = obj6;
		goto IL_02fa;
		IL_032d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_031d;
	}

	private void OnInfoChanged(SelectionGroupToggleSingleButton btn)
	{
		Refresh();
	}

	private void OnRunConfigChanged(RunConfig runConfig)
	{
		Refresh();
	}

	private unsafe void OnMapSelected(SelectionGroupToggleSingleButton mapButton, MapData mapData)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_0277: Expected O, but got Ref
		//IL_0149: Expected O, but got I4
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_029d: Expected O, but got Ref
		//IL_02ca: Expected O, but got Ref
		List<Button> list = new List<Button>();
		SelectionGroupToggleSingleButtonTier[] array = tierButtons;
		object obj = 0;
		object obj2 = 0;
		List<Button> list2 = list;
		while (true)
		{
			if ((nint)obj2 < array.Length)
			{
				if ((nint)obj < array.Length)
				{
					Button button = array[obj].GetButton();
					int version = list._version + 1;
					list._version = version;
					list2 = (List<Button>)(object)list._items;
					if (list._size >= list2._size)
					{
						((List<object>)(object)list).AddWithResize((object)button);
						obj++;
						obj2 = obj;
						list2 = list;
						continue;
					}
					int size = list._size + 1;
					list._size = size;
					if (list._size < list2._size)
					{
						object obj3 = list._size * 8;
						object obj4 = (object)list2 + obj3;
						list2 = (List<Button>)(obj4 + 32);
						obj++;
						obj2 = obj;
						continue;
					}
				}
				goto IL_02df;
			}
			Button button2 = btnChallenges.GetButton();
			int version2 = list._version + 1;
			list._version = version2;
			list2 = (List<Button>)(object)list._items;
			if (list._size >= list2._size)
			{
				((List<object>)(object)list).AddWithResize((object)button2);
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				if (list._size >= list2._size)
				{
					goto IL_02df;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			break;
			IL_02df:
			throw new IndexOutOfRangeException();
		}
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Selectable selectable = default(Selectable);
		Navigation navigation = default(Navigation);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = (object)selectable == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					bool flag2 = (object)mapButton == null;
					enumerator2 = (List<object>.Enumerator)(&enumerator);
					if (flag2)
					{
						break;
					}
					Button button3 = mapButton.GetButton();
					selectable.navigation = (Navigation)(&navigation);
					continue;
				}
				throw new NullReferenceException();
			}
			((List<Button>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void RefreshTiers()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004e: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_02cf: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected I4, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected I4, but got Unknown
		//IL_035d: Expected O, but got I
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Expected O, but got Unknown
		//IL_0412: Expected O, but got Ref
		//IL_0483: Expected O, but got Ref
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		MapSelectionUi mapSelectionUi = this.mapSelectionUi;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		RunConfig runConfig = mapSelectionUi.runConfig;
		MapData mapData = runConfig.mapData;
		bool flag = mapData.eMap == EMap.Graveyard;
		object obj3 = 1;
		if (!flag)
		{
			obj3 = 3;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		int highestCompletedTier = progression.menuMeta.GetHighestCompletedTier(mapData.eMap);
		SelectionGroupToggleSingleButtonTier[] array = tierButtons;
		object obj4 = 0;
		object obj5 = 0;
		while ((nint)obj4 < array.Length)
		{
			SelectionGroupToggleSingleButtonTier[] array2 = tierButtons;
			object obj6 = highestCompletedTier + 1;
			object obj7 = obj5 - obj6;
			object obj8 = obj5 ^ obj6;
			object obj9 = obj5 ^ obj7;
			object obj10 = obj8 & obj9;
			bool flag2 = (nint)obj10 < 0;
			bool flag3 = (nint)obj7 < 0;
			bool flag4 = obj7 == null;
			bool flag5 = flag3 != flag2;
			bool b = flag5 | flag4;
			array2[obj5].CanSelect(b);
			SelectionGroupToggleSingleButtonTier[] array3 = tierButtons;
			MapSelectionUi mapSelectionUi2 = this.mapSelectionUi;
			object obj11 = obj5 - highestCompletedTier;
			int num = obj5 ^ highestCompletedTier;
			object obj12 = obj5 ^ obj11;
			int num2 = num & obj12;
			bool flag6 = num2 < 0;
			bool flag7 = (nint)obj11 < 0;
			bool flag8 = obj11 == null;
			bool flag9 = flag7 != flag6;
			bool completed = flag9 | flag8;
			array3[obj5].SetCompleted(completed, mapSelectionUi2.runConfig);
			SelectionGroupToggleSingleButtonTier[] array4 = tierButtons;
			GameObject gameObject;
			bool active;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				gameObject = array4[obj5].gameObject;
				active = true;
			}
			else
			{
				gameObject = array4[obj5].gameObject;
				active = false;
			}
			gameObject.SetActive(active);
			array = tierButtons;
			obj5++;
			obj4 = obj5;
		}
		object obj13 = 0;
		do
		{
			SelectionGroupToggleSingleButtonTier[] array5 = tierButtons;
			Button button = array5[obj13].GetButton();
			_ = ((Selectable)button).m_Navigation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v20 (UnityEngine.UI.Button)+38]");
			_ = 0;
			object obj14 = obj3 - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v20 (UnityEngine.UI.Button)+48]");
			_ = 0;
			if (obj13 != obj14)
			{
				SelectionGroupToggleSingleButtonTier[] array6 = tierButtons;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v28 (SelectionGroupToggleSingleButtonTier[])+28+v124 @ rbx_v7*8]");
				Button button2 = ((MyButton)0).GetButton();
			}
			else
			{
				Button button3 = btnChallenges.GetButton();
				Button button4 = btnChallenges.GetButton();
				SelectionGroupToggleSingleButtonTier[] array7 = tierButtons;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v29 (UnityEngine.UI.Button)+48]");
				_ = 0;
				_ = ((Selectable)button4).m_Navigation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v29 (UnityEngine.UI.Button)+38]");
				_ = 0;
				Button button5 = array7[obj13].GetButton();
				Button button6 = btnChallenges.GetButton();
				Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-1]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F]");
				_ = 0;
				button6.navigation = navigation;
			}
			SelectionGroupToggleSingleButtonTier[] array8 = tierButtons;
			Button button7 = array8[obj13].GetButton();
			Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
			_ = 0;
			button7.navigation = navigation2;
			obj13++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3));
		tierSelection.FindButtons();
	}

	private unsafe void Refresh()
	{
		//IL_007d: Expected O, but got Ref
		//IL_00e1: Expected I, but got O
		//IL_00fa: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_01dd: Expected I, but got O
		//IL_0218: Expected I, but got O
		//IL_0239: Expected O, but got I
		//IL_0258: Expected O, but got I
		//IL_0283: Expected I, but got O
		//IL_0295: Expected O, but got I4
		//IL_0386: Expected I, but got O
		//IL_03d0: Expected I, but got O
		//IL_041c: Expected I, but got O
		//IL_045c: Expected I, but got O
		//IL_0559: Expected I, but got O
		//IL_0569: Expected O, but got I
		//IL_04a7: Expected I, but got O
		//IL_058b: Expected I, but got O
		//IL_05c4: Expected O, but got I
		//IL_04cc: Expected O, but got I4
		//IL_04e5: Expected I, but got O
		//IL_05fb: Expected O, but got I
		//IL_0505: Expected I, but got O
		//IL_0533: Expected I, but got O
		//IL_062c: Expected O, but got I
		//IL_071b: Expected O, but got I
		//IL_0735: Expected I, but got O
		//IL_073d: Expected O, but got I4
		//IL_074d: Expected O, but got I
		//IL_075d: Expected O, but got I
		//IL_0dd8: Expected I, but got O
		//IL_0de5: Expected O, but got I4
		//IL_07a5: Expected I, but got O
		//IL_07b2: Expected O, but got I4
		//IL_07e6: Expected I, but got O
		//IL_07f3: Expected O, but got I4
		//IL_0821: Expected I, but got O
		//IL_082e: Expected O, but got I4
		//IL_0862: Expected I, but got O
		//IL_0885: Expected O, but got I
		//IL_08a1: Expected I, but got O
		//IL_08cd: Expected I, but got O
		//IL_091c: Expected O, but got I
		//IL_092c: Expected O, but got I
		//IL_0ce0: Expected I, but got O
		//IL_0952: Expected I, but got O
		//IL_0980: Expected I, but got O
		//IL_0986: Expected O, but got I
		//IL_0996: Expected O, but got I
		//IL_099e: Expected O, but got I
		//IL_09d2: Expected I, but got O
		//IL_09d8: Expected O, but got I
		//IL_09e8: Expected O, but got I
		//IL_09f0: Expected O, but got I
		//IL_0a24: Expected I, but got O
		//IL_0a2a: Expected O, but got I
		//IL_0a3a: Expected O, but got I
		//IL_0a68: Expected I, but got O
		//IL_0a6e: Expected O, but got I
		//IL_0a7e: Expected O, but got I
		//IL_0ab2: Expected I, but got O
		//IL_0ab8: Expected O, but got I
		//IL_0ad6: Expected O, but got I
		//IL_0af2: Expected I, but got O
		//IL_0af8: Expected O, but got I
		//IL_0b1f: Expected I, but got O
		//IL_0b25: Expected O, but got I
		//IL_0b72: Expected I, but got O
		//IL_0b78: Expected O, but got I
		//IL_0b88: Expected O, but got I
		//IL_0bc3: Expected I, but got O
		//IL_0bc9: Expected O, but got I
		//IL_0bd9: Expected O, but got I
		//IL_0c12: Expected I, but got O
		//IL_0c18: Expected O, but got I
		//IL_0c40: Expected O, but got I
		//IL_0c55: Expected O, but got I
		//IL_0c5d: Expected O, but got I4
		//IL_0c8b: Expected I, but got O
		//IL_0c91: Expected O, but got I
		//IL_0c99: Expected O, but got I4
		RefreshTiers();
		SelectionGroupToggleSingle selectionGroupToggleSingle = tierSelection;
		bool flag = (object)tierSelection == null;
		object obj = null;
		string text5;
		nint num2;
		if (!flag)
		{
			int selectedIndex = tierSelection.GetSelectedIndex();
			LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("ChallengesUi", "STAGES");
			object[] array = new object[1];
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = default(int);
			string text = num.ToString();
			bool flag2 = dictionary == null;
			object obj2 = null;
			obj = null;
			selectionGroupToggleSingle = (SelectionGroupToggleSingle)(&num);
			if (!flag2)
			{
				((Dictionary<object, object>)(object)dictionary).Add((object)"numStages", (object)text);
				bool flag3 = array == null;
				num2 = 0;
				obj2 = text;
				obj = "numStages";
				selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)dictionary;
				if (!flag3)
				{
					nint num3 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
					dictionary.Add((string)0, text);
					object obj3 = default(object);
					bool flag4 = obj3 == null;
					num2 = 0;
					obj2 = text;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
					obj = 0;
					selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)dictionary;
					if (flag4)
					{
						((Dictionary<string, string>)(object)selectionGroupToggleSingle).Add((string)obj, (string)obj2);
						object obj4 = default(object);
						throw obj4;
					}
					selectionGroupToggleSingle = (SelectionGroupToggleSingle)(array + 32);
					array[0] = dictionary;
					bool flag5 = localizedStringReference == null;
					num2 = 0;
					obj2 = text;
					obj = dictionary;
					if (!flag5)
					{
						string localizedString = localizedStringReference.GetLocalizedString(array);
						string text2 = "" + localizedString + "\n";
						selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)this.mapSelectionUi;
						bool flag6 = (object)this.mapSelectionUi == null;
						num2 = unchecked((nint)null);
						obj2 = "\n";
						obj = localizedString;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rcx_v5 (SelectionGroupToggleSingle)+90]");
							bool flag7 = (nint)0 == 0;
							num2 = unchecked((nint)null);
							obj2 = "\n";
							obj = localizedString;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rcx_v5 (SelectionGroupToggleSingle)+90]");
							selectionGroupToggleSingle = (SelectionGroupToggleSingle)0;
							if (!flag7)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rcx_v5 (SelectionGroupToggleSingle)+90]");
								float silverMultiplier = ((RunConfig)0).GetSilverMultiplier();
								string[] array2 = new string[6];
								bool flag8 = array2 == null;
								num2 = unchecked((nint)null);
								obj2 = "\n";
								obj = 6;
								selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)typeof(string[]);
								if (!flag8)
								{
									array2[0] = text2;
									array2[1] = "<sprite name=silver> ";
									string text3 = MyStringUtil.ShowOnlyDecimals(silverMultiplier);
									array2[2] = text3;
									array2[3] = "x ";
									string statName = LocalizationUtility.GetStatName(EStat.SilverIncreaseMultiplier);
									array2[4] = statName;
									array2[5] = "\n";
									string text4 = string.Concat(array2);
									MapSelectionUi mapSelectionUi = this.mapSelectionUi;
									bool flag9 = (object)this.mapSelectionUi == null;
									num2 = unchecked((nint)null);
									obj2 = "\n";
									obj = null;
									selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)array2;
									if (!flag9)
									{
										RunConfig runConfig = mapSelectionUi.runConfig;
										bool flag10 = mapSelectionUi.runConfig == null;
										num2 = unchecked((nint)null);
										obj2 = "\n";
										obj = null;
										selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)array2;
										if (!flag10)
										{
											bool flag11 = runConfig.challenge != null;
											bool flag12 = !flag11;
											num2 = unchecked((nint)null);
											text5 = text4;
											obj2 = null;
											obj = null;
											if (flag12)
											{
												goto IL_0d6a;
											}
											MapSelectionUi mapSelectionUi2 = this.mapSelectionUi;
											bool flag13 = (object)this.mapSelectionUi == null;
											num2 = unchecked((nint)null);
											obj2 = null;
											obj = null;
											selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)runConfig.challenge;
											if (!flag13)
											{
												selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)mapSelectionUi2.runConfig;
												bool flag14 = mapSelectionUi2.runConfig == null;
												num2 = unchecked((nint)null);
												obj2 = null;
												obj = null;
												if (!flag14)
												{
													selectionGroupToggleSingle = (SelectionGroupToggleSingle)selectionGroupToggleSingle.startIndex;
													bool flag15 = selectionGroupToggleSingle.startIndex == 0;
													num2 = unchecked((nint)null);
													obj2 = null;
													obj = null;
													if (!flag15)
													{
														nint num4 = (nint)selectionGroupToggleSingle;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v927 @ rax_v79 (Il2CppClass<SelectionGroupToggleSingle>)+188] (should have been resolved before IL gen)");
														string text7 = default(string);
														string text6 = text4 + "<color=orange>" + text7 + "</color>";
														num2 = unchecked((nint)"</color>");
														text5 = text6;
														obj2 = text7;
														obj = "<color=orange>";
														goto IL_0d6a;
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
		goto IL_0d07;
		IL_0d6a:
		selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)t_mapSpecs;
		bool active;
		GameObject gameObject;
		if ((object)t_mapSpecs != null)
		{
			num2 = (nint)selectionGroupToggleSingle;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ r9_v2 (Il2CppMethodInfo)+560]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v603 @ r9_v2 (Il2CppMethodInfo)+558] (should have been resolved before IL gen)");
			nint num5 = (nint)typeof(SaveManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v948 @ rax_v41 (Il2CppClass<SaveManager>)+B8]");
			nint num6 = 0;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			bool flag16 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
			obj = text5;
			selectionGroupToggleSingle = (SelectionGroupToggleSingle)num6;
			if (!flag16)
			{
				obj = saveManager.progression;
				bool flag17 = saveManager.progression == null;
				selectionGroupToggleSingle = (SelectionGroupToggleSingle)num6;
				if (!flag17)
				{
					MapSelectionUi mapSelectionUi3 = this.mapSelectionUi;
					bool flag18 = (object)this.mapSelectionUi == null;
					selectionGroupToggleSingle = (SelectionGroupToggleSingle)num6;
					if (!flag18)
					{
						selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)mapSelectionUi3.runConfig;
						if (mapSelectionUi3.runConfig != null)
						{
							IntPtr cachedPtr = ((UnityEngine.Object)selectionGroupToggleSingle).m_CachedPtr;
							if (((UnityEngine.Object)selectionGroupToggleSingle).m_CachedPtr != (IntPtr)0)
							{
								selectionGroupToggleSingle = tierSelection;
								if ((object)tierSelection != null)
								{
									int selectedIndex2 = tierSelection.GetSelectedIndex();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+50]");
									bool flag19 = (nint)0 == 0;
									obj = null;
									if (!flag19)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+50]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v44 (System.IntPtr)+58]");
										bool flag20 = ((MenuMeta)num7).IsTierCompleted(EMap.None, selectedIndex2);
										bool flag21 = (object)btnChallenges == null;
										num2 = unchecked((nint)null);
										obj2 = selectedIndex2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v44 (System.IntPtr)+58]");
										obj = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+50]");
										selectionGroupToggleSingle = (SelectionGroupToggleSingle)0;
										if (!flag21)
										{
											btnChallenges.SetInteractableButKeepSelectionOn(flag20);
											selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)btnChallenges;
											SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
											bool flag22 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
											num2 = unchecked((nint)null);
											obj2 = null;
											obj = flag20;
											if (!flag22)
											{
												ProgressionSaveFile progression = saveManager2.progression;
												bool flag23 = saveManager2.progression == null;
												num2 = unchecked((nint)null);
												obj2 = null;
												obj = flag20;
												if (!flag23)
												{
													selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)progression.menuMeta;
													bool flag24 = progression.menuMeta == null;
													num2 = unchecked((nint)null);
													obj2 = null;
													obj = flag20;
													if (!flag24)
													{
														MapSelectionUi mapSelectionUi4 = this.mapSelectionUi;
														bool flag25 = (object)this.mapSelectionUi == null;
														num2 = unchecked((nint)null);
														obj2 = null;
														obj = flag20;
														if (!flag25)
														{
															obj = mapSelectionUi4.runConfig;
															bool flag26 = mapSelectionUi4.runConfig == null;
															num2 = unchecked((nint)null);
															obj2 = null;
															if (!flag26)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+10]");
																obj = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+10]");
																bool flag27 = (nint)0 == 0;
																num2 = unchecked((nint)null);
																obj2 = null;
																if (!flag27)
																{
																	bool flag28 = ((MonoBehaviour)selectionGroupToggleSingle).m_CancellationTokenSource == null;
																	num2 = unchecked((nint)null);
																	obj2 = null;
																	selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)((MonoBehaviour)selectionGroupToggleSingle).m_CancellationTokenSource;
																	if (!flag28)
																	{
																		CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)selectionGroupToggleSingle).m_CancellationTokenSource;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																		bool flag29 = ((Dictionary<System.Int32Enum, object>)(object)cancellationTokenSource).ContainsKey((System.Int32Enum)0);
																		bool flag30 = !flag29;
																		obj2 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																		obj = 0;
																		if (flag30)
																		{
																			goto IL_0cc0;
																		}
																		nint num8 = (nint)typeof(SaveManager);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rax_v62 (Il2CppClass<SaveManager>)+B8]");
																		nint num9 = 0;
																		SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
																		bool flag31 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
																		num2 = unchecked((nint)null);
																		obj2 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																		obj = 0;
																		selectionGroupToggleSingle = (SelectionGroupToggleSingle)num9;
																		if (!flag31)
																		{
																			ProgressionSaveFile progression2 = saveManager3.progression;
																			bool flag32 = saveManager3.progression == null;
																			num2 = unchecked((nint)null);
																			obj2 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																			obj = 0;
																			selectionGroupToggleSingle = (SelectionGroupToggleSingle)num9;
																			if (!flag32)
																			{
																				selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)progression2.menuMeta;
																				bool flag33 = progression2.menuMeta == null;
																				num2 = unchecked((nint)null);
																				obj2 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																				obj = 0;
																				if (!flag33)
																				{
																					MapSelectionUi mapSelectionUi5 = this.mapSelectionUi;
																					bool flag34 = (object)this.mapSelectionUi == null;
																					num2 = unchecked((nint)null);
																					obj2 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																					obj = 0;
																					if (!flag34)
																					{
																						obj = mapSelectionUi5.runConfig;
																						bool flag35 = mapSelectionUi5.runConfig == null;
																						num2 = unchecked((nint)null);
																						obj2 = 0;
																						if (!flag35)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+10]");
																							obj = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+10]");
																							bool flag36 = (nint)0 == 0;
																							num2 = unchecked((nint)null);
																							obj2 = 0;
																							if (!flag36)
																							{
																								bool flag37 = ((MonoBehaviour)selectionGroupToggleSingle).m_CancellationTokenSource == null;
																								num2 = unchecked((nint)null);
																								obj2 = 0;
																								selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)((MonoBehaviour)selectionGroupToggleSingle).m_CancellationTokenSource;
																								if (!flag37)
																								{
																									CancellationTokenSource cancellationTokenSource2 = ((MonoBehaviour)selectionGroupToggleSingle).m_CancellationTokenSource;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																									object obj5 = ((Dictionary<System.Int32Enum, object>)(object)cancellationTokenSource2).get_Item((System.Int32Enum)0);
																									bool flag38 = obj5 == null;
																									num2 = unchecked((nint)null);
																									obj2 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																									obj = 0;
																									selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)((MonoBehaviour)selectionGroupToggleSingle).m_CancellationTokenSource;
																									if (!flag38)
																									{
																										selectionGroupToggleSingle = tierSelection;
																										bool flag39 = (object)tierSelection == null;
																										num2 = unchecked((nint)null);
																										obj2 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rdx_v3 (System.Object)+58]");
																										obj = 0;
																										if (!flag39)
																										{
																											int selectedIndex3 = tierSelection.GetSelectedIndex();
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v66 (System.Object)+18]");
																											bool flag40 = (nint)0 == 0;
																											num2 = unchecked((nint)null);
																											obj2 = 0;
																											obj = null;
																											if (!flag40)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v66 (System.Object)+18]");
																												bool flag41 = ((HashSet<int>)0).Contains(selectedIndex3);
																												bool flag42 = !flag41;
																												obj2 = 0;
																												obj = selectedIndex3;
																												if (flag42)
																												{
																													goto IL_0cc0;
																												}
																												selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)newChallengesIndicator;
																												bool flag43 = (object)newChallengesIndicator == null;
																												num2 = unchecked((nint)null);
																												obj2 = 0;
																												obj = selectedIndex3;
																												if (!flag43)
																												{
																													active = true;
																													gameObject = newChallengesIndicator;
																													goto IL_0dac;
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
		goto IL_0d07;
		IL_0dac:
		gameObject.SetActive(active);
		return;
		IL_0d07:
		throw new NullReferenceException();
		IL_0cc0:
		selectionGroupToggleSingle = (SelectionGroupToggleSingle)(object)newChallengesIndicator;
		bool flag44 = (object)newChallengesIndicator == null;
		num2 = unchecked((nint)null);
		if (flag44)
		{
			goto IL_0d07;
		}
		active = false;
		gameObject = newChallengesIndicator;
		goto IL_0dac;
	}
}
