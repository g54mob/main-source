using UnityEngine;
using VRTK;

public class UpdateCameraDampening : MonoBehaviour
{
	public AnimationCurve matchingCurve;

	private Transform cameraDampeningContainer;

	private Transform currentTarget;

	private GameObject[] debugCubes;

	private void OnEnable()
	{
		OnCarChanged(PlayerManager.Car);
		PlayerManager.CarChanged += OnCarChanged;
		PlayerManager.PlayerTeleportStarted += Cleanup;
		PlayerManager.PlayerTeleportFinished += Reinitialize;
		LocomotionSetup.LocomotionAboutToBeChanged += Cleanup;
		LocomotionSetup.LocomotionChanged += OnLocomotionChanged;
	}

	private void OnDisable()
	{
		PlayerManager.CarChanged -= OnCarChanged;
		PlayerManager.PlayerTeleportStarted -= Cleanup;
		PlayerManager.PlayerTeleportFinished -= Reinitialize;
		LocomotionSetup.LocomotionAboutToBeChanged -= Cleanup;
		LocomotionSetup.LocomotionChanged -= OnLocomotionChanged;
		if (!UnloadWatcher.isUnloading)
		{
			Cleanup();
		}
	}

	private void OnCarChanged(TrainCar car)
	{
		Reinitialize(car);
	}

	private void OnLocomotionChanged(LocomotionType _)
	{
		Reinitialize();
	}

	private void Reinitialize()
	{
		Reinitialize(PlayerManager.Car);
	}

	private void Reinitialize(TrainCar car)
	{
		Cleanup();
		if ((bool)car)
		{
			Setup(car);
		}
	}

	private Transform GetTargetTransform()
	{
		if (VRManager.IsVREnabled())
		{
			bool num = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
			Transform transform = VRTK_DeviceFinder.PlayAreaTransform();
			if (!num)
			{
				return transform;
			}
			return transform.parent;
		}
		return GetComponent<CameraSmoothing>().head;
	}

	public void Cleanup()
	{
		if (!currentTarget)
		{
			return;
		}
		if (currentTarget.parent == cameraDampeningContainer)
		{
			currentTarget.SetParent(cameraDampeningContainer.parent, worldPositionStays: true);
		}
		currentTarget.rotation = Quaternion.Euler(0f, currentTarget.rotation.eulerAngles.y, 0f);
		Object.Destroy(cameraDampeningContainer.gameObject);
		cameraDampeningContainer = null;
		currentTarget = null;
		if (debugCubes != null)
		{
			GameObject[] array = debugCubes;
			for (int i = 0; i < array.Length; i++)
			{
				Object.Destroy(array[i]);
			}
		}
		debugCubes = null;
	}

	private void Setup(TrainCar car)
	{
		if ((bool)currentTarget)
		{
			Debug.LogWarning("Camera dampening is already set up, aborting.", this);
			return;
		}
		currentTarget = GetTargetTransform();
		GameObject gameObject = new GameObject("Camera Dampening container");
		gameObject.SetActive(value: false);
		cameraDampeningContainer = gameObject.transform;
		cameraDampeningContainer.parent = car.interior;
		cameraDampeningContainer.localPosition = new Vector3(0f, 2.5f, 0f);
		cameraDampeningContainer.localRotation = Quaternion.identity;
		bool num = VRManager.IsVREnabled();
		CameraDampening cameraDampening = (num ? gameObject.AddComponent<CameraDampeningConeSampler>() : gameObject.AddComponent<CameraDampening>());
		cameraDampening.cameraGO = PlayerManager.PlayerCamera.gameObject;
		cameraDampening.matchingCurve = matchingCurve;
		if (num)
		{
			((CameraDampeningConeSampler)cameraDampening).sampleLayers = LayerMask.GetMask("Camera_Dampening");
		}
		gameObject.SetActive(value: true);
		currentTarget.SetParent(cameraDampeningContainer, worldPositionStays: true);
		if (WorldStreamingInit.IsLoaded && !cameraDampening.cameraGO.transform.IsChildOf(cameraDampeningContainer))
		{
			Debug.LogError("CameraDampening must be added to a (grand)parent of player camera gameobject", this);
			Cleanup();
		}
	}

	private void Update()
	{
		KillLocalOffset();
	}

	private void KillLocalOffset()
	{
		if ((bool)currentTarget && (cameraDampeningContainer.position - currentTarget.position).sqrMagnitude > 0.09f)
		{
			currentTarget.SetParent(cameraDampeningContainer.parent);
			cameraDampeningContainer.position = currentTarget.position;
			currentTarget.SetParent(cameraDampeningContainer);
		}
	}
}
