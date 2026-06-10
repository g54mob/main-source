using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.UI;

namespace NSMedieval.WorldMap
{
	public abstract class WorldMapMarkerView : WorldMapItemClickable
	{
		private WorldMapMarkerPlace instance;

		private readonly List<string> tooltipLines = new List<string>();

		private List<string> TooltipLines
		{
			get
			{
				RefreshTooltipTextLines();
				return tooltipLines;
			}
		}

		public WorldMapMarkerPlace Instance
		{
			get
			{
				return instance;
			}
			set
			{
				instance = value;
				instance.OnPositionChanged += UpdatePosition;
				UpdatePosition();
			}
		}

		public override void OnPointerEnter()
		{
			if (MonoSingleton<UIController>.IsInstantiated() && !MonoSingleton<UIController>.Instance.InGameMenu.MenuActive)
			{
				MonoSingleton<TooltipController>.Instance.Show(TooltipLines, null);
			}
		}

		public override void OnPointerLeave()
		{
			if (MonoSingleton<UIController>.IsInstantiated() && !MonoSingleton<UIController>.Instance.InGameMenu.MenuActive)
			{
				MonoSingleton<TooltipController>.Instance.Hide();
			}
		}

		public override void OnClick()
		{
			if (MonoSingleton<UIController>.IsInstantiated() && !MonoSingleton<UIController>.Instance.InGameMenu.MenuActive)
			{
				MonoSingleton<WorldMapController>.Instance.PlaceClicked(Instance);
			}
		}

		private void RefreshTooltipTextLines()
		{
			tooltipLines.Clear();
			tooltipLines.Add(Instance.Name);
		}

		private void UpdatePosition()
		{
			SetGridPosition(instance.Position);
		}

		private void OnDestroy()
		{
			if (instance != null)
			{
				instance.OnPositionChanged -= UpdatePosition;
			}
			instance = null;
		}
	}
}
