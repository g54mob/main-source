using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[Preserve]
	public struct DualSenseTriggerEffectFeedback : IDualSenseTriggerEffect
	{
		[SerializeField]
		private byte _position;

		[SerializeField]
		private byte _strength;

		public byte position
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte strength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType => default(DualSenseTriggerEffectType);
	}
}
