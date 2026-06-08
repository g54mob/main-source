using System.Collections.Generic;
using Jobberwocky.GeometryAlgorithms.Source.Core;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull2D
{
	public class Grid
	{
		private Dictionary<GridKey, List<Vertex>> Cells;

		private int CellSize;

		public Grid(Vertex[] points, int cellSize)
		{
			Cells = new Dictionary<GridKey, List<Vertex>>();
			CellSize = cellSize;
			GridKey gridKey = default(GridKey);
			for (int i = 0; i < points.Length; i++)
			{
				gridKey = Point2CellXY(points[i].Position.x, points[i].Position.y);
				if (!Cells.ContainsKey(gridKey))
				{
					Cells.Add(gridKey, new List<Vertex>());
				}
				Cells[gridKey].Add(points[i]);
			}
		}

		public void CellPoints(GridKey key, ref List<Vertex> points)
		{
			if (Cells.ContainsKey(key))
			{
				points.AddRange(Cells[key]);
			}
		}

		public List<Vertex> RangePoints(double[] bbox)
		{
			GridKey gridKey = Point2CellXY(bbox[0], bbox[1]);
			GridKey gridKey2 = Point2CellXY(bbox[2], bbox[3]);
			GridKey key = default(GridKey);
			List<Vertex> points = new List<Vertex>();
			for (int i = gridKey.X; i <= gridKey2.X; i++)
			{
				for (int j = gridKey.Y; j <= gridKey2.Y; j++)
				{
					key.X = i;
					key.Y = j;
					CellPoints(key, ref points);
				}
			}
			return points;
		}

		public void RemovePoint(Vertex point)
		{
			GridKey key = Point2CellXY(point.Position.x, point.Position.y);
			List<Vertex> list = Cells[key];
			for (int i = 0; i < list.Count; i++)
			{
				Vertex v = list[i];
				if (point.Equals(v))
				{
					list.RemoveAt(i);
					break;
				}
			}
		}

		public GridKey Point2CellXY(double px, double py)
		{
			return new GridKey((int)(px / (double)CellSize), (int)(py / (double)CellSize));
		}

		public void ExtendBbox(double[] bbox, float scaleFactor)
		{
			bbox[0] -= scaleFactor * (float)CellSize;
			bbox[1] -= scaleFactor * (float)CellSize;
			bbox[2] += scaleFactor * (float)CellSize;
			bbox[3] += scaleFactor * (float)CellSize;
		}
	}
}
