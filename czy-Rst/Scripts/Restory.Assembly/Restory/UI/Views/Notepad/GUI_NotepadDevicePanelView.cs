using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Views.Notepad
{
	public sealed class GUI_NotepadDevicePanelView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[Space]
		[SerializeField]
		private Image customerImage;

		[SerializeField]
		private TMP_Text customerName;

		[SerializeField]
		private TMP_Text deviceName;

		[SerializeField]
		private TMP_Text condition;

		[SerializeField]
		private TMP_Text task;

		[SerializeField]
		private TMP_Text orderFrom;

		[SerializeField]
		private TMP_Text price;

		[SerializeField]
		private TMP_Text progress;

		[Space]
		[Header("Presets")]
		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private string fleaMarketPreset;

		[SerializeField]
		private string npcOrderPreset;

		[SerializeField]
		private string internetOrderPreset;

		public void SetVisibility(bool shouldBeVisible)
		{
			canvasGroup.alpha = (shouldBeVisible ? 1 : 0);
			canvasGroup.blocksRaycasts = shouldBeVisible;
			canvasGroup.interactable = shouldBeVisible;
		}

		public void SetDeviceInfo(string deviceNameText, string deviceConditionText, int reward)
		{
			deviceName.text = deviceNameText;
			condition.text = deviceConditionText;
			price.text = string.Format("{0}{1}", "¥", reward);
			presetSwitcher.ActivatePreset(fleaMarketPreset);
		}

		public void SetNpcOrderInfo(Sprite customerIcon, string customerNameText, string deviceNameText, string deviceConditionText, string taskText, int reward, int daysInWork)
		{
			customerImage.sprite = customerIcon;
			customerName.text = customerNameText;
			deviceName.text = deviceNameText;
			condition.text = deviceConditionText;
			task.text = taskText;
			price.text = string.Format("{0}{1}", "¥", reward);
			progress.text = daysInWork.ToString();
			presetSwitcher.ActivatePreset(npcOrderPreset);
		}

		public void SetEmailOrderInfo(string deviceNameText, string emailAddress, string deviceConditionText, string taskText, int reward, int daysInWork, int daysToComplete)
		{
			deviceName.text = deviceNameText;
			orderFrom.text = emailAddress;
			condition.text = deviceConditionText;
			task.text = taskText;
			price.text = string.Format("{0}{1}", "¥", reward);
			progress.text = $"{daysInWork}/{daysToComplete}";
			presetSwitcher.ActivatePreset(internetOrderPreset);
		}

		public void Clear()
		{
			if ((bool)customerImage)
			{
				customerImage.sprite = null;
			}
			if ((bool)deviceName)
			{
				deviceName.text = string.Empty;
			}
		}
	}
}
