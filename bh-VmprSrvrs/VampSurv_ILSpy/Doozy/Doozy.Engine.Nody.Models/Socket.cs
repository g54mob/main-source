using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Connections;
using UnityEngine;

namespace Doozy.Engine.Nody.Models;

[Serializable]
public class Socket
{
	public const string DEFAULT_INPUT_SOCKET_NAME_PREFIX = "InputSocket_";

	public const string DEFAULT_OUTPUT_SOCKET_NAME_PREFIX = "OutputSocket_";

	private ConnectionMode m_connectionMode;

	private List<Connection> m_connections;

	private List<Vector2> m_connectionPoints;

	private SocketDirection m_direction;

	private Type m_valueType;

	private bool m_canBeDeleted;

	private bool m_canBeReordered;

	private float m_curveModifier;

	private float m_height;

	private float m_width;

	private float m_x;

	private float m_y;

	private string m_id;

	private string m_nodeId;

	private string m_socketName;

	private string m_value;

	private string m_valueTypeQualifiedName;

	[NonSerialized]
	private Rect m_hoverRect;

	public bool AcceptsMultipleConnections
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_connectionMode - 1;
			return obj == null;
		}
	}

	public bool CanBeDeleted => m_canBeDeleted;

	public bool CanBeReordered => m_canBeReordered;

	public List<Vector2> ConnectionPoints
	{
		get
		{
			List<Vector2> result = m_connectionPoints;
			if (m_connectionPoints == null)
			{
				result = (m_connectionPoints = new List<Vector2>());
			}
			return result;
		}
		set
		{
			m_connectionPoints = value;
		}
	}

	public List<Connection> Connections
	{
		get
		{
			List<Connection> result = m_connections;
			if (m_connections == null)
			{
				result = (m_connections = new List<Connection>());
			}
			return result;
		}
		set
		{
			m_connections = value;
		}
	}

	public float CurveModifier
	{
		get
		{
			return m_curveModifier;
		}
		set
		{
			m_curveModifier = value;
		}
	}

	public Connection FirstConnection
	{
		get
		{
			List<Connection> connections = Connections;
			if (connections._size > 0)
			{
				List<Connection> connections2 = Connections;
				if (connections2._size > 0)
				{
					Connection[] items = connections2._items;
					return items[0];
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Connection result = default(Connection);
				return result;
			}
			return null;
		}
	}

	public unsafe Rect HoverRect
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = (float)m_hoverRect;
			return rect;
		}
		set
		{
			//IL_000f: Expected O, but got F4
			m_hoverRect = (Rect)value.m_XMin;
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

	public bool IsConnected
	{
		get
		{
			//IL_009e: Expected I4, but got O
			List<Connection> connections = m_connections;
			if (m_connections != null)
			{
				int num = connections._size ^ connections._size;
				int num2 = connections._size & num;
				bool flag = num2 < 0;
				bool flag2 = connections._size < 0;
				bool flag3 = connections._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool IsInput => m_direction == SocketDirection.Input;

	public bool IsOutput
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_direction - 1;
			return obj == null;
		}
	}

	public bool OverrideConnection => m_connectionMode == ConnectionMode.Override;

	public string NodeId
	{
		get
		{
			return m_nodeId;
		}
		set
		{
			m_nodeId = value;
		}
	}

	public string SocketName => m_socketName;

	public string Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	public Type ValueType
	{
		get
		{
			if ((object)m_valueType == null)
			{
				string valueTypeQualifiedName = m_valueTypeQualifiedName;
				if (m_valueTypeQualifiedName == null || valueTypeQualifiedName._stringLength <= (nint)m_valueType)
				{
					return null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7DE0");
				Type valueType = default(Type);
				m_valueType = valueType;
			}
			return m_valueType;
		}
		private set
		{
			m_valueType = value;
			if ((object)value != null)
			{
				string assemblyQualifiedName = value.AssemblyQualifiedName;
				m_valueTypeQualifiedName = assemblyQualifiedName;
			}
		}
	}

	private string ValueTypeQualifiedName
	{
		get
		{
			return m_valueTypeQualifiedName;
		}
		set
		{
			m_valueTypeQualifiedName = value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7DE0");
			Type valueType = default(Type);
			m_valueType = valueType;
		}
	}

	public unsafe Socket(Node node, string socketName, SocketDirection direction, ConnectionMode connectionMode, List<Vector2> connectionPoints, Type valueType, bool canBeDeleted, bool canBeReordered)
	{
		object obj = default(object);
		global::Interop.GetRandomBytes((byte*)(&obj), 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Guid guid = default(Guid);
		string id = guid.ToString("D", null);
		m_id = id;
		m_nodeId = node.m_id;
		m_socketName = socketName;
		IntPtr intPtr = default(IntPtr);
		m_connectionMode = (ConnectionMode)(nint)intPtr;
		List<Vector2> connectionPoints2 = default(List<Vector2>);
		m_connectionPoints = connectionPoints2;
		m_direction = direction;
		Type type = default(Type);
		m_valueType = type;
		bool canBeDeleted2 = default(bool);
		m_canBeDeleted = canBeDeleted2;
		bool canBeReordered2 = default(bool);
		m_canBeReordered = canBeReordered2;
		string assemblyQualifiedName = type.AssemblyQualifiedName;
		m_valueTypeQualifiedName = assemblyQualifiedName;
		Type valueType2 = ValueType;
		object obj2 = Activator.CreateInstance(valueType2, false, true);
		string value = JsonUtility.ToJson(obj2);
		m_value = value;
		List<Connection> connections = new List<Connection>();
		m_connections = connections;
		m_curveModifier = 0f;
	}

	public Socket(Socket other)
	{
		bool flag = other == null;
		Socket socket = this;
		if (!flag)
		{
			m_id = other.m_id;
			m_nodeId = other.m_nodeId;
			m_socketName = other.m_socketName;
			m_direction = other.m_direction;
			m_connectionMode = other.m_connectionMode;
			List<Vector2> connectionPoints = other.ConnectionPoints;
			List<Vector2> connectionPoints2 = new List<Vector2>(connectionPoints);
			m_connectionPoints = connectionPoints2;
			m_x = other.m_x;
			m_y = other.m_y;
			m_width = other.m_width;
			m_height = other.m_height;
			m_valueType = other.m_valueType;
			m_valueTypeQualifiedName = other.m_valueTypeQualifiedName;
			m_value = other.m_value;
			m_canBeDeleted = other.m_canBeDeleted;
			m_canBeReordered = other.m_canBeReordered;
			socket = (Socket)(object)(m_connections = new List<Connection>());
			if (other.m_connections != null)
			{
				List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
				while (enumerator.MoveNext())
				{
					List<object> connections = (List<object>)(object)m_connections;
					Connection item = new Connection(null);
					if (m_connections != null)
					{
						int version = connections._version + 1;
						connections._version = version;
						socket = (Socket)(object)connections._items;
						if (connections._items != null)
						{
							if (connections._size >= (nint)socket.m_connections)
							{
								((List<object>)(object)m_connections).AddWithResize((object)item);
								continue;
							}
							int size = connections._size + 1;
							connections._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				m_curveModifier = other.m_curveModifier;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe bool CanConnect(Socket other, bool ignoreValueType = false)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Ref, but got Unknown
		//IL_00f4: Expected I8, but got I4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Ref, but got Unknown
		//IL_049e: Expected I4, but got O
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected Ref, but got Unknown
		//IL_01f5: Expected I8, but got I4
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected Ref, but got Unknown
		if (other != null && !IsConnectedToSocket(other.m_id))
		{
			string id = m_id;
			string id2 = other.m_id;
			if ((object)m_id != other.m_id)
			{
				if (m_id != null && other.m_id != null && id._stringLength == id2._stringLength)
				{
					ref byte second = ref *(byte*)(other.m_id + 20);
					ulong length = (ulong)(id._stringLength + id._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref *(byte*)(m_id + 20), ref second, length))
					{
						goto IL_0482;
					}
				}
				string nodeId = m_nodeId;
				string nodeId2 = other.m_nodeId;
				if ((object)m_nodeId != other.m_nodeId)
				{
					if (m_nodeId != null && other.m_nodeId != null && nodeId._stringLength == nodeId2._stringLength)
					{
						ref byte second2 = ref *(byte*)(other.m_nodeId + 20);
						ulong length2 = (ulong)(nodeId._stringLength + nodeId._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref *(byte*)(m_nodeId + 20), ref second2, length2))
						{
							goto IL_0482;
						}
					}
					if ((m_direction != SocketDirection.Input || other.m_direction != SocketDirection.Input) && (m_direction != SocketDirection.Output || other.m_direction != SocketDirection.Output))
					{
						if (!ignoreValueType)
						{
							Type valueType = ValueType;
							if ((object)valueType != null)
							{
								Type baseType = valueType.BaseType;
								Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(PassthroughConnection));
								if ((object)typeFromHandle != null)
								{
									Type baseType2 = typeFromHandle.BaseType;
									if ((object)baseType == baseType2)
									{
										goto IL_0474;
									}
									Type valueType2 = other.ValueType;
									if ((object)valueType2 != null)
									{
										Type baseType3 = valueType2.BaseType;
										Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(PassthroughConnection));
										if ((object)typeFromHandle2 != null)
										{
											Type baseType4 = typeFromHandle2.BaseType;
											if ((object)baseType3 == baseType4)
											{
												goto IL_0474;
											}
											Type valueType3 = ValueType;
											if ((object)valueType3 != null)
											{
												Type baseType5 = valueType3.BaseType;
												Type valueType4 = other.ValueType;
												if ((object)valueType4 != null)
												{
													Type baseType6 = valueType4.BaseType;
													if ((object)baseType5 == baseType6)
													{
														goto IL_0474;
													}
													goto IL_0482;
												}
											}
										}
									}
								}
							}
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						goto IL_0474;
					}
				}
			}
		}
		goto IL_0482;
		IL_0474:
		return true;
		IL_0482:
		return false;
	}

	public unsafe bool ContainsConnection(string connectionId)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<Connection> connections = Connections;
		List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Connection>.Enumerator enumerator2 = (List<Connection>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public bool ContainsConnection(Connection connection)
	{
		//IL_0043: Expected I4, but got O
		if (connection != null)
		{
			return ContainsConnection(connection.m_id);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void Disconnect()
	{
		List<Connection> connections = Connections;
		int version = connections._version + 1;
		connections._version = version;
		connections._size = 0;
		if (connections._size > 0)
		{
			Array.Clear(connections._items, 0, connections._size);
		}
	}

	public unsafe void DisconnectFromNode(string nodeId)
	{
		//IL_025e: Expected O, but got I4
		//IL_047c: Expected O, but got I4
		//IL_0356: Expected O, but got I4
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected Ref, but got Unknown
		//IL_01c4: Expected I8, but got I4
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected Ref, but got Unknown
		//IL_0200: Expected O, but got I4
		//IL_0209: Expected O, but got I4
		//IL_0211: Expected I, but got I8
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected Ref, but got Unknown
		//IL_03bb: Expected I8, but got I4
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected Ref, but got Unknown
		//IL_0406: Expected O, but got I4
		//IL_040f: Expected O, but got I4
		//IL_0417: Expected I, but got I8
		List<Connection> connections = m_connections;
		if (connections._size <= 0)
		{
			return;
		}
		List<Connection> connections2 = Connections;
		bool flag = (nint)connections2 < 0;
		int num = connections2._size - 1;
		if (flag)
		{
			return;
		}
		nint num3 = default(nint);
		object obj2 = default(object);
		while (true)
		{
			List<Connection> connections3 = Connections;
			if (num >= connections3._size)
			{
				break;
			}
			Connection[] items = connections3._items;
			Connection connection = items[num];
			bool flag2 = m_direction != SocketDirection.Input;
			nint num2 = num3;
			object obj;
			if (!flag2)
			{
				string outputNodeId = connection.m_outputNodeId;
				bool flag3 = (object)connection.m_outputNodeId == nodeId;
				obj = obj2;
				if (flag3)
				{
					goto IL_021f;
				}
				bool flag4 = connection.m_outputNodeId == null;
				num2 = num3;
				if (!flag4)
				{
					bool flag5 = nodeId == null;
					num2 = num3;
					if (!flag5)
					{
						bool flag6 = outputNodeId._stringLength != nodeId._stringLength;
						num2 = num3;
						if (!flag6)
						{
							ref byte second = ref *(byte*)(nodeId + 20);
							ulong num4 = (ulong)(outputNodeId._stringLength + outputNodeId._stringLength);
							bool flag7 = System.SpanHelpers.SequenceEqual(ref *(byte*)(connection.m_outputNodeId + 20), ref second, num4);
							bool flag8 = !flag7;
							obj = 0;
							obj2 = 0;
							num2 = (nint)num4;
							if (!flag8)
							{
								goto IL_021f;
							}
						}
					}
				}
			}
			goto IL_024e;
			IL_0463:
			num--;
			bool flag9;
			object obj3 = !flag9;
			if (obj3 == null)
			{
				return;
			}
			continue;
			IL_0425:
			List<Connection> connections4 = Connections;
			flag9 = (nint)connections4 < 0;
			connections4.RemoveAt(num);
			object obj4;
			obj2 = obj4;
			num3 = 0;
			goto IL_0463;
			IL_021f:
			List<Connection> connections5 = Connections;
			connections5.RemoveAt(num);
			obj2 = obj;
			num2 = 0;
			goto IL_024e;
			IL_024e:
			object obj5 = m_direction - 1;
			flag9 = (nint)obj5 < 0;
			bool flag10 = m_direction != SocketDirection.Output;
			num3 = num2;
			if (!flag10)
			{
				string inputNodeId = connection.m_inputNodeId;
				bool flag11 = (object)connection.m_inputNodeId == nodeId;
				obj4 = obj2;
				if (flag11)
				{
					goto IL_0425;
				}
				flag9 = (nint)connection.m_inputNodeId < 0;
				bool flag12 = connection.m_inputNodeId == null;
				num3 = num2;
				if (!flag12)
				{
					flag9 = (nint)nodeId < 0;
					bool flag13 = nodeId == null;
					num3 = num2;
					if (!flag13)
					{
						object obj6 = inputNodeId._stringLength - nodeId._stringLength;
						flag9 = (nint)obj6 < 0;
						bool flag14 = inputNodeId._stringLength != nodeId._stringLength;
						num3 = num2;
						if (!flag14)
						{
							ref byte second2 = ref *(byte*)(nodeId + 20);
							ulong num5 = (ulong)(inputNodeId._stringLength + inputNodeId._stringLength);
							bool flag15 = System.SpanHelpers.SequenceEqual(ref *(byte*)(connection.m_inputNodeId + 20), ref second2, num5);
							flag9 = (flag15 ? 1 : 0) < (false ? 1 : 0);
							bool flag16 = !flag15;
							obj4 = 0;
							obj2 = 0;
							num3 = (nint)num5;
							if (!flag16)
							{
								goto IL_0425;
							}
						}
					}
				}
			}
			goto IL_0463;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public Vector2 GetClosestConnectionPointToPosition(Vector2 position)
	{
		//IL_0060: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_022e: Expected I, but got O
		//IL_0188: Invalid comparison between I4 and F4
		//IL_01a5: Expected F4, but got I4
		List<Vector2> connectionPoints = ConnectionPoints;
		if (connectionPoints != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Vector2 result = default(Vector2);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v11+18]");
				if ((nint)0 <= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				List<Vector2> connectionPoints2 = ConnectionPoints;
				if (connectionPoints2 != null)
				{
					float num = 100000f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v11+20]");
					Vector2 result2 = (Vector2)0;
					List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
					object obj4 = default(object);
					object obj5 = default(object);
					Vector2 vector = default(Vector2);
					while (enumerator.MoveNext())
					{
						object obj2 = 0 - position;
						object obj3 = obj4 - obj5;
						nint num2 = (nint)typeof(Math);
						object obj6 = obj3 * obj3;
						object obj7 = obj2 * obj2;
						double d = (double)obj6 + (double)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rcx_v13 (Il2CppClass<System.Math>)+E4]");
						if ((nint)0 <= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
						}
						else
						{
							double num3 = Math.Sqrt(d);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
						if (!(0f > num))
						{
							num = 0f;
							result2 = vector;
						}
					}
					return result2;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe Vector2 GetClosestConnectionPointToSocket(Socket other)
	{
		//IL_0056: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_0105: Expected O, but got Ref
		//IL_0179: Expected O, but got I4
		List<Vector2> connectionPoints = ConnectionPoints;
		if (connectionPoints != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Vector2 result = default(Vector2);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v17+18]");
				if ((nint)0 <= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				List<Vector2> connectionPoints2 = ConnectionPoints;
				if (connectionPoints2 != null)
				{
					float num = 100000f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v17+20]");
					Vector2 result2 = (Vector2)0;
					List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
					List<Vector2>.Enumerator enumerator2 = default(List<Vector2>.Enumerator);
					float num2 = default(float);
					while (true)
					{
						if (enumerator.MoveNext())
						{
							bool flag = other == null;
							Socket socket = (Socket)(&enumerator);
							if (!flag)
							{
								List<Vector2> connectionPoints3 = other.ConnectionPoints;
								if (connectionPoints3 == null)
								{
									break;
								}
								while (enumerator2.MoveNext())
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
									if (!(num2 > num))
									{
										num = num2;
										result2 = (Vector2)0;
									}
								}
								continue;
							}
							throw new NullReferenceException();
						}
						return result2;
					}
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe List<string> GetConnectedNodesIds()
	{
		//IL_005f: Expected O, but got I4
		//IL_00ab: Expected O, but got Ref
		//IL_0089: Expected O, but got Ref
		List<string> result = new List<string>();
		List<Connection> connections = m_connections;
		if (m_connections != null)
		{
			if (connections._size > 0)
			{
				List<Connection> connections2 = Connections;
				if (connections2 == null)
				{
					goto IL_00dc;
				}
				List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<Connection>.Enumerator enumerator2;
					if (m_direction == SocketDirection.Input)
					{
						enumerator2 = (List<Connection>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					enumerator2 = (List<Connection>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
			}
			return result;
		}
		goto IL_00dc;
		IL_00dc:
		throw new NullReferenceException();
	}

	public unsafe List<string> GetConnectedSocketIds()
	{
		//IL_005f: Expected O, but got I4
		//IL_00ab: Expected O, but got Ref
		//IL_0089: Expected O, but got Ref
		List<string> result = new List<string>();
		List<Connection> connections = m_connections;
		if (m_connections != null)
		{
			if (connections._size > 0)
			{
				List<Connection> connections2 = Connections;
				if (connections2 == null)
				{
					goto IL_00dc;
				}
				List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<Connection>.Enumerator enumerator2;
					if (m_direction == SocketDirection.Input)
					{
						enumerator2 = (List<Connection>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					enumerator2 = (List<Connection>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
			}
			return result;
		}
		goto IL_00dc;
		IL_00dc:
		throw new NullReferenceException();
	}

	public unsafe Connection GetConnection(string connectionId)
	{
		//IL_0017: Expected O, but got Ref
		List<Connection> connections = Connections;
		List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
		if (enumerator.MoveNext())
		{
			Connection connection = null;
			List<Connection>.Enumerator enumerator2 = (List<Connection>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe List<string> GetConnectionIds()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<string> result = new List<string>();
		List<Connection> connections = Connections;
		List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Connection>.Enumerator enumerator2 = (List<Connection>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public ConnectionMode GetConnectionMode()
	{
		return m_connectionMode;
	}

	public SocketDirection GetDirection()
	{
		return m_direction;
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

	public float GetHeight()
	{
		return m_height;
	}

	public Vector2 GetPosition()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe Rect GetRect()
	{
		//IL_000a: Expected native int or pointer, but got O
		//IL_0019: Expected native int or pointer, but got O
		//IL_0028: Expected native int or pointer, but got O
		//IL_0037: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = m_x;
		((Rect*)(nint)rect)->m_YMin = m_y;
		((Rect*)(nint)rect)->m_Width = m_width;
		((Rect*)(nint)rect)->m_Height = m_height;
		return rect;
	}

	public Vector2 GetSize()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public float GetWidth()
	{
		return m_width;
	}

	public float GetX()
	{
		return m_x;
	}

	public float GetY()
	{
		return m_y;
	}

	public unsafe bool IsConnectedToNode(string nodeId)
	{
		//IL_0013: Expected O, but got I4
		//IL_002f: Expected O, but got Ref
		//IL_0045: Expected O, but got Ref
		List<Connection> connections = Connections;
		List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
		do
		{
			if (enumerator.MoveNext())
			{
				object obj = 0;
				bool flag = m_direction != SocketDirection.Input;
				List<Connection>.Enumerator enumerator2 = (List<Connection>.Enumerator)(&enumerator);
				if (!flag)
				{
					enumerator2 = (List<Connection>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				continue;
			}
			return false;
		}
		while (m_direction != SocketDirection.Output);
		throw new NullReferenceException();
	}

	public unsafe bool IsConnectedToSocket(string socketId)
	{
		//IL_0013: Expected O, but got I4
		//IL_002f: Expected O, but got Ref
		//IL_0045: Expected O, but got Ref
		List<Connection> connections = Connections;
		List<Connection>.Enumerator enumerator = default(List<Connection>.Enumerator);
		do
		{
			if (enumerator.MoveNext())
			{
				object obj = 0;
				bool flag = m_direction != SocketDirection.Input;
				List<Connection>.Enumerator enumerator2 = (List<Connection>.Enumerator)(&enumerator);
				if (!flag)
				{
					enumerator2 = (List<Connection>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				continue;
			}
			return false;
		}
		while (m_direction != SocketDirection.Output);
		throw new NullReferenceException();
	}

	public unsafe void RemoveConnection(string connectionId)
	{
		//IL_0261: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected Ref, but got Unknown
		//IL_01ad: Expected I8, but got I4
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Ref, but got Unknown
		//IL_01f8: Expected O, but got I4
		//IL_0201: Expected O, but got I4
		if (!ContainsConnection(connectionId))
		{
			return;
		}
		List<Connection> connections = Connections;
		bool flag = (nint)connections < 0;
		int num = connections._size - 1;
		if (flag)
		{
			return;
		}
		object obj2 = default(object);
		while (true)
		{
			List<Connection> connections2 = Connections;
			if (num >= connections2._size)
			{
				break;
			}
			Connection[] items = connections2._items;
			Connection connection = items[num];
			string id = connection.m_id;
			if ((object)connection.m_id == connectionId)
			{
				goto IL_020f;
			}
			bool flag2 = (nint)connection.m_id < 0;
			bool flag3 = connection.m_id == null;
			object obj = obj2;
			if (!flag3)
			{
				flag2 = (nint)connectionId < 0;
				bool flag4 = connectionId == null;
				obj = obj2;
				if (!flag4)
				{
					object obj3 = id._stringLength - connectionId._stringLength;
					flag2 = (nint)obj3 < 0;
					bool flag5 = id._stringLength != connectionId._stringLength;
					obj = obj2;
					if (!flag5)
					{
						ref byte second = ref *(byte*)(connectionId + 20);
						ulong length = (ulong)(id._stringLength + id._stringLength);
						bool flag6 = System.SpanHelpers.SequenceEqual(ref *(byte*)(connection.m_id + 20), ref second, length);
						flag2 = (flag6 ? 1 : 0) < (false ? 1 : 0);
						bool flag7 = !flag6;
						obj2 = 0;
						obj = 0;
						if (!flag7)
						{
							goto IL_020f;
						}
					}
				}
			}
			goto IL_0248;
			IL_0248:
			num--;
			object obj4 = !flag2;
			obj2 = obj;
			if (obj4 == null)
			{
				return;
			}
			continue;
			IL_020f:
			List<Connection> connections3 = Connections;
			flag2 = (nint)connections3 < 0;
			connections3.RemoveAt(num);
			obj = obj2;
			goto IL_0248;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SetHeight(float value)
	{
		m_height = value;
	}

	public void SetName(string value)
	{
		m_socketName = value;
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

	public void SetX(float value)
	{
		m_x = value;
	}

	public void SetY(float value)
	{
		m_y = value;
	}

	public void UpdateHoverRect()
	{
		Rect hoverRect = default(Rect);
		m_hoverRect = hoverRect;
	}
}
