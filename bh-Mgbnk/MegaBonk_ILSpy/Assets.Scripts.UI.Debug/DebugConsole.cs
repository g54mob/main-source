using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Debug;

public class DebugConsole : MonoBehaviour
{
	public TextMeshProUGUI textField;

	public TextMeshProUGUI suggestionText;

	public TextMeshProUGUI inputFieldText;

	public TMP_InputField inputField;

	public ScrollRect scrollRect;

	public Transform suggestionParent;

	public GameObject suggestionPrefab;

	private List<CommandSuggestion> suggestionPrefabs;

	private List<DebugCommandBase> suggestions;

	private int suggestionIndex;

	public List<object> commandList;

	public static DebugConsole Instance;

	private bool isTyping;

	public GameObject consoleTransform;

	private bool oldPauseState;

	private bool movedIndexThisFrame;

	private int nSuggestions;

	private void OnEnable()
	{
		scrollRect.verticalNormalizedPosition = 0f;
	}

	private void Start()
	{
		if (Instance == this)
		{
			scrollRect.verticalNormalizedPosition = 0f;
			consoleTransform.SetActive(value: true);
			consoleTransform.SetActive(value: false);
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			List<object> list = new List<object>();
			commandList = list;
			Action action = CommandImplementation.Help;
			Type commandType = default(Type);
			Action command = default(Action);
			DebugCommand item = new DebugCommand("help", "List all commands", "", commandType, command);
			commandList.Add(item);
			Action action2 = CommandImplementation.GetSeed;
			DebugCommand item2 = new DebugCommand("seed", "Get the current map seed and copy to clipboard.", "", commandType, command);
			commandList.Add(item2);
			Action<int> action3 = CommandImplementation.SetSeedCrypt;
			DebugCommand<int> item3 = new DebugCommand<int>("set_seed_crypt", "Set the seed of crypt generation. CANNOT unlock ghost skins, challenges, Pot or Snek if using this. Use 0 (default) to get random generation.", "set_seed_crypt <seed>", commandType, (Action<int>)(object)command);
			commandList.Add(item3);
			Action<float> action4 = CommandImplementation.SetResetTime;
			DebugCommand<float> item4 = new DebugCommand<float>("reset_time", "Set how fast the quick reset should circle should fill (0.2 - 1)", "reset_time <time>", commandType, (Action<float>)(object)command);
			commandList.Add(item4);
			List<DebugCommandBase> list2 = new List<DebugCommandBase>();
			suggestions = list2;
			List<CommandSuggestion> list3 = new List<CommandSuggestion>();
			suggestionPrefabs = list3;
		}
		else
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
	}

	private void Update()
	{
		//IL_0221: Expected I4, but got I8
		if (Input.GetKeyDownInt(KeyCode.F10) && !LoadingScreen.isLoading)
		{
			if (UiManager.Instance != null)
			{
				UiManager instance = UiManager.Instance;
				if (!instance.pause.IsPaused())
				{
					goto IL_011d;
				}
			}
			bool activeInHierarchy = consoleTransform.activeInHierarchy;
			bool active = (byte)((activeInHierarchy ? 1u : 0u) ^ 1u) != 0;
			consoleTransform.SetActive(active);
			StopTyping();
			isTyping = true;
			inputField.Select();
			TMP_InputField tMP_InputField = inputField;
			GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
			gameObject.SetActive(value: false);
		}
		goto IL_011d;
		IL_011d:
		if (consoleTransform.activeInHierarchy)
		{
			movedIndexThisFrame = false;
			if (Input.GetKeyDownInt(KeyCode.Return))
			{
				HandleInput();
			}
			if (Input.GetKeyInt(KeyCode.Tab))
			{
				DoAutoComplete();
			}
			if (Input.GetKeyDownInt(KeyCode.DownArrow))
			{
				MoveSelectionIndex(1);
			}
			if (Input.GetKeyDownInt(KeyCode.UpArrow))
			{
				MoveSelectionIndex(-1);
			}
		}
	}

	private void CheckToggle()
	{
		if (!Input.GetKeyDownInt(KeyCode.F10) || LoadingScreen.isLoading)
		{
			return;
		}
		if (UiManager.Instance != null)
		{
			UiManager instance = UiManager.Instance;
			if (!instance.pause.IsPaused())
			{
				return;
			}
		}
		bool activeInHierarchy = consoleTransform.activeInHierarchy;
		bool active = (byte)((activeInHierarchy ? 1u : 0u) ^ 1u) != 0;
		consoleTransform.SetActive(active);
		StopTyping();
		isTyping = true;
		inputField.Select();
		TMP_InputField tMP_InputField = inputField;
		GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
		gameObject.SetActive(value: false);
	}

	private void CheckInput()
	{
		//IL_0104: Expected I4, but got I8
		if (consoleTransform.activeInHierarchy)
		{
			movedIndexThisFrame = false;
			if (Input.GetKeyDownInt(KeyCode.Return))
			{
				HandleInput();
			}
			if (Input.GetKeyInt(KeyCode.Tab))
			{
				DoAutoComplete();
			}
			if (Input.GetKeyDownInt(KeyCode.DownArrow))
			{
				MoveSelectionIndex(1);
			}
			if (Input.GetKeyDownInt(KeyCode.UpArrow))
			{
				MoveSelectionIndex(-1);
			}
		}
	}

