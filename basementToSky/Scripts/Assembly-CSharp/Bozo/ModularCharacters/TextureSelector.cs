using UnityEngine;
using UnityEngine.UI;

namespace Bozo.ModularCharacters
{
	public class TextureSelector : MonoBehaviour
	{
		public Image icon;

		private TexturePackage texture;

		private CharacterCreator characterCreator;

		private Button button;

		public void Init(TexturePackage texture, CharacterCreator characterCreator)
		{
			button = GetComponentInChildren<Button>();
			button.onClick.AddListener(OnSelect);
			this.texture = texture;
			this.characterCreator = characterCreator;
			icon.overrideSprite = texture.icon;
		}

		private void OnSelect()
		{
			if (texture.type == TextureType.Decal)
			{
				characterCreator.colorPickerControl.SetDecal(texture.texture, texture.colors, texture.maxScale);
			}
			if (texture.type == TextureType.Pattern)
			{
				characterCreator.colorPickerControl.SetPattern(texture.texture, texture.colors, texture.maxScale);
			}
		}

		public void SetVisable(string type)
		{
			if (texture.catagory == type)
			{
				base.gameObject.SetActive(value: true);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
