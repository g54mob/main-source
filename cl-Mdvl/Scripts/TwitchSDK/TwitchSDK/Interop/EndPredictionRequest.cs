using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class EndPredictionRequest : IMarshallable
	{
		internal readonly int TypeCode = -359250458;

		public string BroadcasterId;

		public string PredictionId;

		public PredictionStatus Status;

		public string WinningOutcomeId;

		public override int GetHashCode()
		{
			return (((13 * 7 + BroadcasterId.GetHashCode()) * 7 + PredictionId.GetHashCode()) * 7 + Status.GetHashCode()) * 7 + WinningOutcomeId.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			EndPredictionRequest endPredictionRequest = obj as EndPredictionRequest;
			if (endPredictionRequest == null)
			{
				return false;
			}
			if (BroadcasterId == endPredictionRequest.BroadcasterId && PredictionId == endPredictionRequest.PredictionId && Status == endPredictionRequest.Status)
			{
				return WinningOutcomeId == endPredictionRequest.WinningOutcomeId;
			}
			return false;
		}

		public static bool operator ==(EndPredictionRequest a, EndPredictionRequest b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(EndPredictionRequest a, EndPredictionRequest b)
		{
			return !(a == b);
		}
	}
}
