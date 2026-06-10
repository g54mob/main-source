using FoxyVoxel.Logging;

namespace NSMedieval.Goap.Actions
{
	public static class GeneralActions
	{
		public static GoapAction Instant()
		{
			return new GoapAction("Instant")
			{
				CompleteMode = ActionCompleteMode.Instant
			};
		}

		public static GoapAction Instant(string id)
		{
			return new GoapAction("Instant " + id)
			{
				CompleteMode = ActionCompleteMode.Instant
			};
		}

		public static GoapAction Wait(float time = 0f)
		{
			GoapAction obj = new GoapAction("Wait")
			{
				CompleteMode = ActionCompleteMode.Delay
			};
			obj.CompleteAfterTimeExpires(time);
			return obj;
		}

		public static GoapAction WaitForever(string name = "WaitForever")
		{
			return new GoapAction(name)
			{
				CompleteMode = ActionCompleteMode.Never
			};
		}

		public static GoapAction WaitUntilTimeLeftExpires(GoapAction delayedAction)
		{
			GoapAction action = new GoapAction("WaitUntilDurationExpires");
			action.OnInit = delegate
			{
				if (delayedAction.CompleteMode != ActionCompleteMode.Delay)
				{
					Log.Error("WaitUntilTimeLeftExpires requires action with complete mode Delay!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\GeneralActions.cs");
				}
				else
				{
					float num = delayedAction.Duration - delayedAction.TotalTickingTime;
					if (num > 0f)
					{
						action.CompleteAfterTimeExpires(num);
					}
				}
			};
			return action;
		}
	}
}
