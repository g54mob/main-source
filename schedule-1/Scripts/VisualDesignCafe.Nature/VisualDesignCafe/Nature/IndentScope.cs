using System;

namespace VisualDesignCafe.Nature
{
	internal class IndentScope : IDisposable
	{
		private readonly ILog _log;

		private readonly bool _brackets;

		public IndentScope(ILog log, string message = null, bool brackets = false)
		{
		}

		public void Dispose()
		{
		}
	}
}
