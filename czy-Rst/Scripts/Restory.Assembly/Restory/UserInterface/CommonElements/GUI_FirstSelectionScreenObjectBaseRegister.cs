using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public sealed class GUI_FirstSelectionScreenObjectBaseRegister : MonoBehaviour
	{
		[SerializeField]
		private GUI_BaseFirstNavigationSetter firstSelection;

		[SerializeField]
		private GUI_ScreenObjectBase screenObjectBase;

		private void OnEnable()
		{
			screenObjectBase.OnShown.AddListener(ResolveScreenObjectBaseOnShown);
			screenObjectBase.OnHidden.AddListener(ResolveScreenObjectBaseOnHidden);
			if (screenObjectBase.IsOpen)
			{
				ResolveScreenObjectBaseOnShown();
			}
		}

		private void OnDisable()
		{
			screenObjectBase.OnShown.RemoveListener(ResolveScreenObjectBaseOnShown);
			screenObjectBase.OnHidden.RemoveListener(ResolveScreenObjectBaseOnHidden);
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
