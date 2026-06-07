using Assets.Scripts.Career;
using Assets.Scripts.Career.Milestones;
using ModApi.Math;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsMilestoneScript : DetailsWidgetBaseScript
	{
		private XmlElement _element;

		public override void Initialize(ListViewDetailsScript details)
		{
			_element = GetComponent<XmlElement>();
		}

		public void SetMilestone(Milestone milestone, bool indent)
		{
			if (indent)
			{
				_element.AddClass("indented");
			}
			else
			{
				_element.RemoveClass("indented");
			}
			int num = 0;
			foreach (Milestone.MilestoneTier tier in milestone.Tiers)
			{
				XmlElement elementByInternalId = _element.GetElementByInternalId($"tier-{num}");
				Image elementByInternalId2 = elementByInternalId.GetElementByInternalId<Image>("milestone-fill");
				TextMeshProUGUI elementByInternalId3 = elementByInternalId.GetElementByInternalId<TextMeshProUGUI>("tier-left");
				TextMeshProUGUI elementByInternalId4 = elementByInternalId.GetElementByInternalId<TextMeshProUGUI>("tier-center");
				TextMeshProUGUI elementByInternalId5 = elementByInternalId.GetElementByInternalId<TextMeshProUGUI>("tier-right");
				if (num < milestone.CurrentTierIndex)
				{
					elementByInternalId.RemoveClass("milestone-locked");
					elementByInternalId3.text = "COMPLETE";
					elementByInternalId4.text = GetRewardText(tier);
					elementByInternalId5.text = StringProcessor.FormatDouble(tier.Value, milestone.ValueFormat);
					elementByInternalId2.fillAmount = 1f;
				}
				else if (num == milestone.CurrentTierIndex)
				{
					elementByInternalId.RemoveClass("milestone-locked");
					elementByInternalId3.text = StringProcessor.FormatDouble(milestone.Value, milestone.ValueFormat);
					elementByInternalId4.text = GetRewardText(tier);
					elementByInternalId5.text = StringProcessor.FormatDouble(tier.Value, milestone.ValueFormat);
					elementByInternalId2.fillAmount = milestone.TierPercentageComplete;
				}
				else
				{
					elementByInternalId.AddClass("milestone-locked");
					elementByInternalId3.text = $"TIER {num + 1}";
					elementByInternalId4.text = GetRewardText(tier);
					elementByInternalId5.text = StringProcessor.FormatDouble(tier.Value, milestone.ValueFormat);
					elementByInternalId2.fillAmount = 0f;
				}
				num++;
			}
		}

		private static string GetRewardText(Milestone.MilestoneTier tier)
		{
			string text = string.Empty;
			if (tier.Money > 0)
			{
				text += Units.GetMoneyString(tier.Money);
			}
			if (tier.Research >= 0)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += " | ";
				}
				text += $"{tier.Research}<size=90%>TP</size>";
			}
			return text;
		}
	}
}
