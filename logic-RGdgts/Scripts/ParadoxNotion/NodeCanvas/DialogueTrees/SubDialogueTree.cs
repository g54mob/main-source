using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public class SubDialogueTree : DTNodeNested<DialogueTree>, IUpdatable, IGraphElement
	{
		[SerializeField]
		[ExposeField]
		private BBParameter<DialogueTree> _subTree;

		[fsSerializeAs]
		private Dictionary<string, string> _actorParametersMap;

		public override int maxOutConnections => 0;

		public override DialogueTree subGraph
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override BBParameter subGraphParameter => null;

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}

		private void OnSubDialogueFinish(bool success)
		{
		}

		void IUpdatable.Update()
		{
		}

		private void TryWriteMappedActorParameters()
		{
		}
	}
}
