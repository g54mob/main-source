using ScheduleOne.EntityFramework;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Persistence.Loaders
{
	public class GridItemLoader : BuildableItemLoader
	{
		public override string ItemType => null;

		public override void Load(string mainPath)
		{
		}

		public override void Load(DynamicSaveData data)
		{
		}

		protected GridItem LoadAndCreate(string mainPath)
		{
			return null;
		}

		protected GridItem LoadAndCreate(GridItemData data)
		{
			return null;
		}
	}
}
