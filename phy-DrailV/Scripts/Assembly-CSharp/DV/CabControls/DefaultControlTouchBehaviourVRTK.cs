using DV.CabControls.VRTK;
using VRTK;

namespace DV.CabControls
{
	public class DefaultControlTouchBehaviourVRTK : IControlTouchBehaviourVRTK
	{
		private readonly VRTK_ControlImplBaseInteractableObject interactableObject;

		public DefaultControlTouchBehaviourVRTK(VRTK_ControlImplBaseInteractableObject interactableObject)
		{
			this.interactableObject = interactableObject;
		}

		public void Touch(InteractableObjectEventArgs e)
		{
			interactableObject.StartUsing();
		}

		public void UnTouch(InteractableObjectEventArgs e)
		{
			interactableObject.StopUsing();
		}
	}
}
