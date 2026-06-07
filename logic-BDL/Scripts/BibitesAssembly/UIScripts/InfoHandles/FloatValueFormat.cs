using ScriptHelpers;

namespace UIScripts.InfoHandles
{
	public class FloatValueFormat
	{
		public string prefix = "";

		public string units = "";

		public int precision = 1;

		public float factor = 1f;

		public bool SI = true;

		public bool alwaysShowSign;

		public bool precisionIsSI;

		public bool isInt;

		public static FloatValueFormat percentage = new FloatValueFormat
		{
			units = "%",
			factor = 100f,
			SI = false,
			precision = 1
		};

		public string Format(float val)
		{
			string text = (SI ? val : (val * factor)).ScientificFormat(precision, units, alwaysShowSign, SIUnits: SI, prefixWithUnits: !isInt, scientificPrecision: precisionIsSI && !isInt, isInt: isInt);
			return prefix + text;
		}
	}
}
