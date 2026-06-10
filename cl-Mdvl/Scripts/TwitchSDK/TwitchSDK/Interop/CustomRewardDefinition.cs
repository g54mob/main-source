using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class CustomRewardDefinition : IMarshallable
	{
		internal readonly int TypeCode = 1158389922;

		public string Title;

		public long Cost;

		public string Prompt;

		public bool IsEnabled = true;

		public string BackgroundColor;

		public bool IsUserInputRequired;

		public bool IsMaxPerStreamEnabled;

		public int MaxPerStream;

		public bool IsMaxPerUserPerStreamEnabled;

		public int MaxPerUserPerStream;

		public bool IsGlobalCooldownEnabled;

		public int GlobalCooldownSeconds;

		public bool ShouldRedemptionsSkipRequestQueue;

		public override int GetHashCode()
		{
			return ((((((((((((13 * 7 + Title.GetHashCode()) * 7 + Cost.GetHashCode()) * 7 + Prompt.GetHashCode()) * 7 + IsEnabled.GetHashCode()) * 7 + BackgroundColor.GetHashCode()) * 7 + IsUserInputRequired.GetHashCode()) * 7 + IsMaxPerStreamEnabled.GetHashCode()) * 7 + MaxPerStream.GetHashCode()) * 7 + IsMaxPerUserPerStreamEnabled.GetHashCode()) * 7 + MaxPerUserPerStream.GetHashCode()) * 7 + IsGlobalCooldownEnabled.GetHashCode()) * 7 + GlobalCooldownSeconds.GetHashCode()) * 7 + ShouldRedemptionsSkipRequestQueue.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			CustomRewardDefinition customRewardDefinition = obj as CustomRewardDefinition;
			if (customRewardDefinition == null)
			{
				return false;
			}
			if (Title == customRewardDefinition.Title && Cost == customRewardDefinition.Cost && Prompt == customRewardDefinition.Prompt && IsEnabled == customRewardDefinition.IsEnabled && BackgroundColor == customRewardDefinition.BackgroundColor && IsUserInputRequired == customRewardDefinition.IsUserInputRequired && IsMaxPerStreamEnabled == customRewardDefinition.IsMaxPerStreamEnabled && MaxPerStream == customRewardDefinition.MaxPerStream && IsMaxPerUserPerStreamEnabled == customRewardDefinition.IsMaxPerUserPerStreamEnabled && MaxPerUserPerStream == customRewardDefinition.MaxPerUserPerStream && IsGlobalCooldownEnabled == customRewardDefinition.IsGlobalCooldownEnabled && GlobalCooldownSeconds == customRewardDefinition.GlobalCooldownSeconds)
			{
				return ShouldRedemptionsSkipRequestQueue == customRewardDefinition.ShouldRedemptionsSkipRequestQueue;
			}
			return false;
		}

		public static bool operator ==(CustomRewardDefinition a, CustomRewardDefinition b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(CustomRewardDefinition a, CustomRewardDefinition b)
		{
			return !(a == b);
		}
	}
}
