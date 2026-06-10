using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Analytics
{
	public class GraphDotInstance : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public RectTransform rectTransform;

		public string eventTitle;

		public string tooltipText;

		public void ConstructEventData(LogEntry entry)
		{
			eventTitle = $"{entry.EventType} @ {entry.Timestamp:F1}s";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<align=left>Money: <b>" + CurrencyFormatter.FormatMoney(entry.TotalMoney) + "</b>");
			stringBuilder.AppendLine("<align=left>Change: <b>" + CurrencyFormatter.FormatMoney(entry.ChangeAmount) + "</b>");
			stringBuilder.AppendLine("----------");
			switch (entry.EventType)
			{
			case "GameStart":
				stringBuilder.AppendLine("<b>Session Started</b>");
				break;
			case "CaughtFish":
				stringBuilder.AppendLine("<b>" + entry.FishRarity + " " + entry.FishName + "</b>");
				break;
			case "BoughtUpgrade":
				stringBuilder.AppendLine("<b>Skill: " + entry.SkillID + "</b>");
				stringBuilder.AppendLine("Cost: " + CurrencyFormatter.FormatMoney(entry.SkillCost));
				break;
			case "EndOfDay":
			{
				stringBuilder.AppendLine("<b>End of Day: " + entry.AreaID + "</b>");
				stringBuilder.AppendLine("Gained: " + CurrencyFormatter.FormatMoney(entry.MoneyGained));
				stringBuilder.AppendLine($"Pond Lvl: {entry.PondLevel}");
				stringBuilder.AppendLine("--- Fish ---");
				string value = "No Fish";
				if (!string.IsNullOrEmpty(entry.FishCaughtSummary))
				{
					value = entry.FishCaughtSummary.Replace(";", "\n");
				}
				stringBuilder.AppendLine(value);
				break;
			}
			default:
				stringBuilder.AppendLine("<b>" + entry.EventType + "</b> (Unknown)");
				break;
			}
			tooltipText = stringBuilder.ToString();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Debug.Log($"OnPointerExit: {eventData.position}");
			rectTransform = base.transform as RectTransform;
			SimpleTooltip.Instance.ShowTooltip(tooltipText, rectTransform, new Vector3(-2f, 5f, 0f), eventTitle, showHeaderText: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (SimpleTooltip.Instance != null)
			{
				SimpleTooltip.Instance.HideTooltip();
				Debug.Log($"OnPointerExit: {eventData.position}");
			}
		}
	}
}
