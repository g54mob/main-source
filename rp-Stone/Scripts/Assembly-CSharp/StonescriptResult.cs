using System.Collections.Generic;

public class StonescriptResult
{
	public enum Type
	{
		Error = 0,
		Warning = 1,
		Print = 2,
		LiteralBool = 3,
		LiteralInt = 4,
		LiteralString = 5,
		Equip = 6,
		EquipLeft = 7,
		EquipRight = 8,
		EquipFaerie = 9,
		EquipLoadout = 10,
		ActivateAbility = 11,
		EnableGameElement = 12,
		DisableGameElement = 13,
		PlaySound = 14,
		Brew = 15
	}

	private static Stack<StonescriptResult> resultPool = new Stack<StonescriptResult>();

	public Type type { get; set; }

	public string param { get; set; }

	public bool paramBool { get; set; }

	public int paramInt { get; set; }

	public bool isRecycled { get; set; }

	public void Reset()
	{
		type = Type.Error;
		param = null;
		paramBool = false;
		paramInt = 0;
	}

	public StonescriptResult Clone()
	{
		StonescriptResult stonescriptResult = NewResult();
		stonescriptResult.type = type;
		stonescriptResult.param = param;
		stonescriptResult.paramBool = paramBool;
		stonescriptResult.paramInt = paramInt;
		return stonescriptResult;
	}

	public bool Compare(StonescriptResult compareTo)
	{
		if (compareTo.type != type)
		{
			return false;
		}
		if (compareTo.param != param)
		{
			return false;
		}
		if (compareTo.paramBool != paramBool)
		{
			return false;
		}
		if (compareTo.paramInt != paramInt)
		{
			return false;
		}
		return true;
	}

	public static bool CompareResults(List<StonescriptResult> resultsA, List<StonescriptResult> resultsB)
	{
		if (resultsA.Count != resultsB.Count)
		{
			return false;
		}
		for (int i = 0; i < resultsA.Count; i++)
		{
			if (!resultsA[i].Compare(resultsB[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static StonescriptResult NewResult()
	{
		if (resultPool.Count > 0)
		{
			StonescriptResult stonescriptResult = resultPool.Pop();
			stonescriptResult.isRecycled = false;
			return stonescriptResult;
		}
		return new StonescriptResult();
	}

	public static void Recycle(StonescriptResult result)
	{
		if (!result.isRecycled)
		{
			result.isRecycled = true;
			result.Reset();
			resultPool.Push(result);
		}
	}

	public override string ToString()
	{
		return $"{type} {((param != null) ? param : ((paramInt != 0) ? paramInt.ToString() : (paramBool ? paramBool.ToString() : null)))}";
	}
}
