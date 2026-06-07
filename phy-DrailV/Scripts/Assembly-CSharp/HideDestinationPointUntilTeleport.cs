using System.Collections;
using UnityEngine;
using VRTK;

public class HideDestinationPointUntilTeleport : MonoBehaviour
{
	private const string PROP_POSITION = "_ReferenceWorldPosition";

	private const string PROP_ENABLED = "_Enabled";

	public Material material;

	private int pid_Position;

	private int pid_Enabled;

	private int counter;

	private IEnumerator Start()
	{
		if (material == null || !material.HasProperty("_ReferenceWorldPosition") || !material.HasProperty("_Enabled"))
		{
			Debug.LogError("HideDestinationPointUntilTeleport has null or wrong material assigned, will not work", base.gameObject);
			yield break;
		}
		pid_Position = Shader.PropertyToID("_ReferenceWorldPosition");
		pid_Enabled = Shader.PropertyToID("_Enabled");
		yield return WaitFor.SecondsRealtime(0.5f);
		SetupListeners(on: true);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		GameObject[] array = new GameObject[2]
		{
			VRTK_DeviceFinder.GetControllerLeftHand(),
			VRTK_DeviceFinder.GetControllerRightHand()
		};
		foreach (GameObject gameObject in array)
		{
			if (!gameObject)
			{
				continue;
			}
			VRTK_Pointer[] componentsInChildren = gameObject.GetComponentsInChildren<VRTK_Pointer>(includeInactive: true);
			foreach (VRTK_Pointer vRTK_Pointer in componentsInChildren)
			{
				if (on)
				{
					vRTK_Pointer.ActivationButtonPressed += OnTeleportingStart;
					vRTK_Pointer.ActivationButtonReleased += OnTeleportingEnd;
				}
				else
				{
					vRTK_Pointer.ActivationButtonPressed -= OnTeleportingStart;
					vRTK_Pointer.ActivationButtonReleased -= OnTeleportingEnd;
				}
			}
		}
	}

	private void OnTeleportingStart(object sender, ControllerInteractionEventArgs e)
	{
		counter = Mathf.Clamp(counter + 1, 0, 2);
		UpdateVisibility();
	}

	private void OnTeleportingEnd(object sender, ControllerInteractionEventArgs e)
	{
		counter = Mathf.Clamp(counter - 1, 0, 2);
		UpdateVisibility();
	}

	private void UpdateVisibility()
	{
		if (PlayerManager.PlayerTransform == null)
		{
			Debug.LogWarning("HideDestinationPointUntilTeleport couldn't find player position", base.gameObject);
		}
		bool flag = counter != 0;
		material.SetInt(pid_Enabled, flag ? 1 : 0);
		if (flag)
		{
			material.SetVector(pid_Position, PlayerManager.PlayerTransform.position);
		}
	}
}
