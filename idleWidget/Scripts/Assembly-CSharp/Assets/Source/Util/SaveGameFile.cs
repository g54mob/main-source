using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using LightJson;

namespace Assets.Source.Util
{
	public class SaveGameFile
	{
		public readonly FileInfo File;

		public readonly string Name;

		public DateTime Timestamp => File.LastWriteTime;

		public SaveGameFile(FileInfo file)
		{
			Name = file.Name.Replace(".save", "");
			File = file;
		}

		public void LoadSaveGame()
		{
			SaveGame.LoadState(Recall());
		}

		public JsonObject Recall()
		{
			byte[] array = null;
			using (FileStream stream = File.OpenRead())
			{
				try
				{
					using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
					using MemoryStream memoryStream = new MemoryStream();
					gZipStream.CopyTo(memoryStream);
					array = memoryStream.ToArray();
				}
				catch (IOException)
				{
				}
			}
			using (FileStream fileStream = File.OpenRead())
			{
				if (array == null)
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
				}
			}
			return JsonValue.Parse(Encoding.UTF8.GetString(array));
		}
	}
}
