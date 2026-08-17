using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class TP_WindWhip1_Weapon : Weapon
{
	protected int _fireCounter;

	protected int _specialCounter = 3;

	protected int _subWeaponCounter = 7;

	public override float PPower()
	{
		float num = base.PPower();
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PGrowth();
		return num * num;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		if (++_fireCounter % _specialCounter == 0)
		{
			OnSpecialCounter(skipTriggers);
		}
		if (_fireCounter % _subWeaponCounter == 0)
		{
			OnSubWeaponCounter(skipTriggers);
		}
	}

	public virtual void OnSpecialCounter(bool skipTriggers = false)
	{
	}

	public virtual void OnSubWeaponCounter(bool skipTriggers = false)
	{
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}
}
