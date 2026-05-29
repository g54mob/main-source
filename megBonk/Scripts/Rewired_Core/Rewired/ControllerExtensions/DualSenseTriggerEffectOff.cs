using System;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 1)]
	[Preserve]
	public struct DualSenseTriggerEffectOff : IDualSenseTriggerEffect
	{
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType => default(DualSenseTriggerEffectType);
	}
}
