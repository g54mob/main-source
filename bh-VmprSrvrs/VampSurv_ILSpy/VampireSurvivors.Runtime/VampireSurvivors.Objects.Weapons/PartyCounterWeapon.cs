using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class PartyCounterWeapon : PartyWeapon
{
	protected override void Awake()
	{
		base.Awake();
		FrontFiring = false;
		CircleColors = new uint[8] { 48059u, 8738u, 12303291u, 11189179u, 48059u, 48059u, 48059u, 48059u };
		StarColors = new uint[8] { 187u, 34u, 12303291u, 11184827u, 187u, 187u, 187u, 187u };
		TriangleColors = new uint[8] { 26299u, 26146u, 12281531u, 11167419u, 26299u, 26299u, 26299u, 26299u };
		HeartColors = new uint[8] { 47974u, 8806u, 12303206u, 11189094u, 47974u, 47974u, 47974u, 47974u };
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
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
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}
}
