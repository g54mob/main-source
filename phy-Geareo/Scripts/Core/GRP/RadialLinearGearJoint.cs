using UnityEngine;

namespace GRP
{
	public class RadialLinearGearJoint : GearJoint
	{
		public IRadialGear radial;

		public ILinearGear linear;

		public int radialTooth;

		public float linearTooth;

		public ConfigurableJoint joint;

		public Transform radialTransform => null;

		public Transform linearTransform => null;

		public RadialLinearGearJoint(IRadialGear radial, ILinearGear linear)
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

		public Vector3 ToothLinearToPos(ILinearGear part, float tooth)
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
