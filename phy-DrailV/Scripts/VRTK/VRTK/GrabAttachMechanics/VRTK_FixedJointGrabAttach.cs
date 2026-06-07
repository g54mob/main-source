using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Grab Attach Mechanics/VRTK_FixedJointGrabAttach")]
	public class VRTK_FixedJointGrabAttach : VRTK_BaseJointGrabAttach
	{
		[Tooltip("Maximum force the Joint can withstand before breaking. Setting to `infinity` ensures the Joint is unbreakable.")]
		public float breakForce = 1500f;

		protected override void CreateJoint(GameObject obj)
		{
			givenJoint = obj.AddComponent<FixedJoint>();
			givenJoint.breakForce = (grabbedObjectScript.IsDroppable() ? breakForce : float.PositiveInfinity);
			base.CreateJoint(obj);
		}
	}
}
