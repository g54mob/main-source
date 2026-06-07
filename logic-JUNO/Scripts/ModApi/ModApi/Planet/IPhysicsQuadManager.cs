using UnityEngine;

namespace ModApi.Planet
{
	public interface IPhysicsQuadManager
	{
		void RegisterPhysicsPosition(Vector3d position, int subdivisionLevel, int quadRadiusSynchronous, int quadRadiusAsynchronous);
	}
}
