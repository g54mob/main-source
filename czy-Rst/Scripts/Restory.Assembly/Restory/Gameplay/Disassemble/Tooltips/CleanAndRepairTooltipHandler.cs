using System;
using System.Collections.Generic;
using DG.Tweening;
using Restory.Data.Elements.Condition;
using Restory.Data.Tooltips;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Tooltips;
using Restory.Gameplay.Workplace;
using Restory.ObjectPools;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public sealed class CleanAndRepairTooltipHandler : ICleanAndRepairTooltipHandler, IDisposable
	{
		private readonly List<ElementProjection> activeProjections = new List<ElementProjection>();

		private readonly List<ElementConditionMarker> activeMarkers = new List<ElementConditionMarker>();

		private readonly WorkSurface workSurface;

		private readonly TweenSequencesService tweenSequences;

		private readonly ElementProjectionFactory elementProjectionFactory;

		private readonly ElementConditionMarkerPool elementConditionMarkerPool;

		private readonly ClearAndRepairTooltipSettings settings;

		private Sequence projectionSequence;

		private Sequence markerSequence;

		[Inject]
		public CleanAndRepairTooltipHandler(WorkSurface workSurface, TweenSequencesService tweenSequences, ElementProjectionFactory elementProjectionFactory, ElementConditionMarkerPool elementConditionMarkerPool, ClearAndRepairTooltipSettings settings)
		{
			this.workSurface = workSurface;
			this.tweenSequences = tweenSequences;
			this.elementProjectionFactory = elementProjectionFactory;
			this.elementConditionMarkerPool = elementConditionMarkerPool;
			this.settings = settings;
		}

		public void Dispose()
		{
			Clear();
		}

		public void ShowTooltip()
		{
			HighlightNotPerfectElements(workSurface.PlacedElements);
		}

		public void HideTooltip()
		{
			Clear();
		}

		private void HighlightNotPerfectElements(IEnumerable<ElementBase> elements)
		{
			Clear();
			foreach (ElementBase element in elements)
			{
				ElementConditionBase condition = element.ConditionHandler.ElementData.Condition;
				if (!(condition is DirtyElementCondition))
				{
					if (condition is DamagedElementCondition)
					{
						HighlightDamagedElement(element);
					}
				}
				else
				{
					HighlightDirtyElement(element);
				}
			}
			if (activeProjections.Count > 0)
			{
				PlayProjectionSequence();
			}
			if (activeMarkers.Count > 0)
			{
				PlayMarkerSequence();
			}
		}

		private void HighlightDirtyElement(ElementBase element)
		{
			ElementProjection elementProjection = GetElementProjection(element);
			elementProjection.MakeDirty();
			activeProjections.Add(elementProjection);
		}

		private void HighlightDamagedElement(ElementBase element)
		{
			ElementProjection elementProjection = GetElementProjection(element);
			elementProjection.MakeDamaged();
			activeProjections.Add(elementProjection);
		}

		private void MarkElement(ElementBase element)
		{
			ElementConditionMarker elementConditionMarker = GetElementConditionMarker(element);
			activeMarkers.Add(elementConditionMarker);
		}

		private ElementProjection GetElementProjection(ElementBase element)
		{
			if (element is FlexibleElement flexibleElement)
			{
				ElementProjectionData projectionData = new ElementProjectionData(flexibleElement.PlacementModel.transform, Vector3.zero, flexibleElement.BehaviorSwitcher.CastCollider);
				return elementProjectionFactory.CreateElementProjection(projectionData, element.transform);
			}
			return elementProjectionFactory.CreateElementProjection(element.ProjectionData, element.transform);
		}

		private ElementConditionMarker GetElementConditionMarker(ElementBase element)
		{
			ElementConditionMarker elementConditionMarker = elementConditionMarkerPool.Get<ElementConditionMarker>();
			elementConditionMarker.CanvasGroup.alpha = 0f;
			elementConditionMarker.transform.position = element.PlacementPositionHandler.MarkerPosition;
			elementConditionMarker.Init(element.ConditionHandler.ElementData.Condition);
			return elementConditionMarker;
		}

		private void PlayProjectionSequence()
		{
			projectionSequence = tweenSequences.Create();
			projectionSequence.AppendInterval(settings.ProjectionHoldDuration).OnComplete(ReleaseProjections);
		}

		private void PlayMarkerSequence()
		{
			markerSequence = tweenSequences.Create();
			markerSequence.Append(DOTween.To(() => 0f, SetMarkersAlpha, 1f, settings.MarkerFadeInDuration).SetEase(settings.MarkerFadeInEase)).AppendInterval(settings.MarkerHoldDuration).Append(DOTween.To(() => 1f, SetMarkersAlpha, 0f, settings.MarkerFadeOutDuration).SetEase(settings.MarkerFadeOutEase))
				.OnComplete(ReleaseMarkers);
		}

		private void SetMarkersAlpha(float alpha)
		{
			foreach (ElementConditionMarker activeMarker in activeMarkers)
			{
				activeMarker.CanvasGroup.alpha = alpha;
			}
		}

		private void Clear()
		{
			if (projectionSequence != null)
			{
				tweenSequences.Kill(projectionSequence);
				projectionSequence = null;
				ReleaseProjections();
			}
			if (markerSequence != null)
			{
				tweenSequences.Kill(markerSequence);
				projectionSequence = null;
				ReleaseMarkers();
			}
		}

		private void ReleaseProjections()
		{
			foreach (ElementProjection activeProjection in activeProjections)
			{
				elementProjectionFactory.DestroyElementProjection(activeProjection);
			}
			activeProjections.Clear();
		}

		private void ReleaseMarkers()
		{
			foreach (ElementConditionMarker activeMarker in activeMarkers)
			{
				elementConditionMarkerPool.Release(activeMarker);
			}
			activeMarkers.Clear();
		}
	}
}
