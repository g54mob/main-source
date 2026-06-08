using System;

namespace HandlebarsDotNet
{
	public class Compatibility
	{
		[Obsolete("@last is supported on Handlebarsjs, so it is always enabled, and the setting should be removed.")]
		public bool SupportLastInObjectIterations { get; set; } = true;

		[Obsolete("Toggle will be removed in the next major release")]
		public bool RelaxedHelperNaming { get; set; }
	}
}
