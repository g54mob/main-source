using System;
using UnityEngine;

[Serializable]
public class CheatLooks
{
	public bool customBodyMat;

	public Material bodyMat;

	public bool customLegMat;

	public Material legMat;

	public bool customNoseEarMat;

	public Material noseEarMat;

	public bool replaceHeadTexture;

	public Material newHeadMat;

	public bool customBodyScale;

	public float bodyScaleX;

	public float bodyScaleY;

	public float bodyScaleZ;

	public float bodyScaleYZ;

	public bool customBodyScaleGlobal;

	public float bodyScaleGlobal;

	public bool customTailSize;

	public float tailSize;

	public bool customTailNum;

	public int tailNum;

	public bool customTailType;

	public TailType tailType;

	public bool customNoseType;

	public NoseType noseType;

	public bool customNoseModA;

	public float noseModA;

	public bool customSnoutModA;

	public float snoutModA;

	public bool customSnoutModB;

	public float snoutModB;

	public bool customSnoutModC;

	public float snoutModC;

	public bool customHeadSize;

	public float headSize;

	public bool customHeadNumber;

	public int headNumber;

	public bool customEarType;

	public EarType earType;

	public bool customEarModA;

	public float earModA;

	public bool customFrontLegNum;

	public int frontLegPairNum;

	public bool customBackLegNum;

	public int backLegPairNum;

	public bool customWingSize;

	public float wingSize;

	public bool customWingType;

	public WingType wingType;

	public bool customWingNumber;

	public int wingNumber;

	public bool customLegXZFrontScale;

	public float legXZFrontScale;

	public bool customLegXZBackScale;

	public float legXZBackScale;

	public bool customLegYFrontTopScale;

	public float legYFrontTopScale;

	public bool customLegYFrontBotScale;

	public float legYFrontBotScale;

	public bool customLegYBackTopScale;

	public float legYBackTopScale;

	public bool customLegYBackBotScale;

	public float legYBackBotScale;

	public bool customStanceWidthFront;

	public float frontStanceWidth;

	public bool customStanceWidthBack;

	public float backStanceWidth;

	public Material GetBodyMat(Material baseMat)
	{
		if (!customBodyMat)
		{
			return baseMat;
		}
		return bodyMat;
	}

	public Material GetLegMat(Material baseMat)
	{
		if (!customLegMat)
		{
			return baseMat;
		}
		return legMat;
	}

	public Material GetNoseEarMat(Material baseMat)
	{
		if (!customNoseEarMat)
		{
			return baseMat;
		}
		return noseEarMat;
	}

	public Material GetHeadMat(Material baseMat)
	{
		if (!replaceHeadTexture)
		{
			return baseMat;
		}
		return newHeadMat;
	}

	public float GetBodyScaleX(float baseScale)
	{
		if (!customBodyScale)
		{
			return baseScale;
		}
		return bodyScaleX;
	}

	public float GetBodyScaleY(float baseScale)
	{
		if (!customBodyScale)
		{
			return baseScale;
		}
		return bodyScaleY;
	}

	public float GetBodyScaleZ(float baseScale)
	{
		if (!customBodyScale)
		{
			return baseScale;
		}
		return bodyScaleZ;
	}

	public float GetBodyScaleYZ(float baseScale)
	{
		if (!customBodyScale)
		{
			return baseScale;
		}
		return bodyScaleYZ;
	}

	public float GetBodyScaleGlobal(float baseScale)
	{
		if (!customBodyScaleGlobal)
		{
			return baseScale;
		}
		return bodyScaleGlobal;
	}

	public float GetCustomTailSize(float baseSize)
	{
		if (!customTailSize)
		{
			return baseSize;
		}
		return tailSize;
	}

	public int GetCustomTailNum(int baseNum)
	{
		if (!customTailNum)
		{
			return baseNum;
		}
		return tailNum;
	}

	public TailType GetCustomTailType(TailType baseType)
	{
		if (!customTailType)
		{
			return baseType;
		}
		return tailType;
	}

	public float GetCustomWingSize(float baseSize)
	{
		if (!customWingSize)
		{
			return baseSize;
		}
		return wingSize;
	}

	public int GetCustomWingNum(int baseNum)
	{
		if (!customWingNumber)
		{
			return baseNum;
		}
		return wingNumber;
	}

	public WingType GetCustomWingType(WingType baseType)
	{
		if (!customWingType)
		{
			return baseType;
		}
		return wingType;
	}

	public NoseType GetCustomNoseType(NoseType baseType)
	{
		if (!customNoseType)
		{
			return baseType;
		}
		return noseType;
	}

	public float GetCustomNoseModA(float baseNum)
	{
		if (!customNoseModA)
		{
			return baseNum;
		}
		return noseModA;
	}

	public float GetCustomSnoutModA(float baseNum)
	{
		if (!customSnoutModA)
		{
			return baseNum;
		}
		return snoutModA;
	}

	public float GetCustomSnoutModB(float baseNum)
	{
		if (!customSnoutModB)
		{
			return baseNum;
		}
		return snoutModB;
	}

	public float GetCustomSnoutModC(float baseNum)
	{
		if (!customSnoutModC)
		{
			return baseNum;
		}
		return snoutModC;
	}

	public float GetCustomHeadSize(float baseSize)
	{
		if (!customHeadSize)
		{
			return baseSize;
		}
		return headSize;
	}

	public int GetCustomHeadNumber(int baseNum)
	{
		if (!customHeadNumber)
		{
			return baseNum;
		}
		return headNumber;
	}

	public EarType GetCustomEarType(EarType baseType)
	{
		if (!customEarType)
		{
			return baseType;
		}
		return earType;
	}

	public float GetCustomEarModA(float baseMod)
	{
		if (!customEarModA)
		{
			return baseMod;
		}
		return earModA;
	}

	public int GetCustomFrontLegNum(int baseNum)
	{
		if (!customFrontLegNum)
		{
			return baseNum;
		}
		return frontLegPairNum;
	}

	public int GetCustomBackLegNum(int baseNum)
	{
		if (!customBackLegNum)
		{
			return baseNum;
		}
		return backLegPairNum;
	}

	public float GetCustomLegXZFrontScale(float baseNum)
	{
		if (!customLegXZFrontScale)
		{
			return baseNum;
		}
		return legXZFrontScale;
	}

	public float GetCustomLegXZBackScale(float baseNum)
	{
		if (!customLegXZBackScale)
		{
			return baseNum;
		}
		return legXZBackScale;
	}

	public float GetCustomLegYFrontTopScale(float baseNum)
	{
		if (!customLegYFrontTopScale)
		{
			return baseNum;
		}
		return legYFrontTopScale;
	}

	public float GetCustomLegYFrontBotScale(float baseNum)
	{
		if (!customLegYFrontBotScale)
		{
			return baseNum;
		}
		return legYFrontBotScale;
	}

	public float GetCustomLegYBackTopScale(float baseNum)
	{
		if (!customLegYBackTopScale)
		{
			return baseNum;
		}
		return legYBackTopScale;
	}

	public float GetCustomLegYBackBotScale(float baseNum)
	{
		if (!customLegYBackBotScale)
		{
			return baseNum;
		}
		return legYBackBotScale;
	}

	public float GetCustomStanceWidthFront(float baseNum)
	{
		if (!customStanceWidthFront)
		{
			return baseNum;
		}
		return frontStanceWidth;
	}

	public float GetCustomStanceWidthBack(float baseNum)
	{
		if (!customStanceWidthBack)
		{
			return baseNum;
		}
		return backStanceWidth;
	}
}
