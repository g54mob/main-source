using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	public class NestedBTState : FSMStateNested<BehaviourTree>
	{
		public enum BTExecutionMode
		{
			Once = 0,
			Repeat = 1
		}

		public enum BTExitMode
		{
			StopAndRestart = 0,
			PauseAndResume = 1
		}

		[SerializeField]
		[ExposeField]
		private BBParameter<BehaviourTree> _nestedBT;

		public BTExitMode exitMode;

		public BTExecutionMode executionMode;

		[DimIfDefault]
		public string successEvent;

		[DimIfDefault]
		public string failureEvent;

		public override BehaviourTree subGraph
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

		private void OnFinish(bool success)
		{
		}

		protected override void OnExit()
		{
		}
	}
}
