using UnityEngine;

namespace DV.Items
{
	public class TrainItemActivityHandlerOverrideDynamic : TrainItemActivityHandlerOverride
	{
		[Range(-1f, 5f)]
		[SerializeField]
		private int longRangeThreshold = 4;

		private int shortRangeThreshold;

		private void Awake()
		{
			shortRangeThreshold = ActivityThreshold;
		}

		public void ToggleRange(bool longRange)
		{
			ActivityThreshold = (longRange ? longRangeThreshold : shortRangeThreshold);
		}
	}
}
