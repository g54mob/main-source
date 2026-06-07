using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Runtime
{
	public struct WingBuildOutput
	{
		public GameObject[] MeshObjects;

		public RigidTransform[] ControlSurfaceRootPoses;

		public List<ColliderInfo>[] Colliders;

		public MassPropertiesOutput[] MassPropertiesOutput;
	}
}
