using System;

namespace Loxodon.Framework.Interactivity
{
	public interface IInteractionRequest
	{
		event EventHandler<InteractionEventArgs> Raised;
	}
}
