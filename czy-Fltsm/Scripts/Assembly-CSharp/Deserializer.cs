using System.IO;

public class Deserializer<T> where T : SerializableBase, new()
{
	public T Root { get; private set; }

	public T Deserialize(string filename)
	{
		using (FileStream stream = File.OpenRead(filename))
		{
			Deserialize(stream);
		}
		return Root;
	}

	public T Deserialize(byte[] buffer)
	{
		using (MemoryStream stream = new MemoryStream(buffer))
		{
			Deserialize(stream);
		}
		return Root;
	}

	private void Deserialize(Stream stream)
	{
		BinaryReader reader = new BinaryReader(stream);
		Root = new T();
		Root.Deserialize(reader, isRoot: true);
	}
}
