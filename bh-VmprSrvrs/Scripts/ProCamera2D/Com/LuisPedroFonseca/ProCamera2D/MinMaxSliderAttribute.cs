using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	public class MinMaxSliderAttribute : PropertyAttribute
	{
		public readonly float max;

		public readonly float min;

		public MinMaxSliderAttribute(float min, float max)
		{
		}
	}
}
