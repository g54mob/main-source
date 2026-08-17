using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors;

public class NetStats : MonoBehaviour
{
	public KeyCode toggleKey;

	private static NetStats _instance;

	private bool display;

	private bool registeredOnDisconnected;

	private const int PacketsGraph = 1;

	private const int BandwidthGraph = 2;

	private const int UpdatesGraph = 3;

	private const int EnemyCountGraph = 4;

	private const int PingGraph = 5;

	public static NetStats Instance => _instance;

	public void Toggle()
	{
		bool flag = !display;
		display = flag;
		if (~(display ? 1u : 0u) == 0)
		{
			RemoveGraphs();
		}
	}

	private void Start()
	{
		_instance = this;
		DebugGUI instance = DebugGUI.Instance;
		instance.isOnRight = false;
	}

	private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
	{
		if (display)
		{
			display = false;
			RemoveGraphs();
		}
	}

	private void RegisterOnDisconnectedEvent()
	{
		//IL_0034: Expected O, but got I
		//IL_0067: Expected O, but got I
		if (!registeredOnDisconnected)
		{
			registeredOnDisconnected = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v4+F0]");
			object obj = 0;
			UnityAction<CoherenceBridge, ConnectionCloseReason> action = OnDisconnected;
			UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<CoherenceBridge, ConnectionCloseReason>.GetDelegate(action);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rsi_v3+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
			_ = 1;
		}
	}

	private void CheckDisplayToggle()
	{
		//IL_0053: Expected O, but got I4
		object obj = Input.GetKeyDownInt(toggleKey);
		if (obj != null)
		{
			bool flag = !display;
			display = flag;
			if (~(display ? 1u : 0u) == 0)
			{
				RemoveGraphs();
			}
		}
	}

	private unsafe void DrawGraphs()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0020: Expected I, but got O
		//IL_01ad: Expected O, but got I
		//IL_01fc: Expected O, but got Ref
		//IL_022c: Invalid comparison between I4 and F4
		//IL_0277: Expected F4, but got I4
		//IL_028f: Expected O, but got Ref
		//IL_0364: Expected O, but got I4
		//IL_038d: Expected O, but got I4
		//IL_04ae: Invalid comparison between I4 and F4
		//IL_0356: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = (nint)typeof(CoherenceBridgeStore);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v5 (Il2CppClass<Coherence.Toolkit.CoherenceBridgeStore>)+B8]");
		nint num2 = 0;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496630");
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496630");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120B0]");
		_ = 0;
		int graph = default(int);
		Color color = default(Color);
		float value = default(float);
		Graph("pIN", "Packets IN", 0f, 10f, graph, color, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12430]");
		_ = 0;
		Graph("pOUT", "Packets OUT", 0f, 10f, graph, color, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm10,8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,rax\"");
		Graph("ingress", "Ingress", 0f, 1300f, graph, color, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12430]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,rax\"");
		Graph("egress", "Egress", 0f, 1300f, graph, color, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A120B0]");
		_ = 0;
		Graph("updatesIn", "Updates IN", 0f, 100f, graph, color, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v15+60]");
		object obj3 = (nint)0 >> 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12430]");
		_ = 0;
		Graph("updatesOut", "Updates OUT", 0f, 100f, graph, color, value);
		CoherenceBridge masterBridge3 = CoherenceBridgeStore.masterBridge;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800045A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
		float num3 = 0f / 300f;
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = num3 * -1f;
		float num5 = num3 * 0f;
		float num6 = num3 * 0f;
		float num7 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FC0]");
		float num8 = num7 + 0f;
		object obj5 = default(object);
		float num9 = num4 + (float)obj5;
		float num10 = num5 + (float)obj5;
		float num11 = num6 + (float)obj5;
		CoherenceBridge masterBridge4 = CoherenceBridgeStore.masterBridge;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800045A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
		_ = 0;
		Graph("ping", "Ping", 0f, 300f, graph, color, value);
		GameManager core = GM.Core;
		object obj7;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
				_ = 0;
				_ = spawnedEnemies._size;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				obj7 = 0;
				goto IL_0478;
			}
		}
		obj7 = 0;
		goto IL_0478;
		IL_0478:
		object obj9;
		if (obj7 != null)
		{
			object obj8 = obj7 >> 32;
			obj9 = obj8;
		}
		else
		{
			obj9 = 0;
		}
		float num12 = (float)obj9 / 300f;
		if (0f > num12 || num12 > 1f)
		{
		}
		Graph("enemyCount", "Enemy Count", 0f, 1000f, graph, color, value);
	}

	private static void RemoveGraphs()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3BF1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance = DebugGUI.Instance;
			instance.InstanceRemoveGraph((object)"pIN");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance2 = DebugGUI.Instance;
			instance2.InstanceRemoveGraph((object)"pOUT");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance3 = DebugGUI.Instance;
			instance3.InstanceRemoveGraph((object)"ingress");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance4 = DebugGUI.Instance;
			instance4.InstanceRemoveGraph((object)"egress");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance5 = DebugGUI.Instance;
			instance5.InstanceRemoveGraph((object)"updatesIn");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance6 = DebugGUI.Instance;
			instance6.InstanceRemoveGraph((object)"updatesOut");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance7 = DebugGUI.Instance;
			instance7.InstanceRemoveGraph((object)"ping");
		}
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance8 = DebugGUI.Instance;
			instance8.InstanceRemoveGraph((object)"enemyCount");
		}
	}

	private static void Graph(string key, string label, float min, float max, int graph, Color color, float value)
	{
		if (DebugGUI.GraphsEnabled)
		{
			DebugGUI instance = DebugGUI.Instance;
			int num = instance.graphDictionary.FindEntry((object)key);
			if (instance.graphDictionary != null)
			{
				goto IL_0096;
			}
		}
		int num2 = default(int);
		Color color2 = default(Color);
		bool autoScale = default(bool);
		DebugGUI.SetGraphProperties(key, label, min, max, num2, color2, autoScale);
		goto IL_0096;
		IL_0096:
		float val = default(float);
		DebugGUI.Graph(key, val);
	}

	public NetStats()
	{
		//IL_0020: Expected I, but got O
		toggleKey = KeyCode.LeftControl;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
