using System.Collections.Generic;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class PaintingBrushSingleAndLineRaycaster : MonoBehaviour
	{
		[SerializeField]
		protected PaintableTargetTextureRaycaster raycaster;

		[SerializeField]
		private int maxAdditionalRaycastsInLine = 50;

		private Camera mainCamera;

		private int rayHitsCount;

		private Vector3? previousRaycastSourcePoint;

		private Vector3? previousRaycastHitPoint;

		private PaintableTargetRaycastData previousRaycastHitData;

		private Vector2Int? previousRaycastTextureCoordinate;

		public int MaxRaycasts => maxAdditionalRaycastsInLine + 1;

		[Inject]
		private void Construct([Inject(Id = "GameCamera")] Camera gameCamera)
		{
			mainCamera = gameCamera;
		}

		public bool TryGetRaycastResultsInLineFromWorldSpaceDistance(IReadOnlyCollection<PaintableTargetRaycastData> raycastData, Vector3 raycastSourcePoint, float distanceBetweenRaycasts)
		{
			rayHitsCount = 0;
			foreach (PaintableTargetRaycastData raycastDatum in raycastData)
			{
				raycastDatum.ValidCoordinatesCount = 0;
			}
			Ray ray = mainCamera.ScreenPointToRay(raycastSourcePoint);
			if (!raycaster.TryHitValidTarget(ray, raycastData, out var hitTargetData, out var raycastHit))
			{
				ClearPreviousPoints();
				return false;
			}
			Vector2? vector = null;
			RaycastHit raycastHit2 = default(RaycastHit);
			bool flag = false;
			if (IsDistanceBetweenPreviousAndNewRaycastsTooBig(distanceBetweenRaycasts, raycastHit.point, out var actualDistanceBetweenRaycastHits))
			{
				int num = Mathf.CeilToInt(actualDistanceBetweenRaycastHits / distanceBetweenRaycasts);
				for (int i = 1; i < num && i < maxAdditionalRaycastsInLine; i++)
				{
					float t = (float)i / (float)num;
					Vector2 vector2 = Vector2.Lerp(previousRaycastSourcePoint.Value, raycastSourcePoint, t);
					Ray ray2 = mainCamera.ScreenPointToRay(vector2);
					if (raycaster.TryFillInPaintingTextureCoordinateWhereRayHits(ray2, raycastData, out var raycastHit3))
					{
						rayHitsCount++;
						flag = true;
						raycastHit2 = raycastHit3;
						vector = vector2;
					}
				}
			}
			if (rayHitsCount < MaxRaycasts)
			{
				previousRaycastSourcePoint = raycastSourcePoint;
				previousRaycastHitPoint = raycastHit.point;
				if (!flag)
				{
					raycaster.AddHitDataFromRaycast(hitTargetData, raycastHit);
					rayHitsCount++;
				}
			}
			else if (vector.HasValue)
			{
				previousRaycastSourcePoint = vector.Value;
				previousRaycastHitPoint = raycastHit2.point;
			}
			else
			{
				ClearPreviousPoints();
			}
			return rayHitsCount > 0;
		}

		public bool TryGetRaycastSegmentResult(IReadOnlyCollection<PaintableTargetRaycastData> raycastData, Vector3 raycastSourcePoint, float textureSegmentContinuityTolerance)
		{
			foreach (PaintableTargetRaycastData raycastDatum in raycastData)
			{
				raycastDatum.ValidCoordinatesCount = 0;
				raycastDatum.HasLineSegment = false;
			}
			Ray ray = mainCamera.ScreenPointToRay(raycastSourcePoint);
			if (!raycaster.TryHitValidTarget(ray, raycastData, out var hitTargetData, out var raycastHit))
			{
				ClearPreviousPoints();
				return false;
			}
			Vector2Int textureCoordinateFromRaycast = raycaster.GetTextureCoordinateFromRaycast(hitTargetData, raycastHit);
			bool flag = previousRaycastHitData == hitTargetData && previousRaycastTextureCoordinate.HasValue && IsTextureSegmentContinuous(raycastData, hitTargetData, raycastSourcePoint, textureCoordinateFromRaycast, textureSegmentContinuityTolerance);
			Vector2Int segmentStartTextureCoordinate = (flag ? previousRaycastTextureCoordinate.Value : textureCoordinateFromRaycast);
			hitTargetData.SegmentStartTextureCoordinate = segmentStartTextureCoordinate;
			hitTargetData.SegmentEndTextureCoordinate = textureCoordinateFromRaycast;
			hitTargetData.SegmentHasStartCap = !flag;
			hitTargetData.HasLineSegment = true;
			previousRaycastSourcePoint = raycastSourcePoint;
			previousRaycastHitPoint = raycastHit.point;
			previousRaycastHitData = hitTargetData;
			previousRaycastTextureCoordinate = textureCoordinateFromRaycast;
			return true;
		}

		private bool IsTextureSegmentContinuous(IReadOnlyCollection<PaintableTargetRaycastData> raycastData, PaintableTargetRaycastData hitData, Vector3 currentRaycastSourcePoint, Vector2Int currentTextureCoordinate, float textureSegmentContinuityTolerance)
		{
			if (!previousRaycastSourcePoint.HasValue || !previousRaycastTextureCoordinate.HasValue)
			{
				return false;
			}
			Vector3 pos = Vector3.Lerp(previousRaycastSourcePoint.Value, currentRaycastSourcePoint, 0.5f);
			Ray ray = mainCamera.ScreenPointToRay(pos);
			if (!raycaster.TryHitValidTarget(ray, raycastData, out var hitTargetData, out var raycastHit) || hitTargetData != hitData)
			{
				return false;
			}
			Vector2Int textureCoordinateFromRaycast = raycaster.GetTextureCoordinateFromRaycast(hitData, raycastHit);
			return Vector2.Distance(b: Vector2.Lerp(previousRaycastTextureCoordinate.Value, currentTextureCoordinate, 0.5f), a: textureCoordinateFromRaycast) <= textureSegmentContinuityTolerance;
		}

		public void ClearPreviousPoints()
		{
			previousRaycastSourcePoint = null;
			previousRaycastHitPoint = null;
			previousRaycastHitData = null;
			previousRaycastTextureCoordinate = null;
		}

		private bool IsDistanceBetweenPreviousAndNewRaycastsTooBig(float thresholdDistanceBetweenRaycastHits, Vector3 newRaycastHitPoint, out float actualDistanceBetweenRaycastHits)
		{
			if (!previousRaycastSourcePoint.HasValue || !previousRaycastHitPoint.HasValue)
			{
				actualDistanceBetweenRaycastHits = 0f;
				return false;
			}
			actualDistanceBetweenRaycastHits = (newRaycastHitPoint - previousRaycastHitPoint.Value).magnitude;
			return actualDistanceBetweenRaycastHits > thresholdDistanceBetweenRaycastHits;
		}

		private bool FindingValidRaycastPointsTest(Vector3 raycastSourcePoint, IReadOnlyCollection<PaintableTargetRaycastData> raycastData)
		{
			if (previousRaycastSourcePoint.HasValue)
			{
				if (previousRaycastHitPoint.HasValue)
				{
					PaintableTargetRaycastData paintableTargetRaycastData;
					Vector3 resultRaycastSourcePoint;
					RaycastHit raycastHit;
					return PerformRecursiveDiminishingRaycasts(previousRaycastSourcePoint.Value, raycastSourcePoint, raycastData, 0, 10, float.MaxValue, 1f, out paintableTargetRaycastData, out resultRaycastSourcePoint, out raycastHit);
				}
				Ray ray = mainCamera.ScreenPointToRay(previousRaycastSourcePoint.Value);
				PaintableTargetRaycastData hitTargetData;
				RaycastHit raycastHit2;
				bool num = raycaster.TryHitValidTarget(ray, raycastData, out hitTargetData, out raycastHit2);
				mainCamera.ScreenPointToRay(raycastSourcePoint);
				PaintableTargetRaycastData hitTargetData2;
				RaycastHit raycastHit3;
				bool flag = raycaster.TryHitValidTarget(ray, raycastData, out hitTargetData2, out raycastHit3);
				PaintableTargetRaycastData paintableTargetRaycastData3;
				Vector3 resultRaycastSourcePoint3;
				RaycastHit raycastHit5;
				if (num)
				{
					PaintableTargetRaycastData paintableTargetRaycastData2;
					Vector3 resultRaycastSourcePoint2;
					RaycastHit raycastHit4;
					if (!flag)
					{
						return PerformRecursiveDiminishingRaycasts(previousRaycastSourcePoint.Value, raycastSourcePoint, raycastData, 0, 10, float.MaxValue, 1f, out paintableTargetRaycastData2, out resultRaycastSourcePoint2, out raycastHit4);
					}
				}
				else if (flag)
				{
					return PerformRecursiveDiminishingRaycasts(raycastSourcePoint, previousRaycastSourcePoint.Value, raycastData, 0, 10, float.MaxValue, 1f, out paintableTargetRaycastData3, out resultRaycastSourcePoint3, out raycastHit5);
				}
			}
			return false;
		}

		private bool PerformRecursiveDiminishingRaycasts(Vector3 raycastSourcePointA, Vector3 raycastSourcePointB, IReadOnlyCollection<PaintableTargetRaycastData> raycastData, int currentRaycastsCount, int maxRaycastsCount, float currentSqrDistanceBetweenRaycastSources, float minSqrDistanceBetweenRaycastSources, out PaintableTargetRaycastData paintableTargetRaycastData, out Vector3 resultRaycastSourcePoint, out RaycastHit raycastHit)
		{
			Vector3 vector = (raycastSourcePointA - raycastSourcePointB) * 0.5f;
			resultRaycastSourcePoint = raycastSourcePointA + vector;
			currentSqrDistanceBetweenRaycastSources = vector.sqrMagnitude;
			currentRaycastsCount++;
			Ray ray = mainCamera.ScreenPointToRay(resultRaycastSourcePoint);
			PaintableTargetRaycastData hitTargetData;
			RaycastHit raycastHit2;
			bool flag = raycaster.TryHitValidTarget(ray, raycastData, out hitTargetData, out raycastHit2);
			paintableTargetRaycastData = hitTargetData;
			raycastHit = raycastHit2;
			if (currentRaycastsCount >= maxRaycastsCount || currentSqrDistanceBetweenRaycastSources <= minSqrDistanceBetweenRaycastSources)
			{
				return flag;
			}
			Vector3 raycastSourcePointA2;
			Vector3 raycastSourcePointB2;
			if (flag)
			{
				raycastSourcePointA2 = resultRaycastSourcePoint;
				raycastSourcePointB2 = raycastSourcePointB;
			}
			else
			{
				raycastSourcePointA2 = raycastSourcePointA;
				raycastSourcePointB2 = resultRaycastSourcePoint;
			}
			if (PerformRecursiveDiminishingRaycasts(raycastSourcePointA2, raycastSourcePointB2, raycastData, currentRaycastsCount, maxRaycastsCount, currentSqrDistanceBetweenRaycastSources, minSqrDistanceBetweenRaycastSources, out var paintableTargetRaycastData2, out var resultRaycastSourcePoint2, out var raycastHit3))
			{
				paintableTargetRaycastData = paintableTargetRaycastData2;
				resultRaycastSourcePoint = resultRaycastSourcePoint2;
				raycastHit = raycastHit3;
				return true;
			}
			return false;
		}
	}
}
