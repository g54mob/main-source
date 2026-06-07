using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
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

		public float EmptyMass { get; private set; }

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
			float num2 = 0f;
			Vector3 zero = Vector3.zero;
			foreach (PartData part in parts)
			{
				num += part.LoadedMass;
				num2 += part.EmptyMass;
				Vector3 vector = part.PartScript.transform.TransformPoint(part.CenterOfMass);
				zero += vector * part.LoadedMass;
			}
			MassWeightedCenterOfMass = zero;
			LoadedMass = num;
			EmptyMass = num2;
		}
	}
}
