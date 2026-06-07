using System.Collections.Generic;
using DV;
using DV.Utils;
using UnityEngine;

public class HazmatAudioGrid : MonoBehaviour
{
	public GameObject fireAudioPrefabLoD0;

	public GameObject fireAudioPrefabLoD1;

	public GameObject fireAudioPrefabLoD2;

	public GameObject corrosiveAudioPrefabLoD0;

	public GameObject corrosiveAudioPrefabLoD1;

	public GameObject corrosiveAudioPrefabLoD2;

	public GameObject biohazardAudioPrefabLoD0;

	public GameObject biohazardAudioPrefabLoD1;

	public GameObject biohazardAudioPrefabLoD2;

	public AudioClip ignitionSound;

	private bool biohazardLODsAllowed;

	[Range(0f, 5f)]
	public float fireSourceHeightOffset = 1.75f;

	[Range(0f, 5f)]
	public float corrosiveSourceHeightOffset = 0.5f;

	private Vector3 fireLoD0vel = Vector3.zero;

	private Vector3 fireLoD1vel = Vector3.zero;

	private Vector3 corrosiveLoD0vel = Vector3.zero;

	private Vector3 corrosiveLoD1vel = Vector3.zero;

	private Vector3 biohazardLoD0vel = Vector3.zero;

	private Vector3 biohazardLoD1vel = Vector3.zero;

	private const float SMOOTH_TIME = 0.5f;

	private int maxLoDIndex = 2;

	private int maxLoD2Distance = 10;

	private int lod2ClosestDistance = 5;

	private const string FIRE_AUDIO_LOD_NAME = "GridFireAuioLoD{0}";

	private const string CORROSIVE_AUDIO_LOD_NAME = "GridCorrosiveAuioLoD{0}";

	private const string BIOHAZARD_AUDIO_LOD_NAME = "GridBiohazardAuioLoD{0}";

	private const int LOD2_SOURCE_COUNT = 4;

	private Vector3 positionSumFire = Vector3.zero;

	private Vector3 positionSumCorrosive = Vector3.zero;

	private Vector3 positionSumBiohazard = Vector3.zero;

	private Vector3[] positionSumFireLoD2 = new Vector3[4];

	private Vector3[] positionSumCorrosiveLoD2 = new Vector3[4];

	private Vector3[] positionSumBiohazardLoD2 = new Vector3[4];

	private int positionCounterFire;

	private int positionCounterCorrosive;

	private int positionCounterBiohazard;

	private int[] positionCounterFireLoD2 = new int[4];

	private int[] positionCounterCorrosiveLoD2 = new int[4];

	private int[] positionCounterBiohazardLoD2 = new int[4];

	private float fireLoD0volumeVelo;

	private float fireLoD1volumeVelo;

	private float corrosiveLoD0volumeVelo;

	private float corrosiveLoD1volumeVelo;

	private float biohazardLoD0volumeVelo;

	private float biohazardLoD1volumeVelo;

	private AudioSource fireAudioSourceLoD0 = new AudioSource();

	private AudioSource fireAudioSourceLoD1 = new AudioSource();

	private AudioSource[] fireAudioSourceLoD2 = new AudioSource[4];

	private AudioSource corrosiveAudioSourceLoD0 = new AudioSource();

	private AudioSource corrosiveAudioSourceLoD1 = new AudioSource();

	private AudioSource[] corrosiveAudioSourceLoD2 = new AudioSource[4];

	private AudioSource biohazardAudioSourceLoD0 = new AudioSource();

	private AudioSource biohazardAudioSourceLoD1 = new AudioSource();

	private AudioSource[] biohazardAudioSourceLoD2 = new AudioSource[4];

