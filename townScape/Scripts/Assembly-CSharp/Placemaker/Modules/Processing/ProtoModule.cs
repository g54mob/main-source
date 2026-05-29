using System;
using System.Collections.Generic;
using Os.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Modules.Processing
{
	[Serializable]
	public class ProtoModule
	{
		public int3 coordinate;

		public int cost;

		public bool isDecor;

		public bool canBeJoined;

		public ushort moduleIndex;

		public int totalHash;

		public int3x2 bounds;

		public ByteQube cornerStates;

		public List<int> anyCorners;

		public List<SbyteFloat3> cornerTouches;

		public int unknownCount;

		public int insideCount;

		public int outsideCount;

		public int cornerLinks;

		public List<ProtoModuleMesh> moduleMeshes;

		public List<MaterialCluster> materialClusters;

		public List<OrientedModule> decorModules;

		public List<DecorPoint> decorPoints;

		public List<SideProfile> sideProfiles;

		public List<PropPlacement> propPlacements;

		public List<int2> colorsThatCantBeTheSame;

		public List<OrientedModule> orientedProtoMeshes;

		public int permutationCount;

		public ByteQube defaultQube;

		public Vector3 worldPos => default(Vector3);
	}
}
