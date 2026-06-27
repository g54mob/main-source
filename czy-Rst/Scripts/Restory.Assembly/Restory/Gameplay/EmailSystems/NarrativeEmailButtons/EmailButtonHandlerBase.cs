using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public abstract class EmailButtonHandlerBase<TButtonSettings> : IEmailButtonHandler where TButtonSettings : EmailButtonSettingsBase
	{
		public void HandleButtonPress(EmailButtonSettingsBase buttonSettings)
		{
			HandleButtonPress(buttonSettings as TButtonSettings);
		}

		protected abstract void HandleButtonPress(TButtonSettings buttonSettings);
	}
}
