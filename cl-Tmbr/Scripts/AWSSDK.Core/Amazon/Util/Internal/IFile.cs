using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Util.Internal
{
	public interface IFile
	{
		bool Exists(string path);

		string ReadAllText(string path);

		void WriteAllText(string path, string contents);

		void Delete(string path);

		Task<string> ReadAllTextAsync(string path, CancellationToken token = default(CancellationToken));

		Task WriteAllTextAsync(string path, string contents, CancellationToken token = default(CancellationToken));
	}
}
