using System.Collections.Generic;

namespace GRP
{
	public class UndoSnapshot
	{
		public Project project;

		public SelectorData selector;

		public HubData hub;

		public ProjectSettingsData settings;

		public Dictionary<Id, Part> parts;

		public Dictionary<Id, EntityData> partsData;

		public int[] orders;

		public void RecordHub()
		{
		}

		public void RecordSettings()
		{
		}

		public void RecordPart(Part part)
		{
		}

		public void CalculateOrders()
		{
		}

		public void RecordParts(params Part[] items)
		{
		}
	}
}
