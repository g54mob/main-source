namespace Coherence.RSL.EntityManager.Requests
{
	public struct ResponseInfo
	{
		public ResponseInfoType Type;

		private IRequest request;

		private bool applied;

		private EntityMeta meta;

		public ResponseInfo(IRequest request, bool applied, EntityMeta meta, ResponseInfoType type)
		{
			Type = default(ResponseInfoType);
			this.request = null;
			this.applied = false;
			this.meta = default(EntityMeta);
		}

		public static ResponseInfo Standard(IRequest request, bool applied, EntityMeta meta)
		{
			return default(ResponseInfo);
		}

		public static ResponseInfo ResolveDuplicate(IRequest request, bool applied, EntityMeta meta)
		{
			return default(ResponseInfo);
		}

		public IRequest GetRequest()
		{
			return null;
		}

		public bool WasApplied()
		{
			return false;
		}

		public EntityMeta GetMeta()
		{
			return default(EntityMeta);
		}
	}
}
