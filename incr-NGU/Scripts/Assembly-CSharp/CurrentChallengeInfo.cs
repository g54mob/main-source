using UnityEngine;
using UnityEngine.UI;

public class CurrentChallengeInfo : MonoBehaviour
{
	public Character character;

	public Text infoText;

	private string message;

	private void Start()
	{
		InvokeRepeating("updateChallengeText", 0f, 0.1f);
	}

	private void updateChallengeText()
	{
		if (character.menuID == 12)
		{
			message = challengeInfoMessage();
			infoText.text = message;
		}
	}

	public string challengeInfoMessage()
	{
		string result = "";
		if (!character.challenges.inChallenge)
		{
			result = "Current Challenge: None";
		}
		else if (character.challenges.basicChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> Basic Challenge\n<b>Challenge Time:</b> " + character.challenges.basicChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.basicChallenge.targetBoss() + 1);
		}
		else if (character.challenges.noAugsChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> No Augs Challenge\n<b>Challenge Time:</b> " + character.challenges.noAugsChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.noAugsChallenge.targetBoss() + 1);
		}
		else if (character.challenges.hour24Challenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> 24 Hour Challenge\n<b>Challenge Time Remaining:</b> " + character.challenges.hour24Challenge.challengeTime.inverseDisplayColon(86400.0);
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.hour24Challenge.targetBoss() + 1) + " in under 24 hours of play!";
		}
		else if (character.challenges.levelChallenge10k.inChallenge)
		{
			result = "<b>Current Challenge:</b> 100 Level Challenge\n<b>Challenge Time:</b> " + character.challenges.levelChallenge10k.challengeTime.timeDisplayColon() + "\nLevels Used: " + character.settings.rebirthLevels + "/100";
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.level100Challenge.targetBoss() + 1);
		}
		else if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> No Equipment Challenge\n<b>Challenge Time:</b> " + character.challenges.noEquipmentChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.noEquipmentChallenge.targetBoss() + 1);
		}
		else if (character.challenges.noRebirthChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> No Rebirth Challenge\n<b>Challenge Time:</b> " + character.challenges.noRebirthChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.noRebirthChallenge.targetBoss() + 1);
		}
		else if (character.challenges.trollChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> Troll Challenge\n<b>Challenge Time:</b> " + character.challenges.trollChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nTime Until Next Troll: </b>" + character.allChallenges.trollChallenge.timeToNextTroll();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.trollChallenge.targetBoss() + 1);
		}
		else if (character.challenges.laserSwordChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> Laser Sword Challenge\n<b>Challenge Time:</b> " + character.challenges.laserSwordChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Create a " + character.allChallenges.laserSwordChallenge.laserSwordTarget() + "/" + character.allChallenges.laserSwordChallenge.laserSwordTarget() + " Laser Sword Augment.";
		}
		else if (character.challenges.nguChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> No NGU Challenge\n<b>Challenge Time:</b> " + character.challenges.nguChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.NGUChallenge.targetBoss() + 1);
		}
		else if (character.challenges.timeMachineChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> No Time Machine Challenge\n<b>Challenge Time:</b> " + character.challenges.timeMachineChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.timeMachineChallenge.targetBoss() + 1);
		}
		else if (character.challenges.blindChallenge.inChallenge)
		{
			result = "<b>Current Challenge:</b> Blind Challenge\n<b>Challenge Time:</b> " + character.challenges.blindChallenge.challengeTime.timeDisplayColon();
			result = result + "<b>\nObjective:</b> Defeat boss " + (character.allChallenges.blindChallenge.targetBoss() + 1);
		}
		return result;
	}
}
