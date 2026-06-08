namespace RTLTMPro
{
	public struct TashkeelLocation
	{
		private char _003CTashkeel_003Ek__BackingField;

		private int _003CPosition_003Ek__BackingField;

		public char Tashkeel
		{
			get
			{
				return _003CTashkeel_003Ek__BackingField;
			}
			set
			{
				_003CTashkeel_003Ek__BackingField = value;
			}
		}

		public int Position
		{
			get
			{
				return _003CPosition_003Ek__BackingField;
			}
			set
			{
				_003CPosition_003Ek__BackingField = value;
			}
		}

		public TashkeelLocation(TashkeelCharacters tashkeel, int position)
		{
			this = default(TashkeelLocation);
			Tashkeel = (char)tashkeel;
			Position = position;
		}
	}
}
