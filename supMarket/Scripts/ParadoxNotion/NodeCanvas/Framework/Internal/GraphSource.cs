using System;
using System.Collections.Generic;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	[fsDeserializeOverwrite]
	public class GraphSource : ISerializationCollector, ISerializationCollectable
	{
		public const float FRAMEWORK_VERSION = 3.3f;

		[SerializeField]
		[fsSerializeAs("version")]
		[fsWriteOnly]
		[fsIgnoreInBuild]
		private float _version;

		[SerializeField]
		[fsSerializeAs("category")]
		[fsWriteOnly]
		[fsIgnoreInBuild]
		private string _category;

		[SerializeField]
		[fsSerializeAs("comments")]
		[fsWriteOnly]
		[fsIgnoreInBuild]
		private string _comments;

		[SerializeField]
		[fsSerializeAs("translation")]
		[fsWriteOnly]
		[fsIgnoreInBuild]
		private Vector2 _translation;

		[SerializeField]
		[fsSerializeAs("zoomFactor")]
		[fsWriteOnly]
		[fsIgnoreInBuild]
		private float _zoomFactor;

		[fsSerializeAs("type")]
		private string _type;

		[fsSerializeAs("nodes")]
		private List<Node> _nodes;

		[fsSerializeAs("connections")]
		private List<Connection> _connections;

		[fsSerializeAs("canvasGroups")]
		[fsIgnoreInBuild]
		private List<CanvasGroup> _canvasGroups;

		[fsSerializeAs("localBlackboard")]
		private BlackboardSource _localBlackboard;

		[fsSerializeAs("derivedData")]
		private object _derivedData;

		public List<Task> allTasks { get; private set; }

		public List<BBParameter> allParameters { get; private set; }

		public float version
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string category
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string comments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2 translation
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float zoomFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string type
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<Node> nodes
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<Connection> connections
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public List<CanvasGroup> canvasGroups
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BlackboardSource localBlackboard
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object derivedData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		void ISerializationCollector.OnPush(ISerializationCollector parent)
		{
		}

		void ISerializationCollector.OnCollect(ISerializationCollectable child, int depth)
		{
		}

		void ISerializationCollector.OnPop(ISerializationCollector parent)
		{
		}

		public GraphSource Pack(Graph graph)
		{
			return null;
		}

		public GraphSource Unpack(Graph graph)
		{
			return null;
		}

		public GraphSource SetMetaData(GraphSource source)
		{
			return null;
		}

		public void PurgeRedundantReferences()
		{
		}
	}
}
