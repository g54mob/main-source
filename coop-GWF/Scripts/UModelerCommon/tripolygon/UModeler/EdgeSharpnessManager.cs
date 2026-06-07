using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace tripolygon.UModeler
{
	[Serializable]
	public class EdgeSharpnessManager
	{
		[SerializeField]
		[FormerlySerializedAs("edgeSharpnesses")]
		private List<EdgeSharpness> edgeSharpnesses_ = new List<EdgeSharpness>();

		public void AddEdge(string name, Edge edge)
		{
			Find(name)?.AddEdge(edge);
		}

		public EdgeSharpness Find(string name)
		{
			for (int i = 0; i < edgeSharpnesses_.Count; i++)
			{
				if (edgeSharpnesses_[i].name == name)
				{
					return edgeSharpnesses_[i];
				}
			}
			return null;
		}
	}
}
