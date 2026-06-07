using System;
using UnityEngine;

namespace Assets.Scripts.UI.Dialogs
{
	public class TexturePickerItem
	{
		private Func<Texture2D> _loadTexture;

		private Texture2D _texture;

		public string Category { get; }

		public string Id { get; }

		public Texture2D Texture
		{
			get
			{
				if (_texture == null)
				{
					_texture = _loadTexture();
				}
				return _texture;
			}
		}

		public string Tooltip { get; }

		public TexturePickerItem(string id, Func<Texture2D> loadTexture, string category, string tooltip)
		{
			Id = id;
			_loadTexture = loadTexture;
			Category = category;
			Tooltip = tooltip;
		}
	}
}
