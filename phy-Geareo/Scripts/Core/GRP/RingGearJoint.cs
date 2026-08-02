using UnityEngine;

namespace GRP
{
	public class RingGearJoint : GearJoint
	{
		public IRadialGear ring;

		public IRadialGear spur;

		public int ringTooth;

		public float spurTooth;

		public ConfigurableJoint joint;

		public Transform ringTransform => null;

		public Transform spurTransform => null;

		public RingGearJoint(IRadialGear ring, IRadialGear spur)
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
