using System;
using System.Collections.Generic;

[Serializable]
public class SaveableDoggyBrain
{
	public float anger;

	public float hunger;

	public float energy;

	public float stress;

	public float boredom;

	public bool isDead;

	public bool requiresDeath;

	public DeathReason deathReason;

	public bool hasShownNearDeathPopup;

	public bool hasShownHungerPainsPopup;

	public float barfMeter;

	public float currentMaxHungerTime;

	public DogAge dogAge;

	public float dogAgeProgress;

	public float lifeExtension;

	public float endOfLifeModifier;

	public bool hatchedFromEgg;

	public SaveableDogPersonality personality;

	public SerializableDictionary<ulong, int> dogOpinionCount;

	public SerializableDictionary<ulong, Opinion> dogOpinions;

	public SerializableDictionary<string, float> reinforcement;

	public SaveableDoggyBrain(DoggyBrain brain)
	{
		SaveBrain(brain);
	}

	private SaveableDoggyBrain()
	{
	}

	public SaveableDoggyBrain GetCopy()
	{
		SaveableDoggyBrain saveableDoggyBrain = new SaveableDoggyBrain();
		saveableDoggyBrain.anger = anger;
		saveableDoggyBrain.hunger = hunger;
		saveableDoggyBrain.energy = energy;
		saveableDoggyBrain.stress = stress;
		saveableDoggyBrain.boredom = boredom;
		saveableDoggyBrain.isDead = isDead;
		saveableDoggyBrain.requiresDeath = requiresDeath;
		saveableDoggyBrain.deathReason = deathReason;
		saveableDoggyBrain.hasShownNearDeathPopup = hasShownNearDeathPopup;
		saveableDoggyBrain.hasShownHungerPainsPopup = hasShownHungerPainsPopup;
		saveableDoggyBrain.barfMeter = barfMeter;
		saveableDoggyBrain.currentMaxHungerTime = currentMaxHungerTime;
		saveableDoggyBrain.dogAge = dogAge;
		saveableDoggyBrain.lifeExtension = lifeExtension;
		saveableDoggyBrain.dogAgeProgress = dogAgeProgress;
		saveableDoggyBrain.endOfLifeModifier = endOfLifeModifier;
		saveableDoggyBrain.hatchedFromEgg = hatchedFromEgg;
		saveableDoggyBrain.personality = personality.GetCopy();
		Dictionary<ulong, Opinion> dict = new Dictionary<ulong, Opinion>();
		dogOpinions.Load(dict);
		saveableDoggyBrain.dogOpinions = new SerializableDictionary<ulong, Opinion>(dict);
		Dictionary<ulong, int> dict2 = new Dictionary<ulong, int>();
		if (dogOpinionCount != null)
		{
			dogOpinionCount.Load(dict2);
			saveableDoggyBrain.dogOpinionCount = new SerializableDictionary<ulong, int>(dict2);
		}
		Dictionary<string, float> dict3 = new Dictionary<string, float>();
		if (reinforcement != null)
		{
			reinforcement.Load(dict3);
		}
		saveableDoggyBrain.reinforcement = new SerializableDictionary<string, float>(dict3);
		return saveableDoggyBrain;
	}

	private void SaveBrain(DoggyBrain brain)
	{
		anger = brain.GetCurrentAnger();
		hunger = brain.GetCurrentHunger();
		energy = brain.GetCurrentEnergy();
		stress = brain.GetCurrentStress();
		boredom = brain.GetCurrentBoredom();
		isDead = brain.IsDead();
		requiresDeath = brain.DoesDogRequireDeath();
		deathReason = brain.GetDeathReason();
		hasShownNearDeathPopup = brain.HasDogShownNearDeathPopup();
		hasShownHungerPainsPopup = brain.HasDogShownHungerPainsPopup();
		barfMeter = brain.GetBarfMeter();
		dogAge = brain.GetCurrentDogAge();
		hatchedFromEgg = brain.DidDogHatchFromEgg();
		lifeExtension = brain.GetLifeExtension();
		endOfLifeModifier = brain.GetEndOfLifeModifier();
		dogAgeProgress = brain.GetCurrentDogAgeProgress();
		currentMaxHungerTime = brain.GetCurrentMaxHungerTime();
		personality = new SaveableDogPersonality(brain.GetPersonality());
		dogOpinions = new SerializableDictionary<ulong, Opinion>(brain.GetDogOpinions());
		dogOpinionCount = new SerializableDictionary<ulong, int>(brain.GetDogOpinionsCount());
		reinforcement = new SerializableDictionary<string, float>(brain.GetReinforcementDict());
	}

	public void LoadBrain(DoggyBrain brain)
	{
		brain.SetAnger(anger);
		brain.SetHunger(hunger);
		brain.SetEnergy(energy);
		brain.SetStress(stress);
		brain.SetBoredom(boredom);
		brain.SetHasShownNearDeathPopup(hasShownNearDeathPopup);
		brain.SetHasShownHungerPainsPopup(hasShownHungerPainsPopup);
		brain.SetDogHatchedFromEgg(hatchedFromEgg);
		brain.LoadBarfMeterFromSavedDog(barfMeter);
		brain.SetLifeExtension(lifeExtension);
		brain.SetEndOfLifeModifier(endOfLifeModifier);
		brain.SetCurrentMaxHungerTime(currentMaxHungerTime);
		brain.LoadDogAgeFromSavedDog(dogAge, dogAgeProgress);
		if (personality != null)
		{
			brain.SetPersonality(personality.LoadPersonality());
		}
		else
		{
			brain.SetPersonality(new DogPersonality());
		}
		if (dogOpinions != null)
		{
			brain.SetDogOpinionsFromSavedBrain(dogOpinions);
		}
		if (dogOpinionCount != null)
		{
			brain.SetDogOpinionsCountFromSavedBrain(dogOpinionCount);
		}
		if (reinforcement != null)
		{
			brain.SetReinforcementDictFromSavedBrain(reinforcement);
		}
		if (requiresDeath && !isDead)
		{
			brain.PrepareToDie(deathReason);
		}
	}
}
