using DV.Interaction.Inputs;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabberInputHandler : MonoBehaviour
	{
		private IGrabberInteractionHandler grabberInteractionHandler;

		private Grabber grabber;

		private bool isMousePressed;

		private void Awake()
		{
			grabber = GetComponent<Grabber>();
			grabberInteractionHandler = GetComponent<IGrabberInteractionHandler>();
		}

		private void Update()
		{
			grabber.DoUpdate();
			bool button = InputManager.NewPlayer.GetButton(InputManager.Actions.InteractionPrimary);
			if (button && !isMousePressed)
			{
				isMousePressed = true;
				grabberInteractionHandler.RequestStartInteraction();
			}
			else if (!button && isMousePressed)
			{
				isMousePressed = false;
				grabberInteractionHandler.RequestEndInteraction();
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Drop))
			{
				AGrabHandler currentItemHeld = grabber.CurrentItemHeld;
				if (currentItemHeld != null)
				{
					grabberInteractionHandler.RequestDrop();
					currentItemHeld.Throw(GetComponent<IPlayerRig>().GetAttachPoint().forward);
				}
			}
		}
	}
}