	private void Start()
	{
		if (fireAudioPrefabLoD0 == null || fireAudioPrefabLoD1 == null || fireAudioPrefabLoD2 == null || corrosiveAudioPrefabLoD0 == null || corrosiveAudioPrefabLoD1 == null || corrosiveAudioPrefabLoD2 == null)
		{
			Debug.LogError("At least one of the audio prefabs is not found. Hazmat terrain effects will not be played");
			base.enabled = false;
			return;
		}
		if (biohazardAudioPrefabLoD0 != null && biohazardAudioPrefabLoD1 != null && biohazardAudioPrefabLoD2 != null)
		{
			biohazardLODsAllowed = true;
		}
		if (!SingletonBehaviour<HazmatTileManager>.Instance)
		{
			Debug.LogError("HazmatTileManager singleton not found. Disabling HazmatAudioGrid.");
			base.enabled = false;
			return;
		}
		GameObject gameObject = Object.Instantiate(fireAudioPrefabLoD0);
		gameObject.name = $"GridFireAuioLoD{0}";
		gameObject.transform.parent = WorldMover.OriginShiftParent;
		fireAudioSourceLoD0 = gameObject.GetComponent<AudioSource>();
		fireAudioSourceLoD0.Stop();
		fireAudioSourceLoD0.volume = 0f;
		gameObject = Object.Instantiate(fireAudioPrefabLoD1);
		gameObject.name = $"GridFireAuioLoD{1}";
		gameObject.transform.parent = WorldMover.OriginShiftParent;
		fireAudioSourceLoD1 = gameObject.GetComponent<AudioSource>();
		fireAudioSourceLoD1.Stop();
		fireAudioSourceLoD1.volume = 0f;
		for (int i = 0; i < fireAudioSourceLoD2.Length; i++)
		{
			gameObject = Object.Instantiate(fireAudioPrefabLoD2);
			gameObject.name = $"GridFireAuioLoD{$"2_{i}"}";
			gameObject.transform.parent = WorldMover.OriginShiftParent;
			fireAudioSourceLoD2[i] = gameObject.GetComponent<AudioSource>();
			fireAudioSourceLoD2[i].Stop();
			fireAudioSourceLoD2[i].volume = 0f;
		}
		gameObject = Object.Instantiate(corrosiveAudioPrefabLoD0);
		gameObject.name = $"GridCorrosiveAuioLoD{0}";
		gameObject.transform.parent = WorldMover.OriginShiftParent;
		corrosiveAudioSourceLoD0 = gameObject.GetComponent<AudioSource>();
		corrosiveAudioSourceLoD0.Stop();
		corrosiveAudioSourceLoD0.volume = 0f;
		gameObject = Object.Instantiate(corrosiveAudioPrefabLoD1);
		gameObject.name = $"GridCorrosiveAuioLoD{1}";
		gameObject.transform.parent = WorldMover.OriginShiftParent;
		corrosiveAudioSourceLoD1 = gameObject.GetComponent<AudioSource>();
		corrosiveAudioSourceLoD1.Stop();
		corrosiveAudioSourceLoD1.volume = 0f;
		for (int j = 0; j < corrosiveAudioSourceLoD2.Length; j++)
		{
			gameObject = Object.Instantiate(fireAudioPrefabLoD2);
			gameObject.name = $"GridCorrosiveAuioLoD{$"2_{j}"}";
			gameObject.transform.parent = WorldMover.OriginShiftParent;
			corrosiveAudioSourceLoD2[j] = gameObject.GetComponent<AudioSource>();
			corrosiveAudioSourceLoD2[j].Stop();
			corrosiveAudioSourceLoD2[j].volume = 0f;
		}
		if (biohazardLODsAllowed)
		{
			gameObject = Object.Instantiate(biohazardAudioPrefabLoD0);
			gameObject.name = $"GridBiohazardAuioLoD{0}";
			gameObject.transform.parent = WorldMover.OriginShiftParent;
			biohazardAudioSourceLoD0 = gameObject.GetComponent<AudioSource>();
			biohazardAudioSourceLoD0.Stop();
			biohazardAudioSourceLoD0.volume = 0f;
			gameObject = Object.Instantiate(biohazardAudioPrefabLoD1);
			gameObject.name = $"GridBiohazardAuioLoD{1}";
			gameObject.transform.parent = WorldMover.OriginShiftParent;
			biohazardAudioSourceLoD1 = gameObject.GetComponent<AudioSource>();
			biohazardAudioSourceLoD1.Stop();
			biohazardAudioSourceLoD1.volume = 0f;
			for (int k = 0; k < corrosiveAudioSourceLoD2.Length; k++)
			{
				gameObject = Object.Instantiate(fireAudioPrefabLoD2);
				gameObject.name = $"GridBiohazardAuioLoD{$"2_{k}"}";
				gameObject.transform.parent = WorldMover.OriginShiftParent;
				biohazardAudioSourceLoD2[k] = gameObject.GetComponent<AudioSource>();
				biohazardAudioSourceLoD2[k].Stop();
				biohazardAudioSourceLoD2[k].volume = 0f;
			}
		}
	}

	private int GetGridPosition(Vector3 pos)
	{
		return SingletonBehaviour<HazmatTileManager>.Instance.GetGridPositionFromWorldPosition(pos);
	}

	private int GetGridX(int gridCoords)
	{
		return SingletonBehaviour<HazmatTileManager>.Instance.GetTileCoordX(gridCoords);
	}

