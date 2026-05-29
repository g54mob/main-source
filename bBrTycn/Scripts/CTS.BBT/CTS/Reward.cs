using UnityEngine;

namespace CTS
{
	public abstract class Reward : ScriptableObject
	{
		public abstract void ApplyReward(LastDialogueHelper.EDialogueScore dialogueScore);
	}
}
