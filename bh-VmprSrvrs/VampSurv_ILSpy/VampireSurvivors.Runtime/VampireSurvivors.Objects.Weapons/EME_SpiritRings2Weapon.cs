using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class EME_SpiritRings2Weapon : EME_SpiritRings1Weapon
{
	protected override bool IsEvolved => true;

	protected override void OnStart()
	{
		base.OnStart();
		float num = base.PInterval();
		float num2 = default(float);
		_elapsed_Firee = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulps xmm1,[188A12570h]\"");
		float elapsed_Chaos = num2 * 13f;
		_elapsed_Water = num2;
		_elapsed_Chaos = elapsed_Chaos;
	}

	public EME_SpiritRings2Weapon()
	{
		base._sunlightPoolCount = 50;
		base._aquaSpherePoolCount = 10;
		base._heavensThunderPoolCount = 50;
		base._hyperGravityPoolCount = 1;
		base._vermillionSandsPoolCount = 1;
		base._chaosDisasterPoolCount = 1;
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		base._glimmerNames = glimmerNames;
		((Weapon)this)._002Ector();
	}
}
