namespace Assets.Scripts.Design.PartProperties.Attributes
{
	public abstract class DesignerPropertyAttribute : PartModifierPropertyAttribute
	{
		public string Header { get; set; }

		public bool HeaderCollapsed { get; set; }

		public string Label { get; set; }

		public int Order { get; set; }

		public bool SupportsLists { get; set; } = true;

		public string Tooltip { get; set; }

		public DesignerPropertyAttribute()
			: base(preserveState: true)
		{
			Order = 100;
		}
	}
}
