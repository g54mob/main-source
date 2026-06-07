using System;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using Unity.Linq;
using UnityEngine;
using VRTK;

public class LoadingScreenManager : SingletonBehaviour<LoadingScreenManager>
{
	private VrLoading vrLoading;

	private GameObject nonVrLoading;

	private Coroutine TerminationCoroutine;

	private Interpolator volumeFade;

	private List<GameObject> turnedOffControllers = new List<GameObject>();

	private List<VRTK_InteractableObject> undroppableItems = new List<VRTK_InteractableObject>();

	public static bool IsLoading { get; private set; }

	public event Action LoadingStateChanged;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		IsLoading = false;
	}

	public new static string AllowAutoCreate()
	{
		return "[LoadingScreenManager]";
	}

	protected override void Awake()
	{
		base.Awake();
		volumeFade = base.gameObject.AddComponent<Interpolator>();
	}

	public void StartLoading(bool finishOnStableFps = false, bool gameLoading = false)
	{
		if (IsLoading)
		{
			FinishLoading(instantly: true);
		}
		IsLoading = true;
		this.LoadingStateChanged?.Invoke();
		volumeFade.Interpolate(AudioListener.volume, 0f, 0.5f, delegate(float volume)
		{
			AudioListener.volume = volume;
		});
		if (VRManager.IsVREnabled())
		{
			StartVrLoading(gameLoading);
		}
		if (!gameLoading)
		{
			if (!VRManager.IsVREnabled())
			{
				SingletonBehaviour<ScreenspaceMouse>.Instance.RequestOverride(this, on: false, 1);
			}
			nonVrLoading = UnityEngine.Object.Instantiate(Resources.Load("[NonVrLoading]") as GameObject);
			nonVrLoading.GetComponentInChildren<Camera>().enabled = true;
		}
		if (finishOnStableFps)
		{
			SingletonBehaviour<FpsStabilityMeasurer>.Instance.WaitForStableFps(delegate
			{
				FinishLoading();
			});
		}
	}

	private void StartVrLoading(bool progressBar)
	{
		if (SteamVR.instance == null)
		{
			Debug.Log("No SteamVR running, not showing VR loading screen");
			return;
		}
		if (vrLoading != null)
		{
			Debug.LogError("Attempted StartVrLoading while one is already active! Destroying current one!");
			UnityEngine.Object.Destroy(vrLoading);
		}
		vrLoading = UnityEngine.Object.Instantiate(Resources.Load("[VrLoading]") as GameObject).GetComponent<VrLoading>();
		if (!progressBar)
		{
			vrLoading.progressBarFull = null;
			vrLoading.progressBarEmpty = null;
		}
		PreventItemDropping();
		DeactivateFreeControllers();
		ToggleControllerPipa(enabled: false);
	}

	public void UpdateProgress(float progress)
	{
		if ((bool)vrLoading)
		{
			vrLoading.progress = progress;
		}
	}

	public void FinishLoading(bool instantly = false)
	{
		if (VRManager.IsVREnabled())
		{
			if ((bool)vrLoading)
			{
				vrLoading.progress = 1f;
			}
			ToggleControllerPipa(enabled: true);
			foreach (GameObject turnedOffController in turnedOffControllers)
			{
				turnedOffController.SetActive(value: true);
			}
			turnedOffControllers.Clear();
			foreach (VRTK_InteractableObject undroppableItem in undroppableItems)
			{
				undroppableItem.validDrop = VRTK_InteractableObject.ValidDropTypes.DropAnywhere;
			}
			undroppableItems.Clear();
		}
		if ((bool)nonVrLoading)
		{
			UnityEngine.Object.Destroy(nonVrLoading);
			SingletonBehaviour<ScreenspaceMouse>.Instance.RemoveRequest(this);
		}
		float targetVolumeForCurrentPreferenceValue = AudioManager.GetTargetVolumeForCurrentPreferenceValue();
		if (instantly)
		{
			AudioListener.volume = targetVolumeForCurrentPreferenceValue;
		}
		else
		{
			volumeFade.Interpolate(AudioListener.volume, targetVolumeForCurrentPreferenceValue, 0.5f, delegate(float volume)
			{
				AudioListener.volume = volume;
			});
		}
		IsLoading = false;
		this.LoadingStateChanged?.Invoke();
		if ((bool)SingletonBehaviour<GraphicsOptions>.Instance)
		{
			SingletonBehaviour<GraphicsOptions>.Instance.UpdateBackgroundSetting();
		}
	}

	private void DeactivateFreeControllers()
	{
		(from t in new List<SDK_BaseController.ControllerHand>
			{
				SDK_BaseController.ControllerHand.Left,
				SDK_BaseController.ControllerHand.Right
			}.Select(VRTK_ControllerReference.GetControllerReference)
			where t.scriptAlias != null
			where t.scriptAlias.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() == null
			select t.scriptAlias.Parent()).ToList().ForEach(delegate(GameObject t)
		{
			turnedOffControllers.Add(t);
			t.SetActive(value: false);
		});
	}

	private void PreventItemDropping()
	{
		(from t in new List<SDK_BaseController.ControllerHand>
			{
				SDK_BaseController.ControllerHand.Left,
				SDK_BaseController.ControllerHand.Right
			}.Select(VRTK_ControllerReference.GetControllerReference)
			where t.scriptAlias != null
			select t.scriptAlias.GetComponent<VRTK_InteractGrab>().GetGrabbedObject() into t
			where t != null
			select t.GetComponent<VRTK_InteractableObject>()).ToList().ForEach(delegate(VRTK_InteractableObject t)
		{
			undroppableItems.Add(t);
			t.validDrop = VRTK_InteractableObject.ValidDropTypes.NoDrop;
		});
	}

	private void ToggleControllerPipa(bool enabled)
	{
		(from t in new List<SDK_BaseController.ControllerHand>
			{
				SDK_BaseController.ControllerHand.Left,
				SDK_BaseController.ControllerHand.Right
			}.Select(VRTK_ControllerReference.GetControllerReference)
			where t.scriptAlias != null
			select t.scriptAlias.GetComponentInChildren<ControllerPipa>() into t
			where t != null
			select t).ToList().ForEach(delegate(ControllerPipa t)
		{
			t.enabled = enabled;
		});
	}
}
