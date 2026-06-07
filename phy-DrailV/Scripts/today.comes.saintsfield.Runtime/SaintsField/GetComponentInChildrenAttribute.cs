using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class GetComponentInChildrenAttribute : GetByXPathAttribute
	{
		public readonly Type CompType;

		public readonly bool IncludeInactive;

		public readonly bool ExcludeSelf;

		public override string GroupBy { get; }

		public GetComponentInChildrenAttribute(bool includeInactive = false, Type compType = null, bool excludeSelf = false, string groupBy = "")
		{
			ParseOptions(SaintsFieldConfigUtil.GetComponentInChildrenExp(EXP.NoAutoResignToNull | EXP.NoPicker));
			ParseArguments(includeInactive, compType, excludeSelf);
			GroupBy = groupBy;
			CompType = compType;
			IncludeInactive = includeInactive;
			ExcludeSelf = excludeSelf;
			base.OptimizationPayload = new GetComponentInChildrenPayload(compType, includeInactive, excludeSelf);
		}

		public GetComponentInChildrenAttribute(EXP config, bool includeInactive = false, Type compType = null, bool excludeSelf = false, string groupBy = "")
		{
			ParseOptions(config);
			ParseArguments(includeInactive, compType, excludeSelf);
			GroupBy = groupBy;
			base.OptimizationPayload = new GetComponentInChildrenPayload(compType, includeInactive, excludeSelf);
		}

		private void ParseArguments(bool includeInactive, Type compType, bool excludeSelf)
		{
			string compFilter = GetByXPathAttribute.GetComponentFilter(compType);
			string activeFilter = (includeInactive ? "" : "[@{gameObject.activeInHierarchy}]");
			IEnumerable<string> source = ((!excludeSelf) ? new string[2] { "", "//*" } : new string[1] { "//*" }).Select((string each) => each + activeFilter + compFilter);
			XPathInfoAndList = source.Select((string ePath) => new XPathInfo[1]
			{
				new XPathInfo
				{
					IsCallback = false,
					Callback = ""
				}
			}).ToArray();
		}
	}
}
