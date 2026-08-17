using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Nody;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.UI.Connections;
using Doozy.Engine.UI.Internal;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes;

public class UINode : Node
{
	public enum NodeState
	{
		OnEnter,
		OnExit
	}

	public enum ViewAction
	{
		ShowView,
		HideView
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<UIViewCategoryName, string> _003C_003E9__26_0;

		public static Func<UIViewCategoryName, string> _003C_003E9__26_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CSortViewsList_003Eb__26_0(UIViewCategoryName x)
		{
			if (x != null)
			{
				return x.Category;
			}
			return (string)(object)new NullReferenceException();
		}

		internal string _003CSortViewsList_003Eb__26_1(UIViewCategoryName x)
		{
			if (x != null)
			{
				return x.Name;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	private List<UIViewCategoryName> m_onEnterShowViews;

	private List<UIViewCategoryName> m_onEnterHideViews;

	private List<UIViewCategoryName> m_onExitShowViews;

	private List<UIViewCategoryName> m_onExitHideViews;

	[NonSerialized]
	private bool m_timerIsActive;

	[NonSerialized]
	private double m_timerStart;

	[NonSerialized]
	private float m_timeDelay;

	[NonSerialized]
	private Socket m_activeSocketAfterTimeDelay;

	public List<UIViewCategoryName> OnEnterShowViews => m_onEnterShowViews;

	public List<UIViewCategoryName> OnEnterHideViews => m_onEnterHideViews;

	public List<UIViewCategoryName> OnExitShowViews => m_onExitShowViews;

	public List<UIViewCategoryName> OnExitHideViews => m_onExitHideViews;

	public float TimerProgress
	{
		get
		{
			//IL_002d: Expected F4, but got I4
			//IL_00a8: Invalid comparison between I4 and F4
			//IL_0061: Expected F4, but got I4
			//IL_006f: Expected O, but got F4
			float num;
			if (!m_timerIsActive)
			{
				num = 0f;
			}
			else
			{
				object obj = Time.realtimeSinceStartup;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rbx+0A8h]\"");
				num = 0f / m_timeDelay;
			}
			if (!(0f > num))
			{
				if (num > 1f)
				{
					return 1f;
				}
			}
			else
			{
				num = 0f;
			}
			return num;
		}
	}

