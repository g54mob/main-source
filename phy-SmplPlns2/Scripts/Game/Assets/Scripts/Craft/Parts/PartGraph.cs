using System.Collections.Generic;
using Jundroo.Common.Pool;
using Unity.Profiling;

namespace Assets.Scripts.Craft.Parts
{
	public class PartGraph
	{
		private static class Profile
		{
			public static readonly ProfilerMarker Create = new ProfilerMarker("Create PartGraph");

			public static readonly ProfilerMarker GetConnectedParts = new ProfilerMarker("PartGraph.GetConnectedParts");
		}

		private Dictionary<PartData, bool> _includedParts;

		public bool HasCockpit { get; set; }

		public List<PartData> Parts { get; private set; }

		public PartGraph(PartData part, Dictionary<PartData, bool> includedParts)
		{
			using (Profile.Create.Auto())
			{
				_includedParts = includedParts;
				Parts = new List<PartData>();
				HashSet<int> value;
				using (CollectionPool<HashSet<int>, int>.Get(out value))
				{
					Traverse(null, part, breakOnRigidBodyBoundary: false, value, null);
				}
			}
		}

		public PartGraph(PartData part, bool breakOnRigidBodyBoundary)
		{
			using (Profile.Create.Auto())
			{
				Parts = new List<PartData>();
				if (breakOnRigidBodyBoundary)
				{
					breakOnRigidBodyBoundary = true;
				}
				HashSet<int> value;
				using (CollectionPool<HashSet<int>, int>.Get(out value))
				{
					Traverse(null, part, breakOnRigidBodyBoundary, value, null);
				}
			}
		}

		public PartGraph(PartData part, PartData ignorePart)
		{
			using (Profile.Create.Auto())
			{
				Parts = new List<PartData>();
				HashSet<int> value;
				using (CollectionPool<HashSet<int>, int>.Get(out value))
				{
					value.Add(ignorePart.Id);
					Traverse(null, part, breakOnRigidBodyBoundary: false, value, null);
				}
			}
		}

		public PartGraph(PartData part, List<PartConnection> partConnectionsToIgnore)
		{
			using (Profile.Create.Auto())
			{
				Parts = new List<PartData>();
				HashSet<int> value;
				using (CollectionPool<HashSet<int>, int>.Get(out value))
				{
					Traverse(null, part, breakOnRigidBodyBoundary: false, value, null, partConnectionsToIgnore);
				}
			}
		}

		public static void GetConnectedParts(PartData rootPart, bool breakOnRigidBodyBoundary, List<PartData> parts)
		{
			using (Profile.GetConnectedParts.Auto())
			{
				parts.Clear();
				breakOnRigidBodyBoundary = breakOnRigidBodyBoundary;
				HashSet<int> value;
				using (CollectionPool<HashSet<int>, int>.Get(out value))
				{
					Queue<PartData> value2;
					using (QueuePool<PartData>.Get(out value2))
					{
						value2.Enqueue(rootPart);
						value.Add(rootPart.Id);
						while (value2.Count > 0)
						{
							PartData partData = value2.Dequeue();
							parts.Add(partData);
							foreach (PartConnection partConnection in partData.PartConnections)
							{
								PartData otherPart = partConnection.GetOtherPart(partData);
								if (!value.Add(otherPart.Id))
								{
									continue;
								}
								if (breakOnRigidBodyBoundary)
								{
									bool sharesRigidBody = partData.SharesRigidBody;
									bool sharesRigidBody2 = otherPart.SharesRigidBody;
									if (!sharesRigidBody2 || !sharesRigidBody)
									{
										if (!sharesRigidBody2 && !sharesRigidBody)
										{
											continue;
										}
										PartData partData2 = (sharesRigidBody ? partData : otherPart);
										if (!partData2.PartType.IgnoreSharesRigidBody || partData2.PartConnections.Count > 1)
										{
											continue;
										}
									}
									if (partConnection.IsPhysicsJoint)
									{
										continue;
									}
								}
								value2.Enqueue(otherPart);
							}
						}
					}
				}
			}
		}

		public static List<PartData> GetPartsConnectedToPartButNotConnectedToCockpit(PartScript rootPart)
		{
			List<PartConnection> list = new List<PartConnection>();
			foreach (PartConnection partConnection in rootPart.Part.PartConnections)
			{
				if (new PartGraph(partConnection.GetOtherPart(rootPart.Part), rootPart.Part).HasCockpit || rootPart.Part.IsCockpit)
				{
					list.Add(partConnection);
				}
			}
			return new PartGraph(rootPart.Part, list).Parts;
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

		private void Traverse(PartData previousPart, PartData part, bool breakOnRigidBodyBoundary, HashSet<int> visitedNodes, PartConnection previousConnection, List<PartConnection> partConnectionsToIgnore = null)
		{
			visitedNodes.Add(part.Id);
			if (breakOnRigidBodyBoundary && (!part.SharesRigidBody || (previousPart != null && !previousPart.SharesRigidBody)) && previousPart != null)
			{
				if (!part.SharesRigidBody && !previousPart.SharesRigidBody)
				{
					return;
				}
				PartData partData = (previousPart.SharesRigidBody ? previousPart : part);
				if (!partData.PartType.IgnoreSharesRigidBody || partData.PartConnections.Count > 1)
				{
					return;
				}
			}
			if (!IsPartIncluded(part))
			{
				return;
			}
			Parts.Add(part);
			if (part.IsCockpit)
			{
				HasCockpit = true;
			}
			foreach (PartConnection partConnection in part.PartConnections)
			{
				if (partConnection != previousConnection && (!partConnection.IsPhysicsJoint || !breakOnRigidBodyBoundary) && (partConnectionsToIgnore == null || !partConnectionsToIgnore.Contains(partConnection)))
				{
					PartData partData2 = null;
					partData2 = ((partConnection.PartA == part) ? partConnection.PartB : partConnection.PartA);
					if (!visitedNodes.Contains(partData2.Id))
					{
						Traverse(part, partData2, breakOnRigidBodyBoundary, visitedNodes, partConnection, partConnectionsToIgnore);
					}
				}
			}
		}
	}
}
