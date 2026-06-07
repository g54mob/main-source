using System;
using System.Collections.Generic;

namespace ModApi.Craft.Parts
{
	public class PartGraph
	{
		private Dictionary<PartData, bool> _includedParts;

		private Dictionary<int, PartData> _visitedNodes;

		public List<PartConnection> BoundaryConnections { get; private set; }

		public bool HasRoot { get; set; }

		public List<PartData> Parts { get; private set; }

		public PartGraph(PartData part, Dictionary<PartData, bool> includedParts)
		{
			_visitedNodes = new Dictionary<int, PartData>();
			_includedParts = includedParts;
			Parts = new List<PartData>();
			Traverse(part, breakOnRigidBodyBoundary: false, null, captureRigidBodyBoundries: false);
		}

		public PartGraph(PartData part, bool breakOnRigidBodyBoundary, bool captureRigidBodyBoundries = false, Predicate<PartConnection> customBreak = null)
		{
			_visitedNodes = new Dictionary<int, PartData>();
			Parts = new List<PartData>();
			Traverse(part, breakOnRigidBodyBoundary, null, captureRigidBodyBoundries, customBreak);
		}

		public PartGraph(PartData part, PartData ignorePart)
		{
			_visitedNodes = new Dictionary<int, PartData>();
			Parts = new List<PartData>();
			_visitedNodes[ignorePart.Id] = ignorePart;
			Traverse(part, breakOnRigidBodyBoundary: false, null, captureRigidBodyBoundries: false);
		}

		public PartGraph(PartData part, List<PartConnection> partConnectionsToIgnore)
		{
			_visitedNodes = new Dictionary<int, PartData>();
			Parts = new List<PartData>();
			Traverse(part, breakOnRigidBodyBoundary: false, partConnectionsToIgnore, captureRigidBodyBoundries: false);
		}

		public static List<PartData> GetPartsConnectedToPartButNotConnectedToRootPart(IPartScript part)
		{
			List<PartConnection> list = new List<PartConnection>();
			foreach (PartConnection partConnection in part.Data.PartConnections)
			{
				if (new PartGraph(partConnection.GetOtherPart(part.Data), part.Data).HasRoot || part.Data.IsRootPart)
				{
					list.Add(partConnection);
				}
			}
			return new PartGraph(part.Data, list).Parts;
		}

		public static List<PartData> GetPartsOnRigidBodyBoundary(PartData part)
		{
			PartGraph partGraph = new PartGraph(part, breakOnRigidBodyBoundary: true, captureRigidBodyBoundries: true);
			List<PartData> list = new List<PartData>();
			foreach (PartConnection boundaryConnection in partGraph.BoundaryConnections)
			{
				PartData item = (partGraph.Parts.Contains(boundaryConnection.PartA) ? boundaryConnection.PartB : boundaryConnection.PartA);
				list.Add(item);
			}
			return list;
		}

		private bool IsPartIncluded(PartData part)
		{
			if (_includedParts != null)
			{
				bool value = false;
				_includedParts.TryGetValue(part, out value);
				return value;
			}
			return true;
		}

		private void Traverse(PartData initialPart, bool breakOnRigidBodyBoundary, List<PartConnection> partConnectionsToIgnore, bool captureRigidBodyBoundries, Predicate<PartConnection> customBreak = null)
		{
			if (captureRigidBodyBoundries)
			{
				BoundaryConnections = new List<PartConnection>();
			}
			List<PartData> list = new List<PartData>();
			list.Add(initialPart);
			_visitedNodes[initialPart.Id] = initialPart;
			for (int i = 0; i < list.Count; i++)
			{
				PartData partData = list[i];
				if (!IsPartIncluded(partData))
				{
					continue;
				}
				Parts.Add(partData);
				if (partData.IsRootPart)
				{
					HasRoot = true;
				}
				foreach (PartConnection partConnection in partData.PartConnections)
				{
					if (partConnection.IsDestroyed || (customBreak != null && customBreak(partConnection)))
					{
						continue;
					}
					if ((!partConnection.IsPhysicsJoint || !breakOnRigidBodyBoundary) && (partConnectionsToIgnore == null || !partConnectionsToIgnore.Contains(partConnection)))
					{
						PartData partData2 = null;
						partData2 = ((!(partConnection.PartA != partData)) ? partConnection.PartB : partConnection.PartA);
						if (!_visitedNodes.ContainsKey(partData2.Id))
						{
							_visitedNodes[partData2.Id] = partData2;
							list.Add(partData2);
						}
					}
					if (captureRigidBodyBoundries && partConnection.IsPhysicsJoint)
					{
						BoundaryConnections.Add(partConnection);
					}
				}
			}
		}
	}
}
