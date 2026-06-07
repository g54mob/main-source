using System;
using UnityEngine;

namespace FractureField.Tools
{
	[Serializable]
	public class Tool
	{
		public ToolType Type { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public float BaseFracture { get; set; }

		public float BasePierce { get; set; }

		public float BaseRange { get; set; }

		public float DustCost { get; set; }

		public Vector2 ImpactOffset { get; set; }

		public Tool(ToolType type, string name, string description, float baseFracture, float basePierce, float baseRange, float dustCost, Vector2 impactOffset = default(Vector2))
		{
		}
	}
}
