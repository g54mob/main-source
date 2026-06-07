namespace GAudio
{
	public abstract class RetainableObject : IRetainable
	{
		protected int _retainCount;

		public int RetainCount => _retainCount;

		public void Retain()
		{
			_retainCount++;
		}

		public void Release()
		{
			_retainCount--;
			if (_retainCount < 1)
			{
				Discard();
			}
		}

		protected abstract void Discard();
	}
}
