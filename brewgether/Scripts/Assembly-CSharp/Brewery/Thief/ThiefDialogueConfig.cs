using UnityEngine;

namespace Brewery.Thief
{
	[CreateAssetMenu(fileName = "ThiefDialogueConfig", menuName = "Brewery/Thief Dialogue Config")]
	public class ThiefDialogueConfig : ScriptableObject
	{
		[Header("Stealer - Lurking (player near target, waiting)")]
		[TextArea(1, 2)]
		public string[] stealerLurking;

		[Header("Stealer - Steal Success (depositing loot)")]
		[TextArea(1, 2)]
		public string[] stealerStealSuccess;

		[Header("Stealer - Fleeing (running to camp for backup)")]
		[TextArea(1, 2)]
		public string[] stealerFleeing;

		[Header("Stealer - Combat (fighting briefly)")]
		[TextArea(1, 2)]
		public string[] stealerCombat;

		[Header("Defender - Idle (patrolling camp)")]
		[TextArea(1, 2)]
		public string[] defenderIdle;

		[Header("Defender - Warning (player approaching camp)")]
		[TextArea(1, 2)]
		public string[] defenderWarning;

		[Header("Defender - Revenge (hunting player)")]
		[TextArea(1, 2)]
		public string[] defenderRevenge;

		[Header("Defender - Combat (fighting)")]
		[TextArea(1, 2)]
		public string[] defenderCombat;

		public string GetRandom(string[] lines)
		{
			return null;
		}
	}
}
