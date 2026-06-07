using UnityEngine;

namespace Assets.Scripts.Craft.FlightData
{
	public class LazyData
	{
		private int _lastUpdateFrame = -1000;

		public int UpdatePeriod { get; set; }

		public void ForceUpdate()
		{
			UpdateData();
		}

		public void OnAccessed()
		{
			int num = Time.frameCount - _lastUpdateFrame;
			if (num >= UpdatePeriod || num < 0)
			{
				UpdateData();
			}
		}

		protected virtual void UpdateData()
		{
			_lastUpdateFrame = Time.frameCount;
		}
	}
}
