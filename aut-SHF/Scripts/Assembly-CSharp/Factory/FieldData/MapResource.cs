using System;

namespace Factory.FieldData
{
	[Serializable]
	public class MapResource
	{
		public string id;

		public int count;

		public MapResource(eLuggage id, int count)
		{
		}

		public (eLuggage, int) Deserialize()
		{
			return default((eLuggage, int));
		}
	}
}
