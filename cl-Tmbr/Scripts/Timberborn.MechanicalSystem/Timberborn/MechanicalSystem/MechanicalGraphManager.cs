using System.Collections.Generic;
using System.Collections.Immutable;

namespace Timberborn.MechanicalSystem
{
	internal class MechanicalGraphManager
	{
		private readonly MechanicalGraphFactory _mechanicalGraphFactory;

		private readonly MechanicalGraphReorganizer _mechanicalGraphReorganizer;

		private readonly TransputMap _transputMap;

		public MechanicalGraphManager(MechanicalGraphFactory mechanicalGraphFactory, MechanicalGraphReorganizer mechanicalGraphReorganizer, TransputMap transputMap)
		{
			_mechanicalGraphFactory = mechanicalGraphFactory;
			_mechanicalGraphReorganizer = mechanicalGraphReorganizer;
			_transputMap = transputMap;
		}

		public void AddNode(MechanicalNode mechanicalNode)
		{
			_mechanicalGraphFactory.Create().AddNode(mechanicalNode);
			HashSet<MechanicalGraph> hashSet = new HashSet<MechanicalGraph> { mechanicalNode.Graph };
			ImmutableArray<Transput>.Enumerator enumerator = mechanicalNode.Transputs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Transput current = enumerator.Current;
				Transput facingTransput = _transputMap.GetFacingTransput(current);
				if (facingTransput != null && facingTransput.IsFinished)
				{
					MechanicalGraph graph = facingTransput.ParentNode.Graph;
					if (graph != null)
					{
						current.Connect(facingTransput);
						facingTransput.Connect(current);
						hashSet.Add(graph);
					}
				}
			}
			if (hashSet.Count > 1)
			{
				_mechanicalGraphFactory.Join(hashSet);
			}
		}

		public void RemoveNode(MechanicalNode mechanicalNode)
		{
			ImmutableArray<Transput>.Enumerator enumerator = mechanicalNode.Transputs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Transput current = enumerator.Current;
				if (current.Connected)
				{
					current.ConnectedTransput.Disconnect();
					current.Disconnect();
				}
			}
			MechanicalGraph graph = mechanicalNode.Graph;
			graph.RemoveNode(mechanicalNode);
			_mechanicalGraphReorganizer.Reorganize(graph);
		}
	}
}
