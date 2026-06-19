namespace TH20
{
	public abstract class InspectorSubDataRoom
	{
		protected Room _room;

		protected Level Level => _room.Level;

		protected InspectorSubDataRoom(Room room)
		{
			_room = room;
		}

		public abstract string GetText();

		public abstract string GetTooltip();

		public abstract bool OnButtonPressed();

		public abstract bool ShouldShowButton();
	}
}
