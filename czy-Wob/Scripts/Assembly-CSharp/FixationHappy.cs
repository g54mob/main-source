using System.Collections.Generic;
using UnityEngine;

public class FixationHappy : FixationBase
{
	public FixationHappy(DogAI newAIRef)
		: base(newAIRef)
	{
		lockoutTime = 0f;
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		float happyPercentage = dog.GetComponent<DoggyBrain>().GetHappyPercentage();
		if (!(happyPercentage <= 0f))
		{
			ScorableFixation item = new ScorableFixation
			{
				fixationType = FixationType.HAPPINESS
			};
			float item2 = FixationBase.baseScore * happyPercentage;
			fixationList.Add(item);
			fixationScores.Add(item2);
		}
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if ((currentRunningBehavior == null || currentRunningBehavior.CanBeReplaced()) && currentFixationTime >= maxFixationTime)
		{
			aiRef.OnFixationDone();
		}
		else
		{
			FindNewBehavior(currentRunningBehavior == null);
		}
	}

	protected override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null && !currentRunningBehavior.CanBeReplaced())
		{
			return true;
		}
		bool num = aiRef.FindNewFixationTypeBehavior(FixationType.HAPPINESS, forceInterrupt);
		if (!num)
		{
			aiRef.OnFixationDone();
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
