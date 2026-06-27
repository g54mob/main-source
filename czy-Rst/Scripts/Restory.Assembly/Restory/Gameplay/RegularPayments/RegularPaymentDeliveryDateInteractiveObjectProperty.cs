using System;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.RegularPayments
{
	[Serializable]
	public class RegularPaymentDeliveryDateInteractiveObjectProperty : InteractiveObjectAdditionalProperty
	{
		[SerializeField]
		private DateTime deliveryTime;

		public DateTime DeliveryTime => deliveryTime;

		public RegularPaymentDeliveryDateInteractiveObjectProperty(DateTime deliveryTime)
		{
			this.deliveryTime = deliveryTime;
		}

		private void AddDays(int days)
		{
			deliveryTime = deliveryTime.AddDays(days);
		}
	}
}
