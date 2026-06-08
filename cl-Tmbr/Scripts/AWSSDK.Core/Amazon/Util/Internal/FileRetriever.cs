using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Util.Internal
{
	public class FileRetriever : IFile
	{
		public bool Exists(string path)
		{
			return File.Exists(path);
		}

		public string ReadAllText(string path)
		{
			return File.ReadAllText(path);
		}

		public void WriteAllText(string path, string contents)
		{
			File.WriteAllText(path, contents);
		}

		public void Delete(string path)
		{
			File.Delete(path);
		}

		public async Task<string> ReadAllTextAsync(string path, CancellationToken token = default(CancellationToken))
		{
			using FileStream fs = File.OpenRead(path);
			using StreamReader reader = new StreamReader(fs);
			return await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task WriteAllTextAsync(string path, string contents, CancellationToken token = default(CancellationToken))
		{
			using FileStream fs = new FileStream(path, FileMode.Create);
			using StreamWriter writer = new StreamWriter(fs);
			await writer.WriteAsync(contents).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
