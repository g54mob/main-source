using System;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Theme", 50, false, false)]
	public class ThemeNode : Node, ISerializationCallbackReceiver
	{
		public Guid ThemeId;

		public Guid VariantId;

		[SerializeField]
		private byte[] ThemeIdSerializedGuid;

		[SerializeField]
		private byte[] VariantIdSerializedGuid;

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
		}

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		private void ExecuteActions()
		{
		}
	}
}
