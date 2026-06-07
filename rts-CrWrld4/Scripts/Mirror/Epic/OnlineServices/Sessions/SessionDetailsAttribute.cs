namespace Epic.OnlineServices.Sessions
{
	public class SessionDetailsAttribute : ISettable
	{
		public AttributeData Data { get; set; }

		public SessionAttributeAdvertisementType AdvertisementType { get; set; }

		internal void Set(SessionDetailsAttributeInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
