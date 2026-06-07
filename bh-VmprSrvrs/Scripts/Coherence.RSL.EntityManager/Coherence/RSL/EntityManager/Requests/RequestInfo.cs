using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.RSL.EntityManager.Requests
{
	public abstract class RequestInfo : IRequest, IBaseRequest
	{
		protected Entity entity;

		private uint participant;

		private FloatingOrigin floatingOrigin;

		private EntityMeta meta;

		public RequestMode Mode { get; set; }

		public ChannelID ChannelID { get; set; }

		public RequestInfo(Entity entity, uint participant, FloatingOrigin origin, EntityMeta meta, bool isInternal)
		{
		}

		public RequestInfo(Entity entity, uint participant, FloatingOrigin origin, EntityMeta meta, RequestMode mode)
		{
		}

		public Entity GetEntity()
		{
			return default(Entity);
		}

		public uint GetParticipant()
		{
			return 0u;
		}

		public FloatingOrigin GetFloatingOrigin()
		{
			return default(FloatingOrigin);
		}

		public void SetFloatingOrigin(FloatingOrigin origin)
		{
		}

		public EntityMeta GetMeta()
		{
			return default(EntityMeta);
		}

		public bool GetIsInternal()
		{
			return false;
		}

		public virtual IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger _)
		{
			return default(IEntityMapper.Error);
		}

		public virtual RefsInfo GetReferenceInfo()
		{
			return default(RefsInfo);
		}
	}
}
