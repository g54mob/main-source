using System;
using NSEipix.Base;

namespace NSMedieval.Destruction
{
	public class DestructionController : MonoSingleton<DestructionController>
	{
		public event Action<Vec3Int> ObjectDestroyedCheckFallDownEvent;

		public void ObjectDestroyedCheckFallDown(Vec3Int gridPosition)
		{
			this.ObjectDestroyedCheckFallDownEvent?.Invoke(gridPosition);
		}
	}
}
