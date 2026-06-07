using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class FB_Simondo : CharacterController_FirstBlood
	{
		private float _spawnPickupsDelay;

		private float _spawnPickupsTime;

		private Timer _activationTimer;

		private List<ItemType> _pickupTypes;

		private PhaserSprite _highlight;

		public override void AfterFullInitialization()
		{
		}

		public float SpawnPickupsInterval()
		{
			return 0f;
		}

		protected override void OnUpdate()
		{
		}

		private void CriticalHP()
		{
		}

		private void SpawnPickups(int extra = 0)
		{
		}

		private void SpawnSingle(float x, float y, ItemType itemType, float delay)
		{
		}

		[Command]
		public void ShowHighlightOnline(float x, float y, float delay)
		{
		}

		private void ShowHighlight(float x, float y, float detune)
		{
		}
	}
}
