using System;
using System.Collections.Generic;

namespace Yarn
{
	public interface IType
	{
		string Name { get; }

		IType Parent { get; }

		string Description { get; }

		IReadOnlyDictionary<string, Delegate> Methods { get; }
	}
}
