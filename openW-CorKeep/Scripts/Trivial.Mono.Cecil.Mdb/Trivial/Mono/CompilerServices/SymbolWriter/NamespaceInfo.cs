using System.Collections;

namespace Trivial.Mono.CompilerServices.SymbolWriter
{
	internal class NamespaceInfo
	{
		public string Name;

		public int NamespaceID;

		public ArrayList UsingClauses = new ArrayList();
	}
}
