using System;
using Restory.Data.Email;
using Restory.Gameplay.RegularPayments;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class EmailButtonPaymentBillHandler : EmailButtonHandlerBase<EmailButtonPaymentBillSettings>
	{
		private readonly RegularPaymentsService regularPaymentsService;

		private readonly DeliveryPaymentsService deliveryPaymentsService;

		public EmailButtonPaymentBillHandler(RegularPaymentsService regularPaymentsService, DeliveryPaymentsService deliveryPaymentsService)
		{
			this.deliveryPaymentsService = deliveryPaymentsService;
			this.regularPaymentsService = regularPaymentsService;
		}

		protected override void HandleButtonPress(EmailButtonPaymentBillSettings buttonSettings)
		{
			switch (buttonSettings.BillProcessingOption)
			{
			case EmailButtonPaymentBillOptions.BringOnce:
				deliveryPaymentsService.SendToDelivery(buttonSettings.TargetBill);
				break;
			case EmailButtonPaymentBillOptions.AddToRegularPayments:
				regularPaymentsService.AddNewRegularPayment(buttonSettings.TargetBill);
				break;
			case EmailButtonPaymentBillOptions.RemoveFromRegularPayments:
				regularPaymentsService.RemoveExistingRegularPayment(buttonSettings.TargetBill);
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
