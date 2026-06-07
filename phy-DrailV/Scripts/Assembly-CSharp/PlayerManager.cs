using System;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class PlayerManager
{
	private static Camera _playerCameraOverride;

	private static bool unloadRegistered;

	public static Transform PlayerTransform { get; private set; }

	public static Camera PlayerCameraOverride
	{
		get
		{
			return _playerCameraOverride;
		}
		set
		{
			Camera activeCamera = ActiveCamera;
			_playerCameraOverride = value;
			if (ActiveCamera != activeCamera)
			{
				PlayerManager.CameraChanged?.Invoke();
			}
		}
	}

	public static Camera PlayerCamera { get; private set; }

	public static Camera ActiveCamera
	{
		get
		{
			if (!PlayerCameraOverride)
			{
				return PlayerCamera;
			}
			return PlayerCameraOverride;
		}
	}

	public static TrainCar Car { get; private set; }

	public static TrainCar LastLoco { get; private set; }

	public static event Action<TrainCar> CarChanged;

	public static event Action PlayerChanged;

	public static event Action CameraChanged;

	public static event Action PlayerTeleportStarted;

	public static event Action PlayerTeleportFinished;

	public static void SetPlayer(Transform player, Camera camera)
	{
		if (player == PlayerTransform && camera == PlayerCamera)
		{
			return;
		}
		Transform playerTransform = PlayerTransform;
		Camera activeCamera = ActiveCamera;
		PlayerTransform = player;
		if (player == null)
		{
			PlayerCamera = null;
		}
		else
		{
			PlayerCamera = camera;
			if (camera == null)
			{
				Debug.LogError("PlayerManager got non-null player along with null camera", player);
			}
		}
		if (PlayerTransform != playerTransform)
		{
			PlayerManager.PlayerChanged?.Invoke();
		}
		if (ActiveCamera != activeCamera)
		{
			PlayerManager.CameraChanged?.Invoke();
		}
		if (!unloadRegistered)
		{
			unloadRegistered = true;
			UnloadWatcher.UnloadRequested += UnloadHandler;
		}
	}

	private static void UnloadHandler()
	{
		UnloadWatcher.UnloadRequested -= UnloadHandler;
		PlayerManager.CarChanged = null;
		PlayerManager.PlayerChanged = null;
		PlayerManager.PlayerTeleportStarted = null;
		PlayerManager.PlayerTeleportFinished = null;
		PlayerCameraOverride = null;
		Car = null;
		LastLoco = null;
	}

	public static void SetCar(TrainCar newCar)
	{
		if (Car != newCar)
		{
			if ((bool)Car)
			{
				Debug.Log("Player exiting car '" + Car.name + "'", Car);
			}
			if ((bool)newCar)
			{
				Debug.Log($"Player entering car '{newCar}'", newCar);
			}
			Car = newCar;
			if (Car != null && Car.IsLoco)
			{
				LastLoco = Car;
				Debug.Log($"Setting '{Car}' as Player's last loco.", Car);
			}
			PlayerManager.CarChanged?.Invoke(newCar);
		}
	}

	public static void TeleportPlayer(Vector3 position, Quaternion rotation, Transform target, bool useRotation, bool playFootstepSound = false)
	{
		if (PlayerTransform == null)
		{
			Debug.LogError("Cannot teleport player, player transform is null");
			return;
		}
		if (!SingletonBehaviour<APlayerTeleport>.Instance)
		{
			Debug.LogError("Cannot teleport player, no APlayerTeleport instance could be found");
			return;
		}
		PlayerManager.PlayerTeleportStarted?.Invoke();
		SingletonBehaviour<APlayerTeleport>.Instance.TeleportPlayer(position, rotation, target, useRotation, playFootstepSound);
		PlayerManager.PlayerTeleportFinished?.Invoke();
	}

	public static void TeleportPlayerToCar(TrainCar car)
	{
		CabTeleportDestination cabTeleportDestination = car.cabTeleportDestination;
		if ((bool)cabTeleportDestination)
		{
			(Vector3, Quaternion) teleportPose = cabTeleportDestination.GetTeleportPose();
			TeleportPlayer(teleportPose.Item1, teleportPose.Item2, car.interior, useRotation: true);
			return;
		}
		Transform transform = car.interior.Find("[cab]");
		if ((bool)transform)
		{
			TeleportPlayer(transform.position, transform.rotation, car.interior, useRotation: true);
			return;
		}
		if (car.LoadedCargo != CargoType.None && car.CargoModelController.GetCurrentCargoModelBounds().IsSome(out var value) && Physics.SphereCast(value.center + Vector3.up * (value.extents.y + 0.5f), 0.5f, Vector3.down, out var hitInfo, value.extents.y * 2f, LayerMask.GetMask("Train_Walkable")))
		{
			TeleportPlayer(hitInfo.point, car.transform.rotation, car.interior, useRotation: true);
			return;
		}
		Bounds bounds = car.Bounds;
		Transform transform2 = car.transform;
		TeleportPlayer(transform2.TransformPoint(bounds.center + Vector3.up * bounds.extents.y), transform2.rotation, car.interior, useRotation: true);
	}

	public static bool IsPlayerPositionValid(Vector3 playerPosition)
	{
		float num = -0.5f;
		float num2 = LevelInfo.WorldSize.x + 0.5f;
		float num3 = LevelInfo.WorldSize.z + 0.5f;
		float num4 = 0f - LevelInfo.WaterLevel;
		float y = LevelInfo.WorldSize.y;
		return !(playerPosition.x > num2) && !(playerPosition.x < num) && !(playerPosition.z > num3) && !(playerPosition.z < num) && !(playerPosition.y > y) && !(playerPosition.y < num4);
	}

	public static bool IsCameraWithinRangeOf(Vector3 point, float rangeSqr)
	{
		return Vector3.SqrMagnitude(ActiveCamera.transform.position - point) < rangeSqr;
	}
}
