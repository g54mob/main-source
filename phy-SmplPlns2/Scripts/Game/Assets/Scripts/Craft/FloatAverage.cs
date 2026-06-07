using System.Collections.Generic;

namespace Assets.Scripts.Craft
{
	public class FloatAverage
	{
		private List<float> _list;

		private int _max;

		public float Value
		{
			get
			{
				float num = 0f;
				if (_list.Count > 0)
				{
					foreach (float item in _list)
					{
						num += item;
					}
					num /= (float)_list.Count;
				}
				return num;
			}
		}

		public FloatAverage(int max)
		{
			_max = max;
			_list = new List<float>();
		}

		public void Add(float v)
		{
			_list.Add(v);
			while (_list.Count > _max)
			{
				_list.RemoveAt(0);
			}
		}
	}
}
