namespace FluffyUnderware.DevTools
{
	public class MinMaxAttribute : DTPropertyAttribute
	{
		public readonly string MaxValueField;

		public float Min;

		public string MinBoundFieldOrPropertyName;

		public float Max;

		public string MaxBoundFieldOrPropertyName;

		public MinMaxAttribute(string maxValueField, string label = "", string tooltip = "")
			: base(null, null)
		{
		}
	}
}
