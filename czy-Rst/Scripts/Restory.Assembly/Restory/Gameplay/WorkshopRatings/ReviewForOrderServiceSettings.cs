using System.Collections.Generic;
using Restory.Data.Metrics;
using UnityEngine;

namespace Restory.Gameplay.WorkshopRatings
{
	[CreateAssetMenu(menuName = "Restory/WorkshopRatings/ReviewForOrderServiceSettings", fileName = "ReviewForOrderServiceSettings")]
	public class ReviewForOrderServiceSettings : ScriptableObject
	{
		[SerializeField]
		private MetricInfo comfortMetricInfo;

		[SerializeField]
		[Min(0f)]
		private int comfort = 10;

		[SerializeField]
		[Range(0f, 1f)]
		private float reviewChance = 0.5f;

		[SerializeField]
		[Min(1f)]
		private int reviewBagSize = 2;

		[SerializeField]
		private ReviewSentence[] sentences = new ReviewSentence[0];

		public MetricInfo ComfortMetricInfo => comfortMetricInfo;

		public int Comfort => comfort;

		public float ReviewChance => Mathf.Clamp01(reviewChance);

		public int ReviewBagSize => reviewBagSize;

		public IReadOnlyList<ReviewSentence> Sentences => sentences;
	}
}
