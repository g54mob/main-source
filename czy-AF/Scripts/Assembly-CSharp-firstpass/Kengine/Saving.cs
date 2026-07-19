using System.IO;
using System.IO.Compression;
using System.Text;
using UnityEngine;

namespace Kengine
{
	public class Saving : MonoBehaviour
	{
		public static void SaveString(string data, string path)
		{
			byte[] bytes = Zip(data);
			File.WriteAllBytes(path, bytes);
		}

		public static void SaveStringUncompressed(string data, string path)
		{
			File.WriteAllText(path, data);
		}

		public static string LoadString(string path)
		{
			return Unzip(File.ReadAllBytes(path));
		}

		public static string LoadStringUncompressed(string path)
		{
			return File.ReadAllText(path);
		}

		public static void SaveObject(object obj, string path)
		{
			byte[] bytes = Zip(JsonUtility.ToJson(obj));
			File.WriteAllBytes(path, bytes);
		}

		public static void SaveObjectUncompressed(object obj, string path)
		{
			File.WriteAllText(path, JsonUtility.ToJson(obj));
		}

		public static Type LoadObject<Type>(string path)
		{
			return JsonUtility.FromJson<Type>(Unzip(File.ReadAllBytes(path)));
		}

		public static Type LoadObjectUncompressed<Type>(string path)
		{
			return JsonUtility.FromJson<Type>(File.ReadAllText(path));
		}

		public static void CopyTo(Stream src, Stream dest)
		{
			byte[] array = new byte[4096];
			int count;
			while ((count = src.Read(array, 0, array.Length)) != 0)
			{
				dest.Write(array, 0, count);
			}
		}

		public static byte[] Zip(string str)
		{
			using MemoryStream src = new MemoryStream(Encoding.UTF8.GetBytes(str));
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream dest = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				CopyTo(src, dest);
			}
			return memoryStream.ToArray();
		}

		public static string Unzip(byte[] bytes)
		{
			using MemoryStream stream = new MemoryStream(bytes);
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream src = new GZipStream(stream, CompressionMode.Decompress))
			{
				CopyTo(src, memoryStream);
			}
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
	}
}
