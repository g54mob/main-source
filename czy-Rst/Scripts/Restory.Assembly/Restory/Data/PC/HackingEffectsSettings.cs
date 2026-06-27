using System;
using UnityEngine;

namespace Restory.Data.PC
{
	[Serializable]
	public class HackingEffectsSettings
	{
		[Header("Effects")]
		[SerializeField]
		[Range(1f, 100f)]
		private float effectFrequencyInSeconds = 5f;

		[SerializeField]
		[Range(1f, 100f)]
		private float effectsDurationInSeconds = 5f;

		public float EffectFrequencyInSeconds => effectFrequencyInSeconds;

		public float EffectDurationInSeconds => effectsDurationInSeconds;
	}
}
