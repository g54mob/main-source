using System;
using System.Collections.Generic;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody.Models
{
	[Serializable]
	[NodeMenu(null, 0, false, false)]
	public class Node : ScriptableObject
	{
		[SerializeField]
		private List<Socket> m_inputSockets;

		[SerializeField]
		private List<Socket> m_outputSockets;

		[SerializeField]
		private NodeType m_nodeType;

		[SerializeField]
		private bool m_allowDuplicateNodeName;

		[SerializeField]
		private bool m_allowEmptyNodeName;

		[SerializeField]
		private bool m_canBeDeleted;

		[SerializeField]
		private bool m_debugMode;

		[SerializeField]
		private bool m_useFixedUpdate;

		[SerializeField]
		private bool m_useLateUpdate;

		[SerializeField]
		private bool m_useUpdate;

		[SerializeField]
		private float m_height;

		[SerializeField]
		private float m_width;

		[SerializeField]
		private float m_x;

		[SerializeField]
		private float m_y;

		[SerializeField]
		private int m_minimumInputSocketsCount;

		[SerializeField]
		private int m_minimumOutputSocketsCount;

		[SerializeField]
		private string m_graphId;

		[SerializeField]
		private string m_id;

		[SerializeField]
		private string m_name;

		[SerializeField]
		private string m_notes;

		[NonSerialized]
		private Graph m_activeGraph;

		[NonSerialized]
		protected bool m_activated;

		protected static UILanguagePack UILabels => null;

		public bool AllowDuplicateNodeName => false;

		public bool AllowEmptyNodeName => false;

		public bool CanBeDeleted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DebugMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Ping { get; set; }

		public bool UseFixedUpdate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseLateUpdate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseUpdate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Graph ActiveGraph
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int MinimumInputSocketsCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MinimumOutputSocketsCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public List<Socket> InputSockets
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<Socket> OutputSockets
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NodeType NodeType => default(NodeType);

		public Socket FirstInputSocket => null;

		public Socket FirstOutputSocket => null;

		public string GraphId
		{
			get
			{
				return null;
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

		public string Name => null;

		protected virtual void OnEnable()
		{
		}

		public virtual void Activate(Graph portalGraph)
		{
		}

		public virtual void AddDefaultSockets()
		{
		}

		public virtual void CheckForErrors()
		{
		}

		public virtual void CopyNode(Node original)
		{
		}

		public virtual void Deactivate()
		{
		}

		public virtual float GetDefaultNodeHeight()
		{
			return 0f;
		}

		public virtual float GetDefaultNodeWidth()
		{
			return 0f;
		}

		public virtual void InitNode(Graph graph, Vector2 pos, int minimumInputSocketsCount = 1, int minimumOutputSocketsCount = 1)
		{
		}

		public virtual void OnCreate()
		{
		}

		public virtual void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public virtual void OnExit(Node nextActiveNode, Connection connection)
		{
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
			return null;
		}

		public Socket AddInputSocket(string socketName, ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
		{
			return null;
		}

		public Socket AddInputSocket(ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
		{
			return null;
		}

		public Socket AddOutputSocket(string socketName, ConnectionMode connectionMode, List<Vector2> connectionPoints, Type valueType, bool canBeDeleted, bool canBeReordered)
		{
			return null;
		}

		public Socket AddOutputSocket(string socketName, ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
		{
			return null;
		}

		public Socket AddOutputSocket(ConnectionMode connectionMode, Type valueType, bool canBeDeleted, bool canBeReordered)
		{
			return null;
		}

		private Socket AddSocket(string socketName, SocketDirection direction, ConnectionMode connectionMode, List<Vector2> connectionPoints, Type valueType, bool canBeDeleted, bool canBeReordered = true)
		{
			return null;
		}

		public bool CanDeleteSocket(Socket socket)
		{
			return false;
		}

		public bool ContainsConnection(string connectionId)
		{
			return false;
		}

		public bool ContainsSocket(string socketId)
		{
			return false;
		}

		public void Disconnect()
		{
		}

		public void DisconnectFromNode(string nodeId)
		{
		}

		public string GenerateNewId()
		{
			return null;
		}

		public Vector2 GetCenterConnectionPointPosition()
		{
			return default(Vector2);
		}

		public Connection GetConnection(string connectionId)
		{
			return null;
		}

		public List<string> GetConnectedInputNodesIds()
		{
			return null;
		}

		public List<string> GetConnectedInputSocketsIds()
		{
			return null;
		}

		public List<string> GetConnectedOutputNodesIds()
		{
			return null;
		}

		public List<string> GetConnectedOutputSocketsIds()
		{
			return null;
		}

		public Rect GetFooterRect()
		{
			return default(Rect);
		}

		public Rect GetHeaderRect()
		{
			return default(Rect);
		}

		public float GetHeight()
		{
			return 0f;
		}

		public Socket GetInputSocketFromId(string socketId)
		{
			return null;
		}

		public Socket GetInputSocketFromName(string socketName)
		{
			return null;
		}

		private List<Vector2> GetLeftAndCenterAndRightConnectionPoints()
		{
			return null;
		}

		public Vector2 GetLeftConnectionPointPosition()
		{
			return default(Vector2);
		}

		public List<Vector2> GetLeftAndRightConnectionPoints()
		{
			return null;
		}

		public Vector2 GetPosition()
		{
			return default(Vector2);
		}

		public Socket GetOutputSocketFromId(string socketId)
		{
			return null;
		}

		public Socket GetOutputSocketFromName(string socketName)
		{
			return null;
		}

		public Rect GetRect()
		{
			return default(Rect);
		}

		public Vector2 GetRightConnectionPointPosition()
		{
			return default(Vector2);
		}

		public virtual float GetWidth()
		{
			return 0f;
		}

		public Vector2 GetSize()
		{
			return default(Vector2);
		}

		public Socket GetSocketFromId(string socketId)
		{
			return null;
		}

		public Socket GetSocketFromName(string socketName)
		{
			return null;
		}

		public float GetX()
		{
			return 0f;
		}

		public float GetY()
		{
			return 0f;
		}

		public bool IsConnected()
		{
			return false;
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

		public void SetActiveGraph(Graph graph)
		{
		}

		protected void SetAllowEmptyNodeName(bool value)
		{
		}

		protected void SetAllowDuplicateNodeName(bool value)
		{
		}

		public void SetName(string value)
		{
		}

		public void SetNodeType(NodeType nodeType)
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

		public void SetHeight(float value)
		{
		}

		public void SetX(float value)
		{
		}

		public void SetY(float value)
		{
		}

		private void CheckThatNodeNameIsNotEmpty()
		{
		}
	}
}
