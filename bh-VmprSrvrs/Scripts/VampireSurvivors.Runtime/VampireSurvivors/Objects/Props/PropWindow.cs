using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Objects.Props
{
	public class PropWindow : Destructible
	{
		private Stage _stage;

		private bool _hasFired;

		[Inject]
		private void Construct(Stage stage)
		{
		}

		public override void Init(PropType destructibleType)
		{
		}

		protected override void OnDestroyed()
		{
		}
	}
}
