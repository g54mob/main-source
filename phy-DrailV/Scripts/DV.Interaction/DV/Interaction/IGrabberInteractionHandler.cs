using System;

namespace DV.Interaction
{
	public interface IGrabberInteractionHandler
	{
		event Action<AGrabHandler> ForceHoldRequested;

		event Action DropRequested;

		event Action StartInteractionRequested;

		event Action EndInteractionRequested;

		void RequestStartInteraction();

		void RequestEndInteraction();

		void RequestForceHold(AGrabHandler grabHandler);

		void RequestDrop();

		Grabber.Trigger? IdleStartInteraction();

		Grabber.Trigger? HoldingStartInteraction();

		Grabber.Trigger? HoldingStopInteraction();
	}
}
