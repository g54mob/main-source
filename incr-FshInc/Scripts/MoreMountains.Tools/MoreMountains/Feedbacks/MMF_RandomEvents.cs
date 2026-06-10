using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to play a random Unity Event, out of a weighted list. To use it, add items to its WeightedEvents list. For each of them, you'll need to specify a weight (the higher the weight, the more likely it'll be picked) and the event to trigger. For an event in that list to have a chance to be picked, the weights can't be zero.")]
	[FeedbackPath("Events/Random Unity Events")]
	public class MMF_RandomEvents : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Events", true, 44, false, false)]
		[Tooltip("the list of events from which to pick")]
		public List<WeightedEvent> WeightedEvents;

		protected MMShufflebag<int> _weightShuffleBag;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (WeightedEvents != null && WeightedEvents.Count != 0)
			{
				_weightShuffleBag = new MMShufflebag<int>(WeightedEvents.Count);
				for (int i = 0; i < WeightedEvents.Count; i++)
				{
					_weightShuffleBag.Add(i, WeightedEvents[i].Weight);
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && WeightedEvents != null && WeightedEvents.Count != 0 && _weightShuffleBag != null)
			{
				int index = _weightShuffleBag.Pick();
				WeightedEvents[index].Event.Invoke();
			}
		}
	}
}
