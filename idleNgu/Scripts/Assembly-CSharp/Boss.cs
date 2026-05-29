using UnityEngine;

public class Boss : MonoBehaviour
{
	private double[] _bossAttack = new double[301];

	private double[] _bossDefense = new double[301];

	private double[] _bossRegen = new double[301];

	private double[] _bossCurHP = new double[301];

	private double[] _bossMaxHP = new double[301];

	public string[] bossName = new string[301];

	public string[] bossDesc = new string[301];

	public double[] bossAttack
	{
		get
		{
			return _bossAttack;
		}
		set
		{
			_bossAttack = value;
		}
	}

	public double[] bossDefense
	{
		get
		{
			return _bossDefense;
		}
		set
		{
			_bossDefense = value;
		}
	}

	public double[] bossRegen
	{
		get
		{
			return _bossRegen;
		}
		set
		{
			_bossRegen = value;
		}
	}

	public double[] bossCurHP
	{
		get
		{
			return _bossCurHP;
		}
		set
		{
			_bossCurHP = value;
		}
	}

	public double[] bossMaxHP
	{
		get
		{
			return _bossMaxHP;
		}
		set
		{
			_bossMaxHP = value;
		}
	}

	private void Awake()
	{
		constructBossStats();
	}

	private void Update()
	{
	}

	private void constructBossTextInfo()
	{
	}

	private void constructBossStats()
	{
		double num = 1300000.0;
		double num2 = 700000.0;
		double num3 = 200.0;
		double num4 = 13000000.0;
		double num5 = 13000000.0;
		bossAttack[0] = 50000.0;
		bossDefense[0] = 40000.0;
		bossRegen[0] = 40.0;
		bossCurHP[0] = 500000.0;
		bossMaxHP[0] = 500000.0;
		bossAttack[1] = 100000.0;
		bossDefense[1] = 90000.0;
		bossRegen[1] = 90.0;
		bossCurHP[1] = 1000000.0;
		bossMaxHP[1] = 1000000.0;
		bossAttack[2] = 400000.0;
		bossDefense[2] = 350000.0;
		bossRegen[2] = 350.0;
		bossCurHP[2] = 4000000.0;
		bossMaxHP[2] = 4000000.0;
		bossAttack[3] = 1100000.0;
		bossDefense[3] = 600000.0;
		bossRegen[3] = 170.0;
		bossCurHP[3] = 11000000.0;
		bossMaxHP[3] = 11000000.0;
		for (int i = 4; i < 20; i++)
		{
			num *= 5.0;
			num2 *= 5.0;
			num3 *= 5.0;
			num4 *= 5.0;
			num5 *= 5.0;
			bossAttack[i] = num;
			bossDefense[i] = num2;
			bossRegen[i] = num3;
			bossCurHP[i] = num4;
			bossMaxHP[i] = num5;
		}
		for (int j = 20; j < 301; j++)
		{
			num *= 10.0;
			num2 *= 10.0;
			num3 *= 10.0;
			num4 *= 10.0;
			num5 *= 10.0;
			bossAttack[j] = num;
			bossDefense[j] = num2;
			bossRegen[j] = num3;
			bossCurHP[j] = num4;
			bossMaxHP[j] = num5;
		}
	}

	private void showAllBosses()
	{
		for (int i = 0; i < 301; i++)
		{
		}
	}
}
