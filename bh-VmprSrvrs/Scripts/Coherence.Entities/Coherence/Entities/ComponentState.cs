using System;

namespace Coherence.Entities
{
	public enum ComponentState
	{
		[Obsolete]
		Construct = 1,
		Update = 2,
		Destruct = 3
	}
}
