using System;
using System.Collections.Generic;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class ConcentricCirclesPaintingBrushMultiRaycaster : MonoBehaviour
	{
		[SerializeField]
		private PaintableTargetTextureRaycaster raycaster;

		[SerializeField]
		private int raycastRingsCount = 3;

		[SerializeField]
		private int raysIncrementPerRing = 8;

		private Camera mainCamera;

		private float ringsSpacing;

		private float rayMaxRandomDeviation;

		private bool shouldRaysGoParallelInWorldSpace;

		private int rayHitsCount;

		public int MaxRaysCount { get; private set; }

		public float FarthestRingRadius { get; private set; }

		[Inject]
		private void Construct([Inject(Id = "GameCamera")] Camera gameCamera)
		{
			mainCamera = gameCamera;
		}

		private void Awake()
		{
			MaxRaysCount = GetMaxRaysCount();
		}

		public void SetBrushSettings(float ringsSpacing, float rayMaxRandomDeviation, bool shouldRaysGoParallelInWorldSpace = false)
		{
			this.ringsSpacing = ringsSpacing;
			this.rayMaxRandomDeviation = rayMaxRandomDeviation;
			this.shouldRaysGoParallelInWorldSpace = shouldRaysGoParallelInWorldSpace;
			FarthestRingRadius = (float)raycastRingsCount * ringsSpacing;
		}

		public bool TryGetPaintingMultiRaycastResults(IReadOnlyCollection<PaintableTargetRaycastData> raycastData, Vector3 raycastSourceScreenPosition)
		{
			rayHitsCount = 0;
			foreach (PaintableTargetRaycastData raycastDatum in raycastData)
			{
				raycastDatum.ValidCoordinatesCount = 0;
			}
			Ray ray = mainCamera.ScreenPointToRay(raycastSourceScreenPosition);
			if (raycaster.TryFillInPaintingTextureCoordinateWhereRayHits(ray, raycastData, out var raycastHit))
			{
				rayHitsCount++;
			}
			for (int i = 1; i <= raycastRingsCount; i++)
			{
				float radius = (float)i * ringsSpacing;
				int num = raysIncrementPerRing * i;
				for (int j = 0; j < num; j++)
				{
					float angle = (float)j / (float)num * MathF.PI * 2f;
					Ray ray2 = (shouldRaysGoParallelInWorldSpace ? GetParallelRay(angle, radius, ray) : GetRayFromScreenPoint(angle, radius, raycastSourceScreenPosition));
					if (raycaster.TryFillInPaintingTextureCoordinateWhereRayHits(ray2, raycastData, out raycastHit))
					{
						rayHitsCount++;
					}
				}
			}
			return rayHitsCount > 0;
		}

		private int GetMaxRaysCount()
		{
			int num = 1;
			for (int i = 1; i <= raycastRingsCount; i++)
			{
				num += i * raysIncrementPerRing;
			}
			return num;
		}

		private Ray GetRayFromScreenPoint(float angle, float radius, Vector3 center)
		{
			Vector2 vector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
			Vector3 pos = center + new Vector3(vector.x + UnityEngine.Random.Range(0f - rayMaxRandomDeviation, rayMaxRandomDeviation), vector.y + UnityEngine.Random.Range(0f - rayMaxRandomDeviation, rayMaxRandomDeviation), 0f);
			return mainCamera.ScreenPointToRay(pos);
		}

		private Ray GetParallelRay(float angle, float radius, Ray centralRay)
		{
			Transform obj = mainCamera.transform;
			Vector3 right = obj.right;
			Vector3 up = obj.up;
			Vector3 vector = (right * Mathf.Cos(angle) + up * Mathf.Sin(angle)) * radius;
			Vector3 vector2 = right * UnityEngine.Random.Range(0f - rayMaxRandomDeviation, rayMaxRandomDeviation) + up * UnityEngine.Random.Range(0f - rayMaxRandomDeviation, rayMaxRandomDeviation);
			return new Ray(centralRay.origin + vector + vector2, centralRay.direction);
		}
	}
}
