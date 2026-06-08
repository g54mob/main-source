using Controllers;

namespace Kitchen
{
	public struct InputIdentifier
	{
		public SourceIdentifier InputSource;

		public int PlayerID;

		public InputIdentifier(SourceIdentifier source, int id)
		{
			InputSource = source;
			PlayerID = id;
		}

		public static implicit operator InputIdentifier(CPlayer ply)
		{
			return new InputIdentifier(ply.InputSource, ply.ID);
		}
	}
}
