using System;
using Ludiq;

namespace Bolt
{
	public interface IUnitValuePort : IUnitPort, IGraphItem
	{
		Type type { get; }
	}
}
