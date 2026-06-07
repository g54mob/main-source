using System.Collections.Generic;

namespace Jundroo.Common.Math
{
	public class FastAvg
	{
		private float _avg;

		private int _count;

		private int _maxValues;

		private float _sum;

		private Queue<float> _valueQueue;

		public float Avg => _avg;

		public int Count => _count;

		public float Sum => _sum;

		public FastAvg(int maxValues)
		{
			_maxValues = maxValues;
			_valueQueue = new Queue<float>(maxValues);
		}

		public float AddValue(float value)
		{
			if (_valueQueue.Count >= _maxValues)
			{
				_sum -= _valueQueue.Dequeue();
			}
			_valueQueue.Enqueue(value);
			_count = _valueQueue.Count;
			_sum += value;
			_avg = _sum / (float)_count;
			return _avg;
		}
	}
}
