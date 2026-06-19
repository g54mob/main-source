using System;

namespace Loxodon.Framework.Attributes
{
	[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
	public class RemarkAttribute : Attribute
	{
		private string remark;

		public string Remark => remark;

		public RemarkAttribute(string remark)
		{
			this.remark = remark;
		}
	}
}
