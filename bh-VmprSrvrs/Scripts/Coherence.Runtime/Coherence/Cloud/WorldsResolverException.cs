using System;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public class WorldsResolverException : Exception
	{
		public Result ErrorCode;

		public WorldsResolverException(Result code, string message)
		{
		}
	}
}
