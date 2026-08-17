using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDrownerRash : EnemyDrownerNormal
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		_goNutsMinute = 15f;
		_distanceMultiplier = 0.3f;
		base.InitEnemy(enemyType, asRemote);
	}

	protected override float GetSpawnY()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num = renderer2.height * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v7 (PhaserScene+Renderer)+38]");
		float num2 = 0f - num;
		bool flag = !(-14.08f > num2);
		float result = -14.08f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public EnemyDrownerRash()
	{
		base._isFresh = true;
		_goNutsMinute = 10f;
		_distanceMultiplier = 0.45f;
		((EnemyController)this)._002Ector();
	}
}
