namespace Epic.OnlineServices.Sanctions
{
	public class PlayerSanction : ISettable
	{
		public long TimePlaced { get; set; }

		public string Action { get; set; }

		internal void Set(PlayerSanctionInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
