using NSEipix.Base;

namespace NSMedieval.Testing.Autoplay
{
	public class TestManager : MonoSingleton<TestManager>
	{
		public static bool FlattenMap => false;

		public static bool DontDisposeResource => false;

		public static bool SpawnResources => true;
	}
}
