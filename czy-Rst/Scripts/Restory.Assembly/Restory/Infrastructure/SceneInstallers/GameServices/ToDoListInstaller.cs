using Restory.Gameplay.ToDoList;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public sealed class ToDoListInstaller : MonoInstaller
	{
		[SerializeField]
		private ToDoListService toDoListService;

		public override void InstallBindings()
		{
			base.Container.Bind<ToDoItemHandlerFactory>().FromNew().AsSingle()
				.WhenInjectedInto<ToDoListService>();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(toDoListService.gameObject);
			base.Container.BindInterfacesAndSelfTo<ToDoListService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
