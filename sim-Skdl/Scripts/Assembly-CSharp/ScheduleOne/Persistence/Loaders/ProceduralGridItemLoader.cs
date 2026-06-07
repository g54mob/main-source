using ScheduleOne.EntityFramework;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Persistence.Loaders
{
	public class ProceduralGridItemLoader : BuildableItemLoader
	{
		public override string ItemType => null;

		public override int LoadOrder => 0;

		public override void Load(string mainPath)
		{
		}

		public override void Load(DynamicSaveData data)
		{
		}

		protected ProceduralGridItem LoadAndCreate(string mainPath)
		{
			return null;
		}

		protected ProceduralGridItem LoadAndCreate(ProceduralGridItemData data)
		{
			return null;
		}
	}
}
