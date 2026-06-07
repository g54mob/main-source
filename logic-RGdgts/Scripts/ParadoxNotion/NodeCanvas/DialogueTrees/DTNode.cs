using System;
using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public abstract class DTNode : Node
	{
		[SerializeField]
		private string _actorName;

		[SerializeField]
		private string _actorParameterID;

		public override string name => null;

		public virtual bool requireActorSelection => false;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public sealed override Type outConnectionType => null;

		public sealed override bool allowAsPrime => false;

		public sealed override bool canSelfConnect => false;

		public sealed override Alignment2x2 commentsAlignment => default(Alignment2x2);

		public sealed override Alignment2x2 iconAlignment => default(Alignment2x2);

		protected DialogueTree DLGTree => null;

		public string actorName
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public IDialogueActor finalActor => null;
	}
}
