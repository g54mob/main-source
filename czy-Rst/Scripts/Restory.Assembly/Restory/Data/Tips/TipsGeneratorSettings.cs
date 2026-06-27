using System;
using Restory.Data.WorkshopStatus;
using UnityEngine;

namespace Restory.Data.Tips
{
	[CreateAssetMenu(fileName = "TipsGeneratorSettings", menuName = "Restory/Tips/TipsGeneratorSettings")]
	public class TipsGeneratorSettings : ScriptableObject
	{
		[SerializeField]
		[Min(1f)]
		private float minTipsArgument = 200f;

		[SerializeField]
		[Min(1f)]
		private float maxTipsArgument = 1500f;

		[SerializeField]
		[Range(0f, 2f)]
		private float tipsStartAddingDelay = 0.5f;

		[SerializeField]
		[Range(0f, 2f)]
		private float delayBetweenTipsAdding = 1f;

		[SerializeField]
		private StatusInfo[] statusesForMultiplier = Array.Empty<StatusInfo>();

		[SerializeField]
		[Min(1f)]
		private float statusMultiplier = 2f;

		public float MinTipsArgument => minTipsArgument;

		public float MaxTipsArgument => maxTipsArgument;

		public float TipsStartAddingDelay => tipsStartAddingDelay;

		public float DelayBetweenTipsAdding => delayBetweenTipsAdding;

		public StatusInfo[] StatusesForMultiplier => statusesForMultiplier;

		public float StatusMultiplier => statusMultiplier;
	}
}
