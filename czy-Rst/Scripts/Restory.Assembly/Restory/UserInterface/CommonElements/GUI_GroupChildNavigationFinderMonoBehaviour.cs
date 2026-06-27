using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public sealed class GUI_GroupChildNavigationFinderMonoBehaviour : GUI_BaseNavigationFinderMonoBehaviour
	{
		private class GroupChildNavigationValidator : INavigationValidator
		{
			public Transform Container { get; }

			public INavigationValidator ChildValidator { get; set; }

			public GroupChildNavigationValidator(Transform container)
			{
				Container = container;
			}

			public GUI_BaseNavigation ValidateNavigation(GUI_BaseNavigation navigation)
			{
				if (!navigation.RectTransform.IsChildOf(Container))
				{
					return null;
				}
				return ChildValidator.ValidateNavigation(navigation);
			}
		}

		private GroupChildNavigationValidator validator;

		private void Awake()
		{
			validator = new GroupChildNavigationValidator(base.transform);
		}

		public override GUI_BaseNavigation FindSelectable(GUI_BaseNavigation center, Vector3 dir, bool wrapAround)
		{
			validator.ChildValidator = center.Validator;
			return GUI_NavigationFinderHelper.FindSelectableFirstOrLast(center.RectTransform, validator, GUI_BaseNavigation.AllNavigations, dir, wrapAround);
		}
	}
}
