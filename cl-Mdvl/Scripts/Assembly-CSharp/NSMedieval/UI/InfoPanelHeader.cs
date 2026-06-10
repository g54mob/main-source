namespace NSMedieval.UI
{
	public class InfoPanelHeader
	{
		private string objectId;

		private string objectName;

		private string objectType;

		public string ObjectId => objectId;

		public string ObjectName => objectName;

		public string ObjectType => objectType;

		public InfoPanelHeader(string id, string name, string objectType)
		{
			objectId = id;
			objectName = name;
			this.objectType = objectType;
		}
	}
}
