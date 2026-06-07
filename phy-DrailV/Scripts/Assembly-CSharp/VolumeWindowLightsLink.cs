using System.Collections;
using DV.Utils;
using UnityEngine;

public class VolumeWindowLightsLink : MonoBehaviour
{
	private CookeryLightVolumeRenderer lightVolume;

	private WindowsLightEvent windowsEvent;

	private void Awake()
	{
		lightVolume = GetComponent<CookeryLightVolumeRenderer>();
		if (!lightVolume)
		{
			Debug.LogError($"{typeof(VolumeWindowLightsLink)} component can't work without a {typeof(CookeryLightVolumeRenderer)} on the same object, destroying self.");
			Object.Destroy(this);
		}
		else
		{
			StartCoroutine(GetWindowsEvent());
		}
	}

	private IEnumerator GetWindowsEvent()
	{
		while (!SingletonBehaviour<WorldTimeBasedEvents>.Instance)
		{
			yield return null;
		}
		windowsEvent = SingletonBehaviour<WorldTimeBasedEvents>.Instance.GetComponent<WindowsLightEvent>();
		if (!windowsEvent)
		{
			Debug.LogError($"{typeof(WorldTimeBasedEvents)} doesn't have a {typeof(WindowsLightEvent)} on it, so there's no timing reference, destroying self.");
			Object.Destroy(this);
		}
		else
		{
			lightVolume.enabled = windowsEvent.LightsOn;
		}
	}

	private void Update()
	{
		if ((bool)windowsEvent)
		{
			lightVolume.enabled = windowsEvent.LightsOn;
		}
	}
}
