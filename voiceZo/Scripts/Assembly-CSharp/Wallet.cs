using System;
using UnityEngine;

public class Wallet
{
	private static Wallet _instance;

	private const long GOLD_LIMIT = 999999999999999L;

	public static Wallet Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new Wallet();
			}
			return _instance;
		}
	}

	public long CurrentGold { get; private set; }

	public event Action<long> OnGoldChanged;

	public void Init(long gold)
	{
		CurrentGold = gold;
		this.OnGoldChanged?.Invoke(CurrentGold);
	}

	public void AddGold(long amount)
	{
		long num = CurrentGold + amount;
		if (num > 999999999999999L)
		{
			num = 999999999999999L;
		}
		CurrentGold = num;
		this.OnGoldChanged?.Invoke(CurrentGold);
	}

	public void ReduceGold(long amount)
	{
		if (CurrentGold < amount)
		{
			Debug.LogError("골드가 부족합니다.");
			return;
		}
		CurrentGold -= amount;
		MonoSingleton<GameManager>.Instance.SaveGame(lightweight: false);
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_Buy);
		this.OnGoldChanged?.Invoke(CurrentGold);
	}

	public bool HasEnoughGold(long amount)
	{
		return CurrentGold >= amount;
	}
}
