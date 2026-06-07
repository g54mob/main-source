using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_ItemsTest_Character : TP_Character
	{
		private Timer _sequentialTimer;

		private int _sequentialSpawn;

		private List<ItemType> _pickupTypes;

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		private void SpawnPickups(int extra = 0)
		{
		}

		private void SpawnSingle(float x, float y, ItemType itemType, float delay)
		{
		}
	}
}
