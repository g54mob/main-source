using System.Globalization;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Research;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WarningMessageLayoutItemView : UIView
	{
		[SerializeField]
		private SoundButton buttonClick;

		[SerializeField]
		private SoundButton buttonClose;

		[SerializeField]
		private WarningMessageTooltipView tooltipView;

		[SerializeField]
		private Image image;

		[SerializeField]
		private TMP_Text textField;

		private string imagePath;

		private SoundButton Button => buttonClick;

		private SoundButton ButtonClose => buttonClose;

		private WarningMessageTooltipView TooltipView => tooltipView;

		public void SetData(WarningMessageData message)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText(message.Text, BodyType.None);
			if (message.FactionInstance != null)
			{
				text = text.Replace("<faction_name>", message.FactionInstance.NameLocalized);
			}
			if (text.Contains("<room_type>"))
			{
				text = text.Replace("<room_type>", RoomUtils.GetLocalizedName(message.ID));
			}
			if (text.Contains("<research_count>"))
			{
				text = text.Replace("<research_count>", MonoSingleton<ResearchManager>.Instance.GetUnlockableNodesCount().ToString(CultureInfo.CurrentCulture));
			}
			if (message.Timer > 0)
			{
				string text2 = base.Localize.GetText("general_imminent");
				if (message.Timer > GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour)
				{
					text2 = UiUtils.GetTimeFormatByMinutes(message.Timer, isDuration: true);
				}
				text = text + " (" + text2 + ")";
			}
			SetText(text);
			TooltipView.SetWarningData(message);
			Button.onClick.RemoveAllListeners();
			if (message.ClickAction != null)
			{
				Button.onClick.AddListener(delegate
				{
					message.ClickAction(message);
				});
			}
			if (ButtonClose != null)
			{
				ButtonClose.onClick.RemoveAllListeners();
				if (message.CloseClickAction != null)
				{
					ButtonClose.onClick.AddListener(delegate
					{
						message.CloseClickAction(message);
					});
				}
			}
			SetImage(message.Icon);
		}

		public override void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		private void SetImage(string path)
		{
			if (!(image == null) && !(imagePath == path))
			{
				Sprite sprite = AssetUtils.GetSprite(path);
				image.sprite = ((sprite == null) ? AssetUtils.GetSprite("ph") : sprite);
				imagePath = path;
			}
		}

		private void SetText(string text)
		{
			if (!(textField == null))
			{
				textField.SetText(text);
			}
		}
	}
}
