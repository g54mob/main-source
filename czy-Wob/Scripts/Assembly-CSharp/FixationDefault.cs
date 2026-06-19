using System.Collections.Generic;
using UnityEngine;

public class FixationDefault : FixationBase
{
	public FixationDefault(DogAI newAIRef)
		: base(newAIRef)
	{
		lockoutTime = 0f;
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		ScorableFixation item = new ScorableFixation
		{
			fixationType = FixationType.DEFAULT
		};
		float item2 = FixationBase.baseScore;
		fixationList.Add(item);
		fixationScores.Add(item2);
	}

	public override void Update()
	{
		base.Update();
		if (currentRunningBehavior != null && !currentRunningBehavior.IsRunningBehavior())
		{
			currentRunningBehavior = null;
		}
		if (currentRunningBehavior == null && currentFixationTime >= maxFixationTime)
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
		if (currentRunningBehavior != null)
		{
			return true;
		}
		bool num = aiRef.FindNewFixationTypeBehavior(FixationType.DEFAULT, forceInterrupt);
		if (!num)
		{
			aiRef.OnFixationDone();
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		return num;
	}
}
