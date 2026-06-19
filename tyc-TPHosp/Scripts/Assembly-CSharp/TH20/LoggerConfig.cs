using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LoggerConfig
	{
		public string LogFileNamePrefix = "tph-log-";

		public string LogFileNameDateFormat = "yyyy-MM-dd_HH.mm.ss";

		public string LogFileNameExtension = ".txt";

		public TimeSpan TimeToKeepLogFiles = TimeSpan.FromDays(7.0);

		public string LogFileSubdirectory = "Logs";
	}
}
