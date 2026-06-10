using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class CaravanAnimalEntry : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text animalName;

		[SerializeField]
		private TMP_Text weightLabel;

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
		private CaravanPanelView parent;

		private string bbtText = string.Empty;

		public AnimalInstance AnimalInstance => animalInstance;

		public void Reset()
		{
			toggle.SetIsOnWithoutNotify(value: false);
		}

		public void SetData(AnimalInstance animalInstance, CaravanPanelView parent)
		{
			this.parent = parent;
			this.animalInstance = animalInstance;
			animalName.SetText(AnimalUtils.GetTradeName(animalInstance));
			weightLabel.SetText(string.Format("+{0}{1}", animalInstance.LifePhase.CaravanStorageCapacity, base.Localize.GetText("general_kg")));
			toggle.onValueChanged.RemoveAllListeners();
			toggle.isOn = false;
			toggle.onValueChanged.AddListener(OnToggle);
			SetImage(animalInstance.Blueprint.IconPath);
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

		public void SetToggle(bool value)
		{
			toggle.isOn = value;
		}

		private void Start()
		{
			bbtButtonOnToggle.onClick.RemoveAllListeners();
			bbtButtonOnToggle.onClick.AddListener(ShowUnavailableBbt);
		}

		private void OnToggle(bool selected)
		{
			CaravanInstance caravanInstance = parent.CaravanInstance;
			bool isEnabled;
			if (selected)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanAnimalEntry.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding ");
					messageBuilder.AppendFormatted(AnimalUtils.GetTradeName(animalInstance));
					messageBuilder.AppendLiteral(" to caravan '");
					messageBuilder.AppendFormatted(caravanInstance.Name);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				caravanInstance.Creatures.Add(animalInstance);
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanAnimalEntry.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing ");
					messageBuilder.AppendFormatted(AnimalUtils.GetTradeName(animalInstance));
					messageBuilder.AppendLiteral(" from caravan '");
					messageBuilder.AppendFormatted(caravanInstance.Name);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				caravanInstance.Creatures.Remove(animalInstance);
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
