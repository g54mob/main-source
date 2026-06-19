namespace TH20.ExtContent
{
	[DontSave]
	public class ExtContentManagerDebug
	{
		public class ExtContentDebugConfig
		{
			public bool bTest = true;
		}

		private ExtContentDebugConfig _config;

		public ExtContentManagerDebug(ExtContentDebugConfig config)
		{
			_config = config;
		}

		public void Init(ExtContentManager extContentManager, InputManager inputManager)
		{
		}

		public void DeInit()
		{
		}

		public void Update()
		{
		}
	}
}
