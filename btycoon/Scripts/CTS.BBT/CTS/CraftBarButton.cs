namespace CTS
{
	public class CraftBarButton : InterfaceButton
	{
		public static CraftBarButton Instance { get; private set; }

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
