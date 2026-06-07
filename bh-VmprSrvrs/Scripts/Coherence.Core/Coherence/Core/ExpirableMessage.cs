using System;
using Coherence.ProtocolDef;

namespace Coherence.Core
{
	internal struct ExpirableMessage
	{
		public readonly IEntityMessage Message;

		public readonly DateTime ExpirationDate;

		public ExpirableMessage(IEntityMessage message, DateTime expirationDate)
		{
			Message = null;
			ExpirationDate = default(DateTime);
		}

		public bool HasExpired(in DateTime now)
		{
			return false;
		}
	}
}
