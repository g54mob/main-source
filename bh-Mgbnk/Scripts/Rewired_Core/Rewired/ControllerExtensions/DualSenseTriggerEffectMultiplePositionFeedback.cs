using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[Preserve]
	public struct DualSenseTriggerEffectMultiplePositionFeedback : IDualSenseTriggerEffect
	{
		[SerializeField]
		private DualSenseTriggerEffectPositionValueSet _strength;

		public DualSenseTriggerEffectPositionValueSet strength
		{
			get
			{
				return default(DualSenseTriggerEffectPositionValueSet);
			}
			set
			{
			}
		}

		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType => default(DualSenseTriggerEffectType);
	}
}
