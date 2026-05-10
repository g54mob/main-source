using UnityEngine;

namespace CTS.Core
{
	[CreateAssetMenu(menuName = "CTS/Statistics/Types/Float")]
	public class StatisticDataFloat : StatisticData
	{
		[SerializeField]
		private float _defaultValue;

		public override IStatistic CreateStatistic()
		{
			return new FloatStatistic(_defaultValue);
		}
	}
}
