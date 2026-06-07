using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class NestedDTState : FSMStateNested<DialogueTree>
	{
		[SerializeField]
		[ExposeField]
		private BBParameter<DialogueTree> _nestedDLG;

		[DimIfDefault]
		public string successEvent;

		[DimIfDefault]
		public string failureEvent;

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

		protected override void OnEnter()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnExit()
		{
		}

		private void OnDialogueFinished(bool success)
		{
		}
	}
}
