namespace VampireSurvivors.Framework.Particles;

public class GravityWellConfig
{
	public float? _x;

	public float? _y;

	public float _power;

	public float _epsilon;

	public float _gravity;

	public bool _usePauseSystem;

	public bool requiresLateUpdate;

	public bool preCacheParticles;

	public GravityWellConfig()
	{
		//IL_001b: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		_epsilon = 100f;
		_x = (float?)(object)1;
		_y = (float?)(object)1;
		_gravity = 50f;
		_usePauseSystem = true;
		preCacheParticles = true;
	}
}
