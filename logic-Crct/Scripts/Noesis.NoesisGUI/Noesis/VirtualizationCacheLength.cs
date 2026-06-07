namespace Noesis
{
	public struct VirtualizationCacheLength
	{
		private float _beforeViewport;

		private float _afterViewport;

		public float CacheBeforeViewport => 0f;

		public float CacheAfterViewport => 0f;

		public VirtualizationCacheLength(float cacheBeforeAndAfterViewport)
		{
			_beforeViewport = 0f;
			_afterViewport = 0f;
		}

		public VirtualizationCacheLength(float cacheBeforeViewport, float cacheAfterViewport)
		{
			_beforeViewport = 0f;
			_afterViewport = 0f;
		}

		public static bool operator ==(VirtualizationCacheLength l1, VirtualizationCacheLength l2)
		{
			return false;
		}

		public static bool operator !=(VirtualizationCacheLength l1, VirtualizationCacheLength l2)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public bool Equals(VirtualizationCacheLength other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
