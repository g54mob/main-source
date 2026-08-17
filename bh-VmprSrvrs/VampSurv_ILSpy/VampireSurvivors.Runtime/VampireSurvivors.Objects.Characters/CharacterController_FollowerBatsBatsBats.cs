using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_FollowerBatsBatsBats : CharacterController
{
	public override bool NeedsCart => false;

	public override float PAmount()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		float num = base.PAmount();
		EggDouble eggDouble = base.PRevivals();
		double num2 = eggDouble._eggVal;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [rax+10h]\"");
		object obj = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018759DE7Ah\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					return -1f / 0f + num;
				}
				goto IL_0103;
			}
		}
		num2 = 1.7976931348623157E+308;
		goto IL_0103;
		IL_0103:
		return (float)num2 + num;
	}

	protected override void OnStop()
	{
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		base._spriteTrail.Reset();
		SpriteTrail spriteTrail = base._spriteTrail;
		spriteTrail._MaxHistory = 0;
		spriteTrail.InitialiseGhosts(expandExisting: true);
	}
}
