public class SerializableInstantiator<T> : ISerializableInstantiator where T : SerializableBase, new()
{
	public SerializableBase Instantiate()
	{
		return new T();
	}
}
