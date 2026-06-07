using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public interface IDualSenseExtension : IControllerVibrator, IDualShock4Extension
	{
		bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect);

		DualSenseTriggerEffectStates GetTriggerEffectStates();
	}
}
