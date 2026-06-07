using System;
using System.Collections.Generic;
using UnityEngine;

public class GemsComponent : MonoBehaviour, ISavable
{
	[SerializeField]
	private int maxGems = 1;

	[SerializeField]
	[Savable("gems", true, false)]
	private GemData[] gems;

	private GameplayEffectsComponent gameplayEffectsComponent;

	public GemData[] Gems => gems;

	public List<GemData> GemsList
	{
		get
		{
			List<GemData> list = new List<GemData>();
			for (int i = 0; i < Gems.Length; i++)
			{
				if ((bool)Gems[i])
				{
					list.Add(Gems[i]);
				}
			}
			return list;
		}
	}

	public int MaxGems
	{
		get
		{
			return maxGems;
		}
		set
		{
			if (maxGems == value)
			{
				return;
			}
			GemData[] array = new GemData[value];
			if (value < maxGems)
			{
				for (int num = maxGems - 1; num >= value; num--)
				{
					LTFunctionLibrary.GetPlayerData().AddGem(Gems[num]);
				}
			}
			for (int i = 0; i < gems.Length && i < value; i++)
			{
				array[i] = gems[i];
			}
			gems = array;
			maxGems = value;
			this.onMaxGemsChanged?.Invoke(maxGems);
		}
	}

	public event Action<int> onMaxGemsChanged;

	public event Action<GemData> onGemAdded;

	public event Action<GemData> onGemRemoved;

	private void Awake()
	{
		gameplayEffectsComponent = GetComponent<GameplayEffectsComponent>();
		if (Gems == null)
		{
			gems = new GemData[MaxGems];
			return;
		}
		if (gems.Length < MaxGems)
		{
			GemData[] array = new GemData[MaxGems];
			for (int i = 0; i < gems.Length; i++)
			{
				array[i] = gems[i];
			}
			gems = array;
		}
		GemData[] array2 = Gems;
		foreach (GemData gemData in array2)
		{
			ApplyGemEffects(gemData);
		}
	}

	public bool AddGem(GemData gemToAdd, int idx)
	{
		if (idx < gems.Length)
		{
			gems[idx] = gemToAdd;
			ApplyGemEffects(gemToAdd);
			this.onGemAdded?.Invoke(gemToAdd);
			return true;
		}
		return false;
	}

	public bool AddGem(GemData gemToAdd)
	{
		for (int i = 0; i < gems.Length; i++)
		{
			if (gems[i] == null)
			{
				return AddGem(gemToAdd, i);
			}
		}
		return false;
	}

	public bool RemoveGem(int removeIdx)
	{
		if (removeIdx < gems.Length && gems[removeIdx] != null)
		{
			RemoveGemEffects(gems[removeIdx]);
			GemData obj = gems[removeIdx];
			gems[removeIdx] = null;
			this.onGemRemoved?.Invoke(obj);
			return true;
		}
		return false;
	}

	private void ApplyGemEffects(GemData gemData)
	{
		if ((bool)gemData)
		{
			GameplayEffectData[] gameplayEffectsToApply = gemData.GameplayEffectsToApply;
			foreach (GameplayEffectData effectData in gameplayEffectsToApply)
			{
				gameplayEffectsComponent.ApplyEffect(effectData);
			}
		}
	}

	private void RemoveGemEffects(GemData gemData)
	{
		GameplayEffectData[] gameplayEffectsToApply = gemData.GameplayEffectsToApply;
		foreach (GameplayEffectData effectData in gameplayEffectsToApply)
		{
			gameplayEffectsComponent.RemoveEffect(effectData, 1);
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!hasLoadedSomething || !data.ContainsKey("gems"))
		{
			return;
		}
		foreach (Dictionary<string, object> item in data["gems"] as List<Dictionary<string, object>>)
		{
			if (item != null)
			{
				AddGem(LTAssetsReferences.instance.GetGemDataById(item["id"] as string));
			}
		}
	}
}
