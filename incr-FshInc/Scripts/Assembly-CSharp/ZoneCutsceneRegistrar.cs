using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class ZoneCutsceneRegistrar : MonoBehaviour
{
	private void Awake()
	{
		PlayableDirector component = GetComponent<PlayableDirector>();
		component.playOnAwake = false;
		component.Stop();
	}

	private void Start()
	{
		if (CutsceneManager.Instance == null)
		{
			Debug.LogWarning("[ZoneCutsceneRegistrar] CutsceneManager not found in scene.");
			return;
		}
		PlayableDirector component = GetComponent<PlayableDirector>();
		CutsceneManager.Instance.SetDirector(component);
		Debug.Log("[ZoneCutsceneRegistrar] Registered director on '" + base.transform.root.name + "'.");
		ZoneData zoneData = GameManager.Instance?.currentZone;
		CutsceneManager.Instance.NotifyZoneLoaded(zoneData);
	}
}
