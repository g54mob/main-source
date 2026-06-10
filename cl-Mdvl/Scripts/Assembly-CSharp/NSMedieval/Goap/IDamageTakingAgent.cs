using System;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Goap
{
	public interface IDamageTakingAgent : IDamageCommonAgent, IGoapTargetable, IGameDisposable, IDisposable
	{
		DamageTakingAgentType DamageAgentType { get; }
	}
}
