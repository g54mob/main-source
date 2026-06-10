using NaughtyAttributes;
using UnityEngine;

public class ModifiersController : MonoBehaviour
{
	private static ModifiersController _instance;

	[Header("Rat Control Properties")]
	public bool ratDetectiveActive;

	public bool ratDetectiveModifierEnabled;

	public float RatPlayerSpotDistance;

	public GameObject autoTravelToggle;

	public SphereCollider playerCameraCollider;

	public CapsuleCollider playerCapsuleCollider;

	public Vector3 ratCameraOffset;

	[Header("Film Noir Properties")]
	public bool filmNoirModifierEnabled;

	private float _stashedSaturationValue;

	[Header("Snail Nemesis Properties")]
	public bool snailNemesisModifierEnabled;

	public GameObject snailPrefab;

	public SnailController currentSnail;

	[Header("Ironman Properties")]
	public bool ironmanModifierEnabled;

	[Header("Short-Sighted Properties")]
	public bool shortSightedModifierEnabled;

	public bool playerHasGlasses;

	public float shortSightedDofNearStart;

	public float shortSightedDofNearEnd;

	public float shortSightedDofFarStart;

	public float shortSightedDofFarEnd;

	[Header("Gambling Debt Properties")]
	public bool gamblingDebtModifierEnabled;

	[Header("House Arrest Properties")]
	public bool houseArrestModifierEnabled;

	[Header("House Arrest Properties")]
	public bool fameAndFortuneModifierEnabled;

	public float fameAndFortuneChance;

	public float fameAndFortuneCombatChance;

	public static ModifiersController Instance => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public float QuickRange(float val, float min, float max)
	{
		return 0f;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateFilmNoir()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateFilmNoir()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateShortSighted()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateShortSighted()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateGambingDebt()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateGamblingDebt()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateHouseArrest()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateHouseArrest()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateFameAndFortune()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateFameAndFortune()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateIronman()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateIronman()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateRatModifier()
	{
	}

	public void ApplyRatCameraOffset(bool useOffset)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateRatModifier()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeactivateSnailNemesis()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ActivateSnailNemesis()
	{
	}

	public void OnNewGameStarted(bool loadedSaveGame)
	{
	}

	private void SpawnNewSnail(SnailController.SnailSaveData loadData = null)
	{
	}

	private void RemoveCurrentSnail()
	{
	}

	public void ShortSightedGlassesCheck()
	{
	}

	public void ChanceToDropGlasses(float chance)
	{
	}

	public bool HouseArrestTrespass(NewRoom roomRef)
	{
		return false;
	}
}
