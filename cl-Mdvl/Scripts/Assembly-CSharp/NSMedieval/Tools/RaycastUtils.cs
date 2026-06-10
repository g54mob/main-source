using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Tools
{
	public static class RaycastUtils
	{
		private static readonly RaycastHit[] HitCache = new RaycastHit[10];

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			for (int i = 0; i < HitCache.Length; i++)
			{
				HitCache[i] = default(RaycastHit);
			}
		}

		public static bool RaycastToSurface(out RaycastHit hit, Ray ray, int layerMask, Func<RaycastHit, bool> filter = null)
		{
			int num = Physics.RaycastNonAlloc(ray, HitCache, 1000f, layerMask);
			hit = default(RaycastHit);
			if (num <= 0)
			{
				return false;
			}
			float num2 = float.MaxValue;
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit = HitCache[i];
				if (!raycastHit.Equals(default(RaycastHit)) && (filter == null || filter(raycastHit)) && raycastHit.distance < num2)
				{
					num2 = raycastHit.distance;
					hit = raycastHit;
				}
			}
			return num2 < float.MaxValue;
		}

		public static bool RaycastFromScreen(Vector3 screenPos, out Vector3 position, int layerMask, Func<RaycastHit, bool> filter = null)
		{
			Ray ray = MonoSingleton<CameraManager>.Instance.GameplayCamera.ScreenPointToRay(screenPos);
			if (!RaycastToSurface(out var hit, ray, layerMask, filter))
			{
				position = Vector3.zero;
				return false;
			}
			position = hit.point;
			return true;
		}

		public static bool RaycastMouseToSurface(out Vector3 position, int raycastMask, Func<RaycastHit, bool> filter = null)
		{
			return RaycastFromScreen(Input.mousePosition, out position, raycastMask, filter);
		}

		public static bool WorldToCanvas(Vector3 objectTransformPosition, RectTransform canvasTransform, out Vector3 proportionalPosition)
		{
			Camera main = Camera.main;
			if ((object)main != null)
			{
				Vector2 vector = main.WorldToViewportPoint(objectTransformPosition);
				Vector2 sizeDelta = canvasTransform.sizeDelta;
				proportionalPosition = new Vector2(vector.x * sizeDelta.x, vector.y * sizeDelta.y);
				return true;
			}
			proportionalPosition = Vector3.zero;
			return false;
		}
	}
}
