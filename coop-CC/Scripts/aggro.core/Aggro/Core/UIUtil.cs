using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Aggro.Core
{
	public static class UIUtil
	{
		private static List<RectTransform> _rts = new List<RectTransform>();

		private static List<Selectable> _selectables = new List<Selectable>();

		public static void ForceRebuildLayoutImmediateDeep(RectTransform rt)
		{
			GatherLayoutsHelper(rt);
			for (int i = 0; i < _rts.Count; i++)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(_rts[i]);
			}
			_rts.Clear();
		}

		private static void GatherLayoutsHelper(RectTransform t)
		{
			if (t != null)
			{
				for (int i = 0; i < t.childCount; i++)
				{
					GatherLayoutsHelper(t.GetChild(i) as RectTransform);
				}
				if (t.GetComponent<ILayoutGroup>() != null)
				{
					_rts.Add(t);
				}
			}
		}

		public static void SetNavigation<T>(T component, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown) where T : Component
		{
			SetNavigation(component.GetComponent<Selectable>(), onLeft, onUp, onRight, onDown);
		}

		public static void SetNavigation(Selectable selectable, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			Navigation navigation = selectable.navigation;
			navigation.mode = Navigation.Mode.Explicit;
			navigation.selectOnLeft = onLeft;
			navigation.selectOnUp = onUp;
			navigation.selectOnRight = onRight;
			navigation.selectOnDown = onDown;
			selectable.navigation = navigation;
		}

		public static void SetGridSelectablesHorizontal(List<Selectable> selectables, int count, int colCount, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			for (int i = 0; i < count; i++)
			{
				Navigation navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit
				};
				int num = i % colCount;
				int num2 = i / colCount;
				if (num == 0)
				{
					navigation.selectOnLeft = onLeft;
				}
				else
				{
					navigation.selectOnLeft = selectables[num2 * colCount + (num - 1)];
				}
				if (num2 == 0)
				{
					navigation.selectOnUp = onUp;
				}
				else
				{
					navigation.selectOnUp = selectables[(num2 - 1) * colCount + num];
				}
				if (num == colCount - 1 || i == count - 1)
				{
					navigation.selectOnRight = onRight;
				}
				else
				{
					navigation.selectOnRight = selectables[num2 * colCount + (num + 1)];
				}
				if (num2 == (count - 1) / colCount)
				{
					navigation.selectOnDown = onDown;
				}
				else
				{
					navigation.selectOnDown = selectables[(num2 + 1) * colCount + num];
				}
				selectables[i].navigation = navigation;
			}
		}

		public static void SetGridSelectablesVertical(List<Selectable> selectables, int count, int rowCount, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			for (int i = 0; i < count; i++)
			{
				Navigation navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit
				};
				int num = i / rowCount;
				int num2 = i % rowCount;
				if (num == 0)
				{
					navigation.selectOnLeft = onLeft;
				}
				else
				{
					navigation.selectOnLeft = selectables[(num - 1) * rowCount + num2];
				}
				if (num2 == 0)
				{
					navigation.selectOnUp = onUp;
				}
				else
				{
					navigation.selectOnUp = selectables[num * rowCount + (num2 - 1)];
				}
				if (num == (count - 1) / rowCount || i + rowCount >= count)
				{
					navigation.selectOnRight = onRight;
				}
				else
				{
					navigation.selectOnRight = selectables[(num + 1) * rowCount + num2];
				}
				if (num2 == rowCount - 1 || i == count - 1)
				{
					navigation.selectOnDown = onDown;
				}
				else
				{
					navigation.selectOnDown = selectables[num * rowCount + (num2 + 1)];
				}
				selectables[i].navigation = navigation;
			}
		}

		public static void SetGridSelectablesHorizontal(List<Selectable> selectables, int colCount, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			SetGridSelectablesHorizontal(selectables, selectables.Count, colCount, onLeft, onUp, onRight, onDown);
		}

		public static void SetGridSelectablesVertical(List<Selectable> selectables, int rowCount, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			SetGridSelectablesVertical(selectables, selectables.Count, rowCount, onLeft, onUp, onRight, onDown);
		}

		public static void SetGridSelectablesHorizontal(List<PoolableReference> components, int colCount, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				_selectables.Add(components[i].gameObject.GetComponent<Selectable>());
			}
			SetGridSelectablesHorizontal(_selectables, colCount, onLeft, onUp, onRight, onDown);
			_selectables.Clear();
		}

		public static void SetGridSelectablesHorizontal<T>(List<PoolableReference<T>> components, int colCount, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown) where T : Component
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				_selectables.Add(components[i].gameObject.GetComponent<Selectable>());
			}
			SetGridSelectablesHorizontal(_selectables, colCount, onLeft, onUp, onRight, onDown);
			_selectables.Clear();
		}

		public static void SetVerticalSelectables(List<Selectable> selectables, int count, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			for (int i = 0; i < count; i++)
			{
				Navigation navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit,
					selectOnLeft = onLeft
				};
				if (i == 0)
				{
					navigation.selectOnUp = onUp;
				}
				else
				{
					navigation.selectOnUp = selectables[i - 1];
				}
				navigation.selectOnRight = onRight;
				if (i == count - 1)
				{
					navigation.selectOnDown = onDown;
				}
				else
				{
					navigation.selectOnDown = selectables[i + 1];
				}
				selectables[i].navigation = navigation;
			}
		}

		public static void SetVerticalSelectables(List<Selectable> selectables, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			SetVerticalSelectables(selectables, selectables.Count, onLeft, onUp, onRight, onDown);
		}

		public static void SetVerticalSelectables(List<PoolableReference> components, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				_selectables.Add(components[i].gameObject.GetComponent<Selectable>());
			}
			SetVerticalSelectables(_selectables, count, onLeft, onUp, onRight, onDown);
			_selectables.Clear();
		}

		public static void SetVerticalSelectables<T>(List<PoolableReference<T>> components, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown) where T : Component
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				_selectables.Add(components[i].gameObject.GetComponent<Selectable>());
			}
			SetVerticalSelectables(_selectables, count, onLeft, onUp, onRight, onDown);
			_selectables.Clear();
		}

		public static void SetVerticalSelectables(List<PoolableReference<Selectable>> components, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				_selectables.Add(components[i].component);
			}
			SetVerticalSelectables(_selectables, count, onLeft, onUp, onRight, onDown);
			_selectables.Clear();
		}

		public static void SetHorizontalSelectables(List<Selectable> selectables, int count, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			for (int i = 0; i < count; i++)
			{
				Navigation navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit
				};
				if (i == 0)
				{
					navigation.selectOnLeft = onLeft;
				}
				else
				{
					navigation.selectOnLeft = selectables[i - 1];
				}
				navigation.selectOnUp = onUp;
				if (i == count - 1)
				{
					navigation.selectOnRight = onRight;
				}
				else
				{
					navigation.selectOnRight = selectables[i + 1];
				}
				navigation.selectOnDown = onDown;
				selectables[i].navigation = navigation;
			}
		}

		public static void SetHorizontalSelectables(List<Selectable> selectables, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			SetHorizontalSelectables(selectables, selectables.Count, onLeft, onUp, onRight, onDown);
		}

		public static void SetHorizontalSelectables<T>(List<PoolableReference<T>> components, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown) where T : Component
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				_selectables.Add(components[i].gameObject.GetComponent<Selectable>());
			}
			SetHorizontalSelectables(_selectables, count, onLeft, onUp, onRight, onDown);
			_selectables.Clear();
		}

		public static void SetHorizontalSelectables(List<PoolableReference<Selectable>> components, Selectable onLeft, Selectable onUp, Selectable onRight, Selectable onDown)
		{
			int count = components.Count;
			for (int i = 0; i < count; i++)
			{
				_selectables.Add(components[i].component);
			}
			SetHorizontalSelectables(_selectables, count, onLeft, onUp, onRight, onDown);
			_selectables.Clear();
		}

		public static T GetBottomLeftGridElement<T>(List<T> list, int colCount)
		{
			return list[(list.Count - 1) / colCount * colCount];
		}

		public static T GetTopRightGridElement<T>(List<T> list, int colCount)
		{
			return list[math.min(list.Count, colCount) - 1];
		}

		public static T GetTopRightGridElement<T>(List<T> list, GridLayoutGroup grid)
		{
			if (grid.constraint == GridLayoutGroup.Constraint.FixedColumnCount && grid.startAxis == GridLayoutGroup.Axis.Horizontal)
			{
				return list[math.min(list.Count, grid.constraintCount) - 1];
			}
			if (grid.constraint == GridLayoutGroup.Constraint.FixedRowCount && grid.startAxis == GridLayoutGroup.Axis.Vertical)
			{
				int num = list.Count / grid.constraintCount;
				return list[num * grid.constraintCount];
			}
			Debug.LogError("Grid type unsupported!", grid);
			return default(T);
		}

		public static void ConnectUpDownGrids(List<Selectable> aboveSelectables, int aboveCount, List<Selectable> belowSelectables, int belowCount, int colCount)
		{
			int num = aboveCount % colCount;
			int num2 = math.min(belowCount, colCount);
			for (int i = 0; i < num; i++)
			{
				int index = i + (aboveCount - num);
				int index2 = math.min(i, num2 - 1);
				Selectable selectable = aboveSelectables[index];
				Navigation navigation = selectable.navigation;
				navigation.selectOnDown = belowSelectables[index2];
				selectable.navigation = navigation;
			}
			for (int j = 0; j < num2; j++)
			{
				int index3 = math.min(j + (aboveCount - num), aboveCount - 1);
				int index4 = j;
				Selectable selectable2 = belowSelectables[index4];
				Navigation navigation2 = selectable2.navigation;
				navigation2.selectOnUp = aboveSelectables[index3];
				selectable2.navigation = navigation2;
			}
		}

		public static void DisableNavigation(List<Selectable> selectables)
		{
			for (int i = 0; i < selectables.Count; i++)
			{
				Selectable selectable = selectables[i];
				Navigation navigation = selectable.navigation;
				navigation.mode = Navigation.Mode.None;
				selectable.navigation = navigation;
			}
		}

		public static void SetTilingHintInterior(RectTransform transform, int amountForStart, int rawMaxAmount, int tilingAmount, float originalWidth)
		{
			tilingAmount = math.min(tilingAmount, amountForStart);
			Vector2 offsetMin = transform.offsetMin;
			Vector2 offsetMax = transform.offsetMax;
			float num = 1f - math.saturate((float)amountForStart / (float)rawMaxAmount);
			float num2 = 1f - (num + math.saturate((float)tilingAmount / (float)rawMaxAmount));
			offsetMin.x = originalWidth * num2;
			offsetMax.x = (0f - originalWidth) * num;
			transform.offsetMin = offsetMin;
			transform.offsetMax = offsetMax;
		}

		public static void SetTilingHintExterior(RectTransform transform, int amountForStart, int maxAmount, int rawMaxAmount, int tilingAmount, float originalWidth)
		{
			tilingAmount = math.min(tilingAmount, maxAmount - amountForStart);
			Vector2 offsetMin = transform.offsetMin;
			Vector2 offsetMax = transform.offsetMax;
			float num = math.saturate((float)amountForStart / (float)rawMaxAmount);
			float num2 = 1f - math.saturate((float)(amountForStart + tilingAmount) / (float)rawMaxAmount);
			offsetMin.x = originalWidth * num;
			offsetMax.x = (0f - originalWidth) * num2;
			transform.offsetMin = offsetMin;
			transform.offsetMax = offsetMax;
		}

		public static void SetSiblingOrder<T>(List<T> list) where T : Component
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i].transform.SetSiblingIndex(i);
			}
		}

		public static void GetRectTransformBounds(RectTransform target, out Vector2 center, out Vector2 sizeDelta)
		{
			Rect rect = target.rect;
			center = target.TransformPoint(rect.center);
			sizeDelta = rect.size;
		}
	}
}
