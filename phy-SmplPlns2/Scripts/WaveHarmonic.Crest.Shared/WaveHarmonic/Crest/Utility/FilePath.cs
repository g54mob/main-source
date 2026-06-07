using System;

namespace WaveHarmonic.Crest.Utility
{
	[AttributeUsage(AttributeTargets.Class)]
	internal sealed class FilePath : Attribute
	{
		public readonly string _Path;

		public FilePath(string path)
		{
			_Path = path;
		}
	}
}
