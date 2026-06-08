using UnityEngine;

public class SmiteDamageTest : MonoBehaviour
{
	private GameStates.State lastState;

	private int totalSmiteDamage;

	private int totalEffectiveSmite;

	private void Update()
	{
		if (lastState != GameStates.Singleton.CurrentState)
		{
			GameStates.State currentState = GameStates.Singleton.CurrentState;
			if (currentState == GameStates.State.Playing && lastState < GameStates.State.Playing)
			{
				HandleQuestStarted();
			}
			else if ((currentState == GameStates.State.QuestScreen || currentState == GameStates.State.CustomQuests) && (lastState >= GameStates.State.Playing || lastState == GameStates.State.Soulstone))
			{
				HandleQuestEnded();
			}
			else if (currentState == GameStates.State.Soulstone)
			{
				HandleOuroborosLoop();
			}
		}
		lastState = GameStates.Singleton.CurrentState;
	}

	private void HandleQuestStarted()
	{
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		Debug.LogError("Quest Started = " + questData.ToString());
		totalEffectiveSmite = 0;
	}

	private void HandleQuestEnded()
	{
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		Debug.LogError("Quest Ended = " + questData.ToString());
	}

	private void HandleOuroborosLoop()
	{
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		Debug.LogError("Quest Looped = " + questData.ToString());
		Debug.LogError("Frames = " + GameStates.Singleton.GetTotalTime());
		Debug.LogError("Total Smite damage = " + totalSmiteDamage + ", total effective = " + totalEffectiveSmite);
		totalSmiteDamage = 0;
		totalEffectiveSmite = 0;
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.Owner == GameStates.Singleton.hero && dmg.bullet == null && dmg.tags != null && dmg.tags.Contains("magic") && dmg.tags.Contains("AEther"))
		{
			int amount = dmg.amount;
			int num = dmg.amount;
			if (dmg.endHitpoints < 0)
			{
				num += dmg.endHitpoints;
			}
			totalSmiteDamage += amount;
			totalEffectiveSmite += num;
		}
	}

	private void Start()
	{
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}
}
