using NSEipix.Base;
using NSMedieval.State;

namespace NSMedieval.Controllers
{
	public class InventoryController : MonoSingleton<InventoryController>
	{
		public delegate void EquipmentHandler(EquipmentInstance equipment);

		public event EquipmentHandler OnEquipmentDestroyEvent;

		public void DestroyEquipment(EquipmentInstance equipment)
		{
			this.OnEquipmentDestroyEvent?.Invoke(equipment);
		}
	}
}
