using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AudioManagerConfig
	{
		public bool LogMissingEvents;

		public bool LogAllEvents;

		public bool LogLookups;

		public bool LogBankLoads = true;

		public bool LogBankRefCounts;

		public VOBank VOBank;
	}
}
