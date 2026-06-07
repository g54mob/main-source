using System;

namespace Epic.OnlineServices.Connect
{
	public class ExternalAccountInfo : ISettable
	{
		public ProductUserId ProductUserId { get; set; }

		public string DisplayName { get; set; }

		public string AccountId { get; set; }

		public ExternalAccountType AccountIdType { get; set; }

		public DateTimeOffset? LastLoginTime { get; set; }

		internal void Set(ExternalAccountInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
