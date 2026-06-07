using UnityEngine;

namespace AwesomeTechnologies.Utility.Culling
{
	public struct BoundingSphereInfo
	{
		public BoundingSphere BoundingSphere;

		public int CurrentDistanceBand;

		public int PreviousDistanceBand;

		public int Visibility;

		public int LastVisisbility;

		public int Enabled;
	}
}
