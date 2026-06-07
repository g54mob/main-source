using System;
using System.Collections.Generic;

namespace UMA
{
	[Serializable]
	public abstract class VertexAdjustment
	{
		public int vertexIndex;

		public float weight;

		public string _name;

		private List<Type> vertexAdjustmentTypes;

		private static List<VertexAdjustment> adjustmentTypes;

		public abstract string Name { get; }

		public abstract VertexAdjustmentCollection VertexAdjustmentCollection { get; }

		public List<Type> VertexAdjustmentTypes => null;

		public static List<VertexAdjustment> AdjustmentTypes => null;

		public abstract VertexAdjustment ShallowCopy();

		public abstract void Apply(MeshDetails mesh, MeshDetails src);

		public abstract void ApplyScaled(MeshDetails mesh, MeshDetails src, float scale);

		public VertexAdjustment()
		{
		}

		public static List<Type> GetVertexAdjustmentTypes()
		{
			return null;
		}

		public static VertexAdjustment CreateVertexAdjustment(Type type)
		{
			return null;
		}

		public static VertexAdjustment FromJSON(string json)
		{
			return null;
		}
	}
}
