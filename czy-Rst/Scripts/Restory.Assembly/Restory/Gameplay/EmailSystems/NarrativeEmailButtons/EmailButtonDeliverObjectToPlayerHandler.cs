using Restory.Data.Email;
using Restory.Gameplay.Delivery;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class EmailButtonDeliverObjectToPlayerHandler : EmailButtonHandlerBase<EmailButtonDeliverObjectToPlayerSettings>
	{
		private readonly DeliveryService deliveryService;

		public EmailButtonDeliverObjectToPlayerHandler(DeliveryService deliveryService)
		{
			this.deliveryService = deliveryService;
		}

		protected override void HandleButtonPress(EmailButtonDeliverObjectToPlayerSettings buttonSettings)
		{
			deliveryService.SendToDelivery(buttonSettings.ObjectToDeliver);
		}
	}
}
