namespace Sirenix.Serialization
{
	public sealed class NullableFormatter<T> : BaseFormatter<T?> where T : struct
	{
		private static readonly Serializer<T> TSerializer;

		static NullableFormatter()
		{
		}

		protected override void DeserializeImplementation(ref T? value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref T? value, IDataWriter writer)
		{
		}
	}
}
