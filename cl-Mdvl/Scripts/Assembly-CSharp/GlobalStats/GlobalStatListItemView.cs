using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.GlobalStats;
using NSMedieval.Objectives;
using NSMedieval.Repository;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalStats
{
	public class GlobalStatListItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text nameText;

		[SerializeField]
		private TMP_Text valueText;

		[SerializeField]
		private Slider progressbar;

		[SerializeField]
		private SoundButton activateObjectiveButton;

		[NonSerialized]
		private GlobalStatInstance globalStatInstance;

		protected override bool AddToClosables => false;

		public void SetGlobalStatInstance(GlobalStatInstance statInstance)
		{
			globalStatInstance = statInstance;
			activateObjectiveButton.onClick.RemoveAllListeners();
			if (!string.IsNullOrEmpty(globalStatInstance.OfferingObjective))
			{
				activateObjectiveButton.gameObject.SetActive(value: true);
				activateObjectiveButton.onClick.AddListener(OnActivateObjectiveButtonClick);
				activateObjectiveButton.GetComponentInChildren<TMP_Text>().text = globalStatInstance.GetObjectiveButtonText();
				SetGrandObjectiveTooltip();
				nameText.gameObject.SetActive(value: false);
				progressbar.gameObject.SetActive(value: false);
			}
			else
			{
				SetTooltip();
				nameText.gameObject.SetActive(value: true);
				progressbar.gameObject.SetActive(value: true);
				activateObjectiveButton.gameObject.SetActive(value: false);
				nameText.SetText(globalStatInstance.GetNameLocalized());
				UpdateGlobalStatValue();
			}
		}

		public void UpdateGlobalStatValue()
		{
			if (!(globalStatInstance.Blueprint == null))
			{
				progressbar.minValue = globalStatInstance.Blueprint.Min;
				progressbar.maxValue = globalStatInstance.Blueprint.Max;
				progressbar.value = globalStatInstance.Value;
				valueText.SetText($"{progressbar.normalizedValue * 100f:F1}%");
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			globalStatInstance = null;
		}

		private void OnDisable()
		{
			activateObjectiveButton.onClick.RemoveAllListeners();
		}

		private void OnActivateObjectiveButtonClick()
		{
			List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>();
			list.Add(new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), OnActivateObjectiveConfirmClick));
			list.Add(new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), null));
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("activate_objective_confirm", list));
		}

		private void OnActivateObjectiveConfirmClick()
		{
			Objective byID = Repository<ObjectiveRepository, Objective>.Instance.GetByID(globalStatInstance.OfferingObjective);
			if (byID == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(78, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatListItemView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot activate objective ");
					messageBuilder.AppendFormatted(globalStatInstance.OfferingObjective);
					messageBuilder.AppendLiteral(". It could not be found in ObjectiveRepository.json.");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				MonoSingleton<WorldMap>.Instance.Data.SetActiveObjective(byID);
			}
		}

		private void SetTooltip()
		{
			SetTooltipLine(globalStatInstance.GetTooltipLocalized());
		}

		private void SetGrandObjectiveTooltip()
		{
			SetTooltipLine(globalStatInstance.GetObjectiveButtonTooltipLocalized());
		}
	}
}