	private int GetGridY(int gridCoords)
	{
		return SingletonBehaviour<HazmatTileManager>.Instance.GetTileCoordY(gridCoords);
	}

	private int PackCoords(int x, int y)
	{
		return SingletonBehaviour<HazmatTileManager>.Instance.PackGridCoordsToInt(x, y);
	}

	private Vector3 GetWorldPosition(HazmatGridTile tile)
	{
		return SingletonBehaviour<HazmatTileManager>.Instance.GetWorldPositionFromGridTileWithHeight(tile);
	}

	private void Update()
	{
		if (TimeUtil.IsFlowing)
		{
			ManageAudioLoDs();
		}
	}

	public void ManageAudioLoDs()
	{
		if (SingletonBehaviour<HazmatTileManager>.Instance.TileDictionary == null || SingletonBehaviour<HazmatTileManager>.Instance.TileDictionary.Count <= 0)
		{
			AudioSourceSmoothToggle(fireAudioSourceLoD0, ref fireLoD0volumeVelo, on: false);
			AudioSourceSmoothToggle(fireAudioSourceLoD1, ref fireLoD1volumeVelo, on: false);
			AudioSourceSmoothToggle(corrosiveAudioSourceLoD0, ref corrosiveLoD0volumeVelo, on: false);
			AudioSourceSmoothToggle(corrosiveAudioSourceLoD1, ref corrosiveLoD1volumeVelo, on: false);
			AudioSource[] array;
			if (biohazardLODsAllowed)
			{
				AudioSourceSmoothToggle(biohazardAudioSourceLoD0, ref biohazardLoD0volumeVelo, on: false);
				AudioSourceSmoothToggle(biohazardAudioSourceLoD1, ref biohazardLoD1volumeVelo, on: false);
				array = biohazardAudioSourceLoD2;
				foreach (AudioSource audioSource in array)
				{
					if (audioSource.isPlaying)
					{
						audioSource.Stop();
					}
				}
			}
			array = fireAudioSourceLoD2;
			foreach (AudioSource audioSource2 in array)
			{
				if (audioSource2.isPlaying)
				{
					audioSource2.Stop();
				}
			}
			array = corrosiveAudioSourceLoD2;
			foreach (AudioSource audioSource3 in array)
			{
				if (audioSource3.isPlaying)
				{
					audioSource3.Stop();
				}
			}
		}
		else if (Camera.main != null)
		{
			int gridPosition = GetGridPosition(Camera.main.transform.position);
			int gridX = GetGridX(gridPosition);
			int gridY = GetGridY(gridPosition);
			for (int j = 0; j <= maxLoDIndex; j++)
			{
				UpdateAudioLoD(j, gridX, gridY);
			}
		}
	}

