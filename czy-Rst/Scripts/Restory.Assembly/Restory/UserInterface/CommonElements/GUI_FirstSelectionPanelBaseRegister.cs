using Restory.UserInterface.GameplayMenu;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public sealed class GUI_FirstSelectionPanelBaseRegister : MonoBehaviour
	{
		[SerializeField]
		private GUI_BaseFirstNavigationSetter firstSelection;

		[SerializeField]
		private GUI_PanelBase panelBase;

		private void OnEnable()
		{
			panelBase.OnShown.AddListener(ResolveScreenObjectBaseOnShown);
			panelBase.OnHidden.AddListener(ResolveScreenObjectBaseOnHidden);
			if (panelBase.IsActive)
			{
				ResolveScreenObjectBaseOnShown();
			}
		}

		private void OnDisable()
		{
			panelBase.OnShown.RemoveListener(ResolveScreenObjectBaseOnShown);
			panelBase.OnHidden.RemoveListener(ResolveScreenObjectBaseOnHidden);
			firstSelection.Unregister();
		}

		private void ResolveScreenObjectBaseOnShown()
		{
			firstSelection.Register();
		}

		private void ResolveScreenObjectBaseOnHidden()
		{
			firstSelection.Unregister();
		}
	}
}
