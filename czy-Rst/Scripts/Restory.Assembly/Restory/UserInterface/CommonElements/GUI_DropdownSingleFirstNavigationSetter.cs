using Restory.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_DropdownSingleFirstNavigationSetter : MonoBehaviour
	{
		[SerializeField]
		private GUI_Dropdown dropdown;

		[SerializeField]
		private GUI_SingleFirstNavigationSetter firstNavigationSetter;

		private GameObject lastSelectedGameObject;

		private ActiveSelectionService activeSelectionService;

		[Inject]
		private void Construct(ActiveSelectionService activeSelectionService)
		{
			this.activeSelectionService = activeSelectionService;
			if (base.isActiveAndEnabled)
			{
				dropdown.IsShownChanged += ResolveIsShownChanged;
				if (dropdown.IsShown)
				{
					Register();
				}
			}
		}

		private void OnEnable()
		{
			dropdown.IsShownChanged += ResolveIsShownChanged;
			if (dropdown.IsShown)
			{
				Register();
			}
		}

		private void OnDisable()
		{
			dropdown.IsShownChanged -= ResolveIsShownChanged;
		}

		private void ResolveCurrentSelectionChanged(GameObject value)
		{
			if (dropdown.IsShown)
			{
				GameObject currentSelection = activeSelectionService.CurrentSelection;
				if (currentSelection != null && currentSelection.transform.IsChildOf(dropdown.transform))
				{
					firstNavigationSetter.TargetNavigation = currentSelection;
				}
			}
		}

		private void ResolveIsShownChanged(Dropdown dropdown, bool isShown)
		{
			if (isShown)
			{
				Register();
			}
			else
			{
				Unregister();
			}
		}

		private void Register()
		{
			activeSelectionService.CurrentSelectionChanged += ResolveCurrentSelectionChanged;
			firstNavigationSetter.Register();
			lastSelectedGameObject = activeSelectionService.CurrentSelection;
		}

		private void Unregister()
		{
			activeSelectionService.CurrentSelectionChanged -= ResolveCurrentSelectionChanged;
			firstNavigationSetter.Unregister();
			activeSelectionService.Select(lastSelectedGameObject);
		}
	}
}
