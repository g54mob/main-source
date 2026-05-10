using System.Collections.Generic;
using UnityEngine;

public class Chest : MapObject, ISavable
{
	[SerializeField]
	private AudioData openChestAudioData;

	[SerializeField]
	private List<Cost> reward;

	private Animator animator;

	[Savable("alreadyUsed", true, false)]
	private bool alreadyUsed;

	public List<Cost> Reward
	{
		get
		{
			return reward;
		}
		set
		{
			reward = value;
			if (reward != null)
			{
				SortReward();
			}
		}
	}

	public bool AlreadyUsed => alreadyUsed;

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
	}

	private void SortReward()
	{
		reward.Sort((Cost x, Cost y) => x.Amount.CompareTo(y.Amount));
	}

	public void GetReward()
	{
		if (alreadyUsed)
		{
			return;
		}
		foreach (Cost item in Reward)
		{
			LTFunctionLibrary.GetPlayerInventory().StoreObject(item.Resource, item.Amount, Storage_ResourceData.EStoreSource.Chest);
		}
		AudioSystem.Instance.PlaySound2DOneShot(openChestAudioData, AudioSystem.EAudioMixerGroup.UI);
		alreadyUsed = true;
		animator.Play("Disappear");
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!hasLoadedSomething || alreadyUsed)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
