using Restory.EventSystems;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_SingleFirstNavigationSetter : GUI_BaseFirstNavigationSetter
	{
		[SerializeField]
		private GameObject targetNavigation;

		[SerializeField]
		private NavigationPriority priority = NavigationPriority.Default;

		public override GameObject TargetNavigation
		{
			get
			{
				return targetNavigation;
			}
			set
			{
				SetTargetNavigation(value);
			}
		}

		public override NavigationPriority Priority
		{
			get
			{
				return priority;
			}
			set
			{
				SetPriority(value);
			}
		}

		public override void SetTargetNavigation(GameObject targetNavigation)
		{
			this.targetNavigation = targetNavigation;
		}

		public override void SetPriority(NavigationPriority priority)
		{
			this.priority = priority;
		}
	}
}
