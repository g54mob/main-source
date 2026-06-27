using System;
using Restory.Gameplay.WorkOrders.EmailOrders;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class EmailOrdersServiceSaveData
	{
		public TrackedEmailOrder[] TrackedOrders;
	}
}
