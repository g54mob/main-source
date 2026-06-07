using DV.VRTK_Extensions;

namespace DV.CabControls.VRTK
{
	public class VRTK_ControlImplBaseInteractableObject : VRTK_InteractableObject_DV
	{
		public ControlImplBase controlImplBase;

		public bool touchDisabled;

		public override bool InteractionAllowed
		{
			get
			{
				if (controlImplBase.InteractionAllowed)
				{
					return !touchDisabled;
				}
				return false;
			}
		}
	}
}
