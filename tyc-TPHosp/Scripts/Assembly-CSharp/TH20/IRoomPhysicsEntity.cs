using UnityEngine;

namespace TH20
{
	public interface IRoomPhysicsEntity
	{
		Transform GetTransform();

		void DestroyEntity();
	}
}
