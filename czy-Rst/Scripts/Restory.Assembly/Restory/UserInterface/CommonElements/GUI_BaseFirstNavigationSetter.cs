using Restory.EventSystems;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public abstract class GUI_BaseFirstNavigationSetter : MonoBehaviour, IPrioritizedSelection
	{
		[SerializeField]
		protected bool autoRegisterOnEnable = true;

		protected ActiveSelectionService activeSelectionService;

		public abstract GameObject TargetNavigation { get; set; }

		public abstract NavigationPriority Priority { get; set; }

		[Inject]
		private void Construct(ActiveSelectionService activeSelectionService)
		{
			this.activeSelectionService = activeSelectionService;
			if (base.isActiveAndEnabled && autoRegisterOnEnable)
			{
				Register();
			}
		}

		protected virtual void OnEnable()
		{
			if (autoRegisterOnEnable)
			{
				Register();
			}
		}

		protected virtual void OnDisable()
		{
			if (autoRegisterOnEnable)
			{
				Unregister();
			}
		}

		public void Register()
		{
			if (!(activeSelectionService == null))
			{
				activeSelectionService.RegisterFirstSelection(this);
			}
		}

		public void Unregister()
		{
			if (!(activeSelectionService == null))
			{
				activeSelectionService.UnregisterFirstSelection(this);
			}
		}

		public void Select()
		{
			activeSelectionService.Select(TargetNavigation);
		}

		public abstract void SetTargetNavigation(GameObject targetNavigation);

		public abstract void SetPriority(NavigationPriority priority);
	}
}
