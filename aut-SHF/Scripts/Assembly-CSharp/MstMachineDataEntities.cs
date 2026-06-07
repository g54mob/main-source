using System;

[Serializable]
public class MstMachineDataEntities : ICommonEntiies
{
	public eMachine id;

	public int sortNum;

	public eBroadMachineCategory BroadCategory;

	public ePrimaryMachineCategory PrimaryCategory;

	public eSecondaryMachineCategory SecondaryCategory;

	public string ThirdCategory;

	public ePaletteCategory paletteCategory;

	public eGuideCategory guideCategory;

	public eGuideCategory noCursorGuideCategory;

	public eMouseOverDetailCategory mouseOverDetailCategory;

	public eMachineDescSpecTextType specTextType;

	public string name;

	public string desc;

	public int cost1;

	public int cost2;

	public float processingSpeedRate;

	public float processingSpeedAdd;

	public float descCorrection;

	public int unlockLevel;

	public int rarity;

	public int getCount;

	public bool isHidden;

	public bool isDrawable;

	public int reqMinionMin;

	public int reqMinionMax;

	public bool isEliteMinion;

	public bool isReqFuel;

	public bool isBoostInkEngine;

	public bool connectableRecycleBox;

	public int pairSpaceMax;

	public int counterDenominator;

	public bool isCollection;

	public string iconPath;

	public string moviePath;

	public string imagePath;

	public string mapExtendIconPath;

	public bool hasBillboard;

	public bool unbreakable;

	public bool streamType;

	public bool shigenType;

	public bool kakouType;

	public eLuggage naturalResource;

	public string Name => null;

	public string Desc => null;

	public string IconPath => null;

	public override string ToString()
	{
		return null;
	}
}
