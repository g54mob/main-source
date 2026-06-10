using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TravelAnimalEntry : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text animalName;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private Image image;

		[SerializeField]
		private GameObject greyForeground;

		[SerializeField]
		private Button bbtButtonOnToggle;

		[SerializeField]
		private LocalizedTextTooltipView toggleTooltip;

		[NonSerialized]
		private AnimalInstance animalInstance;

		[NonSerialized]
		private DebugTravelView parent;

		private string bbtText = string.Empty;

		public void Reset()
		{
			toggle.SetIsOnWithoutNotify(value: false);
		}

		public void SetData(AnimalInstance animalInstance, DebugTravelView parent)
		{
			this.parent = parent;
			this.animalInstance = animalInstance;
			animalName.SetText(AnimalUtils.GetTradeName(animalInstance));
			toggle.onValueChanged.RemoveAllListeners();
			toggle.isOn = false;
			toggle.onValueChanged.AddListener(OnToggle);
			base.TooltipNew.SetLines(AnimalUtils.GetTooltipLines(animalInstance));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			animalInstance = null;
		}

		public void SetClickable(bool clickable, string tooltipKey, string bbtKey)
		{
			toggle.interactable = clickable;
			greyForeground.SetActive(!clickable);
			bbtText = (string.IsNullOrEmpty(bbtKey) ? string.Empty : MonoSingleton<LocalizationController>.Instance.GetText(bbtKey));
			toggleTooltip.SetTooltipKey(tooltipKey);
			toggleTooltip.SetEnabled(!clickable);
			bbtButtonOnToggle.enabled = !clickable;
		}

		private void Start()
		{
			bbtButtonOnToggle.onClick.RemoveAllListeners();
			bbtButtonOnToggle.onClick.AddListener(ShowUnavailableBbt);
		}

		private void OnToggle(bool selected)
		{
			bool isEnabled;
			if (selected)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(7, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\TravelAnimalEntry.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding ");
					messageBuilder.AppendFormatted(AnimalUtils.GetTradeName(animalInstance));
				}
				Log.Info(messageBuilder);
				parent.AddAnimal(animalInstance);
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\TravelAnimalEntry.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing ");
					messageBuilder.AppendFormatted(AnimalUtils.GetTradeName(animalInstance));
				}
				Log.Info(messageBuilder);
				parent.RemoveAnimal(animalInstance);
			}
			parent.UpdatedWorkersCount();
		}

		private void ShowUnavailableBbt()
		{
			if (!string.IsNullOrEmpty(bbtText))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(bbtText);
			}
		}
	}
}
