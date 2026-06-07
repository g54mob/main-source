using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Ui
{
	public class GenericMenuNavigator : MonoBehaviour, UiMaster.IUiSetup
	{
		private enum Mode
		{
			Vertical = 0,
			Horizontal = 1
		}

		public interface INavigableMenu
		{
			void Close(bool openLastMenu);

			UpdateState GetMainUpdateState();
		}

		private UiMaster master;

		private INavigableMenu navigableMenu;

		[SerializeField]
		private BetterScrollRect scrollRect;

		[SerializeField]
		private List<NavigableButton> navigableButtons;

		[SerializeField]
		private NavigableButton selectedButton;

		private RapidButton rapidX;

		private RapidButton rapidY;

		[SerializeReference]
		private Transform selectorTransform;

		[SerializeField]
		private Mode mode;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void Update()
		{
		}

		private void UpdateScroll()
		{
		}

		private void UpdateControls()
		{
		}

		private void SelectButton(NavigableButton button)
		{
		}

		public void ResetNavigation()
		{
		}
	}
}
