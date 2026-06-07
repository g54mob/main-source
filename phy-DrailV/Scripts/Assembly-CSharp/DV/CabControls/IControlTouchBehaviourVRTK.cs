using VRTK;

namespace DV.CabControls
{
	public interface IControlTouchBehaviourVRTK
	{
		void Touch(InteractableObjectEventArgs e);

		void UnTouch(InteractableObjectEventArgs e);
	}
}
