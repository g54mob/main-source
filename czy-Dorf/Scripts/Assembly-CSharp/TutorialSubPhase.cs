using UnityEngine;

public class TutorialSubPhase : TutorialPhase
{
	[SerializeField]
	private TutorialPhase followupPhase;

	protected override void Finish()
	{
		watcher.OnConditionFulfilled -= Finish;
		TutorialEvent[] array = events;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Finish();
		}
		followupPhase.Begin();
	}
}
