namespace CTS
{
	public class FinancialMenuButton : InterfaceButton
	{
		public static FinancialMenuButton Instance { get; private set; }

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
