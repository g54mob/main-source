namespace CTS
{
	public class BarButton : InterfaceButton
	{
		public static BarButton Instance { get; private set; }

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
