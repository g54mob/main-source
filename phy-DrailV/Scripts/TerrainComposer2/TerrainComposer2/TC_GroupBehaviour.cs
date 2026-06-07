namespace TerrainComposer2
{
	public class TC_GroupBehaviour : TC_ItemBehaviour
	{
		public int firstActive;

		public int lastActive;

		public int totalActive;

		public void Clear(bool undo)
		{
			int num = 0;
			int childCount = t.childCount;
			for (int i = 0; i < childCount; i++)
			{
				TC_ItemBehaviour component = t.GetChild(num).GetComponent<TC_ItemBehaviour>();
				if (component != null)
				{
					component.DestroyMe(undo);
				}
				else
				{
					num++;
				}
			}
		}
	}
}
