namespace TH20
{
	public abstract class ArrivalMethod : MustCallDestroy
	{
		protected readonly Level _level;

		protected readonly IArrivedCallback _arrivedCallback;

		protected ArrivalMethod(Level level, IArrivedCallback arrivedCallback)
		{
			_level = level;
			_arrivedCallback = arrivedCallback;
		}

		public abstract bool Update();

		public abstract bool IsValid();

		public void OnFail()
		{
			_arrivedCallback.OnFailed();
		}

		public abstract bool IsArriving(Character character);
	}
}
