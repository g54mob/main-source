using System;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Modding;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ModItemView : LayoutGroupItemView
	{
		[SerializeField]
		private CustomToggle toggle;

		[SerializeField]
		private TMP_Text modNameLabel;

		[SerializeField]
		private SoundButton moveUpButton;

		[SerializeField]
		private SoundButton moveDownButton;

		[SerializeField]
		private CustomToggle selectionToggle;

		[SerializeField]
		private Image sourceIcon;

		[SerializeField]
		private Sprite[] modSourceIcons;

		private string modId;

		private ModInstance modInstance;

		private void Start()
		{
			selectionToggle.group = base.transform.GetComponentInParent<ToggleGroup>();
		}

		public void SetData(string modId, Action<string, bool> selectionCallback)
		{
			this.modId = modId;
			modInstance = MonoSingleton<ModManager>.Instance.GetModInstance(modId);
			modNameLabel.SetText(modInstance.ModModel.Name);
			sourceIcon.sprite = modSourceIcons[(int)modInstance.Source];
			sourceIcon.color = ColorUtils.GetColor("white");
			WorkshopVersionCheck();
			toggle.SetIsOnWithoutNotify(MonoSingleton<ModManager>.Instance.IsModEnabled(modId));
			toggle.onValueChanged.RemoveAllListeners();
			toggle.onValueChanged.AddListener(delegate(bool isOn)
			{
				selectionToggle.isOn = true;
				MonoSingleton<ModManager>.Instance.SetModEnabled(this.modId, isOn);
			});
			selectionToggle.SetIsOnWithoutNotify(value: false);
			selectionToggle.onValueChanged.RemoveAllListeners();
			selectionToggle.onValueChanged.AddListener(delegate(bool isOn)
			{
				selectionCallback(this.modId, isOn);
			});
		}

		private void WorkshopVersionCheck()
		{
			if (modInstance.Source == ModSource.Workshop)
			{
				bool flag = MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemVersion.HasValidVersion(modInstance.WorkshopPublishedFileId);
				sourceIcon.color = (flag ? ColorUtils.GetColor("white") : ColorUtils.GetColor("orange"));
			}
		}

		public void SetMoveButtons(bool isFirst, bool isLast)
		{
			moveUpButton.gameObject.SetActive(!isFirst);
			moveDownButton.gameObject.SetActive(!isLast);
		}

		public void Select(bool isOn)
		{
			selectionToggle.isOn = isOn;
		}
	}
}
