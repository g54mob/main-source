using System;
using System.Collections.Generic;

namespace Yarn
{
	internal class AnyType : IType
	{
		public string Name => null;

		public IType Parent => null;

		public string Description => null;

		public IReadOnlyDictionary<string, Delegate> Methods => null;
	}
}
