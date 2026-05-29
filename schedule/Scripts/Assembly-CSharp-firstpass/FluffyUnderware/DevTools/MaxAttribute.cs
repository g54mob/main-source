namespace FluffyUnderware.DevTools
{
	public class MaxAttribute : DTPropertyAttribute
	{
		public float MaxValue;

		public string MaxFieldOrPropertyName;

		public MaxAttribute(float value, string label = "", string tooltip = "")
			: base(null, null)
		{
		}

		public MaxAttribute(string fieldOrProperty, string label = "", string tooltip = "")
			: base(null, null)
		{
		}
	}
}
