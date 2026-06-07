using System;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Obsolete]
	public class EnterExitState : FSMNode, IUpdatable, IGraphElement
	{
		[SerializeField]
		private ActionList _actionListEnter;

		[SerializeField]
		private ActionList _actionListExit;

		public ActionList actionListEnter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ActionList actionListExit
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string name => null;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public override bool allowAsPrime => false;

		public override void OnValidate(Graph assignedGraph)
		{
		}

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
