using System;
using UnityEngine;

[Serializable]
public class PersonalityScoreModifier
{
	public FoodPersonalityType foodType = FoodPersonalityType.STANDARD;

	public EnergyPersonalityType energyType = EnergyPersonalityType.STANDARD;

	public SocialPersonalityType socialType = SocialPersonalityType.STANDARD;

	public MischiefPersonalityType mischiefType = MischiefPersonalityType.STANDARD;

	public NicenessPersonalityType nicenessType = NicenessPersonalityType.STANDARD;

	public PettablePersonalityType pettableType;

	public LoudnessPersonalityType loudnessType;

	public float scoreMultiplier = 1f;

	public PersonalityType personalityType;

	public bool DoesPersonalityGetModifier(DogPersonality personalityRef)
	{
		if (personalityType == PersonalityType.FOOD)
		{
			return personalityRef.GetFoodPersonality() == foodType;
		}
		if (personalityType == PersonalityType.ENERGY)
		{
			return personalityRef.GetEnergyPersonality() == energyType;
		}
		if (personalityType == PersonalityType.SOCIAL)
		{
			return personalityRef.GetSocialPersonality() == socialType;
		}
		if (personalityType == PersonalityType.MISCHIEF)
		{
			return personalityRef.GetMischiefPersonality() == mischiefType;
		}
		if (personalityType == PersonalityType.NICENESS)
		{
			return personalityRef.GetNicenessPersonalityType() == nicenessType;
		}
		if (personalityType == PersonalityType.PETTABLE)
		{
			return personalityRef.GetPettablePersonalityType() == pettableType;
		}
		if (personalityType == PersonalityType.LOUDNESS)
		{
			return personalityRef.GetLoudnessPersonalityType() == loudnessType;
		}
		Debug.LogError("Unhandled personalityType: " + personalityType);
		return false;
	}
}
