using System;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[Obsolete]
	public class ConcurrentState : FSMNode, IUpdatable, IGraphElement
	{
		[SerializeField]
		private ConditionList _conditionList;

		[SerializeField]
		private ActionList _actionList;

		[SerializeField]
		private bool _repeatStateActions;

		private bool done;

		public ConditionList conditionList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ActionList actionList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool repeatStateActions
		{
			get
			{
				return false;
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

		public override void OnGraphPaused()
		{
		}

		void IUpdatable.Update()
		{
		}
	}
}
