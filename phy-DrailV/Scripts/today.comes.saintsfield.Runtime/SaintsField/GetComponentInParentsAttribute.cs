using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class GetComponentInParentsAttribute : GetByXPathAttribute
	{
		public bool IncludeInactive;

		public Type CompType;

		public bool ExcludeSelf;

		public virtual int Limit => 0;

		public override string GroupBy { get; }

		public GetComponentInParentsAttribute(bool includeInactive = false, Type compType = null, bool excludeSelf = false, string groupBy = "")
		{
			ParseOptions(SaintsFieldConfigUtil.GetComponentInParentsExp(EXP.NoAutoResignToNull | EXP.NoPicker));
			ParseArguments(includeInactive, compType, excludeSelf);
			GroupBy = groupBy;
			IncludeInactive = includeInactive;
			CompType = compType;
			ExcludeSelf = excludeSelf;
			base.OptimizationPayload = new GetComponentInParentsPayload(IncludeInactive, CompType, ExcludeSelf, 0);
		}

		public GetComponentInParentsAttribute(EXP config, bool includeInactive = false, Type compType = null, bool excludeSelf = false, string groupBy = "")
		{
			ParseOptions(config);
			ParseArguments(includeInactive, compType, excludeSelf);
			GroupBy = groupBy;
			IncludeInactive = includeInactive;
			CompType = compType;
			ExcludeSelf = excludeSelf;
			base.OptimizationPayload = new GetComponentInParentsPayload(IncludeInactive, CompType, ExcludeSelf, 0);
		}

		private void ParseArguments(bool includeInactive, Type compType, bool excludeSelf)
		{
			string componentFilter = GetByXPathAttribute.GetComponentFilter(compType);
			string text = (includeInactive ? "" : "[@{gameObject.activeInHierarchy}]") + componentFilter;
			string sepFilter = ((text == "") ? "" : ("/" + text));
			IEnumerable<string> source = ((!excludeSelf) ? new string[1] { "//ancestor-or-self::" } : new string[1] { "//ancestor::" }).Select((string each) => each + sepFilter);
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
