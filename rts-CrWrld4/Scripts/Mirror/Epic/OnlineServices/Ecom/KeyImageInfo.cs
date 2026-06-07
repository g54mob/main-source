namespace Epic.OnlineServices.Ecom
{
	public class KeyImageInfo : ISettable
	{
		public string Type { get; set; }

		public string Url { get; set; }

		public uint Width { get; set; }

		public uint Height { get; set; }

		internal void Set(KeyImageInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
