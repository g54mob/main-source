using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class Pickup_Sorbetto : Pickup
	{
		[Inject]
		private void Construct(GameSessionData gameSessionData)
		{
		}

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		private void OnRecycle()
		{
		}

		public override void GetTaken()
		{
		}

		private void TryAddSorbetto()
		{
		}
	}
}
