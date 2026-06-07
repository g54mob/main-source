using UnityEngine;

namespace Gh.Tk.UI
{
	public class TextBlockTooltipInteractable3DUIView : BaseInteractable3DUIView, ITooltipDelayOverrider
	{
		private int _tooltipId;

		private static GameObject _handbookLinkBackerPrefab;

		protected GameObject _linkBacker;

		public int TooltipId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private void UpdateVisual()
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public override void OnClicked()
		{
		}

		public virtual float GetTooltipDelay()
		{
			return 0f;
		}
	}
}
