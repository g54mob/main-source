using System;
using Restory.Data.Equipment;
using Restory.Data.Localization;
using Restory.Gameplay.GameCursor;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tooltips
{
	public class CommonTooltipService : IInitializable, IDisposable
	{
		private readonly CommonTooltipCustomPool tooltipPool;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly LocalizationSystem localizationSystem;

		private GUI_CommonTooltip activeTooltip;

		[Inject]
		public CommonTooltipService(CommonTooltipCustomPool tooltipPool, CursorSelectionService cursorSelectionService, LocalizationSystem localizationSystem)
		{
			this.tooltipPool = tooltipPool;
			this.cursorSelectionService = cursorSelectionService;
			this.localizationSystem = localizationSystem;
		}

		public void Initialize()
		{
			cursorSelectionService.OnDetectionStateChanged += ResolveDetectionStateChanged;
		}

		public void Dispose()
		{
			cursorSelectionService.OnDetectionStateChanged -= ResolveDetectionStateChanged;
		}

		private void ResolveDetectionStateChanged()
		{
			HideActiveTooltip();
			if (!cursorSelectionService.HasDetection || !TryToGetTooltipActivator(cursorSelectionService.DetectedGameObject, out var tooltipActivator) || (tooltipActivator is ITooltipActivatorWithCondition tooltipActivatorWithCondition && !tooltipActivatorWithCondition.ShouldTooltipBeShown()))
			{
				return;
			}
			if (!(tooltipActivator is LocalizedTooltipActivator tooltipActivator2))
			{
				if (!(tooltipActivator is TipBoxTooltipActivator tooltipActivator3))
				{
					if (!(tooltipActivator is CompressedAirTooltipActivator compressedAirTooltipActivator))
					{
						throw new ArgumentOutOfRangeException();
					}
					ActivateTooltip(compressedAirTooltipActivator);
				}
				else
				{
					ActivateTooltip(tooltipActivator3);
				}
			}
			else
			{
				ActivateTooltip(tooltipActivator2);
			}
		}

		private void HideActiveTooltip()
		{
			if ((bool)activeTooltip)
			{
				tooltipPool.ReleaseTooltip(activeTooltip);
				activeTooltip = null;
			}
		}

		private void ActivateTooltip(LocalizedTooltipActivator tooltipActivator)
		{
			if (string.IsNullOrEmpty(tooltipActivator.TooltipLocalizationKey))
			{
				Debug.LogError("Failed to activate tooltip tooltipActivator, localization is null or empty");
				return;
			}
			activeTooltip = tooltipPool.GetTooltip(tooltipActivator.TooltipPrefab);
			activeTooltip.Init(localizationSystem.GetTranslation(tooltipActivator.TooltipLocalizationKey), tooltipActivator.TargetPoint);
		}

		private void ActivateTooltip(TipBoxTooltipActivator tooltipActivator)
		{
			string text = ((tooltipActivator.AccumulatedTips > 0) ? string.Format("{0}{1}", "¥", tooltipActivator.AccumulatedTips) : localizationSystem.GetTranslation(tooltipActivator.EmptyTipBoxLocalizationKey));
			activeTooltip = tooltipPool.GetTooltip(tooltipActivator.TooltipPrefab);
			activeTooltip.Init(text, tooltipActivator.TargetPoint);
		}

		private void ActivateTooltip(CompressedAirTooltipActivator compressedAirTooltipActivator)
		{
			ToolInfo toolInfo = compressedAirTooltipActivator.ToolInfo;
			string text = localizationSystem.GetTranslation(toolInfo.NameLocalizationKey) + ": " + $"{compressedAirTooltipActivator.Count}x";
			activeTooltip = tooltipPool.GetTooltip(compressedAirTooltipActivator.TooltipPrefab);
			activeTooltip.Init(text, compressedAirTooltipActivator.TargetPoint);
		}

		private static bool TryToGetTooltipActivator(GameObject detectedGameObject, out TooltipActivatorBase tooltipActivator)
		{
			tooltipActivator = null;
			if (!detectedGameObject)
			{
				return false;
			}
			if (detectedGameObject.TryGetComponent<TooltipActivatorBase>(out tooltipActivator))
			{
				return true;
			}
			return tooltipActivator = detectedGameObject.GetComponentInParent<TooltipActivatorBase>();
		}
	}
}
