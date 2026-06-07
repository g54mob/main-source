using System;

namespace MagicaCloth2
{
	[Serializable]
	public class CheckSliderSerializeData
	{
		public float value;

		public bool use;

		public CheckSliderSerializeData()
		{
		}

		public CheckSliderSerializeData(bool use, float value)
		{
		}

		public float GetValue(float unusedValue)
		{
			return 0f;
		}

		public void SetValue(bool use, float value)
		{
		}

		public void DataValidate(float min, float max)
		{
		}

		public CheckSliderSerializeData Clone()
		{
			return null;
		}
	}
}
