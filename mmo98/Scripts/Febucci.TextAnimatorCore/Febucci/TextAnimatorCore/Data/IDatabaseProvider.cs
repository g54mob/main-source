using System.Collections.Generic;

namespace Febucci.TextAnimatorCore.Data
{
	public interface IDatabaseProvider<TType>
	{
		Dictionary<string, TType> Database { get; }
	}
}
