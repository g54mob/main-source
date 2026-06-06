using System.Collections.Generic;
using UnityEngine;

namespace Brewery.NPC.Data
{
	[CreateAssetMenu(fileName = "NPC_Roster", menuName = "Brewery/NPC/Roster", order = 110)]
	public class NPCRoster : ScriptableObject
	{
		[SerializeField]
		private List<NPCProfile> profiles;

		public IReadOnlyList<NPCProfile> Profiles => null;

		public NPCProfile GetById(string npcId)
		{
			return null;
		}

		public NPCProfile GetRandomWeighted()
		{
			return null;
		}
	}
}
