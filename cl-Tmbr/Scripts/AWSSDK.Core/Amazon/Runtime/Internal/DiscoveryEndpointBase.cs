using System;

namespace Amazon.Runtime.Internal
{
	public abstract class DiscoveryEndpointBase
	{
		private DateTime _createdOn;

		private string _address;

		private long _cachePeriodInMinutes;

		private object objectExtendLock = new object();

		public string Address
		{
			get
			{
				return _address;
			}
			protected set
			{
				string text = value;
				if (text != null && !text.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !text.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
				{
					text = "https://" + text;
				}
				_address = text;
			}
		}

		public long CachePeriodInMinutes
		{
			get
			{
				return _cachePeriodInMinutes;
			}
			protected set
			{
				_cachePeriodInMinutes = value;
			}
		}

		protected DiscoveryEndpointBase(string address, long cachePeriodInMinutes)
		{
			Address = address;
			CachePeriodInMinutes = cachePeriodInMinutes;
			_createdOn = DateTime.UtcNow;
		}

		public bool HasExpired()
		{
			return (DateTime.UtcNow - _createdOn).TotalMinutes > (double)CachePeriodInMinutes;
		}

		public void ExtendExpiration(long minutes)
		{
			lock (objectExtendLock)
			{
				CachePeriodInMinutes = minutes;
				_createdOn = DateTime.UtcNow;
			}
		}
	}
}
