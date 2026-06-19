using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.Map
{
	public class MapIndicatorViewModel : ViewModelBase
	{
		private Sprite _indicatorSprite;

		public Sprite IndicatorSprite
		{
			get
			{
				return _indicatorSprite;
			}
			set
			{
				Set(ref _indicatorSprite, value, "IndicatorSprite");
			}
		}

		public MapIndicatorViewModel(Sprite indicatorSprite)
		{
			_indicatorSprite = indicatorSprite;
		}

		public virtual void OnIndicatorClick()
		{
		}
	}
}
