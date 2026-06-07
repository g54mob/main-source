using M4.Encoding;

public class StorageActionResult
{
	public string Filename { get; private set; }

	public bool Succes { get; private set; }

	public byte[] Data { get; private set; }

	public StorageActionResult(string filename, bool succes, byte[] data = null)
	{
		Filename = filename;
		Succes = succes;
		Data = data;
	}

	public string GetDataAsNoneEncodedString()
	{
		return NoEncoding.GetString(Data);
	}
}
