using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[Preserve]
	public struct DualSenseTriggerEffectMultiplePositionVibration : IDualSenseTriggerEffect
	{
		[SerializeField]
		private byte _frequency;

		[SerializeField]
		private DualSenseTriggerEffectPositionValueSet _amplitude;

		public byte frequency
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public DualSenseTriggerEffectPositionValueSet amplitude
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
