using System.Collections.Generic;

namespace GRP.Net
{
	public class ProjectSessionChangeBuilder
	{
		public string name;

		public ProjectChangeType type;

		public List<EntityData> parts;

		public List<ulong> ids;

		public int[] orders;

		public void AddPart(EntityData part)
		{
		}

		public void AddParts(IEnumerable<EntityData> parts)
		{
		}

		public void AddId(ulong id)
		{
		}

		public void AddIds(IEnumerable<ulong> ids)
		{
		}

		public ProjectSessionChange ToMessage()
		{
			return default(ProjectSessionChange);
		}
	}
}
