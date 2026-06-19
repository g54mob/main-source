using System;
using DevConsole;
using SickDev.CommandSystem;
using UnityEngine;

public static class CheatLookConsoleCommands
{
	[Command]
	public static void genetics_UseCustomBodyScale(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customBodyScale = val;
		}
	}

	[Command]
	public static void genetics_BodyScaleX(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomBodyScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.bodyScaleX = val;
		}
	}

	[Command]
	public static void genetics_BodyScaleZ(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomBodyScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.bodyScaleZ = val;
		}
	}

	[Command]
	public static void genetics_BodyScaleYZ(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomBodyScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.bodyScaleYZ = val;
		}
	}

	[Command]
	public static void genetics_UseCustomBodyScaleGlobal(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customBodyScaleGlobal = val;
		}
	}

	[Command]
	public static void genetics_BodyScaleGlobal(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomBodyScaleGlobal(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.bodyScaleGlobal = val;
		}
	}

	[Command]
	public static void genetics_UseCustomTailSize(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customTailSize = val;
		}
	}

	[Command]
	public static void genetics_TailSize(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomTailSize(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.tailSize = val;
		}
	}

	[Command]
	public static void genetics_UseCustomTailNum(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customTailNum = val;
		}
	}

	[Command]
	public static void genetics_TailNum(int val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomTailNum(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.tailNum = val;
		}
	}

	[Command]
	public static void genetics_UseCustomTailType(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customTailType = val;
		}
	}

	[Command]
	public static void genetics_TailType(string val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomTailType(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.tailType = (TailType)Enum.Parse(typeof(TailType), val);
		}
	}

	[Command]
	public static void genetics_ListTailTypes()
	{
		if (!CheatEngine.CanRunCommand())
		{
			return;
		}
		foreach (TailType value in EnumUtils.GetValues<TailType>())
		{
			DevConsole.Console.Log(value, Color.green);
		}
	}

	[Command]
	public static void genetics_UseCustomWingSize(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customWingSize = val;
		}
	}

	[Command]
	public static void genetics_WingSize(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomWingSize(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.wingSize = val;
		}
	}

	[Command]
	public static void genetics_UseCustomWingNum(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customWingNumber = val;
		}
	}

	[Command]
	public static void genetics_WingNum(int val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomWingNum(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.wingNumber = val;
		}
	}

	[Command]
	public static void genetics_UseCustomWingType(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customWingType = val;
		}
	}

	[Command]
	public static void genetics_WingType(string val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomWingType(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.wingType = (WingType)Enum.Parse(typeof(WingType), val);
		}
	}

	[Command]
	public static void genetics_ListWingTypes()
	{
		if (!CheatEngine.CanRunCommand())
		{
			return;
		}
		foreach (WingType value in EnumUtils.GetValues<WingType>())
		{
			DevConsole.Console.Log(value, Color.green);
		}
	}

	[Command]
	public static void genetics_UseCustomNoseType(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customNoseType = val;
		}
	}

	[Command]
	public static void genetics_NoseType(string val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomNoseType(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.noseType = (NoseType)Enum.Parse(typeof(NoseType), val);
		}
	}

	[Command]
	public static void genetics_UseCustomNoseModA(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customNoseModA = val;
		}
	}

	[Command]
	public static void genetics_NoseModA(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomNoseModA(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.noseModA = val;
		}
	}

	[Command]
	public static void genetics_UseCustomSnoutModA(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customSnoutModA = val;
		}
	}

	[Command]
	public static void genetics_SnoutModA(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomSnoutModA(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.snoutModA = val;
		}
	}

	[Command]
	public static void genetics_UseCustomSnoutModB(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customSnoutModB = val;
		}
	}

	[Command]
	public static void genetics_SnoutModB(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomSnoutModB(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.snoutModB = val;
		}
	}

	[Command]
	public static void genetics_UseCustomSnoutModC(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customSnoutModC = val;
		}
	}

	[Command]
	public static void genetics_SnoutModC(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomSnoutModC(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.snoutModC = val;
		}
	}

	[Command]
	public static void genetics_ListNoseTypes()
	{
		if (!CheatEngine.CanRunCommand())
		{
			return;
		}
		foreach (NoseType value in EnumUtils.GetValues<NoseType>())
		{
			DevConsole.Console.Log(value, Color.green);
		}
	}

	[Command]
	public static void genetics_UseCustomEarType(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customEarType = val;
		}
	}

	[Command]
	public static void genetics_EarType(string val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomEarType(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.earType = (EarType)Enum.Parse(typeof(EarType), val);
		}
	}

	[Command]
	public static void genetics_ListEarTypes()
	{
		if (!CheatEngine.CanRunCommand())
		{
			return;
		}
		foreach (EarType value in EnumUtils.GetValues<EarType>())
		{
			DevConsole.Console.Log(value, Color.green);
		}
	}

	[Command]
	public static void genetics_UseCustomFrontLegPairNum(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customFrontLegNum = val;
		}
	}

	[Command]
	public static void genetics_FrontLegPairNum(int val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomFrontLegPairNum(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.frontLegPairNum = val;
		}
	}

	[Command]
	public static void genetics_UseCustomBackLegPairNum(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customBackLegNum = val;
		}
	}

	[Command]
	public static void genetics_BackLegPairNum(int val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomBackLegPairNum(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.backLegPairNum = val;
		}
	}

	[Command]
	public static void genetics_UseCustomLegXZFrontScale(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customLegXZFrontScale = val;
		}
	}

	[Command]
	public static void genetics_LegXZFrontScale(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomLegXZFrontScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.legXZFrontScale = val;
		}
	}

	[Command]
	public static void genetics_UseCustomLegXZBackScale(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customLegXZBackScale = val;
		}
	}

	[Command]
	public static void genetics_LegXZBackScale(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomLegXZBackScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.legXZBackScale = val;
		}
	}

	[Command]
	public static void genetics_UseCustomLegYFrontTopScale(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customLegYFrontTopScale = val;
		}
	}

	[Command]
	public static void genetics_LegYFrontTopScale(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomLegYFrontTopScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.legYFrontTopScale = val;
		}
	}

	[Command]
	public static void genetics_UseCustomLegYFrontBotScale(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customLegYFrontBotScale = val;
		}
	}

	[Command]
	public static void genetics_LegYFrontBotScale(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomLegYFrontBotScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.legYFrontBotScale = val;
		}
	}

	[Command]
	public static void genetics_UseCustomLegYBackTopScale(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customLegYBackTopScale = val;
		}
	}

	[Command]
	public static void genetics_LegYBackTopScale(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomLegYBackTopScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.legYBackTopScale = val;
		}
	}

	[Command]
	public static void genetics_UseCustomLegYBackBotScale(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customLegYBackBotScale = val;
		}
	}

	[Command]
	public static void genetics_LegYBackBotScale(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomLegYBackBotScale(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.legYBackBotScale = val;
		}
	}

	[Command]
	public static void genetics_UseCustomFrontStanceWidth(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customStanceWidthFront = val;
		}
	}

	[Command]
	public static void genetics_FrontStanceWidth(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomFrontStanceWidth(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.frontStanceWidth = val;
		}
	}

	[Command]
	public static void genetics_UseCustomBackStanceWidth(bool val)
	{
		if (CheatEngine.CanRunCommand())
		{
			CheatEngine.cheatRef.cheatLooks.customStanceWidthBack = val;
		}
	}

	[Command]
	public static void genetics_BackStanceWidth(float val)
	{
		if (CheatEngine.CanRunCommand())
		{
			genetics_UseCustomBackStanceWidth(val: true);
			CheatEngine.cheatRef.manualDogGenetics = true;
			CheatEngine.cheatRef.cheatLooks.backStanceWidth = val;
		}
	}
}
