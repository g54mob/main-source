using FishNet.Object;
using ScheduleOne.NPCs;

namespace ScheduleOne.Management
{
	public interface IUsable
	{
		bool IsInUse => false;

		bool IsUsedByLocalPlayer => false;

		NetworkObject NPCUserObject { get; set; }

		NetworkObject PlayerUserObject { get; set; }

		string UserName => null;

		bool IsInUseByNPC(NPC npc)
		{
			return false;
		}

		void SetPlayerUser(NetworkObject playerObject);

		void SetNPCUser(NetworkObject playerObject);
	}
}
