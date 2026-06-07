using AwesomeTechnologies.Utility.Quadtree;
using UnityEngine;

namespace AwesomeTechnologies.MeshTerrains
{
	public class MeshSampleCell
	{
		public Bounds CellBounds;

		public MeshSampleCell(Rect rectangle)
		{
			CellBounds = RectExtension.CreateBoundsFromRect(rectangle, -100000f);
		}
	}
}
