using UnityEngine;

namespace NSMedieval.State.AStar
{
	public interface IAStarAgent
	{
		Vector3 GetPosition();

		float GetMovementSpeed();
	}
}
