using UnityEngine;
using UnityEngine.UI;

public class AllAdvancedTraining : MonoBehaviour
{
	public Character character;

	public AdvancedTrainingController defense;

	public AdvancedTrainingController block;

	public AdvancedTrainingController attack;

	public AdvancedTrainingController wandoosEnergy;

	public AdvancedTrainingController wandoosMagic;

	public Image checkmark;

	public readonly int length = 5;

	public void Update()
	{
		if (advancedTrainingUnlocked() && !character.advancedTraining.transferredBankedLevels)
		{
			for (int i = 0; i < size(); i++)
			{
				character.advancedTraining.level[i] += character.advancedTraining.bankedLevel[i];
				character.advancedTraining.bankedLevel[i] = 0L;
			}
			character.advancedTraining.transferredBankedLevels = true;
		}
	}

	public int size()
	{
		return 5;
	}

	public bool advancedTrainingUnlocked()
	{
		if (character.training.attackTraining[4] >= 25000)
		{
			return character.training.defenseTraining[4] >= 25000;
		}
		return false;
	}

	public void reset()
	{
		for (int i = 0; i < size(); i++)
		{
			character.advancedTraining.training[i] = 0;
			character.advancedTraining.energy[i] = 0L;
			character.advancedTraining.barProgress[i] = 0f;
			long num = (long)(character.adventureController.itopod.totalBankedAdvTraining() * (float)character.advancedTraining.level[i]);
			if (num < 0)
			{
				num = 0L;
			}
			if (num > (long)((float)character.advancedTraining.level[i] * character.adventureController.itopod.totalBankedAdvTraining()))
			{
				num = (long)((float)character.advancedTraining.level[i] * character.adventureController.itopod.totalBankedAdvTraining());
			}
			character.advancedTraining.level[i] = 0L;
			character.advancedTraining.bankedLevel[i] = num;
		}
		for (int j = 0; j < size(); j++)
		{
			character.advancedTraining.level[j] = character.adventure.itopod.perkLevel[18];
		}
		if (character.adventureController.itopod.totalBankedAdvTraining() > 0f)
		{
			character.advancedTraining.transferredBankedLevels = false;
		}
	}

	public void challengeReset()
	{
		for (int i = 0; i < size(); i++)
		{
			character.advancedTraining.bankedLevel[i] = 0L;
		}
	}

	public void refresh()
	{
		if (character.menuID == 17)
		{
			defense.refresh();
			block.refresh();
			attack.refresh();
			wandoosEnergy.refresh();
			wandoosMagic.refresh();
			updateToggle();
		}
	}

	public void updateToggle()
	{
		if (character.advancedTraining.autoAdvance)
		{
			checkmark.color = Color.white;
		}
		else
		{
			checkmark.color = Color.clear;
		}
	}

	public void toggleAutoAdvance()
	{
		character.advancedTraining.autoAdvance = !character.advancedTraining.autoAdvance;
		updateToggle();
	}

	public void removeAllEnergy()
	{
		defense.removeAllEnergy();
		block.removeAllEnergy();
		attack.removeAllEnergy();
		wandoosEnergy.removeAllEnergy();
		wandoosMagic.removeAllEnergy();
	}

	public string trainingName(int id)
	{
		switch (id)
		{
		case 0:
			return defense.trainingName;
		case 1:
			return attack.trainingName;
		case 2:
			return block.trainingName;
		case 3:
			return wandoosEnergy.trainingName;
		case 4:
			return wandoosMagic.trainingName;
		default:
			return "A bug. Tell 4g about this please!";
		}
	}

	public float getDivisor(int id)
	{
		switch (id)
		{
		case 0:
			return defense.getDivisor();
		case 1:
			return attack.getDivisor();
		case 2:
			return block.getDivisor();
		case 3:
			return wandoosEnergy.getDivisor();
		case 4:
			return wandoosMagic.getDivisor();
		default:
			return 0f;
		}
	}

	public float getProgressPerTick(int id)
	{
		switch (id)
		{
		case 0:
			return defense.progressPerTick();
		case 1:
			return attack.progressPerTick();
		case 2:
			return block.progressPerTick();
		case 3:
			return wandoosEnergy.progressPerTick();
		case 4:
			return wandoosMagic.progressPerTick();
		default:
			return 0f;
		}
	}

	public void advanceEnergy(int id)
	{
		long num = character.advancedTraining.energy[id];
		character.advancedTraining.energy[id] = 0L;
		character.idleEnergy += num;
		if (!character.advancedTraining.autoAdvance)
		{
			refresh();
			return;
		}
		int num2 = id;
		for (int i = 0; i < size(); i++)
		{
			num2++;
			if (num2 >= size())
			{
				num2 = 0;
			}
			if (!reachedTarget(num2))
			{
				character.idleEnergy -= num;
				character.advancedTraining.energy[num2] += num;
				break;
			}
		}
		refresh();
	}

	public float adventurePowerBonus(int offset)
	{
		long num = character.advancedTraining.level[1];
		if (num + offset <= 0)
		{
			return 0f;
		}
		return Mathf.Pow(num + offset, 0.4f) * 0.1f;
	}

	public float adventureToughnessBonus(int offset)
	{
		long num = character.advancedTraining.level[0];
		if (num + offset <= 0)
		{
			return 0f;
		}
		return Mathf.Pow(num + offset, 0.4f) * 0.1f;
	}

	public bool reachedTarget(int id)
	{
		if (id == 3 && !character.settings.wandoos98On)
		{
			return true;
		}
		if (id == 4 && !character.settings.wandoos98On)
		{
			return true;
		}
		if (character.advancedTraining.levelTarget[id] == -1)
		{
			return true;
		}
		if (character.advancedTraining.levelTarget[id] == 0L)
		{
			return false;
		}
		return character.advancedTraining.level[id] >= character.advancedTraining.levelTarget[id];
	}
}
