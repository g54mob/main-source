using Restory.Gameplay.GameSettings;
using Restory.Gameplay.PlayerInput.Observers;
using Restory.Remapping;
using Rewired.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class RewiredInstaller : MonoInstaller
	{
		[Header("Input Settings")]
		[SerializeField]
		private GameObject rewiredInputManagerPrefab;

		public override void InstallBindings()
		{
			InstallRewired();
		}

		private void InstallRewired()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(rewiredInputManagerPrefab);
			base.Container.Bind<ActiveControllerTypeManager>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<EventSystem>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<PlayerMouse>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<GUI_RewiredPanelInputModule>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<IInputUserData>().FromInstance(gameObject.GetComponent<RewiredInputUserData>()).AsSingle();
			base.Container.BindInterfacesAndSelfTo<RewiredInitializedObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.BindInterfacesAndSelfTo<RewiredShutDownObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.BindInterfacesAndSelfTo<RewiredControllerConnectedObserver>().AsSingle().CopyIntoAllSubContainers();
			base.Container.BindInterfacesAndSelfTo<RewiredControllerDisconnectedObserver>().AsSingle().CopyIntoAllSubContainers();
		}
	}
}
