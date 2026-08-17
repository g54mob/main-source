using Unity.Mathematics;

namespace VampireSurvivors.Objects.Projectiles;

public class WhipVerletNode(float2 position)
{
	public float2 position = position;

	public float2 oldPosition = position;

	public bool isStatic;
}
