using Services.Enemy;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
	public class EnemyLoyaltyInstaller : MonoInstaller
	{
		[Header("Air Raid Timer")]
		[Tooltip("Even if the player never grinds money, the enemy loyalty/stress meter fills on its own from the start of the game, guaranteeing an air raid (enemy plane) after this many minutes of continuous gameplay. Grinding money fills it faster on top of this.")]
		[Min(0.1f)]
		[SerializeField]
		private float _minutesUntilAirRaid = 120f;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<LoyaltyService>().FromNew().AsSingle()
				.WithArguments(_minutesUntilAirRaid);
		}
	}
}
