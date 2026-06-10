using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.UI
{
	public class BattleScaleView : MonoSingleton<BattleScaleView>
	{
		[SerializeField]
		private RectTransform marker;

		[SerializeField]
		private TooltipViewNew tooltipView;

		private float markerNormalizedPosition;

		public bool IsVisible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				if (base.gameObject.activeSelf != value)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\BattleScaleView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("IsVisible: ");
						messageBuilder.AppendFormatted(value);
					}
					Log.Info(messageBuilder);
					base.gameObject.SetActive(value);
				}
			}
		}

		public float MarkerPosition
		{
			get
			{
				return markerNormalizedPosition;
			}
			set
			{
				markerNormalizedPosition = Mathf.Clamp(value, -1f, 1f);
				float width = marker.parent.GetComponent<RectTransform>().rect.width;
				marker.anchoredPosition = new Vector2(width / 2f * markerNormalizedPosition, marker.anchoredPosition.y);
			}
		}

		private void Start()
		{
			IsVisible = false;
		}

		public void SetTooltipLines(IEnumerable<string> lines)
		{
			tooltipView.SetLines(lines);
		}
	}
}
