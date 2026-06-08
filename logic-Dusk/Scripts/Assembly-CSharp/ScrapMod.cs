using System;

public class ScrapMod : IModification
{
	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.None;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Convert into scrap";
		}
	}

	public string Description
	{
		get
		{
			return "this item is converted to scrap that can be used to perform other modifications";
		}
	}

	public int ScrapCost { get; private set; }

	public int MaxAllowed
	{
		get
		{
			return 1;
		}
	}

	public string TargetName
	{
		get
		{
			return "Scrap Pile";
		}
	}

	public IUIItem AffectedItem { get; set; }

	private ScrapMod()
	{
	}

	public ScrapMod(int scrap)
	{
		ScrapCost = scrap;
	}

	public void SetTarget(object itemToReceiveMod)
	{
	}

	public bool CanApplyModToTarget()
	{
		return true;
	}

	public void ApplyModToTarget()
	{
	}

	public IModification CopyModification()
	{
		throw new NotImplementedException();
	}
}
