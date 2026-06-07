using VampireSurvivors.App.Objects;

namespace VampireSurvivors.Objects.Items
{
	public class TP_CycleGate : PickupTeleporter
	{
		private MapToken _mapToken;

		public void SetGateIndex(int index)
		{
		}

		protected override void GenerateSpritesAndAnims()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnGateIndexChanged(int oldValue, int newValue)
		{
		}
	}
}
