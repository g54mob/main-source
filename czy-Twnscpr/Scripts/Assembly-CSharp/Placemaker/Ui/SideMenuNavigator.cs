using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class SideMenuNavigator : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		public UiMaster master;

		[SerializeField]
		private NavigableButton selectedButton;

		[SerializeField]
		private RectTransform selectorTransform;

		[SerializeField]
		private List<NavigableButton> navigableButtons;

		public UpdateState targetArrowY;

		public UpdateState targetArrowX;

		public UpdateState openState;

		[SerializeField]
		private BetterScrollRect scrollRect;

		private RapidButton rapidY;

		private RapidButton rapidX;

		[SerializeField]
		private bool isPanning;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void SelectButton(NavigableButton button)
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

		private void SetTargetsToButton()
		{
		}

		private void SetTargetsToButton(NavigableButton button)
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		public void ResetNavigation()
		{
		}
	}
}
