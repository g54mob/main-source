using Unity.Burst;

namespace Simulation
{
	public class SchmittTrigger : InvertingSchmittTrigger
	{
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}
	}
}
