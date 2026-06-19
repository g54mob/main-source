using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipRoomButton : Tooltip
	{
		[SerializeField]
		private TMP_Text StaffRequired;

		[SerializeField]
		private TMP_Text Description;

		[SerializeField]
		private TMP_Text UpgradesAvailable;

		[SerializeField]
		private TMP_Text CurrentCount;

		public void SetData(RoomDefinition roomDefinition, RibbonRoomRow.Mode mode, Metagame metagame, GameplayStatsTracker gameplayStatsTracker, RoomTemplate template, RibbonRoomRow.TemplateInvalidReason templateInvalidReason, List<uint> missingDLC)
		{
			string text = roomDefinition.Description.Translation;
			if (mode == RibbonRoomRow.Mode.Locked || mode == RibbonRoomRow.Mode.LockedAffordable || mode == RibbonRoomRow.Mode.ContainsInvalidItems)
			{
				if (template != null)
				{
					if (templateInvalidReason.HasFlag(RibbonRoomRow.TemplateInvalidReason.LockedItems) || templateInvalidReason.HasFlag(RibbonRoomRow.TemplateInvalidReason.BannedItems))
					{
						text += "\n\n<color=#b60000>";
						text += ScriptLocalization.Menu.RoomTemplates_LockedItem_CS;
						text += "</color>";
					}
					if (templateInvalidReason.HasFlag(RibbonRoomRow.TemplateInvalidReason.MissingUGC))
					{
						text += "\n\n<color=#b60000>";
						text += ScriptLocalization.Menu.RoomTemplates_MissingUGCItem_CS;
						text += "</color>";
					}
					if (templateInvalidReason.HasFlag(RibbonRoomRow.TemplateInvalidReason.MissingDLC))
					{
						text += "\n\n<color=#b60000>";
						text += ScriptLocalization.Misc.Requires_DLC_List_Header_CS;
						foreach (uint item in missingDLC)
						{
							DLCItemDefinition dLCByAppID = metagame.App.DLCManager.GetDLCByAppID(item);
							if (dLCByAppID != null)
							{
								text += "\n";
								text += dLCByAppID.Name.Translation;
							}
						}
						text += "</color>";
					}
				}
				else
				{
					text += "\n\n";
					text += StringUtils.FormatCurrency(roomDefinition.GetCostWithRequiredItems());
					text += "\n\n";
					text += GameStringUtils.GetUnlockText(roomDefinition.SilverCost(), metagame.TotalSilver());
				}
			}
			base.Text = roomDefinition.GetLocalisedName();
			Description.text = text;
			CurrentCount.text = GameStringUtils.GetRoomCountText(gameplayStatsTracker, roomDefinition);
			int num = RoomAlgorithms.CalculateNumberOfUpgradesForRoom(roomDefinition, metagame);
			UpgradesAvailable.text = ScriptLocalization.Tooltip.RibbonMenu_RoomBuild_UpgradesAvailable_CS.Replace("{[COUNT]}", num.ToString());
			GameObjectUtils.SetActive(UpgradesAvailable.gameObject, num != 0);
			string requiredStaffText = GameStringUtils.GetRequiredStaffText(roomDefinition.GetRequiredStaff());
			StaffRequired.text = requiredStaffText;
			GameObjectUtils.SetActive(StaffRequired.gameObject, !string.IsNullOrEmpty(requiredStaffText));
		}
	}
}
