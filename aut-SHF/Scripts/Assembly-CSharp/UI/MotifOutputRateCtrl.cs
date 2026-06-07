using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace UI
{
	public class MotifOutputRateCtrl : SingletonMonoBehaviour<MotifOutputRateCtrl>
	{
		[SerializeField]
		private MotifOutputRateItem circleItem;

		[SerializeField]
		private MotifOutputRateItem triangleItem;

		[SerializeField]
		private MotifOutputRateItem squareItem;

		private double _spiritBonusRate;

		public double NowCircleRate { get; private set; }

		public double NowTriangleRate { get; private set; }

		public double NowSquareRate { get; private set; }

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public void UpdateMotifOutputRateView()
		{
		}

		public void UpdateMotifSpiritRateView()
		{
		}

		private double GetRate(List<MstUpgradeEntities> data)
		{
			return 0.0;
		}

		private double GetAddRate(List<string> rateStrList)
		{
			return 0.0;
		}
	}
}
