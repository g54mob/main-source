using System;

[Serializable]
public class Training
{
	public int[] _attackCaps = new int[6] { 2500, 15000, 30000, 50000, 70000, 100000 };

	public int[] _defenseCaps = new int[6] { 2500, 15000, 30000, 50000, 70000, 100000 };

	public int[] evilAttackCaps = new int[6] { 250000, 1500000, 3000000, 5000000, 7000000, 10000000 };

	public int[] evilDefenseCaps = new int[6] { 250000, 1500000, 3000000, 5000000, 7000000, 10000000 };

	public long[] _attackTraining = new long[6];

	public long[] _defenseTraining = new long[6];

	public long[] _attackEnergy = new long[6];

	public long[] _defenseEnergy = new long[6];

	public long _totalAttackLevels;

	public long _totalDefenseLevels;

	public float[] _attackBarProgress = new float[6];

	public float[] _defenseBarProgress = new float[6];

	public int[] _trainFactor = new int[6] { 150, 1000, 5000, 20000, 80000, 250000 };

	public bool _hasAutoAdvance;

	public bool _autoAdvanceToggle;

	public int[] attackCaps
	{
		get
		{
			return _attackCaps;
		}
		set
		{
			_attackCaps = value;
		}
	}

	public int[] defenseCaps
	{
		get
		{
			return _defenseCaps;
		}
		set
		{
			_defenseCaps = value;
		}
	}

	public long[] attackTraining
	{
		get
		{
			return _attackTraining;
		}
		set
		{
			_attackTraining = value;
		}
	}

	public long[] defenseTraining
	{
		get
		{
			return _defenseTraining;
		}
		set
		{
			_defenseTraining = value;
		}
	}

	public long[] attackEnergy
	{
		get
		{
			return _attackEnergy;
		}
		set
		{
			_attackEnergy = value;
		}
	}

	public long[] defenseEnergy
	{
		get
		{
			return _defenseEnergy;
		}
		set
		{
			_defenseEnergy = value;
		}
	}

	public long totalAttackLevels
	{
		get
		{
			return _totalAttackLevels;
		}
		set
		{
			_totalAttackLevels = value;
		}
	}

	public long totalDefenseLevels
	{
		get
		{
			return _totalDefenseLevels;
		}
		set
		{
			_totalDefenseLevels = value;
		}
	}

	public float[] attackBarProgress
	{
		get
		{
			return _attackBarProgress;
		}
		set
		{
			_attackBarProgress = value;
		}
	}

	public float[] defenseBarProgress
	{
		get
		{
			return _defenseBarProgress;
		}
		set
		{
			_defenseBarProgress = value;
		}
	}

	public int[] trainFactor
	{
		get
		{
			return _trainFactor;
		}
		set
		{
			_trainFactor = value;
		}
	}

	public bool hasAutoAdvance
	{
		get
		{
			return _hasAutoAdvance;
		}
		set
		{
			_hasAutoAdvance = value;
		}
	}

	public bool autoAdvanceToggle
	{
		get
		{
			return _autoAdvanceToggle;
		}
		set
		{
			_autoAdvanceToggle = value;
		}
	}

	public Training()
	{
		for (int i = 0; i < 6; i++)
		{
			attackTraining[i] = 0L;
			defenseTraining[i] = 0L;
			attackEnergy[i] = 0L;
			defenseEnergy[i] = 0L;
			totalDefenseLevels = 0L;
			totalAttackLevels = 0L;
			attackBarProgress[i] = 0f;
			defenseBarProgress[i] = 0f;
		}
		hasAutoAdvance = false;
		autoAdvanceToggle = false;
	}

	public int getTrainingSize()
	{
		return _attackCaps.Length;
	}

	public double getTotalAttack()
	{
		double num = 0.0;
		for (int i = 0; i < getTrainingSize(); i++)
		{
			num += Math.Pow(attackTraining[i], 1.3) * (double)trainFactor[i];
		}
		return num;
	}

	public double getTotalDefense()
	{
		double num = 0.0;
		for (int i = 0; i < getTrainingSize(); i++)
		{
			num += Math.Pow(defenseTraining[i], 1.3) * (double)trainFactor[i];
		}
		return num;
	}

	public void updateBaseStats(int f0, int f1, int f2, int f3, int f4, int f5)
	{
		trainFactor[0] = f0;
		trainFactor[1] = f1;
		trainFactor[2] = f2;
		trainFactor[3] = f3;
		trainFactor[4] = f4;
		trainFactor[5] = f5;
	}

	public string attackName(int id)
	{
		switch (id)
		{
		case 0:
			return "Idle Attack";
		case 1:
			return "Regular Attack";
		case 2:
			return "Strong Attack";
		case 3:
			return "Parry";
		case 4:
			return "Piercing Attack";
		case 5:
			return "Ultimate Attack";
		default:
			return "Bug. Ah crap...";
		}
	}

	public string defenseName(int id)
	{
		switch (id)
		{
		case 0:
			return "Block";
		case 1:
			return "Defensive Buff";
		case 2:
			return "Heal";
		case 3:
			return "Offensive Buff";
		case 4:
			return "Charge";
		case 5:
			return "Ultimate Buff";
		default:
			return "Bug. Ah crap...";
		}
	}
}
