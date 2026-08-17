using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody.Models;

[Serializable]
public class Node : ScriptableObject
{
	private List<Socket> m_inputSockets;

	private List<Socket> m_outputSockets;

	private NodeType m_nodeType;

	private bool m_allowDuplicateNodeName;

	private bool m_allowEmptyNodeName;

	private bool m_canBeDeleted;

	private bool m_debugMode;

	private bool m_useFixedUpdate;

	private bool m_useLateUpdate;

	private bool m_useUpdate;

	private float m_height;

	private float m_width;

	private float m_x;

	private float m_y;

	private int m_minimumInputSocketsCount;

	private int m_minimumOutputSocketsCount;

	private string m_graphId;

	private string m_id;

	private string m_name;

	private string m_notes;

	[NonSerialized]
	private Graph m_activeGraph;

	[NonSerialized]
	protected bool m_activated;

	private bool _003CPing_003Ek__BackingField;

	protected static UILanguagePack UILabels => UILanguagePack.Instance;

	public bool AllowDuplicateNodeName => m_allowDuplicateNodeName;

	public bool AllowEmptyNodeName => m_allowEmptyNodeName;

	public bool CanBeDeleted
	{
		get
		{
			return m_canBeDeleted;
		}
		set
		{
			m_canBeDeleted = value;
		}
	}

	public bool DebugMode
	{
		get
		{
			return m_debugMode;
		}
		set
		{
			m_debugMode = value;
		}
	}

	public bool Ping
	{
		get
		{
			return _003CPing_003Ek__BackingField;
		}
		set
		{
			_003CPing_003Ek__BackingField = value;
		}
	}

	public bool UseFixedUpdate
	{
		get
		{
			return m_useFixedUpdate;
		}
		set
		{
			m_useFixedUpdate = value;
		}
	}

	public bool UseLateUpdate
	{
		get
		{
			return m_useLateUpdate;
		}
		set
		{
			m_useLateUpdate = value;
		}
	}

	public bool UseUpdate
	{
		get
		{
			return m_useUpdate;
		}
		set
		{
			m_useUpdate = value;
		}
	}

	public Graph ActiveGraph
	{
		get
		{
			return m_activeGraph;
		}
		set
		{
			m_activeGraph = value;
		}
	}

	public int MinimumInputSocketsCount
	{
		get
		{
			return m_minimumInputSocketsCount;
		}
		set
		{
			m_minimumInputSocketsCount = value;
		}
	}

	public int MinimumOutputSocketsCount
	{
		get
		{
			return m_minimumOutputSocketsCount;
		}
		set
		{
			m_minimumOutputSocketsCount = value;
		}
	}

	public List<Socket> InputSockets
	{
		get
		{
			List<Socket> result = m_inputSockets;
			if (m_inputSockets == null)
			{
				result = (m_inputSockets = new List<Socket>());
			}
			return result;
		}
		set
		{
			m_inputSockets = value;
		}
	}

	public List<Socket> OutputSockets
	{
		get
		{
			List<Socket> result = m_outputSockets;
			if (m_outputSockets == null)
			{
				result = (m_outputSockets = new List<Socket>());
			}
			return result;
		}
		set
		{
			m_outputSockets = value;
		}
	}

	public NodeType NodeType => m_nodeType;

	public Socket FirstInputSocket
	{
		get
		{
			List<Socket> inputSockets = InputSockets;
			if (inputSockets._size > 0)
			{
				List<Socket> inputSockets2 = InputSockets;
				if (inputSockets2._size > 0)
				{
					Socket[] items = inputSockets2._items;
					return items[0];
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Socket result = default(Socket);
				return result;
			}
			return null;
		}
	}

	public Socket FirstOutputSocket
	{
		get
		{
			List<Socket> outputSockets = OutputSockets;
			if (outputSockets._size > 0)
			{
				List<Socket> outputSockets2 = OutputSockets;
				if (outputSockets2._size > 0)
				{
					Socket[] items = outputSockets2._items;
					return items[0];
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Socket result = default(Socket);
				return result;
			}
			return null;
		}
	}

	public string GraphId
	{
		get
		{
			return m_graphId;
		}
		set
		{
			m_graphId = value;
		}
	}

	public string Id
	{
		get
		{
			return m_id;
		}
		set
		{
			m_id = value;
		}
	}

	public string Name => m_name;

	protected virtual void OnEnable()
	{
	}

	public virtual void Activate(Graph portalGraph)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B4F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!m_activated)
		{
			if (m_debugMode)
			{
				string message = "Node '" + m_name + "': Activated";
				DDebug.Log(message);
			}
			m_activated = true;
		}
	}

