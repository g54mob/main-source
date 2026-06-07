using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_John_Character : TP_Character
	{
		private bool _arcanaAdded;

		private Timer _sequentialTimer;

		private int _sequentialSpawn;

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		private void SpawnSingle(float x, float y, ItemType itemType, float delay)
		{
		}
	}
}
