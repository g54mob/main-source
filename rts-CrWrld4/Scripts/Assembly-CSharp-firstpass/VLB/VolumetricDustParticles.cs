using UnityEngine;

namespace VLB
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class VolumetricDustParticles : MonoBehaviour
	{
		public enum Direction
		{
			Beam = 0,
			Random = 1
		}

		public float alpha;

		public float size;

		public Direction direction;

		public float speed;

		public float density;

		public float spawnMaxDistance;

		public bool cullingEnabled;

		public float cullingMaxDistance;

		public static bool isFeatureSupported;

		private ParticleSystem m_Particles;

		private ParticleSystemRenderer m_Renderer;

		private static bool ms_NoMainCameraLogged;

		private static Camera ms_MainCamera;

		private VolumetricLightBeam m_Master;

		public bool isCulled { get; private set; }

		public bool particlesAreInstantiated => false;

		public int particlesCurrentCount => 0;

		public int particlesMaxCount => 0;

		public Camera mainCamera => null;

		private void Start()
		{
		}

		private void InstantiateParticleSystem()
		{
		}

		private void OnEnable()
		{
		}

		private void SetActiveAndPlay()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void SetParticleProperties()
		{
		}

		private void UpdateCulling()
		{
		}
	}
}
