using System;
using Factory;

namespace Popups
{
	public abstract class AbstractConfirmationPopup : BasePopup
	{
		public abstract void Initialise(IScope scope, StringId mainPromptStringId, Action onNoPressed, Action onYesPressed, StringId additionalInfoStringId = StringId.None);

		public abstract void Initialise(IScope scope, StringId mainPromptStringId, Action onClosed, StringId additionalInfoStringId = StringId.None);
	}
}
