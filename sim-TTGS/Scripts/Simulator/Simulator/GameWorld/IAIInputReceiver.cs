using UnityEngine;

namespace Simulator.GameWorld
{
	public interface IAIInputReceiver
	{
		void OnAIInput_Look(Vector3 lookDirection);

		void OnAIInput_Move(Vector3 position);

		void OnAIInput_IsWalking(bool walking);

		void OnAIInput_MainInteraction(ISensable sensable);

		void OnAIInput_SecondaryInteraction(ISensable sensable);
	}
}
