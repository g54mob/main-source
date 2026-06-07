using UnityEngine;

namespace MK.Toon
{
	public class StepProperty : Property<int>
	{
		private int _keywordDisabled;

		private int _minValue;

		private int _maxValue;

		public StepProperty(Uniform uniform, int minValue, int maxValue, string keyword, int keywordDisabled = 0)
			: base((Uniform)null, (string[])null)
		{
		}

		public StepProperty(Uniform uniform, int minValue, int maxValue)
			: base((Uniform)null, (string[])null)
		{
		}

		public override int GetValue(Material material)
		{
			return 0;
		}

		public override void SetValue(Material material, int value)
		{
		}
	}
}
