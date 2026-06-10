using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class PredictionDefinition : IMarshallable
	{
		internal readonly int TypeCode = -354228052;

		public string Title;

		public string[] Outcomes;

		public int Duration;

		public override int GetHashCode()
		{
			return ((13 * 7 + Title.GetHashCode()) * 7 + Outcomes.GetHashCode()) * 7 + Duration.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			PredictionDefinition predictionDefinition = obj as PredictionDefinition;
			if (predictionDefinition == null)
			{
				return false;
			}
			if (Title == predictionDefinition.Title && Outcomes == predictionDefinition.Outcomes)
			{
				return Duration == predictionDefinition.Duration;
			}
			return false;
		}

		public static bool operator ==(PredictionDefinition a, PredictionDefinition b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(PredictionDefinition a, PredictionDefinition b)
		{
			return !(a == b);
		}
	}
}
