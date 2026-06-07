namespace Sirenix.Serialization
{
	public sealed class Int16Serializer : Serializer<short>
	{
		public override short ReadValue(IDataReader reader)
		{
			return 0;
		}

		public override void WriteValue(string name, short value, IDataWriter writer)
		{
		}
	}
}
