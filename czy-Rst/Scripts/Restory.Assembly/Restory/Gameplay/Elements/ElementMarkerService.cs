using System;
using Mandragora.Utils;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Tooltips;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementMarkerService : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		[BoolButton(20, 0)]
		private bool showElementMarker = true;

		private ElementDetectionRegistrator elementDetectionRegistrator;

		private DisassembleStateMachine disassembleStateMachine;

		private ElementConditionMarkerPool elementConditionMarkerPool;

		private ElementConditionMarker elementConditionMarker;

		[Inject]
		private void Construct(ElementDetectionRegistrator elementDetectionRegistrator, DisassembleStateMachine disassembleStateMachine, ElementConditionMarkerPool elementConditionMarkerPool)
		{
			this.elementDetectionRegistrator = elementDetectionRegistrator;
			this.disassembleStateMachine = disassembleStateMachine;
			this.elementConditionMarkerPool = elementConditionMarkerPool;
		}

		public void Initialize()
		{
			elementDetectionRegistrator.OnDetectionStateChanged += ResolveDetectionStateChanged;
		}

		public void Dispose()
		{
			elementDetectionRegistrator.OnDetectionStateChanged -= ResolveDetectionStateChanged;
		}

		private void ResolveDetectionStateChanged()
		{
			if (showElementMarker && disassembleStateMachine.ActiveState is DetectionDisassembleState)
			{
				ClearElementMarker();
				ElementBase detectedElement = elementDetectionRegistrator.DetectedElement;
				if ((bool)detectedElement && detectedElement.IsOnSurface && !(detectedElement.ConditionHandler.ElementData.Condition is PerfectElementCondition) && detectedElement.IsOnSurface && !(detectedElement.ConditionHandler.ElementData.Condition is PerfectElementCondition))
				{
					SetElementMarker(detectedElement);
				}
			}
		}

		private void SetElementMarker(ElementBase detectedElement)
		{
			elementConditionMarker = elementConditionMarkerPool.Get<ElementConditionMarker>();
			elementConditionMarker.CanvasGroup.alpha = 1f;
			elementConditionMarker.transform.position = detectedElement.PlacementPositionHandler.MarkerPosition;
			elementConditionMarker.Init(detectedElement.ConditionHandler.ElementData.Condition);
		}

		private void ClearElementMarker()
		{
			if ((bool)elementConditionMarker)
			{
				elementConditionMarkerPool.Release(elementConditionMarker);
				elementConditionMarker = null;
			}
		}
	}
}
