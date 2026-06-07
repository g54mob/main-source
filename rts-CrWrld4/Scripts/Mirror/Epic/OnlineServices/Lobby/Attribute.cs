namespace Epic.OnlineServices.Lobby
{
	public class Attribute : ISettable
	{
		public AttributeData Data { get; set; }

		public LobbyAttributeVisibility Visibility { get; set; }

		internal void Set(AttributeInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
