using System;

[Serializable]
public class SaveableDogPersonality
{
	public FoodPersonalityType foodPersonality = FoodPersonalityType.STANDARD;

	public SocialPersonalityType socialPersonality = SocialPersonalityType.STANDARD;

	public EnergyPersonalityType energyPersonality = EnergyPersonalityType.STANDARD;

	public MischiefPersonalityType mischiefPersonality = MischiefPersonalityType.STANDARD;

	public NicenessPersonalityType nicenessPersonality = NicenessPersonalityType.STANDARD;

	public PettablePersonalityType pettablePersonality;

	public LoudnessPersonalityType loudnessPersonality;

	public SaveableDogPersonality(DogPersonality existingPersonality)
	{
		foodPersonality = existingPersonality.GetFoodPersonality();
		socialPersonality = existingPersonality.GetSocialPersonality();
		energyPersonality = existingPersonality.GetEnergyPersonality();
		mischiefPersonality = existingPersonality.GetMischiefPersonality();
		nicenessPersonality = existingPersonality.GetNicenessPersonalityType();
		pettablePersonality = existingPersonality.GetPettablePersonalityType();
		loudnessPersonality = existingPersonality.GetLoudnessPersonalityType();
	}

	private SaveableDogPersonality()
	{
	}

	public SaveableDogPersonality GetCopy()
	{
		return new SaveableDogPersonality
		{
			foodPersonality = foodPersonality,
			socialPersonality = socialPersonality,
			energyPersonality = energyPersonality,
			mischiefPersonality = mischiefPersonality,
			nicenessPersonality = nicenessPersonality,
			pettablePersonality = pettablePersonality,
			loudnessPersonality = loudnessPersonality
		};
	}

	public DogPersonality LoadPersonality()
	{
		return new DogPersonality(foodPersonality, socialPersonality, energyPersonality, mischiefPersonality, nicenessPersonality, pettablePersonality, loudnessPersonality);
	}
}