	private void UpdateAudioLoD(int lod, int centerX, int centerY)
	{
		Dictionary<int, HazmatGridTile> tileDictionary = SingletonBehaviour<HazmatTileManager>.Instance.TileDictionary;
		positionSumFire = Vector3.zero;
		positionSumCorrosive = Vector3.zero;
		positionSumBiohazard = Vector3.zero;
		positionCounterCorrosive = 0;
		positionCounterFire = 0;
		positionCounterBiohazard = 0;
		switch (lod)
		{
		case 0:
		{
			for (int m = -1; m <= 1; m++)
			{
				int x2 = centerX + m;
				for (int n = -1; n <= 1; n++)
				{
					int y2 = centerY + n;
					int key2 = PackCoords(x2, y2);
					if (tileDictionary.TryGetValue(key2, out var value2))
					{
						if (value2.IsIgnited)
						{
							positionSumFire += GetWorldPosition(value2);
							positionCounterFire++;
						}
						if (value2.ContainsCorosive())
						{
							positionSumCorrosive += GetWorldPosition(value2);
							positionCounterCorrosive++;
						}
						if (biohazardLODsAllowed && value2.ContainsBioHazard())
						{
							positionSumBiohazard += GetWorldPosition(value2);
							positionCounterBiohazard++;
						}
					}
				}
			}
			AudioToggleAndRepositionSmooth(positionCounterFire, fireAudioSourceLoD0, positionSumFire, fireSourceHeightOffset, ref fireLoD0vel, ref fireLoD0volumeVelo);
			AudioToggleAndRepositionSmooth(positionCounterCorrosive, corrosiveAudioSourceLoD0, positionSumCorrosive, corrosiveSourceHeightOffset, ref corrosiveLoD0vel, ref corrosiveLoD0volumeVelo);
			if (biohazardLODsAllowed)
			{
				AudioToggleAndRepositionSmooth(positionCounterBiohazard, biohazardAudioSourceLoD0, positionSumBiohazard, corrosiveSourceHeightOffset, ref biohazardLoD0vel, ref biohazardLoD0volumeVelo);
			}
			return;
		}
		case 1:
		{
			for (int i = -3; i <= 3; i += 3)
			{
				int num = centerX + i;
				for (int j = -3; j <= 3; j += 3)
				{
					if (i == 0 && j == 0)
					{
						continue;
					}
					int num2 = centerY + j;
					for (int k = -1; k <= 1; k++)
					{
						int x = num + k;
						for (int l = -1; l <= 1; l++)
						{
							int y = num2 + l;
							int key = PackCoords(x, y);
							if (tileDictionary.TryGetValue(key, out var value))
							{
								if (value.IsIgnited)
								{
									positionSumFire += GetWorldPosition(value);
									positionCounterFire++;
								}
								if (value.ContainsCorosive())
								{
									positionSumCorrosive += GetWorldPosition(value);
									positionCounterCorrosive++;
								}
								if (biohazardLODsAllowed && value.ContainsBioHazard())
								{
									positionSumBiohazard += GetWorldPosition(value);
									positionCounterBiohazard++;
								}
							}
						}
					}
				}
			}
			AudioToggleAndRepositionSmooth(positionCounterFire, fireAudioSourceLoD1, positionSumFire, fireSourceHeightOffset, ref fireLoD1vel, ref fireLoD1volumeVelo);
			AudioToggleAndRepositionSmooth(positionCounterCorrosive, corrosiveAudioSourceLoD1, positionSumCorrosive, corrosiveSourceHeightOffset, ref corrosiveLoD1vel, ref corrosiveLoD1volumeVelo);
			if (biohazardLODsAllowed)
			{
				AudioToggleAndRepositionSmooth(positionCounterBiohazard, biohazardAudioSourceLoD1, positionSumBiohazard, corrosiveSourceHeightOffset, ref biohazardLoD1vel, ref biohazardLoD1volumeVelo);
			}
			return;
		}
		}
		if (fireAudioSourceLoD1.isPlaying || fireAudioSourceLoD0.isPlaying)
		{
			AudioSource[] array = fireAudioSourceLoD2;
			for (int num3 = 0; num3 < array.Length; num3++)
			{
				array[num3].Stop();
			}
			return;
		}
		for (int num4 = 0; num4 < 4; num4++)
		{
			positionSumFireLoD2[num4] = Vector3.zero;
			positionSumCorrosiveLoD2[num4] = Vector3.zero;
			positionCounterFireLoD2[num4] = 0;
			positionCounterCorrosiveLoD2[num4] = 0;
		}
		for (int num5 = 0; num5 <= maxLoD2Distance; num5++)
		{
			int num6 = lod2ClosestDistance + num5;
			for (int num7 = -5 - num5; num7 < num5 + 5; num7++)
			{
				int num8 = lod2ClosestDistance + num7;
				int x3 = centerX + num6;
				int y3 = centerY + num8;
				HazmatGridTile loD2Tile = GetLoD2Tile(PackCoords(x3, y3));
				if (loD2Tile != null && loD2Tile.IsIgnited)
				{
					if (loD2Tile.IsIgnited)
					{
						positionSumFireLoD2[0] += GetWorldPosition(loD2Tile);
						positionCounterFireLoD2[0]++;
					}
					if (loD2Tile.ContainsCorosive())
					{
						positionSumCorrosiveLoD2[0] += GetWorldPosition(loD2Tile);
						positionCounterCorrosiveLoD2[0]++;
					}
				}
				x3 = centerX - num8;
				y3 = centerY + num6;
				loD2Tile = GetLoD2Tile(PackCoords(x3, y3));
				if (loD2Tile != null && loD2Tile.IsIgnited)
				{
					if (loD2Tile.IsIgnited)
					{
						positionSumFireLoD2[1] += GetWorldPosition(loD2Tile);
						positionCounterFireLoD2[1]++;
					}
					if (loD2Tile.ContainsCorosive())
					{
						positionSumCorrosiveLoD2[1] += GetWorldPosition(loD2Tile);
						positionCounterCorrosiveLoD2[1]++;
					}
					if (biohazardLODsAllowed && loD2Tile.ContainsBioHazard())
					{
						positionSumBiohazardLoD2[1] += GetWorldPosition(loD2Tile);
						positionCounterBiohazardLoD2[1]++;
					}
				}
				x3 = centerX - num6;
				y3 = centerY - num8;
				loD2Tile = GetLoD2Tile(PackCoords(x3, y3));
				if (loD2Tile != null && loD2Tile.IsIgnited)
				{
					if (loD2Tile.IsIgnited)
					{
						positionSumFireLoD2[2] += GetWorldPosition(loD2Tile);
						positionCounterFireLoD2[2]++;
					}
					if (loD2Tile.ContainsCorosive())
					{
						positionSumCorrosiveLoD2[2] += GetWorldPosition(loD2Tile);
						positionCounterCorrosiveLoD2[2]++;
					}
					if (biohazardLODsAllowed && loD2Tile.ContainsBioHazard())
					{
						positionSumBiohazardLoD2[2] += GetWorldPosition(loD2Tile);
						positionCounterBiohazardLoD2[2]++;
					}
				}
				x3 = centerX + num8;
				y3 = centerY - num6;
				loD2Tile = GetLoD2Tile(PackCoords(x3, y3));
				if (loD2Tile != null && loD2Tile.IsIgnited)
				{
					if (loD2Tile.IsIgnited)
					{
						positionSumFireLoD2[3] += GetWorldPosition(loD2Tile);
						positionCounterFireLoD2[3]++;
					}
					if (loD2Tile.ContainsCorosive())
					{
						positionSumCorrosiveLoD2[3] += GetWorldPosition(loD2Tile);
						positionCounterCorrosiveLoD2[3]++;
					}
					if (biohazardLODsAllowed && loD2Tile.ContainsBioHazard())
					{
						positionSumBiohazardLoD2[3] += GetWorldPosition(loD2Tile);
						positionCounterBiohazardLoD2[3]++;
					}
				}
			}
		}
		for (int num9 = 0; num9 < 4; num9++)
		{
			AudioToggleAndRepositionInstant(positionCounterFireLoD2[num9], fireAudioSourceLoD2[num9], positionSumFireLoD2[num9]);
			AudioToggleAndRepositionInstant(positionCounterCorrosiveLoD2[num9], corrosiveAudioSourceLoD2[num9], positionSumCorrosiveLoD2[num9]);
			if (biohazardLODsAllowed)
			{
				AudioToggleAndRepositionInstant(positionCounterBiohazardLoD2[num9], biohazardAudioSourceLoD2[num9], positionSumBiohazardLoD2[num9]);
			}
		}
	}

