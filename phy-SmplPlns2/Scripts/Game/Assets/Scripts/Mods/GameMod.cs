using Assets.Scripts.Craft;

namespace Assets.Scripts.Mods
{
	public abstract class GameMod : GameModBase
	{
		public virtual bool IsModRequiredForCraft(AircraftData craft)
		{
			return false;
		}
	}
}
