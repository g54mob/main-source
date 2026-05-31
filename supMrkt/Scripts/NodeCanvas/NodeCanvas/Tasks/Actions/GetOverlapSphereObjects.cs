using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Physics")]
	[Description("Gets a lists of game objects that are in the physics overlap sphere at the position of the agent, excluding the agent")]
	public class GetOverlapSphereObjects : ActionTask<Transform>
	{
		public LayerMask layerMask;

		public BBParameter<float> radius;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveObjectsAs;

		protected override void OnExecute()
		{
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
