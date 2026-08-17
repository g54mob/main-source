using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapMenu : MonoBehaviour
{
	public Transform mapGridParent;

	public GameObject mapPrefabUi;

	public MyButton b_confirm;

	public BackEscape windowBackEscape;

	private List<MyButtonMap> mapButtons;

	public TextMeshProUGUI t_buttonDisabledText;

	private MyButton selectedButton;

	public MapData selectedMap;

	private unsafe void Start()
	{
		//IL_0161: Expected O, but got I
		//IL_0172: Expected O, but got I
		//IL_0824: Expected O, but got Ref
		//IL_030f: Expected O, but got Ref
		//IL_0317: Expected O, but got Ref
		//IL_0296: Expected O, but got I4
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_07c0: Expected O, but got Ref
		//IL_03e9: Expected O, but got Ref
		//IL_0381: Expected O, but got Ref
		//IL_048c: Expected O, but got Ref
		//IL_0587: Expected I4, but got O
		//IL_05a8: Expected I, but got O
		//IL_05db: Expected I4, but got O
		//IL_05fc: Expected I, but got O
		//IL_067e: Expected I4, but got O
		//IL_069f: Expected I, but got O
		//IL_06d2: Expected I4, but got O
		//IL_06f3: Expected I, but got O
		List<MyButtonMap> list = (mapButtons = new List<MyButtonMap>());
		GameObject gameObject = mapPrefabUi;
		bool flag = (object)mapPrefabUi == null;
		List<MyButtonMap> list2 = list;
		if (!flag)
		{
			list2 = mapButtons;
			MyButtonMap component = mapPrefabUi.GetComponent<MyButtonMap>();
			if (mapButtons != null)
			{
				int version = list2._version + 1;
				list2._version = version;
				gameObject = (GameObject)(object)list2._items;
				if (list2._items != null)
				{
					int size = list2._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v16 (UnityEngine.GameObject)+18]");
					if ((nint)size >= (nint)0)
					{
						((List<object>)(object)mapButtons).AddWithResize((object)component);
					}
					else
					{
						int size2 = list2._size + 1;
						list2._size = size2;
					}
					gameObject = (GameObject)(object)DataManager.Instance;
					if ((object)DataManager.Instance != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v16 (UnityEngine.GameObject)+40]");
						IEnumerable<object> enumerable = (IEnumerable<object>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v16 (UnityEngine.GameObject)+40]");
						List<object> list3 = Enumerable.ToList((IEnumerable<object>)0);
						int num = 0;
						List<object>.Enumerator enumerator = default(List<object>.Enumerator);
						MapData mapData = default(MapData);
						Navigation navigation = default(Navigation);
						while (true)
						{
							gameObject = (GameObject)(object)enumerable;
							bool flag2 = list3 == null;
							list2 = (List<MyButtonMap>)(object)list3;
							if (flag2)
							{
								break;
							}
							if (num < MyAchievements.fakeMaps)
							{
								int version2 = ((List<MyButtonMap>)(object)list3)._version + 1;
								((List<MyButtonMap>)(object)list3)._version = version2;
								gameObject = (GameObject)(object)((List<MyButtonMap>)(object)list3)._items;
								bool flag3 = ((List<MyButtonMap>)(object)list3)._items == null;
								list2 = (List<MyButtonMap>)(object)list3;
								if (flag3)
								{
									break;
								}
								int size3 = ((List<MyButtonMap>)(object)list3)._size;
								int size4 = ((List<MyButtonMap>)(object)list3)._size;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v16 (UnityEngine.GameObject)+18]");
								if ((nint)size4 >= (nint)0)
								{
									list3.AddWithResize((object)null);
									num++;
									enumerable = list3;
									continue;
								}
								int size5 = ((List<MyButtonMap>)(object)list3)._size + 1;
								((List<MyButtonMap>)(object)list3)._size = size5;
								_ = 0;
								object obj = ((List<MyButtonMap>)(object)list3)._size * 8;
								object obj2 = (object)((List<MyButtonMap>)(object)list3)._items + obj;
								enumerable = (IEnumerable<object>)(obj2 + 32);
								num++;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
							num = 0;
							nint num2;
							while (enumerator.MoveNext())
							{
								List<MyButtonMap> list4 = mapButtons;
								bool flag4 = mapButtons == null;
								num2 = num;
								list2 = (List<MyButtonMap>)(&enumerator);
								List<MyButtonMap> list5 = (List<MyButtonMap>)(&enumerator);
								if (!flag4)
								{
									bool flag5 = num < list4._size;
									MapData map = mapData;
									if (!flag5)
									{
										GameObject gameObject2 = UnityEngine.Object.Instantiate(mapPrefabUi, mapGridParent);
										bool flag6 = (object)gameObject2 == null;
										list2 = (List<MyButtonMap>)(&enumerator);
										if (flag6)
										{
											throw new NullReferenceException();
										}
										MyButtonMap component2 = gameObject2.GetComponent<MyButtonMap>();
										mapButtons.Add(component2);
										map = mapData;
									}
									bool flag7 = mapButtons == null;
									list2 = (List<MyButtonMap>)(&enumerator);
									if (!flag7)
									{
										MyButtonMap myButtonMap = mapButtons.get_Item(num);
										bool flag8 = (object)myButtonMap == null;
										list2 = (List<MyButtonMap>)(&enumerator);
										if (!flag8)
										{
											myButtonMap.SetMap(map);
											num++;
											continue;
										}
										throw new NullReferenceException();
									}
									num2 = num;
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							((List<MapData>.Enumerator*)(&enumerator))->Dispose();
							bool flag9 = mapButtons == null;
							list2 = (List<MyButtonMap>)(&enumerator);
							if (flag9)
							{
								break;
							}
							MyButtonMap myButtonMap2 = mapButtons.get_Item(0);
							Button button = b_confirm.GetButton();
							Button button2 = myButtonMap2.GetButton();
							Button button3 = b_confirm.GetButton();
							button3.navigation = (Navigation)(&navigation);
							selectedMap = myButtonMap2.mapData;
							BackEscape backEscape = windowBackEscape;
							backEscape.enabled = true;
							selectedButton = myButtonMap2;
							bool flag10 = myButtonMap2.mapData == null;
							MyButton myButton = b_confirm;
							if (!flag10)
							{
								myButton.state = MyButton.EButtonState.Active;
								myButton.RefreshState();
							}
							else
							{
								myButton.state = MyButton.EButtonState.Inactive;
								myButton.RefreshState();
								t_buttonDisabledText.text = "Unavailable\nin demo :(";
							}
							Action<MyButtonMap> b = OnSelectMap;
							Delegate obj3 = Delegate.Combine(MyButtonMap.A_Select, b);
							if ((object)obj3 == null)
							{
								MyButtonMap.A_Select = null;
							}
							else
							{
								MyButtonMap myButtonMap3 = ((List<MyButtonMap>)(object)obj3).get_Item((int)typeof(Action<MyButtonMap>));
								bool flag11 = (object)myButtonMap3 == null;
								num2 = (nint)typeof(Action<MyButtonMap>);
								list2 = (List<MyButtonMap>)(object)obj3;
								if (flag11)
								{
									goto IL_0866;
								}
								MyButtonMap.A_Select = (Action<MyButtonMap>)(object)myButtonMap3;
								MyButtonMap myButtonMap4 = ((List<MyButtonMap>)(object)obj3).get_Item((int)typeof(Action<MyButtonMap>));
								bool flag12 = (object)myButtonMap4 == null;
								num2 = (nint)typeof(Action<MyButtonMap>);
								list2 = (List<MyButtonMap>)(object)obj3;
								if (flag12)
								{
									goto IL_087d;
								}
							}
							Action<MyButtonMap> b2 = OnConfirmMap;
							Delegate obj4 = Delegate.Combine(MyButtonMap.A_Confirm, b2);
							if ((object)obj4 == null)
							{
								MyButtonMap.A_Confirm = null;
								goto IL_070a;
							}
							MyButtonMap myButtonMap5 = ((List<MyButtonMap>)(object)obj4).get_Item((int)typeof(Action<MyButtonMap>));
							bool flag13 = (object)myButtonMap5 == null;
							num2 = (nint)typeof(Action<MyButtonMap>);
							list2 = (List<MyButtonMap>)(object)obj4;
							if (!flag13)
							{
								MyButtonMap.A_Confirm = (Action<MyButtonMap>)(object)myButtonMap5;
								MyButtonMap myButtonMap6 = ((List<MyButtonMap>)(object)obj4).get_Item((int)typeof(Action<MyButtonMap>));
								bool flag14 = (object)myButtonMap6 == null;
								num2 = (nint)typeof(Action<MyButtonMap>);
								list2 = (List<MyButtonMap>)(object)obj4;
								if (!flag14)
								{
									goto IL_070a;
								}
								MyButtonMap myButtonMap7 = list2.get_Item((int)num2);
							}
							MyButtonMap myButtonMap8 = list2.get_Item((int)num2);
							goto IL_087d;
							IL_087d:
							MyButtonMap myButtonMap9 = list2.get_Item((int)num2);
							goto IL_0866;
							IL_070a:
							Invoke("RefreshArrow", 0.1f);
							return;
							IL_0866:
							MyButtonMap myButtonMap10 = list2.get_Item((int)num2);
							throw new NullReferenceException();
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RefreshArrow()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180578BE0");
	}

	private unsafe void OnSelectMap(MyButtonMap mapButton)
	{
		//IL_004c: Expected O, but got Ref
		Button button = b_confirm.GetButton();
		Button button2 = mapButton.GetButton();
		Button button3 = b_confirm.GetButton();
		object obj = default(object);
		button3.navigation = (Navigation)(&obj);
		selectedMap = mapButton.mapData;
		BackEscape backEscape = windowBackEscape;
		backEscape.enabled = true;
		selectedButton = mapButton;
		bool flag = mapButton.mapData == null;
		MyButton myButton = b_confirm;
		if (!flag)
		{
			myButton.state = MyButton.EButtonState.Active;
			myButton.RefreshState();
		}
		else
		{
			myButton.state = MyButton.EButtonState.Inactive;
			myButton.RefreshState();
			t_buttonDisabledText.text = "Unavailable\nin demo :(";
		}
	}

	private void OnConfirmMap(MyButtonMap mapButton)
	{
		ButtonManager.ForceHoverButton(b_confirm);
		mapButton.StartHover();
		BackEscape backEscape = windowBackEscape;
		backEscape.enabled = false;
		selectedButton = mapButton;
	}

	private void Update()
	{
		if (MyInputManager.GetButtonDown(MyInputManager.UICancel))
		{
			BackEscape backEscape = windowBackEscape;
			if (!backEscape.enabled)
			{
				ButtonManager.ForceHoverButton(selectedButton);
			}
		}
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<MyButtonMap> value = OnSelectMap;
		Delegate obj = Delegate.Remove(MyButtonMap.A_Select, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonMap.A_Select = (Action<MyButtonMap>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButtonMap> action = default(Action<MyButtonMap>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<MyButtonMap>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			MyButtonMap.A_Select = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<MyButtonMap>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<MyButtonMap> value2 = OnConfirmMap;
		Delegate obj6 = Delegate.Remove(MyButtonMap.A_Confirm, value2);
		if ((object)obj6 == null)
		{
			MyButtonMap.A_Confirm = (Action<MyButtonMap>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyButtonMap> action2 = default(Action<MyButtonMap>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<MyButtonMap>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		MyButtonMap.A_Confirm = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<MyButtonMap>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	public void StartMap()
	{
	}
}
