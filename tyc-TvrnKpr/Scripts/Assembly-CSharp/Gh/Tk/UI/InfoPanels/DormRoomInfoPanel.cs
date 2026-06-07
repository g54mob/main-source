using System;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class DormRoomInfoPanel : RoomInfoPanel
	{
		[SerializeField]
		private PriceButtonInfoPanel3DUIView _priceButton;

		[SerializeField]
		private LinenSelectionButton3DUIView _linenSelectionButton;

		public override Room Room
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Closed()
		{
		}

		private void OnLinenTypeChanged(object sender, EventArgs e)
		{
		}

		private void RefreshLinenSelectionButton()
		{
		}

		public override void ShowInfo(GameObjectX gox)
		{
		}

		protected override void OnEnable()
		{
		}
	}
}
