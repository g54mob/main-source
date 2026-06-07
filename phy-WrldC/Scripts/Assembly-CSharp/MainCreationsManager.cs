using System;
using System.Collections;
using UnityEngine;

public class MainCreationsManager
{
	private bool isAttackerCreationReady;

	private bool isDefenderCreationReady;

	private bool shouldRestoresLastCameraPosition;

	private bool shouldRestoresWorldPosition;

	public CreationController MainCreationController { get; set; }

	public CreationController AttackerCreationController { get; private set; }

	public CreationController DefenderCreationController { get; private set; }

	public bool IsCreationsLoaded
	{
		get
		{
			if (isAttackerCreationReady)
			{
				return isDefenderCreationReady;
			}
			return false;
		}
	}

	public event Action OnCreationsLoadingStarted;

	public event Action OnCreationsLoadingCompleted;

	public MainCreationsManager(GameManager GAME)
	{
		AttackerCreationController = CreationControllerBuilder.BuildRigidController(new CreationModel("", "", ""));
		DefenderCreationController = CreationControllerBuilder.BuildRigidController(new CreationModel("", "", ""));
		AttackerCreationController.view.transform.SetParent(GAME.attackerCreationFolder.transform, worldPositionStays: false);
		DefenderCreationController.view.transform.SetParent(GAME.defenderCreationFolder.transform, worldPositionStays: false);
		AttackerCreationController.view.CreationRole = CreationView.CreationRoleState.Attacker;
		DefenderCreationController.view.CreationRole = CreationView.CreationRoleState.Defender;
		isAttackerCreationReady = true;
		isDefenderCreationReady = true;
		shouldRestoresLastCameraPosition = false;
		AttackerCreationController.IsAsyncBuild = true;
		DefenderCreationController.IsAsyncBuild = true;
		AttackerCreationController.OnSyncViewWithModelStarted += delegate
		{
			if (this.OnCreationsLoadingStarted != null)
			{
				this.OnCreationsLoadingStarted();
			}
			isAttackerCreationReady = false;
			CreationBuildingStartedHandler(AttackerCreationController);
		};
		AttackerCreationController.OnSyncViewWithModelCompleted += delegate
		{
			CreationBuildingCompletedHandler(AttackerCreationController);
			isAttackerCreationReady = true;
			if (this.OnCreationsLoadingCompleted != null)
			{
				this.OnCreationsLoadingCompleted();
			}
		};
		DefenderCreationController.OnSyncViewWithModelStarted += delegate
		{
			isDefenderCreationReady = false;
			CreationBuildingStartedHandler(DefenderCreationController);
		};
		DefenderCreationController.OnSyncViewWithModelCompleted += delegate
		{
			isDefenderCreationReady = true;
			CreationBuildingCompletedHandler(DefenderCreationController);
		};
	}

	private void CreationBuildingStartedHandler(CreationController creationController)
	{
		if (shouldRestoresLastCameraPosition && creationController == MainCreationController)
		{
			if (shouldRestoresWorldPosition)
			{
				GameManager.Instance.CameraManager.RestoresLastMainCameraPosition();
			}
			else
			{
				GameManager.Instance.CameraManager.OrbitCamera.SetTargetPosition(LevelManager.Instance.SelectedZone.transform.position);
			}
		}
	}

	private void CreationBuildingCompletedHandler(CreationController creationController)
	{
		if (shouldRestoresLastCameraPosition && creationController == MainCreationController)
		{
			GameManager.Instance.CameraManager.RestoresMainCameraStatus(MainCreationController.view, shouldRestoreLastPosition: false);
			shouldRestoresLastCameraPosition = false;
		}
	}

	public void RestoreLastCameraPositionForNextBuilding(bool shouldRestoresWorldPosition)
	{
		shouldRestoresLastCameraPosition = true;
		this.shouldRestoresWorldPosition = shouldRestoresWorldPosition;
	}

	public void RestoreLastCameraPositionWhenBuilt()
	{
		GameManager.Instance.StartCoroutine(CheckAndRestore());
		IEnumerator CheckAndRestore()
		{
			while (!IsCreationsLoaded)
			{
				yield return new WaitForEndOfFrame();
			}
			GameManager.Instance.CameraManager.RestoresMainCameraStatus(MainCreationController.view, shouldRestoreLastPosition: false);
		}
	}
}
