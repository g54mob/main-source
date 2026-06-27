using Restory.Data.Microstories;
using UnityEngine;

namespace Restory.Data.NPCs
{
	public class GeneratedNpcInfo : INpcInfo, ICustomizableNpc
	{
		private readonly string id;

		private readonly string nameLocalizationKey;

		private readonly GameObject prefab;

		private readonly NpcCustomizationOptions customization;

		public string ID => id;

		public string NameLocalizationKey => nameLocalizationKey;

		public Sprite Icon => null;

		public GameObject Prefab => prefab;

		public NpcCustomizationOptions Customization => customization;

		public GeneratedNpcInfo(string id, string nameLocalizationKey, GameObject prefab, NpcCustomizationOptions customization)
		{
			this.id = id;
			this.nameLocalizationKey = nameLocalizationKey;
			this.prefab = prefab;
			this.customization = customization;
		}
	}
}
