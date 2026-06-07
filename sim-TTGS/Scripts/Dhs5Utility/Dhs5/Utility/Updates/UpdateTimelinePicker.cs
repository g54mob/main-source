using System;
using Dhs5.Utility.Databases;

namespace Dhs5.Utility.Updates
{
	[Serializable]
	public class UpdateTimelinePicker : DataPicker<UpdateTimelineDatabase>
	{
		public UpdateTimelineObject Get()
		{
			if (TryGetUpdateTimeline(out var element))
			{
				return element;
			}
			return null;
		}

		public bool TryGetUpdateTimeline(out UpdateTimelineObject element)
		{
			return TryGetData<UpdateTimelineObject>(out element);
		}
	}
}
