namespace NSEipix.ObjectMapper
{
	public interface ISerializer<T>
	{
		void Serialize(T obj);

		T Deserialize();

		T[] DeserializeDirectory(string path);
	}
}
