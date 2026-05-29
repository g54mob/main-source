using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Life
{
	public class BirdFlock : MonoBehaviour
	{
		public enum State : byte
		{
			Boiding = 0,
			Landing = 1,
			Stopping = 2,
			Stopped = 3,
			Leaving = 4
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private Mesh sitMesh;

		[SerializeField]
		private Mesh halfSitMesh;

		[SerializeField]
		private Mesh standMesh;

		[SerializeField]
		private Mesh landMesh;

		[SerializeField]
		private Mesh flapMesh;

		[SerializeField]
		private Mesh flyMesh;

		[SerializeField]
		private Mesh glideMesh;

		[SerializeField]
		private ParticleSystem featherEffect;

		private const int absoluteMaxBirdCount = 64;

		[SerializeField]
		private Bird srcBird;

		[SerializeField]
		private Transform activeBirds;

		[SerializeField]
		private Transform disabledBirds;

		[SerializeField]
		public List<Bird> birds;

		[SerializeField]
		public int birdLandingCount;

		public byte assignedBirdsCount;

		public byte activeBirdsCount;

		public byte totalBirdCount;

		public byte maxBirdCount;

		public byte minBirdCount;

		public byte idealBirdCount;

		public bool optimalBirdCountDirty;

		private const float dt = 0.3f;

		[SerializeField]
		private int takeOffCount;

		private Vector3 takeOffPos;

		[SerializeField]
		private AudioClip[] flapAudioClips;

		[SerializeField]
		private AudioSource audioSource0;

		[SerializeField]
		private AudioSource audioSource1;

		private float lastAudioTime;

		private Vector3 orbitPos;

		private Vector3 orbitTarget;

		private float lastOrbitTime;

		[SerializeField]
		private float sqrShakeDetectionThreshold;

		[SerializeField]
		private float minShakeInterval;

		[SerializeField]
		private float timeSinceLastShake;

		private const float landingNeigbourRadius = 1.1f;

		private const float landingNeigbourSqRadius = 1.21f;

		public void CalculateOptimalLandings()
		{
		}

		public void OnReset()
		{
		}

		public bool IterateBirdCreation()
		{
			return false;
		}

		private bool TryGetRandomLanding(out BirdLanding landing)
		{
			landing = null;
			return false;
		}

		public void OnUpdate()
		{
		}

		public void UprootRadius(Vector3 pos, float radius = 1f, float speed = 1f)
		{
		}

		private void UprootAllBirds()
		{
		}

		private Vector3 GetLandingPos(Bird bird)
		{
			return default(Vector3);
		}

		private void SetState(Bird bird, State state)
		{
		}

		public void UprootBird(Bird bird, float speed = 1f)
		{
		}

		private BirdLanding GetLanding(Bird bird)
		{
			return null;
		}

		private (int3, int3) GetSearchCoordinates(Vector3 pos, float radius)
		{
			return default((int3, int3));
		}

		private void SetBird(BirdLanding landing, Bird bird)
		{
		}

		public void AddOrRemoveLanding(BirdLanding landing, bool landingAdded)
		{
		}

		private void SetLanding(Bird bird, BirdLanding landing)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
