using Dhs5.Utility.Updates;
using Simulator.GameWorld;

namespace Simulator
{
	public class SimulatorUpdaterOverrider : TransientManager<SimulatorUpdaterOverrider>, IUpdaterOverrider
	{
		protected override void OnMenuEvent(EMenuEvent menuEvent)
		{
			base.OnMenuEvent(menuEvent);
			if (menuEvent == EMenuEvent.MENU_REGISTRATION)
			{
				Updater.Overrider = this;
			}
		}

		public virtual bool OverrideConditionFulfillment(EUpdateCondition condition, out bool fulfilled)
		{
			switch (condition)
			{
			case EUpdateCondition.ALWAYS:
				fulfilled = true;
				return true;
			case EUpdateCondition.GAME_PLAYING:
				fulfilled = World.Playing;
				return true;
			case EUpdateCondition.GAME_PAUSED:
				fulfilled = World.Loaded && !World.Playing;
				return true;
			case EUpdateCondition.GAME_OVER:
				fulfilled = !World.Loaded;
				return true;
			case EUpdateCondition.CUSTOM1:
				fulfilled = TransientManager<InputManager>.Instance.CurrentMap == InputManager.EMap.PLAYER;
				return true;
			default:
				fulfilled = false;
				return false;
			}
		}
	}
}
