using System.IO;
using System.IO.Compression;
using PlayFab;
using UnityEngine.Networking;

public class GzipDownloadHandler : DownloadHandlerScript
{
	private byte[] _data;

	public byte[] Data => _data;

	protected override byte[] GetData()
	{
		return _data;
	}

	protected override bool ReceiveData(byte[] data, int dataLength)
	{
		if (_data == null)
		{
			_data = data;
		}
		else
		{
			byte[] array = new byte[_data.Length + dataLength];
			_data.CopyTo(array, 0);
			data.CopyTo(array, _data.Length);
			_data = array;
		}
		return true;
	}

	protected override void CompleteContent()
	{
		try
		{
			using MemoryStream stream = new MemoryStream(_data);
			using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true);
			byte[] array = new byte[4096];
			using MemoryStream memoryStream = new MemoryStream();
			int count;
			while ((count = gZipStream.Read(array, 0, array.Length)) > 0)
			{
				memoryStream.Write(array, 0, count);
			}
			_data = memoryStream.ToArray();
		}
		catch (IOException)
		{
			PlayFabSettings.staticSettings.DecompressWithDownloadHandler = false;
		}
	}
}
