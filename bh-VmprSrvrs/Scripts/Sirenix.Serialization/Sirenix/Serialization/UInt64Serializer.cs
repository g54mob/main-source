namespace Sirenix.Serialization
{
	public sealed class UInt64Serializer : Serializer<ulong>
	{
		public override ulong ReadValue(IDataReader reader)
		{
			return 0uL;
		}

		public override void WriteValue(string name, ulong value, IDataWriter writer)
		{
		}
	}
}
