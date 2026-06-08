using UnityEngine;

namespace GRP
{
	public class RadialGearJoint : GearJoint
	{
		public IRadialGear gear;

		public IRadialGear other;

		public int gearTooth;

		public float otherTooth;

		public ConfigurableJoint joint;

		public Transform gearTransform => null;

		public Transform otherTransform => null;

		public RadialGearJoint(IRadialGear gear, IRadialGear other)
		{
		}

		public override void Update()
		{
		}

		public void Calculate(bool force = false)
		{
		}

		public Vector3 ToothToPos(IRadialGear part, float tooth)
		{
			return default(Vector3);
		}

		public override void Destroy()
		{
		}

		public override void OnDrawGizmos()
		{
		}
	}
}
