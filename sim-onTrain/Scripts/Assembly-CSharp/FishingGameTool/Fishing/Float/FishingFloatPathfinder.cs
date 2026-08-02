using System.Collections.Generic;
using FishingGameTool.Fishing.LootData;
using UnityEngine;

namespace FishingGameTool.Fishing.Float
{
	public class FishingFloatPathfinder
	{
		private List<PathData> _pathData = new List<PathData>();

		private static int _maxPathPoints = 4;

		private bool _initizlizePath = true;

		private Vector3 _smoothedDirection;

		private static float _smoothedSpeed = 7f;

		public void FloatBehavior(FishingLootData lootData, Transform fishingFloatTransform, Vector3 transformPosition, float maxLineLength, float finalSpeed, bool attractInput, LayerMask fishingLayer)
		{
			Vector3 position = fishingFloatTransform.position;
			float checkerRadius = fishingFloatTransform.gameObject.GetComponent<FishingFloat>()._checkerRadius;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			if (lootData != null && lootData._lootType == LootType.Fish)
			{
				InitializePath(_pathData, _maxPathPoints, position, transformPosition, checkerRadius, maxLineLength, fishingLayer);
				if (_pathData.Count < 1)
				{
					return;
				}
				float num = Vector3.Distance(_pathData[0]._pathPoint, _pathData[1]._pathPoint);
				if (Vector3.Distance(position, _pathData[1]._pathPoint) < num / 4f)
				{
					_pathData.RemoveAt(0);
					SetNewPathPoint(_pathData, _maxPathPoints, transformPosition, checkerRadius, maxLineLength, fishingLayer);
				}
				vector2 = (_pathData[1]._pathPoint - position).normalized;
			}
			if (attractInput)
			{
				vector = AttractDirection(position, transformPosition, CheckWaterNormal(position, fishingLayer), fishingLayer);
				Debug.DrawRay(position, vector, Color.green);
			}
			float num2 = 1.5f;
			Vector3 normalized = (vector2 + vector * num2).normalized;
			_smoothedDirection = Vector3.Slerp(_smoothedDirection, normalized, _smoothedSpeed * Time.deltaTime);
			fishingFloatTransform.Translate(_smoothedDirection * finalSpeed * Time.deltaTime);
		}

		private Vector3 AttractDirection(Vector3 fishingFloatPosition, Vector3 transformPosition, Vector3 waterNormal, LayerMask fishingLayer)
		{
			Vector3 normalized = Vector3.ProjectOnPlane(new Vector3(transformPosition.x, fishingFloatPosition.y, transformPosition.z) - fishingFloatPosition, waterNormal).normalized;
			float num = Vector3.Distance(fishingFloatPosition, transformPosition);
			if (Physics.Raycast(new Ray(fishingFloatPosition, normalized), out var hitInfo, num + 1f, ~(int)fishingLayer))
			{
				Vector3 normalized2 = (fishingFloatPosition - hitInfo.point).normalized;
				float num2 = 1f;
				Vector3 vector = hitInfo.point + normalized2 * num2 - fishingFloatPosition;
				float num3 = 3f;
				if (num >= num3)
				{
					return AvoidEdgeCollision(vector, fishingFloatPosition, waterNormal, fishingLayer);
				}
				return vector;
			}
			return normalized;
		}

		private Vector3 AvoidEdgeCollision(Vector3 direction, Vector3 fishingFloatPosition, Vector3 waterNormal, LayerMask fishingLayer)
		{
			Ray ray = new Ray(fishingFloatPosition, direction);
			float maxDistance = 1f;
			if (Physics.Raycast(ray, out var hitInfo, maxDistance, ~(int)fishingLayer))
			{
				Vector3 normalized = Vector3.ProjectOnPlane(Vector3.Cross(hitInfo.normal, Vector3.up).normalized, waterNormal).normalized;
				float num = 0.7f;
				return (direction + normalized * num).normalized;
			}
			return direction;
		}

		private void InitializePath(List<PathData> pathData, int maxPathPoints, Vector3 fishingFloatPosition, Vector3 transformPosition, float fishingFloatCheckerRadius, float maxLineLength, LayerMask fishingLayer)
		{
			if (_initizlizePath)
			{
				if (pathData.Count == 0)
				{
					PathData pathData2 = new PathData();
					pathData2._pathPoint = fishingFloatPosition;
					pathData2._waterNormal = CheckWaterNormal(fishingFloatPosition, fishingLayer);
					pathData.Add(pathData2);
				}
				for (int i = 0; i < maxPathPoints; i++)
				{
					PathData pathPoint = GetPathPoint(pathData[i], (i > 0) ? pathData[i - 1] : pathData[i], transformPosition, fishingFloatCheckerRadius, maxLineLength, fishingLayer);
					pathData.Add(pathPoint);
				}
				_initizlizePath = false;
			}
		}

