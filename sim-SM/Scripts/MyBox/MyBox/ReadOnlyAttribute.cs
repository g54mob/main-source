namespace MyBox
{
	public class ReadOnlyAttribute : ConditionalFieldAttribute
	{
		public ReadOnlyAttribute(string fieldToCheck, bool inverse = false, params object[] compareValues)
			: base(null, inverse: false, null)
		{
		}

		public ReadOnlyAttribute(string[] fieldToCheck, bool[] inverse = null, params object[] compare)
			: base(null, inverse: false, null)
		{
		}

		public ReadOnlyAttribute(params string[] fieldToCheck)
			: base(null, inverse: false, null)
		{
		}

		public ReadOnlyAttribute(bool useMethod, string method, bool inverse = false)
			: base(null, inverse: false, null)
		{
		}
	}
}
