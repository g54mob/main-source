using System;
using System.Collections.Generic;

namespace GRP.Net
{
	public class NetIdGeneratorClient
	{
		public NetSessionClient session;

		public Func<IdGenerator> idGenerator;

		public int tag;

		public List<Id> generatedIds;

		public bool generatingId;

		private bool postRequest;

		private int postCount;

		public NetIdGeneratorClient(NetSessionClient session, Func<IdGenerator> idGenerator, int tag)
		{
		}

		public void Reset()
		{
		}

		public bool TryReadId(out Id id)
		{
			id = default(Id);
			return false;
		}

		public bool CanReadId(int count)
		{
			return false;
		}

		public void EnsureId(int count)
		{
		}

		public void Build()
		{
		}
	}
}
