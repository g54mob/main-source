using UnityEngine;

namespace MK.Toon
{
	public class RangeProperty : Property<float>
	{
		private float _keywordDisabled;

		private float _minValue;

		private float _maxValue;

		public RangeProperty(Uniform uniform, string keyword, float minValue, float maxValue, float keywordDisabled = 0f)
			: base((Uniform)null, (string[])null)
		{
		}

		public RangeProperty(Uniform uniform, string keyword, float minValue, float keywordDisabled = 0f)
			: base((Uniform)null, (string[])null)
		{
		}

		public RangeProperty(Uniform uniform, float minValue, float maxValue)
			: base((Uniform)null, (string[])null)
		{
		}

		public RangeProperty(Uniform uniform, float minValue)
			: base((Uniform)null, (string[])null)
		{
		}

		public override float GetValue(Material material)
		{
			return 0f;
		}

		public override void SetValue(Material material, float value)
		{
		}
	}
}
