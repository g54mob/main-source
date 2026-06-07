namespace tripolygon.UModeler
{
	public class BSPTree3DNode
	{
		public BSPTree3DNode negative;

		public BSPTree3DNode positive;

		private EditableMesh co_polygons_ = new EditableMesh();

		public EditableMesh co_polygons => co_polygons_;

		public void AddCoPolygon(SimplePolygon polygon)
		{
			co_polygons_.AddUnitedPolygon(polygon);
		}

		private void GetPositivePartitions(SimplePolygon polygon, Partitions3D outPartitions)
		{
			if (positive != null)
			{
				positive.GetPartitions(polygon, outPartitions);
			}
			else
			{
				outPartitions.positives.AddPolygon(polygon);
			}
		}

		private void GetNegativePartitions(SimplePolygon polygon, Partitions3D outPartitions)
		{
			if (negative != null)
			{
				negative.GetPartitions(polygon, outPartitions);
			}
			else
			{
				outPartitions.negatives.AddPolygon(polygon);
			}
		}

		public void GetPartitions(SimplePolygon polygon, Partitions3D outPartitions)
		{
			if (co_polygons_.IsEmpty())
			{
				return;
			}
			PlaneEx plane = co_polygons_.GetPolygon(0).plane;
			PlaneEx planeEx = plane.Clone().Flip();
			if (plane.IsEquivalent(polygon.plane) || planeEx.IsEquivalent(polygon.plane))
			{
				HandleCoPolygons(polygon, outPartitions);
				return;
			}
			polygon.ClipByPlane(plane, out var abovePolygons, out var belowPolygons);
			int num = 0;
			while (abovePolygons != null && num < abovePolygons.GetPolygonCount())
			{
				GetPositivePartitions(abovePolygons.GetPolygon(num), outPartitions);
				num++;
			}
			int num2 = 0;
			while (belowPolygons != null && num2 < belowPolygons.GetPolygonCount())
			{
				GetNegativePartitions(belowPolygons.GetPolygon(num2), outPartitions);
				num2++;
			}
		}

		private void HandleCoPolygons(SimplePolygon polygon, Partitions3D outPartitions)
		{
			for (int i = 0; i < co_polygons_.GetPolygonCount(); i++)
			{
				SimplePolygon polygon2 = co_polygons_.GetPolygon(i);
				if (polygon2.plane.IsEquivalent(polygon.plane))
				{
					SimplePolygon simplePolygon = polygon2.Clone();
					simplePolygon.Intersect(polygon);
					if (simplePolygon.IsValid() && !simplePolygon.IsOpen())
					{
						outPartitions.coPositive.AddPolygon(simplePolygon);
					}
				}
				else
				{
					SimplePolygon simplePolygon2 = polygon2.Clone().Flip();
					simplePolygon2.Intersect(polygon);
					if (simplePolygon2.IsValid() && !simplePolygon2.IsOpen())
					{
						outPartitions.coNegative.AddPolygon(simplePolygon2);
					}
				}
			}
			EditableMesh editableMesh = new EditableMesh();
			editableMesh.AddPolygon(polygon.Clone());
			for (int j = 0; j < co_polygons_.GetPolygonCount(); j++)
			{
				SimplePolygon polygon3 = co_polygons_.GetPolygon(j);
				if (polygon.plane.IsEquivalent(polygon3.plane))
				{
					editableMesh.AddSubtractedPolygon(polygon3);
				}
				else
				{
					editableMesh.AddSubtractedPolygon(polygon3.Clone().Flip());
				}
			}
			for (int k = 0; k < editableMesh.GetPolygonCount(); k++)
			{
				SimplePolygon polygon4 = editableMesh.GetPolygon(k);
				if (polygon4.IsValid() && !polygon4.IsOpen())
				{
					GetPositivePartitions(polygon4, outPartitions);
				}
			}
		}
	}
}
