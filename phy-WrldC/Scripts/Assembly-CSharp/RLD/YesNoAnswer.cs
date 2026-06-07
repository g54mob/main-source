namespace RLD
{
	public class YesNoAnswer
	{
		private bool _hasYes;

		private bool _hasNo;

		public bool HasYes => _hasYes;

		public bool HasNo => _hasNo;

		public bool HasOnlyYes
		{
			get
			{
				if (HasYes)
				{
					return !HasNo;
				}
				return false;
			}
		}

		public void Yes()
		{
			_hasYes = true;
		}

		public void No()
		{
			_hasNo = true;
		}
	}
}
