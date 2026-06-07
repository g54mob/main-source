using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager
{
	private static AnimalManager _instance;

	public static AnimalManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AnimalManager();
			}
			return _instance;
		}
	}

	public Dictionary<int, Animal> AnimalDict { get; private set; }

	public event Action<Animal> OnCollectAnimal;

	public event Action<Animal> OnAdoptAnimal;

	public event Action<Animal> OnEditAnimal;

	public event Action<Animal> OnProcessStartAdoptEdit;

	public event Action<Animal> OnProcessEndAdoptEdit;

	public event Action<long> OnAddIncomePerSecond;

	public void Init()
	{
		AnimalDict = new Dictionary<int, Animal>();
		foreach (KeyValuePair<int, AnimalData> item in DataManager.Instance.GetAnimalDataDict())
		{
			Animal animal = new Animal(item.Value, isCollected: false, string.Empty);
			animal.OnAddIncomePerSecond += AddIncomePerSecond;
			AnimalDict.Add(item.Key, animal);
		}
	}

	public void AdoptAnimal(Animal animal)
	{
		if (!animal.IsCollected && Wallet.Instance.HasEnoughGold(animal.AnimalData.AdoptCost))
		{
			Wallet.Instance.ReduceGold(animal.AnimalData.AdoptCost);
			AnimalCollectStateChange(animal.AnimalData.ID, collectState: true);
			MonoSingleton<TutorialManager>.Instance.TryEndTutorial();
			MonoSingleton<GameManager>.Instance.SaveGame(lightweight: false);
			if (animal.AnimalData.ID == 10020)
			{
				MonoSingleton<SteamAchievementManager>.Instance.Achieve_FinalAchievement();
			}
			Notify_OnAdoptEditProcessStart(animal);
			this.OnAdoptAnimal?.Invoke(animal);
			MonoSingleton<CostumeManager>.Instance.UpdateAnimalsCostumeVoice();
		}
	}

	public void EditAnimal(Animal animal)
	{
		if (Wallet.Instance.HasEnoughGold(animal.AnimalData.EditCost))
		{
			Wallet.Instance.ReduceGold(animal.AnimalData.EditCost);
			Notify_OnAdoptEditProcessStart(animal);
			this.OnEditAnimal?.Invoke(animal);
		}
	}

	public void AnimalCollectStateChange(int animalID, bool collectState)
	{
		if (AnimalDict.TryGetValue(animalID, out var value))
		{
			value.SetIsCollected(collectState);
			if (collectState)
			{
				this.OnCollectAnimal?.Invoke(value);
			}
		}
		else
		{
			Debug.LogError($"동물을 찾을 수 없습니다 : {animalID}");
		}
	}

	public void SetAnimalName(int animalID, string name)
	{
		if (AnimalDict.TryGetValue(animalID, out var value))
		{
			value.SetName(name);
		}
		else
		{
			Debug.LogError($"동물을 찾을 수 없습니다 : {animalID}");
		}
	}

	public void SetAnimalVoice(int animalID, AudioClip voice)
	{
		if (AnimalDict.TryGetValue(animalID, out var value))
		{
			value.SetVoice(voice);
		}
		else
		{
			Debug.LogError($"동물을 찾을 수 없습니다 : {animalID}");
		}
	}

	private void AddIncomePerSecond(long income)
	{
		Wallet.Instance.AddGold(income);
		this.OnAddIncomePerSecond?.Invoke(income);
	}

	public void Notify_OnAdoptEditProcessStart(Animal animal)
	{
		this.OnProcessStartAdoptEdit?.Invoke(animal);
	}

	public void Notify_OnAdoptEditProcessEnd(Animal animal)
	{
		this.OnProcessEndAdoptEdit?.Invoke(animal);
	}

	public List<Animal> GetAnimalList()
	{
		List<Animal> list = new List<Animal>();
		foreach (Animal value in AnimalDict.Values)
		{
			list.Add(value);
		}
		return list;
	}

	public bool IsAnimalCollected(int animalID)
	{
		if (AnimalDict.TryGetValue(animalID, out var value))
		{
			return value.IsCollected;
		}
		Debug.LogError($"동물을 찾을 수 없습니다 : {animalID}");
		return false;
	}
}
