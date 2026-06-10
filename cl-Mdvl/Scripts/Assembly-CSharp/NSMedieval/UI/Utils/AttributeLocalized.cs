using NSMedieval.StatsSystem;

namespace NSMedieval.UI.Utils
{
	public struct AttributeLocalized
	{
		public AttributeInstance Attribute { get; set; }

		public string LocalizedName { get; set; }

		public string LocalizedDescription { get; set; }

		public string LocalizedValue { get; set; }

		public string LocalizedBaseValue { get; set; }

		public AttributeGroup Group { get; set; }
	}
}
