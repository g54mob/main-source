using UnityEngine;

public class TrailerHacking : MonoBehaviour
{
	public GameManager gameManager;

	public EnhancementUpgrade[] upgrades;

	public EnhancementModule[] modules;

	public EnhancementWagon[] wagons;

	public GameObject bike;

	public GameObject technical;

	public Transform spawnPosition;

	public Transform spawnPosition2;

	private int currentUpgradeIndex;

	private int currentModuleIndex;

	private int currentWagonIndex;
}
