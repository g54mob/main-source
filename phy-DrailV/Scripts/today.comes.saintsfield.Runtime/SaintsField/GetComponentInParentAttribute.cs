using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class GetComponentInParentAttribute : GetComponentInParentsAttribute
	{
		public override int Limit => 1;

		public override string GroupBy { get; }

		public GetComponentInParentAttribute(Type compType = null, bool excludeSelf = false, string groupBy = "")
		{
			ParseOptions(SaintsFieldConfigUtil.GetComponentInParentExp(EXP.NoAutoResignToNull | EXP.NoPicker));
			ParseArguments(compType, excludeSelf);
			GroupBy = groupBy;
			IncludeInactive = true;
			CompType = compType;
			ExcludeSelf = excludeSelf;
			base.OptimizationPayload = new GetComponentInParentsPayload(includeInactive: true, CompType, excludeSelf, 1);
		}

		public GetComponentInParentAttribute(EXP config, Type compType = null, bool excludeSelf = false, string groupBy = "")
		{
			ParseOptions(config);
			ParseArguments(compType, excludeSelf);
			GroupBy = groupBy;
			IncludeInactive = true;
			CompType = compType;
			ExcludeSelf = excludeSelf;
			base.OptimizationPayload = new GetComponentInParentsPayload(includeInactive: true, CompType, excludeSelf, 1);
		}

		private void ParseArguments(Type compType, bool excludeSelf)
		{
			string componentFilter = GetByXPathAttribute.GetComponentFilter(compType);
			string sepFilter = ((componentFilter == "") ? "" : ("/" + componentFilter));
			IEnumerable<string> source = ((!excludeSelf) ? new string[1] { "//parent-or-self::" } : new string[1] { "//parent::" }).Select((string each) => each + sepFilter);
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
