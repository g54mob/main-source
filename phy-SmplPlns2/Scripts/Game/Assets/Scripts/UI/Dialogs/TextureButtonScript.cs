using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class TextureButtonScript : WidgetScript
	{
		private RawImageWidget _image;

		private bool _selected;

		private TexturePickerScript _texturePicker;

		public RawImageWidget RawImage => _image;

		public TexturePickerItem TextureItem { get; private set; }

		public void InitializeTextureButton(TexturePickerScript texturePicker, TexturePickerItem textureItem, int cellSize)
		{
			_texturePicker = texturePicker;
			TextureItem = textureItem;
			_image = base.Widget.FindWidget<RawImageWidget>("image");
			Texture texture = textureItem.Texture;
			if (texture != null && cellSize > 0)
			{
				float num = (float)texture.width / (float)texture.height;
				int num2 = cellSize;
				int num3 = cellSize;
				if (num > 1f)
				{
					num3 = Mathf.Max(1, Mathf.RoundToInt((float)cellSize / num));
				}
				else if (num < 1f)
				{
					num2 = Mathf.Max(1, Mathf.RoundToInt((float)cellSize * num));
				}
				RenderTexture temporary = RenderTexture.GetTemporary(num2, num3, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = temporary;
				Graphics.Blit(texture, temporary);
				Texture2D texture2D = new Texture2D(num2, num3, TextureFormat.RGBA32, mipChain: false);
				texture2D.wrapMode = TextureWrapMode.Clamp;
				texture2D.filterMode = FilterMode.Bilinear;
				texture2D.ReadPixels(new Rect(0f, 0f, num2, num3), 0, 0);
				texture2D.Apply(updateMipmaps: false);
				RenderTexture.active = active;
				RenderTexture.ReleaseTemporary(temporary);
				_image.Texture = texture2D;
			}
			else
			{
				_image.Texture = texture;
			}
			base.Widget.Tooltip = textureItem.Tooltip;
		}

		public void SetSelected(bool selected)
		{
			if (_selected != selected)
			{
				_selected = selected;
				base.Widget.EnableClass("texture-button-selected", selected);
			}
		}

		protected void OnDestroy()
		{
			if (_image != null && _image.Texture != null && _image.Texture != TextureItem.Texture)
			{
				Object.Destroy(_image.Texture);
			}
		}

		private void OnClicked(Widget widget)
		{
			_texturePicker.OnTextureButtonClicked(this);
		}
	}
}
