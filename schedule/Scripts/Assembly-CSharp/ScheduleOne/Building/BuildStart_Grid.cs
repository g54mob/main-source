using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.Building
{
	public class BuildStart_Grid : BuildStart_Base
	{
		protected GridItem ghostModelClass;

		public override void StartBuilding(ItemInstance itemInstance)
		{
		}

		protected virtual string GetInputPromptsModuleName()
		{
			return null;
		}

		protected virtual GridItem CreateGhostModel(BuildableItemDefinition itemDefinition)
		{
			return null;
		}
	}
}
