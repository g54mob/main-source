using System;
using System.Reflection;
using QFSW.QC;

namespace PugMod
{
	public class CommandWithModSupportScanRule : IQcScanRule
	{
		public ScanRuleResult ShouldScan<T>(T entity) where T : ICustomAttributeProvider
		{
			if (((entity as System.Reflection.MemberInfo)?.Module.Assembly.GetName().Name ?? string.Empty) == "QFSW.QC")
			{
				return ScanRuleResult.Accept;
			}
			Type typeFromHandle = typeof(CommandAttribute);
			if (entity.IsDefined(typeFromHandle, inherit: true))
			{
				Type typeFromHandle2 = typeof(CommandWithModSupportAttribute);
				if (!entity.IsDefined(typeFromHandle2, inherit: true))
				{
					return ScanRuleResult.Reject;
				}
			}
			return ScanRuleResult.Accept;
		}
	}
}
