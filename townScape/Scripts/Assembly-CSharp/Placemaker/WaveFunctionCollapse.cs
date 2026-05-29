using System;
using System.Collections.Generic;
using Placemaker.Graphs;
using UnityEngine;

namespace Placemaker
{
	public class WaveFunctionCollapse : MonoBehaviour
	{
		[Serializable]
		private struct LastRemovedStruct
		{
			public Qube qube;

			public ushort side;

			public sbyte sideIndex;

			public ushort propagationIndex;
		}

		[Serializable]
		private struct Propagation : IComparable<Propagation>
		{
			public Qube qube;

			public ushort propagationIndex;

			public uint existanceIndex;

			public byte sideVariationMask;

			int IComparable<Propagation>.CompareTo(Propagation p1)
			{
				return 0;
			}
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private ushort propagationCounter;

		[SerializeField]
		private ushort lastStartedPropagation;

		[SerializeField]
		private List<Propagation> removeNeighbors;

		[SerializeField]
		private List<Propagation> updates;

		[SerializeField]
		private List<Propagation> propagations;

		[SerializeField]
		private List<Propagation> validations;

		[SerializeField]
		private List<Propagation> toCollapse;

		[SerializeField]
		private List<Propagation> decorUpdates;

		[SerializeField]
		private List<Propagation> decorPropagations;

		[SerializeField]
		private List<Propagation> decorToCollapse;

		[SerializeField]
		private List<Propagation> decorToBuild;

		[SerializeField]
		private List<LastRemovedStruct> lastRemovals;

		[SerializeField]
		private List<LastRemovedStruct> lastDecorRemovals;

		[SerializeField]
		private List<Qube> qubesToRebuild;

		private HashSet<int> hashset;

		[SerializeField]
		private bool doDebugBreak;

		public void QubeRemoved(Qube qube, byte sideMask)
		{
		}

		public void IteratePropagationCount()
		{
		}

		public void QubeUpdated(Qube qube)
		{
		}

		public void LaterUpdate()
		{
		}

		public bool IterateApplyModules()
		{
			return false;
		}

		public bool Iterate0()
		{
			return false;
		}

		public bool Iterate1()
		{
			return false;
		}

		public bool IterateDecor()
		{
			return false;
		}

		public void ResetPropagationCounter()
		{
		}

		private bool MaybeQueueQubeForRebuilding(Qube qube)
		{
			return false;
		}

		private bool RemovePossibleModule(Qube qube, OrientedModuleSides possibleModule, int index, Qube.Relation6 relations)
		{
			return false;
		}

		private void RemovePossibleDecor(Qube qube, OrientedModuleSides possibleModule, int index, Qube.Relation6 relations)
		{
		}

		private byte FillQubePossibilities(Qube qube)
		{
			return 0;
		}

		private byte FillDecorPossibilities(Qube qube)
		{
			return 0;
		}

		private void LastRemoved(Qube qube, ushort side, sbyte sideIndex)
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void DrawPropagationGizmo(Propagation propagation)
		{
		}
	}
}
