using Cpp2ILInjected;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters.Enemies.DLC6;

public class EME_TeleporterBoss : EnemyControllerBoss
{
	private BackgroundEmerald.EmeraldsBiomes _bossBiome;

	private string[] _teleportKeysToActivate;

	protected override void Die()
	{
		//IL_0054: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_006c: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00a8: Expected O, but got I
		//IL_00de: Expected O, but got I4
		base.Die();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundEmerald fancyBg = (BackgroundEmerald)stage._fancyBg;
		if ((object)stage._fancyBg == null)
		{
			return;
		}
		nint num = (nint)typeof(BackgroundEmerald);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v11+FFFFFFF8+v84 @ rax_v6*8]");
			if (0 == (nint)typeof(BackgroundEmerald))
			{
				obj3 = 1;
				goto IL_012e;
			}
		}
		obj3 = 0;
		goto IL_012e;
		IL_012e:
		bool flag = obj3 == null;
		BackgroundEmerald backgroundEmerald = null;
		if (!flag)
		{
			backgroundEmerald = (BackgroundEmerald)stage._fancyBg;
		}
		backgroundEmerald?.TeleportBossKilled(_bossBiome, _teleportKeysToActivate);
	}
}
