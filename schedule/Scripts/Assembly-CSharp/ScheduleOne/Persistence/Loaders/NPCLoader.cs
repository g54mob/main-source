using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Persistence.Loaders
{
	public class NPCLoader : DynamicLoader
	{
		public virtual string NPCType => null;

		public override void Load(DynamicSaveData saveData)
		{
		}
	}
}
