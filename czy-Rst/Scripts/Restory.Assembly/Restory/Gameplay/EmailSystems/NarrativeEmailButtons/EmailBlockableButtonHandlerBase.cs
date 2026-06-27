using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public abstract class EmailBlockableButtonHandlerBase<TButtonSettings> : EmailButtonHandlerBase<TButtonSettings>, IEmailBlockableButtonHandler, IEmailButtonHandler where TButtonSettings : EmailBlockableButtonSettingsBase
	{
		public bool ShouldButtonBeEnabled(EmailButtonSettingsBase buttonSettings)
		{
			return ShouldButtonBeEnabled(buttonSettings as TButtonSettings);
		}

		protected virtual bool ShouldButtonBeEnabled(TButtonSettings buttonSettings)
		{
			return true;
		}
	}
}
