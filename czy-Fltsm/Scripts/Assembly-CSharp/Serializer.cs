using System.IO;
using UnityEngine;

public class Serializer : MonoBehaviour
{
	private SerializableBase _root;

	public Serializer(SerializableBase root)
	{
		_root = root;
	}

	public void Serialize(string filename)
	{
		using FileStream stream = File.OpenRead(filename);
		Serialize(stream);
	}

	public byte[] Serialize()
	{
		using MemoryStream memoryStream = new MemoryStream();
		Serialize(memoryStream);
		return memoryStream.ToArray();
	}

	private void Serialize(Stream stream)
	{
		BinaryWriter writer = new BinaryWriter(stream);
		_root.Serialize(writer);
	}
}
