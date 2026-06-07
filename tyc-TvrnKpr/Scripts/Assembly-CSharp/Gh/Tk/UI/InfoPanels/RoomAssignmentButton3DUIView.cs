using System;
using TMPro;

namespace Gh.Tk.UI.InfoPanels
{
	public class RoomAssignmentButton3DUIView : Button3DUIView
	{
		public TextMeshPro numberValueText;

		private WeakReference<GameObjectX> _gox;

		public GameObjectX Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Start()
		{
		}

		private void OnStaffExcludedRoomsChanged(object sender, EventArgs<Staff> e)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Invalidate()
		{
		}

		public override void CheckState()
		{
		}

		public override void OnClicked()
		{
		}
	}
}
