using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval;
using NSMedieval.Controllers;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

public class RoomTypeTooltipView : TooltipViewNew
{
	[SerializeField]
	private Image buttonImage;

	private RoomType roomType;

	private static readonly Color MustHaveColor = Color.green;

	private static readonly Color CannotHaveColor = Color.red;

	private bool isGenerated;

	public void SetRoomType(RoomType roomType)
	{
		this.roomType = roomType;
		if (buttonImage != null)
		{
			buttonImage.color = this.roomType.Color;
		}
	}

	private void GenerateTextLines()
	{
		AppendLine(roomType.NameLocalized, TooltipStyles.TooltipTitle);
		string line = ColorUtils.ColorText(MonoSingleton<LocalizationController>.Instance.GetText("room_must_have") + ":", MustHaveColor);
		string line2 = ColorUtils.ColorText(MonoSingleton<LocalizationController>.Instance.GetText("room_cannot_have") + ":", CannotHaveColor);
		string lastEntrySeparator = " " + MonoSingleton<LocalizationController>.Instance.GetText("list_or") + " ";
		StringBuilder stringBuilder = new StringBuilder();
		foreach (RoomTypeMustHave item in roomType.MustHave)
		{
			string text;
			if (item.TextKeys == null || !item.TextKeys.Any())
			{
				text = RoomUtils.GetLocalizedContentsList(item.Content, lastEntrySeparator);
				if (item.Content.Count >= 2)
				{
					text = text ?? "";
				}
			}
			else
			{
				List<string> list = new List<string>(item.TextKeys);
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = MonoSingleton<LocalizationController>.Instance.GetText(list[i]);
				}
				text = RoomUtils.GetLocalizedContentsList(list, lastEntrySeparator);
			}
			if (item != roomType.MustHave.First())
			{
				stringBuilder.Append("\n");
			}
			if (item.MaxCount == item.MinCount)
			{
				stringBuilder.Append(MonoSingleton<LocalizationController>.Instance.GetText("list_exactly") + " " + TextFormatting.GetFormatedItemCount(item.MinCount, text));
			}
			else if (item.MaxCount <= 0)
			{
				stringBuilder.Append(MonoSingleton<LocalizationController>.Instance.GetText("list_at_least") + " " + TextFormatting.GetFormatedItemCount(item.MinCount, text));
			}
			else
			{
				stringBuilder.Append(TextFormatting.GetFormatedItemCount($"{item.MinCount} - {item.MaxCount}", text));
			}
			if (item != roomType.MustHave.Last())
			{
				stringBuilder.Append(", ");
			}
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		if (roomType.TextKeyCantHaveBuildings == null || !roomType.TextKeyCantHaveBuildings.Any())
		{
			stringBuilder2.Append(RoomUtils.GetLocalizedContentsList(roomType.CantHave, ",\n", ",\n"));
			if (roomType.CantHaveOtherProductionBuildings)
			{
				stringBuilder2.Append("\n" + MonoSingleton<LocalizationController>.Instance.GetText("room_cant_have_other_prod_buildings"));
			}
		}
		else
		{
			List<string> list2 = new List<string>(roomType.TextKeyCantHaveBuildings);
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j] = MonoSingleton<LocalizationController>.Instance.GetText(list2[j]);
			}
			stringBuilder2.Append(RoomUtils.GetLocalizedContentsList(list2, lastEntrySeparator));
		}
		AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("room_click_to_select"));
		AppendLine("\n");
		AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("room_info_" + roomType.GetID()), TooltipStyles.TooltipDescriptionLine);
		if (stringBuilder.Length > 0)
		{
			AppendLine("\n");
			AppendLine(line);
			AppendLine(stringBuilder.ToString(), TooltipStyles.TooltipAttribute);
		}
		if (stringBuilder2.Length > 0)
		{
			AppendLine("\n");
			AppendLine(line2);
			AppendLine(stringBuilder2.ToString(), TooltipStyles.TooltipAttribute);
		}
		if (roomType.MinimumArea > 0)
		{
			AppendLine("\n");
			AppendLine(string.Format("{0} {1}", MonoSingleton<LocalizationController>.Instance.GetText("room_minimum_area"), roomType.MinimumArea), TooltipStyles.TooltipAttribute);
		}
		AppendLine("\n");
		AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("room_effect_" + roomType.GetID()));
		foreach (PlayerTriggeredEvent allItem in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems())
		{
			if (allItem.RoomTypeIds != null && allItem.RoomTypeIds.Contains(roomType.GetID()))
			{
				AppendLine("\n");
				AppendLine("room_pte_requirement".ToLocalized() + ": " + LocKeyUtils.GetName(allItem.LocKeys).ToLocalized());
				break;
			}
		}
		foreach (Role allItem2 in Repository<RoleRepository, Role>.Instance.GetAllItems())
		{
			if (allItem2.GetAllRoleRooms(out var roomIds) && roomIds.Contains(roomType.GetID()))
			{
				AppendLine("\n");
				AppendLine("room_role_requirement".ToLocalized() + ": " + LocKeyUtils.GetName(allItem2.LocKeys).ToLocalized(BodyType.None));
				break;
			}
		}
	}

	protected override List<string> GetLinesToShow()
	{
		if (!isGenerated)
		{
			isGenerated = true;
			ClearLines();
			GenerateTextLines();
		}
		return lines;
	}
}
