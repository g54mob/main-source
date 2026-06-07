using System.Collections.Generic;

namespace CLanguage.Syntax
{
	public class StructuredInitializer : Initializer
	{
		public List<Initializer> Initializers { get; private set; }

		public void Add(Initializer init)
		{
		}
	}
}
