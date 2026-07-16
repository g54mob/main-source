using UnityEngine;

public class UpkeepComponent : MonoBehaviour
{
	[SerializeField]
	private bool registerOnStart;

	public int ampunt;

	private void Start()
	{
		if (GameStateManager.GetCurrentGameState() != GameStateManager.GameState.TitleScreen)
		{
			float difficultyFactor = CafeShopManager.GetDifficultyFactor();
			int upkeep = GetComponent<ItemComponent>().GetInfo().upkeep;
			ampunt = Mathf.RoundToInt((float)upkeep * difficultyFactor);
			CafeShopManager.RegisterUpkeep(this);
		}
	}

	private void OnDestroy()
	{
		OnRemove();
	}

	public void OnPlace()
	{
		CafeShopManager.RegisterUpkeep(this);
	}

	public void OnRemove()
	{
		CafeShopManager.UnregisterUpkeep(this);
	}
}
