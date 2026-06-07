using System.Collections.Generic;
using Assets.Scripts.UI.Dialogs;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public interface ITexturePropertyHandler
	{
		IEnumerable<TexturePickerItem> CreateItemsForTexturePicker(IConfigurableProperty property);

		Texture2D GetPreviewTexture(IConfigurableProperty property);

		void OnTextureSelected(TexturePickerItem item);
	}
}
