using System;
using System.Collections.Generic;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.Nody.Nodes
{
	[NodeMenu("Navigation/Switch Back", 50, false, false)]
	public class SwitchBackNode : Node
	{
		[Serializable]
		public class SourceInfo
		{
			public string SourceName;

			public string InputSocketId;

			public string OutputSocketId;

			public bool InputSocketIsConnected;

			public bool OutputSocketIsConnected;

			public bool IsConnected => false;

			public SourceInfo(string sourceName, string inputSocketId, string outputSocketId)
			{
			}
		}

		[NonSerialized]
		private Graph m_targetGraph;

		[NonSerialized]
		private string m_returnSourceOutputSocketId;

		public List<SourceInfo> Sources;

		public Socket TargetInputSocket => null;

		public Socket TargetOutputSocket => null;

		public string ReturnSourceOutputSocketId => null;

		public override void OnCreate()
		{
		}

		public override float GetDefaultNodeWidth()
		{
			return 0f;
		}

		public override void AddDefaultSockets()
		{
		}

		public void AddSourceSocketPair()
		{
		}

		protected override void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private SourceInfo GetSource(Connection connection)
		{
			return null;
		}

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void CheckForErrors()
		{
		}

		public void RegenerateSourcesSocketIds()
		{
		}
	}
}
