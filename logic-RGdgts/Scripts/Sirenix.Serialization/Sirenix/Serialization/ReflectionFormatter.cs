namespace Sirenix.Serialization
{
	public class ReflectionFormatter<T> : BaseFormatter<T>
	{
		public ISerializationPolicy OverridePolicy { get; private set; }

		public ReflectionFormatter()
		{
		}

		public ReflectionFormatter(ISerializationPolicy overridePolicy)
		{
		}

		protected override void DeserializeImplementation(ref T value, IDataReader reader)
		{
		}

		protected override void SerializeImplementation(ref T value, IDataWriter writer)
		{
		}
	}
}
