namespace NSMedieval.UI
{
	public class InfoEquipmentStat
	{
		private string statName;

		private string imageName;

		private string statValue;

		private string tooltip;

		public string ImageName => imageName;

		public string StatName => statName;

		public string StatValue => statValue;

		public string Tooltip => tooltip;

		public InfoEquipmentStat(string statName, string imageName, string statValue, string tooltip)
		{
			this.statName = statName;
			this.imageName = imageName;
			this.statValue = statValue;
			this.tooltip = tooltip;
		}
	}
}
