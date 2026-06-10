using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PredictionOutcome : IMarshallable
	{
		internal readonly int TypeCode = 2038549629;

		public string Id;

		public string Title;

		public long Users;

		public long ChannelPoints;

		public string Color;

		public override int GetHashCode()
		{
			return ((((13 * 7 + Id.GetHashCode()) * 7 + Title.GetHashCode()) * 7 + Users.GetHashCode()) * 7 + ChannelPoints.GetHashCode()) * 7 + Color.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PredictionOutcome predictionOutcome = obj as PredictionOutcome;
			if (predictionOutcome == null)
			{
				return false;
			}
			if (Id == predictionOutcome.Id && Title == predictionOutcome.Title && Users == predictionOutcome.Users && ChannelPoints == predictionOutcome.ChannelPoints)
			{
				return Color == predictionOutcome.Color;
			}
			return false;
		}

		public static bool operator ==(PredictionOutcome a, PredictionOutcome b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PredictionOutcome a, PredictionOutcome b)
		{
			return !(a == b);
		}
	}
}
