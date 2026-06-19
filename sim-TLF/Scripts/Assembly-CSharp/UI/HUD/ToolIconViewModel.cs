using System.Collections.Generic;
using Items;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.HUD
{
	internal class ToolIconViewModel : ViewModelBase
	{
		private Sprite _toolSprite;

		private bool _enabled;

		private List<ToolSpriteType> _sprites;

		public Sprite CurrentToolSprite
		{
			get
			{
				return _toolSprite;
			}
			set
			{
				Set(ref _toolSprite, value, "CurrentToolSprite");
			}
		}

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				Set(ref _enabled, value, "Enabled");
			}
		}

		public ToolIconViewModel(List<ToolSpriteType> sprites)
		{
			_sprites = sprites;
		}

		public void SetToolType(ProgressToolType toolType)
		{
			CurrentToolSprite = _sprites.Find((ToolSpriteType x) => x.ToolType == toolType).ToolSprite;
		}
	}
}
