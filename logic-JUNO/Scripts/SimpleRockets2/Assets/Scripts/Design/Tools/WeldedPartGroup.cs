using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;

namespace Assets.Scripts.Design.Tools
{
	public class WeldedPartGroup
	{
		public PartData BasePart { get; private set; }

		public List<PartConnection> BoundaryConnections { get; private set; } = new List<PartConnection>();

		public List<PartData> BoundaryParts { get; private set; } = new List<PartData>();

		public Guid GroupId { get; private set; }

		public List<PartData> Parts { get; private set; } = new List<PartData>();

		public WeldedPartGroup(PartData basePart)
		{
			if (!basePart.GroupId.HasValue)
			{
				throw new ArgumentException("WeldedPartGroup can only be created for parts with a group ID");
			}
			BasePart = basePart;
			GroupId = basePart.GroupId.Value;
			FindWeldedParts(basePart, this, new Dictionary<int, bool>());
		}

		private static void FindWeldedParts(PartData part, WeldedPartGroup group, Dictionary<int, bool> partLookup)
		{
			if (partLookup.ContainsKey(part.Id))
			{
				return;
			}
			partLookup[part.Id] = true;
			group.Parts.Add(part);
			foreach (PartConnection partConnection in part.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(part);
				if (otherPart.GroupId == group.GroupId)
				{
					FindWeldedParts(otherPart, group, partLookup);
				}
				else if (otherPart.GroupId != group.GroupId)
				{
					if (!group.BoundaryParts.Contains(otherPart))
					{
						group.BoundaryParts.Add(otherPart);
					}
					if (!group.BoundaryConnections.Contains(partConnection))
					{
						group.BoundaryConnections.Add(partConnection);
					}
				}
			}
		}
	}
}
