using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class WetTrait : GameObjectXTrait, IProgressTrait
	{
		private RubbishSpawner _rubbishSpawner;

		private const string ParticlesDripTransformName = "Particles_Drip";

		[PersistenceOptIn]
		private float _currentWetness;

		[PersistenceOptIn]
		private float _currentDryFactor;

		[PersistenceOptIn]
		private bool _isInside;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _rainIdle_StateSet;

		private bool _inside;

		public float CurrentWetness => 0f;

		public float ProgressPercentage => 0f;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Actor_SleepingStatusChanged(object sender, Actor.ActorEventArgs<bool> e)
		{
		}

		protected WetTrait()
		{
		}

		public WetTrait(GameObjectX owner)
		{
		}

		public override void Init()
		{
		}

		private void SleepingStatusChanged(bool isSleeping)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		private void SetActive()
		{
		}

		private void SetInactive()
		{
		}

		private void SetDripEffectActive(bool active)
		{
		}

		public bool IsWet()
		{
			return false;
		}

		public void IncreaseWetness(float delta)
		{
		}

		private void UpdateWhileOutside()
		{
		}

		private void UpdateWhileInside(TileData tile)
		{
		}

		private void DecreaseWetness(float currentTemperature)
		{
		}

		public override void Update()
		{
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}
	}
}
