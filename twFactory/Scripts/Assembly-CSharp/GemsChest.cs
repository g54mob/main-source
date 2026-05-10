using System.Collections.Generic;
using UnityEngine;

public class GemsChest : MapObject, ISavable
{
	[SerializeField]
	private AudioData openChestAudioData;

	[SerializeField]
	private List<GemData> reward;

	private Animator animator;

	[Savable("alreadyUsed", true, false)]
	private bool alreadyUsed;

	public List<GemData> Reward
	{
		get
		{
			return reward;
		}
		set
		{
			reward = value;
		}
	}

	public bool AlreadyUsed => alreadyUsed;

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
	}

	public void GetReward()
	{
		if (alreadyUsed)
		{
			return;
		}
		foreach (GemData item in Reward)
		{
			LTFunctionLibrary.GetPlayerData().AddGem(item);
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
