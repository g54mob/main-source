using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public class MultipleChoiceNode : DTNode
	{
		[Serializable]
		public class Choice
		{
			public bool isUnfolded;

			public Statement statement;

			public ConditionTask condition;

			public Choice()
			{
			}

			public Choice(Statement statement)
			{
			}
		}

		public float availableTime;

		public bool saySelection;

		[SerializeField]
		[AutoSortWithChildrenConnections]
		private List<Choice> availableChoices;

		public override int maxOutConnections => 0;

		public override bool requireActorSelection => false;

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}

		private void OnOptionSelected(int index)
		{
		}
	}
}
