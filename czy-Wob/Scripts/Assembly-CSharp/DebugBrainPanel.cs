using System.Collections.Generic;
using UnityEngine;

public class DebugBrainPanel : MonoBehaviour
{
	public bool debugEnabled;

	public string currentBehavior;

	public string currentTarget;

	public string fixation;

	public string distraction;

	public float hunger;

	public bool makeFull;

	public bool makeHungry;

	public float stress;

	public bool makeStressed;

	public bool makeNotStressed;

	public float energy;

	public bool makeTired;

	public bool makeNotTired;

	public float anger;

	public bool makeAngry;

	public bool makeNotAngry;

	public float boredom;

	public bool makeBored;

	public bool makeNotBored;

	public FoodPersonalityType foodPersonality;

	public SocialPersonalityType socialPersonality;

	public EnergyPersonalityType energyPersonality;

	public MischiefPersonalityType mischiefPersonality;

	public NicenessPersonalityType nicenessPersonality;

	public PettablePersonalityType pettablePersonality;

	public LoudnessPersonalityType loudnessPersonality;

	public List<string> dogOpinions = new List<string>();

	private DogAI aiRef;

	private DoggyBrain brainRef;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		aiRef = GetComponent<DogAI>();
		brainRef = GetComponent<DoggyBrain>();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void Update()
	{
		if (debugEnabled)
		{
			UpdateDogOpinions();
			CheckDebugOptions();
			UpdateNeedsDisplay();
			UpdateCurrentBehavior();
			UpdatePersonalityDisplay();
			UpdateFixationDistractionDisplay();
		}
	}

	private void CheckDebugOptions()
	{
		if (makeFull)
		{
			makeFull = false;
			brainRef.SetHunger(1f);
		}
		if (makeHungry)
		{
			makeHungry = false;
			if (brainRef.GetCurrentHunger() > 0.5f)
			{
				brainRef.SetHunger(0.5f);
			}
		}
		if (makeStressed)
		{
			makeStressed = false;
			brainRef.SetStress(0f);
		}
		if (makeNotStressed)
		{
			makeNotStressed = false;
			brainRef.SetStress(1f);
		}
		if (makeAngry)
		{
			makeAngry = false;
			brainRef.SetAnger(1f);
		}
		if (makeNotAngry)
		{
			makeNotAngry = false;
			brainRef.SetAnger(0f);
		}
		if (makeTired)
		{
			makeTired = false;
			brainRef.SetEnergy(0f);
		}
		if (makeNotTired)
		{
			makeNotTired = false;
			brainRef.SetEnergy(1f);
		}
		if (makeBored)
		{
			makeBored = false;
			brainRef.SetBoredom(0f);
		}
		if (makeNotBored)
		{
			makeNotBored = false;
			brainRef.SetBoredom(1f);
		}
	}

	private void UpdateDogOpinions()
	{
		dogOpinions.Clear();
		Dictionary<ulong, Opinion> dictionary = brainRef.GetDogOpinions();
		foreach (ulong key in dictionary.Keys)
		{
			SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(key);
			if (saveableDogFromID != null)
			{
				dogOpinions.Add(saveableDogFromID.dogName + "(" + key + "): " + dictionary[key]);
			}
			else
			{
				dogOpinions.Add("Missing Name (" + key + "): " + dictionary[key]);
			}
		}
	}

	private void UpdateCurrentBehavior()
	{
		if (aiRef.GetCurrentBehavior() == null)
		{
			currentTarget = "No Target";
			currentBehavior = "No Behavior";
			return;
		}
		currentBehavior = aiRef.GetCurrentBehavior().ToString();
		GameObject target = aiRef.GetCurrentBehavior().GetTarget();
		if (target == null)
		{
			currentTarget = "No Target";
			return;
		}
		target = target.transform.root.gameObject;
		string text = "";
		ObjectID component = target.GetComponent<ObjectID>();
		if (component != null)
		{
			text = component.GetUID().ToString();
		}
		currentTarget = target.name + " : " + text;
	}

	private void UpdateNeedsDisplay()
	{
		anger = brainRef.GetCurrentAnger();
		hunger = brainRef.GetCurrentHunger();
		stress = brainRef.GetCurrentStress();
		energy = brainRef.GetCurrentEnergy();
		boredom = brainRef.GetCurrentBoredom();
	}

	private void UpdateFixationDistractionDisplay()
	{
		if (aiRef.GetCurrentFixation() == null)
		{
			fixation = "";
		}
		else
		{
			fixation = aiRef.GetCurrentFixation().ToString();
		}
		if (aiRef.GetCurrentDistraction() == null)
		{
			distraction = "";
		}
		else
		{
			distraction = aiRef.GetCurrentDistraction().ToString();
		}
	}

	private void UpdatePersonalityDisplay()
	{
		DogPersonality personality = brainRef.GetPersonality();
		foodPersonality = personality.GetFoodPersonality();
		socialPersonality = personality.GetSocialPersonality();
		energyPersonality = personality.GetEnergyPersonality();
		mischiefPersonality = personality.GetMischiefPersonality();
		nicenessPersonality = personality.GetNicenessPersonalityType();
		pettablePersonality = personality.GetPettablePersonalityType();
		loudnessPersonality = personality.GetLoudnessPersonalityType();
	}
}
