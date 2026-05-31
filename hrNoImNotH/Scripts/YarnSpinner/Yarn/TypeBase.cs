using System;
using System.Collections.Generic;

namespace Yarn
{
	internal abstract class TypeBase : IType
	{
		private Dictionary<string, Delegate> methods;

		public abstract string Name { get; }

		public abstract IType Parent { get; }

		public abstract string Description { get; }

		public IReadOnlyDictionary<string, Delegate> Methods => null;

		protected TypeBase(IReadOnlyDictionary<string, Delegate> methods)
		{
		}
	}
}
