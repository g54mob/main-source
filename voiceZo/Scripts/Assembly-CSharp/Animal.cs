using System;
using UnityEngine;

public class Animal
{
	public AnimalData AnimalData { get; private set; }

	public bool IsCollected { get; private set; }

	public string Name { get; private set; }

	public AudioClip Voice { get; private set; }

	public bool IsVoiceDirty { get; private set; }

	public event Action<string> OnNameChanged;

	public event Action<AudioClip> OnVoiceChanged;

	public event Action<bool> OnChangeIsAdoptProcessing;

	public event Action OnPlayVoice;

	public event Action<long> OnAddIncomePerSecond;

	public Animal(AnimalData animalData, bool isCollected, string name)
	{
		AnimalData = animalData;
		IsCollected = isCollected;
		Name = name;
	}

	public long GetIncome()
	{
		return AnimalData.Income;
	}

	public int GetIncomeInterval()
	{
		return AnimalData.IncomeInterval;
	}

	public double GetIncomePerSecond()
	{
		return AnimalData.Income / AnimalData.IncomeInterval;
	}

	public void SetIsCollected(bool isCollected)
	{
		IsCollected = isCollected;
	}

	public void SetName(string name)
	{
		Name = name;
		this.OnNameChanged?.Invoke(name);
	}

	public void SetVoice(AudioClip voice, bool markDirty = true)
	{
		Voice = voice;
		if (markDirty)
		{
			IsVoiceDirty = true;
		}
		this.OnVoiceChanged?.Invoke(voice);
		MonoSingleton<CostumeManager>.Instance.UpdateAnimalsCostumeVoice();
	}

	public void ChangeIsAdoptProcessing(bool isAdoptProcessing)
	{
		this.OnChangeIsAdoptProcessing?.Invoke(isAdoptProcessing);
	}

	public void PlayVoice()
	{
		this.OnPlayVoice?.Invoke();
	}

	public void AddIncomePerSecond(long income)
	{
		this.OnAddIncomePerSecond?.Invoke(income);
	}

	public void MarkVoiceDirty()
	{
		IsVoiceDirty = true;
	}

	public void ClearVoiceDirty()
	{
		IsVoiceDirty = false;
	}
}
