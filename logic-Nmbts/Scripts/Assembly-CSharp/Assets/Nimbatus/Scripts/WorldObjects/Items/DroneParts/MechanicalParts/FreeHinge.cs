using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class FreeHinge : DronePart
	{
		protected override void Awake()
		{
			IndividualJoint = true;
			base.Awake();
			Joint = GetComponent<HingeJoint>();
			Joint.breakForce = 40000f;
		}

		public override string GetDetailedTooltip()
		{
			return base.GetDetailedTooltip();
		}
	}
}
