using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Name("Target In Line Of Sight", 0)]
	[Category("GameObject")]
	[Description("Check of agent is in line of sight with target by doing a linecast and optionaly save the distance")]
	public class CheckLOS : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> LOSTarget;

		public BBParameter<LayerMask> layerMask;

		public Vector3 offset;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		private RaycastHit hit;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
