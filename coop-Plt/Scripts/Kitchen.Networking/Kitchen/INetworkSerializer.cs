namespace Kitchen
{
	public interface INetworkSerializer<T>
	{
		byte[] Serialize(T data);

		T Deserialize(byte[] data);
	}
}
