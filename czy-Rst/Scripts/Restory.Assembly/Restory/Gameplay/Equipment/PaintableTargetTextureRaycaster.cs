using System.Collections.Generic;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using UnityEngine;

namespace Restory.Gameplay.Equipment
{
	public class PaintableTargetTextureRaycaster : MonoBehaviour
	{
		[SerializeField]
		private LayerMask layerMask = -1;

		[SerializeField]
		private float maxDistance = 3f;

		private readonly RaycastHit[] resultHits = new RaycastHit[8];

		public bool TryHitValidTarget(Ray ray, IReadOnlyCollection<PaintableTargetRaycastData> raycastData, out PaintableTargetRaycastData hitTargetData, out RaycastHit raycastHit)
		{
			int num = Physics.RaycastNonAlloc(ray, resultHits, maxDistance, layerMask);
			if (num == 0)
			{
				raycastHit = default(RaycastHit);
				hitTargetData = null;
				return false;
			}
			hitTargetData = null;
			RaycastHit raycastHit2 = new RaycastHit
			{
				distance = float.MaxValue
			};
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit3 = resultHits[i];
				if (TryGetValidHitTarget(raycastData, raycastHit3, out var targetData) && raycastHit3.distance < raycastHit2.distance)
				{
					raycastHit2 = raycastHit3;
					hitTargetData = targetData;
				}
			}
			if (raycastHit2.distance > maxDistance || hitTargetData == null)
			{
				raycastHit = default(RaycastHit);
				return false;
			}
			raycastHit = raycastHit2;
			return true;
		}

		public bool TryFillInPaintingTextureCoordinateWhereRayHits(Ray ray, IReadOnlyCollection<PaintableTargetRaycastData> raycastData, out RaycastHit raycastHit)
		{
			if (!TryHitValidTarget(ray, raycastData, out var hitTargetData, out raycastHit))
			{
				return false;
			}
			AddHitDataFromRaycast(hitTargetData, raycastHit);
			return true;
		}

		private bool TryGetValidHitTarget(IReadOnlyCollection<PaintableTargetRaycastData> raycastData, RaycastHit hit, out PaintableTargetRaycastData targetData)
		{
			foreach (PaintableTargetRaycastData raycastDatum in raycastData)
			{
				if (hit.transform == raycastDatum.PaintableElement.RaycastTarget)
				{
					targetData = raycastDatum;
					return true;
				}
			}
			targetData = null;
			return false;
		}

		public void AddHitDataFromRaycast(PaintableTargetRaycastData hitTargetData, RaycastHit raycastHit)
		{
			hitTargetData.HitTextureCoordinates[hitTargetData.ValidCoordinatesCount] = GetTextureCoordinateFromRaycast(hitTargetData, raycastHit);
			hitTargetData.ValidCoordinatesCount++;
		}

		public Vector2Int GetTextureCoordinateFromRaycast(PaintableTargetRaycastData hitTargetData, RaycastHit raycastHit)
		{
			return new Vector2Int(Mathf.FloorToInt(raycastHit.textureCoord.x * (float)hitTargetData.PaintableElement.PaintingTextureHolder.PaintingTexture.width), Mathf.FloorToInt(raycastHit.textureCoord.y * (float)hitTargetData.PaintableElement.PaintingTextureHolder.PaintingTexture.height));
		}
	}
}
