using System.Diagnostics;
using System.IO;
using FluentAssertions.Execution;

namespace FluentAssertions.Streams
{
	[DebuggerNonUserCode]
	public class BufferedStreamAssertions : BufferedStreamAssertions<BufferedStreamAssertions>
	{
		public BufferedStreamAssertions(BufferedStream stream, AssertionChain assertionChain)
			: base(stream, assertionChain)
		{
		}
	}
	public class BufferedStreamAssertions<TAssertions> : StreamAssertions<BufferedStream, TAssertions> where TAssertions : BufferedStreamAssertions<TAssertions>
	{
		protected override string Identifier => "buffered stream";

		public BufferedStreamAssertions(BufferedStream stream, AssertionChain assertionChain)
			: base(stream, assertionChain)
		{
		}
	}
}
