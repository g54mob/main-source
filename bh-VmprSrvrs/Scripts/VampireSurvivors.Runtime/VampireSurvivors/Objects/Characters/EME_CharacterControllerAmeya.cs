using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerAmeya : EME_CharacterControllerShowstopper
	{
		[Tooltip("In seconds")]
		private float _catSpawnInterval;

		private float _catsPerSpawn;

		[Tooltip("Closer to 1 = higher probability")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _rainbowCatSpawnChance;

		[SerializeField]
		private Vector2 _spawnRectangleSize;

		[Space]
		[SerializeField]
		private bool _allowCatSpawnsInCameraView;

		private PhysicsGroup _catsPhysicsGroup;

		private Camera _mainCamera;

		private readonly List<GameObject> _cachedCats;

		private const int MaxActiveCats = 20;

		public override void AfterFullInitialization()
		{
		}

		private void SpawnCats()
		{
		}

		private Bounds CalculateSpawnBounds(Bounds cameraBounds)
		{
			return default(Bounds);
		}

		private void SpawnCatsInsideBounds()
		{
		}

		private bool OnCatOverlapsWall(CallbackContext context, ArcadeColliderType catCollider, ArcadeColliderType tileCollider)
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}

		public override void LevelUp()
		{
		}
	}
}
