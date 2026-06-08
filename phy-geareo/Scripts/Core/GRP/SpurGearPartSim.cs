using UnityEngine;

namespace GRP
{
	public class SpurGearPartSim : PartSim<SpurGearPart>, IRadialGear, IGear, ICameraAttach, ISimPrePhysicsUpdate, ISimPhysicsUpdate
	{
		public SpurGearVisual gearVisual;

		public MeshGroupShape bodyShape;

		public LayerMask layerMask;

		private static Collider[] cols;

		public GearType gearType => default(GearType);

		public SimShape gearShape => null;

		public GearController gearController { get; }

		public GearModule gearModule { get; set; }

		public int gearTeeth => 0;

		public float gearRadius => 0f;

		public int gearSkip => 0;

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		public void CenterOfMass(Transform transform, SpurGearPart part, out Vector3 centerOfMass, out float totalVolume)
		{
			centerOfMass = default(Vector3);
			totalVolume = default(float);
		}

		public static float Area(Vector3 A, Vector3 B, Vector3 C)
		{
			return 0f;
		}

		public static float Volume(Tetrahedron tet)
		{
			return 0f;
		}

		public static Vector3 Centroid(Tetrahedron tet)
		{
			return default(Vector3);
		}

		public void SimPrePhysicsUpdate()
		{
		}

		public void SimPhysicsUpdate()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void CameraAttach(OrbitCameraController camera, WorldPointerScan target, Vector3 relativePosition)
		{
		}
	}
}
