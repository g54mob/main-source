using UnityEngine;

namespace GRP
{
	public class LinearGearPartSim : PartSim<LinearGearPart>, ILinearGear, IGear, ISimPrePhysicsUpdate, ISimPhysicsUpdate
	{
		public LinearGearVisual gearVisual;

		public BoxShape bodyShape;

		public LayerMask layerMask;

		private static Collider[] cols;

		public GearType gearType => default(GearType);

		public SimShape gearShape => null;

		public GearController gearController { get; }

		public GearModule gearModule { get; set; }

		public int gearTeeth => 0;

		public float gearOffset => 0f;

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
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
	}
}
