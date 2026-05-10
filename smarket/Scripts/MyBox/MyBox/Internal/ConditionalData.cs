namespace MyBox.Internal
{
	public class ConditionalData
	{
		private readonly string _fieldToCheck;

		private readonly bool _inverse;

		private readonly string[] _compareValues;

		private readonly string[] _fieldsToCheckMultiple;

		private readonly bool[] _inverseMultiple;

		private readonly string[] _compareValuesMultiple;

		private readonly string _predicateMethod;

		public bool IsSet => false;

		public ConditionalData(string fieldToCheck, bool inverse = false, params object[] compareValues)
		{
		}

		public ConditionalData(string[] fieldToCheck, bool[] inverse = null, params object[] compare)
		{
		}

		public ConditionalData(params string[] fieldToCheck)
		{
		}

		public ConditionalData(bool useMethod, string methodName, bool inverse = false)
		{
		}
	}
}
