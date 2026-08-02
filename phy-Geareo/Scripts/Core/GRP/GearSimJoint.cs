using UnityEngine;

namespace GRP
{
	public class GearSimJoint
	{
		public GearPartSim gear;

		public GearPartSim other;

		public bool inverted;

		public int gearTooth;

		public float otherTooth;

		public ConfigurableJoint joint;

		public Transform gearTransform => null;

		public Transform otherTransform => null;

		public GearSimJoint(GearPartSim gear, GearPartSim other, bool inverted)
		{
		}

		public void Update(bool force = false)
		{
		}

		public void Destroy()
		{
		}

		public Vector3 ToothToPos(GearPartSim part, float tooth)
		{
			return default(Vector3);
		}

		public void OnDrawGizmos()
		{
		}
	}
}
