using System.Collections.Generic;
using Items;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.HUD
{
	public class ToolInfoViewModel : ViewModelBase
	{
		private Sprite _toolSprite;

		private string _toolText;

		public ObservableProperty<float> Progress = new ObservableProperty<float>();

		private bool _active;

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

		public string ToolText
		{
			get
			{
				return _toolText;
			}
			set
			{
				Set(ref _toolText, value, "ToolText");
			}
		}

		public bool Active
		{
			get
			{
				return _active;
			}
			set
			{
				Set(ref _active, value, "Active");
			}
		}

		public ToolInfoViewModel(List<ToolSpriteType> sprites)
		{
			_sprites = sprites;
		}

		public void SetProgress(float progress)
		{
			Progress.Value = progress;
		}

		public void SetToolType(ProgressToolType toolType)
		{
			CurrentToolSprite = _sprites.Find((ToolSpriteType x) => x.ToolType == toolType).ToolSprite;
		}
	}
}
