using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	[ExecuteInEditMode]
	public class GridLayoutFlexibleSetter : MonoBehaviour
	{
		private GridLayoutGroup group;

		private RectTransform rt;

		private bool hasInit;

		public void Init()
		{
			group = GetComponent<GridLayoutGroup>();
			rt = GetComponent<RectTransform>();
			hasInit = true;
		}

		private void OnEnable()
		{
			UpdateCellSizing();
		}

		private void Start()
		{
			UpdateCellSizing();
		}

		private void OnRectTransformDimensionsChange()
		{
			UpdateCellSizing();
		}

		private void UpdateCellSizing()
		{
			if (!hasInit)
			{
				Init();
			}
			if (group.constraint == GridLayoutGroup.Constraint.FixedColumnCount)
			{
				float width = rt.rect.width;
				group.cellSize = new Vector2(width / (float)group.constraintCount, group.cellSize.y);
			}
			else if (group.constraint == GridLayoutGroup.Constraint.FixedRowCount)
			{
				float height = rt.rect.height;
				group.cellSize = new Vector2(group.cellSize.y, height / (float)group.constraintCount);
			}
		}
	}
}
