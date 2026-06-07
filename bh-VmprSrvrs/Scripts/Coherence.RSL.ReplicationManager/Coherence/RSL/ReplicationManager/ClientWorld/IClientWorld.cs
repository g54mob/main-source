using System;
using System.Collections.Generic;
using Coherence.RSL.EntityManager.Commands;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.ReplicationManager.ClientWorld
{
	public interface IClientWorld : IDisposable
	{
		FloatingOrigin ProcessResponses(IReadOnlyList<ResponseInfo> responses, ref WorldProcessResult result);

		void UpdateAuthority(AuthorityChangedMessage authorityChange, ref WorldProcessResult result);
	}
}
