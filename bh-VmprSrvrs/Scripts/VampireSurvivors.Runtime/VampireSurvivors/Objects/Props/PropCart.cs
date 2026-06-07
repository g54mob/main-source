using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using Zenject;

namespace VampireSurvivors.Objects.Props
{
	public class PropCart : Destructible
	{
		private WeaponsFacade _weaponsFacade;

		private bool _hasFired;

		private static Timer _timerEvent;

		[Inject]
		private void Construct(WeaponsFacade weaponsFacade)
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
