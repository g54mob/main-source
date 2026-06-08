using System.Collections.Generic;
using Rhizomatic;
using UnityEngine.Serialization;

namespace GRP
{
	public class EntityManagerConfig : Config
	{
		[FormerlySerializedAs("entities")]
		public List<EntityConfig> _entities;

		public virtual List<EntityConfig> entities => null;

		public EntityConfig GetConfig(string key)
		{
			return null;
		}

		public T GetConfig<T>() where T : EntityConfig
		{
			return null;
		}
	}
}
