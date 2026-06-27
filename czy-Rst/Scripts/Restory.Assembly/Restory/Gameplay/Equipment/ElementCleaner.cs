using Mandragora.PWS;
using Restory.Audio;
using Restory.Data.Elements.Condition;
using Restory.Data.Equipment;
using Restory.Gameplay.Cleaning;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Soldering;
using Restory.Gameplay.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class ElementCleaner : MonoBehaviour, IElementInteractionEquipment
	{
		[SerializeField]
		private ElementConditionBase cleaningCompleteCondition;

		[SerializeField]
		private Transform holderPoint;

		[SerializeField]
		private Transform elementDragMouseTooltipPoint;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private CleaningVFX vfx;

		[SerializeField]
		private CleanerBrushSFX sfx;

		private CleanerBrush cleanerBrush;

		private CleanColorCalculator cleaningCalculator;

		private ShineEffectApplierToMaterialInstances shineEffectApplier;

		private CleaningSuccessSFX cleaningSuccessSounds;

		private ElementBase targetElement;

		private MeshCollider targetMeshCollider;

		private TextureMaskHolder targetTextureMaskHolder;

		private CleaningProgressInPercentage previousCleaningProgress = CleaningProgressInPercentage.ZeroProgress;

		public Transform ElementDragMouseTooltipPoint => elementDragMouseTooltipPoint;

		public bool IsElementReady => !shineEffectApplier.IsActive;

		public ElementConditionBase CleaningCompleteCondition => cleaningCompleteCondition;

		public ElementBase TargetElement => targetElement;

		public MeshCollider TargetMeshCollider => targetMeshCollider;

		public InitialCleaningData DraggingElementInitialCleaningData { get; private set; }

		public CleanerBrushSFX CleanerBrushSFX => sfx;

		[Inject]
		private void Construct(CleanerBrush cleanerBrush, CleanColorCalculator cleaningCalculator, ShineEffectApplierToMaterialInstances shineEffectApplier, CleaningSuccessSFX cleaningSuccessSounds)
		{
			this.cleanerBrush = cleanerBrush;
			this.cleaningCalculator = cleaningCalculator;
			this.shineEffectApplier = shineEffectApplier;
			this.cleaningSuccessSounds = cleaningSuccessSounds;
		}

		public void ToggleIndicator(bool isActive)
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}

		public void SetTarget(ElementBase targetElement)
		{
			targetMeshCollider = targetElement.transform.GetComponentInChildren<MeshCollider>();
			targetTextureMaskHolder = targetElement.transform.GetComponentInChildren<TextureMaskHolder>();
			if ((bool)targetMeshCollider)
			{
				this.targetElement = targetElement;
				targetMeshCollider.enabled = true;
				cleanerBrush.SetTarget(targetElement);
				cleaningCalculator.CalculateProgress(targetTextureMaskHolder);
			}
			else
			{
				Debug.LogError("Selected element " + targetElement.transform.name + " has no mesh collider.");
			}
			previousCleaningProgress = CleaningProgressInPercentage.ZeroProgress;
		}

		public void SetCleaningTool(ElementCleanerToolInfoBase tool)
		{
			if ((bool)tool)
			{
				if (tool is CleaningToolInfo cleaningToolInfo)
				{
					cleanerBrush.SetBrushSettings(cleaningToolInfo);
					vfx.SetCleaningTool(cleaningToolInfo);
					sfx.SetCleaningTool(cleaningToolInfo);
				}
				else if (tool is SolderingToolInfo solderingSettings)
				{
					cleanerBrush.SetSolderingSettings(solderingSettings);
				}
			}
		}

		public CleaningProgressInPercentage CalculateProgress()
		{
			return cleaningCalculator.CalculateProgress(targetTextureMaskHolder);
		}

		public CleaningProgressInPercentage CleanAndCalculateProgress(Vector2 screenPosition)
		{
			cleanerBrush.Execute(screenPosition);
			if (targetTextureMaskHolder.CurrentTotalDirtyPixelsCount == 0)
			{
				return CleaningProgressInPercentage.FullProgress;
			}
			cleaningCalculator.Execute(targetTextureMaskHolder, async: true, out var forcefullyCleanedColorChannels);
			CleaningProgressInPercentage cleaningProgressPercentage = targetTextureMaskHolder.GetCleaningProgressPercentage();
			if (forcefullyCleanedColorChannels.IsAnyChannelAffected)
			{
				cleanerBrush.ClearSingleColorChannel(forcefullyCleanedColorChannels);
			}
			UpdateVfx(cleaningProgressPercentage);
			return cleaningProgressPercentage;
		}

		public void Solder(Vector2 screenPosition)
		{
			cleanerBrush.ExecuteSoldering(screenPosition);
		}

		public void CompleteCleaning()
		{
			cleanerBrush.ClearWholeTargetTexture();
			cleaningSuccessSounds.PlayDoubleBellSound();
			if ((bool)targetMeshCollider && targetMeshCollider.transform.TryGetComponent<MeshRendererMaterialsInstantiator>(out var component))
			{
				shineEffectApplier.Apply(component);
			}
			targetElement.ConditionHandler.UpdateCondition(cleaningCompleteCondition);
		}

		public void ResetTarget()
		{
			cleanerBrush.ResetTarget();
			if ((bool)targetMeshCollider)
			{
				targetMeshCollider.enabled = false;
				targetMeshCollider = null;
				targetElement = null;
			}
			if ((bool)targetTextureMaskHolder)
			{
				targetTextureMaskHolder = null;
			}
			previousCleaningProgress = CleaningProgressInPercentage.ZeroProgress;
		}

		public void UpdateDraggingElementInitialCleaningData(ElementBase selectedElement)
		{
			if (!selectedElement)
			{
				DraggingElementInitialCleaningData = null;
			}
			CleaningProgressInPercentage cleaningProgress;
			DirtyPixelsCount initialDirtyPixelsCount;
			bool num = IsElementNeedsCleaning(selectedElement, out cleaningProgress, out initialDirtyPixelsCount);
			SolderingProgressInPercentage solderingProgress;
			int solderPointsCount;
			bool flag = IsElementNeedsSoldering(selectedElement, out solderingProgress, out solderPointsCount);
			if (!num && !flag)
			{
				DraggingElementInitialCleaningData = null;
				return;
			}
			DraggingElementInitialCleaningData = new InitialCleaningData
			{
				CleaningProgress = cleaningProgress,
				SolderingProgress = solderingProgress,
				DirtyPixelsCount = initialDirtyPixelsCount,
				SolderPointsCount = solderPointsCount
			};
		}

		public bool IsElementNeedsCleaning(ElementBase selectedElement, out CleaningProgressInPercentage cleaningProgress, out DirtyPixelsCount initialDirtyPixelsCount)
		{
			cleaningProgress = CleaningProgressInPercentage.FullProgress;
			initialDirtyPixelsCount = null;
			if (!(selectedElement.ConditionHandler.ElementData.Condition is DirtyElementCondition) || !selectedElement.ConditionHandler.TextureMaskHolder || !selectedElement.ConditionHandler.TextureMaskHolder.WorkTexture)
			{
				return false;
			}
			TextureMaskHolder textureMaskHolder = selectedElement.ConditionHandler.TextureMaskHolder;
			initialDirtyPixelsCount = textureMaskHolder.InitialDirtyPixelsCount;
			if (initialDirtyPixelsCount.Total <= 0 && !(selectedElement.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty))
			{
				selectedElement.ConditionHandler.UpdateCondition(CleaningCompleteCondition);
				return false;
			}
			cleaningProgress = cleaningCalculator.CalculateProgress(textureMaskHolder);
			return !cleaningProgress.IsFullyCleaned();
		}

		public bool IsElementNeedsSoldering(ElementBase selectedElement, out SolderingProgressInPercentage solderingProgress, out int solderPointsCount)
		{
			solderingProgress = SolderingProgressInPercentage.FullProgress;
			solderPointsCount = 0;
			if (!(selectedElement.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty { IsResoldered: false } scorchedCircuitProperty))
			{
				return false;
			}
			solderingProgress = scorchedCircuitProperty.GetProgress();
			solderPointsCount = scorchedCircuitProperty.InitialBurntPointsCount;
			return true;
		}

		private void UpdateVfx(CleaningProgressInPercentage cleaningProgress)
		{
			cleanerBrush.TryToGetLastPassCleanedValues(out var redChannelCleanedAmount, out var greenChannelCleanedAmount, out var blueChannelCleanedAmount);
			if (previousCleaningProgress.RedAndGreenChannel >= 1f)
			{
				redChannelCleanedAmount = 0f;
				greenChannelCleanedAmount = 0f;
			}
			if (previousCleaningProgress.BlueChannel >= 1f)
			{
				blueChannelCleanedAmount = 0f;
			}
			vfx.ProcessCleaningAttempt(cleanerBrush.LastPassRaysHitsCount, cleanerBrush.LastPassRaysHits, redChannelCleanedAmount, greenChannelCleanedAmount, blueChannelCleanedAmount);
			previousCleaningProgress = cleaningProgress;
		}
	}
}
