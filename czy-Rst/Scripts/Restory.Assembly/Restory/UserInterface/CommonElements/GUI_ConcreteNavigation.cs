using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_ConcreteNavigation : GUI_BaseNavigation, IMoveHandler, IEventSystemHandler
	{
		[SerializeField]
		private ConcreteNavigation navigation = new ConcreteNavigation();

		[Space]
		[SerializeField]
		private Selectable targetSelectable;

		[SerializeField]
		private GUI_Interactable targetInteractable;

		public ConcreteNavigation Navigation
		{
			get
			{
				return navigation;
			}
			set
			{
				navigation = value;
			}
		}

		public override bool IsInteractable()
		{
			if (targetSelectable != null)
			{
				return targetSelectable.IsInteractable();
			}
			if (targetInteractable != null)
			{
				return targetInteractable.IsInteractable();
			}
			return true;
		}

		public GUI_BaseNavigation FindSelectableOnLeft()
		{
			return finder.FindSelectable(this, base.transform.rotation * Vector3.left, navigation.SelectOnLeft.WrapAround);
		}

		public GUI_BaseNavigation FindSelectableOnRight()
		{
			return finder.FindSelectable(this, base.transform.rotation * Vector3.right, navigation.SelectOnRight.WrapAround);
		}

		public GUI_BaseNavigation FindSelectableOnUp()
		{
			return finder.FindSelectable(this, base.transform.rotation * Vector3.up, navigation.SelectOnUp.WrapAround);
		}

		public GUI_BaseNavigation FindSelectableOnDown()
		{
			return finder.FindSelectable(this, base.transform.rotation * Vector3.down, navigation.SelectOnDown.WrapAround);
		}

		public override GUI_BaseNavigation GetSelectableOnLeft()
		{
			return navigation.SelectOnLeft.Mode switch
			{
				ConcreteNavigation.ModeDir.Automatic => FindSelectableOnLeft(), 
				ConcreteNavigation.ModeDir.Explicit => validator.ValidateNavigation(navigation.SelectOnLeft.Element), 
				ConcreteNavigation.ModeDir.ExplicitFromFunction => validator.ValidateNavigation(navigation.SelectOnLeft.Find(this, base.transform.rotation * Vector3.left)), 
				_ => null, 
			};
		}

		public override GUI_BaseNavigation GetSelectableOnRight()
		{
			return navigation.SelectOnRight.Mode switch
			{
				ConcreteNavigation.ModeDir.Automatic => FindSelectableOnRight(), 
				ConcreteNavigation.ModeDir.Explicit => validator.ValidateNavigation(navigation.SelectOnRight.Element), 
				ConcreteNavigation.ModeDir.ExplicitFromFunction => validator.ValidateNavigation(navigation.SelectOnRight.Find(this, base.transform.rotation * Vector3.right)), 
				_ => null, 
			};
		}

		public override GUI_BaseNavigation GetSelectableOnUp()
		{
			return navigation.SelectOnUp.Mode switch
			{
				ConcreteNavigation.ModeDir.Automatic => FindSelectableOnUp(), 
				ConcreteNavigation.ModeDir.Explicit => validator.ValidateNavigation(navigation.SelectOnUp.Element), 
				ConcreteNavigation.ModeDir.ExplicitFromFunction => validator.ValidateNavigation(navigation.SelectOnUp.Find(this, base.transform.rotation * Vector3.up)), 
				_ => null, 
			};
		}

		public override GUI_BaseNavigation GetSelectableOnDown()
		{
			return navigation.SelectOnDown.Mode switch
			{
				ConcreteNavigation.ModeDir.Automatic => FindSelectableOnDown(), 
				ConcreteNavigation.ModeDir.Explicit => validator.ValidateNavigation(navigation.SelectOnDown.Element), 
				ConcreteNavigation.ModeDir.ExplicitFromFunction => validator.ValidateNavigation(navigation.SelectOnDown.Find(this, base.transform.rotation * Vector3.down)), 
				_ => null, 
			};
		}

		public virtual void OnMove(AxisEventData eventData)
		{
			if (IsInteractable())
			{
				switch (eventData.moveDir)
				{
				case MoveDirection.Right:
					Navigate(eventData, GetSelectableOnRight());
					break;
				case MoveDirection.Up:
					Navigate(eventData, GetSelectableOnUp());
					break;
				case MoveDirection.Left:
					Navigate(eventData, GetSelectableOnLeft());
					break;
				case MoveDirection.Down:
					Navigate(eventData, GetSelectableOnDown());
					break;
				}
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			navigation.SetNoneAll();
		}
	}
}
