using Cpp2ILInjected;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GunsCounterProjectile : GunsProjectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		_firingAngles = new float[4] { 45f, -45f, 225f, -225f };
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 100 Invalid \"Jump target not found in method: 0x18729A680\"");
	}
}
