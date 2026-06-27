using UnityEngine;

namespace Restory.Gameplay.SaveLoad
{
	public interface IGameplaySaveLoadRegistry
	{
		void Register(GameObject objectToAdd);

		void Unregister(GameObject objectToRemove);
	}
}
