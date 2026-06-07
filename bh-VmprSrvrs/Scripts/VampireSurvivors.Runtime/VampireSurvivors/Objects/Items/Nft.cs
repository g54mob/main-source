using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class Nft : NetworkPickup
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

		private void TryAddNduja()
		{
		}
	}
}
