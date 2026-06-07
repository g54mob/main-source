namespace UI.Elements
{
	public class ElementColoredButtonParameters
	{
		public string dictId;

		public IElementColoredButtonParameters value;

		public ElementColoredButtonParameters(string dictId, IElementColoredButtonParameters value)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
