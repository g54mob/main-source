using UnityEngine;

public class FishingHarbourUpgrade : MonoBehaviour
{
	[SerializeField]
	private FishingHarbour fishingHarbour;

	private void OnEnable()
	{
		fishingHarbour.maximumIncome *= 2;
		fishingHarbour.incomeIncreasePerTurn *= 2;
		Object.Destroy(this);
		Object.Destroy(base.gameObject);
	}
}
