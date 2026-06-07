using JetBrains.Annotations;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class BackgroundRash : BackgroundManager
	{
		private bool _canShowPizzas;

		private bool _pizzaTriggered;

		private bool _arePizzasVisible;

		private MultiTargetTween _pizzaTween;

		private object[] _pizzaSprites;

		private Blitter _blitter;

		private bool _spawnAtlasRelic;

		public override void Create()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void ShowPizzas()
		{
		}

		private void HidePizzas()
		{
		}

		private void CheckPizzas(CharacterController character)
		{
		}

		private void MakeBlitters()
		{
		}

		private void UpdateBlitter()
		{
		}
	}
}
