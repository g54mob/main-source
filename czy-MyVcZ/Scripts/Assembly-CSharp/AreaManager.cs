using UnityEngine;

public class AreaManager : MonoSingleton<AreaManager>
{
	[SerializeField]
	private GameObject _block_WindIsland;

	[SerializeField]
	private GameObject _block_deepCave;

	public long Cost_WindIsland { get; private set; } = 8000L;

	public long Cost_DeepCave { get; private set; } = 10000L;

	public bool IsUnlock_WindIsland { get; private set; }

	public bool IsUnlock_DeepCave { get; private set; }

	public void Init(bool isUnlock_WindIsland, bool isUnlock_DeepCave)
	{
		ChangeStateWindIsland(isUnlock_WindIsland);
		ChangeStateDeepCave(isUnlock_DeepCave);
	}

	public bool BuyWindIsland()
	{
		if (!Wallet.Instance.HasEnoughGold(Cost_WindIsland))
		{
			return false;
		}
		Wallet.Instance.ReduceGold(Cost_WindIsland);
		ChangeStateWindIsland(isUnlock: true);
		MonoSingleton<GameManager>.Instance.CameraController.StartFocusOnArea(_block_WindIsland.transform);
		return true;
	}

	public bool BuyDeepCave()
	{
		if (!Wallet.Instance.HasEnoughGold(Cost_DeepCave))
		{
			return false;
		}
		ChangeStateDeepCave(isUnlock: true);
		MonoSingleton<GameManager>.Instance.CameraController.StartFocusOnArea(_block_deepCave.transform);
		Wallet.Instance.ReduceGold(Cost_DeepCave);
		return true;
	}

	private void ChangeStateWindIsland(bool isUnlock)
	{
		IsUnlock_WindIsland = isUnlock;
		_block_WindIsland.SetActive(!IsUnlock_WindIsland);
	}

	private void ChangeStateDeepCave(bool isUnlock)
	{
		IsUnlock_DeepCave = isUnlock;
		_block_deepCave.SetActive(!IsUnlock_DeepCave);
	}
}
