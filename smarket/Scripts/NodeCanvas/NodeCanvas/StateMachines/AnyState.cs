using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Name("Any State", 0)]
	[Description("The transitions of this node will be constantly checked. If any becomes true, that transition will take place. This is not a state.")]
	[Color("b3ff7f")]
	public class AnyState : FSMNode, IUpdatable, IGraphElement
	{
		[Tooltip("If enabled, a transition to an already running state will not happen.")]
		public bool dontRetriggerStates;

		public override string name => null;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public override bool allowAsPrime => false;

		public override void OnGraphStarted()
		{
		}

		public override void OnGraphStoped()
		{
		}

		void IUpdatable.Update()
		{
		}
	}
}
