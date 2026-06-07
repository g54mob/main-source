using System.Collections.Generic;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public static class DesignerUtilities
	{
		public static void RepositionParts(PartData part, PartConnection partConnection, Vector3 delta, Dictionary<int, bool> movedParts)
		{
			foreach (PartData part2 in new PartGraph(partConnection.GetOtherPart(part), part).Parts)
			{
				if (!movedParts.ContainsKey(part2.Id))
				{
					movedParts[part2.Id] = true;
					part2.PartScript.Transform.position += delta;
				}
			}
		}
	}
}
