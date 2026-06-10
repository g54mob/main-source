using NSMedieval.Components;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IStorageAgent
	{
		Storage Storage { get; }

		Storage FoodStorage { get; }

		Vector3 GetPosition();

		void DropStorage(Vec3Int position = default(Vec3Int));

		void ConsumeStorage();
	}
}
