namespace TH20
{
	public class FogOfWarRendererProxy
	{
		private static FogOfWarRendererProxy _instance;

		public FogOfWarLevelTextureDefinition FogOfWarDefinition;

		public static FogOfWarRendererProxy Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new FogOfWarRendererProxy();
				}
				return _instance;
			}
		}

		public static void Destroy()
		{
			_instance = null;
		}
	}
}
