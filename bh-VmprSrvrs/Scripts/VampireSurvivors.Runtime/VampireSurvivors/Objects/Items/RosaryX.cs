using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class RosaryX : Rosary
	{
		private Stage _stage;

		[Inject]
		private void Construct(Stage stage)
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		protected override void OnRecycle()
		{
		}

		public override void GetTaken()
		{
		}
	}
}
