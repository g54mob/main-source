using Models;
using NSEipix.Repository;

namespace Repository
{
	public class NPCCustomWarningMessageRepository : DynamicJsonRepository<NPCCustomWarningMessageRepository, NPCCustomWarningMessage>
	{
		protected override string JsonFile()
		{
			return "NPC/NPCCustomWarningMessageRepository.json";
		}
	}
}
