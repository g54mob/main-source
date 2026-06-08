using System;
using System.IO;
using System.Text;

namespace Castle.Core.Resource
{
	public interface IResource : IDisposable
	{
		string FileBasePath { get; }

		TextReader GetStreamReader();

		TextReader GetStreamReader(Encoding encoding);

		IResource CreateRelative(string relativePath);
	}
}
