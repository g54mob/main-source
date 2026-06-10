using NSEipix.Model;

namespace NSMedieval.UI
{
	public class InfoPanelResource
	{
		private string id;

		private string resourceType;

		private string resourceValue;

		private IntRange resourceValues;

		public string Id => id;

		public string ResourceType => resourceType;

		public IntRange ResourceValues => resourceValues;

		public string ResourceValue => resourceValue;

		public InfoPanelResource(string id, string resourceType, IntRange resourceValues)
		{
			this.id = id;
			this.resourceType = resourceType;
			this.resourceValues = resourceValues;
		}

		public InfoPanelResource(string id, string resourceType, string resourceValue)
		{
			this.id = id;
			this.resourceType = resourceType;
			this.resourceValue = resourceValue;
		}
	}
}
