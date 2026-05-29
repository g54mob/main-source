using System;
using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Graphs
{
	[SelectionBase]
	public class Qube : MonoBehaviour
	{
		[Serializable]
		public struct Relation
		{
			public Qube qube;

			public sbyte indexInOther;

			public static readonly Relation empty;

			public Relation(Qube qube, sbyte indexInOther)
			{
				this.qube = null;
				this.indexInOther = 0;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		public struct Relation6
		{
			public Relation r0;

			public Relation r1;

			public Relation r2;

			public Relation r3;

			public Relation r4;

			public Relation r5;

			public Relation Item
			{
				get
				{
					return default(Relation);
				}
				set
				{
				}
			}
		}

		public byte voxelCount;

		public byte sideVariationMask;

		public byte decorSideVariationMask;

		public int shadowIndex;

		public int possibleModuleListIndex;

		public uint existanceIndex;

		public ushort lastFillIndex;

		public ushort lastPropagation;

		public float cost;

		public ByteQube cornerValues;

		public bool awaitingRebuilding;

		public bool awaitingGrass;

		public bool awaitingGraphUpdate;

		public bool awaitingModuleClearing;

		public List<OrientedModuleSides> possibleModules;

		public bool empty => false;

		public bool fullyCovered => false;

		private void OnDrawGizmosSelected()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public Vector3 GetNormal()
		{
			return default(Vector3);
		}

		public (Vector3, float) SampleNormalCoverage(Vector3 ts)
		{
			return default((Vector3, float));
		}

		private void Test()
		{
		}
	}
}
