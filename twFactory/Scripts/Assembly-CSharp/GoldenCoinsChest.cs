using System.Collections.Generic;
using UnityEngine;

public class GoldenCoinsChest : MapObject, ISavable
{
	[SerializeField]
	private AudioData openChestAudioData;

	[SerializeField]
	private int money;

	private Animator animator;

	[Savable("alreadyUsed", true, false)]
	private bool alreadyUsed;

	public int Money
	{
		get
		{
			return money;
		}
		set
		{
			money = value;
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
		if (!alreadyUsed)
		{
			LTFunctionLibrary.GetLTGameManager().ChestCoins += money;
			AudioSystem.Instance.PlaySound2DOneShot(openChestAudioData, AudioSystem.EAudioMixerGroup.UI);
			alreadyUsed = true;
			animator.Play("Disappear");
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
		if (!hasLoadedSomething || alreadyUsed)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
