using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Data.Elements.Condition;
using Restory.Data.Equipment;
using Restory.Gameplay.Common;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.Views;
using Restory.Gameplay.Soldering;
using Restory.Gameplay.Tooltips;
using Restory.Gameplay.Workplace;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBath : MonoBehaviour, IElementInteractionEquipment, IActiveStateSwitchRequester
	{
		[SerializeField]
		private UltrasonicToolView toolView;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private SonicBathDrawer drawer;

		[SerializeField]
		private Transform elementsContainer;

		private readonly Dictionary<ElementBase, ElementRescaleData> insertedElements = new Dictionary<ElementBase, ElementRescaleData>();

		private WorkSurface workSurface;

		private DefaultElementConditions defaultElementConditions;

		private TimeSettingsProvidingService timeSettings;

		private SonicBathView sonicBathView;

		private UltrasonicToolInfo activeTool;

		private InsertedElementData lastRetrievedElement;

		public bool CanBeDetected
		{
			set
			{
				if ((bool)sonicBathView)
				{
					TriggerController.CanBeDetected = value;
				}
			}
		}

		public bool IsCleaningDone { get; set; }

		public UltrasonicToolInfo ActiveTool => activeTool;

		public SonicBathDrawer Drawer => drawer;

		public SonicBathTimer Timer => sonicBathView.Timer;

		public SonicBathTriggerController TriggerController => sonicBathView.TriggerController;

		public SonicBathToggleButton ToggleButton => sonicBathView.ToggleButton;

		public SonicBathCover Cover => sonicBathView.Cover;

		public SonicBathCleaningEffectsPlayer CleaningEffectsPlayer => sonicBathView.CleaningEffectsPlayer;

		public SonicBathElementFitter ElementFitter => sonicBathView.ElementFitter;

		public SonicBathOccupancyIndicator OccupancyIndicator => sonicBathView.OccupancyIndicator;

		public IReadOnlyDictionary<ElementBase, ElementRescaleData> InsertedElements => insertedElements;

		public bool IsFull => insertedElements.Count >= OccupancyIndicator.Capacity;

		public bool IsAnimationActive
		{
			get
			{
				if (!drawer.IsAnimationActive)
				{
					return Cover.IsAnimationActive;
				}
				return true;
			}
		}

		public TimeSpan CleaningDuration => TimeSpan.FromSeconds(activeTool.CleaningDuration * timeSettings.TimeStep.TotalSeconds);

		public event Action OnUltrasonicToolActivated;

		public event Action OnUltrasonicToolReplacing;

		public event Action<ElementBase> OnElementInserted;

		public event Action<ElementBase> OnElementRetrieved;

		[Inject]
		private void Construct(WorkSurface workSurface, DefaultElementConditions defaultElementConditions, TimeSettingsProvidingService timeSettings)
		{
			this.workSurface = workSurface;
			this.defaultElementConditions = defaultElementConditions;
			this.timeSettings = timeSettings;
		}

		private void OnEnable()
		{
			toolView.OnUltrasonicToolActivated += ResolveUltrasonicToolActivated;
		}

		private void OnDisable()
		{
			toolView.OnUltrasonicToolActivated -= ResolveUltrasonicToolActivated;
		}

		public void ToggleTooltipIndicator(bool isActive)
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}

		public bool TryInsertElement(ElementBase element)
		{
			if (insertedElements.ContainsKey(element))
			{
				Debug.LogError("Element " + element.Info.ID + " is already inserted into SonicBath");
				return false;
			}
			if (!ElementFitter.TryGetInsertedElementFitData(element, out var elementFitData))
			{
				return false;
			}
			ElementRescaleData rescaleData = new ElementRescaleData
			{
				OriginalScale = elementFitData.OriginalScale,
				RescaleFactor = elementFitData.FitScaleFactor
			};
			workSurface.RemoveElement(element);
			InsertElement(element, rescaleData);
			StartCoroutine(DisableBathDetectionForOneFrameCoroutine());
			IsCleaningDone = false;
			return true;
		}

		public void InsertElement(ElementBase element, ElementRescaleData rescaleData)
		{
			element.transform.SetParent(elementsContainer);
			element.transform.localScale = rescaleData.OriginalScale * rescaleData.RescaleFactor;
			if (drawer.IsPulled)
			{
				element.IsDragging = false;
				element.BehaviorSwitcher.SwitchToPlacedBehavior();
			}
			else
			{
				element.BehaviorSwitcher.SwitchToPackedBehavior();
			}
			insertedElements.Add(element, rescaleData);
			OccupancyIndicator.SetFilledCount(insertedElements.Count);
			lastRetrievedElement = null;
			this.OnElementInserted?.Invoke(element);
		}

		public bool TryRetrieveElement(ElementBase element)
		{
			if (!insertedElements.TryGetValue(element, out var value))
			{
				return false;
			}
			lastRetrievedElement = new InsertedElementData
			{
				ElementData = element.ConditionHandler.ElementData,
				RescaleData = value
			};
			insertedElements.Remove(element);
			OccupancyIndicator.SetFilledCount(insertedElements.Count);
			workSurface.AddElement(element);
			element.transform.localScale = value.OriginalScale;
			if (insertedElements.Count == 0)
			{
				IsCleaningDone = false;
			}
			this.OnElementRetrieved?.Invoke(element);
			return true;
		}

		public bool TryPull()
		{
			if (!activeTool)
			{
				Debug.LogError("Attempt to pull SonicBath while it has not activeTool");
				return false;
			}
			if (drawer.IsPulled)
			{
				return false;
			}
			drawer.Pull();
			return true;
		}

		public bool TryPush()
		{
			if (!activeTool)
			{
				Debug.LogError("Attempt to push SonicBath while it has not activeTool");
				return false;
			}
			if (!drawer.IsPulled)
			{
				return false;
			}
			FreezeInsertedElements();
			drawer.Push();
			return true;
		}

		public void FreezeInsertedElements()
		{
			foreach (ElementBase key in insertedElements.Keys)
			{
				key.BehaviorSwitcher.SwitchToPackedBehavior();
			}
		}

		public void ReleaseInsertedElements()
		{
			foreach (ElementBase key in insertedElements.Keys)
			{
				key.BehaviorSwitcher.SwitchToPlacedBehavior();
			}
		}

		public void MakeInsertedElementsClean()
		{
			foreach (ElementBase key in insertedElements.Keys)
			{
				if (!(key.ConditionHandler.ElementData.Condition is PerfectElementCondition))
				{
					RemoveContaminationFromElement(key);
				}
			}
			IsCleaningDone = true;
		}

		public bool TryCancelElementRetrieving(ElementBase element)
		{
			if (!element || lastRetrievedElement == null || element.ConditionHandler.ElementData != lastRetrievedElement.ElementData)
			{
				return false;
			}
			element.transform.SetParent(toolView.transform);
			if (!ElementFitter.TryFitElement(element, element.transform.position))
			{
				return false;
			}
			workSurface.RemoveElement(element);
			InsertElement(element, lastRetrievedElement.RescaleData);
			return true;
		}

		public void RestoreActiveTool(UltrasonicToolInfo toolInfo)
		{
			toolView.SetTool(toolInfo, instantly: true);
		}

		private void ResolveUltrasonicToolActivated(UltrasonicToolInfo toolInfo, SonicBathView sonicBathView)
		{
			if ((bool)this.sonicBathView)
			{
				this.OnUltrasonicToolReplacing?.Invoke();
				UnityEngine.Object.Destroy(this.sonicBathView.gameObject);
			}
			this.sonicBathView = sonicBathView;
			activeTool = toolInfo;
			CanBeDetected = false;
			OccupancyIndicator.SetFilledCount(insertedElements.Count);
			this.OnUltrasonicToolActivated?.Invoke();
		}

		private void RemoveContaminationFromElement(ElementBase element)
		{
			if (!(element.ConditionHandler.ElementData.Condition is DirtyElementCondition))
			{
				return;
			}
			element.ConditionHandler.TextureMaskHolder.ClearWorkTexture();
			if (element.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty { IsResoldered: false })
			{
				ContactLinesHandler componentInChildren = element.GetComponentInChildren<ContactLinesHandler>();
				if (!componentInChildren || componentInChildren.AllPoints.Count == 0)
				{
					element.ConditionHandler.UpdateCondition(defaultElementConditions.PerfectElementCondition);
					return;
				}
				foreach (SolderPoint allPoint in componentInChildren.AllPoints)
				{
					SolderPointState state = allPoint.State;
					if (state == SolderPointState.Sooty || state == SolderPointState.Cleaned)
					{
						allPoint.SetState(SolderPointState.Burnt);
					}
				}
				componentInChildren.CaptureSolderPoints();
				element.ConditionHandler.UpdateCondition(defaultElementConditions.BurntElementCondition);
			}
			else
			{
				element.ConditionHandler.UpdateCondition(defaultElementConditions.PerfectElementCondition);
			}
		}

		private IEnumerator DisableBathDetectionForOneFrameCoroutine()
		{
			CanBeDetected = false;
			yield return new WaitForEndOfFrame();
			CanBeDetected = true;
		}
	}
}
