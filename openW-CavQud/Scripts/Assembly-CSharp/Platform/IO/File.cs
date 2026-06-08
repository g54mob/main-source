using System.IO;
using System.Text;
using System.Threading.Tasks;
using LaundryBear.PlatformServices;
using Newtonsoft.Json;

namespace Platform.IO
{
	public static class File
	{
		public static void WriteAllBytes(string path, byte[] content)
		{
			Blob.WriteAllBytes(path, content).ThrowIfFailed();
		}

		public static async Task WriteAllBytesAsync(string path, byte[] content)
		{
			(await Blob.WriteAllBytesAsync(path, content)).ThrowIfFailed();
		}

		public static void WriteAllText(string path, string content)
		{
			Blob.WriteAllText(path, content).ThrowIfFailed();
		}

		public static async Task WriteAllTextAsync(string path, string content)
		{
			(await Blob.WriteAllTextAsync(path, content)).ThrowIfFailed();
		}

		public static byte[] ReadAllBytes(string path)
		{
			return Blob.ReadAllBytes(path).ThrowIfFailed().content;
		}

		public static async Task<byte[]> ReadAllBytesAsync(string path)
		{
			return (await Blob.ReadAllBytesAsync(path)).ThrowIfFailed().content;
		}

		public static string ReadAllText(string path)
		{
			return Blob.ReadAllText(path).ThrowIfFailed().content;
		}

		public static async Task<string> ReadAllTextAsync(string path)
		{
			return (await Blob.ReadAllTextAsync(path)).ThrowIfFailed().content;
		}

		public static FileInfo GetInfo(string path)
		{
			return new FileInfo(path);
		}

		public static bool Exists(string path)
		{
			return Blob.Exists(path).WasSuccessful();
		}

		public static async Task<bool> ExistsAsync(string path)
		{
			return (await Blob.ExistsAsync(path)).WasSuccessful();
		}

		public static void Delete(string path)
		{
			Blob.Delete(path).ThrowIfFailed();
		}

		public static async Task<StorageResult> DeleteAsync(string path)
		{
			return (await Blob.DeleteAsync(path)).ThrowIfFailed();
		}

		public static async Task CopyAsync(string sourceFileName, string destFileName, bool overwrite = false)
		{
			(await Blob.CopyAsync(sourceFileName, destFileName, overwrite)).ThrowIfFailed();
		}

		public static void Copy(string sourceFileName, string destFileName, bool overwrite = false)
		{
			Blob.Copy(sourceFileName, destFileName, overwrite).ThrowIfFailed();
		}

		public static async Task MoveAsync(string sourceFileName, string destFileName, bool overwrite = false)
		{
			(await Blob.MoveAsync(sourceFileName, destFileName, overwrite)).ThrowIfFailed();
		}

		public static void Move(string sourceFileName, string destFileName, bool overwrite = false)
		{
			Blob.Move(sourceFileName, destFileName, overwrite).ThrowIfFailed();
		}

		public static Stream Open(string path, FileMode mode, FileAccess access, FileShare fileShare)
		{
			return Blob.Open(path, mode, access, fileShare).ThrowIfFailed().content;
		}

		public static async Task<Stream> OpenAsync(string path, FileMode mode, FileAccess access)
		{
			return (await Blob.OpenAsync(path, mode, access)).ThrowIfFailed().content;
		}

		public static Stream OpenRead(string path)
		{
			return Blob.OpenRead(path).ThrowIfFailed().content;
		}

		public static async Task<Stream> OpenReadAsync(string path)
		{
			return (await Blob.OpenReadAsync(path)).ThrowIfFailed().content;
		}

		public static Stream OpenWrite(string path)
		{
			return Blob.OpenWrite(path).ThrowIfFailed().content;
		}

		public static async Task<Stream> OpenWriteAsync(string path)
		{
			return (await Blob.OpenWriteAsync(path)).ThrowIfFailed().content;
		}

		public static void AppendAllText(string path, string content)
		{
			using Stream stream = OpenWrite(path);
			stream.Seek(0L, SeekOrigin.End);
			stream.Write(Encoding.UTF8.GetBytes(content));
		}

		public static StreamWriter CreateText(string path)
		{
			return new StreamWriter(OpenWrite(path));
		}

		public static void WriteAllJson(string path, object content, JsonSerializerSettings settings = null)
		{
			Blob.WriteAllJson(path, content, settings).ThrowIfFailed();
		}

		public static async Task WriteAllJsonAsync(string path, object content, JsonSerializerSettings settings = null)
		{
			(await Blob.WriteAllJsonAsync(path, content, settings)).ThrowIfFailed();
		}

		public static T ReadAllJson<T>(string path, JsonSerializerSettings settings = null)
		{
			return Blob.ReadAllJson<T>(path, settings).ThrowIfFailed().content;
		}

		public static async Task<T> ReadAllJsonAsync<T>(string path, JsonSerializerSettings settings = null)
		{
			return (await Blob.ReadJsonAsync<T>(path, settings)).ThrowIfFailed().content;
		}
	}
}
