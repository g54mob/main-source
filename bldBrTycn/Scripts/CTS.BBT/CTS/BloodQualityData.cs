using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Stocks/Quality Data")]
	public class BloodQualityData : ScriptableObject
	{
		public const int MinQuality = 1;

		public const int MaxQuality = 10;

		[SerializeField]
		private PercentageList<int> _repartition = new PercentageList<int>();

		public int GetRandomQuality()
		{
			return _repartition.GetWeightedRandom();
		}
	}
}
