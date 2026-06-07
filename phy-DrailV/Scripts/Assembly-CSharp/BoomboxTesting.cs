using System.Collections;
using UnityEngine;

public class BoomboxTesting : MonoBehaviour
{
	public enum InitMode
	{
		SpawnAsEnabled = 0,
		SpawnInDisabledObject = 1,
		SpawnAsEnabledThenReparentToDisabled = 2
	}

	public bool spawnPowerModeOn = true;

	public bool spawnRadioModeOn = true;

	public float spawnVolume = 0.5f;

	public float spawnAntenna = 1f;

	public int spawnRadioStationIndex = 4;

	public GameObject spawnInsertedCassettePrefab;

	public int spawnCassettePlaylistIndex = 2;

	public bool spawnCassettePlaying = true;

	public InitMode initMode;

	[InspectorButton("Spawn", false, true)]
	public bool spawn;

	public GameObject container;

	public GameObject boomboxPrefab;

	private GameObject boombox;

	private BoomboxInteractionController bc;

	[Header("Boombox general")]
	[InspectorButton("PowerOn", false, true)]
	public bool powerOn;

	[InspectorButton("PowerOff", false, true)]
	public bool powerOff;

	[InspectorButton("SwitchToRadioMode", false, true)]
	public bool switchToRadioMode;

	[InspectorButton("SwitchToTapeMode", false, true)]
	public bool switchToTapeMode;

	public float volumeToSet = 1f;

	[InspectorButton("SetVolume", false, true)]
	public bool setVolume;

	[Header("Radio")]
	public float antennaToSet = 1f;

	[InspectorButton("SetAntenna", false, true)]
	public bool setAntenna;

	[InspectorButton("RadioTuneNext", false, true)]
	public bool radioTuneNext;

	[InspectorButton("RadioTunePrevious", false, true)]
	public bool radioTunePrevious;

	[Header("Cassette")]
	public Cassette cassetteToInsert;

	[InspectorButton("InsertCassette", false, true)]
	public bool insertCassette;

	[InspectorButton("RemoveCassette", false, true)]
	public bool removeCassette;

	[InspectorButton("CloseDoor", false, true)]
	public bool closeDoor;

	[InspectorButton("Play", false, true)]
	public bool play;

	[InspectorButton("Pause", false, true)]
	public bool pause;

	[InspectorButton("Stop", false, true)]
	public bool stop;

	[InspectorButton("Previous", false, true)]
	public bool previous;

	[InspectorButton("Next", false, true)]
	public bool next;

	private void Spawn()
	{
		if (initMode == InitMode.SpawnAsEnabled)
		{
			container.SetActive(value: true);
			boombox = Object.Instantiate(boomboxPrefab, container.transform, instantiateInWorldSpace: false) as GameObject;
		}
		else if (InitMode.SpawnInDisabledObject == initMode)
		{
			container.SetActive(value: false);
			boombox = Object.Instantiate(boomboxPrefab, container.transform, instantiateInWorldSpace: false) as GameObject;
		}
		else if (InitMode.SpawnAsEnabledThenReparentToDisabled == initMode)
		{
			container.SetActive(value: false);
			boombox = Object.Instantiate(boomboxPrefab);
			StartCoroutine(Reparent(boombox.transform, container.transform));
		}
		bc = boombox.GetComponent<BoomboxInteractionController>();
		StartCoroutine(LoadStateCoro());
	}

	private IEnumerator LoadStateCoro()
	{
		while (!bc.initialized)
		{
			yield return null;
		}
		if (spawnInsertedCassettePrefab != null)
		{
			GameObject gameObject = Object.Instantiate(spawnInsertedCassettePrefab);
			gameObject.name = spawnInsertedCassettePrefab.name;
			gameObject.GetComponent<InventoryItemSpec>().BelongsToPlayer = true;
			gameObject.transform.position = bc.transform.position + Vector3.down;
			gameObject.transform.SetParent(WorldMover.OriginShiftParent);
			Cassette component = gameObject.GetComponent<Cassette>();
			if (component == null)
			{
				Debug.LogError(string.Format("Unexpected state: {0} prefab is missing {1} component! Can't load inserted cassette. Destroying invalid cassette.", spawnInsertedCassettePrefab, "Cassette"));
				Object.Destroy(gameObject);
			}
			else
			{
				if (spawnCassettePlaylistIndex >= 0)
				{
					component.lastPlayedPlaylistEntry = spawnCassettePlaylistIndex;
				}
				bc.InsertCassette(component, removeFromStorage: false);
				if (spawnCassettePlaying)
				{
					bc.CassettePlay();
				}
			}
		}
		bc.SetMode(spawnRadioModeOn);
		if (spawnRadioStationIndex >= 0)
		{
			bc.OverrideLastPlayedStationIndex(spawnRadioStationIndex);
		}
		bc.SetVolume(spawnVolume);
		bc.SetAntenna(spawnAntenna);
		bc.SetPower(spawnPowerModeOn);
		bc.SyncInteractables();
	}

	private IEnumerator Reparent(Transform what, Transform where)
	{
		yield return null;
		what.SetParent(where);
		what.localPosition = Vector3.zero;
		what.localRotation = Quaternion.identity;
	}

	private void PowerOn()
	{
		bc.SetPower(powerOn: true);
	}

	private void PowerOff()
	{
		bc.SetPower(powerOn: false);
	}

	private void SwitchToRadioMode()
	{
		bc.SetMode(setRadioMode: true);
	}

	private void SwitchToTapeMode()
	{
		bc.SetMode(setRadioMode: false);
	}

	private void SetVolume()
	{
		bc.SetVolume(volumeToSet);
	}

	private void SetAntenna()
	{
		bc.SetAntenna(antennaToSet);
	}

	private void RadioTuneNext()
	{
		bc.UpdateRadioTune(next: true);
	}

	private void RadioTunePrevious()
	{
		bc.UpdateRadioTune(next: false);
	}

	private void Play()
	{
		bc.CassettePlay();
	}

	private void Pause()
	{
		bc.CassettePause();
	}

	private void Stop()
	{
		bc.CassetteStopOrEject();
	}

	private void Previous()
	{
		bc.CassettePrevious();
	}

	private void Next()
	{
		bc.CassetteNext();
	}

	private void CloseDoor()
	{
		bc.CassetteDoorClose();
	}

	private void InsertCassette()
	{
		bc.InsertCassette(cassetteToInsert);
	}

	private void RemoveCassette()
	{
		bc.RemoveCassette();
	}
}
