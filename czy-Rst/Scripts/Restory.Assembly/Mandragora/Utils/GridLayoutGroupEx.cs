using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mandragora.Utils
{
	public static class GridLayoutGroupEx
	{
		public static void GetColumnAndRow(this GridLayoutGroup gridLayoutGroup, out int columns, out int rows)
		{
			columns = 0;
			rows = 0;
			int num = 0;
			for (int i = 0; i < gridLayoutGroup.transform.childCount; i++)
			{
				if (!gridLayoutGroup.transform.GetChild(i).TryGetComponent<ILayoutIgnorer>(out var component) || !component.ignoreLayout)
				{
					num++;
				}
			}
			if (num != 0)
			{
				switch (gridLayoutGroup.constraint)
				{
				case GridLayoutGroup.Constraint.FixedColumnCount:
					columns = gridLayoutGroup.constraintCount;
					rows = Mathf.CeilToInt((float)num / (float)columns);
					break;
				case GridLayoutGroup.Constraint.FixedRowCount:
					rows = gridLayoutGroup.constraintCount;
					columns = Mathf.CeilToInt((float)num / (float)rows);
					break;
				case GridLayoutGroup.Constraint.Flexible:
				{
					RectTransform component2 = gridLayoutGroup.gameObject.GetComponent<RectTransform>();
					columns = Mathf.FloorToInt(component2.sizeDelta.x / gridLayoutGroup.cellSize.x);
					rows = Mathf.CeilToInt((float)num / (float)columns);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException($"Unexpected constraint: {gridLayoutGroup.constraint}");
				}
			}
		}
	}
}