	private void StartTyping()
	{
		isTyping = true;
		inputField.Select();
		TMP_InputField tMP_InputField = inputField;
		GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
		gameObject.SetActive(value: false);
	}

	private void StopTyping()
	{
		isTyping = false;
		inputField.text = "";
		inputField.ReleaseSelection();
		EventSystem current = EventSystem.current;
		current.SetSelectedGameObject(null);
		TMP_InputField tMP_InputField = inputField;
		GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
		gameObject.SetActive(value: true);
	}

	public bool IsActive()
	{
		//IL_0041: Expected I4, but got O
		if ((object)consoleTransform != null)
		{
			return consoleTransform.activeInHierarchy;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void Toggle()
	{
		if (LoadingScreen.isLoading)
		{
			return;
		}
		if (UiManager.Instance != null)
		{
			UiManager instance = UiManager.Instance;
			if (!instance.pause.IsPaused())
			{
				return;
			}
		}
		bool activeInHierarchy = consoleTransform.activeInHierarchy;
		bool active = (byte)((activeInHierarchy ? 1u : 0u) ^ 1u) != 0;
		consoleTransform.SetActive(active);
		StopTyping();
		isTyping = true;
		inputField.Select();
		TMP_InputField tMP_InputField = inputField;
		GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
		gameObject.SetActive(value: false);
	}

	public void HandleInput()
	{
		//IL_00c1: Expected O, but got I4
		//IL_00c6: Expected I, but got O
		//IL_0132: Expected I, but got O
		//IL_0140: Expected I, but got O
		//IL_0150: Expected O, but got I
		//IL_01d0: Expected O, but got I4
		//IL_018c: Expected O, but got I
		//IL_020f: Expected O, but got I
		//IL_01c2: Expected O, but got I4
		//IL_0294: Expected I, but got O
		//IL_02a2: Expected I, but got O
		//IL_02b2: Expected O, but got I
		//IL_0332: Expected O, but got I4
		//IL_02ee: Expected O, but got I
		//IL_0394: Expected I, but got O
		//IL_03a2: Expected I, but got O
		//IL_03b2: Expected O, but got I
		//IL_0324: Expected O, but got I4
		//IL_0432: Expected O, but got I4
		//IL_10a6: Expected I, but got O
		//IL_10b4: Expected I, but got O
		//IL_10c4: Expected O, but got I
		//IL_03ee: Expected O, but got I
		//IL_0494: Expected I, but got O
		//IL_04a2: Expected I, but got O
		//IL_04b2: Expected O, but got I
		//IL_1100: Expected O, but got I
		//IL_0424: Expected O, but got I4
		//IL_0532: Expected O, but got I4
		//IL_04ee: Expected O, but got I
		//IL_113d: Expected O, but got I
		//IL_1153: Unknown result type (might be due to invalid IL or missing references)
		//IL_1158: Expected O, but got Unknown
		//IL_1177: Expected I, but got O
		//IL_0f81: Expected I, but got O
		//IL_0f8f: Expected I, but got O
		//IL_0f9f: Expected O, but got I
		//IL_0594: Expected I, but got O
		//IL_05a2: Expected I, but got O
		//IL_05b2: Expected O, but got I
		//IL_14f5: Expected O, but got I4
		//IL_14fd: Expected I, but got O
		//IL_0524: Expected O, but got I4
		//IL_0632: Expected O, but got I4
		//IL_118d: Expected I, but got O
		//IL_0fdb: Expected O, but got I
		//IL_0e40: Expected I, but got O
		//IL_0e4e: Expected I, but got O
		//IL_0e5e: Expected O, but got I
		//IL_05ee: Expected O, but got I
		//IL_0694: Expected I, but got O
		//IL_06a2: Expected I, but got O
		//IL_06b2: Expected O, but got I
		//IL_1018: Expected F4, but got I
		//IL_1020: Expected I, but got O
		//IL_1030: Expected O, but got I
		//IL_0e9a: Expected O, but got I
		//IL_0624: Expected O, but got I4
		//IL_0732: Expected O, but got I4
		//IL_1074: Expected O, but got I4
		//IL_06ee: Expected O, but got I
		//IL_1066: Expected O, but got I4
		//IL_0ed7: Expected O, but got I
		//IL_0eef: Expected O, but got I
		//IL_0d1b: Expected I, but got O
		//IL_0d29: Expected I, but got O
		//IL_0d39: Expected O, but got I
		//IL_0794: Expected I, but got O
		//IL_07a2: Expected I, but got O
		//IL_07b2: Expected O, but got I
		//IL_16f0: Expected O, but got I4
		//IL_0f33: Expected O, but got I4
		//IL_0724: Expected O, but got I4
		//IL_0832: Expected O, but got I4
		//IL_14b2: Expected I, but got O
		//IL_0f25: Expected O, but got I4
		//IL_0d75: Expected O, but got I
		//IL_07ee: Expected O, but got I
		//IL_086d: Expected O, but got I4
		//IL_16c3: Expected O, but got I
		//IL_16cd: Expected O, but got I4
		//IL_16d5: Expected I, but got O
		//IL_0bda: Expected I, but got O
		//IL_0be8: Expected I, but got O
		//IL_0bf8: Expected O, but got I
		//IL_0f40: Expected I, but got O
		//IL_0db2: Expected O, but got I
		//IL_0dba: Expected I, but got O
		//IL_0dca: Expected O, but got I
		//IL_0824: Expected O, but got I4
		//IL_0883: Expected I, but got O
		//IL_0891: Expected I, but got O
		//IL_08a1: Expected O, but got I
		//IL_08c8: Expected O, but got I4
		//IL_0e0e: Expected O, but got I4
		//IL_0c34: Expected O, but got I
		//IL_0e00: Expected O, but got I4
		//IL_0a99: Expected I, but got O
		//IL_0aa7: Expected I, but got O
		//IL_0ab7: Expected O, but got I
		//IL_08e6: Expected O, but got I
		//IL_090e: Expected O, but got I4
		//IL_16a1: Expected O, but got I4
		//IL_0c71: Expected O, but got I
		//IL_0c79: Expected I, but got O
		//IL_0c89: Expected O, but got I
		//IL_0ccd: Expected O, but got I4
		//IL_0af3: Expected O, but got I
		//IL_0cbf: Expected O, but got I4
		//IL_1680: Expected O, but got I4
		//IL_0b30: Expected O, but got I
		//IL_0b38: Expected I, but got O
		//IL_0b48: Expected O, but got I
		//IL_0958: Expected I, but got O
		//IL_0966: Expected I, but got O
		//IL_0976: Expected O, but got I
		//IL_0b8c: Expected O, but got I4
		//IL_0b7e: Expected O, but got I4
		//IL_09b2: Expected O, but got I
		//IL_165f: Expected O, but got I4
		//IL_09ef: Expected O, but got I
		//IL_09f7: Expected I, but got O
		//IL_0a07: Expected O, but got I
		//IL_0a4b: Expected O, but got I4
		//IL_0a3d: Expected O, but got I4
		//IL_163e: Expected O, but got I4
		TMP_InputField tMP_InputField = inputField;
		StopTyping();
		isTyping = true;
		inputField.Select();
		TMP_InputField tMP_InputField2 = inputField;
		GameObject gameObject = tMP_InputField2.m_Placeholder.gameObject;
		gameObject.SetActive(value: false);
		if (string.IsNullOrWhiteSpace(tMP_InputField.m_Text))
		{
			return;
		}
		string[] array = tMP_InputField.m_Text.Split(" ");
		AppendMessage(tMP_InputField.m_Text);
		int num = 0;
		object obj = 0;
		nint num2 = unchecked((nint)null);
		while (true)
		{
			List<object> list = commandList;
			object obj2;
			object obj6;
			object obj3;
			if (num < list._size)
			{
				obj2 = list.get_Item(num);
				if (obj2 == null)
				{
					obj3 = null;
					goto IL_01e2;
				}
				num2 = (nint)obj2;
				nint num3 = (nint)typeof(DebugCommandBase);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rdx_v121 (Il2CppClass<DebugCommandBase>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ r9_v39 (Il2CppClass<System.Object>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ rdx_v121 (Il2CppClass<DebugCommandBase>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ r9_v39 (Il2CppClass<System.Object>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1386 @ rax_v199+FFFFFFF8+v1288 @ rax_v195*8]");
					if (0 == (nint)typeof(DebugCommandBase))
					{
						obj6 = 1;
						goto IL_1323;
					}
				}
				obj6 = 0;
				goto IL_1323;
			}
			if (obj == null)
			{
				AppendMessage("Command not found");
			}
			return;
			IL_134a:
			object obj7;
			bool flag = obj7 == null;
			object obj8 = null;
			object obj9;
			if (!flag)
			{
				obj8 = obj9;
			}
			bool flag2 = obj8 != null;
			List<object> list2 = commandList;
			if (flag2)
			{
				object obj10 = commandList.get_Item(num);
				nint num5 = (nint)obj10;
				nint num6 = (nint)typeof(DebugCommand);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ r8_v78 (Il2CppClass<DebugCommand>)+130]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2095 @ rax_v188 (Il2CppClass<System.Object>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ r8_v78 (Il2CppClass<DebugCommand>)+130]");
				if (num7 < 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2095 @ rax_v188 (Il2CppClass<System.Object>)+C8]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2099 @ rcx_v129+FFFFFFF8+v2098 @ rcx_v128*8]");
				if (0 != (nint)typeof(DebugCommand))
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ r8_v78 (Il2CppClass<DebugCommand>)+130]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2099 @ rcx_v129+FFFFFFF8+v2630 @ rdx_v117*8]");
				object obj14 = 0 - typeof(DebugCommand);
				bool flag3 = obj14 == null;
				bool flag4 = !flag3;
				nint num8 = unchecked((nint)null);
				if (!flag4)
				{
					num8 = (nint)obj10;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180516660");
				obj = 1;
				num2 = (nint)obj10;
				goto IL_1511;
			}
			goto IL_0344;
			IL_0644:
			List<object> list3;
			object obj15 = list3.get_Item(num);
			List<object> list4;
			nint num9;
			nint num10;
			if (obj15 == null)
			{
				list4 = commandList;
				num9 = num10;
				goto IL_0744;
			}
			num9 = (nint)obj15;
			nint num11 = (nint)typeof(DebugCommand<ushort>);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2805 @ rdx_v79 (Il2CppClass<DebugCommand`1<System.UInt16>>)+130]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ r9_v44 (Il2CppClass<System.Object>)+130]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2805 @ rdx_v79 (Il2CppClass<DebugCommand`1<System.UInt16>>)+130]");
			object obj18;
			if (num12 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ r9_v44 (Il2CppClass<System.Object>)+C8]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2843 @ rax_v137+FFFFFFF8+v2806 @ rax_v124*8]");
				if (0 == (nint)typeof(DebugCommand<ushort>))
				{
					obj18 = 1;
					goto IL_13d2;
				}
			}
			obj18 = 0;
			goto IL_13d2;
			IL_0344:
			object obj19 = list2.get_Item(num);
			List<object> list5;
			nint num13;
			nint num14;
			if (obj19 == null)
			{
				list5 = commandList;
				num13 = num14;
				goto IL_0444;
			}
			num13 = (nint)obj19;
			nint num15 = (nint)typeof(DebugCommand<float>);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2466 @ rdx_v105 (Il2CppClass<DebugCommand`1<System.Single>>)+130]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1732 @ r9_v41 (Il2CppClass<System.Object>)+130]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2466 @ rdx_v105 (Il2CppClass<DebugCommand`1<System.Single>>)+130]");
			object obj22;
			if (num16 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1732 @ r9_v41 (Il2CppClass<System.Object>)+C8]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2501 @ rax_v182+FFFFFFF8+v2467 @ rax_v168*8]");
				if (0 == (nint)typeof(DebugCommand<float>))
				{
					obj22 = 1;
					goto IL_136c;
				}
			}
			obj22 = 0;
			goto IL_136c;
			IL_0744:
			object obj23 = list4.get_Item(num);
			List<object> list6;
			if (obj23 == null)
			{
				list6 = commandList;
				num2 = num9;
				goto IL_0844;
			}
			nint num17 = (nint)obj23;
			nint num18 = (nint)typeof(DebugCommand<short>);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2931 @ rdx_v70 (Il2CppClass<DebugCommand`1<System.Int16>>)+130]");
			object obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ r9_v48 (Il2CppClass<System.Object>)+130]");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2931 @ rdx_v70 (Il2CppClass<DebugCommand`1<System.Int16>>)+130]");
			object obj26;
			if (num19 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ r9_v48 (Il2CppClass<System.Object>)+C8]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2968 @ rax_v123+FFFFFFF8+v2932 @ rax_v110*8]");
				if (0 == (nint)typeof(DebugCommand<short>))
				{
					obj26 = 1;
					goto IL_13f4;
				}
			}
			obj26 = 0;
			goto IL_13f4;
			IL_138e:
			object obj27;
			bool flag5 = obj27 == null;
			object obj28 = null;
			object obj29;
			if (!flag5)
			{
				obj28 = obj29;
			}
			bool flag6 = obj28 != null;
			List<object> list7 = commandList;
			if (flag6)
			{
				object obj30 = commandList.get_Item(num);
				nint num20 = (nint)obj30;
				nint num21 = (nint)typeof(DebugCommand<string>);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ r8_v72 (Il2CppClass<DebugCommand`1<System.String>>)+130]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1579 @ rdx_v100 (Il2CppClass<System.Object>)+130]");
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ r8_v72 (Il2CppClass<DebugCommand`1<System.String>>)+130]");
				if (num22 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1579 @ rdx_v100 (Il2CppClass<System.Object>)+C8]");
					object obj32 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v158+FFFFFFF8+v1582 @ rax_v157*8]");
					if (0 == (nint)typeof(DebugCommand<string>))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ r8_v72 (Il2CppClass<DebugCommand`1<System.String>>)+130]");
						object obj33 = 0;
						object obj34 = obj30;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2903 @ rax_v160+C8]");
						object obj35 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2904 @ rcx_v108+FFFFFFF8+v2902 @ rdx_v101*8]");
						object obj36 = ((0 != (nint)typeof(DebugCommand<string>)) ? ((object)0) : ((object)1));
						bool flag7 = obj36 == null;
						nint num23 = unchecked((nint)null);
						if (!flag7)
						{
							num23 = (nint)obj30;
						}
						((DebugCommand<string>)num23).Invoke(array[1]);
						obj = 1;
						num2 = (nint)obj30;
						goto IL_1511;
					}
				}
				throw new NullReferenceException();
			}
			goto IL_0544;
			IL_0544:
			object obj37 = list7.get_Item(num);
			nint num24;
			if (obj37 == null)
			{
				list3 = commandList;
				num10 = num24;
				goto IL_0644;
			}
			num10 = (nint)obj37;
			nint num25 = (nint)typeof(DebugCommand<ulong>);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2688 @ rdx_v88 (Il2CppClass<DebugCommand`1<System.UInt64>>)+130]");
			object obj38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ r9_v43 (Il2CppClass<System.Object>)+130]");
			nint num26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2688 @ rdx_v88 (Il2CppClass<DebugCommand`1<System.UInt64>>)+130]");
			object obj40;
			if (num26 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ r9_v43 (Il2CppClass<System.Object>)+C8]");
				object obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2723 @ rax_v151+FFFFFFF8+v2689 @ rax_v138*8]");
				if (0 == (nint)typeof(DebugCommand<ulong>))
				{
					obj40 = 1;
					goto IL_13b0;
				}
			}
			obj40 = 0;
			goto IL_13b0;
			IL_1323:
			bool flag8 = obj6 == null;
			obj3 = null;
			if (!flag8)
			{
				obj3 = obj2;
			}
			goto IL_01e2;
			IL_1511:
			num++;
			continue;
			IL_01e2:
			string text = array[0].ToLower();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rbx_v40 (System.Object)+10]");
			string value = ((string)0).ToLower();
			if (text.Equals(value))
			{
				obj9 = commandList.get_Item(num);
				if (obj9 == null)
				{
					list2 = commandList;
					num14 = num2;
					goto IL_0344;
				}
				num14 = (nint)obj9;
				nint num27 = (nint)typeof(DebugCommand);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2364 @ rdx_v113 (Il2CppClass<DebugCommand>)+130]");
				object obj41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2024 @ r9_v40 (Il2CppClass<System.Object>)+130]");
				nint num28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2364 @ rdx_v113 (Il2CppClass<DebugCommand>)+130]");
				if (num28 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2024 @ r9_v40 (Il2CppClass<System.Object>)+C8]");
					object obj42 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2399 @ rax_v194+FFFFFFF8+v2365 @ rax_v183*8]");
					if (0 == (nint)typeof(DebugCommand))
					{
						obj7 = 1;
						goto IL_134a;
					}
				}
				obj7 = 0;
				goto IL_134a;
			}
			goto IL_1511;
			IL_13d2:
			bool flag9 = obj18 == null;
			object obj43 = null;
			if (!flag9)
			{
				obj43 = obj15;
			}
			bool flag10 = obj43 != null;
			list4 = commandList;
			if (flag10)
			{
				object obj44 = commandList.get_Item(num);
				ushort value2 = ushort.Parse(array[1]);
				nint num29 = (nint)obj44;
				nint num30 = (nint)typeof(DebugCommand<ushort>);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r8_v66 (Il2CppClass<DebugCommand`1<System.UInt16>>)+130]");
				object obj45 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ r9_v52 (Il2CppClass<System.Object>)+130]");
				nint num31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r8_v66 (Il2CppClass<DebugCommand`1<System.UInt16>>)+130]");
				if (num31 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ r9_v52 (Il2CppClass<System.Object>)+C8]");
					object obj46 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v908 @ rcx_v85+FFFFFFF8+v907 @ rcx_v84*8]");
					if (0 == (nint)typeof(DebugCommand<ushort>))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r8_v66 (Il2CppClass<DebugCommand`1<System.UInt16>>)+130]");
						object obj47 = 0;
						nint num32 = (nint)obj44;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3047 @ rax_v130 (Il2CppClass<System.Object>)+C8]");
						object obj48 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3048 @ rcx_v86+FFFFFFF8+v3046 @ rdx_v84*8]");
						object obj49 = ((0 != (nint)typeof(DebugCommand<ushort>)) ? ((object)0) : ((object)1));
						bool flag11 = obj49 == null;
						object obj50 = null;
						if (!flag11)
						{
							obj50 = obj44;
						}
						((DebugCommand<ushort>)obj50).Invoke(value2);
						obj = 1;
						num2 = 0;
						goto IL_1511;
					}
				}
				throw new NullReferenceException();
			}
			goto IL_0744;
			IL_136c:
			bool flag12 = obj22 == null;
			object obj51 = null;
			if (!flag12)
			{
				obj51 = obj19;
			}
			bool flag13 = obj51 != null;
			list5 = commandList;
			if (flag13)
			{
				object obj52 = commandList.get_Item(num);
				float num33 = float.Parse(array[1]);
				nint num34 = (nint)obj52;
				nint num35 = (nint)typeof(DebugCommand<float>);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1908 @ r8_v75 (Il2CppClass<DebugCommand`1<System.Single>>)+130]");
				object obj53 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rdx_v109 (Il2CppClass<System.Object>)+130]");
				nint num36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1908 @ r8_v75 (Il2CppClass<DebugCommand`1<System.Single>>)+130]");
				if (num36 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rdx_v109 (Il2CppClass<System.Object>)+C8]");
					object obj54 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1915 @ rax_v174+FFFFFFF8+v1914 @ rax_v173*8]");
					if (0 == (nint)typeof(DebugCommand<float>))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1908 @ r8_v75 (Il2CppClass<DebugCommand`1<System.Single>>)+130]");
						float value3 = 0f;
						nint num37 = (nint)obj52;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2792 @ rax_v175 (Il2CppClass<System.Object>)+C8]");
						object obj55 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2793 @ rcx_v119+FFFFFFF8+v2176 @ rdx_v110 (System.Single)*8]");
						object obj56 = ((0 != (nint)typeof(DebugCommand<float>)) ? ((object)0) : ((object)1));
						bool flag14 = obj56 == null;
						object obj57 = null;
						if (!flag14)
						{
							obj57 = obj52;
						}
						((DebugCommand<float>)obj57).Invoke(value3);
						obj = 1;
						num2 = 0;
						goto IL_1511;
					}
				}
				throw new NullReferenceException();
			}
			goto IL_0444;
			IL_13b0:
			bool flag15 = obj40 == null;
			object obj58 = null;
			if (!flag15)
			{
				obj58 = obj37;
			}
			bool flag16 = obj58 != null;
			list3 = commandList;
			if (flag16)
			{
				object obj59 = commandList.get_Item(num);
				ulong value4 = ulong.Parse(array[1]);
				nint num38 = (nint)obj59;
				nint num39 = (nint)typeof(DebugCommand<ulong>);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ r8_v69 (Il2CppClass<DebugCommand`1<System.UInt64>>)+130]");
				object obj60 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1169 @ r9_v55 (Il2CppClass<System.Object>)+130]");
				nint num40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ r8_v69 (Il2CppClass<DebugCommand`1<System.UInt64>>)+130]");
				if (num40 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1169 @ r9_v55 (Il2CppClass<System.Object>)+C8]");
					object obj61 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1184 @ rcx_v97+FFFFFFF8+v1183 @ rcx_v96*8]");
					if (0 == (nint)typeof(DebugCommand<ulong>))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ r8_v69 (Il2CppClass<DebugCommand`1<System.UInt64>>)+130]");
						object obj62 = 0;
						nint num41 = (nint)obj59;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3025 @ rax_v144 (Il2CppClass<System.Object>)+C8]");
						object obj63 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3026 @ rcx_v98+FFFFFFF8+v3024 @ rdx_v93*8]");
						object obj64 = ((0 != (nint)typeof(DebugCommand<ulong>)) ? ((object)0) : ((object)1));
						bool flag17 = obj64 == null;
						object obj65 = null;
						if (!flag17)
						{
							obj65 = obj59;
						}
						((DebugCommand<ulong>)obj65).Invoke(value4);
						obj = 1;
						num2 = 0;
						goto IL_1511;
					}
				}
				throw new NullReferenceException();
			}
			goto IL_0644;
			IL_0444:
			obj29 = list5.get_Item(num);
			if (obj29 == null)
			{
				list7 = commandList;
				num24 = num13;
				goto IL_0544;
			}
			num24 = (nint)obj29;
			nint num42 = (nint)typeof(DebugCommand<string>);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2569 @ rdx_v97 (Il2CppClass<DebugCommand`1<System.String>>)+130]");
			object obj66 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1313 @ r9_v42 (Il2CppClass<System.Object>)+130]");
			nint num43 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2569 @ rdx_v97 (Il2CppClass<DebugCommand`1<System.String>>)+130]");
			if (num43 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1313 @ r9_v42 (Il2CppClass<System.Object>)+C8]");
				object obj67 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2604 @ rax_v167+FFFFFFF8+v2570 @ rax_v152*8]");
				if (0 == (nint)typeof(DebugCommand<string>))
				{
					obj27 = 1;
					goto IL_138e;
				}
			}
			obj27 = 0;
			goto IL_138e;
			IL_13f4:
			bool flag18 = obj26 == null;
			object obj68 = null;
			if (!flag18)
			{
				obj68 = obj23;
			}
			bool flag19 = obj68 != null;
			num2 = num17;
			list6 = commandList;
			if (flag19)
			{
				object obj69 = commandList.get_Item(num);
				short value5 = short.Parse(array[1]);
				nint num44 = (nint)obj69;
				nint num45 = (nint)typeof(DebugCommand<short>);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ r8_v63 (Il2CppClass<DebugCommand`1<System.Int16>>)+130]");
				object obj70 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r9_v49 (Il2CppClass<System.Object>)+130]");
				nint num46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ r8_v63 (Il2CppClass<DebugCommand`1<System.Int16>>)+130]");
				if (num46 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r9_v49 (Il2CppClass<System.Object>)+C8]");
					object obj71 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rcx_v73+FFFFFFF8+v550 @ rcx_v72*8]");
					if (0 == (nint)typeof(DebugCommand<short>))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ r8_v63 (Il2CppClass<DebugCommand`1<System.Int16>>)+130]");
						object obj72 = 0;
						nint num47 = (nint)obj69;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3069 @ rax_v116 (Il2CppClass<System.Object>)+C8]");
						object obj73 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3070 @ rcx_v74+FFFFFFF8+v3068 @ rdx_v75*8]");
						object obj74 = ((0 != (nint)typeof(DebugCommand<short>)) ? ((object)0) : ((object)1));
						bool flag20 = obj74 == null;
						object obj75 = null;
						if (!flag20)
						{
							obj75 = obj69;
						}
						((DebugCommand<short>)obj75).Invoke(value5);
						obj = 1;
						num2 = 0;
						goto IL_1511;
					}
				}
				throw new NullReferenceException();
			}
			goto IL_0844;
			IL_0844:
			object obj76 = list6.get_Item(num);
			bool flag21 = obj76 == null;
			obj = 1;
			if (!flag21)
			{
				nint num48 = (nint)obj76;
				nint num49 = (nint)typeof(DebugCommand<int>);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rdx_v64 (Il2CppClass<DebugCommand`1<System.Int32>>)+130]");
				object obj77 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ r8_v58 (Il2CppClass<System.Object>)+130]");
				nint num50 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rdx_v64 (Il2CppClass<DebugCommand`1<System.Int32>>)+130]");
				bool flag22 = num50 < 0;
				obj = 1;
				if (!flag22)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ r8_v58 (Il2CppClass<System.Object>)+C8]");
					object obj78 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v102+FFFFFFF8+v2180 @ rax_v101*8]");
					bool flag23 = 0 != (nint)typeof(DebugCommand<int>);
					obj = 1;
					if (!flag23)
					{
						object obj79 = commandList.get_Item(num);
						int value6 = int.Parse(array[1]);
						nint num51 = (nint)obj79;
						nint num52 = (nint)typeof(DebugCommand<int>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ r8_v60 (Il2CppClass<DebugCommand`1<System.Int32>>)+130]");
						object obj80 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ r9_v46 (Il2CppClass<System.Object>)+130]");
						nint num53 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ r8_v60 (Il2CppClass<DebugCommand`1<System.Int32>>)+130]");
						if (num53 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ r9_v46 (Il2CppClass<System.Object>)+C8]");
							object obj81 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rcx_v64+FFFFFFF8+v325 @ rcx_v63*8]");
							if (0 == (nint)typeof(DebugCommand<int>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ r8_v60 (Il2CppClass<DebugCommand`1<System.Int32>>)+130]");
								object obj82 = 0;
								nint num54 = (nint)obj79;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3084 @ rax_v105 (Il2CppClass<System.Object>)+C8]");
								object obj83 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3085 @ rcx_v65+FFFFFFF8+v3083 @ rdx_v68*8]");
								object obj84 = ((0 != (nint)typeof(DebugCommand<int>)) ? ((object)0) : ((object)1));
								bool flag24 = obj84 == null;
								object obj85 = null;
								if (!flag24)
								{
									obj85 = obj79;
								}
								((DebugCommand<int>)obj85).Invoke(value6);
								obj = 1;
								num2 = 0;
								goto IL_1511;
							}
						}
						throw new NullReferenceException();
					}
				}
			}
			goto IL_1511;
		}
		throw new NullReferenceException();
	}

	public void AppendMessage(string msg)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172569]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		scrollRect.verticalNormalizedPosition = 0f;
		string text = textField.text;
		string text2 = text + "\n" + msg;
		textField.text = text2;
		string text3 = textField.text;
		if (text3._stringLength > 5000)
		{
			string text4 = textField.text;
			string text5 = text4.Substring(0, 2500);
			textField.text = text5;
		}
		suggestionText.text = "";
		inputField.text = "";
		inputField.caretPosition = 0;
	}

	public unsafe void TryAutoComplete()
	{
		//IL_00b2: Expected I, but got O
		//IL_00ba: Expected I, but got O
		//IL_00ca: Expected O, but got I
		//IL_00fe: Expected I, but got O
		//IL_0494: Expected I4, but got I8
		//IL_011c: Expected O, but got I
		//IL_0159: Expected I, but got O
		//IL_016f: Expected I, but got O
		//IL_024d: Expected I, but got O
		//IL_0562: Expected O, but got I4
		//IL_0287: Expected O, but got I4
		//IL_028c: Expected I, but got O
		//IL_02b2: Expected O, but got I4
		if (movedIndexThisFrame)
		{
			return;
		}
		TMP_InputField tMP_InputField = inputField;
		string text = tMP_InputField.m_Text.ToLower();
		List<DebugCommandBase> list = new List<DebugCommandBase>();
		suggestions = list;
		Component component = default(Component);
		int num7;
		if (!string.IsNullOrWhiteSpace(text))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			nint num = 0;
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			while (enumerator.MoveNext())
			{
				DebugCommandBase debugCommandBase;
				nint num2;
				if ((object)component == null)
				{
					debugCommandBase = null;
					num2 = 0;
					goto IL_017d;
				}
				nint num3 = (nint)typeof(DebugCommandBase);
				nint num4 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rdx_v40 (Il2CppClass<DebugCommandBase>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ r8_v19 (Il2CppMethodInfo)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rdx_v40 (Il2CppClass<DebugCommandBase>)+130]");
				bool flag = num5 < 0;
				DebugCommandBase debugCommandBase2 = (DebugCommandBase)(object)component;
				nint num6 = (nint)typeof(DebugCommandBase);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ r8_v19 (Il2CppMethodInfo)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v63+FFFFFFF8+v604 @ rax_v62*8]");
					bool flag2 = 0 != (nint)typeof(DebugCommandBase);
					debugCommandBase = (DebugCommandBase)(object)component;
					num = num4;
					num2 = (nint)typeof(DebugCommandBase);
					debugCommandBase2 = (DebugCommandBase)(object)component;
					num6 = (nint)typeof(DebugCommandBase);
					if (!flag2)
					{
						goto IL_017d;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				throw debugCommandBase2;
				IL_017d:
				if (text != null)
				{
					if (debugCommandBase != null)
					{
						string text2 = debugCommandBase._003CcommandId_003Ek__BackingField;
						if (debugCommandBase._003CcommandId_003Ek__BackingField != null)
						{
							if (text._stringLength <= text2._stringLength)
							{
								string text3 = debugCommandBase._003CcommandId_003Ek__BackingField.Substring(0, text._stringLength);
								bool flag3 = text3 == null;
								num = text._stringLength;
								num2 = unchecked((nint)null);
								object obj3;
								if (flag3)
								{
									obj3 = 0;
									throw new NullReferenceException();
								}
								string text4 = text3.ToLower();
								bool flag4 = text4 == text;
								obj3 = 0;
								num = unchecked((nint)null);
								if (flag4)
								{
									suggestions.Add(debugCommandBase);
									obj3 = 0;
									num = 0;
								}
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				debugCommandBase2 = debugCommandBase;
				num4 = num;
				num6 = num2;
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			num7 = 0;
		}
		else
		{
			num7 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		while (true)
		{
			if (enumerator2.MoveNext())
			{
				if ((object)component != null)
				{
					GameObject gameObject = component.gameObject;
					if ((object)gameObject == null)
					{
						break;
					}
					gameObject.SetActive(value: false);
					continue;
				}
				throw new NullReferenceException();
			}
			((List<CommandSuggestion>.Enumerator*)(&enumerator2))->Dispose();
			nSuggestions = num7;
			List<DebugCommandBase> list2 = suggestions;
			for (int num8 = num7; num8 < list2._size; num8 = num7)
			{
				List<CommandSuggestion> list3 = suggestionPrefabs;
				if (num7 >= list3._size)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(suggestionPrefab, suggestionParent);
					CommandSuggestion component2 = gameObject2.GetComponent<CommandSuggestion>();
					list3.Add(component2);
				}
				int num9 = nSuggestions + 1;
				nSuggestions = num9;
				CommandSuggestion commandSuggestion = suggestionPrefabs.get_Item(num7);
				DebugCommandBase command = suggestions.get_Item(num7);
				commandSuggestion.SetCommand(command);
				GameObject gameObject3 = commandSuggestion.gameObject;
				gameObject3.SetActive(value: true);
				num7++;
				list2 = suggestions;
			}
			suggestionIndex = -1;
			return;
		}
		throw new NullReferenceException();
	}

	private void MoveSelectionIndex(int dir)
	{
		//IL_004e: Expected I4, but got I8
		movedIndexThisFrame = true;
		int num = dir + suggestionIndex;
		if (num >= -1)
		{
			int num2 = nSuggestions - 1;
			if (num > num2)
			{
				num = num2;
			}
		}
		else
		{
			num = -1;
		}
		suggestionIndex = num;
		if (suggestionIndex != -1)
		{
			CommandSuggestion commandSuggestion = suggestionPrefabs.get_Item(suggestionIndex);
			commandSuggestion.Select(t: false);
		}
		if (suggestionIndex != -1)
		{
			CommandSuggestion commandSuggestion2 = suggestionPrefabs.get_Item(suggestionIndex);
			commandSuggestion2.Select(t: true);
			if (suggestionIndex != -1)
			{
				DebugCommandBase debugCommandBase = suggestions.get_Item(suggestionIndex);
				string text = debugCommandBase._003CcommandId_003Ek__BackingField + " ";
				inputField.text = text;
				inputField.caretPosition = text._stringLength;
			}
		}
	}

	private void DoAutoComplete()
	{
		//IL_0078: Expected I, but got O
		//IL_0080: Expected I, but got O
		//IL_0090: Expected O, but got I
		//IL_00bc: Expected I, but got O
		//IL_00da: Expected O, but got I
		//IL_010f: Expected I, but got O
		//IL_011d: Expected I, but got O
		//IL_017a: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_020f: Expected O, but got I4
		//IL_0214: Expected I, but got O
		//IL_0238: Expected I, but got O
		//IL_0245: Expected I, but got O
		//IL_02f7: Expected O, but got I4
		//IL_026a: Expected O, but got I
		//IL_038e: Expected I, but got O
		//IL_02b0: Expected I, but got O
		TMP_InputField tMP_InputField = inputField;
		string text = tMP_InputField.m_Text;
		if (string.IsNullOrWhiteSpace(tMP_InputField.m_Text))
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		nint num = 0;
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			nint num2;
			nint num4;
			nint num6;
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				num2 = 0;
				if (!flag)
				{
					nint num3 = (nint)typeof(DebugCommandBase);
					num4 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v21 (Il2CppClass<DebugCommandBase>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v5 (Il2CppMethodInfo)+130]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v21 (Il2CppClass<DebugCommandBase>)+130]");
					bool flag2 = num5 < 0;
					num6 = (nint)typeof(DebugCommandBase);
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v5 (Il2CppMethodInfo)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v34+FFFFFFF8+v282 @ rax_v33*8]");
						bool flag3 = 0 != (nint)typeof(DebugCommandBase);
						num = num4;
						num2 = (nint)typeof(DebugCommandBase);
						num6 = (nint)typeof(DebugCommandBase);
						if (!flag3)
						{
							goto IL_012b;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					throw obj;
				}
				goto IL_012b;
			}
			enumerator.Dispose();
			return;
			IL_012b:
			if (tMP_InputField.m_Text != null)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ stack_-50+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ stack_-50+10]");
					if ((nint)0 != 0)
					{
						int stringLength = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v18+10]");
						if ((nint)stringLength > (nint)0)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ stack_-50+10]");
						string text2 = ((string)0).Substring(0, text._stringLength);
						bool flag4 = text2 != tMP_InputField.m_Text;
						object obj5 = 0;
						num = unchecked((nint)null);
						if (flag4)
						{
							continue;
						}
						bool flag5 = (object)inputField == null;
						num = unchecked((nint)null);
						num2 = (nint)tMP_InputField.m_Text;
						if (!flag5)
						{
							TMP_InputField tMP_InputField2 = inputField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ stack_-50+10]");
							tMP_InputField2.text = (string)0;
							TMP_InputField tMP_InputField3 = inputField;
							bool flag6 = (object)inputField == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ stack_-50+10]");
							num2 = 0;
							if (flag6)
							{
								break;
							}
							nint num7 = (nint)tMP_InputField3.m_Text;
							TMP_InputField tMP_InputField4 = inputField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdx_v18 (Il2CppClass<DebugCommandBase>)+10]");
							tMP_InputField4.caretPosition = 0;
							enumerator.Dispose();
							return;
						}
						obj5 = 0;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			num4 = num;
			num6 = num2;
			throw new NullReferenceException();
		}
		num = unchecked((nint)null);
		throw new NullReferenceException();
	}
}