	public virtual void AddDefaultSockets()
	{
	}

	public virtual void CheckForErrors()
	{
	}

	public virtual void CopyNode(Node original)
	{
		//IL_046d: Expected F4, but got O
		//IL_0163: Expected O, but got I4
		//IL_0275: Expected O, but got I4
		bool flag = (object)original == null;
		Node node = this;
		if (!flag)
		{
			string text = ((UnityEngine.Object)original).GetName();
			SetName(text);
			m_id = original.m_id;
			m_graphId = original.m_graphId;
			m_name = original.m_name;
			node = (Node)(object)(m_inputSockets = new List<Socket>());
			if (original.m_inputSockets != null)
			{
				List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
				while (enumerator.MoveNext())
				{
					List<object> inputSockets = (List<object>)(object)m_inputSockets;
					Socket socket = new Socket(null);
					bool flag2 = m_inputSockets == null;
					Socket socket2 = socket;
					if (!flag2)
					{
						int version = inputSockets._version + 1;
						inputSockets._version = version;
						node = (Node)(object)inputSockets._items;
						if (inputSockets._items != null)
						{
							if (inputSockets._size >= (nint)node.m_inputSockets)
							{
								((List<object>)(object)m_inputSockets).AddWithResize((object)socket);
								continue;
							}
							int size = inputSockets._size + 1;
							inputSockets._size = size;
							((List<Socket>)(object)inputSockets._items).AddWithResize((Socket)inputSockets._size);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				List<Socket> outputSockets = new List<Socket>();
				m_outputSockets = outputSockets;
				if (original.m_outputSockets != null)
				{
					List<Socket>.Enumerator enumerator2 = default(List<Socket>.Enumerator);
					while (enumerator2.MoveNext())
					{
						List<object> outputSockets2 = (List<object>)(object)m_outputSockets;
						Socket socket3 = new Socket(null);
						bool flag3 = m_outputSockets == null;
						Socket socket2 = socket3;
						if (!flag3)
						{
							int version2 = outputSockets2._version + 1;
							outputSockets2._version = version2;
							socket2 = (Socket)(object)outputSockets2._items;
							if (outputSockets2._items != null)
							{
								if (outputSockets2._size >= (nint)socket2.m_connections)
								{
									((List<object>)(object)m_outputSockets).AddWithResize((object)socket3);
									continue;
								}
								int size2 = outputSockets2._size + 1;
								outputSockets2._size = size2;
								((List<Socket>)(object)outputSockets2._items).AddWithResize((Socket)outputSockets2._size);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					m_canBeDeleted = original.m_canBeDeleted;
					m_useUpdate = original.m_useUpdate;
					m_useFixedUpdate = original.m_useFixedUpdate;
					m_useLateUpdate = original.m_useLateUpdate;
					m_nodeType = original.m_nodeType;
					m_minimumInputSocketsCount = original.m_minimumInputSocketsCount;
					m_minimumOutputSocketsCount = original.m_minimumOutputSocketsCount;
					m_allowEmptyNodeName = original.m_allowEmptyNodeName;
					m_allowDuplicateNodeName = original.m_allowDuplicateNodeName;
					m_x = original.m_x;
					m_y = original.m_y;
					float width = original.GetWidth();
					m_width = (float)original.m_outputSockets;
					m_height = original.m_height;
					bool flag4 = ((UnityEngine.Object)original).m_CachedPtr == (IntPtr)0;
					HideFlags hideFlags = UnityEngine.Object.get_hideFlags_Injected(((UnityEngine.Object)original).m_CachedPtr);
					base.hideFlags = hideFlags;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public virtual void Deactivate()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B51]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (m_activated)
		{
			if (m_debugMode)
			{
				string message = "Node '" + m_name + "': Deactivated ";
				DDebug.Log(message);
			}
			m_activated = false;
		}
	}

	public virtual float GetDefaultNodeHeight()
	{
		NodySettings instance = NodySettings.Instance;
		return instance.DefaultNodeHeight;
	}

	public virtual float GetDefaultNodeWidth()
	{
		NodySettings instance = NodySettings.Instance;
		return instance.DefaultNodeWidth;
	}

	public unsafe virtual void InitNode(Graph graph, Vector2 pos, int minimumInputSocketsCount = 1, int minimumOutputSocketsCount = 1)
	{
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_00da: Expected F4, but got O
		//IL_0138: Expected F4, but got O
		//IL_014c: Expected F4, but got O
		object obj = this + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		object obj2 = obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v55 @ rdx_v2+1B8] (should have been resolved before IL gen)");
		string text = default(string);
		SetName(text);
		object obj4 = default(object);
		global::Interop.GetRandomBytes((byte*)(&obj4), 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Guid guid = default(Guid);
		string id = guid.ToString("D", null);
		m_id = id;
		m_graphId = graph.m_id;
		string text2 = GetName();
		m_name = text2;
		List<Socket> inputSockets = new List<Socket>();
		m_inputSockets = inputSockets;
		List<Socket> outputSockets = new List<Socket>();
		m_outputSockets = outputSockets;
		m_x = (float)pos;
		float y = default(float);
		m_y = y;
		m_canBeDeleted = true;
		m_nodeType = NodeType.General;
		m_useLateUpdate = false;
		m_useFixedUpdate = false;
		m_minimumInputSocketsCount = minimumInputSocketsCount;
		int minimumOutputSocketsCount2 = default(int);
		m_minimumOutputSocketsCount = minimumOutputSocketsCount2;
		float defaultNodeWidth = GetDefaultNodeWidth();
		m_width = (float)pos;
		float defaultNodeHeight = GetDefaultNodeHeight();
		m_height = (float)pos;
	}

	public virtual void OnCreate()
	{
	}

	public virtual void OnEnter(Node previousActiveNode, Connection connection)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B53]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (m_debugMode)
		{
			string message = "Node '" + m_name + "': OnEnter";
			DDebug.Log(message);
		}
	}

	public virtual void OnExit(Node nextActiveNode, Connection connection)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B54]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (m_debugMode)
		{
			string message = "Node '" + m_name + "': OnExit";
			DDebug.Log(message);
		}
		_003CPing_003Ek__BackingField = true;
		if (connection != null)
		{
			connection._003CPing_003Ek__BackingField = true;
		}
	}

	public virtual void OnFixedUpdate()
	{
	}

	public virtual void OnLateUpdate()
	{
	}

	public virtual void OnUpdate()
	{
	}

	public Socket AddInputSocket(string socketName, ConnectionMode connectionMode, List<Vector2> connectionPoints, Type valueType, bool canBeDeleted, bool canBeReordered = true)
	{
		List<Vector2> connectionPoints2 = default(List<Vector2>);
		Type valueType2 = default(Type);
		bool canBeDeleted2 = default(bool);
		bool canBeReordered2 = default(bool);
		return AddSocket(socketName, SocketDirection.Input, connectionMode, connectionPoints2, valueType2, canBeDeleted2, canBeReordered2);
	}

	public Socket AddInputSocket(string socketName, ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
	{
		List<Vector2> leftAndRightConnectionPoints = GetLeftAndRightConnectionPoints();
		List<Vector2> connectionPoints = default(List<Vector2>);
		Type valueType2 = default(Type);
		bool canBeDeleted2 = default(bool);
		bool canBeReordered2 = default(bool);
		return AddSocket(socketName, SocketDirection.Input, connectionMode, connectionPoints, valueType2, canBeDeleted2, canBeReordered2);
	}

	public Socket AddInputSocket(ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B55]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		List<Vector2> leftAndRightConnectionPoints = GetLeftAndRightConnectionPoints();
		List<Vector2> connectionPoints = default(List<Vector2>);
		Type valueType2 = default(Type);
		bool canBeDeleted2 = default(bool);
		bool canBeReordered2 = default(bool);
		return AddSocket("", SocketDirection.Input, connectionMode, connectionPoints, valueType2, canBeDeleted2, canBeReordered2);
	}

	public Socket AddOutputSocket(string socketName, ConnectionMode connectionMode, List<Vector2> connectionPoints, Type valueType, bool canBeDeleted, bool canBeReordered)
	{
		List<Vector2> connectionPoints2 = default(List<Vector2>);
		Type valueType2 = default(Type);
		bool canBeDeleted2 = default(bool);
		bool canBeReordered2 = default(bool);
		return AddSocket(socketName, SocketDirection.Output, connectionMode, connectionPoints2, valueType2, canBeDeleted2, canBeReordered2);
	}

	public Socket AddOutputSocket(string socketName, ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
	{
		List<Vector2> leftAndRightConnectionPoints = GetLeftAndRightConnectionPoints();
		List<Vector2> connectionPoints = default(List<Vector2>);
		Type valueType2 = default(Type);
		bool canBeDeleted2 = default(bool);
		bool canBeReordered2 = default(bool);
		return AddSocket(socketName, SocketDirection.Output, connectionMode, connectionPoints, valueType2, canBeDeleted2, canBeReordered2);
	}

	public Socket AddOutputSocket(ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B56]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		List<Vector2> leftAndRightConnectionPoints = GetLeftAndRightConnectionPoints();
		List<Vector2> connectionPoints = default(List<Vector2>);
		Type valueType2 = default(Type);
		bool canBeDeleted2 = default(bool);
		bool canBeReordered2 = default(bool);
		return AddSocket("", SocketDirection.Output, connectionMode, connectionPoints, valueType2, canBeDeleted2, canBeReordered2);
	}

	private unsafe Socket AddSocket(string socketName, SocketDirection direction, ConnectionMode connectionMode, List<Vector2> connectionPoints, Type valueType, bool canBeDeleted, bool canBeReordered = true)
	{
		//IL_012a: Expected O, but got I4
		//IL_0134: Expected O, but got Ref
		//IL_044c: Expected O, but got I4
		//IL_0456: Expected O, but got Ref
		//IL_0254: Expected O, but got Ref
		//IL_0576: Expected O, but got Ref
		//IL_0283: Expected O, but got Ref
		//IL_05a5: Expected O, but got Ref
		//IL_0347: Expected O, but got Ref
		//IL_0647: Expected O, but got Ref
		List<Vector2> list = default(List<Vector2>);
		bool flag = list != null;
		List<Vector2> list2 = list;
		if (!flag)
		{
			List<Vector2> leftAndRightConnectionPoints = GetLeftAndRightConnectionPoints();
			List<Vector2> list3 = new List<Vector2>(leftAndRightConnectionPoints);
			bool flag2 = list3 == null;
			list2 = list3;
			List<Vector2> list4 = list3;
			if (flag2)
			{
				goto IL_06bc;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r13_v10 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 == 0)
		{
			List<Vector2> leftAndRightConnectionPoints2 = GetLeftAndRightConnectionPoints();
			List<Vector2> list5 = list2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r13_v10 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			list5.InsertRange(0, leftAndRightConnectionPoints2);
		}
		List<string> list6 = new List<string>();
		string text;
		object obj2 = default(object);
		string text4;
		if (direction == SocketDirection.Input)
		{
			List<Socket> inputSockets = InputSockets;
			bool flag3 = inputSockets == null;
			List<Vector2> list4 = (List<Vector2>)(object)this;
			if (!flag3)
			{
				List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					list4 = (List<Vector2>)(&enumerator);
					throw new NullReferenceException();
				}
				if (socketName != null)
				{
					bool flag4 = socketName._stringLength > 0;
					list4 = (List<Vector2>)(&enumerator);
					text = socketName;
					if (flag4)
					{
						goto IL_07a2;
					}
				}
				string text2 = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&obj2), null);
				string text3 = "InputSocket_" + text2;
				ConnectionMode connectionMode2 = ConnectionMode.Override;
				list4 = (List<Vector2>)(object)"InputSocket_";
				text = text3;
				goto IL_07a2;
			}
		}
		else
		{
			if (direction != SocketDirection.Output)
			{
				SocketDirection socketDirection = default(SocketDirection);
				object actualValue = socketDirection;
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("direction", actualValue, null);
				throw ex;
			}
			List<Socket> outputSockets = OutputSockets;
			bool flag5 = outputSockets == null;
			List<Vector2> list4 = (List<Vector2>)(object)this;
			if (!flag5)
			{
				List<Socket>.Enumerator enumerator2 = default(List<Socket>.Enumerator);
				if (enumerator2.MoveNext())
				{
					object obj3 = 0;
					list4 = (List<Vector2>)(&enumerator2);
					throw new NullReferenceException();
				}
				if (socketName != null)
				{
					bool flag6 = socketName._stringLength > 0;
					list4 = (List<Vector2>)(&enumerator2);
					text4 = socketName;
					if (flag6)
					{
						goto IL_083c;
					}
				}
				string text5 = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&obj2), null);
				string text6 = "OutputSocket_" + text5;
				ConnectionMode connectionMode2 = ConnectionMode.Override;
				list4 = (List<Vector2>)(object)"OutputSocket_";
				text4 = text6;
				goto IL_083c;
			}
		}
		goto IL_06bc;
		IL_07a2:
		bool flag7 = list6 == null;
		ConnectionMode connectionMode4 = default(ConnectionMode);
		ConnectionMode connectionMode3 = connectionMode4;
		SocketDirection socketDirection2 = SocketDirection.Input;
		List<Vector2> connectionPoints2 = default(List<Vector2>);
		Type valueType2 = default(Type);
		bool canBeDeleted2 = default(bool);
		IntPtr intPtr = default(IntPtr);
		List<Socket> list7;
		Socket socket2;
		if (!flag7)
		{
			while (list6._size != 0)
			{
				int num = Array.IndexOf((object[])list6._items, (object)text, 0, list6._size);
				if (num == -1)
				{
					break;
				}
				SocketDirection socketDirection3 = socketDirection2 + 1;
				string text7 = System.Number.FormatInt32((int)socketDirection2, (ReadOnlySpan<char>)(&obj2), null);
				string text8 = "InputSocket_" + text7;
				text = text8;
				socketDirection2 = socketDirection3;
			}
			Socket socket = new Socket(this, text, canBeReordered ? SocketDirection.Output : SocketDirection.Input, connectionMode3, connectionPoints2, valueType2, canBeDeleted2, (byte)(nint)intPtr != 0);
			list7 = InputSockets;
			socket2 = socket;
			goto IL_03bc;
		}
		goto IL_06bc;
		IL_06bc:
		throw new NullReferenceException();
		IL_03bc:
		if (list7 != null)
		{
			((List<Vector2>)(object)list7)._002Ector((IEnumerable<Vector2>)socket2);
			return socket2;
		}
		goto IL_06bc;
		IL_083c:
		bool flag8 = list6 == null;
		connectionMode3 = connectionMode4;
		socketDirection2 = SocketDirection.Input;
		if (!flag8)
		{
			while (list6._size != 0)
			{
				int num2 = Array.IndexOf((object[])list6._items, (object)text4, 0, list6._size);
				if (num2 == -1)
				{
					break;
				}
				SocketDirection socketDirection4 = socketDirection2 + 1;
				string text9 = System.Number.FormatInt32((int)socketDirection2, (ReadOnlySpan<char>)(&obj2), null);
				string text10 = "OutputSocket_" + text9;
				text4 = text10;
				socketDirection2 = socketDirection4;
			}
			Socket socket3 = new Socket(this, text4, canBeReordered ? SocketDirection.Output : SocketDirection.Input, connectionMode3, connectionPoints2, valueType2, canBeDeleted2, (byte)(nint)intPtr != 0);
			list7 = OutputSockets;
			socket2 = socket3;
			goto IL_03bc;
		}
		goto IL_06bc;
	}

