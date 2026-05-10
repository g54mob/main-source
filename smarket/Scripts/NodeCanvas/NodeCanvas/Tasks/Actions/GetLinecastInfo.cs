using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Physics")]
	public class GetLinecastInfo : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<LayerMask> layerMask;

		[BlackboardOnly]
		public BBParameter<GameObject> saveHitGameObjectAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePointAs;

		[BlackboardOnly]
		public BBParameter<Vector3> saveNormalAs;

		private RaycastHit hit;

		protected override void OnExecute()
		{
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
