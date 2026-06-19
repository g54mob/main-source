using System;
using UnityEngine;

namespace TheKiwiCoder
{
	[Serializable]
	public class SubTree : ActionNode
	{
		[Tooltip("Behaviour tree asset to run as a subtree")]
		public BehaviourTree treeAsset;

		[HideInInspector]
		public BehaviourTree treeInstance;

		public override void OnInit()
		{
			if ((bool)treeAsset)
			{
				treeInstance = treeAsset.Clone();
				treeInstance.Bind(context);
			}
		}

		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			if ((bool)treeInstance)
			{
				return treeInstance.Tick(context.tickDelta);
			}
			return State.Failure;
		}
	}
}