		private void SetNewPathPoint(List<PathData> pathData, int maxPathPoints, Vector3 transformPosition, float fishingFloatCheckerRadius, float maxLineLength, LayerMask fishingLayer)
		{
			PathData pathPoint = GetPathPoint(pathData[maxPathPoints - 1], pathData[maxPathPoints - 2], transformPosition, fishingFloatCheckerRadius, maxLineLength, fishingLayer);
			pathData.Add(pathPoint);
		}

		private PathData GetPathPoint(PathData currentPathData, PathData previousPathData, Vector3 transformPosition, float fishingFloatCheckerRadius, float maxLineLength, LayerMask fishingLayer)
		{
			float num = 15f;
			Vector2 vector = Random.insideUnitCircle * num;
			Vector3 newPathPoint = Vector3.ProjectOnPlane(new Vector3(vector.x, 0f, vector.y), currentPathData._waterNormal) + currentPathData._pathPoint;
			newPathPoint = AdjustPathPointToEnviorment(currentPathData._pathPoint, newPathPoint, fishingLayer);
			Vector3 vector2 = previousPathData._pathPoint - currentPathData._pathPoint;
			Vector3 vector3 = newPathPoint - currentPathData._pathPoint;
			float num2 = Mathf.Acos(Vector3.Dot(vector2.normalized, vector3.normalized)) * 57.29578f;
			float num3 = 70f;
			int num4 = 0;
			int num5 = 400;
			while ((!CheckPointVisibility(previousPathData._pathPoint, newPathPoint, fishingLayer) || !CheckNewPathPointCorrectness(currentPathData._pathPoint, newPathPoint, transformPosition, fishingFloatCheckerRadius, maxLineLength, fishingLayer) || num2 < num3) && num4 <= num5)
			{
				vector = Random.insideUnitCircle * num;
				newPathPoint = Vector3.ProjectOnPlane(new Vector3(vector.x, 0f, vector.y), currentPathData._waterNormal) + currentPathData._pathPoint;
				newPathPoint = AdjustPathPointToEnviorment(currentPathData._pathPoint, newPathPoint, fishingLayer);
				vector3 = newPathPoint - currentPathData._pathPoint;
				num2 = Mathf.Acos(Vector3.Dot(vector2.normalized, vector3.normalized)) * 57.29578f;
				num4++;
			}
			Vector3 waterNormal = CheckWaterNormal(newPathPoint, fishingLayer);
			return new PathData
			{
				_pathPoint = newPathPoint,
				_waterNormal = waterNormal
			};
		}

		private Vector3 CheckWaterNormal(Vector3 pathPointPosition, LayerMask fishingLayer)
		{
			float maxDistance = 0.5f;
			if (Physics.Raycast(new Ray(pathPointPosition, Vector3.down), out var hitInfo, maxDistance, fishingLayer))
			{
				return hitInfo.normal;
			}
			return Vector3.zero;
		}

		private Vector3 AdjustPathPointToEnviorment(Vector3 currentPathPoint, Vector3 newPathPoint, LayerMask fishingLayer)
		{
			if (Physics.Linecast(currentPathPoint, newPathPoint, out var hitInfo))
			{
				Vector3 normalized = (currentPathPoint - hitInfo.point).normalized;
				float num = 1.5f;
				if (((int)fishingLayer & (1 << hitInfo.collider.gameObject.layer)) != 0)
				{
					num = 1f;
				}
				return hitInfo.point + normalized * num;
			}
			return newPathPoint;
		}

		private bool CheckPointVisibility(Vector3 previousPathPoint, Vector3 newPathPoint, LayerMask fishingLayer)
		{
			if (Physics.Linecast(previousPathPoint, newPathPoint, ~(int)fishingLayer))
			{
				return false;
			}
			return true;
		}

		private bool CheckNewPathPointCorrectness(Vector3 currentPathPoint, Vector3 newPathPoint, Vector3 transformPosition, float fishingFloatCheckerRadius, float maxLineLength, LayerMask fishingLayer)
		{
			float num = 1f;
			float num2 = Vector3.Distance(currentPathPoint, newPathPoint);
			float num3 = Vector3.Distance(newPathPoint, transformPosition);
			float maxDistance = fishingFloatCheckerRadius + fishingFloatCheckerRadius * 0.1f;
			bool flag = true;
			if (Physics.Raycast(newPathPoint, Vector3.down, maxDistance, fishingLayer))
			{
				flag = false;
			}
			bool result = true;
			if (num2 < num || num3 > maxLineLength || flag)
			{
				result = false;
			}
			return result;
		}

		public void ClearPathData()
		{
			_pathData.Clear();
			_initizlizePath = true;
		}
	}
}
