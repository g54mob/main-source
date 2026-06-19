using System.Collections.Generic;

namespace TH20
{
	public class QueuePathManager : MustCallDestroy
	{
		private const float ProcessFrequency = 0.25f;

		private readonly List<QueuePath> _queues = new List<QueuePath>();

		private float _lastTimeProcessed;

		private int _indexToProcess;

		public void Add(QueuePath queuePath)
		{
			FloorPlan floorPlan = queuePath.FloorPlan;
			if (floorPlan != null && !floorPlan.Definition.IsHospitalOrBay && !floorPlan.Definition.IsHospitalUnbuilt)
			{
				_queues.AddUnique(queuePath);
			}
		}

		public void Remove(QueuePath queuePath)
		{
			int num = _queues.IndexOf(queuePath);
			if (num >= 0)
			{
				_queues.RemoveAt(num);
				if (num != 0 && _indexToProcess >= num)
				{
					_indexToProcess--;
				}
			}
		}

		public void Tick()
		{
			float unscaledTime = GameTime.unscaledTime;
			if (_queues.Count != 0 && _lastTimeProcessed + 0.25f < unscaledTime)
			{
				int num = _indexToProcess;
				if (num >= _queues.Count)
				{
					num = 0;
				}
				_queues[num].CalculateQueue();
				_indexToProcess = num + 1;
				_lastTimeProcessed = unscaledTime;
			}
		}
	}
}
