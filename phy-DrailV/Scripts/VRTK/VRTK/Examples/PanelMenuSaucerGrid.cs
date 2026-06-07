using UnityEngine;
using UnityEngine.UI;

namespace VRTK.Examples
{
	public class PanelMenuSaucerGrid : MonoBehaviour
	{
		protected enum Direction
		{
			None = 0,
			Up = 1,
			Down = 2,
			Left = 3,
			Right = 4
		}

		public GridLayoutGroup gridLayoutGroup;

		public MeshRenderer changeObject;

		public VRTK_PanelMenuItemController panelMenuController;

		public Color[] colours = new Color[0];

		protected int currentIndex;

		protected readonly Color colorDefault = Color.white;

		protected readonly Color colorSelected = Color.green;

		protected readonly float colorAlpha = 0.25f;

		protected virtual void OnEnable()
		{
			if (panelMenuController != null)
			{
				panelMenuController.PanelMenuItemSwipeTop += PanelMenuItemSwipeTop;
				panelMenuController.PanelMenuItemSwipeBottom += PanelMenuItemSwipeBottom;
				panelMenuController.PanelMenuItemSwipeLeft += PanelMenuItemSwipeLeft;
				panelMenuController.PanelMenuItemSwipeRight += PanelMenuItemSwipeRight;
				panelMenuController.PanelMenuItemTriggerPressed += PanelMenuItemTriggerPressed;
			}
			SetGridLayoutItemSelectedState(currentIndex);
		}

		protected virtual void PanelMenuItemTriggerPressed(object sender, PanelMenuItemControllerEventArgs e)
		{
			if (currentIndex < colours.Length && changeObject != null)
			{
				changeObject.material.color = colours[currentIndex];
			}
		}

		protected virtual void PanelMenuItemSwipeRight(object sender, PanelMenuItemControllerEventArgs e)
		{
			MoveSelectGridLayoutItem(Direction.Right);
		}

		protected virtual void PanelMenuItemSwipeLeft(object sender, PanelMenuItemControllerEventArgs e)
		{
			MoveSelectGridLayoutItem(Direction.Left);
		}

		protected virtual void PanelMenuItemSwipeBottom(object sender, PanelMenuItemControllerEventArgs e)
		{
			MoveSelectGridLayoutItem(Direction.Down);
		}

		protected virtual void PanelMenuItemSwipeTop(object sender, PanelMenuItemControllerEventArgs e)
		{
			MoveSelectGridLayoutItem(Direction.Up);
		}

		protected virtual void SetGridLayoutItemSelectedState(int index)
		{
			foreach (Transform item in gridLayoutGroup.transform)
			{
				GameObject gameObject = item.gameObject;
				if (gameObject != null)
				{
					Color color = colorDefault;
					color.a = colorAlpha;
					gameObject.GetComponent<Image>().color = color;
				}
			}
			Transform child = gridLayoutGroup.transform.GetChild(index);
			if (child != null)
			{
				Color color2 = colorSelected;
				color2.a = colorAlpha;
				child.GetComponent<Image>().color = color2;
			}
		}

		protected virtual bool MoveSelectGridLayoutItem(Direction direction)
		{
			int num = FindNextItemBasedOnMoveDirection(direction);
			if (num != currentIndex)
			{
				SetGridLayoutItemSelectedState(num);
				currentIndex = num;
			}
			return true;
		}

		protected virtual int FindNextItemBasedOnMoveDirection(Direction direction)
		{
			float preferredWidth = gridLayoutGroup.preferredWidth;
			float x = gridLayoutGroup.cellSize.x;
			float x2 = gridLayoutGroup.spacing.x;
			int num = (int)Mathf.Floor(preferredWidth / (x + x2 / 2f));
			int childCount = gridLayoutGroup.transform.childCount;
			switch (direction)
			{
			case Direction.Up:
			{
				int num4 = currentIndex - num;
				if (num4 < 0)
				{
					return currentIndex;
				}
				return num4;
			}
			case Direction.Down:
			{
				int num3 = currentIndex + num;
				if (num3 >= childCount)
				{
					return currentIndex;
				}
				return num3;
			}
			case Direction.Left:
			{
				int num5 = currentIndex - 1;
				if (num5 < 0)
				{
					return currentIndex;
				}
				return num5;
			}
			case Direction.Right:
			{
				int num2 = currentIndex + 1;
				if (num2 >= childCount)
				{
					return currentIndex;
				}
				return num2;
			}
			default:
				return currentIndex;
			}
		}
	}
}
