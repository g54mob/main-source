using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes;

public class PortalNode : Node
{
	public enum ListenerType
	{
		GameEvent,
		UIButton,
		UIView,
		UIDrawer
	}

	private const ListenerType DEFAULT_LISTENER_TYPE = ListenerType.GameEvent;

	private const bool DEFAULT_ANY_VALUE = false;

	private const string DEFAULT_GAME_EVENT = "";

	private string m_gameEvent = "";

	[NonSerialized]
	private Graph m_portalGraph;

	public ListenerType ListenFor;

	public bool AnyValue;

	public UIViewBehaviorType UIViewTriggerAction = UIViewBehaviorType.Show;

	public string ViewCategory;

	public string ViewName;

	public UIButtonBehaviorType UIButtonTriggerAction;

	public string ButtonCategory;

	public string ButtonName;

	public UIDrawerBehaviorType UIDrawerTriggerAction;

	public string DrawerName;

	public bool CustomDrawerName;

	public bool SwitchBackMode;

	private Node m_sourceNode;

	private bool m_activatedByEvent;

	public string GameEventToListenFor => m_gameEvent;

	public Graph PortalGraph
	{
		get
		{
			return m_portalGraph;
		}
		set
		{
			m_portalGraph = value;
		}
	}

	public bool HasSource
	{
		get
		{
			Node sourceNode = m_sourceNode;
			if ((object)m_sourceNode != null)
			{
				bool flag = ((UnityEngine.Object)sourceNode).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public Node Source => m_sourceNode;

	public unsafe string WaitForInfoTitle
	{
		get
		{
			//IL_0015: Expected O, but got I4
			//IL_00bd: Expected O, but got Ref
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0094: Expected O, but got Ref
			//IL_006b: Expected O, but got Ref
			bool flag = ListenFor == ListenerType.GameEvent;
			if (!flag)
			{
				object obj = ListenFor - 1;
				object obj3 = default(object);
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							return "---";
						}
						string text = ((Enum)(&obj3)).ToString();
						return "UIDrawer " + text;
					}
					string text2 = ((Enum)(&obj3)).ToString();
					return "UIView " + text2;
				}
				string text3 = ((Enum)(&obj3)).ToString();
				return "UIButton " + text3;
			}
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance != null)
			{
				return instance.GameEvent;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	public string WaitForInfoDescription
	{
		get
		{
			//IL_0043: Expected O, but got I4
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980807]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag = ListenFor == ListenerType.GameEvent;
			string text;
			if (!flag)
			{
				object obj = ListenFor - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							goto IL_0259;
						}
						if (!AnyValue)
						{
							return DrawerName;
						}
						UILanguagePack instance = UILanguagePack.Instance;
						if ((object)instance != null)
						{
							return instance.AnyUIDrawer;
						}
					}
					else
					{
						if (!AnyValue)
						{
							return ViewCategory + " / " + ViewName;
						}
						UILanguagePack instance2 = UILanguagePack.Instance;
						if ((object)instance2 != null)
						{
							return instance2.AnyUIView;
						}
					}
				}
				else
				{
					if (!AnyValue)
					{
						return ButtonCategory + " / " + ButtonName;
					}
					UILanguagePack instance3 = UILanguagePack.Instance;
					if ((object)instance3 != null)
					{
						return instance3.AnyUIButton;
					}
				}
			}
			else
			{
				if (!AnyValue)
				{
					text = m_gameEvent;
					if (m_gameEvent == null || text._stringLength <= 0)
					{
						goto IL_0259;
					}
					goto IL_0294;
				}
				UILanguagePack instance4 = UILanguagePack.Instance;
				if ((object)instance4 != null)
				{
					return instance4.AnyGameEvent;
				}
			}
			return (string)(object)new NullReferenceException();
			IL_0259:
			text = "---";
			goto IL_0294;
			IL_0294:
			return text;
		}
	}

	public override void OnCreate()
	{
		base.m_canBeDeleted = true;
		base.m_nodeType = NodeType.Global;
		UILanguagePack instance = UILanguagePack.Instance;
		base.m_name = instance.PortalNodeName;
	}

	public override void AddDefaultSockets()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type valueType = default(Type);
		bool canBeReordered = default(bool);
		Socket socket = AddOutputSocket(ConnectionMode.Override, valueType, canBeDeleted: false, canBeReordered);
	}

	private void AddListeners()
	{
		//IL_0015: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		bool flag = ListenFor == ListenerType.GameEvent;
		if (!flag)
		{
			object obj = ListenFor - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						Action<UIDrawerMessage> callback = OnUIDrawerMessage;
						Message.AddListener(callback);
					}
				}
				else
				{
					Action<UIViewMessage> callback2 = OnUIViewMessage;
					Message.AddListener(callback2);
				}
			}
			else
			{
				Action<UIButtonMessage> callback3 = OnUIButtonMessage;
				Message.AddListener(callback3);
			}
		}
		else
		{
			Action<GameEventMessage> callback4 = OnGameEventMessage;
			Message.AddListener(callback4);
		}
	}

	private void RemoveListeners()
	{
		//IL_0015: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		bool flag = ListenFor == ListenerType.GameEvent;
		if (!flag)
		{
			object obj = ListenFor - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						Action<UIDrawerMessage> callback = OnUIDrawerMessage;
						Message.RemoveListener(callback);
					}
				}
				else
				{
					Action<UIViewMessage> callback2 = OnUIViewMessage;
					Message.RemoveListener(callback2);
				}
			}
			else
			{
				Action<UIButtonMessage> callback3 = OnUIButtonMessage;
				Message.RemoveListener(callback3);
			}
		}
		else
		{
			Action<GameEventMessage> callback4 = OnGameEventMessage;
			Message.RemoveListener(callback4);
		}
	}

	public override void Activate(Graph portalGraph)
	{
		if (!m_activated)
		{
			base.Activate(portalGraph);
			m_portalGraph = portalGraph;
			AddListeners();
		}
	}

	public override void Deactivate()
	{
		if (m_activated)
		{
			base.Deactivate();
			RemoveListeners();
		}
	}

	private void UpdateSourceNode(Node node)
	{
		if (SwitchBackMode)
		{
			m_sourceNode = node;
		}
	}

	private unsafe void OnGameEventMessage(GameEventMessage message)
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected Ref, but got Unknown
		//IL_0132: Expected I8, but got I4
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Ref, but got Unknown
		Graph portalGraph = m_portalGraph;
		if ((object)m_portalGraph != null && ((UnityEngine.Object)portalGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph portalGraph2 = m_portalGraph;
			if (!portalGraph2.m_enabled)
			{
				return;
			}
		}
		string eventName = message.EventName;
		string gameEvent = m_gameEvent;
		if ((object)message.EventName != m_gameEvent)
		{
			if (message.EventName == null || m_gameEvent == null || eventName._stringLength != gameEvent._stringLength)
			{
				return;
			}
			ref byte second = ref *(byte*)(m_gameEvent + 20);
			ulong length = (ulong)(eventName._stringLength + eventName._stringLength);
			if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(message.EventName + 20), ref second, length))
			{
				return;
			}
		}
		m_activatedByEvent = true;
		Node nodeById = m_portalGraph.GetNodeById(base.m_id);
		m_portalGraph.SetActiveNode(nodeById);
	}

	private unsafe void OnUIViewMessage(UIViewMessage message)
	{
		//IL_00d3: Expected O, but got Ref
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected Ref, but got Unknown
		//IL_02b4: Expected I8, but got I4
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected Ref, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected Ref, but got Unknown
		//IL_03b5: Expected I8, but got I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected Ref, but got Unknown
		Graph portalGraph = m_portalGraph;
		if ((object)m_portalGraph != null && ((UnityEngine.Object)portalGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph portalGraph2 = m_portalGraph;
			if (!portalGraph2.m_enabled)
			{
				return;
			}
		}
		if (ListenFor != ListenerType.UIView)
		{
			return;
		}
		if (base.m_debugMode)
		{
			string[] array = new string[10];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UIView view = message.View;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UIView view2 = message.View;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array);
			DDebug.Log(message2, this);
		}
		if (message.Type == UIViewBehaviorType.Unknown || message.Type != UIViewTriggerAction)
		{
			return;
		}
		if (!AnyValue)
		{
			UIView view3 = message.View;
			string viewCategory = view3.ViewCategory;
			string viewCategory2 = ViewCategory;
			if ((object)view3.ViewCategory != ViewCategory)
			{
				if (ViewCategory == null || viewCategory._stringLength != viewCategory2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(ViewCategory + 20);
				ulong length = (ulong)(viewCategory._stringLength + viewCategory._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(view3.ViewCategory + 20), ref second, length))
				{
					return;
				}
			}
			UIView view4 = message.View;
			string viewName = view4.ViewName;
			string viewName2 = ViewName;
			if ((object)view4.ViewName != ViewName)
			{
				if (ViewName == null || viewName._stringLength != viewName2._stringLength)
				{
					return;
				}
				ref byte second2 = ref *(byte*)(ViewName + 20);
				ulong length2 = (ulong)(viewName._stringLength + viewName._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(view4.ViewName + 20), ref second2, length2))
				{
					return;
				}
			}
		}
		m_activatedByEvent = true;
		Node nodeById = m_portalGraph.GetNodeById(base.m_id);
		m_portalGraph.SetActiveNode(nodeById);
	}

	private unsafe void OnUIButtonMessage(UIButtonMessage message)
	{
		//IL_017e: Expected O, but got I
		//IL_00d3: Expected O, but got Ref
		//IL_01b5: Expected O, but got I4
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected Ref, but got Unknown
		//IL_024a: Expected I8, but got I4
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected Ref, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected Ref, but got Unknown
		//IL_033a: Expected I8, but got I4
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected Ref, but got Unknown
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected Ref, but got Unknown
		//IL_04fa: Expected I8, but got I4
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected Ref, but got Unknown
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected Ref, but got Unknown
		//IL_05fb: Expected I8, but got I4
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected Ref, but got Unknown
		Graph portalGraph = m_portalGraph;
		if ((object)m_portalGraph != null && ((UnityEngine.Object)portalGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph portalGraph2 = m_portalGraph;
			if (!portalGraph2.m_enabled)
			{
				return;
			}
		}
		if (ListenFor != ListenerType.UIButton)
		{
			return;
		}
		if (base.m_debugMode)
		{
			string[] array = new string[6];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array);
			DDebug.Log(message2, this);
		}
		if (message.Type != UIButtonTriggerAction)
		{
			return;
		}
		string buttonName = ButtonName;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980639]");
		if ((nint)0 == 0)
		{
			_ = 1;
			obj = 1;
		}
		object obj2 = "Back";
		if ((object)ButtonName == "Back")
		{
			goto IL_0287;
		}
		if ("Back" != null)
		{
			int stringLength = buttonName._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rdx_v4+10]");
			if ((nint)stringLength == 0)
			{
				ref byte first = ref *(byte*)(ButtonName + 20);
				ulong length = (ulong)(buttonName._stringLength + buttonName._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Back" + 20), length))
				{
					goto IL_0287;
				}
			}
		}
		goto IL_03d2;
		IL_03d2:
		if (!AnyValue)
		{
			UIButton button = message.Button;
			if ((object)message.Button == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rsi_v10 (Doozy.Engine.UI.UIButton)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			UIButton button2 = message.Button;
			string buttonCategory = button2.ButtonCategory;
			string buttonCategory2 = ButtonCategory;
			if ((object)button2.ButtonCategory != ButtonCategory)
			{
				if (ButtonCategory == null || buttonCategory._stringLength != buttonCategory2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(ButtonCategory + 20);
				ulong length2 = (ulong)(buttonCategory._stringLength + buttonCategory._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(button2.ButtonCategory + 20), ref second, length2))
				{
					return;
				}
			}
			UIButton button3 = message.Button;
			string buttonName2 = button3.ButtonName;
			string buttonName3 = ButtonName;
			if ((object)button3.ButtonName != ButtonName)
			{
				if (ButtonName == null || buttonName2._stringLength != buttonName3._stringLength)
				{
					return;
				}
				ref byte second2 = ref *(byte*)(ButtonName + 20);
				ulong length3 = (ulong)(buttonName2._stringLength + buttonName2._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(button3.ButtonName + 20), ref second2, length3))
				{
					return;
				}
			}
		}
		goto IL_063c;
		IL_063c:
		m_activatedByEvent = true;
		Node nodeById = m_portalGraph.GetNodeById(base.m_id);
		m_portalGraph.SetActiveNode(nodeById);
		return;
		IL_0287:
		string buttonName4 = message.ButtonName;
		if (obj == null)
		{
			_ = 1;
		}
		object obj3 = "Back";
		if ((object)message.ButtonName != "Back")
		{
			if ("Back" != null)
			{
				int stringLength2 = buttonName4._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rdx_v15+10]");
				if ((nint)stringLength2 == 0)
				{
					ref byte first2 = ref *(byte*)(message.ButtonName + 20);
					ulong length4 = (ulong)(buttonName4._stringLength + buttonName4._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Back" + 20), length4))
					{
						goto IL_063c;
					}
				}
			}
			UIButton button4 = message.Button;
			if ((object)message.Button != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rsi_v12 (Doozy.Engine.UI.UIButton)+10]");
				if ((nint)0 != 0 && message.Button.IsBackButton)
				{
					goto IL_063c;
				}
			}
			goto IL_03d2;
		}
		goto IL_063c;
	}

	private unsafe void OnUIDrawerMessage(UIDrawerMessage message)
	{
		//IL_00d3: Expected O, but got Ref
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Ref, but got Unknown
		//IL_024e: Expected I8, but got I4
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Ref, but got Unknown
		Graph portalGraph = m_portalGraph;
		if ((object)m_portalGraph != null && ((UnityEngine.Object)portalGraph).m_CachedPtr != (IntPtr)0)
		{
			Graph portalGraph2 = m_portalGraph;
			if (!portalGraph2.m_enabled)
			{
				return;
			}
		}
		if (ListenFor != ListenerType.UIDrawer)
		{
			return;
		}
		if (base.m_debugMode)
		{
			string[] array = new string[6];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UIDrawer drawer = message.Drawer;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message2 = string.Concat(array);
			DDebug.Log(message2, this);
		}
		if (message.Type != UIDrawerTriggerAction)
		{
			return;
		}
		if (!AnyValue)
		{
			UIDrawer drawer2 = message.Drawer;
			string drawerName = drawer2.DrawerName;
			string drawerName2 = DrawerName;
			if ((object)drawer2.DrawerName != DrawerName)
			{
				if (DrawerName == null || drawerName._stringLength != drawerName2._stringLength)
				{
					return;
				}
				ref byte second = ref *(byte*)(DrawerName + 20);
				ulong length = (ulong)(drawerName._stringLength + drawerName._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(drawer2.DrawerName + 20), ref second, length))
				{
					return;
				}
			}
		}
		m_activatedByEvent = true;
		Node nodeById = m_portalGraph.GetNodeById(base.m_id);
		m_portalGraph.SetActiveNode(nodeById);
	}

	public override void CopyNode(Node original)
	{
		//IL_00da: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0098: Expected O, but got I
		//IL_012e: Expected O, but got I
		//IL_0197: Expected O, but got I
		//IL_0157: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_0180: Expected O, but got I
		base.CopyNode(original);
		nint num = (nint)typeof(PortalNode);
		nint num2 = (nint)original;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.PortalNode>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v2 (Il2CppClass<Doozy.Engine.UI.Nodes.PortalNode>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<Doozy.Engine.Nody.Models.Node>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(PortalNode))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+80]");
				m_gameEvent = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+90]");
				ListenFor = ListenerType.GameEvent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+94]");
				AnyValue = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+98]");
				UIViewTriggerAction = UIViewBehaviorType.Unknown;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+A0]");
				ViewCategory = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+A8]");
				ViewName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+B0]");
				UIButtonTriggerAction = UIButtonBehaviorType.OnClick;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+B8]");
				ButtonCategory = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+C0]");
				ButtonName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+C8]");
				UIDrawerTriggerAction = UIDrawerBehaviorType.Open;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+D0]");
				DrawerName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+D8]");
				CustomDrawerName = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [original @ rdx (Doozy.Engine.Nody.Models.Node)+D9]");
				SwitchBackMode = false;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void OnEnter(Node previousActiveNode, Connection connection)
	{
		base.OnEnter(previousActiveNode, connection);
		Graph activeGraph = base.m_activeGraph;
		if ((object)base.m_activeGraph == null || ((UnityEngine.Object)activeGraph).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Socket firstOutputSocket = base.FirstOutputSocket;
		List<Connection> connections = firstOutputSocket.m_connections;
		if (connections._size <= 0)
		{
			return;
		}
		if (SwitchBackMode)
		{
			if (!m_activatedByEvent)
			{
				Node sourceNode = m_sourceNode;
				if ((object)m_sourceNode != null && ((UnityEngine.Object)sourceNode).m_CachedPtr != (IntPtr)0)
				{
					Node sourceNode2 = m_sourceNode;
					Node nodeById = m_portalGraph.GetNodeById(sourceNode2.m_id);
					m_portalGraph.SetActiveNode(nodeById);
					m_sourceNode = null;
					return;
				}
			}
			if (SwitchBackMode)
			{
				bool flag = m_activatedByEvent;
				Node sourceNode3 = previousActiveNode;
				if (!flag)
				{
					sourceNode3 = null;
				}
				m_sourceNode = sourceNode3;
			}
		}
		Socket firstOutputSocket2 = base.FirstOutputSocket;
		Connection firstConnection = firstOutputSocket2.FirstConnection;
		Node nodeById2 = m_portalGraph.GetNodeById(firstConnection.m_inputNodeId);
		m_portalGraph.SetActiveNode(nodeById2, firstConnection);
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
		m_activatedByEvent = false;
	}

	public override void CheckForErrors()
	{
	}

	public PortalNode()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980779]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ViewCategory = "General";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998077A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ViewName = "Unnamed";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ButtonCategory = "General";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998063C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ButtonName = "Unnamed";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998069B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DrawerName = "Unnamed";
		((ScriptableObject)this)._002Ector();
	}
}
