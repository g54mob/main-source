using System.Collections.Generic;
using UnityEngine;

public class FixationHoardObjects : FixationBase
{
	private bool hasRunBehavior;

	private DogBehaviorBase hoardObjectBehavior;

	public FixationHoardObjects(DogAI newAIRef)
		: base(newAIRef)
	{
		hoardObjectBehavior = aiRef.fixationTypeBehaviorMapping[FixationType.HOARD_OBJECTS][0];
	}

	public static void ScoreAndAddFixations(GameObject dog, ref List<ScorableFixation> fixationList, ref List<float> fixationScores)
	{
		if (DogDenManager.CanDogAccessAnyCompletedDen(dog.GetComponent<ObjectID>().GetUID()).HasValue)
		{
			ScorableFixation item = new ScorableFixation
			{
				fixationType = FixationType.HOARD_OBJECTS
			};
			float item2 = FixationBase.baseScore * 2f;
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
		if (currentRunningBehavior == null && hasRunBehavior)
		{
			aiRef.OnFixationDone();
			return;
		}
		FindNewBehavior(currentRunningBehavior == null);
		if (currentRunningBehavior != null)
		{
			hasRunBehavior = true;
		}
	}

	protected override bool FindNewBehavior(bool forceInterrupt)
	{
		if (currentRunningBehavior != null)
		{
			return true;
		}
		if (aiRef.TryRunBehavior(hoardObjectBehavior, null, forceInterrupt))
		{
			currentRunningBehavior = aiRef.GetCurrentBehavior();
			return true;
		}
		currentRunningBehavior = aiRef.GetCurrentBehavior();
		aiRef.OnFixationDone();
		return false;
	}
}
