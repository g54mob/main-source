using UnityEngine;

public class CriminalControls : MonoBehaviour
{
	[Header("Blood Patterns")]
	public SpatterPatternPreset punchSpatter;

	[Header("Weapon References")]
	public MurderWeaponPreset sniperRifle;

	private static CriminalControls _instance;

	public static CriminalControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
