using NSEipix;
using NSMedieval.Goap;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Pick Random Siege Weapon")]
	[Description("Pick random siege weapon and get it as IGoapTargetable")]
	public class PickRandomSiegeWeapon : CommanderAIBTActionBase
	{
		public BBParameter<IGoapTargetable> siegeWeapon;

		protected override void OnStart()
		{
			base.OnStart();
			if (base.agent.DeployedSiegeWeapons == null || base.agent.DeployedSiegeWeapons.Count == 0)
			{
				EndAction(success: false);
				return;
			}
			siegeWeapon.SetValue(base.agent.DeployedSiegeWeapons.GetRandom());
			EndAction(success: true);
		}
	}
}
