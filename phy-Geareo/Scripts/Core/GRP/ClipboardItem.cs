using UnityEngine;

namespace GRP
{
	public class ClipboardItem
	{
		public string id;

		public EntityData[] partsData;

		public Quaternion camRotation;

		public Texture2D thumbnail;

		public bool CompareContent(ClipboardItem other)
		{
			return false;
		}

		public ClipboardItemData Serialize()
		{
			return null;
		}

		public void Deserialize(ClipboardItemData data)
		{
		}
	}
}
