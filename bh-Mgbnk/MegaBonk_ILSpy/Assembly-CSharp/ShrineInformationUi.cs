using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI;
using Cpp2ILInjected;
using UnityEngine;

public class ShrineInformationUi : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>> _003C_003E9__10_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CInit_003Eb__10_0(KeyValuePair<string, InteractablesStatus.InteractableStatusContainer> a, KeyValuePair<string, InteractablesStatus.InteractableStatusContainer> b)
		{
			return string.Compare((string)a, (string)b, StringComparison.Ordinal);
		}
	}

	public Transform parent;

	public GameObject prefab;

	private List<ShrineInformationPrefab> entries;

	private int ticksUntilInit = 5;

	private void Awake()
	{
		//IL_0528: Expected I, but got O
		//IL_0539: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_056b: Expected I, but got O
		//IL_057c: Expected O, but got I4
		//IL_0592: Expected I, but got O
		//IL_05b8: Expected I, but got O
		//IL_05c9: Expected O, but got I4
		//IL_05df: Expected I, but got O
		//IL_01db: Expected I, but got O
		//IL_01ec: Expected O, but got I4
		//IL_022f: Expected I, but got O
		//IL_0240: Expected O, but got I4
		//IL_02d2: Expected I, but got O
		//IL_02e3: Expected O, but got I4
		//IL_0326: Expected I, but got O
		//IL_0337: Expected O, but got I4
		//IL_0353: Expected I, but got O
		//IL_067d: Expected O, but got I4
		//IL_0693: Expected I, but got O
		//IL_0435: Expected I, but got O
		//IL_06c1: Expected O, but got I4
		//IL_06d7: Expected I, but got O
		//IL_0705: Expected O, but got I4
		//IL_071b: Expected I, but got O
		//IL_0749: Expected O, but got I4
		//IL_075f: Expected I, but got O
		Action<string, object, object> b = OnSettingUpdate;
		Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action = default(Action<string, object, object>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, object, object>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_07e5;
			}
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0548;
			}
		}
		Action action2 = OnMapGenerated;
		Delegate obj6 = Delegate.Combine(MapGenerationController.A_GenerationComplete, action2);
		if ((object)obj6 == null)
		{
			MapGenerationController.A_GenerationComplete = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)MapGenerationController.A_GenerationComplete;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0795;
			}
			MapGenerationController.A_GenerationComplete = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num2 = (nint)MapGenerationController.A_GenerationComplete;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_07a5;
			}
		}
		Action<string> b2 = OnInteractableStatusUpdate;
		Delegate obj9 = Delegate.Combine(InteractablesStatus.A_InteractableUsed, b2);
		if ((object)obj9 == null)
		{
			InteractablesStatus.A_InteractableUsed = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action3 = default(Action<string>);
			bool flag6 = action3 == null;
			num2 = (nint)typeof(Action<string>);
			obj2 = obj9;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_0615;
			}
			InteractablesStatus.A_InteractableUsed = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag7 = obj10 == null;
			num = (nint)typeof(Action<string>);
			obj2 = obj9;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_0625;
			}
		}
		Action<string> b3 = OnInteractableSpawned;
		Delegate obj11 = Delegate.Combine(InteractablesStatus.A_InteractableSpawned, b3);
		if ((object)obj11 == null)
		{
			InteractablesStatus.A_InteractableSpawned = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action4 = default(Action<string>);
			bool flag8 = action4 == null;
			num = (nint)typeof(Action<string>);
			obj2 = obj11;
			obj3 = 0;
			obj4 = null;
			if (flag8)
			{
				goto IL_063d;
			}
			InteractablesStatus.A_InteractableSpawned = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag9 = obj12 == null;
			num = (nint)typeof(Action<string>);
			obj2 = obj11;
			obj3 = 0;
			obj4 = null;
			if (flag9)
			{
				goto IL_064d;
			}
		}
		num = (nint)GameManager.A_DungeonStarted;
		Action action5 = Refresh;
		Delegate obj13 = Delegate.Combine(GameManager.A_DungeonStarted, action5);
		if ((object)obj13 == null)
		{
			GameManager.A_DungeonStarted = null;
		}
		else
		{
			bool flag10 = (object)obj13.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj13;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj13;
			nint num5 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_07b5;
			}
			GameManager.A_DungeonStarted = (Action)obj14;
			bool flag12 = (object)obj13.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag12)
			{
				obj15 = obj13;
			}
			bool flag13 = (object)obj15 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj13;
			nint num6 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_07c5;
			}
		}
		num = (nint)GameManager.A_DungeonEnded;
		Action action6 = Refresh;
		Delegate obj16 = Delegate.Combine(GameManager.A_DungeonEnded, action6);
		if ((object)obj16 == null)
		{
			GameManager.A_DungeonEnded = null;
			return;
		}
		bool flag14 = (object)obj16.GetType() != typeof(Action);
		Delegate obj17 = null;
		if (!flag14)
		{
			obj17 = obj16;
		}
		bool flag15 = (object)obj17 == null;
		obj2 = action6;
		obj3 = 0;
		obj4 = obj16;
		nint num7 = (nint)typeof(Action);
		if (flag15)
		{
			goto IL_07d5;
		}
		GameManager.A_DungeonEnded = (Action)obj17;
		bool flag16 = (object)obj16.GetType() != typeof(Action);
		Delegate obj18 = null;
		if (!flag16)
		{
			obj18 = obj16;
		}
		bool flag17 = (object)obj18 == null;
		obj2 = action6;
		obj3 = 0;
		obj4 = obj16;
		nint num8 = (nint)typeof(Action);
		if (!flag17)
		{
			return;
		}
		goto IL_07e5;
		IL_07b5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_064d;
		IL_064d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_063d;
		IL_063d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0625;
		IL_07c5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07b5;
		IL_07a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0795;
		IL_0615:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07a5;
		IL_0795:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0548;
		IL_0625:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0615;
		IL_0548:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_07e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07d5;
		IL_07d5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07c5;
	}

	private void OnDestroy()
	{
		//IL_0528: Expected I, but got O
		//IL_0539: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_056b: Expected I, but got O
		//IL_057c: Expected O, but got I4
		//IL_0592: Expected I, but got O
		//IL_05b8: Expected I, but got O
		//IL_05c9: Expected O, but got I4
		//IL_05df: Expected I, but got O
		//IL_01db: Expected I, but got O
		//IL_01ec: Expected O, but got I4
		//IL_022f: Expected I, but got O
		//IL_0240: Expected O, but got I4
		//IL_02d2: Expected I, but got O
		//IL_02e3: Expected O, but got I4
		//IL_0326: Expected I, but got O
		//IL_0337: Expected O, but got I4
		//IL_0353: Expected I, but got O
		//IL_067d: Expected O, but got I4
		//IL_0693: Expected I, but got O
		//IL_0435: Expected I, but got O
		//IL_06c1: Expected O, but got I4
		//IL_06d7: Expected I, but got O
		//IL_0705: Expected O, but got I4
		//IL_071b: Expected I, but got O
		//IL_0749: Expected O, but got I4
		//IL_075f: Expected I, but got O
		Action<string, object, object> value = OnSettingUpdate;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action = default(Action<string, object, object>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, object, object>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_07e5;
			}
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0548;
			}
		}
		Action action2 = OnMapGenerated;
		Delegate obj6 = Delegate.Remove(MapGenerationController.A_GenerationComplete, action2);
		if ((object)obj6 == null)
		{
			MapGenerationController.A_GenerationComplete = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)MapGenerationController.A_GenerationComplete;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0795;
			}
			MapGenerationController.A_GenerationComplete = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num2 = (nint)MapGenerationController.A_GenerationComplete;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_07a5;
			}
		}
		Action<string> value2 = OnInteractableStatusUpdate;
		Delegate obj9 = Delegate.Remove(InteractablesStatus.A_InteractableUsed, value2);
		if ((object)obj9 == null)
		{
			InteractablesStatus.A_InteractableUsed = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action3 = default(Action<string>);
			bool flag6 = action3 == null;
			num2 = (nint)typeof(Action<string>);
			obj2 = obj9;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_0615;
			}
			InteractablesStatus.A_InteractableUsed = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag7 = obj10 == null;
			num = (nint)typeof(Action<string>);
			obj2 = obj9;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_0625;
			}
		}
		Action<string> value3 = OnInteractableSpawned;
		Delegate obj11 = Delegate.Remove(InteractablesStatus.A_InteractableSpawned, value3);
		if ((object)obj11 == null)
		{
			InteractablesStatus.A_InteractableSpawned = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string> action4 = default(Action<string>);
			bool flag8 = action4 == null;
			num = (nint)typeof(Action<string>);
			obj2 = obj11;
			obj3 = 0;
			obj4 = null;
			if (flag8)
			{
				goto IL_063d;
			}
			InteractablesStatus.A_InteractableSpawned = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag9 = obj12 == null;
			num = (nint)typeof(Action<string>);
			obj2 = obj11;
			obj3 = 0;
			obj4 = null;
			if (flag9)
			{
				goto IL_064d;
			}
		}
		num = (nint)GameManager.A_DungeonStarted;
		Action action5 = Refresh;
		Delegate obj13 = Delegate.Remove(GameManager.A_DungeonStarted, action5);
		if ((object)obj13 == null)
		{
			GameManager.A_DungeonStarted = null;
		}
		else
		{
			bool flag10 = (object)obj13.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj13;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj13;
			nint num5 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_07b5;
			}
			GameManager.A_DungeonStarted = (Action)obj14;
			bool flag12 = (object)obj13.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag12)
			{
				obj15 = obj13;
			}
			bool flag13 = (object)obj15 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj13;
			nint num6 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_07c5;
			}
		}
		num = (nint)GameManager.A_DungeonEnded;
		Action action6 = Refresh;
		Delegate obj16 = Delegate.Remove(GameManager.A_DungeonEnded, action6);
		if ((object)obj16 == null)
		{
			GameManager.A_DungeonEnded = null;
			return;
		}
		bool flag14 = (object)obj16.GetType() != typeof(Action);
		Delegate obj17 = null;
		if (!flag14)
		{
			obj17 = obj16;
		}
		bool flag15 = (object)obj17 == null;
		obj2 = action6;
		obj3 = 0;
		obj4 = obj16;
		nint num7 = (nint)typeof(Action);
		if (flag15)
		{
			goto IL_07d5;
		}
		GameManager.A_DungeonEnded = (Action)obj17;
		bool flag16 = (object)obj16.GetType() != typeof(Action);
		Delegate obj18 = null;
		if (!flag16)
		{
			obj18 = obj16;
		}
		bool flag17 = (object)obj18 == null;
		obj2 = action6;
		obj3 = 0;
		obj4 = obj16;
		nint num8 = (nint)typeof(Action);
		if (!flag17)
		{
			return;
		}
		goto IL_07e5;
		IL_07b5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_064d;
		IL_064d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_063d;
		IL_063d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0625;
		IL_07c5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07b5;
		IL_07a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0795;
		IL_0615:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07a5;
		IL_0795:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0548;
		IL_0625:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0615;
		IL_0548:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_07e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07d5;
		IL_07d5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07c5;
	}

	private void Start()
	{
		CheckVisible();
	}

	private void OnInteractableSpawned(string debugName)
	{
		ticksUntilInit = 5;
	}

	private void FixedUpdate()
	{
		//IL_008c: Expected O, but got I4
		//IL_0072: Expected I4, but got I8
		bool flag = ticksUntilInit == 0;
		if (ticksUntilInit > 0)
		{
			int num = ticksUntilInit - 1;
			ticksUntilInit = num;
			flag = ticksUntilInit == 0;
		}
		object obj = !flag;
		if (obj == null)
		{
			ticksUntilInit = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 29 Invalid \"Jump target not found in method: 0x180526B40\"");
		}
	}

	private void OnMapGenerated()
	{
		CheckVisible();
		Refresh();
	}

	private void Init()
	{
		//IL_04bd: Expected I, but got O
		//IL_020f: Expected I, but got O
		Component component = default(Component);
		if (entries != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			while (enumerator.MoveNext())
			{
				if ((object)component != null)
				{
					GameObject obj = component.gameObject;
					UnityEngine.Object.Destroy(obj);
					continue;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		if ((object)prefab != null)
		{
			prefab.SetActive(value: true);
			List<ShrineInformationPrefab> list = new List<ShrineInformationPrefab>();
			entries = list;
			List<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>> list2 = (List<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>>)(object)new List<KeyValuePair<object, object>>((IEnumerable<KeyValuePair<object, object>>)InteractablesStatus.interactablesByName);
			Comparison<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>> comparison = _003C_003Ec._003C_003E9__10_0;
			if (_003C_003Ec._003C_003E9__10_0 == null)
			{
				Comparison<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>> comparison2 = (_003C_003Ec._003C_003E9__10_0 = (KeyValuePair<string, InteractablesStatus.InteractableStatusContainer> a, KeyValuePair<string, InteractablesStatus.InteractableStatusContainer> b) => string.Compare((string)a, (string)b, StringComparison.Ordinal));
				nint num = unchecked((nint)null);
				comparison = comparison2;
			}
			if (list2 != null)
			{
				list2.Sort(comparison);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126FB0");
				nint num2 = 0;
				List<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>>.Enumerator enumerator2 = default(List<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>>.Enumerator);
				InteractablesStatus.InteractableStatusContainer container = default(InteractablesStatus.InteractableStatusContainer);
				while (enumerator2.MoveNext())
				{
					bool flag = (object)prefab == null;
					List<object> list3 = (List<object>)(object)prefab;
					if (!flag)
					{
						Transform transform = prefab.transform;
						bool flag2 = (object)transform == null;
						list3 = (List<object>)(object)prefab;
						if (!flag2)
						{
							Transform transform2 = transform.parent;
							GameObject gameObject = UnityEngine.Object.Instantiate(prefab, transform2);
							bool flag3 = (object)gameObject == null;
							list3 = (List<object>)(object)prefab;
							if (!flag3)
							{
								ShrineInformationPrefab component2 = gameObject.GetComponent<ShrineInformationPrefab>();
								bool flag4 = (object)component2 == null;
								list3 = (List<object>)(object)gameObject;
								if (!flag4)
								{
									component2.debugName = (string)(object)component;
									component2.container = container;
									list3 = (List<object>)(object)component2.t_name;
									if ((object)component2.t_name != null)
									{
										nint num3 = (nint)list3;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v890 @ rax_v35 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+558] (should have been resolved before IL gen)");
										component2.Refresh();
										list3 = (List<object>)(object)entries;
										if (entries != null)
										{
											int version = list3._version + 1;
											list3._version = version;
											object[] items = list3._items;
											if (list3._items != null)
											{
												num2 = list3._size;
												if (list3._size >= items.Length)
												{
													((List<object>)(object)entries).AddWithResize((object)component2);
													nint num = 0;
													num2 = 0;
													continue;
												}
												int size = list3._size + 1;
												list3._size = size;
												if (list3._size < items.Length)
												{
													items[num2] = component2;
													nint num = 0;
													continue;
												}
												throw new IndexOutOfRangeException();
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
					throw new NullReferenceException();
				}
				enumerator2.Dispose();
				if ((object)prefab != null)
				{
					prefab.SetActive(value: false);
					Refresh();
					Invoke("Rebuild", 0.1f);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Rebuild()
	{
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
	}

	private void OnInteractableStatusUpdate(string name)
	{
		Refresh();
	}

	private void Refresh()
	{
		GameObject gameObject = parent.gameObject;
		if (!gameObject.activeSelf || entries == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		ShrineInformationPrefab shrineInformationPrefab = default(ShrineInformationPrefab);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)shrineInformationPrefab == null)
				{
					break;
				}
				shrineInformationPrefab.Refresh();
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			Transform root = base.transform;
			UiUtility.RebuildUi(root);
			return;
		}
		throw new NullReferenceException();
	}

	private void CheckVisible()
	{
		//IL_008a: Expected O, but got I4
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			GameObject gameObject = parent.gameObject;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			object obj = cfGameSettings.debug_shrines - 1;
			bool active = obj == null;
			gameObject.SetActive(active);
			GameObject gameObject2 = parent.gameObject;
			if (gameObject2.activeSelf)
			{
				Refresh();
			}
		}
	}

	private void OnSettingUpdate(string name, object oldVal, object newVal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F05]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (name == "debug_shrines")
		{
			CheckVisible();
		}
	}
}
