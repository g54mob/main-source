using Unity.Entities;

namespace Kitchen
{
	public class ManageCostumeIndicators : PlayerSpecificUIIndicator<CCosmeticSelector, CCostumeChangeInfo>
	{
		protected override ViewType ViewType => ViewType.CostumeChangeInfo;

		protected override CCostumeChangeInfo GetInfo(Entity source, CCosmeticSelector selector, CTriggerPlayerSpecificUI trigger, CPlayer player)
		{
			return new CCostumeChangeInfo
			{
				CurrentCostume = 1,
				Player = player,
				PlayerEntity = trigger.TriggerEntity
			};
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
