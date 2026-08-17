using Unity.Mathematics;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Weapons;

public class VerletTweenNode
{
	public float posX;

	public float posY;

	public float oldX;

	public float oldY;

	public MultiTargetTween tween;

	public bool isStatic;

	public VerletTweenNode(float2 position)
	{
		//IL_000a: Expected F4, but got O
		//IL_001e: Expected F4, but got O
		posX = (float)position;
		float num = default(float);
		posY = num;
		oldX = (float)position;
		oldY = num;
	}
}
