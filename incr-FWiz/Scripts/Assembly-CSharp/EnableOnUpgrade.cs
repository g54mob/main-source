using UnityEngine;

public class EnableOnUpgrade : MonoBehaviour
{
	[SerializeField]
	private MonoBehaviour _enableOnUpgrade;

	[SerializeField]
	private UpgradeDef _upgradeDef;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnUpgrade(int i)
	{
	}
}
