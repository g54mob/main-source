namespace TH20
{
	public class PostProcessingRendererProxy
	{
		private static PostProcessingRendererProxy _instance;

		public PostProcessingRendererData PostProcessRendererData;

		public static PostProcessingRendererProxy Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PostProcessingRendererProxy();
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
