using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public class Window : MonoBehaviour, IPropModifier
	{
		private Vector3 samplePos;

		private static List<Mesh> materialMeshes;

		private MeshFilter mf0;

		private MeshFilter mf1;

		public Mesh GetMeshWithVoxelType(Mesh srcMesh, byte voxelType, int variation)
		{
			return null;
		}

		void IPropModifier.Apply(WorldMaster master, ref Unity.Mathematics.Random random, PropModifierStruct propModifierStruct)
		{
		}

		void IPropModifier.Reset(WorldMaster master, Transform srcT)
		{
		}
	}
}
