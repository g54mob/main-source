using System;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public class MatchMakerException : Exception
	{
		public Result ErrorCode;

		public MatchMakerException(Result code, string message)
		{
		}
	}
}
