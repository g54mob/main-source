using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
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
