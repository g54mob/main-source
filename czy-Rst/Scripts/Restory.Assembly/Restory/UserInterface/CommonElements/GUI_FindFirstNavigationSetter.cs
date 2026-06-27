using System;
using Restory.EventSystems;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_FindFirstNavigationSetter : GUI_BaseFirstNavigationSetter
	{
		[SerializeField]
		private NavigationPriority priority = NavigationPriority.Default;

		private Func<GameObject> findFunction;

		public override GameObject TargetNavigation
		{
			get
			{
				return findFunction?.Invoke();
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

		public Func<GameObject> FindFunction
		{
			get
			{
				return findFunction;
			}
			set
			{
				SetFindFunction(value);
			}
		}

		private void OnDestroy()
		{
			findFunction = null;
		}

		public override void SetTargetNavigation(GameObject targetNavigation)
		{
			findFunction = () => targetNavigation;
		}

		public override void SetPriority(NavigationPriority priority)
		{
			this.priority = priority;
		}

		public void SetFindFunction(Func<GameObject> findFunction)
		{
			this.findFunction = findFunction;
		}
	}
}
