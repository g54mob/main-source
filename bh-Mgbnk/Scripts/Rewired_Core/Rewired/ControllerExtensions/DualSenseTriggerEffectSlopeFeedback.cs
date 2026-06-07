using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[Preserve]
	public struct DualSenseTriggerEffectSlopeFeedback : IDualSenseTriggerEffect
	{
		[SerializeField]
		private byte _startPosition;

		[SerializeField]
		private byte _endPosition;

		[SerializeField]
		private byte _startStrength;

		[SerializeField]
		private byte _endStrength;

		public byte startPosition
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte endPosition
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte startStrength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte endStrength
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
