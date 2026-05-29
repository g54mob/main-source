using ScheduleOne.EntityFramework;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Persistence.Loaders
{
	public class SurfaceItemLoader : BuildableItemLoader
	{
		public override string ItemType => null;

		public override void Load(string mainPath)
		{
		}

		public override void Load(DynamicSaveData data)
		{
		}

		protected SurfaceItem LoadAndCreate(string mainPath)
		{
			return null;
		}

		protected SurfaceItem LoadAndCreate(SurfaceItemData data)
		{
			return null;
		}
	}
}
