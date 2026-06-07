using Unity.Mathematics;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Weapons
{
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
		}
	}
}
