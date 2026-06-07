using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Grab Attach Mechanics/VRTK_ClimbableGrabAttach")]
	public class VRTK_ClimbableGrabAttach : VRTK_BaseGrabAttach
	{
		[Header("Climbable Settings", order = 2)]
		[Tooltip("Will respect the grabbed climbing object's rotation if it changes dynamically")]
		public bool useObjectRotation;

		protected override void Initialise()
		{
			tracked = false;
			climbable = true;
			kinematic = true;
		}
	}
}
