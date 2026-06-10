using System;
using NSEipix.Base;

namespace NSMedieval.Manager
{
	public class CropBlightController : MonoSingleton<CropBlightController>
	{
		public event Action<Vec3Int> BlightAddedToGridPositionEvent;

		public event Action<Vec3Int> BlightRemovedFromGridPositionEvent;

		public event Action BlightStartedEvent;

		public event Action BlightEndedEvent;

		public void BlightStarted()
		{
			this.BlightStartedEvent?.Invoke();
		}

		public void BlightEnded()
		{
			this.BlightEndedEvent?.Invoke();
		}

		public void BlightAddedToGridPosition(Vec3Int gridPosition)
		{
			this.BlightAddedToGridPositionEvent?.Invoke(gridPosition);
		}

		public void BlightRemovedFromGridPosition(Vec3Int gridPosition)
		{
			this.BlightRemovedFromGridPositionEvent?.Invoke(gridPosition);
		}
	}
}
