using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyPartIdAttribute : DesignerPropertyAttribute
	{
		public bool MustBeConnected { get; set; }

		public string NoOptionsMessage { get; set; }

		public string RequiredPartTypeId { get; set; }

		public string StartMessage { get; set; }
	}
}
