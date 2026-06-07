using LitJson;

namespace Gh.Tk
{
	public class BookedEntertainerEvent : GameEvent
	{
		private string _profileId;

		[JsonIgnore]
		private EntertainerProfile _profile;

		private int _entertainerEventId;

		[JsonIgnore]
		public EntertainerProfile Profile => null;

		[JsonIgnore]
		private SpawnEntertainerEvent SpawnEntertainerEvent => null;

		protected BookedEntertainerEvent()
		{
		}

		public BookedEntertainerEvent(EntertainerProfile profile, float day, float hour)
		{
		}

		public void SetPerformanceTime(float day, float hour, float hoursOfPlaytime)
		{
		}

		private void SetPerformanceTime(float dayF, float hoursOfPlaytime)
		{
		}

		public bool CanUnbook()
		{
			return false;
		}

		public override void Trigger()
		{
		}

		protected override void OnDestroy()
		{
		}

		public string GetDatePlaying()
		{
			return null;
		}
	}
}
