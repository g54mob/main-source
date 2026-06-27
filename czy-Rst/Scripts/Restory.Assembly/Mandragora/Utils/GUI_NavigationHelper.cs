using System.Collections.Generic;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;

namespace Mandragora.Utils
{
	public static class GUI_NavigationHelper
	{
		private class GetNavigationArgs
		{
			public IReadOnlyList<GUI_ConcreteNavigation> Navigations;

			public GUI_ConcreteNavigation Current;

			public INavigationValidator Validator;
		}

		public static ConcreteNavigation CreateNoneNavigation()
		{
			ConcreteNavigation concreteNavigation = new ConcreteNavigation();
			concreteNavigation.SetNoneAll();
			return concreteNavigation;
		}

		public static ConcreteNavigation CreateAutomaticNavigation()
		{
			ConcreteNavigation concreteNavigation = new ConcreteNavigation();
			concreteNavigation.SetAutomaticAll();
			return concreteNavigation;
		}

		public static GUI_ConcreteNavigation[] GetChildNavigations(Transform parent)
		{
			return parent.GetComponentsInChildren<GUI_ConcreteNavigation>();
		}

		public static GUI_ConcreteNavigation GetFirstChildNavigation(Transform parent)
		{
			GUI_ConcreteNavigation[] childNavigations = GetChildNavigations(parent);
			if (childNavigations.Length == 0)
			{
				return null;
			}
			return childNavigations[0];
		}

		public static GUI_ConcreteNavigation GetLastChildNavigation(Transform parent)
		{
			GUI_ConcreteNavigation[] childNavigations = GetChildNavigations(parent);
			if (childNavigations.Length == 0)
			{
				return null;
			}
			return childNavigations[^1];
		}

		public static void SetLocalChildNavigation(LayoutGroup layoutGroup)
		{
			if (!(layoutGroup is VerticalLayoutGroup localChildNavigation))
			{
				if (!(layoutGroup is HorizontalLayoutGroup localChildNavigation2))
				{
					if (layoutGroup is GridLayoutGroup localChildNavigation3)
					{
						SetLocalChildNavigation(localChildNavigation3);
					}
				}
				else
				{
					SetLocalChildNavigation(localChildNavigation2);
				}
			}
			else
			{
				SetLocalChildNavigation(localChildNavigation);
			}
		}

		public static void SetOutsideChildNavigation(LayoutGroup layoutGroup, ConcreteNavigation outsideNavigation)
		{
			if (!(layoutGroup is VerticalLayoutGroup verticalLayoutGroup))
			{
				if (!(layoutGroup is HorizontalLayoutGroup horizontalLayoutGroup))
				{
					if (layoutGroup is GridLayoutGroup gridLayoutGroup)
					{
						SetOutsideChildNavigation(gridLayoutGroup, outsideNavigation);
					}
				}
				else
				{
					SetOutsideChildNavigation(horizontalLayoutGroup, outsideNavigation);
				}
			}
			else
			{
				SetOutsideChildNavigation(verticalLayoutGroup, outsideNavigation);
			}
		}

		public static void SetLocalAndOutsideChildNavigation(LayoutGroup layoutGroup, ConcreteNavigation outsideNavigation)
		{
			if (!(layoutGroup is VerticalLayoutGroup verticalLayoutGroup))
			{
				if (!(layoutGroup is HorizontalLayoutGroup horizontalLayoutGroup))
				{
					if (layoutGroup is GridLayoutGroup gridLayoutGroup)
					{
						SetLocalAndOutsideChildNavigation(gridLayoutGroup, outsideNavigation);
					}
				}
				else
				{
					SetLocalAndOutsideChildNavigation(horizontalLayoutGroup, outsideNavigation);
				}
			}
			else
			{
				SetLocalAndOutsideChildNavigation(verticalLayoutGroup, outsideNavigation);
			}
		}

		public static void SetLocalChildNavigation(HorizontalLayoutGroup horizontalLayoutGroup)
		{
			SetLocalHorizontalNavigation(GetChildNavigations(horizontalLayoutGroup.transform));
		}

		public static void SetOutsideChildNavigation(HorizontalLayoutGroup horizontalLayoutGroup, ConcreteNavigation outsideNavigation)
		{
			SetOutsideHorizontalNavigation(GetChildNavigations(horizontalLayoutGroup.transform), outsideNavigation);
		}

		public static void SetLocalAndOutsideChildNavigation(HorizontalLayoutGroup horizontalLayoutGroup, ConcreteNavigation outsideNavigation)
		{
			GUI_ConcreteNavigation[] childNavigations = GetChildNavigations(horizontalLayoutGroup.transform);
			SetLocalHorizontalNavigation(childNavigations);
			SetOutsideHorizontalNavigation(childNavigations, outsideNavigation);
		}

