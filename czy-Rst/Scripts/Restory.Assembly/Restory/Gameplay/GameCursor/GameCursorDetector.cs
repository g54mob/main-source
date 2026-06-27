using Restory.Data.GameConfigs;
using Restory.Gameplay.Common;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.GameCursor
{
	public sealed class GameCursorDetector
	{
		private const float RAYCAST_DISTANCE = 4f;

		private readonly Camera gameCamera;

		private readonly GameConfig gameConfig;

		private readonly ScreenSizeCacheService screenSize;

		public GameCursorDetector([Inject(Id = "GameCamera")] Camera gameCamera, GameConfig gameConfig, ScreenSizeCacheService screenSize)
		{
			this.gameCamera = gameCamera;
			this.gameConfig = gameConfig;
			this.screenSize = screenSize;
		}

		public bool TryToDetectInWorldPosition(Vector3 worldPosition, LayerMask layerMask, RaycastHit[] raycastHits, out int hitCount)
		{
			Vector2 vector = gameCamera.WorldToScreenPoint(worldPosition);
			return TryToDetect(vector, layerMask, raycastHits, out hitCount);
		}

		public bool TryToDetect(Vector3 screenPoint, LayerMask layerMask, RaycastHit[] raycastHits, out int hitCount)
		{
			Ray ray = gameCamera.ScreenPointToRay(screenPoint);
			hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 4f, layerMask);
			return hitCount > 0;
		}

		public bool TryToDetect(Vector3 screenPoint, LayerMask layerMask, out RaycastHit hit)
		{
			return Physics.Raycast(gameCamera.ScreenPointToRay(screenPoint), out hit, 4f, layerMask);
		}

		public float GetPointerToTargetDistance(Vector3 screenPoint, Vector3 targetPosition)
		{
			Vector2 b = gameCamera.WorldToScreenPoint(targetPosition);
			return Vector2.Distance(screenPoint, b) * screenSize.ScreenDistanceNormalizer;
		}
	}
}