	public bool CanDeleteSocket(Socket socket)
	{
		//IL_020e: Expected I4, but got O
		//IL_016f: Expected O, but got I4
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected I4, but got Unknown
		//IL_00a9: Expected O, but got I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected I4, but got Unknown
		if (socket != null)
		{
			if (!socket.m_canBeDeleted)
			{
				goto IL_01fa;
			}
			if (socket.m_direction != SocketDirection.Input)
			{
				if (socket.m_direction != SocketDirection.Output)
				{
					goto IL_01fa;
				}
				List<Socket> outputSockets = OutputSockets;
				if (outputSockets != null)
				{
					object obj = outputSockets._size - m_minimumOutputSocketsCount;
					int num = outputSockets._size ^ m_minimumOutputSocketsCount;
					int num2 = outputSockets._size ^ obj;
					int num3 = num & num2;
					bool flag = num3 < 0;
					bool flag2 = (nint)obj < 0;
					bool flag3 = obj == null;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
			else
			{
				List<Socket> inputSockets = InputSockets;
				if (inputSockets != null)
				{
					object obj2 = inputSockets._size - m_minimumInputSocketsCount;
					int num4 = inputSockets._size ^ m_minimumInputSocketsCount;
					int num5 = inputSockets._size ^ obj2;
					int num6 = num4 & num5;
					bool flag6 = num6 < 0;
					bool flag7 = (nint)obj2 < 0;
					bool flag8 = obj2 == null;
					bool flag9 = flag7 == flag6;
					bool flag10 = !flag8;
					return flag10 & flag9;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01fa:
		return false;
	}

	public bool ContainsConnection(string connectionId)
	{
		Connection connection = GetConnection(connectionId);
		bool flag = connection == null;
		return !flag;
	}

	public bool ContainsSocket(string socketId)
	{
		Socket socketFromId = GetSocketFromId(socketId);
		bool flag = socketFromId == null;
		return !flag;
	}

	public unsafe void Disconnect()
	{
		//IL_0012: Expected O, but got Ref
		//IL_00a2: Expected O, but got Ref
		List<Socket> inputSockets = InputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		List<Socket> outputSockets = OutputSockets;
		List<Socket>.Enumerator enumerator3 = default(List<Socket>.Enumerator);
		if (enumerator3.MoveNext())
		{
			Socket socket = (Socket)(&enumerator3);
			throw new NullReferenceException();
		}
	}

	public void DisconnectFromNode(string nodeId)
	{
		List<Socket> inputSockets = InputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			throw new NullReferenceException();
		}
		List<Socket> outputSockets = OutputSockets;
		List<Socket>.Enumerator enumerator2 = default(List<Socket>.Enumerator);
		if (enumerator2.MoveNext())
		{
			Socket socket = null;
			throw new NullReferenceException();
		}
	}

	public unsafe string GenerateNewId()
	{
		object obj = default(object);
		global::Interop.GetRandomBytes((byte*)(&obj), 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Guid guid = default(Guid);
		return m_id = guid.ToString("D", null);
	}

	public Vector2 GetCenterConnectionPointPosition()
	{
		float width = GetWidth();
		NodySettings instance = NodySettings.Instance;
		if ((object)instance != null)
		{
			NodySettings instance2 = NodySettings.Instance;
			if ((object)instance2 != null)
			{
				NodySettings instance3 = NodySettings.Instance;
				Vector2 result = default(Vector2);
				if ((object)instance3 != null)
				{
					return result;
				}
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public Connection GetConnection(string connectionId)
	{
		List<Socket> inputSockets = InputSockets;
		if (inputSockets != null)
		{
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				Socket socket = null;
				throw new NullReferenceException();
			}
			List<Socket> outputSockets = OutputSockets;
			if (outputSockets != null)
			{
				List<Socket>.Enumerator enumerator2 = default(List<Socket>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Socket socket = null;
					throw new NullReferenceException();
				}
				return null;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe List<string> GetConnectedInputNodesIds()
	{
		//IL_0017: Expected O, but got Ref
		List<string> result = new List<string>();
		List<Socket> outputSockets = OutputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe List<string> GetConnectedInputSocketsIds()
	{
		//IL_0017: Expected O, but got Ref
		List<string> result = new List<string>();
		List<Socket> outputSockets = OutputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe List<string> GetConnectedOutputNodesIds()
	{
		//IL_0017: Expected O, but got Ref
		List<string> result = new List<string>();
		List<Socket> inputSockets = InputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe List<string> GetConnectedOutputSocketsIds()
	{
		//IL_0017: Expected O, but got Ref
		List<string> result = new List<string>();
		List<Socket> inputSockets = InputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe Rect GetFooterRect()
	{
		//IL_00a8: Expected native int or pointer, but got O
		//IL_00b5: Expected native int or pointer, but got O
		//IL_00c2: Expected native int or pointer, but got O
		//IL_00e3: Expected native int or pointer, but got O
		NodySettings instance = NodySettings.Instance;
		if ((object)instance != null)
		{
			float width = GetWidth();
			NodySettings instance2 = NodySettings.Instance;
			if ((object)instance2 != null)
			{
				float num = m_y - 6f;
				float xMin = m_x + 6f;
				object obj = default(object);
				float width2 = (float)obj - 12f;
				float num2 = num + m_height;
				Rect rect = default(Rect);
				((Rect*)(nint)rect)->m_Height = instance2.FooterHeight;
				((Rect*)(nint)rect)->m_XMin = xMin;
				((Rect*)(nint)rect)->m_Width = width2;
				float yMin = num2 - instance.FooterHeight;
				((Rect*)(nint)rect)->m_YMin = yMin;
				return rect;
			}
		}
		return (Rect)new NullReferenceException();
	}

	public unsafe Rect GetHeaderRect()
	{
		//IL_0071: Expected native int or pointer, but got O
		//IL_007e: Expected native int or pointer, but got O
		//IL_008b: Expected native int or pointer, but got O
		//IL_0098: Expected native int or pointer, but got O
		float width = GetWidth();
		NodySettings instance = NodySettings.Instance;
		if ((object)instance != null)
		{
			float xMin = m_x + 6f;
			float yMin = m_y + 6f;
			object obj = default(object);
			float width2 = (float)obj - 12f;
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_Height = instance.NodeHeaderHeight;
			((Rect*)(nint)rect)->m_XMin = xMin;
			((Rect*)(nint)rect)->m_YMin = yMin;
			((Rect*)(nint)rect)->m_Width = width2;
			return rect;
		}
		return (Rect)new NullReferenceException();
	}

	public float GetHeight()
	{
		return m_height;
	}

	public unsafe Socket GetInputSocketFromId(string socketId)
	{
		//IL_0017: Expected O, but got Ref
		List<Socket> inputSockets = InputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Socket GetInputSocketFromName(string socketName)
	{
		//IL_0017: Expected O, but got Ref
		List<Socket> inputSockets = InputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	private List<Vector2> GetLeftAndCenterAndRightConnectionPoints()
	{
		List<Vector2> list = new List<Vector2>();
		Vector2 leftConnectionPointPosition = GetLeftConnectionPointPosition();
		if (list != null)
		{
			list.Add(leftConnectionPointPosition);
			float width = GetWidth();
			NodySettings instance = NodySettings.Instance;
			if ((object)instance != null)
			{
				NodySettings instance2 = NodySettings.Instance;
				if ((object)instance2 != null)
				{
					NodySettings instance3 = NodySettings.Instance;
					if ((object)instance3 != null)
					{
						Vector2 item = default(Vector2);
						list.Add(item);
						Vector2 rightConnectionPointPosition = GetRightConnectionPointPosition();
						list.Add(rightConnectionPointPosition);
						return list;
					}
				}
			}
		}
		return (List<Vector2>)(object)new NullReferenceException();
	}

	public Vector2 GetLeftConnectionPointPosition()
	{
		NodySettings instance = NodySettings.Instance;
		if ((object)instance != null)
		{
			NodySettings instance2 = NodySettings.Instance;
			if ((object)instance2 != null)
			{
				NodySettings instance3 = NodySettings.Instance;
				Vector2 result = default(Vector2);
				if ((object)instance3 != null)
				{
					return result;
				}
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public List<Vector2> GetLeftAndRightConnectionPoints()
	{
		List<Vector2> list = new List<Vector2>();
		Vector2 leftConnectionPointPosition = GetLeftConnectionPointPosition();
		if (list != null)
		{
			list.Add(leftConnectionPointPosition);
			Vector2 rightConnectionPointPosition = GetRightConnectionPointPosition();
			list.Add(rightConnectionPointPosition);
			return list;
		}
		return (List<Vector2>)(object)new NullReferenceException();
	}

	public Vector2 GetPosition()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe Socket GetOutputSocketFromId(string socketId)
	{
		//IL_0017: Expected O, but got Ref
		List<Socket> outputSockets = OutputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Socket GetOutputSocketFromName(string socketName)
	{
		//IL_0017: Expected O, but got Ref
		List<Socket> outputSockets = OutputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			Socket socket = null;
			List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe Rect GetRect()
	{
		//IL_0014: Expected native int or pointer, but got O
		//IL_0023: Expected native int or pointer, but got O
		//IL_0032: Expected native int or pointer, but got O
		//IL_003f: Expected native int or pointer, but got O
		float width = GetWidth();
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_Height = m_height;
		((Rect*)(nint)rect)->m_XMin = m_x;
		((Rect*)(nint)rect)->m_YMin = m_y;
		float width2 = default(float);
		((Rect*)(nint)rect)->m_Width = width2;
		return rect;
	}

	public Vector2 GetRightConnectionPointPosition()
	{
		float width = GetWidth();
		NodySettings instance = NodySettings.Instance;
		if ((object)instance != null)
		{
			NodySettings instance2 = NodySettings.Instance;
			if ((object)instance2 != null)
			{
				NodySettings instance3 = NodySettings.Instance;
				if ((object)instance3 != null)
				{
					NodySettings instance4 = NodySettings.Instance;
					Vector2 result = default(Vector2);
					if ((object)instance4 != null)
					{
						return result;
					}
				}
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public virtual float GetWidth()
	{
		return m_width;
	}

	public Vector2 GetSize()
	{
		float width = GetWidth();
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe Socket GetSocketFromId(string socketId)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0139: Expected O, but got Ref
		List<Socket> inputSockets = InputSockets;
		if (inputSockets != null)
		{
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				Socket socket = null;
				List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			List<Socket> outputSockets = OutputSockets;
			if (outputSockets != null)
			{
				List<Socket>.Enumerator enumerator3 = default(List<Socket>.Enumerator);
				if (enumerator3.MoveNext())
				{
					Socket socket2 = null;
					List<Socket>.Enumerator enumerator4 = (List<Socket>.Enumerator)(&enumerator3);
					throw new NullReferenceException();
				}
				return null;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe Socket GetSocketFromName(string socketName)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0139: Expected O, but got Ref
		List<Socket> inputSockets = InputSockets;
		if (inputSockets != null)
		{
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				Socket socket = null;
				List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			List<Socket> outputSockets = OutputSockets;
			if (outputSockets != null)
			{
				List<Socket>.Enumerator enumerator3 = default(List<Socket>.Enumerator);
				if (enumerator3.MoveNext())
				{
					Socket socket2 = null;
					List<Socket>.Enumerator enumerator4 = (List<Socket>.Enumerator)(&enumerator3);
					throw new NullReferenceException();
				}
				return null;
			}
		}
		throw new NullReferenceException();
	}

	public float GetX()
	{
		return m_x;
	}

	public float GetY()
	{
		return m_y;
	}

	public unsafe bool IsConnected()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_0066: Expected O, but got I4
		//IL_006e: Expected O, but got Ref
		List<Socket> inputSockets = InputSockets;
		if (inputSockets != null)
		{
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			List<Socket> outputSockets = OutputSockets;
			if (outputSockets != null)
			{
				List<Socket>.Enumerator enumerator3 = default(List<Socket>.Enumerator);
				if (enumerator3.MoveNext())
				{
					object obj2 = 0;
					List<Socket>.Enumerator enumerator2 = (List<Socket>.Enumerator)(&enumerator3);
					throw new NullReferenceException();
				}
				return false;
			}
		}
		throw new NullReferenceException();
	}

	public bool IsConnectedToNode(string nodeId)
	{
		List<Socket> inputSockets = InputSockets;
		if (inputSockets != null)
		{
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				Socket socket = null;
				throw new NullReferenceException();
			}
			List<Socket> outputSockets = OutputSockets;
			if (outputSockets != null)
			{
				List<Socket>.Enumerator enumerator2 = default(List<Socket>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Socket socket = null;
					throw new NullReferenceException();
				}
				return false;
			}
		}
		throw new NullReferenceException();
	}

	public bool IsConnectedToSocket(string socketId)
	{
		List<Socket> inputSockets = InputSockets;
		if (inputSockets != null)
		{
			List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
			if (enumerator.MoveNext())
			{
				Socket socket = null;
				throw new NullReferenceException();
			}
			List<Socket> outputSockets = OutputSockets;
			if (outputSockets != null)
			{
				List<Socket>.Enumerator enumerator2 = default(List<Socket>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Socket socket = null;
					throw new NullReferenceException();
				}
				return false;
			}
		}
		throw new NullReferenceException();
	}

	public void RemoveConnection(string connectionId)
	{
		List<Socket> inputSockets = InputSockets;
		List<Socket>.Enumerator enumerator = default(List<Socket>.Enumerator);
		if (enumerator.MoveNext())
		{
			throw new NullReferenceException();
		}
		List<Socket> outputSockets = OutputSockets;
		List<Socket>.Enumerator enumerator2 = default(List<Socket>.Enumerator);
		if (enumerator2.MoveNext())
		{
			Socket socket = null;
			throw new NullReferenceException();
		}
	}

	public void SetActiveGraph(Graph graph)
	{
		m_activeGraph = graph;
	}

	protected void SetAllowEmptyNodeName(bool value)
	{
		m_allowEmptyNodeName = value;
	}

	protected void SetAllowDuplicateNodeName(bool value)
	{
		m_allowDuplicateNodeName = value;
	}

	public void SetName(string value)
	{
		m_name = value;
	}

	public void SetNodeType(NodeType nodeType)
	{
		m_nodeType = nodeType;
	}

	public void SetPosition(Vector2 position)
	{
		//IL_000a: Expected F4, but got O
		m_x = (float)position;
		float y = default(float);
		m_y = y;
	}

	public void SetPosition(float x, float y)
	{
		m_x = x;
		m_y = y;
	}

	public void SetRect(Rect rect)
	{
		m_x = rect.m_XMin;
		m_y = rect.m_YMin;
		m_width = rect.m_Width;
		m_height = rect.m_Height;
	}

	public void SetRect(Vector2 position, Vector2 size)
	{
		//IL_000a: Expected F4, but got O
		//IL_001e: Expected F4, but got O
		m_x = (float)position;
		float y = default(float);
		m_y = y;
		m_width = (float)size;
		float height = default(float);
		m_height = height;
	}

	public void SetRect(float x, float y, float width, float height)
	{
		float height2 = default(float);
		m_height = height2;
		m_x = y;
		m_width = width;
	}

	public void SetSize(Vector2 size)
	{
		//IL_000a: Expected F4, but got O
		m_width = (float)size;
		float height = default(float);
		m_height = height;
	}

	public void SetSize(float width, float height)
	{
		m_width = width;
		m_height = height;
	}

	public void SetWidth(float value)
	{
		m_width = value;
	}

	public void SetHeight(float value)
	{
		m_height = value;
	}

	public void SetX(float value)
	{
		m_x = value;
	}

	public void SetY(float value)
	{
		m_y = value;
	}

	private void CheckThatNodeNameIsNotEmpty()
	{
	}
}
