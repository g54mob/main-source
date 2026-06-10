using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum OrderAllowType
	{
		Piles = 1,
		Blueprints = 2,
		Foundations = 4,
		All = 7
	}
}
