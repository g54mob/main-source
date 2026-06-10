using System;
using NSEipix.Base;
using NSMedieval.Model;

namespace NSMedieval.Controllers
{
	public class PenController : MonoSingleton<PenController>
	{
		public event Action<AnimalPenInstance> OnPenAddedEvent;

		public event Action<AnimalPenInstance> OnPenRemovedEvent;

		public event Action<AnimalPenInstance> OnPenRegionRefreshedEvent;

		public void PenAdded(AnimalPenInstance pen)
		{
			this.OnPenAddedEvent?.Invoke(pen);
		}

		public void PenRemoved(AnimalPenInstance pen)
		{
			this.OnPenRemovedEvent?.Invoke(pen);
		}

		public void PenRegionRefreshed(AnimalPenInstance pen)
		{
			this.OnPenRegionRefreshedEvent?.Invoke(pen);
		}
	}
}
