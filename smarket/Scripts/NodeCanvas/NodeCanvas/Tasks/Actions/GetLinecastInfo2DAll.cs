using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Physics")]
	[Description("Get hit info for ALL objects in the linecast, in Lists")]
	public class GetLinecastInfo2DAll : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public LayerMask mask;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> saveHitGameObjectsAs;

		[BlackboardOnly]
		public BBParameter<List<float>> saveDistancesAs;

		[BlackboardOnly]
		public BBParameter<List<Vector3>> savePointsAs;

		[BlackboardOnly]
		public BBParameter<List<Vector3>> saveNormalsAs;

		private RaycastHit2D[] hits;

		protected override void OnExecute()
		{
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
