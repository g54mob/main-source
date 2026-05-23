using UnityEngine;

public class CaslteUpReciever : MonoBehaviour
{
	[SerializeField]
	private BuildSlot buildSlot;

	private void Start()
	{
		buildSlot.OnUpgradeEarly.AddListener(OnBuild);
	}

	private void OnBuild()
	{
		if ((bool)UpgradeCastleUp.instance)
		{
			UpgradeCastleUp.instance.DecreasePriceOfWallOrTower(buildSlot);
		}
	}
}
