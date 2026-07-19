using System;

namespace UniGLTF
{
	public interface IStorage
	{
		ArraySegment<byte> Get(string url);

		string GetPath(string url);
	}
}
