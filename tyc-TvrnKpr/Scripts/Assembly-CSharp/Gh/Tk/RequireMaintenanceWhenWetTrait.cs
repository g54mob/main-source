using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class RequireMaintenanceWhenWetTrait : GameObjectXTrait
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnAIComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		protected RequireMaintenanceWhenWetTrait()
		{
		}

		public RequireMaintenanceWhenWetTrait(Prop owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
