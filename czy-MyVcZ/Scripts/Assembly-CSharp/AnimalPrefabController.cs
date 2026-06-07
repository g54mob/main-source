using System.Collections.Generic;
using UnityEngine;

public class AnimalPrefabController : MonoBehaviour
{
	[SerializeField]
	private Camera _previewCamera;

	[SerializeField]
	private List<AnimalPos> _animalPosList;

	private Dictionary<int, AnimalPos> _animalPosDict;

	private Dictionary<int, AnimalPrefab> _spawnedAnimalPrefabDict;

	public void Init()
	{
		_animalPosDict = new Dictionary<int, AnimalPos>();
		int num = 10001;
		foreach (AnimalPos animalPos in _animalPosList)
		{
			_animalPosDict.Add(num, animalPos);
			num++;
		}
		_spawnedAnimalPrefabDict = new Dictionary<int, AnimalPrefab>();
	}

	public void SpawnAnimalPrefab(Animal animal)
	{
		AnimalPrefab animalPrefab = Object.Instantiate(Resources.Load<AnimalPrefab>(animal.AnimalData.PrefabPath), _animalPosDict[animal.AnimalData.ID].transform);
		animalPrefab.Init(animal);
		_spawnedAnimalPrefabDict.Add(animal.AnimalData.ID, animalPrefab);
		_animalPosDict[animal.AnimalData.ID].SetCurrentAnimalPrefab(animalPrefab);
	}

	public void PreviewCameraFocus_ToAnimalSpawnPos(Animal animal)
	{
		if (_animalPosDict.TryGetValue(animal.AnimalData.ID, out var value))
		{
			_previewCamera.transform.position = value.transform.position + new Vector3(0f, 0f, -1f);
		}
		else
		{
			Debug.LogError($"동물 스폰 위치를 찾을 수 없습니다 : {animal.AnimalData.ID}");
		}
	}

	public void SetMute_AllAnimalPrefabs(Animal animal)
	{
		foreach (AnimalPrefab value in _spawnedAnimalPrefabDict.Values)
		{
			value.ChangeMuteState(isMute: true);
		}
	}

	public void SetUnmute_AllAnimalPrefabs(Animal animal)
	{
		foreach (AnimalPrefab value in _spawnedAnimalPrefabDict.Values)
		{
			value.ChangeMuteState(isMute: false);
		}
	}

	public AnimalPrefab GetAnimalPrefab(int animalId)
	{
		if (_spawnedAnimalPrefabDict.TryGetValue(animalId, out var value))
		{
			return value;
		}
		Debug.Log($"동물 프리팹을 찾을 수 없습니다 : {animalId}");
		return null;
	}

	public AnimalPos GetAnimalPos(int animalId)
	{
		if (_animalPosDict.TryGetValue(animalId, out var value))
		{
			return value;
		}
		Debug.Log($"동물 스폰 위치를 찾을 수 없습니다 : {animalId}");
		return null;
	}

	public Dictionary<int, AnimalPos> GetAnimalPosDict()
	{
		return _animalPosDict;
	}

	public List<AnimalPrefab> GetSpawnedAnimalPrefabList()
	{
		return new List<AnimalPrefab>(_spawnedAnimalPrefabDict.Values);
	}

	public void SetAllCostumeVoice(AudioClip voiceClip)
	{
		if (voiceClip == null)
		{
			Debug.LogError("코스튬 울음소리 클립이 없습니다");
			return;
		}
		foreach (AnimalPrefab value in _spawnedAnimalPrefabDict.Values)
		{
			if (value.Animal.IsCollected)
			{
				value.SetCostumeVoice(voiceClip);
			}
		}
	}

	public void ResetAllCostumeVoice()
	{
		foreach (AnimalPrefab value in _spawnedAnimalPrefabDict.Values)
		{
			value.ResetCostumeVoice();
		}
	}
}
