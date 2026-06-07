namespace ModApi.Craft.Parts.Attributes
{
	public abstract class DesignerPropertyAttribute : PartModifierPropertyAttribute
	{
		public string Header { get; set; }

		public bool HeaderCollapsed { get; set; }

		public bool IsHidden { get; set; }

		public string Label { get; set; }

		public int Order { get; set; }

		public string Tooltip { get; set; }

		public DesignerPropertyAttribute()
		{
			Order = 100;
		}
	}
}
