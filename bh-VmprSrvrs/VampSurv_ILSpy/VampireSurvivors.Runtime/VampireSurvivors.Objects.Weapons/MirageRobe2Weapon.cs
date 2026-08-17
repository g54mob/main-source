namespace VampireSurvivors.Objects.Weapons;

public class MirageRobe2Weapon : MirageRobeWeapon
{
	protected override void OnStart()
	{
		collides = false;
		((Weapon)this).OnStart();
		if (collides)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider projectileOnProjectileCollider = physics.add.collider(_projectilePool, _projectilePool, null, processCallback, callbackContext);
			base.ProjectileOnProjectileCollider = projectileOnProjectileCollider;
		}
	}

	public MirageRobe2Weapon()
	{
		collides = true;
		((Weapon)this)._002Ector();
	}
}
