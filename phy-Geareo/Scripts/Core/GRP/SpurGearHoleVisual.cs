using System;
using UnityEngine;

namespace GRP
{
	public class SpurGearHoleVisual : MonoBehaviour
	{
		public SpurGearVisual visual;

		public GameObject colliderObj;

		[NonSerialized]
		private GearModule module;

		public static float GearRadius(int teeth, GearModule module)
		{
			return 0f;
		}

		public void Build(SpurGearVisualOptions options, GearConfig config)
		{
		}

		public void Destroy()
		{
		}

		public Mesh[] BuildColliderMesh(SpurGearVisualOptions options, GearConfig config)
		{
			return null;
		}
	}
}
