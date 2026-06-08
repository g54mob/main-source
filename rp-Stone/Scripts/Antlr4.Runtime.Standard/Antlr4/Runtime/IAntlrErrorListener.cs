using System.IO;

namespace Antlr4.Runtime
{
	public interface IAntlrErrorListener<in TSymbol>
	{
		void SyntaxError(TextWriter output, IRecognizer recognizer, TSymbol offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e);
	}
}
