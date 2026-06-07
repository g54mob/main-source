using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.TavernMenu
{
	public class TavernMenuDialog3DUIView : BaseDialog3DUIView
	{
		public static DissolveArea3DUIView DissolveArea;

		[SerializeField]
		private DissolveArea3DUIView _dissolveArea;

		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Button3DUIView _createMealButton;

		[SerializeField]
		private TavernMenuPage _foodItemsPage;

		[SerializeField]
		private TavernMenuPage _drinkItemsPage;

		[SerializeField]
		private BaseInteractable3DUIView _shopPageButton;

		[SerializeField]
		private BaseInteractable3DUIView _accomodationPageButton;

		[SerializeField]
		private TavernMenuPage _shopPage;

		[SerializeField]
		private TavernMenuPage _accomodationPage;

		[SerializeField]
		private Transform _unkownFoodIcon;

		[SerializeField]
		private Transform _researchedFoodIcon;

		[SerializeField]
		private Transform _unkownShopIcon;

		[SerializeField]
		private Transform _researchedShopIcon;

		[SerializeField]
		private GameObject[] _filledStars;

		[SerializeField]
		private GameObject[] _filledHalfStars;

		[SerializeField]
		private GameObject[] _emptyStars;

		[SerializeField]
		private List<GameObject> _hideOnForceClose;

		protected override void Awake()
		{
		}

		public void SetShopAccommodationPage(bool isShop)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Opened()
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void RefreshStars()
		{
		}
	}
}
