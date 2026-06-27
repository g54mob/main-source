using Restory.Scripts.Restory.Data.Dialogue;
using UnityEngine;

namespace Restory.Gameplay.Dialogue
{
	public class DialogueAdditionalImagesSettingsProvidingService
	{
		private readonly DialogueAdditionalImagesSettings settings;

		public DialogueAdditionalImagesSettingsProvidingService(DialogueAdditionalImagesSettings settings)
		{
			this.settings = settings;
		}

		public bool TryGetImage(string id, out Sprite image)
		{
			return settings.TryGetImage(id, out image);
		}
	}
}
