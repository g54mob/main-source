using VRTK.SecondaryControllerGrabActions;

namespace DV.VRTK_Extensions
{
	public abstract class VRTK_BaseTwoHandedSecondaryGrab : VRTK_BaseGrabAction
	{
		public abstract bool CanBecomePrimary { get; }

		public abstract bool BecomePrimaryGrab();
	}
}
