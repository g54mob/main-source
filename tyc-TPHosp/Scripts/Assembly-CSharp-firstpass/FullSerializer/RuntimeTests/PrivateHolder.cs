namespace FullSerializer.RuntimeTests
{
	public class PrivateHolder
	{
		[fsProperty]
		private int SerializedField;

		[fsProperty]
		private int SerializedProperty { get; set; }

		public void Setup()
		{
			SerializedField = 1;
			SerializedProperty = 2;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is PrivateHolder privateHolder))
			{
				return false;
			}
			if (SerializedField == privateHolder.SerializedField)
			{
				return SerializedProperty == privateHolder.SerializedProperty;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return SerializedField.GetHashCode() + 17 * SerializedProperty.GetHashCode();
		}
	}
}
