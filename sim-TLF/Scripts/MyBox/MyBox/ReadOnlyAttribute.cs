namespace MyBox
{
	public class ReadOnlyAttribute : ConditionalFieldAttribute
	{
		public ReadOnlyAttribute(string fieldToCheck, bool inverse = false, params object[] compareValues)
			: base(fieldToCheck, inverse, compareValues)
		{
		}

		public ReadOnlyAttribute(string[] fieldToCheck, bool[] inverse = null, params object[] compare)
			: base(fieldToCheck, inverse, compare)
		{
		}

		public ReadOnlyAttribute(params string[] fieldToCheck)
			: base(fieldToCheck)
		{
		}

		public ReadOnlyAttribute(bool useMethod, string method, bool inverse = false)
			: base(useMethod, method, inverse)
		{
		}
	}
}
