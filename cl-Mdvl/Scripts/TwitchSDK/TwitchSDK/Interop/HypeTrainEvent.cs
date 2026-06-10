using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class HypeTrainEvent : IMarshallable
	{
		internal readonly int TypeCode = 1200007443;

		public string HypeTrainId;

		public string BroadcasterId;

		public string BroadcasterName;

		public int Level;

		public long TotalPoints;

		public long Progress;

		public long Goal;

		public string StartedAt;

		public string ExpiresAt;

		public string EndedAt;

		public string CooldownEndsAt;

		public HypeTrainContribution[] TopContributions;

		public HypeTrainContribution LastContribution;

		public override int GetHashCode()
		{
			return ((((((((((((13 * 7 + HypeTrainId.GetHashCode()) * 7 + BroadcasterId.GetHashCode()) * 7 + BroadcasterName.GetHashCode()) * 7 + Level.GetHashCode()) * 7 + TotalPoints.GetHashCode()) * 7 + Progress.GetHashCode()) * 7 + Goal.GetHashCode()) * 7 + StartedAt.GetHashCode()) * 7 + ExpiresAt.GetHashCode()) * 7 + EndedAt.GetHashCode()) * 7 + CooldownEndsAt.GetHashCode()) * 7 + TopContributions.GetHashCode()) * 7 + LastContribution.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			HypeTrainEvent hypeTrainEvent = obj as HypeTrainEvent;
			if (hypeTrainEvent == null)
			{
				return false;
			}
			if (HypeTrainId == hypeTrainEvent.HypeTrainId && BroadcasterId == hypeTrainEvent.BroadcasterId && BroadcasterName == hypeTrainEvent.BroadcasterName && Level == hypeTrainEvent.Level && TotalPoints == hypeTrainEvent.TotalPoints && Progress == hypeTrainEvent.Progress && Goal == hypeTrainEvent.Goal && StartedAt == hypeTrainEvent.StartedAt && ExpiresAt == hypeTrainEvent.ExpiresAt && EndedAt == hypeTrainEvent.EndedAt && CooldownEndsAt == hypeTrainEvent.CooldownEndsAt && TopContributions == hypeTrainEvent.TopContributions)
			{
				return LastContribution == hypeTrainEvent.LastContribution;
			}
			return false;
		}

		public static bool operator ==(HypeTrainEvent a, HypeTrainEvent b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(HypeTrainEvent a, HypeTrainEvent b)
		{
			return !(a == b);
		}
	}
}
