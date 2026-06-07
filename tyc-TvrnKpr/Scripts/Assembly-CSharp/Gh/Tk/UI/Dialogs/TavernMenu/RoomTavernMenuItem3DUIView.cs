using Gh.Tk.UI.InfoPanels;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.TavernMenu
{
	public class RoomTavernMenuItem3DUIView : TavernMenuItem3DUIView
	{
		[SerializeField]
		private LinenSelectionButton3DUIView _linenSelectionButton;

		[SerializeField]
		private TextMeshProI18n _bedsText;

		[SerializeField]
		private BaseInteractable3DUIView _locateButton;

		[SerializeField]
		private BaseInteractable3DUIView _openScheduleButton;

		private Room _room;

		protected override void Start()
		{
		}

		public virtual void SetData(Room room)
		{
		}

		protected override void UpdateRatingInfo()
		{
		}
	}
}
