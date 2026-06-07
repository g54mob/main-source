using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[Serializable]
	[Preserve]
	public struct DualSenseTriggerEffectWeapon : IDualSenseTriggerEffect
	{
		[SerializeField]
		private byte _startPosition;

		[SerializeField]
		private byte _endPosition;

		[SerializeField]
		private byte _strength;

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
