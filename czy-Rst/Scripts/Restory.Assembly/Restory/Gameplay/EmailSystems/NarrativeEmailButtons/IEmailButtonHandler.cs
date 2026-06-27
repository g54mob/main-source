using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public interface IEmailButtonHandler
	{
		void HandleButtonPress(EmailButtonSettingsBase buttonSettings);
	}
}
