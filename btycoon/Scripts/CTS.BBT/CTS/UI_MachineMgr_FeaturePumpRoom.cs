using CTS.BBT;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UI_MachineMgr_FeaturePumpRoom : UI_MachineMgr_MachinePanelFeature<StationDrink>
	{
		[SerializeField]
		private CTSButton _leftButton;

		[SerializeField]
		private CTSButton _rightButton;

		[SerializeField]
		private TMP_Text _textContainer;

		[SerializeField]
		private LocalizedString _sameRoomString;

		[SerializeField]
		private LocalizedString _adjacentRoomString;

		[SerializeField]
		private LocalizedString _allRoomString;

		protected override void OnAwake()
		{
			base.OnAwake();
			_leftButton.onClick.AddListener(OnLeftButtonClicked);
			_rightButton.onClick.AddListener(OnRightButtonClicked);
		}

		protected override void OnRepaint()
		{
			if ((object)base._currentFurniture != null)
			{
				string text = ((!base._currentFurniture.ServeAllRooms) ? _sameRoomString.GetLocalizedStringSafe() : _allRoomString.GetLocalizedStringSafe());
				int num = text.IndexOf(':');
				if (num != -1)
				{
					text = text.Substring(num + 1);
				}
				_textContainer.text = text;
			}
		}

		protected override bool CanBeDisplayedForFurniture(StationDrink furniture)
		{
			return true;
		}

		protected override void OnFurnitureSet(StationDrink furniture)
		{
			furniture.ServeRoomChanged += OnServeRoomChanged;
		}

		protected override void OnFurnitureUnset(StationDrink furniture)
		{
			furniture.ServeRoomChanged -= OnServeRoomChanged;
		}

		private void OnRightButtonClicked()
		{
			base._currentFurniture.SetServeAllRooms(!base._currentFurniture.ServeAllRooms);
		}

		private void OnLeftButtonClicked()
		{
			base._currentFurniture.SetServeAllRooms(!base._currentFurniture.ServeAllRooms);
		}

		private void OnServeRoomChanged()
		{
			Repaint();
		}
	}
}
