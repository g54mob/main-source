namespace CTS
{
	public class InterimButton : InterfaceButton
	{
		public static InterimButton Instance { get; private set; }

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
