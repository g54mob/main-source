using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public interface IEmailBlockableButtonHandler : IEmailButtonHandler
	{
		bool ShouldButtonBeEnabled(EmailButtonSettingsBase buttonSettings);
	}
}
