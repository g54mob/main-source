namespace Mandragora.PWS
{
	public struct AffectedColorChannels
	{
		public bool Red;

		public bool Green;

		public bool Blue;

		public bool Alpha;

		public bool IsAnyChannelAffected
		{
			get
			{
				if (!Red && !Green && !Blue)
				{
					return Alpha;
				}
				return true;
			}
		}
	}
}
