using Gh.Tk.UI.InfoPanels;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class UnlockRoomActionButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private TextMeshPro _moneyText;

		[SerializeField]
		private RoomInfoPanel _parentRoomInfoPanel;

		private Room _target;

		public Room TargetRoom
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private bool CanUnlockRoom()
		{
			return false;
		}

		protected override void Start()
		{
		}

		public override void CheckState()
		{
		}

		private void Update()
		{
		}

		private void UpdateMoneyText()
		{
		}
	}
}
