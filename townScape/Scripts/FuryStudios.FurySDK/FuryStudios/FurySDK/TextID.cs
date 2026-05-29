namespace FuryStudios.FurySDK
{
	public struct TextID
	{
		public string id;

		public TextID(string id)
		{
			this.id = null;
		}

		public static explicit operator string(TextID text)
		{
			return null;
		}

		public static implicit operator TextID(string id)
		{
			return default(TextID);
		}
	}
}
