using System;
using UnityEngine;

namespace Doozy.Engine.Nody.Models
{
	[Serializable]
	public class Connection
	{
		[SerializeField]
		private Vector2 m_inputConnectionPoint;

		[SerializeField]
		private Vector2 m_outputConnectionPoint;

		[SerializeField]
		private string m_id;

		[SerializeField]
		private string m_inputNodeId;

		[SerializeField]
		private string m_inputSocketId;

		[SerializeField]
		private string m_outputNodeId;

		[SerializeField]
		private string m_outputSocketId;

		public bool Ping { get; set; }

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

		public string InputNodeId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string InputSocketId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string OutputNodeId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string OutputSocketId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2 InputConnectionPoint
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 OutputConnectionPoint
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Connection(Socket socket1, Socket socket2)
		{
		}

		public Connection(Connection other)
		{
		}

		public string GenerateNewId()
		{
			return null;
		}
	}
}
