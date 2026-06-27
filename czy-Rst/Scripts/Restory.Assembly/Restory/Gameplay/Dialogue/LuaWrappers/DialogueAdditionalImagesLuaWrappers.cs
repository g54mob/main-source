using System;
using PixelCrushers.DialogueSystem;
using Restory.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Dialogue.LuaWrappers
{
	public class DialogueAdditionalImagesLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string ShowImage = "Images_ShowImage";

			public static readonly string HideImage = "Images_HideImage";
		}

		private GUI_DialogueAdditionalImages dialogueAdditionalImages;

		private DialogueAdditionalImagesSettingsProvidingService settingsProvider;

		public DialogueAdditionalImagesLuaWrappers(GUI_DialogueAdditionalImages dialogueAdditionalImages, DialogueAdditionalImagesSettingsProvidingService settingsProvider)
		{
			this.dialogueAdditionalImages = dialogueAdditionalImages;
			this.settingsProvider = settingsProvider;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.ShowImage, this, SymbolExtensions.GetMethodInfo(() => ShowImage(string.Empty)));
			Lua.RegisterFunction(LuaNames.HideImage, this, SymbolExtensions.GetMethodInfo(() => HideImage()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.ShowImage);
			Lua.UnregisterFunction(LuaNames.HideImage);
		}

		private void ShowImage(string imageId)
		{
			if (!settingsProvider.TryGetImage(imageId, out var image))
			{
				Debug.LogError("[DialogueAdditionalImagesLuaWrappers] tried to show image with id '" + imageId + "', but there is no image with that id registered in settings! Check the DialogueAdditionalImagesSettings scriptable object asset!");
			}
			else
			{
				dialogueAdditionalImages.Show(image);
			}
		}

		private void HideImage()
		{
			dialogueAdditionalImages.Hide();
		}
	}
}
