using UnityEngine;
using UnityEngine.UI;

public class DamageTracker : MonoBehaviour
{
	public enum IncomeType
	{
		Monster = 0,
		House = 1,
		Haunted = 2,
		Bonus = 3,
		Tree = 4,
		Penalty = 5
	}

	public static DamageTracker instance;

	private int displayType;

	[SerializeField]
	private Text roundTypeText;

	public GameObject uiObject;

	[SerializeField]
	private Text healthDmg;

	[SerializeField]
	private Text armorDmg;

	[SerializeField]
	private Text shieldDmg;

	[SerializeField]
	private Text totalDmg;

	[SerializeField]
	private Text cost;

	[SerializeField]
	private Text ratio;

	[SerializeField]
	private Text incomeTotals;

	[SerializeField]
	private Text incomePercent;

	private Vector3[] towerDamage = new Vector3[18];

	private Vector3[] towerDamageThisRound = new Vector3[18];

	private int[] towerCost = new int[18];

	private int[] income = new int[6];

	private float timer;

	private void Awake()
	{
		instance = this;
	}

	private void FixedUpdate()
	{
		if (uiObject.gameObject.activeInHierarchy)
		{
			timer += Time.fixedDeltaTime;
			if (timer >= 1f)
			{
				timer = 0f;
				DisplayDamageTotals();
			}
		}
	}

	public void AddDamage(TowerType type, int healthDmg, int armorDmg, int shieldDmg)
	{
		towerDamage[(int)type].x += (float)healthDmg / 1000f;
		towerDamage[(int)type].y += (float)armorDmg / 1000f;
		towerDamage[(int)type].z += (float)shieldDmg / 1000f;
		towerDamageThisRound[(int)type].x += (float)healthDmg / 1000f;
		towerDamageThisRound[(int)type].y += (float)armorDmg / 1000f;
		towerDamageThisRound[(int)type].z += (float)shieldDmg / 1000f;
	}

	public void ToggleRoundDisplay()
	{
		displayType = (displayType + 1) % 2;
		DisplayDamageTotals();
	}

	private Vector3[] GetDisplayArray()
	{
		if (displayType == 0)
		{
			return towerDamage;
		}
		return towerDamageThisRound;
	}

	public void NewRound()
	{
		for (int i = 0; i < 18; i++)
		{
			towerDamageThisRound[i] = Vector3.zero;
		}
	}

	public void AddCost(TowerType type, int gold)
	{
		towerCost[(int)type] += gold;
	}

	public void AddIncome(IncomeType type, int gold)
	{
		income[(int)type] += gold;
	}

	public void DisplayIncomeTotals()
	{
		float num = 0f;
		for (int i = 0; i < income.Length; i++)
		{
			num += (float)Mathf.Max(income[i], 1);
		}
		num = Mathf.Max(num, 1f);
		string text = "Gold Generated\n" + income[0] + "g\n" + income[1] + "g\n" + income[2] + "g\n" + income[3] + "g\n" + income[4] + "g\n" + income[5] + "g\n";
		incomeTotals.text = text;
		string text2 = "Income Share\n" + Mathf.FloorToInt((float)(100 * income[0]) / num) + "%\n" + Mathf.FloorToInt((float)(100 * income[1]) / num) + "%\n" + Mathf.FloorToInt((float)(100 * income[2]) / num) + "%\n" + Mathf.FloorToInt((float)(100 * income[3]) / num) + "%\n" + Mathf.FloorToInt((float)(100 * income[4]) / num) + "%\n" + Mathf.FloorToInt((float)(100 * income[5]) / num) + "%\n";
		incomePercent.text = text2;
	}

