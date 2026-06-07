using LitJson;

namespace Gh.Tk
{
	public class SpawnEntertainerEvent : GameEvent
	{
		private string _profileId;

		[JsonIgnore]
		private EntertainerProfile _profile;

		[JsonIgnore]
		public EntertainerProfile Profile => null;

		protected SpawnEntertainerEvent()
		{
		}

		public SpawnEntertainerEvent(EntertainerProfile profile)
		{
		}

		public void SetArrivalTime(float dayF)
		{
		}

		public override void Trigger()
		{
		}
	}
}
