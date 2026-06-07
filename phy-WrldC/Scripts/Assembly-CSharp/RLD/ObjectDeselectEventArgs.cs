namespace RLD
{
	public class ObjectDeselectEventArgs
	{
		private ObjectDeselectReason _deselectReason;

		public ObjectDeselectReason DeselectReason => _deselectReason;

		public ObjectDeselectEventArgs(ObjectDeselectReason deselectReason)
		{
			_deselectReason = deselectReason;
		}
	}
}
