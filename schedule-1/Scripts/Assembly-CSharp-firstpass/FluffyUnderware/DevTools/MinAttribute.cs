namespace FluffyUnderware.DevTools
{
	public class MinAttribute : DTPropertyAttribute
	{
		public float MinValue;

		public string MinFieldOrPropertyName;

		public MinAttribute(float value, string label = "", string tooltip = "")
			: base(null, null)
		{
		}

		public MinAttribute(string fieldOrProperty, string label = "", string tooltip = "")
			: base(null, null)
		{
		}
	}
}
