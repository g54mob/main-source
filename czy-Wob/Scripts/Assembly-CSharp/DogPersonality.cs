using UnityEngine;

public class DogPersonality
{
	private FoodPersonalityType _foodPersonality = FoodPersonalityType.STANDARD;

	private SocialPersonalityType _socialPersonality = SocialPersonalityType.STANDARD;

	private EnergyPersonalityType _energyPersonality = EnergyPersonalityType.STANDARD;

	private MischiefPersonalityType _mischiefPersonality = MischiefPersonalityType.STANDARD;

	private NicenessPersonalityType _nicenessPersonality = NicenessPersonalityType.STANDARD;

	private PettablePersonalityType _pettablePersonality;

	private LoudnessPersonalityType _loudnessPersonality;

	private int maxTraitCount = 6;

	private float socialChance = 0.1f;

	private float aloofChance = 0.1f;

	private float goofChance = 0.1f;

	private float layaboutChance = 0.1f;

	private float foodObsessedChance = 0.1f;

	private float foodAverseChance = 0.1f;

	private float mischiefChance = 0.1f;

	private float politeChance = 0.1f;

	private float niceChance = 0.1f;

	private float meanChance = 0.05f;

	private float loudChance = 0.1f;

	private float quietChance = 0.1f;

	private float dislikesPettingChance = 0.05f;

	public DogPersonality(bool traitsAllowed = true)
	{
		if (traitsAllowed)
		{
			GenerateNewPersonality();
		}
	}

	public DogPersonality(FoodPersonalityType foodPersonality, SocialPersonalityType socialPersonality, EnergyPersonalityType energyPersonality, MischiefPersonalityType mischiefPersonality, NicenessPersonalityType nicenessPersonality, PettablePersonalityType pettablePersonality, LoudnessPersonalityType loudnessPersonality)
	{
		_foodPersonality = foodPersonality;
		_socialPersonality = socialPersonality;
		_energyPersonality = energyPersonality;
		_mischiefPersonality = mischiefPersonality;
		_nicenessPersonality = nicenessPersonality;
		_pettablePersonality = pettablePersonality;
		_loudnessPersonality = loudnessPersonality;
	}

	public void GenerateNewPersonality()
	{
		GenerateNewFoodPersonality();
		GenerateNewSocialPersonality();
		GenerateNewEnergyPersonality();
		GenerateNewMischiefPersonality();
		GenerateNewNicenessPersonality();
		GenerateNewPettablePersonality();
		if (GetTraitCount() < maxTraitCount)
		{
			GenerateNewLoudnessPersonality();
		}
	}

	private int GetTraitCount()
	{
		int num = 0;
		if (_foodPersonality != FoodPersonalityType.STANDARD)
		{
			num++;
		}
		if (_socialPersonality != SocialPersonalityType.STANDARD)
		{
			num++;
		}
		if (_energyPersonality != EnergyPersonalityType.STANDARD)
		{
			num++;
		}
		if (_mischiefPersonality != MischiefPersonalityType.STANDARD)
		{
			num++;
		}
		if (_nicenessPersonality != NicenessPersonalityType.STANDARD)
		{
			num++;
		}
		if (_pettablePersonality != PettablePersonalityType.LIKES_PETTING)
		{
			num++;
		}
		if (_loudnessPersonality != LoudnessPersonalityType.STANDARD)
		{
			num++;
		}
		return num;
	}

	public FoodPersonalityType GetFoodPersonality()
	{
		return _foodPersonality;
	}

	public void SetFoodPersonality(FoodPersonalityType newType)
	{
		_foodPersonality = newType;
	}

	public SocialPersonalityType GetSocialPersonality()
	{
		return _socialPersonality;
	}

	public void SetSocialPersonality(SocialPersonalityType newType)
	{
		_socialPersonality = newType;
	}

	public EnergyPersonalityType GetEnergyPersonality()
	{
		return _energyPersonality;
	}

	public void SetEnergyPersonality(EnergyPersonalityType newType)
	{
		_energyPersonality = newType;
	}

	public MischiefPersonalityType GetMischiefPersonality()
	{
		return _mischiefPersonality;
	}

	public void SetMischiefPersonality(MischiefPersonalityType newType)
	{
		_mischiefPersonality = newType;
	}

	public NicenessPersonalityType GetNicenessPersonalityType()
	{
		return _nicenessPersonality;
	}

	public void SetNicenessPersonality(NicenessPersonalityType newType)
	{
		_nicenessPersonality = newType;
	}

	public PettablePersonalityType GetPettablePersonalityType()
	{
		return _pettablePersonality;
	}

	public void SetPettablePersonality(PettablePersonalityType newType)
	{
		_pettablePersonality = newType;
	}

	public LoudnessPersonalityType GetLoudnessPersonalityType()
	{
		return _loudnessPersonality;
	}

	public void SetLoudnessPersonality(LoudnessPersonalityType newType)
	{
		_loudnessPersonality = newType;
	}

	private void GenerateNewFoodPersonality()
	{
		float value = Random.value;
		if (value <= foodObsessedChance)
		{
			_foodPersonality = FoodPersonalityType.FOOD_OBSESSED;
		}
		else if (value >= 1f - foodAverseChance)
		{
			_foodPersonality = FoodPersonalityType.FOOD_AVERSE;
		}
	}

	private void GenerateNewSocialPersonality()
	{
		float value = Random.value;
		if (value <= socialChance)
		{
			_socialPersonality = SocialPersonalityType.SOCIAL;
		}
		else if (value >= 1f - aloofChance)
		{
			_socialPersonality = SocialPersonalityType.ALOOF;
		}
	}

	private void GenerateNewEnergyPersonality()
	{
		float value = Random.value;
		if (value <= goofChance)
		{
			_energyPersonality = EnergyPersonalityType.GOOF;
		}
		else if (value >= 1f - layaboutChance)
		{
			_energyPersonality = EnergyPersonalityType.LAYABOUT;
		}
	}

	private void GenerateNewMischiefPersonality()
	{
		float value = Random.value;
		if (value <= politeChance)
		{
			_mischiefPersonality = MischiefPersonalityType.POLITE;
		}
		else if (value >= 1f - mischiefChance)
		{
			_mischiefPersonality = MischiefPersonalityType.MISCHEVIOUS;
		}
	}

	private void GenerateNewNicenessPersonality()
	{
		float value = Random.value;
		if (value <= niceChance)
		{
			_nicenessPersonality = NicenessPersonalityType.NICE;
		}
		else if (value >= 1f - meanChance)
		{
			_nicenessPersonality = NicenessPersonalityType.MEAN;
		}
	}

	private void GenerateNewPettablePersonality()
	{
		if (Random.value <= dislikesPettingChance)
		{
			_pettablePersonality = PettablePersonalityType.DISLIKES_PETTING;
		}
	}

	private void GenerateNewLoudnessPersonality()
	{
		float value = Random.value;
		if (value <= loudChance)
		{
			_loudnessPersonality = LoudnessPersonalityType.LOUD;
		}
		else if (value >= 1f - quietChance)
		{
			_loudnessPersonality = LoudnessPersonalityType.QUIET;
		}
	}
}
