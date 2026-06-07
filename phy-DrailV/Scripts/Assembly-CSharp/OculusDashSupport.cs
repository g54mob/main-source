using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.Utils;
using UnityEngine;
using VRTK;

public class OculusDashSupport : MonoBehaviour
{
	private const bool OCULUS_CONTROLLER_VISIBLE = false;

	public List<VRTK_ControllerReference> controllers = new List<VRTK_ControllerReference>();

	private bool? wasAlreadyPausedViaIngameMenu = false;

	private List<Renderer> previouslyHiddenRenderers;

	private IEnumerator Start()
	{
		SetupListeners(on: true);
		yield return WaitFor.Seconds(2f);
		Toggle();
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			OVRManager.InputFocusAcquired += Toggle;
			OVRManager.InputFocusLost += Toggle;
			OVRManager.HMDMounted += Toggle;
			OVRManager.HMDAcquired += Toggle;
			OVRManager.HMDUnmounted += Toggle;
			OVRManager.HMDLost += Toggle;
		}
		else
		{
			OVRManager.InputFocusAcquired -= Toggle;
			OVRManager.InputFocusLost -= Toggle;
			OVRManager.HMDMounted -= Toggle;
			OVRManager.HMDAcquired -= Toggle;
			OVRManager.HMDUnmounted -= Toggle;
			OVRManager.HMDLost -= Toggle;
		}
	}

	private void Toggle()
	{
		bool gameShouldPlay = OVRManager.hasInputFocus && OVRPlugin.userPresent && OVRManager.isHmdPresent;
		HandleInputFocus(gameShouldPlay);
		HandlePause(gameShouldPlay);
	}

	private void HandlePause(bool gameShouldPlay)
	{
		if (LoadingScreenManager.IsLoading || !WorldStreamingInit.IsLoaded || UnloadWatcher.isUnloading)
		{
			return;
		}
		if (gameShouldPlay)
		{
			if (!wasAlreadyPausedViaIngameMenu.HasValue || !wasAlreadyPausedViaIngameMenu.Value)
			{
				SingletonBehaviour<AppUtil>.Instance.UnpauseGame();
			}
			wasAlreadyPausedViaIngameMenu = null;
		}
		else
		{
			if (!wasAlreadyPausedViaIngameMenu.HasValue)
			{
				wasAlreadyPausedViaIngameMenu = SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen;
			}
			SingletonBehaviour<AppUtil>.Instance.PauseGame();
		}
	}

	private void HandleInputFocus(bool gameShouldPlay)
	{
		if (gameShouldPlay)
		{
			OVRManager.instance.GetComponentInChildren<OvrAvatar>().ShowFirstPerson = false;
			if (previouslyHiddenRenderers != null)
			{
				foreach (Renderer previouslyHiddenRenderer in previouslyHiddenRenderers)
				{
					if (previouslyHiddenRenderer != null)
					{
						previouslyHiddenRenderer.enabled = true;
					}
				}
			}
			previouslyHiddenRenderers = null;
			return;
		}
		OVRManager.instance.GetComponentInChildren<OvrAvatar>().ShowFirstPerson = false;
		if (previouslyHiddenRenderers != null)
		{
			return;
		}
		previouslyHiddenRenderers = new List<Renderer>();
		previouslyHiddenRenderers.AddRange(controllers.SelectMany((VRTK_ControllerReference c) => from r in c.model.GetComponentsInChildren<Renderer>(includeInactive: true)
			where r.enabled
			select r));
		previouslyHiddenRenderers.AddRange(controllers.SelectMany((VRTK_ControllerReference c) => from r in c.scriptAlias.GetComponentsInChildren<Renderer>(includeInactive: true)
			where r.enabled
			select r));
		foreach (Renderer previouslyHiddenRenderer2 in previouslyHiddenRenderers)
		{
			if (previouslyHiddenRenderer2 != null)
			{
				previouslyHiddenRenderer2.enabled = false;
			}
		}
	}
}
