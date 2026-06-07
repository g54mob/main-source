using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class AllNGUController : MonoBehaviour
{
	public Character character;

	public NGUController[] NGU = new NGUController[7];

	public NGUMagicController[] NGUMagic = new NGUMagicController[4];

	public HoverTooltip tooltip;

	public List<float> normalEnergyNGUDividers;

	public List<float> normalMagicNGUDividers;

	public List<float> evilEnergyNGUDividers;

	public List<float> evilMagicNGUDividers;

	public List<float> sadisticEnergyNGUDividers;

	public List<float> sadisticMagicNGUDividers;

	public List<float> normalEnergyBoostFactor;

	public List<float> normalMagicBoostFactor;

	public List<float> evilEnergyBoostFactor;

	public List<float> evilMagicBoostFactor;

	public List<float> sadisticEnergyBoostFactor;

	public List<float> sadisticMagicBoostFactor;

	public GameObject normalEnergyTrack;

	public GameObject evilEnergyTrack;

	public GameObject sadisticEnergyTrack;

	public GameObject normalMagicTrack;

	public GameObject evilMagicTrack;

	public GameObject sadisticMagicTrack;

	public Image energyNormalCheckmark;

	public Image energyEvilCheckmark;

	public Image energySadisticCheckmark;

	public Image magicNormalCheckmark;

	public Image magicEvilCheckmark;

	public Image magicSadisticCheckmark;

	public Image checkmark1;

	public Image checkmark2;

	public InputField nguModInput;

	public GameObject nguMod;

	public InputField nguModInputMagic;

	public GameObject nguModMagic;

	public GameObject capAllEnergyButton;

	public GameObject capAllMagicButton;

	private void Start()
	{
	}

	public long hardCapNormalLevel()
	{
		return 1000000000L;
	}

	public void toNormalLevelTrack()
	{
		character.settings.nguLevelTrack = difficulty.normal;
		refreshMenu();
	}

	public void toEvilLevelTrack()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.tooltip.showOverrideTooltip("You haven't unlocked the Evil Level Track yet! Git gud!");
			return;
		}
		character.settings.nguLevelTrack = difficulty.evil;
		refreshMenu();
	}

	public void toSadisticLevelTrack()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal || character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.tooltip.showOverrideTooltip("You have to be in Sadistic to use the Sadistic Level Track! Git gud!");
			return;
		}
		character.settings.nguLevelTrack = difficulty.sadistic;
		refreshMenu();
	}

	public void changeDifficulty()
	{
	}

	public bool nguChallengeUnlocked()
	{
		long num = 0L;
		for (int i = 0; i < character.NGU.skills.Count; i++)
		{
			num += character.NGU.skills[i].level;
			if (num >= 10000)
			{
				return true;
			}
		}
		for (int j = 0; j < character.NGU.magicSkills.Count; j++)
		{
			num += character.NGU.magicSkills[j].level;
			if (num >= 10000)
			{
				return true;
			}
		}
		return false;
	}

	public float energySpeedDivider(int id)
	{
		if (id < 0 || id > character.NGU.skills.Count)
		{
			return 1f;
		}
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			return normalEnergyNGUDividers[id];
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return evilEnergyNGUDividers[id];
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return sadisticEnergyNGUDividers[id];
		}
		return 1f;
	}

	public float magicSpeedDivider(int id)
	{
		if (id < 0 || id > character.NGU.skills.Count)
		{
			return 1f;
		}
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			return normalMagicNGUDividers[id];
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return evilMagicNGUDividers[id];
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return sadisticMagicNGUDividers[id];
		}
		return 1f;
	}

	public void refreshMenu()
	{
		for (int i = 0; i < NGU.Length; i++)
		{
			if (NGU[i] != null)
			{
				NGU[i].refresh();
			}
		}
		for (int j = 0; j < NGUMagic.Length; j++)
		{
			if (NGUMagic[j] != null)
			{
				NGUMagic[j].refresh();
			}
		}
		updateToggles();
		updateLevelTrackToggles();
		updateCapMods();
	}

	public void updateToggles()
	{
		if (character.NGU.autoAdvance)
		{
			checkmark1.color = Color.white;
			checkmark2.color = Color.white;
		}
		else
		{
			checkmark1.color = Color.clear;
			checkmark2.color = Color.clear;
		}
	}

	public void updateCapMods()
	{
		if (!character.arbitrary.hasNGUCapModifier)
		{
			nguMod.gameObject.SetActive(value: false);
			nguModMagic.gameObject.SetActive(value: false);
		}
		else
		{
			nguMod.gameObject.SetActive(value: true);
			nguModMagic.gameObject.SetActive(value: true);
			nguModInput.text = (character.settings.nguCapModifier * 100f).ToString("###.#") + "%";
			nguModInputMagic.text = (character.settings.nguCapModifier * 100f).ToString("###.#") + "%";
		}
		if (character.settings.beastOn)
		{
			capAllEnergyButton.SetActive(value: true);
			capAllMagicButton.SetActive(value: true);
		}
		else
		{
			capAllEnergyButton.SetActive(value: false);
			capAllMagicButton.SetActive(value: false);
		}
	}

	public void updateLevelTrackToggles()
	{
		if (character.menuID == 8)
		{
			switch (character.settings.rebirthDifficulty)
			{
			case difficulty.normal:
				normalEnergyTrack.SetActive(value: false);
				evilEnergyTrack.SetActive(value: false);
				sadisticEnergyTrack.SetActive(value: false);
				break;
			case difficulty.evil:
				normalEnergyTrack.SetActive(value: true);
				evilEnergyTrack.SetActive(value: true);
				sadisticEnergyTrack.SetActive(value: false);
				break;
			case difficulty.sadistic:
				normalEnergyTrack.SetActive(value: true);
				evilEnergyTrack.SetActive(value: true);
				sadisticEnergyTrack.SetActive(value: true);
				break;
			}
			if (character.settings.nguLevelTrack == difficulty.normal)
			{
				energyNormalCheckmark.color = Color.white;
				energyEvilCheckmark.color = Color.clear;
				energySadisticCheckmark.color = Color.clear;
			}
			else if (character.settings.nguLevelTrack == difficulty.evil)
			{
				energyNormalCheckmark.color = Color.clear;
				energyEvilCheckmark.color = Color.white;
				energySadisticCheckmark.color = Color.clear;
			}
			else if (character.settings.nguLevelTrack == difficulty.sadistic)
			{
				energyNormalCheckmark.color = Color.clear;
				energyEvilCheckmark.color = Color.clear;
				energySadisticCheckmark.color = Color.white;
			}
		}
		else if (character.menuID == 37)
		{
			switch (character.settings.rebirthDifficulty)
			{
			case difficulty.normal:
				normalMagicTrack.SetActive(value: false);
				evilMagicTrack.SetActive(value: false);
				sadisticMagicTrack.SetActive(value: false);
				break;
			case difficulty.evil:
				normalMagicTrack.SetActive(value: true);
				evilMagicTrack.SetActive(value: true);
				sadisticMagicTrack.SetActive(value: false);
				break;
			case difficulty.sadistic:
				normalMagicTrack.SetActive(value: true);
				evilMagicTrack.SetActive(value: true);
				sadisticMagicTrack.SetActive(value: true);
				break;
			}
			if (character.settings.nguLevelTrack == difficulty.normal)
			{
				magicNormalCheckmark.color = Color.white;
				magicEvilCheckmark.color = Color.clear;
				magicSadisticCheckmark.color = Color.clear;
			}
			else if (character.settings.nguLevelTrack == difficulty.evil)
			{
				magicNormalCheckmark.color = Color.clear;
				magicEvilCheckmark.color = Color.white;
				magicSadisticCheckmark.color = Color.clear;
			}
			else if (character.settings.nguLevelTrack == difficulty.sadistic)
			{
				magicNormalCheckmark.color = Color.clear;
				magicEvilCheckmark.color = Color.clear;
				magicSadisticCheckmark.color = Color.white;
			}
		}
	}

	public void updateEnergyToggles()
	{
		if (character.NGU.autoAdvance)
		{
			checkmark1.color = Color.white;
			checkmark2.color = Color.white;
		}
		else
		{
			checkmark1.color = Color.clear;
			checkmark2.color = Color.clear;
		}
	}

	public void updateMagicToggles()
	{
		if (character.NGU.autoAdvance)
		{
			checkmark1.color = Color.white;
			checkmark2.color = Color.white;
		}
		else
		{
			checkmark1.color = Color.clear;
			checkmark2.color = Color.clear;
		}
	}

	public void toggleAdvance()
	{
		character.NGU.autoAdvance = !character.NGU.autoAdvance;
		updateToggles();
	}

	public double augmentBonus()
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		return augmentBonusNormal() * augmentBonusEvil() * augmentBonusSadistic();
	}

	public double augmentBonusNormal()
	{
		return 1.0 + (double)((float)character.NGU.skills[0].level * normalEnergyBoostFactor[0]);
	}

	public double augmentBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1.0;
		}
		return 1.0 + (double)((float)character.NGU.skills[0].evilLevel * evilEnergyBoostFactor[0]);
	}

	public double augmentBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1.0;
		}
		return 1.0 + (double)((float)character.NGU.skills[0].sadisticLevel * sadisticEnergyBoostFactor[0]);
	}

	public float wandoosBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return wandoosBonusNormal() * wandoosBonusEvil() * wandoosBonusSadistic();
	}

	public float wandoosBonusNormal()
	{
		return 1f + (float)character.NGU.skills[1].level * normalEnergyBoostFactor[1];
	}

	public float wandoosBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[1].evilLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[1].evilLevel * evilEnergyBoostFactor[1];
		}
		return 1f + Mathf.Pow(character.NGU.skills[1].evilLevel, 0.25f) * 177.9f * evilEnergyBoostFactor[1];
	}

	public float wandoosBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[1].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[1].sadisticLevel * sadisticEnergyBoostFactor[1];
		}
		return 1f + Mathf.Pow(character.NGU.skills[1].sadisticLevel, 0.15f) * 354.81f * sadisticEnergyBoostFactor[1];
	}

	public float respawnBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return 1f * respawnBonusNormal() * respawnBonusEvil() * respawnBonusSadistic();
	}

	public float respawnBonusNormal()
	{
		float num = 1f;
		if (character.NGU.skills[2].level <= 400)
		{
			num = 1f - (float)character.NGU.skills[2].level * normalEnergyBoostFactor[2];
			if (num <= 0.8f)
			{
				num = 0.8f;
			}
			return num;
		}
		num = 1f - ((float)character.NGU.skills[2].level / (float)(character.NGU.skills[2].level * 5 + 200000) + 0.2f);
		if (num < 0.6f)
		{
			num = 0.6f;
		}
		return num;
	}

	public float respawnBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[2].evilLevel <= 10000)
		{
			num = 1f - (float)character.NGU.skills[2].evilLevel * evilEnergyBoostFactor[2];
			if (num <= 0.925f)
			{
				num = 0.925f;
			}
			return num;
		}
		num = 1f - ((float)character.NGU.skills[2].evilLevel / (float)(character.NGU.skills[2].evilLevel * 20 + 200000) + 0.05f);
		if (num < 0.9f)
		{
			num = 0.9f;
		}
		return num;
	}

	public float respawnBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[2].sadisticLevel <= 10000)
		{
			num = 1f - (float)character.NGU.skills[2].sadisticLevel * sadisticEnergyBoostFactor[2];
			if (num <= 0.925f)
			{
				num = 0.925f;
			}
			return num;
		}
		num = 1f - ((float)character.NGU.skills[2].sadisticLevel / (float)(character.NGU.skills[2].sadisticLevel * 20 + 200000) + 0.05f);
		if (num < 0.9f)
		{
			num = 0.9f;
		}
		return num;
	}

	public float goldBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = goldBonusNormal() * goldBonusEvil() * goldBonusSadistic();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float goldBonusNormal()
	{
		return 1f + (float)character.NGU.skills[3].level * normalEnergyBoostFactor[3];
	}

	public float goldBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.NGU.skills[3].evilLevel * evilEnergyBoostFactor[3];
	}

	public float goldBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[3].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[3].sadisticLevel * sadisticEnergyBoostFactor[3];
		}
		return 1f + Mathf.Pow(character.NGU.skills[3].sadisticLevel, 0.5f) * 31.63f * sadisticEnergyBoostFactor[3];
	}

	public float adventureBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return adventureBonusNormal() * adventureBonusEvil() * adventureBonusSadistic();
	}

	public float adventureBonusNormal()
	{
		float num = 1f;
		if (character.NGU.skills[4].level <= 1000)
		{
			return 1f + (float)character.NGU.skills[4].level * normalEnergyBoostFactor[4];
		}
		return 1f + Mathf.Sqrt(character.NGU.skills[4].level) * 31.7f * normalEnergyBoostFactor[4];
	}

	public float adventureBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[4].evilLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[4].evilLevel * evilEnergyBoostFactor[4];
		}
		return 1f + Mathf.Pow(character.NGU.skills[4].evilLevel, 0.25f) * 177.9f * evilEnergyBoostFactor[4];
	}

	public float adventureBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[4].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[4].sadisticLevel * sadisticEnergyBoostFactor[4];
		}
		return 1f + Mathf.Pow(character.NGU.skills[4].sadisticLevel, 0.2f) * 251.19f * sadisticEnergyBoostFactor[4];
	}

	public double statBonus()
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		return alphaStatBonus() * betaStatBonus();
	}

	public double alphaStatBonus()
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		return alphaStatBonusNormal() * alphaStatBonusEvil() * alphaStatBonusSadistic();
	}

	public double alphaStatBonusNormal()
	{
		return 1f + (float)character.NGU.skills[5].level * normalEnergyBoostFactor[5];
	}

	public double alphaStatBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1.0;
		}
		return 1f + (float)character.NGU.skills[5].evilLevel * evilEnergyBoostFactor[5];
	}

	public double alphaStatBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1.0;
		}
		return 1f + (float)character.NGU.skills[5].sadisticLevel * sadisticEnergyBoostFactor[5];
	}

	public double betaStatBonus()
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		return betaStatBonusNormal() * betaStatBonusEvil() * betaStatBonusSadistic();
	}

	public double betaStatBonusNormal()
	{
		return 1f + (float)character.NGU.magicSkills[2].level * normalMagicBoostFactor[2];
	}

	public double betaStatBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1.0;
		}
		return 1f + (float)character.NGU.magicSkills[2].evilLevel * evilMagicBoostFactor[2];
	}

	public double betaStatBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1.0;
		}
		return 1f + (float)character.NGU.magicSkills[2].sadisticLevel * sadisticMagicBoostFactor[2];
	}

	public float yggdrasilBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return yggdrasilBonusNormal() * yggdrasilBonusEvil() * yggdrasilBonusSadistic();
	}

	public float yggdrasilBonusNormal()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[0].level <= 400)
		{
			return 1f + (float)character.NGU.magicSkills[0].level * normalMagicBoostFactor[0];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[0].level, 0.33f) * 55.4f * normalMagicBoostFactor[0];
	}

	public float yggdrasilBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[0].evilLevel <= 400)
		{
			return 1f + (float)character.NGU.magicSkills[0].evilLevel * evilMagicBoostFactor[0];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[0].evilLevel, 0.1f) * 219.72f * evilMagicBoostFactor[0];
	}

	public float yggdrasilBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[0].sadisticLevel <= 400)
		{
			return 1f + (float)character.NGU.magicSkills[0].sadisticLevel * sadisticMagicBoostFactor[0];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[0].sadisticLevel, 0.08f) * 247.69f * sadisticMagicBoostFactor[0];
	}

	public float expBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return expBonusNormal() * expBonusEvil() * expBonusSadistic();
	}

	public float expBonusNormal()
	{
		float num = 1f;
		if (character.NGU.magicSkills[1].level <= 2000)
		{
			return 1f + (float)character.NGU.magicSkills[1].level * character.NGUController.normalMagicBoostFactor[1];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[1].level, 0.4f) * 95.66f * character.NGUController.normalMagicBoostFactor[1];
	}

	public float expBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[1].evilLevel <= 2000)
		{
			return 1f + (float)character.NGU.magicSkills[1].evilLevel * character.NGUController.evilMagicBoostFactor[1];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[1].evilLevel, 0.2f) * 437.35f * character.NGUController.evilMagicBoostFactor[1];
	}

	public float expBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[1].sadisticLevel <= 2000)
		{
			return 1f + (float)character.NGU.magicSkills[1].sadisticLevel * character.NGUController.sadisticMagicBoostFactor[1];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[1].sadisticLevel, 0.15f) * 639.56f * character.NGUController.sadisticMagicBoostFactor[1];
	}

	public float lootBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return lootBonusNormal() * lootBonusEvil() * lootBonusSadistic();
	}

	public float lootBonusNormal()
	{
		float num = 1f;
		if (character.NGU.skills[6].level <= 1000)
		{
			return 1f + (float)character.NGU.skills[6].level * normalEnergyBoostFactor[6];
		}
		return 1f + Mathf.Sqrt(character.NGU.skills[6].level) * 31.7f * normalEnergyBoostFactor[6];
	}

	public float lootBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[6].evilLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[6].evilLevel * evilEnergyBoostFactor[6];
		}
		return 1f + Mathf.Pow(character.NGU.skills[6].evilLevel, 0.3f) * 125.9f * evilEnergyBoostFactor[6];
	}

	public float lootBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[6].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[6].sadisticLevel * sadisticEnergyBoostFactor[6];
		}
		return 1f + Mathf.Pow(character.NGU.skills[6].sadisticLevel, 0.2f) * 251.2f * sadisticEnergyBoostFactor[6];
	}

	public double numberBonus()
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		return numberBonusNormal() * numberBonusEvil() * numberBonusSadistic();
	}

	public double numberBonusNormal()
	{
		double num = 1.0;
		if (character.NGU.magicSkills[3].level <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[3].level * normalMagicBoostFactor[3]) * character.timeMulti;
		}
		return 1.0 + (double)(Mathf.Pow(character.NGU.magicSkills[3].level, 0.5f) * 31.7f * normalMagicBoostFactor[3]) * character.timeMulti;
	}

	public double numberBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.NGU.magicSkills[3].evilLevel <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[3].evilLevel * evilMagicBoostFactor[3]) * character.timeMulti;
		}
		return 1.0 + (double)(Mathf.Pow(character.NGU.magicSkills[3].evilLevel, 0.3f) * 125.9f * evilMagicBoostFactor[3]) * character.timeMulti;
	}

	public double numberBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.NGU.magicSkills[3].sadisticLevel <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[3].sadisticLevel * sadisticMagicBoostFactor[3]) * character.timeMulti;
		}
		return 1.0 + (double)(Mathf.Pow(character.NGU.magicSkills[3].sadisticLevel, 0.2f) * 251.2f * sadisticMagicBoostFactor[3]) * character.timeMulti;
	}

	public double numberBonus(bool noTimeMulti)
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		return numberBonusNormal(noTimeMulti: true) * numberBonusEvil(noTimeMulti: true) * numberBonusSadistic(noTimeMulti: true);
	}

	public double numberBonusNormal(bool noTimeMulti)
	{
		double num = 1.0;
		if (character.NGU.magicSkills[3].level <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[3].level * normalMagicBoostFactor[3]);
		}
		return 1.0 + (double)(Mathf.Pow(character.NGU.magicSkills[3].level, 0.5f) * 31.7f * normalMagicBoostFactor[3]);
	}

	public double numberBonusEvil(bool noTimeMulti)
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.NGU.magicSkills[3].evilLevel <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[3].evilLevel * evilMagicBoostFactor[3]);
		}
		return 1.0 + (double)(Mathf.Pow(character.NGU.magicSkills[3].evilLevel, 0.3f) * 125.9f * evilMagicBoostFactor[3]);
	}

	public double numberBonusSadistic(bool noTimeMulti)
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.NGU.magicSkills[3].sadisticLevel <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[3].sadisticLevel * sadisticMagicBoostFactor[3]);
		}
		return 1.0 + (double)(Mathf.Pow(character.NGU.magicSkills[3].sadisticLevel, 0.2f) * 251.2f * sadisticMagicBoostFactor[3]);
	}

	public float energyNGUBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return energyNGUBonusNormal() * energyNGUBonusEvil() * energyNGUBonusSadistic();
	}

	public float energyNGUBonusNormal()
	{
		float num = 1f;
		if (character.NGU.magicSkills[5].level <= 1000)
		{
			return 1f + (float)character.NGU.magicSkills[5].level * normalMagicBoostFactor[5];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[5].level, 0.3f) * 125.9f * normalMagicBoostFactor[5];
	}

	public float energyNGUBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[5].evilLevel <= 1000)
		{
			return 1f + (float)character.NGU.magicSkills[5].evilLevel * evilMagicBoostFactor[5];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[5].evilLevel, 0.2f) * 251.2f * evilMagicBoostFactor[5];
	}

	public float energyNGUBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[5].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.magicSkills[5].sadisticLevel * sadisticMagicBoostFactor[5];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[5].sadisticLevel, 0.15f) * 354.82f * sadisticMagicBoostFactor[5];
	}

	public float magicNGUBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return magicNGUBonusNormal() * magicNGUBonusEvil() * magicNGUBonusSadistic();
	}

	public float magicNGUBonusNormal()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[7].level <= 1000)
		{
			return 1f + (float)character.NGU.skills[7].level * normalEnergyBoostFactor[7];
		}
		return 1f + Mathf.Pow(character.NGU.skills[7].level, 0.3f) * 125.9f * normalEnergyBoostFactor[7];
	}

	public float magicNGUBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[7].evilLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[7].evilLevel * evilEnergyBoostFactor[7];
		}
		return 1f + Mathf.Pow(character.NGU.skills[7].evilLevel, 0.3f) * 125.9f * evilEnergyBoostFactor[7];
	}

	public float magicNGUBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[7].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[7].sadisticLevel * sadisticEnergyBoostFactor[7];
		}
		return 1f + Mathf.Pow(character.NGU.skills[7].sadisticLevel, 0.1f) * 501.19f * sadisticEnergyBoostFactor[7];
	}

	public float PPBonus()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return PPBonusNormal() * PPBonusEvil() * PPBonusSadistic();
	}

	public float PPBonusNormal()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[8].level <= 1000)
		{
			return 1f + (float)character.NGU.skills[8].level * normalEnergyBoostFactor[8];
		}
		return 1f + Mathf.Pow(character.NGU.skills[8].level, 0.3f) * 125.9f * normalEnergyBoostFactor[8];
	}

	public float PPBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[8].evilLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[8].evilLevel * evilEnergyBoostFactor[8];
		}
		return 1f + Mathf.Pow(character.NGU.skills[8].evilLevel, 0.2f) * 251.2f * evilEnergyBoostFactor[8];
	}

	public float PPBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.skills[8].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.skills[8].sadisticLevel * sadisticEnergyBoostFactor[8];
		}
		return 1f + Mathf.Pow(character.NGU.skills[8].sadisticLevel, 0.1f) * 501.21f * sadisticEnergyBoostFactor[8];
	}

	public float adventureBonus2()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		return adventureBonus2Normal() * adventureBonus2Evil() * adventureBonus2Sadistic();
	}

	public float adventureBonus2Normal()
	{
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[6].level <= 1000)
		{
			return 1f + (float)character.NGU.magicSkills[6].level * normalMagicBoostFactor[6];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[6].level, 0.4f) * 63.13f * normalMagicBoostFactor[6];
	}

	public float adventureBonus2Evil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[6].evilLevel <= 1000)
		{
			return 1f + (float)character.NGU.magicSkills[6].evilLevel * evilMagicBoostFactor[6];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[6].evilLevel, 0.25f) * 177.83f * evilMagicBoostFactor[6];
	}

	public float adventureBonus2Sadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.NGU.disabled)
		{
			return 1f;
		}
		float num = 1f;
		if (character.NGU.magicSkills[6].sadisticLevel <= 1000)
		{
			return 1f + (float)character.NGU.magicSkills[6].sadisticLevel * sadisticMagicBoostFactor[6];
		}
		return 1f + Mathf.Pow(character.NGU.magicSkills[6].sadisticLevel, 0.12f) * 436.53f * sadisticMagicBoostFactor[6];
	}

	public double timeMachineBonus()
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		return timeMachineBonusNormal() * timeMachineBonusEvil() * timeMachineBonusSadistic();
	}

	public double timeMachineBonusNormal()
	{
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.NGU.magicSkills[4].level <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[4].level * normalMagicBoostFactor[4]);
		}
		return 1.0 + Math.Pow(character.NGU.magicSkills[4].level, 0.8) * 3.981 * (double)normalMagicBoostFactor[4];
	}

	public double timeMachineBonusEvil()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1.0;
		}
		if (character.NGU.disabled)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.NGU.magicSkills[4].evilLevel <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[4].evilLevel * evilMagicBoostFactor[4]);
		}
		return 1.0 + Math.Pow(character.NGU.magicSkills[4].evilLevel, 0.8) * 3.981 * (double)evilMagicBoostFactor[4];
	}

	public double timeMachineBonusSadistic()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1.0;
		}
		double num = 1.0;
		if (character.NGU.magicSkills[4].sadisticLevel <= 1000)
		{
			return 1.0 + (double)((float)character.NGU.magicSkills[4].sadisticLevel * sadisticMagicBoostFactor[4]);
		}
		return 1.0 + Math.Pow(character.NGU.magicSkills[4].sadisticLevel, 0.8) * 3.981 * (double)sadisticMagicBoostFactor[4];
	}

	public void reset()
	{
		for (int i = 0; i < NGU.Length; i++)
		{
			NGU[i].reset();
		}
		for (int j = 0; j < NGUMagic.Length; j++)
		{
			NGUMagic[j].reset();
		}
	}

	public void removeAllEnergy()
	{
		for (int i = 0; i < NGU.Length; i++)
		{
			NGU[i].removeAllEnergy();
		}
	}

	public void removeAllMagic()
	{
		for (int i = 0; i < NGUMagic.Length; i++)
		{
			NGUMagic[i].removeAllMagic();
		}
	}

	public bool unlocked100LevelChallenge()
	{
		long num = 0L;
		for (int i = 0; i < NGU.Length; i++)
		{
			if (NGU[i].getLevel() + num >= 10)
			{
				return true;
			}
			num += NGU[i].getLevel();
		}
		return false;
	}

	public void autoAdvanceEnergy(int id)
	{
		int num = id;
		int i = 0;
		long energy = character.NGU.skills[id].energy;
		character.idleEnergy += energy;
		character.NGU.skills[id].energy = 0L;
		if (!character.NGU.autoAdvance)
		{
			refreshMenu();
			return;
		}
		for (; i < character.NGU.NGUEnergySize(); i++)
		{
			num++;
			if (num >= character.NGU.NGUEnergySize())
			{
				num = 0;
			}
			if (!reachedTarget(num))
			{
				character.idleEnergy -= energy;
				character.NGU.skills[num].energy += energy;
				break;
			}
		}
		refreshMenu();
	}

	public void autoAdvanceMagic(int id)
	{
		int num = id;
		int i = 0;
		long magic = character.NGU.magicSkills[id].magic;
		character.magic.idleMagic += magic;
		character.NGU.magicSkills[id].magic = 0L;
		if (!character.NGU.autoAdvance)
		{
			refreshMenu();
			return;
		}
		for (; i < character.NGU.NGUMagicSize(); i++)
		{
			num++;
			if (num >= character.NGU.NGUMagicSize())
			{
				num = 0;
			}
			if (!reachedMagicTarget(num))
			{
				character.magic.idleMagic -= magic;
				character.NGU.magicSkills[num].magic += magic;
				break;
			}
		}
		refreshMenu();
	}

	public bool reachedTarget(int id)
	{
		switch (character.settings.nguLevelTrack)
		{
		case difficulty.normal:
			if (character.NGU.skills[id].target == -1)
			{
				return true;
			}
			if (character.NGU.skills[id].target == 0L)
			{
				return false;
			}
			return character.NGU.skills[id].level >= character.NGU.skills[id].target;
		case difficulty.evil:
			if (character.NGU.skills[id].evilTarget == -1)
			{
				return true;
			}
			if (character.NGU.skills[id].evilTarget == 0L)
			{
				return false;
			}
			return character.NGU.skills[id].evilLevel >= character.NGU.skills[id].evilTarget;
		case difficulty.sadistic:
			if (character.NGU.skills[id].sadisticTarget == -1)
			{
				return true;
			}
			if (character.NGU.skills[id].sadisticTarget == 0L)
			{
				return false;
			}
			return character.NGU.skills[id].sadisticLevel >= character.NGU.skills[id].sadisticTarget;
		default:
			return false;
		}
	}

	public bool reachedMagicTarget(int id)
	{
		switch (character.settings.nguLevelTrack)
		{
		case difficulty.normal:
			if (character.NGU.magicSkills[id].target == -1)
			{
				return true;
			}
			if (character.NGU.magicSkills[id].target == 0L)
			{
				return false;
			}
			return character.NGU.magicSkills[id].level >= character.NGU.magicSkills[id].target;
		case difficulty.evil:
			if (character.NGU.magicSkills[id].evilTarget == -1)
			{
				return true;
			}
			if (character.NGU.magicSkills[id].evilTarget == 0L)
			{
				return false;
			}
			return character.NGU.magicSkills[id].evilLevel >= character.NGU.magicSkills[id].evilTarget;
		case difficulty.sadistic:
			if (character.NGU.magicSkills[id].sadisticTarget == -1)
			{
				return true;
			}
			if (character.NGU.magicSkills[id].sadisticTarget == 0L)
			{
				return false;
			}
			return character.NGU.magicSkills[id].sadisticLevel >= character.NGU.magicSkills[id].sadisticTarget;
		default:
			return false;
		}
	}

	public long energyNGUCapAmount(int id)
	{
		float num = 0f;
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			num = character.NGU.skills[id].level + 1;
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			num = character.NGU.skills[id].evilLevel + 1;
		}
		else if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			num = character.NGU.skills[id].sadisticLevel + 1;
		}
		double num2 = character.totalEnergyPower();
		num2 *= (double)character.totalNGUSpeedBonus();
		num2 *= (double)character.adventureController.itopod.totalEnergyNGUBonus();
		num2 *= (double)character.inventory.macguffinBonuses[4];
		num2 *= (double)character.NGUController.energyNGUBonus();
		num2 *= (double)character.allDiggers.totalEnergyNGUBonus();
		num2 *= (double)character.hacksController.totalEnergyNGUBonus();
		num2 *= (double)character.beastQuestPerkController.totalEnergyNGUSpeed();
		num2 *= (double)character.wishesController.totalEnergyNGUSpeed();
		num2 *= (double)character.cardsController.getBonus(cardBonus.energyNGUSpeed);
		if (character.allChallenges.trollChallenge.sadisticCompletions() >= 1)
		{
			num2 *= 3.0;
		}
		if (character.settings.nguLevelTrack >= difficulty.sadistic)
		{
			num2 /= (double)NGU[0].sadisticDivider();
		}
		double num3 = (double)character.NGUController.energySpeedDivider(id) * (double)num / num2;
		num3 *= (double)character.settings.nguCapModifier;
		if (num3 >= (double)character.hardCap())
		{
			return character.hardCap();
		}
		if (num3 <= 1.0)
		{
			return 1L;
		}
		return (long)num3;
	}

	public long magicNGUCapAmount(int id)
	{
		float num = 0f;
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			num = character.NGU.magicSkills[id].level + 1;
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			num = character.NGU.magicSkills[id].evilLevel + 1;
		}
		else if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			num = character.NGU.magicSkills[id].sadisticLevel + 1;
		}
		double num2 = character.totalMagicPower();
		num2 *= (double)character.totalNGUSpeedBonus();
		num2 *= (double)character.adventureController.itopod.totalMagicNGUBonus();
		num2 *= (double)character.inventory.macguffinBonuses[5];
		num2 *= (double)character.NGUController.magicNGUBonus();
		num2 *= (double)character.allDiggers.totalMagicNGUBonus();
		num2 *= (double)character.hacksController.totalMagicNGUBonus();
		num2 *= (double)character.beastQuestPerkController.totalMagicNGUSpeed();
		num2 *= (double)character.wishesController.totalMagicNGUSpeed();
		num2 *= (double)character.cardsController.getBonus(cardBonus.magicNGUSpeed);
		if (character.allChallenges.trollChallenge.completions() >= 1)
		{
			num2 *= 3.0;
		}
		if (character.settings.nguLevelTrack >= difficulty.sadistic)
		{
			num2 /= (double)NGUMagic[0].sadisticDivider();
		}
		double num3 = (double)character.NGUController.magicSpeedDivider(id) * (double)num / num2;
		num3 *= (double)character.settings.nguCapModifier;
		if (num3 >= (double)character.hardCap())
		{
			return character.hardCap();
		}
		if (num3 <= 1.0)
		{
			return 1L;
		}
		return (long)num3;
	}

	public void parseNGUModInput()
	{
		if (!character.arbitrary.hasNGUCapModifier)
		{
			tooltip.showOverrideTooltip("You need to purchase the NGU Cap Modifier in the Sellout Shop to modify this setting!", 2f);
			updateCapMods();
			return;
		}
		if (nguModInput.text == "")
		{
			nguModInput.text = "100";
		}
		string input = nguModInput.text.ToLower();
		input = Regex.Replace(input, "[^0-9.]", "");
		input = input.Replace("%", "");
		if (input == "")
		{
			input = "100";
		}
		float num = 100f;
		try
		{
			num = float.Parse(input);
		}
		catch (Exception)
		{
			num = 100f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if (num > 300f)
		{
			num = 300f;
		}
		num = (float)Math.Round(num, 1);
		character.settings.nguCapModifier = num / 100f;
		updateCapMods();
	}

	public void parseNGUModInputMagic()
	{
		if (!character.arbitrary.hasNGUCapModifier)
		{
			tooltip.showOverrideTooltip("You need to purchase the NGU Cap Modifier in the Sellout Shop to modify this setting!", 2f);
			updateCapMods();
			return;
		}
		if (nguModInputMagic.text == "")
		{
			nguModInputMagic.text = "100";
		}
		string input = nguModInputMagic.text.ToLower();
		input = Regex.Replace(input, "[^0-9.]", "");
		input = input.Replace("%", "");
		if (input == "")
		{
			input = "100";
		}
		float num = 100f;
		try
		{
			num = float.Parse(input);
		}
		catch (Exception)
		{
			num = 100f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if (num > 300f)
		{
			num = 300f;
		}
		num = (float)Math.Round(num, 1);
		character.settings.nguCapModifier = num / 100f;
		updateCapMods();
	}

	public void capAllEnergy()
	{
		for (int i = 0; i < NGU.Length; i++)
		{
			NGU[i].removeAll();
		}
		for (int j = 0; j < NGU.Length; j++)
		{
			if (!reachedTarget(j))
			{
				NGU[j].cap();
			}
		}
	}

	public void capAllMagic()
	{
		for (int i = 0; i < NGUMagic.Length; i++)
		{
			NGUMagic[i].removeAll();
		}
		for (int j = 0; j < NGUMagic.Length; j++)
		{
			if (!reachedMagicTarget(j))
			{
				NGUMagic[j].cap();
			}
		}
	}
}