	public override void CopyNode(Node original)
	{
		//IL_0133: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0098: Expected O, but got I
		//IL_00bd: Expected O, but got I
		//IL_00e2: Expected O, but got I
		//IL_0107: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(UINode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.UINode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.UINode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(UINode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				List<UIViewCategoryName> onEnterShowViews = UIViewCategoryNameListCopy((List<UIViewCategoryName>)0);
				m_onEnterShowViews = onEnterShowViews;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+88]");
				List<UIViewCategoryName> onEnterHideViews = UIViewCategoryNameListCopy((List<UIViewCategoryName>)0);
				m_onEnterHideViews = onEnterHideViews;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
				List<UIViewCategoryName> onExitShowViews = UIViewCategoryNameListCopy((List<UIViewCategoryName>)0);
				m_onExitShowViews = onExitShowViews;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+98]");
				List<UIViewCategoryName> onExitHideViews = UIViewCategoryNameListCopy((List<UIViewCategoryName>)0);
				m_onExitHideViews = onExitHideViews;
				return;
			}
		}
		throw new InvalidCastException();
	}

	private unsafe List<UIViewCategoryName> UIViewCategoryNameListCopy(List<UIViewCategoryName> original)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<UIViewCategoryName> result = new List<UIViewCategoryName>();
		List<UIViewCategoryName>.Enumerator enumerator = default(List<UIViewCategoryName>.Enumerator);
		if (original != null && enumerator.MoveNext())
		{
			object obj = 0;
			List<UIViewCategoryName>.Enumerator enumerator2 = (List<UIViewCategoryName>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.General;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.UINodeNodeName;
		NodySettings instance2 = NodySettings.Instance;
		base.m_width = instance2.DefaultNodeWidth;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddInputSocket(ConnectionMode.Multiple, valueType, canBeDeleted: false, canBeReordered);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType2 = default(Type);
		Socket socket2 = AddOutputSocket(ConnectionMode.Override, valueType2, canBeDeleted: true, canBeReordered);
		List<Socket> outputSockets = base.OutputSockets;
		if (outputSockets._size > 0)
		{
			Socket[] items = outputSockets._items;
			UIConnection value = UIConnection.GetValue(items[0]);
			value.Trigger = UIConnectionTrigger.ButtonClick;
			value.ButtonCategory = "General";
			value.ButtonName = "Back";
			List<Socket> outputSockets2 = base.OutputSockets;
			if (outputSockets2._size > 0)
			{
				Socket[] items2 = outputSockets2._items;
				Socket socket3 = items2[0];
				string value2 = JsonUtility.ToJson(value);
				socket3.m_value = value2;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SortShowViewsList()
	{
		if (m_onEnterShowViews == null)
		{
			List<UIViewCategoryName> onEnterShowViews = new List<UIViewCategoryName>();
			m_onEnterShowViews = onEnterShowViews;
		}
		if (m_onExitShowViews == null)
		{
			List<UIViewCategoryName> onExitShowViews = new List<UIViewCategoryName>();
			m_onExitShowViews = onExitShowViews;
		}
		List<UIViewCategoryName> onEnterShowViews2 = SortViewsList(m_onEnterShowViews);
		m_onEnterShowViews = onEnterShowViews2;
		List<UIViewCategoryName> onExitShowViews2 = SortViewsList(m_onExitShowViews);
		m_onExitShowViews = onExitShowViews2;
	}

	public void SortHideViewsList()
	{
		if (m_onEnterHideViews == null)
		{
			List<UIViewCategoryName> onEnterHideViews = new List<UIViewCategoryName>();
			m_onEnterHideViews = onEnterHideViews;
		}
		if (m_onExitHideViews == null)
		{
			List<UIViewCategoryName> onExitHideViews = new List<UIViewCategoryName>();
			m_onExitHideViews = onExitHideViews;
		}
		List<UIViewCategoryName> onEnterHideViews2 = SortViewsList(m_onEnterHideViews);
		m_onEnterHideViews = onEnterHideViews2;
		List<UIViewCategoryName> onExitHideViews2 = SortViewsList(m_onExitHideViews);
		m_onExitHideViews = onExitHideViews2;
	}

	private static List<UIViewCategoryName> SortViewsList(IEnumerable<UIViewCategoryName> list)
	{
		//IL_0054: Expected I, but got O
		//IL_00ec: Expected O, but got I
		//IL_0101: Expected O, but got I
		//IL_0117: Expected O, but got I
		//IL_0092: Expected O, but got I
		//IL_009b: Expected O, but got I4
		//IL_0144: Expected O, but got I
		//IL_01b5: Expected O, but got I
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		if (list == null)
		{
			return new List<UIViewCategoryName>();
		}
		Func<UIViewCategoryName, string> keySelector = _003C_003Ec._003C_003E9__26_0;
		if (_003C_003Ec._003C_003E9__26_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__26_0 = (UIViewCategoryName x) => (string)((x != null) ? ((object)x.Category) : ((object)new NullReferenceException())));
		}
		IOrderedEnumerable<UIViewCategoryName> orderedEnumerable = Enumerable.OrderBy(list, keySelector);
		Func<UIViewCategoryName, string> func = _003C_003Ec._003C_003E9__26_1;
		if (_003C_003Ec._003C_003E9__26_1 == null)
		{
			func = (_003C_003Ec._003C_003E9__26_1 = (UIViewCategoryName x) => (string)((x != null) ? ((object)x.Name) : ((object)new NullReferenceException())));
		}
		object obj;
		if (orderedEnumerable != null)
		{
			nint num = (nint)orderedEnumerable;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v2 (Il2CppClass<System.Linq.IOrderedEnumerable`1<Doozy.Engine.UI.Internal.UIViewCategoryName>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_00d2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v2 (Il2CppClass<System.Linq.IOrderedEnumerable`1<Doozy.Engine.UI.Internal.UIViewCategoryName>>)+B0]");
			obj = 0;
			object obj2 = 0;
			while (true)
			{
				object obj3 = obj2 + obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v5+v463 @ rax_v39*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj2++;
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v2 (Il2CppClass<System.Linq.IOrderedEnumerable`1<Doozy.Engine.UI.Internal.UIViewCategoryName>>)+12E]");
				if ((nint)obj4 < 0)
				{
					continue;
				}
				goto IL_00d2;
			}
			object obj5 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v5+8+v528 @ rdx_v17*8]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rbp_v3 (Il2CppMethodInfo)+50]");
			object obj6 = num3 + 0;
			object obj7 = obj6 << 4;
			object obj8 = obj7 + 312;
			object obj9 = obj8 + num;
			goto IL_00f1;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
		IL_00d2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rbp_v3 (Il2CppMethodInfo)+50]");
		obj = 0;
		goto IL_00f1;
		IL_00f1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rax_v18+8]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rcx_v19+53]");
		object obj11 = (nint)0 & (nint)2;
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rcx_v19+40]");
			object obj12 = 0;
			obj10 = obj12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AFEED0");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v588 @ rax_v21+8] (should have been resolved before IL gen)");
		IEnumerable<object> enumerable = default(IEnumerable<object>);
		if (enumerable != null)
		{
			return (List<UIViewCategoryName>)(object)new List<object>(enumerable);
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private void AddListeners()
	{
		Action<UIButtonMessage> callback = OnButtonMessage;
		Message.AddListener(callback);
		Action<GameEventMessage> callback2 = OnGameEventMessage;
		Message.AddListener(callback2);
	}

	private void RemoveListeners()
	{
		Action<UIButtonMessage> callback = OnButtonMessage;
		Message.RemoveListener(callback);
		Action<GameEventMessage> callback2 = OnGameEventMessage;
		Message.RemoveListener(callback2);
	}

	private void OnButtonMessage(UIButtonMessage message)
	{
		//IL_00fb: Expected O, but got I8
		//IL_0115: Expected O, but got I8
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph activeGraph2 = base.m_activeGraph;
			if (!activeGraph2.m_enabled)
			{
				return;
			}
		}
		List<Socket> outputSockets = base.OutputSockets;
		if (outputSockets == null)
		{
			return;
		}
		List<Socket> outputSockets2 = base.OutputSockets;
		if (outputSockets2._size != 0)
		{
			UIButtonBehaviorType type = message.Type;
			if (message.Type > UIButtonBehaviorType.OnRightClick)
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rbx_v5+2BDA934+v318 @ rax_v13 (Doozy.Engine.UI.UIButtonBehaviorType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v303 @ rax_v20 (should have been resolved before IL gen)");
		}
	}

	private unsafe void OnGameEventMessage(GameEventMessage message)
	{
		//IL_00e0: Expected O, but got Ref
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph activeGraph2 = base.m_activeGraph;
			if (!activeGraph2.m_enabled)
			{
				return;
			}
		}
		List<Socket> outputSockets = base.OutputSockets;
		if (outputSockets == null)
		{
			return;
		}
		List<Socket> outputSockets2 = base.OutputSockets;
		if (outputSockets2._size != 0)
		{
			List<Socket> outputSockets3 = base.OutputSockets;
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				Socket socket = null;
				List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	private unsafe void LookForTimeDelay()
	{
		//IL_0057: Expected O, but got Ref
		m_timerIsActive = false;
		base.m_useUpdate = false;
		List<Socket> outputSockets = base.OutputSockets;
		if (outputSockets == null)
		{
			return;
		}
		List<Socket> outputSockets2 = base.OutputSockets;
		if (outputSockets2._size != 0)
		{
			List<Socket> outputSockets3 = base.OutputSockets;
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				Socket socket = null;
				List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	private void ActivateTimer(float timeDelay, Socket socket)
	{
		//IL_0025: Expected O, but got F4
		m_timerIsActive = true;
		object obj = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_activeSocketAfterTimeDelay = socket;
		m_timeDelay = timeDelay;
		m_timerStart = 0.0;
		base.m_useUpdate = true;
	}

	private void ActivateOutputSocketInputNode(Socket socket)
	{
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph != null && ((UnityEngine.Object)activeGraph).m_CachedPtr != (IntPtr)0 && socket != null)
		{
			List<Connection> connections = socket.Connections;
			if (connections._size > 0)
			{
				Connection[] items = connections._items;
				Connection connection = items[0];
				Node nodeById = base.m_activeGraph.GetNodeById(connection.m_inputNodeId);
				base.m_activeGraph.SetActiveNode(nodeById, connection);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	public override void Activate(Graph portalGraph)
	{
		if (!m_activated)
		{
			base.Activate(portalGraph);
			Action<UIButtonMessage> callback = OnButtonMessage;
			Message.AddListener(callback);
			Action<GameEventMessage> callback2 = OnGameEventMessage;
			Message.AddListener(callback2);
		}
	}

	public override void Deactivate()
	{
		if (m_activated)
		{
			base.Deactivate();
			Action<UIButtonMessage> callback = OnButtonMessage;
			Message.RemoveListener(callback);
			Action<GameEventMessage> callback2 = OnGameEventMessage;
			Message.RemoveListener(callback2);
		}
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Activate(base.m_activeGraph);
		LookForTimeDelay();
		ShowViews(m_onEnterShowViews);
		HideViews(m_onEnterHideViews);
	}

	public override void OnUpdate()
	{
		//IL_0078: Expected O, but got F4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_002d: Invalid comparison between O and F4
		//IL_00c2: Expected O, but got F4
		//IL_004a: Invalid comparison between F4 and O
		if (!m_timerIsActive)
		{
			return;
		}
		object obj = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [rbx+0A8h]\"");
		object obj2 = 0 / m_timeDelay;
		if (0 > (nint)obj2)
		{
			return;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				return;
			}
		}
		m_timerIsActive = false;
		object obj3 = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		m_timerStart = 0.0;
		ActivateOutputSocketInputNode(m_activeSocketAfterTimeDelay);
	}

	public override void OnExit(Node nextActiveNode, Connection connection)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B54]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (base.m_debugMode)
		{
			string message = "Node '" + base.m_name + "': OnExit";
			DDebug.Log(message);
		}
		base._003CPing_003Ek__BackingField = true;
		if (connection != null)
		{
			connection._003CPing_003Ek__BackingField = true;
		}
		Deactivate();
		ShowViews(m_onExitShowViews);
		HideViews(m_onExitHideViews);
	}

	public unsafe void ShowViews(List<UIViewCategoryName> views)
	{
		//IL_0013: Expected O, but got I4
		//IL_002c: Expected O, but got Ref
		//IL_0061: Expected O, but got I
		//IL_0061: Expected O, but got I
		List<UIViewCategoryName>.Enumerator enumerator = default(List<UIViewCategoryName>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			bool flag = !base.m_debugMode;
			object obj2 = (object)(&enumerator);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v5+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v5+20]");
				string message = "Show UIView: " + (string)num + " / " + (string)0;
				DDebug.Log(message);
			}
			throw new NullReferenceException();
		}
	}

	public unsafe void HideViews(List<UIViewCategoryName> views)
	{
		//IL_0013: Expected O, but got I4
		//IL_002c: Expected O, but got Ref
		//IL_0061: Expected O, but got I
		//IL_0061: Expected O, but got I
		List<UIViewCategoryName>.Enumerator enumerator = default(List<UIViewCategoryName>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			bool flag = !base.m_debugMode;
			object obj2 = (object)(&enumerator);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v5+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rbx_v5+20]");
				string message = "Hide UIView: " + (string)num + " / " + (string)0;
				DDebug.Log(message);
			}
			throw new NullReferenceException();
		}
	}

	public void AddView(UIViewCategoryName view, NodeState nodeState, ViewAction viewAction, bool saveAssets = false)
	{
		if (view == null)
		{
			return;
		}
		switch (nodeState)
		{
		case NodeState.OnEnter:
			switch (viewAction)
			{
			case ViewAction.ShowView:
			{
				if (m_onEnterShowViews == null)
				{
					List<UIViewCategoryName> onEnterShowViews = new List<UIViewCategoryName>();
					m_onEnterShowViews = onEnterShowViews;
				}
				List<UIViewCategoryName> onExitHideViews2 = m_onEnterShowViews;
				break;
			}
			case ViewAction.HideView:
			{
				if (m_onEnterHideViews == null)
				{
					List<UIViewCategoryName> onEnterHideViews = new List<UIViewCategoryName>();
					m_onEnterHideViews = onEnterHideViews;
				}
				List<UIViewCategoryName> onExitHideViews2 = m_onEnterHideViews;
				break;
			}
			default:
				return;
			}
			break;
		case NodeState.OnExit:
			switch (viewAction)
			{
			case ViewAction.ShowView:
			{
				if (m_onExitShowViews == null)
				{
					List<UIViewCategoryName> onExitShowViews = new List<UIViewCategoryName>();
					m_onExitShowViews = onExitShowViews;
				}
				List<UIViewCategoryName> onExitHideViews2 = m_onExitShowViews;
				break;
			}
			case ViewAction.HideView:
			{
				if (m_onExitHideViews == null)
				{
					List<UIViewCategoryName> onExitHideViews = new List<UIViewCategoryName>();
					m_onExitHideViews = onExitHideViews;
				}
				List<UIViewCategoryName> onExitHideViews2 = m_onExitHideViews;
				break;
			}
			default:
				return;
			}
			break;
		default:
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AFD0");
	}
}
