using UnityEngine;

namespace DV.Interaction
{
	public interface IInteractionPointProvider
	{
		Transform InteractionPoint { get; }
	}
}
