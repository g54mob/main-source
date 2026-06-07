using Assets.Nimbatus.GUI.Common.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI.Stats
{
	public class BarItem : SerializedMonoBehaviour
	{
		public GameObject Highlight;

		public UITexture FillImage;

		public UILabel Label;

		private string _toolTip;

		public void Init(BarData entry)
		{
			FillImage.fillAmount = entry.PercentValue;
			if (entry.IsHighlighted)
			{
				Label.text = LabelHelper.Orange + entry.Label;
			}
			else
			{
				Label.text = LabelHelper.LightGrey + entry.Label;
			}
			_toolTip = entry.ToolTip;
			Highlight.gameObject.SetActive(entry.IsHighlighted);
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(show ? _toolTip : null);
		}
	}
}
