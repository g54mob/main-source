using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class PickupGoldenEgg : NetworkPickup
	{
		private EggManager _eggManager;

		[Sync]
		public uint Seed { get; set; }

		[Inject]
		private void Construct(EggManager eggManager)
		{
		}

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetTaken()
		{
		}

		private void SpawnCursor()
		{
		}

		private void RemoveCursor()
		{
		}

		protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
		{
		}
	}
}
