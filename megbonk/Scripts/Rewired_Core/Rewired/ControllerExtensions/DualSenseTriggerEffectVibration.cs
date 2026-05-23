using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[Preserve]
	public struct DualSenseTriggerEffectVibration : IDualSenseTriggerEffect
	{
		[SerializeField]
		private byte _position;

		[SerializeField]
		private byte _amplitude;

		[SerializeField]
		private byte _frequency;

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

		public byte amplitude
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

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

		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType => default(DualSenseTriggerEffectType);
	}
}