	public void DisplayDamageTotals()
	{
		uiObject.SetActive(value: true);
		DisplayIncomeTotals();
		if (displayType == 0)
		{
			roundTypeText.text = "Tower Damage (total)";
		}
		else
		{
			roundTypeText.text = "Tower Damage (this level)";
		}
		Vector3[] displayArray = GetDisplayArray();
		string text = "Health\n" + (int)displayArray[0].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[0].x)) + "%)\n" + (int)displayArray[1].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[1].x)) + "%)\n" + (int)displayArray[2].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[2].x)) + "%)\n" + (int)displayArray[3].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[3].x)) + "%)\n" + (int)displayArray[5].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[5].x)) + "%)\n" + (int)displayArray[6].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[6].x)) + "%)\n" + (int)displayArray[12].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[12].x)) + "%)\n" + (int)displayArray[13].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[13].x)) + "%)\n" + (int)displayArray[14].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[14].x)) + "%)\n" + (int)displayArray[15].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[15].x)) + "%)\n" + (int)displayArray[16].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[16].x)) + "%)\n" + (int)displayArray[17].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[17].x)) + "%)\n" + (int)displayArray[8].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[8].x)) + "%)\n" + (int)displayArray[4].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[4].x)) + "%)\n" + (int)displayArray[9].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[9].x)) + "%)\n" + (int)displayArray[10].x + "K (" + Mathf.FloorToInt(100f * HealthPercentage(displayArray[10].x)) + "%)\n";
		healthDmg.text = text;
		string text2 = "Armor\n" + (int)displayArray[0].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[0].y)) + "%)\n" + (int)displayArray[1].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[1].y)) + "%)\n" + (int)displayArray[2].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[2].y)) + "%)\n" + (int)displayArray[3].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[3].y)) + "%)\n" + (int)displayArray[5].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[5].y)) + "%)\n" + (int)displayArray[6].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[6].y)) + "%)\n" + (int)displayArray[12].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[12].y)) + "%)\n" + (int)displayArray[13].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[13].y)) + "%)\n" + (int)displayArray[14].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[14].y)) + "%)\n" + (int)displayArray[15].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[15].y)) + "%)\n" + (int)displayArray[16].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[16].y)) + "%)\n" + (int)displayArray[17].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[17].y)) + "%)\n" + (int)displayArray[8].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[8].y)) + "%)\n" + (int)displayArray[4].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[4].y)) + "%)\n" + (int)displayArray[9].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[9].y)) + "%)\n" + (int)displayArray[10].y + "K (" + Mathf.FloorToInt(100f * ArmorPercentage(displayArray[10].y)) + "%)\n";
		armorDmg.text = text2;
		string text3 = "Shield\n" + (int)displayArray[0].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[0].z)) + "%)\n" + (int)displayArray[1].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[1].z)) + "%)\n" + (int)displayArray[2].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[2].z)) + "%)\n" + (int)displayArray[3].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[3].z)) + "%)\n" + (int)displayArray[5].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[5].z)) + "%)\n" + (int)displayArray[6].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[6].z)) + "%)\n" + (int)displayArray[12].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[12].z)) + "%)\n" + (int)displayArray[13].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[13].z)) + "%)\n" + (int)displayArray[14].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[14].z)) + "%)\n" + (int)displayArray[15].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[15].z)) + "%)\n" + (int)displayArray[16].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[16].z)) + "%)\n" + (int)displayArray[17].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[17].z)) + "%)\n" + (int)displayArray[8].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[8].z)) + "%)\n" + (int)displayArray[4].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[4].z)) + "%)\n" + (int)displayArray[9].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[9].z)) + "%)\n" + (int)displayArray[10].z + "K (" + Mathf.FloorToInt(100f * ShieldPercentage(displayArray[10].z)) + "%)\n";
		shieldDmg.text = text3;
		string text4 = "Total\n" + (int)(displayArray[0].x + displayArray[0].y + displayArray[0].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[0].x + displayArray[0].y + displayArray[0].z)) + "%)\n" + (int)(displayArray[1].x + displayArray[1].y + displayArray[1].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[1].x + displayArray[1].y + displayArray[1].z)) + "%)\n" + (int)(displayArray[2].x + displayArray[2].y + displayArray[2].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[2].x + displayArray[2].y + displayArray[2].z)) + "%)\n" + (int)(displayArray[3].x + displayArray[3].y + displayArray[3].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[3].x + displayArray[3].y + displayArray[3].z)) + "%)\n" + (int)(displayArray[5].x + displayArray[5].y + displayArray[5].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[5].x + displayArray[5].y + displayArray[5].z)) + "%)\n" + (int)(displayArray[6].x + displayArray[6].y + displayArray[6].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[6].x + displayArray[6].y + displayArray[6].z)) + "%)\n" + (int)(displayArray[12].x + displayArray[12].y + displayArray[12].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[12].x + displayArray[12].y + displayArray[12].z)) + "%)\n" + (int)(displayArray[13].x + displayArray[13].y + displayArray[13].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[13].x + displayArray[13].y + displayArray[13].z)) + "%)\n" + (int)(displayArray[14].x + displayArray[14].y + displayArray[14].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[14].x + displayArray[14].y + displayArray[14].z)) + "%)\n" + (int)(displayArray[15].x + displayArray[15].y + displayArray[15].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[15].x + displayArray[15].y + displayArray[15].z)) + "%)\n" + (int)(displayArray[16].x + displayArray[16].y + displayArray[16].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[16].x + displayArray[16].y + displayArray[16].z)) + "%)\n" + (int)(displayArray[17].x + displayArray[17].y + displayArray[17].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[17].x + displayArray[17].y + displayArray[17].z)) + "%)\n" + (int)(displayArray[8].x + displayArray[8].y + displayArray[8].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[8].x + displayArray[8].y + displayArray[8].z)) + "%)\n" + (int)(displayArray[4].x + displayArray[4].y + displayArray[4].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[4].x + displayArray[4].y + displayArray[4].z)) + "%)\n" + (int)(displayArray[9].x + displayArray[9].y + displayArray[9].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[9].x + displayArray[9].y + displayArray[9].z)) + "%)\n" + (int)(displayArray[10].x + displayArray[10].y + displayArray[10].z) + "K (" + Mathf.FloorToInt(100f * DamagePercentage(displayArray[10].x + displayArray[10].y + displayArray[10].z)) + "%)\n";
		totalDmg.text = text4;
		string text5 = "Cost\n" + towerCost[0] + "g\n" + towerCost[1] + "g\n" + towerCost[2] + "g\n" + towerCost[3] + "g\n" + towerCost[5] + "g\n" + towerCost[6] + "g\n" + towerCost[12] + "g\n" + towerCost[13] + "g\n" + towerCost[14] + "g\n" + towerCost[15] + "g\n" + towerCost[16] + "g\n" + towerCost[17] + "g\n" + towerCost[8] + "g\n" + towerCost[4] + "g\n" + towerCost[9] + "g\n";
		cost.text = text5;
		string text6 = "Dmg/g\n" + (1000f * ((displayArray[0].x + displayArray[0].y + displayArray[0].z) / (float)Mathf.Max(towerCost[0], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[1].x + displayArray[1].y + displayArray[1].z) / (float)Mathf.Max(towerCost[1], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[2].x + displayArray[2].y + displayArray[2].z) / (float)Mathf.Max(towerCost[2], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[3].x + displayArray[3].y + displayArray[3].z) / (float)Mathf.Max(towerCost[3], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[5].x + displayArray[5].y + displayArray[5].z) / (float)Mathf.Max(towerCost[5], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[6].x + displayArray[6].y + displayArray[6].z) / (float)Mathf.Max(towerCost[6], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[12].x + displayArray[12].y + displayArray[12].z) / (float)Mathf.Max(towerCost[12], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[13].x + displayArray[13].y + displayArray[13].z) / (float)Mathf.Max(towerCost[13], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[14].x + displayArray[14].y + displayArray[14].z) / (float)Mathf.Max(towerCost[14], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[15].x + displayArray[15].y + displayArray[15].z) / (float)Mathf.Max(towerCost[15], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[16].x + displayArray[16].y + displayArray[16].z) / (float)Mathf.Max(towerCost[16], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[17].x + displayArray[17].y + displayArray[17].z) / (float)Mathf.Max(towerCost[17], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[8].x + displayArray[8].y + displayArray[8].z) / (float)Mathf.Max(towerCost[8], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[4].x + displayArray[4].y + displayArray[4].z) / (float)Mathf.Max(towerCost[4], 1))).ToString("F2") + "\n" + (1000f * ((displayArray[9].x + displayArray[9].y + displayArray[9].z) / (float)Mathf.Max(towerCost[9], 1))).ToString("F2") + "\n";
		ratio.text = text6;
	}

	private float DamagePercentage(float portion)
	{
		return portion / Mathf.Max(DamageTotal(), 1E-07f);
	}

	private float HealthPercentage(float portion)
	{
		return portion / Mathf.Max(HealthDamageTotal(), 1E-07f);
	}

	private float ArmorPercentage(float portion)
	{
		return portion / Mathf.Max(ArmorDamageTotal(), 1E-07f);
	}

	private float ShieldPercentage(float portion)
	{
		return portion / Mathf.Max(ShieldDamageTotal(), 1E-07f);
	}

	private float DamageTotal()
	{
		return HealthDamageTotal() + ArmorDamageTotal() + ShieldDamageTotal();
	}

	private float HealthDamageTotal()
	{
		Vector3[] displayArray = GetDisplayArray();
		return displayArray[0].x + displayArray[1].x + displayArray[2].x + displayArray[3].x + displayArray[5].x + displayArray[6].x + displayArray[12].x + displayArray[13].x + displayArray[14].x + displayArray[15].x + displayArray[16].x + displayArray[17].x + displayArray[8].x + displayArray[4].x + displayArray[9].x + displayArray[10].x;
	}

	private float ArmorDamageTotal()
	{
		Vector3[] displayArray = GetDisplayArray();
		return displayArray[0].y + displayArray[1].y + displayArray[2].y + displayArray[3].y + displayArray[5].y + displayArray[6].y + displayArray[12].y + displayArray[13].y + displayArray[14].y + displayArray[15].y + displayArray[16].y + displayArray[17].y + displayArray[8].y + displayArray[4].y + displayArray[9].y + displayArray[10].y;
	}

	private float ShieldDamageTotal()
	{
		Vector3[] displayArray = GetDisplayArray();
		return displayArray[0].z + displayArray[1].z + displayArray[2].z + displayArray[3].z + displayArray[5].z + displayArray[6].z + displayArray[12].z + displayArray[13].z + displayArray[14].z + displayArray[15].z + displayArray[16].z + displayArray[17].z + displayArray[8].z + displayArray[4].z + displayArray[9].z + displayArray[10].z;
	}
}
