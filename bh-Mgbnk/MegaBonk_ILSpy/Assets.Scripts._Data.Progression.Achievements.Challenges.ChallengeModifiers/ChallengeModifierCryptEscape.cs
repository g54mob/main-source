using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;

public class ChallengeModifierCryptEscape : ChallengeModifier
{
	private ChallengeData challengeData;

	private float timeLimit;

	public override void Init(ChallengeData challengeData)
	{
		//IL_001e: Expected F4, but got I4
		this.challengeData = challengeData;
		timeLimit = challengeData.targetValue;
	}

	public override void Cleanup()
	{
	}

	public override void Tick()
	{
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			if (instance._003CcryptIndex_003Ek__BackingField == 0 && !(MyTime.cryptTimer < timeLimit))
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory = instance2.inventory;
				inventory.playerHealth.KillPlayer();
			}
		}
	}
}
