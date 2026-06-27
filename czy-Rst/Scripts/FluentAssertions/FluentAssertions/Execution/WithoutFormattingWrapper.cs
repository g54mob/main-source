namespace FluentAssertions.Execution
{
	internal class WithoutFormattingWrapper
	{
		public WithoutFormattingWrapper(string value)
		{
			_003Cvalue_003EP = value;
			base._002Ector();
		}

		public override string ToString()
		{
			return _003Cvalue_003EP;
		}
	}
}
