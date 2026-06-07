using System.Collections.Generic;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public class GroupCenterOfMass
	{
		public Vector3 CenterOfMass
		{
			get
			{
				if (LoadedMass > 0f)
				{
					return MassWeightedCenterOfMass / LoadedMass;
				}
				return Vector3.zero;
			}
		}

		public float LoadedMass { get; private set; }

		public Vector3 MassWeightedCenterOfMass { get; private set; }

		public GroupCenterOfMass()
		{
			MassWeightedCenterOfMass = Vector3.zero;
			LoadedMass = 0f;
		}

		public GroupCenterOfMass(IEnumerable<PartData> parts)
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (PartData part in parts)
			{
				num += part.Mass;
				Vector3 vector = part.PartScript.Transform.TransformPoint(part.Config.CenterOfMass);
				zero += vector * part.Mass;
			}
			MassWeightedCenterOfMass = zero;
			LoadedMass = num;
		}
	}
}
