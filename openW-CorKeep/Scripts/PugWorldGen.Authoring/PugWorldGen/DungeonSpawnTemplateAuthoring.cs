using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugWorldGen
{
	public class DungeonSpawnTemplateAuthoring : MonoBehaviour
	{
		[Serializable]
		public class SpawnTemplateConfiguration
		{
			public RoomFlags flags;

			public int minimumSizeRequirement;

			public List<SpawnTemplate> templates;
		}

		public List<SpawnTemplateConfiguration> nodeTemplates = new List<SpawnTemplateConfiguration>();

		public List<SpawnTemplateConfiguration> pathTemplates = new List<SpawnTemplateConfiguration>();
	}
}
