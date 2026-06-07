using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public struct BrainDifferences
	{
		public int nCommonConnections;

		public int nDisjointConnections;

		public float nToggleConnections;

		public int nMaxConnections;

		public List<ConnectionDelta> connectionDeltas;

		public List<ActivationDelta> activationDelta;

		public List<long> disjoint1;

		public List<long> disjoint2;

		public List<long> toggled;

		public float totalDistance => (float)nDisjointConnections / (float)Mathf.Max(nMaxConnections, 1) + nToggleConnections / (float)Mathf.Max(nCommonConnections, 1) + connectionDeltas.Sum((ConnectionDelta d) => d.dist) + activationDelta.Sum((ActivationDelta d) => d.dist);

		public BrainDifferences(int n)
		{
			connectionDeltas = new List<ConnectionDelta>();
			activationDelta = new List<ActivationDelta>();
			disjoint1 = new List<long>();
			disjoint2 = new List<long>();
			toggled = new List<long>();
			nCommonConnections = 0;
			nDisjointConnections = 0;
			nToggleConnections = 0f;
			nMaxConnections = n;
		}
	}
}
