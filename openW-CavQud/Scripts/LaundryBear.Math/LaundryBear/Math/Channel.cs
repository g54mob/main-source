using UnityEngine;

namespace LaundryBear.Math
{
	public class Channel
	{
		public float[] _data = new float[1024];

		public Color _color = Color.white;

		public bool isActive;

		public Channel(Color _C)
		{
			_color = _C;
		}

		public void Feed(float val)
		{
			for (int num = 1023; num >= 1; num--)
			{
				_data[num] = _data[num - 1];
			}
			_data[0] = val;
		}
	}
}
