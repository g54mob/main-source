using Player;
using Player.FSM;
using UI.HUD;
using UI.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ObjectsInstaller : MonoInstaller, IInitializable
{
	[SerializeField]
	private PlayerBehaviour _playerBehaviour;

	[SerializeField]
	private InventoryUIService _inventoryUIService;

	[SerializeField]
	private PlayerHUDView _HUDView;

	public override void InstallBindings()
	{
		BindPlayer();
		BindInventoryUIObject();
		BindHUD();
		base.Container.BindInterfacesAndSelfTo<ObjectsInstaller>().FromInstance(this).AsSingle();
	}

	private void BindHUD()
	{
		base.Container.BindInterfacesAndSelfTo<PlayerHUDView>().FromComponentInNewPrefab(_HUDView).AsSingle();
	}

	private void BindInventoryUIObject()
	{
		base.Container.BindInterfacesAndSelfTo<InventoryUIService>().FromComponentInNewPrefab(_inventoryUIService).AsSingle();
	}

	private void BindPlayer()
	{
		base.Container.Bind<IPlayerStateMachineParametersManipulator>().To<PlayerBehaviourStateMachine>().FromComponentInNewPrefab(_playerBehaviour)
			.AsSingle();
		base.Container.Bind<IPlayerToolView>().To<PlayerToolView>().FromComponentInHierarchy()
			.AsSingle();
	}

	public void Initialize()
	{
		CharacterController component = (base.Container.Resolve<IPlayerStateMachineParametersManipulator>() as MonoBehaviour).transform.parent.GetComponent<CharacterController>();
		Debug.Log("Player " + component);
		PlayerSpawnPoint playerSpawnPoint = Object.FindAnyObjectByType<PlayerSpawnPoint>();
		Debug.Log("Spawn point " + playerSpawnPoint.transform.position.ToString());
		if (playerSpawnPoint != null)
		{
			component.enabled = false;
			Debug.Log("Player spawned at " + playerSpawnPoint.transform.position.ToString());
			component.transform.position = playerSpawnPoint.transform.position;
			component.transform.rotation = playerSpawnPoint.transform.rotation;
		}
		component.enabled = true;
	}

	public void Dispose()
	{
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	}
}
