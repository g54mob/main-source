namespace RLD
{
	public class ObjectSelectEventArgs
	{
		private ObjectSelectReason _selectReason;

		public ObjectSelectReason SelectReason => _selectReason;

		public ObjectSelectEventArgs(ObjectSelectReason selectReason)
		{
			_selectReason = selectReason;
		}
	}
}
