using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Weapons;

public class Backup_PlaneData
{
	public PhaserSprite planeSprite;

	public float curveTime;

	public float2 positionOffset;

	public Timer delay;

	public bool available = true;

	public bool moving;

	public Timer[] explosionTimers;

	public float2 direction;
}
