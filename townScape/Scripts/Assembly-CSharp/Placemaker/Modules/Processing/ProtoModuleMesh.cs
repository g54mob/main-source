using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace Placemaker.Modules.Processing
{
	[Serializable]
	public class ProtoModuleMesh
	{
		public ModuleMesh moduleMesh;

		[NonSerialized]
		public MappedMaterial mappedMaterial;

		public int3x2 bounds;

		public List<int3> corners;

		public List<int3> looseEdges;

		public List<CornerTouch> cornerTouches;

		public List<SideProfile> sideProfiles;

		public List<DecorPoint> decorPoints;

		public int decorPointMaskTarget;

		public ushort realMeshIndex;
	}
}
