using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class NPCPresetRepository : DynamicJsonRepository<NPCPresetRepository, HumanPreset>
	{
		protected override string JsonFile()
		{
			return "NPC/NPCPresets.json";
		}
	}
}
