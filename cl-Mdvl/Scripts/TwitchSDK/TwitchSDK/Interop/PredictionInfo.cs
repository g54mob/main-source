using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PredictionInfo : IMarshallable
	{
		internal readonly int TypeCode = -1418330344;

		public string Id;

		public string BroadcasterId;

		public string Title;

		public string WinningOutcomeId;

		public PredictionOutcome[] Outcomes;

		public PredictionStatus Status;

		public string CreatedAt;

		public string EndedAt;

		public string LockedAt;

		public override int GetHashCode()
		{
			return ((((((((13 * 7 + Id.GetHashCode()) * 7 + BroadcasterId.GetHashCode()) * 7 + Title.GetHashCode()) * 7 + WinningOutcomeId.GetHashCode()) * 7 + Outcomes.GetHashCode()) * 7 + Status.GetHashCode()) * 7 + CreatedAt.GetHashCode()) * 7 + EndedAt.GetHashCode()) * 7 + LockedAt.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PredictionInfo predictionInfo = obj as PredictionInfo;
			if (predictionInfo == null)
			{
				return false;
			}
			if (Id == predictionInfo.Id && BroadcasterId == predictionInfo.BroadcasterId && Title == predictionInfo.Title && WinningOutcomeId == predictionInfo.WinningOutcomeId && Outcomes == predictionInfo.Outcomes && Status == predictionInfo.Status && CreatedAt == predictionInfo.CreatedAt && EndedAt == predictionInfo.EndedAt)
			{
				return LockedAt == predictionInfo.LockedAt;
			}
			return false;
		}

		public static bool operator ==(PredictionInfo a, PredictionInfo b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PredictionInfo a, PredictionInfo b)
		{
			return !(a == b);
		}
	}
}
