using System;
using System.Collections.Generic;
using UnityEngine;

namespace Doozy.Engine.Nody.Models
{
	[Serializable]
	public class Socket
	{
		public const string DEFAULT_INPUT_SOCKET_NAME_PREFIX = "InputSocket_";

		public const string DEFAULT_OUTPUT_SOCKET_NAME_PREFIX = "OutputSocket_";

		[SerializeField]
		private ConnectionMode m_connectionMode;

		[SerializeField]
		private List<Connection> m_connections;

		[SerializeField]
		private List<Vector2> m_connectionPoints;

		[SerializeField]
		private SocketDirection m_direction;

		[SerializeField]
		private Type m_valueType;

		[SerializeField]
		private bool m_canBeDeleted;

		[SerializeField]
		private bool m_canBeReordered;

		[SerializeField]
		private float m_curveModifier;

		[SerializeField]
		private float m_height;

		[SerializeField]
		private float m_width;

		[SerializeField]
		private float m_x;

		[SerializeField]
		private float m_y;

		[SerializeField]
		private string m_id;

		[SerializeField]
		private string m_nodeId;

		[SerializeField]
		private string m_socketName;

		[SerializeField]
		private string m_value;

		[SerializeField]
		private string m_valueTypeQualifiedName;

		[NonSerialized]
		private Rect m_hoverRect;

		public bool AcceptsMultipleConnections => false;

		public bool CanBeDeleted => false;

		public bool CanBeReordered => false;

		public List<Vector2> ConnectionPoints
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<Connection> Connections
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float CurveModifier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Connection FirstConnection => null;

		public Rect HoverRect
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public string Id
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsConnected => false;

		public bool IsInput => false;

		public bool IsOutput => false;

		public bool OverrideConnection => false;

		public string NodeId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SocketName => null;

		public string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type ValueType
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		private string ValueTypeQualifiedName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Socket(Node node, string socketName, SocketDirection direction, ConnectionMode connectionMode, List<Vector2> connectionPoints, Type valueType, bool canBeDeleted, bool canBeReordered)
		{
		}

		public Socket(Socket other)
		{
		}

		public bool CanConnect(Socket other, bool ignoreValueType = false)
		{
			return false;
		}

		public bool ContainsConnection(string connectionId)
		{
			return false;
		}

		public bool ContainsConnection(Connection connection)
		{
			return false;
		}

		public void Disconnect()
		{
		}

		public void DisconnectFromNode(string nodeId)
		{
		}

		public Vector2 GetClosestConnectionPointToPosition(Vector2 position)
		{
			return default(Vector2);
		}

		public Vector2 GetClosestConnectionPointToSocket(Socket other)
		{
			return default(Vector2);
		}

		public List<string> GetConnectedNodesIds()
		{
			return null;
		}

		public List<string> GetConnectedSocketIds()
		{
			return null;
		}

		public Connection GetConnection(string connectionId)
		{
			return null;
		}

		public List<string> GetConnectionIds()
		{
			return null;
		}

		public ConnectionMode GetConnectionMode()
		{
			return default(ConnectionMode);
		}

		public SocketDirection GetDirection()
		{
			return default(SocketDirection);
		}

		public string GenerateNewId()
		{
			return null;
		}

		public float GetHeight()
		{
			return 0f;
		}

		public Vector2 GetPosition()
		{
			return default(Vector2);
		}

		public Rect GetRect()
		{
			return default(Rect);
		}

		public Vector2 GetSize()
		{
			return default(Vector2);
		}

		public float GetWidth()
		{
			return 0f;
		}

		public float GetX()
		{
			return 0f;
		}

		public float GetY()
		{
			return 0f;
		}

		public bool IsConnectedToNode(string nodeId)
		{
			return false;
		}

		public bool IsConnectedToSocket(string socketId)
		{
			return false;
		}

		public void RemoveConnection(string connectionId)
		{
		}

		public void SetHeight(float value)
		{
		}

		public void SetName(string value)
		{
		}

		public void SetPosition(Vector2 position)
		{
		}

		public void SetPosition(float x, float y)
		{
		}

		public void SetRect(Rect rect)
		{
		}

		public void SetRect(Vector2 position, Vector2 size)
		{
		}

		public void SetRect(float x, float y, float width, float height)
		{
		}

		public void SetSize(Vector2 size)
		{
		}

		public void SetSize(float width, float height)
		{
		}

		public void SetWidth(float value)
		{
		}

		public void SetX(float value)
		{
		}

		public void SetY(float value)
		{
		}

		public void UpdateHoverRect()
		{
		}
	}
}
