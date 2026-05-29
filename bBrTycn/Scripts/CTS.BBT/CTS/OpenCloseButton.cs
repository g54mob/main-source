namespace CTS
{
	public class OpenCloseButton : InterfaceElement
	{
		public static OpenCloseButton Instance { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
		}

		private void OnDestroy()
		{
			Instance = null;
		}
	}
}
