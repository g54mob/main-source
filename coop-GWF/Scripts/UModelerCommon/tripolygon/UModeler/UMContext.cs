namespace tripolygon.UModeler
{
	public class UMContext
	{
		public static UModeler activeModeler;

		public static IModelerEngine engine;

		public static void Init(IModelerEngine engineInst)
		{
			engine = engineInst;
		}
	}
}
