using System;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	[Serializable]
	public class ConcreteNavigation : IEquatable<ConcreteNavigation>
	{
		public enum ModeDir
		{
			None = 0,
			Automatic = 3,
			Explicit = 4,
			ExplicitFromFunction = 5
		}

		[Serializable]
		public class NavigationDir : IEquatable<NavigationDir>
		{
			[SerializeField]
			private ModeDir mode;

			[SerializeField]
			private bool wrapAround;

			[SerializeField]
			private GUI_BaseNavigation element;

			private FindFunction findFunction;

			private SimpleFindFunction simpleFindFunction;

			private bool simple;

			public ModeDir Mode
			{
				get
				{
					return mode;
				}
				set
				{
					mode = value;
				}
			}

			public bool WrapAround
			{
				get
				{
					return wrapAround;
				}
				set
				{
					wrapAround = value;
				}
			}

			public GUI_BaseNavigation Element
			{
				get
				{
					return element;
				}
				set
				{
					element = value;
				}
			}

			public bool Equals(NavigationDir other)
			{
				if (other.mode == mode && other.wrapAround == wrapAround && other.element == element)
				{
					return other.findFunction == findFunction;
				}
				return false;
			}

			public void SetAutomatic()
			{
				mode = ModeDir.Automatic;
				element = null;
				findFunction = null;
				simpleFindFunction = null;
				simple = false;
			}

			public void SetNone()
			{
				mode = ModeDir.None;
				element = null;
				findFunction = null;
				simpleFindFunction = null;
				simple = false;
				simple = false;
			}

			public void SetExplicit(GUI_BaseNavigation element)
			{
				mode = ModeDir.Explicit;
				this.element = element;
				findFunction = null;
				simpleFindFunction = null;
			}

			public void SetExplicitFromFunction(FindFunction findFunction)
			{
				mode = ModeDir.ExplicitFromFunction;
				element = null;
				this.findFunction = findFunction;
				simpleFindFunction = null;
				simple = false;
			}

			public void SetExplicitFromFunction(SimpleFindFunction findFunction)
			{
				mode = ModeDir.ExplicitFromFunction;
				element = null;
				this.findFunction = null;
				simpleFindFunction = findFunction;
				simple = true;
			}

			public GUI_BaseNavigation Find(GUI_BaseNavigation center, Vector3 direction)
			{
				if (simple)
				{
					return simpleFindFunction?.Invoke();
				}
				return findFunction?.Invoke(center, direction);
			}

			public NavigationDir Clone()
			{
				return new NavigationDir
				{
					mode = mode,
					wrapAround = wrapAround,
					element = element,
					findFunction = findFunction,
					simpleFindFunction = simpleFindFunction,
					simple = simple
				};
			}
		}

		[SerializeField]
		private NavigationDir selectOnUp = new NavigationDir();

		[SerializeField]
		private NavigationDir selectOnDown = new NavigationDir();

		[SerializeField]
		private NavigationDir selectOnLeft = new NavigationDir();

		[SerializeField]
		private NavigationDir selectOnRight = new NavigationDir();

		public NavigationDir SelectOnUp
		{
			get
			{
				return selectOnUp;
			}
			set
			{
				selectOnUp = value;
			}
		}

		public NavigationDir SelectOnDown
		{
			get
			{
				return selectOnDown;
			}
			set
			{
				selectOnDown = value;
			}
		}

		public NavigationDir SelectOnLeft
		{
			get
			{
				return selectOnLeft;
			}
			set
			{
				selectOnLeft = value;
			}
		}

		public NavigationDir SelectOnRight
		{
			get
			{
				return selectOnRight;
			}
			set
			{
				selectOnRight = value;
			}
		}

		public void SetNoneAll()
		{
			selectOnUp.SetNone();
			selectOnDown.SetNone();
			selectOnLeft.SetNone();
			selectOnRight.SetNone();
		}

		public void SetAutomaticAll()
		{
			selectOnUp.SetAutomatic();
			selectOnDown.SetAutomatic();
			selectOnLeft.SetAutomatic();
			selectOnRight.SetAutomatic();
		}

		public NavigationDir GetSelectOn(Vector3 direction)
		{
			if (direction == Vector3.up)
			{
				return selectOnUp;
			}
			if (direction == Vector3.down)
			{
				return selectOnDown;
			}
			if (direction == Vector3.left)
			{
				return selectOnLeft;
			}
			if (direction == Vector3.right)
			{
				return selectOnRight;
			}
			return null;
		}

		public GUI_BaseNavigation GetSelectable(GUI_BaseNavigation center, Vector3 direction, INavigationValidator validator, INavigationFinder finder)
		{
			NavigationDir selectOn = GetSelectOn(direction);
			return selectOn.Mode switch
			{
				ModeDir.Automatic => finder.FindSelectable(center, direction, selectOn.WrapAround), 
				ModeDir.Explicit => validator.ValidateNavigation(selectOn.Element), 
				ModeDir.ExplicitFromFunction => validator.ValidateNavigation(selectOn.Find(center, direction)), 
				_ => null, 
			};
		}

		public bool Equals(ConcreteNavigation other)
		{
			if (other.SelectOnUp.Equals(SelectOnUp) && other.SelectOnDown.Equals(SelectOnDown) && other.SelectOnLeft.Equals(SelectOnLeft))
			{
				return other.SelectOnRight.Equals(SelectOnRight);
			}
			return false;
		}

		public ConcreteNavigation Clone()
		{
			return new ConcreteNavigation
			{
				selectOnUp = selectOnUp.Clone(),
				selectOnDown = selectOnDown.Clone(),
				selectOnLeft = selectOnLeft.Clone(),
				selectOnRight = selectOnRight.Clone()
			};
		}
	}
}
