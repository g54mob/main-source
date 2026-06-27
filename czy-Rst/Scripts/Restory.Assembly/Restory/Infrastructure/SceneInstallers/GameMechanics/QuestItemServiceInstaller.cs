using Restory.Gameplay.Quests;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class QuestItemServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private QuestItemService questItemServicePrefab;

		public override void InstallBindings()
		{
			InstallQuestItemService();
		}

		private void InstallQuestItemService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(questItemServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<QuestItemService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
