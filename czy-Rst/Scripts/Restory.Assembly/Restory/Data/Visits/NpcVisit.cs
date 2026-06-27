using System;
using Restory.Data.NPCs;

namespace Restory.Data.Visits
{
	[Serializable]
	public class NpcVisit
	{
		public INpcInfo Npc { get; set; }

		public string NpcTextureID { get; set; }
	}
}
