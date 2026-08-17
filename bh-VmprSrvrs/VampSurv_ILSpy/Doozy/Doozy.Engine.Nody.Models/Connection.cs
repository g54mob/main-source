using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Nody.Models;

[Serializable]
public class Connection
{
	private bool _003CPing_003Ek__BackingField;

	private Vector2 m_inputConnectionPoint;

	private Vector2 m_outputConnectionPoint;

	private string m_id;

	private string m_inputNodeId;

	private string m_inputSocketId;

	private string m_outputNodeId;

	private string m_outputSocketId;

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

	public string InputNodeId
	{
		get
		{
			return m_inputNodeId;
		}
		set
		{
			m_inputNodeId = value;
		}
	}

	public string InputSocketId
	{
		get
		{
			return m_inputSocketId;
		}
		set
		{
			m_inputSocketId = value;
		}
	}

	public string OutputNodeId
	{
		get
		{
			return m_outputNodeId;
		}
		set
		{
			m_outputNodeId = value;
		}
	}

	public string OutputSocketId
	{
		get
		{
			return m_outputSocketId;
		}
		set
		{
			m_outputSocketId = value;
		}
	}

	public Vector2 InputConnectionPoint
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			m_inputConnectionPoint = value;
		}
	}

	public Vector2 OutputConnectionPoint
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			m_outputConnectionPoint = value;
		}
	}

	public unsafe Connection(Socket socket1, Socket socket2)
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
		if (socket1.m_direction == SocketDirection.Output && socket2.m_direction == SocketDirection.Input)
		{
			m_outputNodeId = socket1.m_nodeId;
			m_outputSocketId = socket1.m_id;
			Vector2 closestConnectionPointToSocket = socket1.GetClosestConnectionPointToSocket(socket2);
			m_outputConnectionPoint = closestConnectionPointToSocket;
			m_inputNodeId = socket2.m_nodeId;
			m_inputSocketId = socket2.m_id;
			Vector2 closestConnectionPointToSocket2 = socket2.GetClosestConnectionPointToSocket(socket1);
			m_inputConnectionPoint = closestConnectionPointToSocket2;
		}
		if (socket1.m_direction == SocketDirection.Input && socket2.m_direction == SocketDirection.Output)
		{
			m_outputNodeId = socket2.m_nodeId;
			m_outputSocketId = socket2.m_id;
			Vector2 closestConnectionPointToSocket3 = socket2.GetClosestConnectionPointToSocket(socket1);
			m_outputConnectionPoint = closestConnectionPointToSocket3;
			m_inputNodeId = socket1.m_nodeId;
			m_inputSocketId = socket1.m_id;
			Vector2 closestConnectionPointToSocket4 = socket1.GetClosestConnectionPointToSocket(socket2);
			m_inputConnectionPoint = closestConnectionPointToSocket4;
		}
	}

	public Connection(Connection other)
	{
		m_id = other.m_id;
		m_outputNodeId = other.m_outputNodeId;
		m_outputSocketId = other.m_outputSocketId;
		m_outputConnectionPoint = other.m_outputConnectionPoint;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [other @ rdx (Doozy.Engine.Nody.Models.Connection)+20]");
		_ = 0;
		m_inputNodeId = other.m_inputNodeId;
		m_inputSocketId = other.m_inputSocketId;
		m_inputConnectionPoint = other.m_inputConnectionPoint;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [other @ rdx (Doozy.Engine.Nody.Models.Connection)+18]");
		_ = 0;
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
}
