using System.Collections.Generic;

namespace GRP
{
	public class PartManagerConfig : EntityManagerConfig
	{
		public PartsContainerConfig config;

		private List<EntityConfig> parts;

		public override List<EntityConfig> entities => null;
	}
}
