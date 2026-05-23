using UnityEngine;

public class RoyalForgeUpgrades : MonoBehaviour
{
	public static RoyalForgeUpgrades instance;

	public float meleeDamage = 1f;

	public float rangedDamage = 1f;

	public float meleeResistance = 1f;

	public float rangedResistance = 1f;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