	private HazmatGridTile GetLoD2Tile(int tileKey)
	{
		SingletonBehaviour<HazmatTileManager>.Instance.TileDictionary.TryGetValue(tileKey, out var value);
		return value;
	}

	private void AudioToggleAndRepositionSmooth(float counter, AudioSource source, Vector3 pos, float offset, ref Vector3 repositionVelocity, ref float volumeVelocity)
	{
		if (counter > 0f)
		{
			pos /= counter;
			pos.y += offset;
			if (!source.isPlaying)
			{
				source.transform.position = pos;
			}
			else
			{
				source.transform.position = Vector3.SmoothDamp(source.transform.position, pos, ref repositionVelocity, 0.5f);
			}
			AudioSourceSmoothToggle(source, ref volumeVelocity);
		}
		else
		{
			AudioSourceSmoothToggle(source, ref volumeVelocity, on: false);
		}
	}

	private void AudioToggleAndRepositionInstant(float counter, AudioSource source, Vector3 pos)
	{
		if (counter > 0f)
		{
			pos /= counter;
			source.transform.position = pos;
			if (!source.isPlaying)
			{
				source.Play();
			}
		}
		else if (source.isPlaying)
		{
			source.Stop();
		}
	}

	private void AudioSourceSmoothToggle(AudioSource source, ref float velocity, bool on = true)
	{
		if (on)
		{
			if (source.isPlaying)
			{
				if (source.volume < 0.99f)
				{
					source.volume = Mathf.SmoothDamp(source.volume, 1f, ref velocity, 0.5f);
				}
				else if (source.volume < 1f)
				{
					source.volume = 1f;
				}
			}
			else
			{
				source.Play();
			}
		}
		else if (source.isPlaying)
		{
			if (source.volume > 0.01f)
			{
				source.volume = Mathf.SmoothDamp(source.volume, 0f, ref velocity, 0.5f);
			}
			else if (source.volume > 0f)
			{
				source.volume = 0f;
				source.Stop();
			}
		}
	}

	public void PlayIgnitionSound(Vector3 pos, bool forced = false)
	{
		if (!(ignitionSound == null))
		{
			if (forced)
			{
				ignitionSound.Play(pos);
			}
			else if (!fireAudioSourceLoD0.isPlaying)
			{
				ignitionSound.Play(pos);
			}
		}
	}
}
