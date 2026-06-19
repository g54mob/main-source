using UnityEngine;

namespace Items
{
	public abstract class ConsumableObject : ScriptableObject
	{
		public abstract void Consume(UsableConsumableItem consumableItem);

		public abstract void TryUnuse();
	}
}
