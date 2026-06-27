using Restory.Data.Email;
using Restory.Gameplay.Inventory;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class EmailButtonSubtractMoneyHandler : EmailBlockableButtonHandlerBase<EmailButtonSubtractMoneySettings>
	{
		private readonly Wallet wallet;

		public EmailButtonSubtractMoneyHandler(Wallet wallet)
		{
			this.wallet = wallet;
		}

		protected override void HandleButtonPress(EmailButtonSubtractMoneySettings buttonSettings)
		{
			wallet.TryToRemove(buttonSettings.SumToSubtract);
		}

		protected override bool ShouldButtonBeEnabled(EmailButtonSubtractMoneySettings buttonPressAction)
		{
			return wallet.MoneyAvailable >= buttonPressAction.SumToSubtract;
		}
	}
}
