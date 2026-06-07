using System.Collections;
using DV.CabControls;
using DV.HUD;
using DV.KeyboardInput;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class HandcarHandbrakeController : MonoBehaviour
	{
		private const float HANDBRAKE_RELEASE_TIME = 0.1f;

		private bool initialized;

		private TrainCar car;

		private ControlImplBase handbrakeInteractable;

		private MouseScrollKeyboardInput mouseScrollKeyboardInput;

		private InteriorControlsManager interiorControlsManager;

		private IEnumerator Start()
		{
			car = TrainCar.Resolve(base.gameObject);
			mouseScrollKeyboardInput = GetComponent<MouseScrollKeyboardInput>();
			if (mouseScrollKeyboardInput == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find mouseScrollKeyboardInput, HandcarHandbrakeController keyboard input won't work properly!");
			}
			OnInteriorLoadedStateChanged(car.loadedInterior);
			car.InteriorLoaded += OnInteriorLoadedStateChanged;
			yield return null;
			yield return null;
			handbrakeInteractable = GetComponent<ControlImplBase>();
			if (handbrakeInteractable == null)
			{
				Debug.LogError("Unexpected state: handbrakeInteractable not found, HandcarBarController destroying self");
				Object.Destroy(this);
			}
			else
			{
				initialized = true;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && car != null)
			{
				car.InteriorLoaded -= OnInteriorLoadedStateChanged;
				car.brakeSystem.SetHandbrakePosition(0f);
			}
		}

		private void Update()
		{
			if (initialized)
			{
				bool num = handbrakeInteractable.IsGrabbedOrHoverScrolled() || (mouseScrollKeyboardInput != null && mouseScrollKeyboardInput.IsScrollingInProgress) || (interiorControlsManager != null && interiorControlsManager.IsControlScrolledRecently(InteriorControlsManager.ControlType.Handbrake));
				float handbrakePosition = car.brakeSystem.handbrakePosition;
				if (!num && handbrakePosition > 0f)
				{
					car.brakeSystem.SetHandbrakePosition(Mathf.Clamp01(handbrakePosition - Time.deltaTime / 0.1f));
				}
			}
		}

		private void OnInteriorLoadedStateChanged(GameObject interior)
		{
			interiorControlsManager = null;
			if (interior != null)
			{
				interiorControlsManager = interior.GetComponent<InteriorControlsManager>();
				if (!interiorControlsManager)
				{
					Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find interiorControlsManager, HandcarBarController UI input won't work!");
				}
			}
		}
	}
}