		public static void SetOutsideHorizontalNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations, ConcreteNavigation outsideNavigation)
		{
			if (navigations.Count == 0)
			{
				return;
			}
			GUI_ConcreteNavigation gUI_ConcreteNavigation = navigations[0];
			GUI_ConcreteNavigation gUI_ConcreteNavigation2 = navigations[navigations.Count - 1];
			gUI_ConcreteNavigation.Navigation.SelectOnLeft = outsideNavigation.SelectOnLeft.Clone();
			gUI_ConcreteNavigation2.Navigation.SelectOnRight = outsideNavigation.SelectOnRight.Clone();
			foreach (GUI_ConcreteNavigation navigation in navigations)
			{
				navigation.Navigation.SelectOnUp = outsideNavigation.SelectOnUp.Clone();
				navigation.Navigation.SelectOnDown = outsideNavigation.SelectOnDown.Clone();
			}
		}

		public static void SetLocalHorizontalNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations)
		{
			for (int i = 1; i < navigations.Count; i++)
			{
				GUI_ConcreteNavigation gUI_ConcreteNavigation = navigations[i - 1];
				GUI_ConcreteNavigation gUI_ConcreteNavigation2 = navigations[i];
				gUI_ConcreteNavigation.Navigation.SelectOnRight.SetExplicit(gUI_ConcreteNavigation2);
				gUI_ConcreteNavigation2.Navigation.SelectOnLeft.SetExplicit(gUI_ConcreteNavigation);
			}
		}

		public static void SetLocalChildNavigation(VerticalLayoutGroup verticalLayoutGroup)
		{
			SetLocalVerticalNavigation(GetChildNavigations(verticalLayoutGroup.transform));
		}

		public static void SetOutsideChildNavigation(VerticalLayoutGroup verticalLayoutGroup, ConcreteNavigation outsideNavigation)
		{
			SetOutsideVerticalNavigation(GetChildNavigations(verticalLayoutGroup.transform), outsideNavigation);
		}

		public static void SetLocalAndOutsideChildNavigation(VerticalLayoutGroup verticalLayoutGroup, ConcreteNavigation outsideNavigation)
		{
			GUI_ConcreteNavigation[] childNavigations = GetChildNavigations(verticalLayoutGroup.transform);
			SetLocalVerticalNavigation(childNavigations);
			SetOutsideVerticalNavigation(childNavigations, outsideNavigation);
		}

		public static void SetLocalVerticalNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations)
		{
			for (int i = 1; i < navigations.Count; i++)
			{
				GUI_ConcreteNavigation gUI_ConcreteNavigation = navigations[i - 1];
				GUI_ConcreteNavigation gUI_ConcreteNavigation2 = navigations[i];
				gUI_ConcreteNavigation.Navigation.SelectOnDown.SetExplicit(gUI_ConcreteNavigation2);
				gUI_ConcreteNavigation2.Navigation.SelectOnUp.SetExplicit(gUI_ConcreteNavigation);
			}
		}

		public static void SetOutsideVerticalNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations, ConcreteNavigation outsideNavigation)
		{
			if (navigations.Count == 0)
			{
				return;
			}
			GUI_ConcreteNavigation gUI_ConcreteNavigation = navigations[0];
			GUI_ConcreteNavigation gUI_ConcreteNavigation2 = navigations[navigations.Count - 1];
			gUI_ConcreteNavigation.Navigation.SelectOnUp = outsideNavigation.SelectOnUp.Clone();
			gUI_ConcreteNavigation2.Navigation.SelectOnDown = outsideNavigation.SelectOnDown.Clone();
			foreach (GUI_ConcreteNavigation navigation in navigations)
			{
				navigation.Navigation.SelectOnLeft = outsideNavigation.SelectOnLeft.Clone();
				navigation.Navigation.SelectOnRight = outsideNavigation.SelectOnRight.Clone();
			}
		}

		public static void GetColumnAndRow(GridLayoutGroup gridLayoutGroup, int count, out int columns, out int rows)
		{
			columns = 0;
			rows = 0;
			if (count != 0)
			{
				switch (gridLayoutGroup.constraint)
				{
				case GridLayoutGroup.Constraint.FixedColumnCount:
					columns = gridLayoutGroup.constraintCount;
					rows = Mathf.CeilToInt((float)count / (float)columns);
					break;
				case GridLayoutGroup.Constraint.FixedRowCount:
					rows = gridLayoutGroup.constraintCount;
					columns = Mathf.CeilToInt((float)count / (float)rows);
					break;
				case GridLayoutGroup.Constraint.Flexible:
				{
					RectTransform component = gridLayoutGroup.gameObject.GetComponent<RectTransform>();
					columns = Mathf.FloorToInt(component.sizeDelta.x / gridLayoutGroup.cellSize.x);
					rows = Mathf.CeilToInt((float)count / (float)columns);
					break;
				}
				}
			}
		}

		private static bool TryGetNavigationWithColumnDiagonals(IReadOnlyList<GUI_ConcreteNavigation> navigations, int column, int row, int columns, out GUI_ConcreteNavigation navigation)
		{
			if (TryGetNavigation(navigations, column, row, columns, out navigation))
			{
				return true;
			}
			for (int i = 1; i < columns; i++)
			{
				if (TryGetNavigation(navigations, column + i, row, columns, out navigation) || TryGetNavigation(navigations, column - i, row, columns, out navigation))
				{
					return true;
				}
			}
			return false;
		}

		private static bool TryGetNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations, int column, int row, int columns, out GUI_ConcreteNavigation navigation)
		{
			navigation = null;
			if (row < 0 || column < 0 || column >= columns)
			{
				return false;
			}
			int num = row * columns + column;
			if (num >= navigations.Count)
			{
				return false;
			}
			navigation = navigations[num];
			return true;
		}

		private static bool TryGetNavigation(Vector3 direction, GetNavigationArgs args, out GUI_ConcreteNavigation navigation)
		{
			navigation = null;
			GUI_BaseNavigation gUI_BaseNavigation = GUI_NavigationFinderHelper.FindSelectableFirstOrLast(args.Current.RectTransform, args.Validator, args.Navigations, direction);
			navigation = gUI_BaseNavigation as GUI_ConcreteNavigation;
			return navigation != null;
		}

		private static bool ContainsNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations, int column, int row, int columns)
		{
			if (row < 0 || column < 0 || column >= columns)
			{
				return false;
			}
			if (row * columns + column >= navigations.Count)
			{
				return false;
			}
			return true;
		}

		public static void SetLocalChildNavigation(GridLayoutGroup gridLayoutGroup)
		{
			GUI_ConcreteNavigation[] childNavigations = GetChildNavigations(gridLayoutGroup.transform);
			GetColumnAndRow(gridLayoutGroup, childNavigations.Length, out var columns, out var rows);
			SetLocalGridNavigation(childNavigations, columns, rows);
		}

		public static void SetOutsideChildNavigation(GridLayoutGroup gridLayoutGroup, ConcreteNavigation outsideNavigation)
		{
			GUI_ConcreteNavigation[] childNavigations = GetChildNavigations(gridLayoutGroup.transform);
			GetColumnAndRow(gridLayoutGroup, childNavigations.Length, out var columns, out var rows);
			SetOutsideGridNavigation(childNavigations, columns, rows, outsideNavigation, gridLayoutGroup);
		}

		public static void SetLocalAndOutsideChildNavigation(GridLayoutGroup gridLayoutGroup, ConcreteNavigation outsideNavigation)
		{
			GUI_ConcreteNavigation[] childNavigations = GetChildNavigations(gridLayoutGroup.transform);
			GetColumnAndRow(gridLayoutGroup, childNavigations.Length, out var columns, out var rows);
			bool num = IsTopToBottomOrder(gridLayoutGroup);
			int num2 = (num ? 1 : (-1));
			int num3 = ((!num) ? 1 : (-1));
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (TryGetNavigation(childNavigations, j, i, columns, out var navigation))
					{
						if (TryGetNavigation(childNavigations, j + 1, i, columns, out var navigation2))
						{
							navigation.Navigation.SelectOnRight.SetExplicit(navigation2);
						}
						else
						{
							navigation.Navigation.SelectOnRight = outsideNavigation.SelectOnRight.Clone();
						}
						if (TryGetNavigation(childNavigations, j - 1, i, columns, out var navigation3))
						{
							navigation.Navigation.SelectOnLeft.SetExplicit(navigation3);
						}
						else
						{
							navigation.Navigation.SelectOnLeft = outsideNavigation.SelectOnLeft.Clone();
						}
						if (TryGetNavigationWithColumnDiagonals(childNavigations, j, i + num2, columns, out var navigation4))
						{
							navigation.Navigation.SelectOnDown.SetExplicit(navigation4);
						}
						else
						{
							navigation.Navigation.SelectOnDown = outsideNavigation.SelectOnDown.Clone();
						}
						if (TryGetNavigationWithColumnDiagonals(childNavigations, j, i + num3, columns, out var navigation5))
						{
							navigation.Navigation.SelectOnUp.SetExplicit(navigation5);
						}
						else
						{
							navigation.Navigation.SelectOnUp = outsideNavigation.SelectOnUp.Clone();
						}
					}
				}
			}
		}

		public static void SetLocalAndOutsideChildNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations, ConcreteNavigation outsideNavigation, INavigationValidator validator)
		{
			GetNavigationArgs getNavigationArgs = new GetNavigationArgs
			{
				Navigations = navigations,
				Validator = validator
			};
			for (int i = 0; i < navigations.Count; i++)
			{
				GUI_ConcreteNavigation gUI_ConcreteNavigation = (getNavigationArgs.Current = navigations[i]);
				if (TryGetNavigation(Vector3.right, getNavigationArgs, out var navigation))
				{
					gUI_ConcreteNavigation.Navigation.SelectOnRight.SetExplicit(navigation);
				}
				else
				{
					gUI_ConcreteNavigation.Navigation.SelectOnRight = outsideNavigation.SelectOnRight.Clone();
				}
				if (TryGetNavigation(Vector3.left, getNavigationArgs, out var navigation2))
				{
					gUI_ConcreteNavigation.Navigation.SelectOnLeft.SetExplicit(navigation2);
				}
				else
				{
					gUI_ConcreteNavigation.Navigation.SelectOnLeft = outsideNavigation.SelectOnLeft.Clone();
				}
				if (TryGetNavigation(Vector3.down, getNavigationArgs, out var navigation3))
				{
					gUI_ConcreteNavigation.Navigation.SelectOnDown.SetExplicit(navigation3);
				}
				else
				{
					gUI_ConcreteNavigation.Navigation.SelectOnDown = outsideNavigation.SelectOnDown.Clone();
				}
				if (TryGetNavigation(Vector3.up, getNavigationArgs, out var navigation4))
				{
					gUI_ConcreteNavigation.Navigation.SelectOnUp.SetExplicit(navigation4);
				}
				else
				{
					gUI_ConcreteNavigation.Navigation.SelectOnUp = outsideNavigation.SelectOnUp.Clone();
				}
			}
		}

		public static void SetLocalGridNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations, int columns, int rows)
		{
			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows - 1; j++)
				{
					if (TryGetNavigation(navigations, i, j, columns, out var navigation) && TryGetNavigation(navigations, i + 1, j, columns, out var navigation2))
					{
						navigation.Navigation.SelectOnRight.SetExplicit(navigation2);
						navigation2.Navigation.SelectOnLeft.SetExplicit(navigation);
					}
				}
			}
			for (int k = 0; k < rows; k++)
			{
				for (int l = 0; l < columns - 1; l++)
				{
					if (TryGetNavigation(navigations, l, k, columns, out var navigation3) && TryGetNavigation(navigations, l, k + 1, columns, out var navigation4))
					{
						navigation3.Navigation.SelectOnDown.SetExplicit(navigation4);
						navigation4.Navigation.SelectOnUp.SetExplicit(navigation3);
					}
				}
			}
		}

		public static void SetOutsideGridNavigation(IReadOnlyList<GUI_ConcreteNavigation> navigations, int columns, int rows, ConcreteNavigation outsideNavigation, GridLayoutGroup gridLayoutGroup)
		{
			bool num = IsTopToBottomOrder(gridLayoutGroup);
			int num2 = (num ? 1 : (-1));
			int num3 = ((!num) ? 1 : (-1));
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (TryGetNavigation(navigations, j, i, columns, out var navigation))
					{
						if (!ContainsNavigation(navigations, j + 1, i, columns))
						{
							navigation.Navigation.SelectOnRight = outsideNavigation.SelectOnRight.Clone();
						}
						if (!ContainsNavigation(navigations, j - 1, i, columns))
						{
							navigation.Navigation.SelectOnLeft = outsideNavigation.SelectOnLeft.Clone();
						}
						if (!ContainsNavigation(navigations, j, i + num2, columns))
						{
							navigation.Navigation.SelectOnDown = outsideNavigation.SelectOnDown.Clone();
						}
						if (!ContainsNavigation(navigations, j, i + num3, columns))
						{
							navigation.Navigation.SelectOnUp = outsideNavigation.SelectOnUp.Clone();
						}
					}
				}
			}
		}

		private static bool IsTopToBottomOrder(GridLayoutGroup gridLayoutGroup)
		{
			if (gridLayoutGroup.startCorner != GridLayoutGroup.Corner.UpperLeft)
			{
				return gridLayoutGroup.startCorner == GridLayoutGroup.Corner.UpperRight;
			}
			return true;
		}
	}
}
