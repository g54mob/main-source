using Loxodon.Framework.Contexts;
using Loxodon.Framework.Services;
using Player.Animations;
using Player.Arms;
using Player.FSM;
using UnityEngine;
using Zenject;

namespace Player.Installers
{
	public class PlayerInstaller : MonoInstaller
	{
		[SerializeField]
		private PlayerBehaviourStateMachine _playerFSM;

		[SerializeField]
		private ArmsAnimator _armsAnimator;

		public override void InstallBindings()
		{
			base.Container.Bind<IPlayerStateMachineParametersManipulator>().To<PlayerBehaviourStateMachine>().FromInstance(_playerFSM)
				.AsSingle();
			ApplicationContext applicationContext = Loxodon.Framework.Contexts.Context.GetApplicationContext();
			IServiceContainer container = applicationContext.GetContainer();
			if (!applicationContext.Contains("PlayerArmsViewModel"))
			{
				container.Register(new PlayerArmsViewModel());
			}
			container.Register(_armsAnimator);
		}

		private void OnDestroy()
		{
			IServiceContainer container = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetContainer();
			container.Unregister<PlayerArmsViewModel>();
			container.Unregister<ArmsAnimator>();
		}
	}
}
