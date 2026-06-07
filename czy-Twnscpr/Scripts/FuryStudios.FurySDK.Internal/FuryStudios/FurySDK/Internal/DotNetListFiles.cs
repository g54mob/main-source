using System.Collections.Generic;

namespace FuryStudios.FurySDK.Internal
{
	public class DotNetListFiles : AsyncRequest<IList<string>>
	{
		private static readonly char[] directorySeparators;

		private readonly string rootPath;

		public DotNetListFiles(string rootPath)
		{
		}

		protected override void OnStarted()
		{
		}
	}
}
